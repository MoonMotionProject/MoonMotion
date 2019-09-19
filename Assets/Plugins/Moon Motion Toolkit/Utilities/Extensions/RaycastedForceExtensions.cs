using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Raycasted Force Extensions: provides extension methods for handling raycasted force
// #force
public static class RaycastedForceExtensions
{
	#region raycastedly forcing
	// methods: apply a raycasted force with the given or respective tug from this given raycasting position or provider of a raycasting position (respectively) along the given raycast direction, with the given magnitude, affecting rigidbodies with colliders matching the given layer mask (if specified) and only within the given raycasting distance and using the given trigger collider query, only forcing the first object raycasted according to the given 'firstHitOnly' boolean, ensuring inclusion of positional colliders if not only forcing the first object raycasted according to the given 'ensureInclusionOfPositionalCollidersIfNotFirstHitOnly' boolean, diminishing magnitude from the raycasting position (to raycasting distance) to zero using the given curve, then return the set of objects affected //


	#region raycastedly forcing with the given tug

	public static HashSet<GameObject> forceRaycastedly(this Vector3 raycastingPosition, Tug tug, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingPosition.raycastedCollidersAlong
			(
				raycastDirection,
				firstHitOnly,
				raycastDistance,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			).after(rigidbodies =>
				raycastingPosition.forceTarget
				(
					rigidbodies,
					tug,
					magnitude,
					raycastDistance,
					raycastDistanceMagnitudeZeroingCurve
				)).uniqueObjects();

	public static HashSet<GameObject> forceRaycastedly(this Component centerComponent, Tug tug, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerComponent.position().forceRaycastedly
			(
				tug,
				raycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> forceRaycastedly(this GameObject centerObject, Tug tug, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerObject.position().forceRaycastedly
			(
				tug,
				raycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion raycastedly forcing with the given tug


	#region pulling (raycastedly attracting)

	public static HashSet<GameObject> pullAlong(this Vector3 raycastingPosition, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingPosition.forceRaycastedly
			(
				Tug.attraction,
				raycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> pullAlong(this Component centerComponent, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerComponent.position().pullAlong
			(
				raycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> pullAlong(this GameObject centerObject, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerObject.position().pullAlong
			(
				raycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion pulling (raycastedly attracting)


	#region pushing (raycastedly repelling)

	public static HashSet<GameObject> pushAlong(this Vector3 raycastingPosition, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingPosition.forceRaycastedly
			(
				Tug.repulsion,
				raycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> pushAlong(this Component centerComponent, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerComponent.position().pushAlong
			(
				raycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> pushAlong(this GameObject centerObject, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerObject.position().pushAlong
			(
				raycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion pushing (raycastedly repelling)
	#endregion raycastedly forcing
}