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

	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.allNonpositionallyRaycastedHitsFrom
			(
				position,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().allNonpositionallyRaycastedHitsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.allNonpositionallyRaycastedHitsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().allNonpositionallyRaycastedHitsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.allNonpositionallyRaycastedHitsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery, 
				layerMask_MaxOf1
			);


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

	public static HashSet<Collider> allRaycastedCollidersAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.allRaycastedCollidersFrom
			(
				position,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<Collider> allRaycastedCollidersAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().allRaycastedCollidersAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> allRaycastedCollidersAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.allRaycastedCollidersAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<Collider> allRaycastedCollidersAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().allRaycastedCollidersAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> allRaycastedCollidersAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.allRaycastedCollidersAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);


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

	public static HashSet<GameObject> allRaycastedObjectsAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.allRaycastedObjectsFrom
			(
				position,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> allRaycastedObjectsAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().allRaycastedObjectsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> allRaycastedObjectsAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.allRaycastedObjectsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> allRaycastedObjectsAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().allRaycastedObjectsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> allRaycastedObjectsAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.allRaycastedObjectsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);


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

	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.allRaycastedRigidbodiesFrom
			(
				position,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().allRaycastedRigidbodiesAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.allRaycastedRigidbodiesAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().allRaycastedRigidbodiesAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool queryPositionalColliders = Default.raycastingPositionalCollidersQuerying, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.allRaycastedRigidbodiesAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				queryPositionalColliders,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion raycasting for all results (not just the first hit)




	#region raycasting for just the first result
	// methods: return the first raycast hit \collider\object\rigidbody (respectively) within the given distance of the given raycasting position provider along this given direction, using the given trigger collider query and layer mask //


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

	public static RaycastHit firstNonpositionallyRaycastedHitAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.firstNonpositionallyRaycastedHitFrom
			(
				position,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static RaycastHit firstNonpositionallyRaycastedHitAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().firstNonpositionallyRaycastedHitAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static RaycastHit firstNonpositionallyRaycastedHitAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.firstNonpositionallyRaycastedHitAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static RaycastHit firstNonpositionallyRaycastedHitAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().firstNonpositionallyRaycastedHitAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static RaycastHit firstNonpositionallyRaycastedHitAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.firstNonpositionallyRaycastedHitAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);


	public static Collider firstNonpositionallyRaycastedColliderFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		RaycastHit raycastHit = direction.firstNonpositionallyRaycastedHitFrom(raycastingPosition, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

		return raycastHit.collider;
	}

	public static Collider firstNonpositionallyRaycastedColliderAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.firstNonpositionallyRaycastedColliderFrom
			(
				position,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static Collider firstNonpositionallyRaycastedColliderAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().firstNonpositionallyRaycastedColliderAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Collider firstNonpositionallyRaycastedColliderAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.firstNonpositionallyRaycastedColliderAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static Collider firstNonpositionallyRaycastedColliderAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().firstNonpositionallyRaycastedColliderAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Collider firstNonpositionallyRaycastedColliderAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.firstNonpositionallyRaycastedColliderAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);


	public static GameObject firstNonpositionallyRaycastedObjectFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		RaycastHit raycastHit = direction.firstNonpositionallyRaycastedHitFrom(raycastingPosition, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

		return raycastHit.gameObject();
	}

	public static GameObject firstNonpositionallyRaycastedObjectAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.firstNonpositionallyRaycastedObjectFrom
			(
				position,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static GameObject firstNonpositionallyRaycastedObjectAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().firstNonpositionallyRaycastedObjectAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static GameObject firstNonpositionallyRaycastedObjectAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.firstNonpositionallyRaycastedObjectAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static GameObject firstNonpositionallyRaycastedObjectAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().firstNonpositionallyRaycastedObjectAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static GameObject firstNonpositionallyRaycastedObjectAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.firstNonpositionallyRaycastedObjectAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);


	public static Rigidbody firstNonpositionallyRaycastedRigidbodyFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		RaycastHit raycastHit = direction.firstNonpositionallyRaycastedHitFrom(raycastingPosition, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

		return raycastHit.rigidbody;
	}

	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.firstNonpositionallyRaycastedRigidbodyFrom
			(
				position,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().firstNonpositionallyRaycastedRigidbodyAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.firstNonpositionallyRaycastedRigidbodyAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().firstNonpositionallyRaycastedRigidbodyAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.firstNonpositionallyRaycastedRigidbodyAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion raycasting for just the first result




	#region raycasting for however many results
	// methods: return the set of raycast hits \colliders\objects\rigidbodies (respectively) within the given distance of the given raycasting position provider along this given direction, using the given raycast query, trigger collider query, and layer mask //


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

	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.nonpositionallyRaycastedHitsFrom
			(
				position,
				raycastDistance,
				firstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().nonpositionallyRaycastedHitsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				firstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.nonpositionallyRaycastedHitsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				firstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().nonpositionallyRaycastedHitsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				firstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool firstHitOnly = Default.raycastQueryingForFirstHitOnly, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.nonpositionallyRaycastedHitsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				firstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);


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

	public static HashSet<Collider> raycastedCollidersAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.raycastedCollidersFrom
			(
				position,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<Collider> raycastedCollidersAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().raycastedCollidersAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> raycastedCollidersAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.raycastedCollidersAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<Collider> raycastedCollidersAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().raycastedCollidersAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Collider> raycastedCollidersAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.raycastedCollidersAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);


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

	public static HashSet<GameObject> raycastedObjectsAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().raycastedObjectsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> raycastedObjectsAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.raycastedObjectsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<GameObject> raycastedObjectsAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().raycastedObjectsAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<GameObject> raycastedObjectsAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.raycastedObjectsAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);


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

	public static HashSet<Rigidbody> raycastedRigidbodiesAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	direction.raycastedRigidbodiesFrom
			(
				position,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<Rigidbody> raycastedRigidbodiesAlong(this Component component, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.position().raycastedRigidbodiesAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, component),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	component.raycastedRigidbodiesAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<Rigidbody> raycastedRigidbodiesAlong(this GameObject gameObject, Vector3 direction, Distinctivity distinctivity = Default.raycastingDistinctivity, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.position().raycastedRigidbodiesAlong
			(
				direction.toGlobalDirectionFromDistinctivityOf(distinctivity, gameObject),
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, RaycastQuery raycastQuery = Default.raycastQuery, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	gameObject.raycastedRigidbodiesAlong
			(
				localDirection,
				Distinctivity.relative,
				raycastDistance,
				raycastQuery,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion raycasting for however many results
}