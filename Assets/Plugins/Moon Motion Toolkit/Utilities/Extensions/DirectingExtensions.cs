using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Directing Extensions: provides extension methods for directing (raycastedly directedly forcing (applying directed force to raycasted targets))
// #force #raycasting
public static class DirectingExtensions
{
	// methods: apply a directed force with the given or declared tug from this given raycasting position or provider of a raycasting position (respectively) along the given raycast direction with the given or appropriate distinctivity, with the given magnitude, affecting rigidbodies (ensuring unique rigidbodies; a methods variant to affect rigidbodies repeatedly for each collider hit is not implemented yet) with colliders matching the given layer mask (if specified) and only within the given raycasting distance and using the given trigger collider query, only forcing the first object raycasted according to the given 'firstHitOnly' boolean, ensuring inclusion of positional colliders if not only forcing the first object raycasted according to the given 'ensureInclusionOfPositionalCollidersIfNotFirstHitOnly' boolean, diminishing magnitude from the raycasting position (to raycasting distance) to zero using the given curve, then return the set of objects affected //


	#region directing with the given tug

	public static HashSet<GameObject> direct
	(
		this Vector3 raycastingPosition,
		Tug tug,
		Vector3 raycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingPosition.raycastedRigidbodiesAlong
			(
				raycastDirection,
				firstHitOnly,
				raycastDistance,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			).applyDirectedForceToEachFrom
			(
				raycastingPosition,
				raycastDirection * tug.asOppositeSign(),
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve
			).uniqueObjects();

	public static HashSet<GameObject> direct
	(
		this GameObject raycastingObject,
		Tug tug,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.raycastedRigidbodiesAlong
			(
				raycastDirection,
				raycastDistinctivity,
				firstHitOnly,
				raycastDistance,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			).applyDirectedForceToEachFrom
			(
				raycastingObject,
				raycastDirection * tug.asOppositeSign(),
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve
			).uniqueObjects();
	public static HashSet<GameObject> direct
	(
		this GameObject raycastingObject,
		Tug tug,
		Vector3 localRaycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.direct
			(
				tug,
				localRaycastDirection,
				Distinctivity.relative,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> directGlobally
	(
		this GameObject raycastingObject,
		Tug tug,
		Vector3 raycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.direct
			(
				tug,
				raycastDirection,
				Distinctivity.absolute,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> direct
	(
		this Component raycastingComponent,
		Tug tug,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.gameObject.direct
			(
				tug,
				raycastDirection,
				raycastDistinctivity,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> direct
	(
		this Component raycastingComponent,
		Tug tug,
		Vector3 localRaycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.direct
			(
				tug,
				localRaycastDirection,
				Distinctivity.relative,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> directGlobally
	(
		this Component raycastingComponent,
		Tug tug,
		Vector3 raycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.direct
			(
				tug,
				raycastDirection,
				Distinctivity.absolute,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion directing with the given tug


	#region directly pulling (directing with attraction)

	public static HashSet<GameObject> directlyPullAlong
	(
		this Vector3 raycastingPosition,
		Vector3 raycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingPosition.direct
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

	public static HashSet<GameObject> directlyPullAlong
	(
		this GameObject raycastingObject,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.direct
			(
				Tug.attraction,
				raycastDirection,
				raycastDistinctivity,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> directlyPullAlong
	(
		this GameObject raycastingObject,
		Vector3 localRaycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.directlyPullAlong
			(
				localRaycastDirection,
				Distinctivity.relative,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> directlyPullAlongGlobal
	(
		this GameObject raycastingObject,
		Vector3 raycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.directlyPullAlong
			(
				raycastDirection,
				Distinctivity.absolute,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> directlyPullAlong
	(
		this Component raycastingComponent,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.gameObject.directlyPullAlong
			(
				raycastDirection,
				raycastDistinctivity,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> directlyPullAlong
	(
		this Component raycastingComponent,
		Vector3 localRaycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.directlyPullAlong
			(
				localRaycastDirection,
				Distinctivity.relative,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> directlyPullAlongGlobal
	(
		this Component raycastingComponent,
		Vector3 raycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.directlyPullAlong
			(
				raycastDirection,
				Distinctivity.absolute,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion directly pulling (directing with attraction)


	#region directly pushing (directing with repulsion)

	public static HashSet<GameObject> directlyPushAlong
	(
		this Vector3 raycastingPosition,
		Vector3 raycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingPosition.direct
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

	public static HashSet<GameObject> directlyPushAlong
	(
		this GameObject raycastingObject,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.direct
			(
				Tug.repulsion,
				raycastDirection,
				raycastDistinctivity,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> directlyPushAlong
	(
		this GameObject raycastingObject,
		Vector3 localRaycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.directlyPushAlong
			(
				localRaycastDirection,
				Distinctivity.relative,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> directlyPushAlongGlobal
	(
		this GameObject raycastingObject,
		Vector3 raycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingObject.directlyPushAlong
			(
				raycastDirection,
				Distinctivity.absolute,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> directlyPushAlong
	(
		this Component raycastingComponent,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.gameObject.directlyPushAlong
			(
				raycastDirection,
				raycastDistinctivity,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> directlyPushAlong
	(
		this Component raycastingComponent,
		Vector3 localRaycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.directlyPushAlong
			(
				localRaycastDirection,
				Distinctivity.relative,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> directlyPushAlongGlobal
	(
		this Component raycastingComponent,
		Vector3 raycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	raycastingComponent.directlyPushAlong
			(
				raycastDirection,
				Distinctivity.absolute,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion directly pushing (directing with repulsion)
}