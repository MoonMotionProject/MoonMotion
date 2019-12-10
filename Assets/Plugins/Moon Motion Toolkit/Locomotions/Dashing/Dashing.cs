using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif
using Valve.VR.InteractionSystem;

// Dashing:
// • provides the player with the dashing locomotion
public class Dashing : SingletonBehaviour<Dashing>, ILocomotion
{
	#region variables


	#region control
	
	#if ODIN_INSPECTOR
	[TabGroup("Control")]
	#else
	[BoxGroup("Control")]
	#endif
	[Tooltip("whether dashing can be canceled via the operation when no target is outlined")]
	public bool isCancelable = true;
	
	#if ODIN_INSPECTOR
	[TabGroup("Control")]
	#else
	[BoxGroup("Control")]
	#endif
	[Tooltip("the controller operations by which to dash")]
	#if ODIN_INSPECTOR
	#if UNITY_EDITOR
    [ListItemSelector("operations_SetSelected")]
	#endif
	#else
	[ReorderableList]
	#endif
	public ControllerOperation[] operations;
	#region selected operation
	#if ODIN_INSPECTOR
	#if UNITY_EDITOR
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
	#endif
	#endregion selected operation
	#endregion control


	#region dashing

	// the (potential) dash starting position //
	public static Vector3? potentialDashStartingPosition = null;
	// the dash starting position the player is currently dashing from (assuming there is one) //
	public static Vector3 dashStartingPosition => potentialDashStartingPosition.GetValueOrDefault();
	
	// the potential target position the player is currently dashing to //
	public static Vector3? potentialCurrentTargetPosition = null;
	// the target position the player is currently dashing to (assuming there is one) //
	public static Vector3 currentTargetPosition => potentialCurrentTargetPosition.GetValueOrDefault();
	// the potential target collider the player is currently dashing to //
	public static Collider potentialCurrentTargetCollider = null;
	
	// whether the player is currently dashing //
	public static bool currentlyDashing => potentialCurrentTargetPosition.isYull();

	#if ODIN_INSPECTOR
	[TabGroup("Dashing")]
	#else
	[BoxGroup("Dashing")]
	#endif
	[Tooltip("end dashes upon the player colliding with the target collider")]
	public bool endUponTargetCollision = true;

	#if ODIN_INSPECTOR
	[TabGroup("Dashing")]
	#else
	[BoxGroup("Dashing")]
	#endif
	[Tooltip("a layer mask by which to end dashes before they reach their target")]
	public LayerMask dashEndingLayerMask = Default.layerMask;

	#if ODIN_INSPECTOR
	[TabGroup("Dashing")]
	#else
	[BoxGroup("Dashing")]
	#endif
	[Tooltip("whether to end the dash if farther from the dash starting position than the target position is (in the same direction)")]
	public bool endIfOverdashed = true;

	#if ODIN_INSPECTOR
	[TabGroup("Dashing")]
	#else
	[BoxGroup("Dashing")]
	#endif
	[Tooltip("the threshold distance for the player's body to be within the target position to end the dash")]
	public float endingThresholdDistance = Default.thresholdDistance;
	
	#if ODIN_INSPECTOR
	[TabGroup("Dashing")]
	#else
	[BoxGroup("Dashing")]
	#endif
	[Tooltip("the magnitude of the dashing force")]
	public float forceMagnitude = 50f;
	
	#if ODIN_INSPECTOR
	[TabGroup("Dashing")]
	#else
	[BoxGroup("Dashing")]
	#endif
	[Tooltip("whether to enable skiing upon starting a dash and to disable skiing upon ending a dash")]
	public bool togglesSkiing = true;
	
	#if ODIN_INSPECTOR
	[TabGroup("Dashing")]
	#else
	[BoxGroup("Dashing")]
	#endif
	[Tooltip("whether to zero the player's velocities before each dash")]
	public bool zeroVelocitiesBefore = true;
	
	#if ODIN_INSPECTOR
	[TabGroup("Dashing")]
	#else
	[BoxGroup("Dashing")]
	#endif
	[Tooltip("whether to zero the player's velocities after each dash")]
	public bool zeroVelocitiesAfter = true;
	
	#if ODIN_INSPECTOR
	[TabGroup("Dashing")]
	#else
	[BoxGroup("Dashing")]
	#endif
	[Tooltip("whether to temporarily lock the player's y position (after dashing, returning the lockedness to what it was before)")]
	public bool temporarilyLockYPosition = true;

	// the lockedness of the player's y position before dashing the last time before starting a dash when temporarily locking the player's y position //
	private bool lastYPositionLockednessBeforeDashing = false;
	#endregion dashing
	#endregion variables




	#region methods


	// method: stop the current dash, if any //
	private void stopDash()
	{
		SkiingSettings.singleton.heldVersusToggled = false;
		if (togglesSkiing)
		{
			Skier.disableSkiing();
		}

		potentialCurrentTargetPosition = null;

		if (temporarilyLockYPosition)
		{
			MoonMotionPlayer.setPositionYLockednessTo(lastYPositionLockednessBeforeDashing);
		}
		
		if (zeroVelocitiesAfter)
		{
			MoonMotionPlayer.zeroVelocities();
		}
	}
	
	// method: begin a dash to the given provided raycast hit //
	private void beginDashTo(object raycastHit_RaycastHitProvider)
	{
		if (zeroVelocitiesBefore)
		{
			MoonMotionPlayer.zeroVelocities();
		}

		if (temporarilyLockYPosition)
		{
			lastYPositionLockednessBeforeDashing = MoonMotionPlayer.positionYLockedness;
			MoonMotionPlayer.lockPositionY();
		}
		
		RaycastHit raycastHit = raycastHit_RaycastHitProvider.provideRaycastHit();

		potentialDashStartingPosition = MoonMotionBody.position;
		potentialCurrentTargetPosition = raycastHit.position();
		potentialCurrentTargetCollider = raycastHit.collider;

		SkiingSettings.singleton.heldVersusToggled = false;
		if (togglesSkiing)
		{
			Skier.enableSkiing();
		}
	}
	#endregion methods




	#region updating

	
	// at each physics update: //
	public override void physicsUpdate()
	{
		if (operations.isOperated() && DashingTargeting.targetedObject)
		{
			beginDashTo(DashingTargeting.targetingRaycastHit);
		}
		else if
		(
			currentlyDashing &&
			(
				(isCancelable && !DashingTargeting.targetedObject && operations.isOperated()) ||

				endUponTargetCollision.and(MoonMotionPlayer.isCollidedWith(potentialCurrentTargetCollider)) ||

				MoonMotionPlayer.isCollidedWith(dashEndingLayerMask) ||

				endIfOverdashed.and(MoonMotionBody.isMoreDistantInSameDirectionalityAs(currentTargetPosition, dashStartingPosition)) ||

				MoonMotionBody.isWithinDistanceOf(currentTargetPosition, endingThresholdDistance)
			)
		)
		{
			stopDash();
		}

		if (currentlyDashing)
		{
			MoonMotionPlayer.applyMistargetedAttractionFrom
			(
				currentTargetPosition,
				dashStartingPosition,
				forceMagnitude
			);
		}
	}
	#endregion updating
}