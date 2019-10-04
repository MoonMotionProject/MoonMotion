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

	public static new Vector3 targetedForceBy(dynamic forcingPosition_PositionProvider, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.targetedForceZeroingOutsideReach, bool clamp = Default.targetedForceClamping)
	{
		Vector3 forcingPosition = Provide.positionVia(forcingPosition_PositionProvider);

		return autoBehaviour.targetedForceBy
		(
			forcingPosition,
			affinity,
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

	public static new AutoBehaviour<SingletonBehaviourT> forceTarget(dynamic targetRigidbodies_RigidbodiesProvider, Affinity affinity, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directedForceZeroingOutsideReach, bool clamp = Default.directedForceClamping)
	{
		List<Rigidbody> targetRigidbodies = Provide.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider);

		return autoBehaviour.forceTarget(targetRigidbodies, affinity, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp);
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
	public static new bool hasAnyCollidersWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.hasAnyCollidersWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> objectsWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.objectsWithin(radius, triggerColliderQuery, layerMask_MaxOf1);
	public static new bool hasAnyObjectsWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.hasAnyObjectsWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> rigidbodiesWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.rigidbodiesWithin(radius, triggerColliderQuery, layerMask_MaxOf1);
	public static new bool hasAnyRigidbodiesWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.hasAnyRigidbodiesWithin(radius, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radial collision


	#region radially forcing

	public static new HashSet<GameObject> forceRadially(Affinity affinity, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.forceRadially(affinity, magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> suck(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.suck(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> repulse(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.repulse(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radially forcing


	#region positional collision

	public static new HashSet<Collider> positionalColliders(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.positionalColliders(triggerColliderQuery, layerMask_MaxOf1);
	public static new bool hasAnyPositionalColliders(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.hasAnyPositionalColliders(triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> positionalObjects(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.positionalObjects(triggerColliderQuery, layerMask_MaxOf1);
	public static new bool hasAnyPositionalObjects(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.hasAnyPositionalObjects(triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> positionalRigidbodies(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1);
	public static new bool hasAnyPositionalRigidbodies(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.hasAnyPositionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1);
	#endregion positional collision


	#region raycasting for all results (not just the first hit)

	public static new HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allNonpositionallyRaycastedHitsAlong(direction, distinctivity, distance, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allNonpositionallyRaycastedHitsAlongLocal(localDirection, distance, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<RaycastHit> allNonpositionallyRaycastedHitsTo(dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.allNonpositionallyRaycastedHitsTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static new HashSet<Collider> allRaycastedCollidersAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedCollidersAlong(direction, distinctivity, distance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> allRaycastedCollidersAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedCollidersAlongLocal(localDirection, distance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> allRaycastedCollidersTo(dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.allRaycastedCollidersTo
		(
			raycastEndPosition,
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static new HashSet<GameObject> allRaycastedObjectsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedObjectsAlong(direction, distinctivity, distance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> allRaycastedObjectsAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedObjectsAlongLocal(localDirection, distance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> allRaycastedObjectsTo(dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.allRaycastedObjectsTo
		(
			raycastEndPosition,
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static new HashSet<Rigidbody> allRaycastedRigidbodiesAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedRigidbodiesAlong(direction, distinctivity, distance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedRigidbodiesAlongLocal(localDirection, distance, queryPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> allRaycastedRigidbodiesTo(dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.allRaycastedRigidbodiesTo
		(
			raycastEndPosition,
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasting for all results (not just the first hit)


	#region raycasting for just the first result

	public static new RaycastHit firstNonpositionallyRaycastedHitAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedHitAlong(direction, distinctivity, distance, triggerColliderQuery, layerMask_MaxOf1);
	public static new RaycastHit firstNonpositionallyRaycastedHitAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedHitAlongLocal(localDirection, distance, triggerColliderQuery, layerMask_MaxOf1);
	public static new RaycastHit firstNonpositionallyRaycastedHitTo(dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.firstNonpositionallyRaycastedHitTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static new Collider firstNonpositionallyRaycastedColliderAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedColliderAlong(direction, distinctivity, distance, triggerColliderQuery, layerMask_MaxOf1);
	public static new Collider firstNonpositionallyRaycastedColliderAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedColliderAlongLocal(localDirection, distance, triggerColliderQuery, layerMask_MaxOf1);
	public static new Collider firstNonpositionallyRaycastedColliderTo(dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.firstNonpositionallyRaycastedColliderTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static new GameObject firstNonpositionallyRaycastedObjectAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedObjectAlong(direction, distinctivity, distance, triggerColliderQuery, layerMask_MaxOf1);
	public static new GameObject firstNonpositionallyRaycastedObjectWhere
	(
		Func<GameObject, bool> function,
		Vector3 direction,
		Distinctivity distinctivity = Default.raycastingDistinctivity,
		float distance = Default.raycastingDistance,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.firstNonpositionallyRaycastedObjectWhere
			(
				function,
				direction,
				distinctivity,
				distance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new GameObject firstNonpositionallyRaycastedObjectAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedObjectAlongLocal(localDirection, distance, triggerColliderQuery, layerMask_MaxOf1);
	public static new GameObject firstNonpositionallyRaycastedObjectLocallyWhere
	(
		Func<GameObject, bool> function,
		Vector3 localDirection,
		float distance = Default.raycastingDistance,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.firstNonpositionallyRaycastedObjectLocallyWhere
			(
				function,
				localDirection,
				distance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new GameObject firstNonpositionallyRaycastedObjectTo(dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.firstNonpositionallyRaycastedObjectTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static new Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedRigidbodyAlong(direction, distinctivity, distance, triggerColliderQuery, layerMask_MaxOf1);
	public static new Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedRigidbodyAlongLocal(localDirection, distance, triggerColliderQuery, layerMask_MaxOf1);
	public static new Rigidbody firstNonpositionallyRaycastedRigidbodyTo(dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.firstNonpositionallyRaycastedRigidbodyTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasting for just the first result


	#region raycasting for however many results

	public static new HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.nonpositionallyRaycastedHitsAlong(direction, distinctivity, distance, firstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.nonpositionallyRaycastedHitsAlongLocal(localDirection, distance, firstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<RaycastHit> nonpositionallyRaycastedHitsTo(dynamic raycastEndPosition_PositionProvider, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.nonpositionallyRaycastedHitsTo
		(
			raycastEndPosition,
			firstHitOnly,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static new HashSet<Collider> raycastedCollidersAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedCollidersAlong(direction, distinctivity, distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> raycastedCollidersAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedCollidersAlongLocal(localDirection, distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> forwardRaycastedCollidersTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.forwardRaycastedCollidersTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> backwardRaycastedCollidersTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.backwardRaycastedCollidersTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> rightwardRaycastedCollidersTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.rightwardRaycastedCollidersTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> leftwardRaycastedCollidersTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.leftwardRaycastedCollidersTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> upwardRaycastedCollidersTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.upwardRaycastedCollidersTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> downwardRaycastedCollidersTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.downwardRaycastedCollidersTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> raycastedCollidersTo(dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.raycastedCollidersTo
		(
			raycastEndPosition,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static new HashSet<GameObject> raycastedObjectsAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedObjectsAlong(direction, distinctivity, distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> raycastedObjectsAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedObjectsAlongLocal(localDirection, distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> forwardRaycastedObjectsTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.forwardRaycastedObjectsTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> backwardRaycastedObjectsTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.backwardRaycastedObjectsTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> rightwardRaycastedObjectsTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.rightwardRaycastedObjectsTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> leftwardRaycastedObjectsTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.leftwardRaycastedObjectsTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> upwardRaycastedObjectsTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.upwardRaycastedObjectsTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> downwardRaycastedObjectsTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.downwardRaycastedObjectsTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> raycastedObjectsTo(dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.raycastedObjectsTo
		(
			raycastEndPosition,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static new HashSet<Rigidbody> raycastedRigidbodiesAlong(Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedRigidbodiesAlong(direction, distinctivity, distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(Vector3 localDirection, float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedRigidbodiesAlongLocal(localDirection, distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> forwardRaycastedRigidbodiesTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.forwardRaycastedRigidbodiesTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> backwardRaycastedRigidbodiesTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.backwardRaycastedRigidbodiesTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> rightwardRaycastedRigidbodiesTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.rightwardRaycastedRigidbodiesTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> leftwardRaycastedRigidbodiesTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.leftwardRaycastedRigidbodiesTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> upwardRaycastedRigidbodiesTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.upwardRaycastedRigidbodiesTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> downwardRaycastedRigidbodiesTo(float distance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.downwardRaycastedRigidbodiesTo(distance, raycastQuery, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> raycastedRigidbodiesTo(dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return autoBehaviour.raycastedRigidbodiesTo
		(
			raycastEndPosition,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasting for however many results


	#region tugging

	public static new HashSet<GameObject> tug
	(
		Affinity affinity,
		Vector3 raycastDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.tug
			(
				affinity,
				raycastDirection,
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> tug
	(
		Affinity affinity,
		BasicDirection raycastBasicDirection,
		Distinctivity raycastDistinctivity = Default.raycastingDistinctivity,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.tug
			(
				affinity,
				raycastBasicDirection,
				raycastDistinctivity,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> tug
	(
		Affinity affinity,
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.tug
			(
				affinity,
				localRaycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> tugGlobally
	(
		Affinity affinity,
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.tugGlobally
			(
				affinity,
				raycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> tug
	(
		Affinity affinity,
		dynamic raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return	autoBehaviour.tug
				(
					affinity,
					raycastEndPosition,
					magnitude,
					raycastDistanceMagnitudeZeroingCurve,
					raycastQuery,
					triggerColliderQuery,
					layerMask_MaxOf1
				);
	}

	public static new HashSet<GameObject> pullAlong
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
		=>	autoBehaviour.pullAlong
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
	public static new HashSet<GameObject> pullAlong
	(
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.pullAlong
			(
				localRaycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> forwardlyPull
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.forwardlyPull
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> backwardlyPull
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.backwardlyPull
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> rightwardlyPull
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.rightwardlyPull
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> leftwardlyPull
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.leftwardlyPull
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> upwardlyPull
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.upwardlyPull
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> downwardlyPull
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.downwardlyPull
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> pullAlongGlobal
	(
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.pullAlongGlobal
			(
				raycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> pullWithin
	(
		dynamic raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return	autoBehaviour.pullWithin
				(
					raycastEndPosition,
					magnitude,
					raycastDistanceMagnitudeZeroingCurve,
					raycastQuery,
					triggerColliderQuery,
					layerMask_MaxOf1
				);
	}

	public static new HashSet<GameObject> pushAlong
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
		=>	autoBehaviour.pushAlong
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
	public static new HashSet<GameObject> pushAlong
	(
		Vector3 localRaycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.pushAlong
			(
				localRaycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> forwardlyPush
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.forwardlyPush
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> backwardlyPush
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.backwardlyPush
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> rightwardlyPush
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.rightwardlyPush
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> leftwardlyPush
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.leftwardlyPush
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> upwardlyPush
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.upwardlyPush
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> downwardlyPush
	(
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.downwardlyPush
			(
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> pushAlongGlobal
	(
		Vector3 raycastDirection,
		float magnitude = Default.forceMagnitude,
		float raycastDistance = Default.raycastingDistance,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
		=>	autoBehaviour.pushAlongGlobal
			(
				raycastDirection,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static new HashSet<GameObject> pushWithin
	(
		dynamic raycastEndPosition_PositionProvider,
		float magnitude = Default.forceMagnitude,
		InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve,
		RaycastQuery raycastQuery = Default.raycastQuery,
		QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery,
		params LayerMask[] layerMask_MaxOf1
	)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return	autoBehaviour.pushWithin
				(
					raycastEndPosition,
					magnitude,
					raycastDistanceMagnitudeZeroingCurve,
					raycastQuery,
					triggerColliderQuery,
					layerMask_MaxOf1
				);
	}
	#endregion tugging
}