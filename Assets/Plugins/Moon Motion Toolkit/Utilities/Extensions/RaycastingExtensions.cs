using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Raycasting Extensions: provides extension methods for handling raycasting
// #raycasting #collision
public static class RaycastingExtensions
{
	#region raycasting for all results (not just the first hit)
	// methods: return the set of raycast hits \colliders\objects\rigidbodies (respectively) within the given distance of the given raycasting position provider along this given direction with the given or appropriate distinctivity, querying positional colliders (where not a method returning raycast hits) according to the given boolean, and using the given trigger collider query and layer mask //

	
	#region raycast hits

	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		RaycastHit[] raycastHits = Physics.RaycastAll
		(
			raycastingPosition,
			direction,
			raycastDistance,
			layerMask_MaxOf1.firstOtherwise(Default.layerMask),
			triggerColliderQuery
		);

		return raycastHits.toSet();
	}

	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(this Vector3 raycastingPosition, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.allNonpositionallyRaycastedHitsFrom
			(
				raycastingPosition,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(this Vector3 raycastingPosition, BasicDirection basicDirection = Default.raycastingBasicDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingPosition.allNonpositionallyRaycastedHitsAlong
			(
				basicDirection.asGlobalDirection(),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.allNonpositionallyRaycastedHitsAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().allNonpositionallyRaycastedHitsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.allNonpositionallyRaycastedHitsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().allNonpositionallyRaycastedHitsTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().allNonpositionallyRaycastedHitsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.allNonpositionallyRaycastedHitsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery, 
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().allNonpositionallyRaycastedHitsTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycast hits


	#region raycasted colliders

	public static HashSet<Collider> allRaycastedCollidersFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		HashSet<Collider> collidersFound = new HashSet<Collider>();

		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		if (queryPositionalColliders)
		{
			collidersFound = raycastingPosition.positionalColliders(triggerColliderQuery, layerMask_MaxOf1);
		}

		return direction.allNonpositionallyRaycastedHitsFrom(raycastingPosition, raycastDistance, triggerColliderQuery, layerMask_MaxOf1)
			.colliders()
			.addToGet(collidersFound);
	}

	public static HashSet<Collider> allRaycastedCollidersAlong(this Vector3 raycastingPosition, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.allRaycastedCollidersFrom
			(
				raycastingPosition,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> allRaycastedCollidersTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.allRaycastedCollidersAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<Collider> allRaycastedCollidersAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().allRaycastedCollidersAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> allRaycastedCollidersAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.allRaycastedCollidersAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> allRaycastedCollidersTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().allRaycastedCollidersTo
		(
			raycastEndPosition,
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<Collider> allRaycastedCollidersAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().allRaycastedCollidersAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> allRaycastedCollidersAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.allRaycastedCollidersAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> allRaycastedCollidersTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().allRaycastedCollidersTo
		(
			raycastEndPosition,
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasted colliders


	#region raycasted objects

	public static HashSet<GameObject> allRaycastedObjectsFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		return	direction.allRaycastedCollidersFrom
				(
					raycastingPosition,
					raycastDistance,
					queryPositionalColliders,
					triggerColliderQuery,
					layerMask_MaxOf1
				).uniqueObjects();
	}

	public static HashSet<GameObject> allRaycastedObjectsAlong(this Vector3 raycastingPosition, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.allRaycastedObjectsFrom
			(
				raycastingPosition,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> allRaycastedObjectsTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.allRaycastedObjectsAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<GameObject> allRaycastedObjectsAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().allRaycastedObjectsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> allRaycastedObjectsAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.allRaycastedObjectsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> allRaycastedObjectsTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().allRaycastedObjectsTo
		(
			raycastEndPosition,
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<GameObject> allRaycastedObjectsAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().allRaycastedObjectsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> allRaycastedObjectsAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.allRaycastedObjectsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> allRaycastedObjectsTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().allRaycastedObjectsTo
		(
			raycastEndPosition,
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasted objects


	#region raycasted rigidbodies

	public static HashSet<Rigidbody> allRaycastedRigidbodiesFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		return	direction.allRaycastedCollidersFrom
				(
					raycastingPosition,
					raycastDistance,
					queryPositionalColliders,
					triggerColliderQuery,
					layerMask_MaxOf1
				).uniqueRigidbodies();
	}

	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlong(this Vector3 raycastingPosition, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.allRaycastedRigidbodiesFrom
			(
				raycastingPosition,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> allRaycastedRigidbodiesTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.allRaycastedRigidbodiesAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().allRaycastedRigidbodiesAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.allRaycastedRigidbodiesAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> allRaycastedRigidbodiesTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().allRaycastedRigidbodiesTo
		(
			raycastEndPosition,
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().allRaycastedRigidbodiesAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.allRaycastedRigidbodiesAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> allRaycastedRigidbodiesTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().allRaycastedRigidbodiesTo
		(
			raycastEndPosition,
			queryPositionalColliders,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasted rigidbodies
	#endregion raycasting for all results (not just the first hit)




	#region raycasting for just the first result
	// methods: return the first raycast hit \collider\object\rigidbody (respectively) within the given distance of the given raycasting position provider along this given direction, using the given trigger collider query and layer mask //


	#region raycast hits

	public static RaycastHit firstNonpositionallyRaycastedHitFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);
		
		RaycastHit raycastHit;
		Physics.Raycast
		(
			raycastingPosition,
			direction,
			out raycastHit,
			raycastDistance,
			layerMask_MaxOf1.firstOtherwise(Default.layerMask),
			triggerColliderQuery
		);

		return raycastHit;
	}

	public static RaycastHit firstNonpositionallyRaycastedHitAlong(this Vector3 raycastingPosition, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.firstNonpositionallyRaycastedHitFrom
			(
				raycastingPosition,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static RaycastHit firstNonpositionallyRaycastedHitTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.firstNonpositionallyRaycastedHitAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static RaycastHit firstNonpositionallyRaycastedHitAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().firstNonpositionallyRaycastedHitAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static RaycastHit firstNonpositionallyRaycastedHitAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.firstNonpositionallyRaycastedHitAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static RaycastHit firstNonpositionallyRaycastedHitTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().firstNonpositionallyRaycastedHitTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static RaycastHit firstNonpositionallyRaycastedHitAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().firstNonpositionallyRaycastedHitAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static RaycastHit firstNonpositionallyRaycastedHitAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.firstNonpositionallyRaycastedHitAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static RaycastHit firstNonpositionallyRaycastedHitTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().firstNonpositionallyRaycastedHitTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycast hits


	#region raycasted colliders

	public static Collider firstNonpositionallyRaycastedColliderFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		RaycastHit raycastHit = direction.firstNonpositionallyRaycastedHitFrom(raycastingPosition, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

		return raycastHit.collider;
	}

	public static Collider firstNonpositionallyRaycastedColliderAlong(this Vector3 raycastingPosition, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.firstNonpositionallyRaycastedColliderFrom
			(
				raycastingPosition,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Collider firstNonpositionallyRaycastedColliderTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.firstNonpositionallyRaycastedColliderAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static Collider firstNonpositionallyRaycastedColliderAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().firstNonpositionallyRaycastedColliderAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Collider firstNonpositionallyRaycastedColliderAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.firstNonpositionallyRaycastedColliderAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Collider firstNonpositionallyRaycastedColliderTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().firstNonpositionallyRaycastedColliderTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static Collider firstNonpositionallyRaycastedColliderAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().firstNonpositionallyRaycastedColliderAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Collider firstNonpositionallyRaycastedColliderAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.firstNonpositionallyRaycastedColliderAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Collider firstNonpositionallyRaycastedColliderTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().firstNonpositionallyRaycastedColliderTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasted colliders


	#region raycasted objects

	public static GameObject firstNonpositionallyRaycastedObjectFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		RaycastHit raycastHit = direction.firstNonpositionallyRaycastedHitFrom(raycastingPosition, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

		return raycastHit.gameObject();
	}

	public static GameObject firstNonpositionallyRaycastedObjectAlong(this Vector3 raycastingPosition, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.firstNonpositionallyRaycastedObjectFrom
			(
				raycastingPosition,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static GameObject firstNonpositionallyRaycastedObjectTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.firstNonpositionallyRaycastedObjectAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static GameObject firstNonpositionallyRaycastedObjectAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().firstNonpositionallyRaycastedObjectAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static GameObject firstNonpositionallyRaycastedObjectAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.firstNonpositionallyRaycastedObjectAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static GameObject firstNonpositionallyRaycastedObjectTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().firstNonpositionallyRaycastedObjectTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static GameObject firstNonpositionallyRaycastedObjectAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().firstNonpositionallyRaycastedObjectAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static GameObject firstNonpositionallyRaycastedObjectAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.firstNonpositionallyRaycastedObjectAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static GameObject firstNonpositionallyRaycastedObjectTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().firstNonpositionallyRaycastedObjectTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasted objects


	#region raycasted rigidbodies

	public static Rigidbody firstNonpositionallyRaycastedRigidbodyFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		RaycastHit raycastHit = direction.firstNonpositionallyRaycastedHitFrom(raycastingPosition, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

		return raycastHit.rigidbody;
	}

	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(this Vector3 raycastingPosition, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.firstNonpositionallyRaycastedRigidbodyFrom
			(
				raycastingPosition,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Rigidbody firstNonpositionallyRaycastedRigidbodyTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.firstNonpositionallyRaycastedRigidbodyAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().firstNonpositionallyRaycastedRigidbodyAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.firstNonpositionallyRaycastedRigidbodyAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Rigidbody firstNonpositionallyRaycastedRigidbodyTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().firstNonpositionallyRaycastedRigidbodyTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().firstNonpositionallyRaycastedRigidbodyAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.firstNonpositionallyRaycastedRigidbodyAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Rigidbody firstNonpositionallyRaycastedRigidbodyTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().firstNonpositionallyRaycastedRigidbodyTo
		(
			raycastEndPosition,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasted rigidbodies
	#endregion raycasting for just the first result




	#region raycasting for however many results
	// methods: return the set of raycast hits \colliders\objects\rigidbodies (respectively) within the given distance of the given raycasting position provider along this given direction, using the given raycast query, trigger collider query, and layer mask //


	#region raycast hits

	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		return
			firstHitOnly ?
				raycastingPosition.firstNonpositionallyRaycastedHitAlong
				(
					direction,
					raycastDistance,
					triggerColliderQuery,
					layerMask_MaxOf1
				).startSet() :
				raycastingPosition.allNonpositionallyRaycastedHitsAlong
				(
					direction,
					raycastDistance,
					triggerColliderQuery,
					layerMask_MaxOf1
				);
	}

	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(this Vector3 raycastingPosition, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.nonpositionallyRaycastedHitsFrom
			(
				raycastingPosition,
				raycastDistance,
				firstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.nonpositionallyRaycastedHitsAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			firstHitOnly,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().nonpositionallyRaycastedHitsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				firstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.nonpositionallyRaycastedHitsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				firstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().nonpositionallyRaycastedHitsTo
		(
			raycastEndPosition,
			firstHitOnly,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().nonpositionallyRaycastedHitsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				firstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.nonpositionallyRaycastedHitsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				firstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().nonpositionallyRaycastedHitsTo
		(
			raycastEndPosition,
			firstHitOnly,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycast hits


	#region raycasted colliders

	public static HashSet<Collider> raycastedCollidersFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		return
			raycastQuery.queriesOnlyFirstHit() ?
				raycastingPosition.firstNonpositionallyRaycastedColliderAlong
				(
					direction,
					raycastDistance,
					triggerColliderQuery,
					layerMask_MaxOf1
				).startSet() :
				raycastingPosition.allRaycastedCollidersAlong
				(
					direction,
					raycastDistance,
					raycastQuery.queriesPositionalColliders(),
					triggerColliderQuery,
					layerMask_MaxOf1
				);
	}

	public static HashSet<Collider> raycastedCollidersAlong(this Vector3 raycastingPosition, Vector3 direction, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.raycastedCollidersFrom
			(
				raycastingPosition,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> raycastedCollidersTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.raycastedCollidersAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<Collider> raycastedCollidersAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().raycastedCollidersAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> raycastedCollidersAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedCollidersAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> forwardRaycastedCollidersTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedCollidersAlongLocal
			(
				Direction.forward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> backwardRaycastedCollidersTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedCollidersAlongLocal
			(
				Direction.backward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> rightwardRaycastedCollidersTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedCollidersAlongLocal
			(
				Direction.right,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> leftwardRaycastedCollidersTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedCollidersAlongLocal
			(
				Direction.left,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> upwardRaycastedCollidersTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedCollidersAlongLocal
			(
				Direction.up,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> downwardRaycastedCollidersTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedCollidersAlongLocal
			(
				Direction.down,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> raycastedCollidersTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().raycastedCollidersTo
		(
			raycastEndPosition,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<Collider> raycastedCollidersAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().raycastedCollidersAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> raycastedCollidersAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedCollidersAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> forwardRaycastedCollidersTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedCollidersAlongLocal
			(
				Direction.forward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> backwardRaycastedCollidersTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedCollidersAlongLocal
			(
				Direction.backward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> rightwardRaycastedCollidersTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedCollidersAlongLocal
			(
				Direction.right,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> leftwardRaycastedCollidersTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedCollidersAlongLocal
			(
				Direction.left,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> upwardRaycastedCollidersTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedCollidersAlongLocal
			(
				Direction.up,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> downwardRaycastedCollidersTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedCollidersAlongLocal
			(
				Direction.down,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> raycastedCollidersTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().raycastedCollidersTo
		(
			raycastEndPosition,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasted colliders


	#region raycasted objects

	public static HashSet<GameObject> raycastedObjectsFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		return	direction.raycastedCollidersFrom
				(
					raycastingPosition,
					raycastDistance,
					raycastQuery,
					triggerColliderQuery,
					layerMask_MaxOf1
				).uniqueObjects();
	}

	public static HashSet<GameObject> raycastedObjectsAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.raycastedObjectsFrom
			(
				position,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> raycastedObjectsTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.raycastedObjectsAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<GameObject> raycastedObjectsAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().raycastedObjectsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> raycastedObjectsAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedObjectsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> forwardRaycastedObjectsTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedObjectsAlongLocal
			(
				Direction.forward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> backwardRaycastedObjectsTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedObjectsAlongLocal
			(
				Direction.backward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> rightwardRaycastedObjectsTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedObjectsAlongLocal
			(
				Direction.right,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> leftwardRaycastedObjectsTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedObjectsAlongLocal
			(
				Direction.left,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> upwardRaycastedObjectsTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedObjectsAlongLocal
			(
				Direction.up,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> downwardRaycastedObjectsTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedObjectsAlongLocal
			(
				Direction.down,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> raycastedObjectsTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().raycastedObjectsTo
		(
			raycastEndPosition,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<GameObject> raycastedObjectsAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().raycastedObjectsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> raycastedObjectsAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedObjectsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> forwardRaycastedObjectsTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedObjectsAlongLocal
			(
				Direction.forward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> backwardRaycastedObjectsTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedObjectsAlongLocal
			(
				Direction.backward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> rightwardRaycastedObjectsTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedObjectsAlongLocal
			(
				Direction.right,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> leftwardRaycastedObjectsTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedObjectsAlongLocal
			(
				Direction.left,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> upwardRaycastedObjectsTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedObjectsAlongLocal
			(
				Direction.up,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> downwardRaycastedObjectsTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedObjectsAlongLocal
			(
				Direction.down,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> raycastedObjectsTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().raycastedObjectsTo
		(
			raycastEndPosition,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasted objects


	#region raycasted rigidbodies

	public static HashSet<Rigidbody> raycastedRigidbodiesFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		return	direction.raycastedCollidersFrom
				(
					raycastingPosition,
					raycastDistance,
					raycastQuery,
					triggerColliderQuery,
					layerMask_MaxOf1
				).uniqueRigidbodies();
	}

	public static HashSet<Rigidbody> raycastedRigidbodiesAlong(this Vector3 raycastingPosition, Vector3 direction, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.raycastedRigidbodiesFrom
			(
				raycastingPosition,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> raycastedRigidbodiesTo(this Vector3 raycastingPosition, dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingPosition.raycastedRigidbodiesAlong
		(
			raycastingPosition.directionTo(raycastEndPosition),
			raycastingPosition.distanceWith(raycastEndPosition),
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<Rigidbody> raycastedRigidbodiesAlong(this Component raycastingComponent, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.position().raycastedRigidbodiesAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingComponent),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(this Component raycastingComponent, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedRigidbodiesAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> forwardRaycastedRigidbodiesTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedRigidbodiesAlongLocal
			(
				Direction.forward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> backwardRaycastedRigidbodiesTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedRigidbodiesAlongLocal
			(
				Direction.backward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> rightwardRaycastedRigidbodiesTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedRigidbodiesAlongLocal
			(
				Direction.right,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> leftwardRaycastedRigidbodiesTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedRigidbodiesAlongLocal
			(
				Direction.left,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> upwardRaycastedRigidbodiesTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedRigidbodiesAlongLocal
			(
				Direction.up,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> downwardRaycastedRigidbodiesTo(this Component raycastingComponent, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingComponent.raycastedRigidbodiesAlongLocal
			(
				Direction.down,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> raycastedRigidbodiesTo(this Component raycastingComponent, dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingComponent.position().raycastedRigidbodiesTo
		(
			raycastEndPosition,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}

	public static HashSet<Rigidbody> raycastedRigidbodiesAlong(this GameObject raycastingObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.position().raycastedRigidbodiesAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, raycastingObject),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(this GameObject raycastingObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedRigidbodiesAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> forwardRaycastedRigidbodiesTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedRigidbodiesAlongLocal
			(
				Direction.forward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> backwardRaycastedRigidbodiesTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedRigidbodiesAlongLocal
			(
				Direction.backward,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> rightwardRaycastedRigidbodiesTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedRigidbodiesAlongLocal
			(
				Direction.right,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> leftwardRaycastedRigidbodiesTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedRigidbodiesAlongLocal
			(
				Direction.left,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> upwardRaycastedRigidbodiesTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedRigidbodiesAlongLocal
			(
				Direction.up,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> downwardRaycastedRigidbodiesTo(this GameObject raycastingObject, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	raycastingObject.raycastedRigidbodiesAlongLocal
			(
				Direction.down,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> raycastedRigidbodiesTo(this GameObject raycastingObject, dynamic raycastEndPosition_PositionProvider, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastEndPosition = Provide.positionVia(raycastEndPosition_PositionProvider);

		return raycastingObject.position().raycastedRigidbodiesTo
		(
			raycastEndPosition,
			raycastQuery,
			triggerColliderQuery,
			layerMask_MaxOf1
		);
	}
	#endregion raycasted rigidbodies
	#endregion raycasting for however many results
}