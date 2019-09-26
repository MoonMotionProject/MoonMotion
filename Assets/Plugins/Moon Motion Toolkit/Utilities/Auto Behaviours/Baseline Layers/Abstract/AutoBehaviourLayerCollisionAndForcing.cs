using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Collision And Forcing:
// #auto #collision #raycasting #force
// • provides this behaviour with methods for handling collision and forcing
public abstract class	AutoBehaviourLayerCollisionAndForcing<AutoBehaviourT> :
					AutoBehaviourLayerComponentShortcutsMoonMotion<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region calculating targeted force

	public Vector3 targetedForceBy(dynamic forcingPosition_PositionProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return position.targetedForceBy
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

	public Vector3 attractionTo(dynamic forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return position.attractionTo
		(
			forcingPosition,
			magnitude,
			reach,
			reachMagnitudeZeroingCurve,
			zeroForceOutsideReach,
			clamp
		);
	}

	public Vector3 repulsionFrom(dynamic forcingPosition_PositionProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return position.repulsionFrom
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

	public AutoBehaviourT forceTarget(dynamic targetRigidbodies_RigidbodiesProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return selfAfter(()=> position.forceTarget(targetRigidbodies, tug, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp));
	}

	public AutoBehaviourT attract(dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return selfAfter(()=> position.attract(targetRigidbodies, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp));
	}

	public AutoBehaviourT repel(dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return selfAfter(()=> position.repel(targetRigidbodies, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp));
	}
	#endregion targetedly forcing


	#region radial collision

	public HashSet<Collider> collidersWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.collidersWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<GameObject> objectsWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.objectsWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<Rigidbody> rigidbodiesWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.rigidbodiesWithin(radius, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radial collision


	#region radially forcing

	public HashSet<GameObject> forceRadially(Tug tug, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.forceRadially(tug, magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<GameObject> suck(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.suck(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<GameObject> repulse(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.repulse(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radially forcing


	#region positional collision

	public HashSet<Collider> positionalColliders(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.positionalColliders(triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<GameObject> positionalObjects(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.positionalObjects(triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<Rigidbody> positionalRigidbodies(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1);
	#endregion positional collision


	#region raycasting for all results (not just the first hit)

	public HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allNonpositionallyRaycastedHitsAlong(direction, distinctivity, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allNonpositionallyRaycastedHitsAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<Collider> allRaycastedCollidersAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allRaycastedCollidersAlong(direction, distinctivity, raycastDistance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<Collider> allRaycastedCollidersAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allRaycastedCollidersAlongLocal(localDirection, raycastDistance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<GameObject> allRaycastedObjectsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allRaycastedObjectsAlong(direction, distinctivity, raycastDistance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<GameObject> allRaycastedObjectsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allRaycastedObjectsAlongLocal(localDirection, raycastDistance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<Rigidbody> allRaycastedRigidbodiesAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allRaycastedRigidbodiesAlong(direction, distinctivity, raycastDistance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allRaycastedRigidbodiesAlongLocal(localDirection, raycastDistance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for all results (not just the first hit)


	#region raycasting for just the first result

	public RaycastHit firstNonpositionallyRaycastedHitAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedHitAlong(direction, distinctivity, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public RaycastHit firstNonpositionallyRaycastedHitAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedHitAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public Collider firstNonpositionallyRaycastedColliderAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedColliderAlong(direction, distinctivity, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public Collider firstNonpositionallyRaycastedColliderAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedColliderAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public GameObject firstNonpositionallyRaycastedObjectAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedObjectAlong(direction, distinctivity, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public GameObject firstNonpositionallyRaycastedObjectAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedObjectAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedRigidbodyAlong(direction, distinctivity, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedRigidbodyAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for just the first result


	#region raycasting for however many results

	public HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.nonpositionallyRaycastedHitsAlong(direction, distinctivity, raycastDistance, firstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.nonpositionallyRaycastedHitsAlongLocal(localDirection, raycastDistance, firstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<Collider> raycastedCollidersAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.raycastedCollidersAlong(direction, distinctivity, raycastDistance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<Collider> raycastedCollidersAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.raycastedCollidersAlongLocal(localDirection, raycastDistance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<GameObject> raycastedObjectsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.raycastedObjectsAlong(direction, distinctivity, raycastDistance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<GameObject> raycastedObjectsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.raycastedObjectsAlongLocal(localDirection, raycastDistance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<Rigidbody> raycastedRigidbodiesAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.raycastedRigidbodiesAlong(direction, distinctivity, raycastDistance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.raycastedRigidbodiesAlongLocal(localDirection, raycastDistance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for however many results


	#region directing

	public HashSet<GameObject> direct
	(
		Tug tug,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	gameObject.direct
			(
				tug,
				raycastDirection,
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public HashSet<GameObject> direct
	(
		Tug tug,
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	gameObject.direct
			(
				tug,
				localRaycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public HashSet<GameObject> directGlobally
	(
		Tug tug,
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	gameObject.directGlobally
			(
				tug,
				raycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public HashSet<GameObject> directlyPullAlong
	(
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	gameObject.directlyPullAlong
			(
				raycastDirection,
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public HashSet<GameObject> directlyPullAlong
	(
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	gameObject.directlyPullAlong
			(
				localRaycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public HashSet<GameObject> directlyPullAlongGlobal
	(
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	gameObject.directlyPullAlongGlobal
			(
				raycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public HashSet<GameObject> directlyPushAlong
	(
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	gameObject.directlyPushAlong
			(
				raycastDirection,
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public HashSet<GameObject> directlyPushAlong
	(
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	gameObject.directlyPushAlong
			(
				localRaycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public HashSet<GameObject> directlyPushAlongGlobal
	(
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	gameObject.directlyPushAlongGlobal
			(
				raycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion directing
}