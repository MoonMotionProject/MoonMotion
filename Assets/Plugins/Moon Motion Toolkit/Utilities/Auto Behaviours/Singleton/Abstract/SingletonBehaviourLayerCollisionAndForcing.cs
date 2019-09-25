using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Collision And Forcing:
// #auto #collision #raycasting #force
// • provides this singleton behaviour with static access to its auto behaviour's collision and forcing layer
public abstract class	SingletonBehaviourLayerCollisionAndForcing<SingletonBehaviourT> :
					SingletonBehaviourLayerComponentShortcutsMoonMotion<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region calculating targeted force

	public static new Vector3 targetedForceBy(dynamic forcingPosition_PositionProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return autoBehaviour.targetedForceBy
		(
			forcingPosition,
			tug,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	}

	public static new Vector3 attractionTo(dynamic forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return autoBehaviour.attractionTo
		(
			forcingPosition,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	}

	public static new Vector3 repulsionFrom(dynamic forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return autoBehaviour.repulsionFrom
		(
			forcingPosition,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	}
	#endregion calculating targeted force


	#region targetedly forcing

	public static new AutoBehaviour<SingletonBehaviourT> forceTarget(dynamic targetRigidbodies_RigidbodiesProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return autoBehaviour.forceTarget(targetRigidbodies, tug, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp);
	}

	public static new AutoBehaviour<SingletonBehaviourT> attract(dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return autoBehaviour.attract(targetRigidbodies, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp);
	}

	public static new AutoBehaviour<SingletonBehaviourT> repel(dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return autoBehaviour.repel(targetRigidbodies, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp);
	}
	#endregion targetedly forcing


	#region radial collision

	public static new HashSet<Collider> collidersWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.collidersWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> objectsWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.objectsWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> rigidbodiesWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.rigidbodiesWithin(radius, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radial collision


	#region radially forcing

	public static new HashSet<GameObject> forceRadially(Tug tug, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.forceRadially(tug, magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> suck(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.suck(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> repulse(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.repulse(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radially forcing


	#region positional collision

	public static new HashSet<Collider> positionalColliders(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.positionalColliders(triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> positionalObjects(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.positionalObjects(triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> positionalRigidbodies(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1);
	#endregion positional collision


	#region raycasting for all results (not just the first hit)

	public static new HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allNonpositionallyRaycastedHitsAlong(direction, distinctivity, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allNonpositionallyRaycastedHitsAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Collider> allRaycastedCollidersAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedCollidersAlong(direction, distinctivity, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> allRaycastedCollidersAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedCollidersAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> allRaycastedObjectsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedObjectsAlong(direction, distinctivity, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> allRaycastedObjectsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedObjectsAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> allRaycastedRigidbodiesAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedRigidbodiesAlong(direction, distinctivity, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedRigidbodiesAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for all results (not just the first hit)


	#region raycasting for just the first result

	public static new RaycastHit firstNonpositionallyRaycastedHitAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedHitAlong(direction, distinctivity, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new RaycastHit firstNonpositionallyRaycastedHitAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedHitAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new Collider firstNonpositionallyRaycastedColliderAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedColliderAlong(direction, distinctivity, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new Collider firstNonpositionallyRaycastedColliderAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedColliderAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new GameObject firstNonpositionallyRaycastedObjectAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedObjectAlong(direction, distinctivity, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new GameObject firstNonpositionallyRaycastedObjectAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedObjectAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedRigidbodyAlong(direction, distinctivity, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedRigidbodyAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for just the first result


	#region raycasting for however many results

	public static new HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.nonpositionallyRaycastedHitsAlong(direction, distinctivity, firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.nonpositionallyRaycastedHitsAlongLocal(localDirection, firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Collider> raycastedCollidersAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedCollidersAlong(direction, distinctivity, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> raycastedCollidersAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedCollidersAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> raycastedObjectsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedObjectsAlong(direction, distinctivity, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> raycastedObjectsAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedObjectsAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> raycastedRigidbodiesAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedRigidbodiesAlong(direction, distinctivity, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedRigidbodiesAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for however many results


	#region directing

	public static new HashSet<GameObject> direct
	(
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
		=>	autoBehaviour.direct
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
	public static new HashSet<GameObject> direct
	(
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
		=>	autoBehaviour.direct
			(
				tug,
				localRaycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> directGlobally
	(
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
		=>	autoBehaviour.directGlobally
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

	public static new HashSet<GameObject> directlyPullAlong
	(
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
		=>	autoBehaviour.directlyPullAlong
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
	public static new HashSet<GameObject> directlyPullAlong
	(
		Vector3 localRaycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.directlyPullAlong
			(
				localRaycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> directlyPullAlongGlobal
	(
		Vector3 raycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.directlyPullAlongGlobal
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

	public static new HashSet<GameObject> directlyPushAlong
	(
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
		=>	autoBehaviour.directlyPushAlong
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
	public static new HashSet<GameObject> directlyPushAlong
	(
		Vector3 localRaycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.directlyPushAlong
			(
				localRaycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> directlyPushAlongGlobal
	(
		Vector3 raycastDirection,
		bool firstHitOnly = Default.raycastingForcingFirstHitOnly,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.directlyPushAlongGlobal
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
	#endregion directing
}