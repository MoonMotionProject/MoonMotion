using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Valve.VR.InteractionSystem;

// Dashing:
// • provides the player with the dashing locomotion
public class Dashing : SingletonBehaviour<Dashing>, ILocomotion
{
	#region variables


	#region control

	[BoxGroup("Control")]
	[Tooltip("the controller operations by which to dash")]
	[ReorderableList]
	public ControllerOperation[] operations;
	
	[BoxGroup("Control")]
	[Tooltip("whether dashing can be canceled via the operation when no target is outlined")]
	public bool cancelable = true;
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

	[BoxGroup("Dashing")]
	[Tooltip("end dashes upon the player colliding with the target collider")]
	public bool endUponTargetCollision = true;

	[BoxGroup("Dashing")]
	[Tooltip("a layer mask by which to end dashes before they reach their target")]
	public LayerMask dashEndingLayerMask = Default.layerMask;

	[BoxGroup("Dashing")]
	[Tooltip("whether to end the dash if farther from the dash starting position than the target position is (in the same direction)")]
	public bool endIfOverdashed = true;

	[BoxGroup("Dashing")]
	[Tooltip("the threshold distance for the player's body to be within the target position to end the dash")]
	public float endingThresholdDistance = Default.thresholdDistance;
	
	[BoxGroup("Dashing")]
	[Tooltip("the magnitude of the dashing force")]
	public float forceMagnitude = 50f;
	
	[BoxGroup("Dashing")]
	[Tooltip("whether to enable skiing upon starting a dash and to disable skiing upon ending a dash")]
	public bool togglesSkiing = true;
	
	[BoxGroup("Dashing")]
	[Tooltip("whether to zero the player's velocities before each dash")]
	public bool zeroVelocitiesBefore = true;
	
	[BoxGroup("Dashing")]
	[Tooltip("whether to zero the player's velocities after each dash")]
	public bool zeroVelocitiesAfter = true;
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
		
		if (zeroVelocitiesAfter)
		{
			MoonMotionPlayer.zeroVelocities();
		}

		potentialCurrentTargetPosition = null;
	}
	
	// method: begin a dash to the given provided raycast hit //
	private void beginDashTo(object raycastHit_RaycastHitProvider)
	{
		SkiingSettings.singleton.heldVersusToggled = false;
		
		if (zeroVelocitiesBefore)
		{
			MoonMotionPlayer.zeroVelocities();
		}
		
		RaycastHit raycastHit = raycastHit_RaycastHitProvider.provideRaycastHit();

		potentialDashStartingPosition = MoonMotionBody.position;
		potentialCurrentTargetPosition = raycastHit.position();
		potentialCurrentTargetCollider = raycastHit.collider;

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
		if (operations.operated() && DashingOutlining.outlinedObject)
		{
			beginDashTo(DashingOutlining.outliningRaycastHit);
		}
		else if
		(
			currentlyDashing &&
			(
				(cancelable && !DashingOutlining.outlinedObject && operations.operated()) ||

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
			currentTargetPosition.attractAsThoughMistargeting<MoonMotionBody, MoonMotionPlayer>(forceMagnitude);
		}
	}
	#endregion updating
}