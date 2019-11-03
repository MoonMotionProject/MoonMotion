using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

// Sweeping:
// • provides the player with the sweeping locomotion
public class Sweeping : SingletonBehaviour<Sweeping>, ILocomotion
{
	#region variables


	#region control

	#if ODIN_INSPECTOR
	[TabGroup("Control")]
	[ToggleLeft]
	#else
	[BoxGroup("Control")]
	#endif
	[Tooltip("whether sweeping can be canceled via the operation")]
	public bool isCancelable = true;

	#if ODIN_INSPECTOR
	[TabGroup("Control")]
    [ListItemSelector("operations_SetSelected")]
	#else
	[BoxGroup("Control")]
	[ReorderableList]
	#endif
	[Tooltip("the controller operations by which to sweep")]
	public ControllerOperation[] operations;
	#region selected operation
	#if ODIN_INSPECTOR
	[TabGroup("Control")]
	[InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden, Expanded = true)]
	[HideLabel]
    [ShowInInspector]
	#pragma warning disable 0414
    private ControllerOperation operations_ListItemSelected;
	#pragma warning restore 0414
	public void operations_SetSelected(int index)
		=> operations_ListItemSelected = operations.itemOtherwiseDefault(index);
	#endif
	#endregion selected operation
	#endregion control


	#region sweeping
	
	// the potential starting time of the last sweep //
	public static float? potentialSweepStartingTime = null;
	// the starting time of the last sweep (assuming the player has started any sweep yet) //
	public static float sweepStartingTime => potentialSweepStartingTime.GetValueOrDefault();
	
	// the potential sweeping position of the controller the player is currently sweeping via //
	public static Vector3? potentialControllerSweepingPosition = null;
	// the sweeping position of the controller the player is currently sweeping via (assuming the player is sweeping) //
	public static Vector3 controllerSweepingPosition => potentialControllerSweepingPosition.GetValueOrDefault();

	// the (potential) sweep starting position //
	public static Vector3? potentialSweepStartingPosition = null;
	// the sweep starting position the player is currently sweeping from (assuming there is one) //
	public static Vector3 sweepStartingPosition => potentialSweepStartingPosition.GetValueOrDefault();
	
	// the potential target position the player is currently dashing to //
	public static Vector3? potentialCurrentTargetPosition = null;
	// the target position the player is currently dashing to (assuming there is one) //
	public static Vector3 currentTargetPosition => potentialCurrentTargetPosition.GetValueOrDefault();
	
	// whether the player is currently sweeping //
	public static bool currentlySweeping => potentialCurrentTargetPosition.isYull();

	#if ODIN_INSPECTOR
	[TabGroup("Sweeping")]
	#else
	[BoxGroup("Sweeping")]
	#endif
	[Tooltip("the distance away from the player's body to sweep to")]
	public float sweepDistance = 3.6f;

	#if ODIN_INSPECTOR
	[TabGroup("Sweeping")]
	#else
	[BoxGroup("Sweeping")]
	#endif
	[Tooltip("whether to limit the duration of each sweep")]
	public bool limitSweepDuration = true;

	#if ODIN_INSPECTOR
	[TabGroup("Sweeping")]
	#else
	[BoxGroup("Sweeping")]
	#endif
	[Tooltip("the maximum duration for a sweep")]
	[ShowIf("limitSweepDuration")]
	public float sweepDurationLimit = 1f;

	#if ODIN_INSPECTOR
	[TabGroup("Sweeping")]
	#else
	[BoxGroup("Sweeping")]
	#endif
	[Tooltip("the threshold distance for the player's body to be within the target position to end the sweep")]
	public float endingThresholdDistance = Default.thresholdDistance;

	#if ODIN_INSPECTOR
	[TabGroup("Sweeping")]
	[ToggleLeft]
	#else
	[BoxGroup("Sweeping")]
	#endif
	[Tooltip("whether to end the sweep if farther from the sweep starting position than the target position is (in the same direction)")]
	public bool endIfOverswept = true;

	#if ODIN_INSPECTOR
	[TabGroup("Sweeping")]
	#else
	[BoxGroup("Sweeping")]
	#endif
	[Tooltip("a layer mask by which to end sweeps before they reach their target position")]
	public LayerMask sweepEndingLayerMask = Default.layerMask;
	
	#if ODIN_INSPECTOR
	[TabGroup("Sweeping")]
	#else
	[BoxGroup("Sweeping")]
	#endif
	[Tooltip("the magnitude of the sweeping force")]
	public float forceMagnitude = 28f;
	
	#if ODIN_INSPECTOR
	[TabGroup("Sweeping")]
	[ToggleLeft]
	#else
	[BoxGroup("Sweeping")]
	#endif
	[Tooltip("whether to enable skiing upon starting a sweep and to disable skiing upon ending a sweep")]
	public bool togglesSkiing = true;
	
	#if ODIN_INSPECTOR
	[TabGroup("Sweeping")]
	[ToggleLeft]
	#else
	[BoxGroup("Sweeping")]
	#endif
	[Tooltip("whether to zero the player's velocities before each sweep")]
	public bool zeroVelocitiesBefore = true;
	
	#if ODIN_INSPECTOR
	[TabGroup("Sweeping")]
	[ToggleLeft]
	#else
	[BoxGroup("Sweeping")]
	#endif
	[Tooltip("whether to zero the player's velocities after each sweep")]
	public bool zeroVelocitiesAfter = true;
	#endregion sweeping
	#endregion variables




	#region methods


	// method: stop the current sweep, if any //
	private void stopSweep()
	{
		SkiingSettings.singleton.heldVersusToggled = false;
		if (togglesSkiing)
		{
			Skier.disableSkiing();
		}
		
		potentialCurrentTargetPosition = null;
		
		if (zeroVelocitiesAfter)
		{
			MoonMotionPlayer.zeroVelocities();
		}
	}
	
	// method: begin a sweep via the given sweeping controller //
	private void beginSweepVia(Controller sweepingController)
	{
		if (zeroVelocitiesBefore)
		{
			MoonMotionPlayer.zeroVelocities();
		}
		
		potentialSweepStartingTime = time;
		potentialControllerSweepingPosition = sweepingController.position();
		potentialSweepStartingPosition = MoonMotionBody.position;
		potentialCurrentTargetPosition = sweepingController.position.positionAlong
		(
			(
				operations.firstOperatedOperation().inputs.contains(Controller.Input.touchpad) ?
					sweepingController.relativeTouchpadDirectionWhereZeroesIsForward :
					sweepingController.forward()
			).withVectralYZeroed(),
			sweepDistance
		);

		SkiingSettings.singleton.heldVersusToggled = false;
		if (togglesSkiing)
		{
			Skier.enableSkiing();
		}
	}
	#endregion methods




	#region updating


	// at each physics update: //
	private void FixedUpdate()
	{
		if (operations.operated() && !currentlySweeping)
		{
			beginSweepVia(operations.firstOperatedControllerOtherwiseFallback());
		}
		else if
		(
			currentlySweeping &&
			(
				(isCancelable && operations.operated()) ||

				(limitSweepDuration && (timeSince(sweepStartingTime) > sweepDurationLimit)) ||

				MoonMotionBody.isWithinDistanceOf(currentTargetPosition, endingThresholdDistance) ||

				endIfOverswept.and(MoonMotionBody.isMoreDistantInSameDirectionalityAs(currentTargetPosition, sweepStartingPosition)) ||
				
				MoonMotionPlayer.isCollidedWith(sweepEndingLayerMask)
			)
		)
		{
			stopSweep();
		}

		if (currentlySweeping)
		{
			MoonMotionPlayer.applyMistargetedAttractionFrom
			(
				currentTargetPosition,
				controllerSweepingPosition,
				forceMagnitude
			);
		}
	}
	#endregion updating
}