using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Raycasting Extensions: provides extension methods for handling raycasting //
public static class RaycastingExtensions
{
	#region raycasting for all results (not just the first hit)
	// methods: return the set of raycast hits \colliders\objects\rigidbodies (respectively) within the given distance of the given raycasting position provider along this given direction, using the given layer mask and trigger collider query, ensuring inclusion of positional colliders (where not returning raycast hits) according to the given boolean //

	
	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		RaycastHit[] raycastHits = Physics.RaycastAll
		(
			Provide.positionVia(raycastingPosition_PositionProvider),
			direction,
			raycastDistance,
			layerMask_MaxOf1.firstOtherwise(Default.layerMask),
			triggerColliderQuery
		);

		return raycastHits.toSet();
	}

	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.allNonpositionallyRaycastedHitsFrom(position, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(this Component component, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().allNonpositionallyRaycastedHitsAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.allNonpositionallyRaycastedHitsAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(this GameObject gameObject, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().allNonpositionallyRaycastedHitsAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.allNonpositionallyRaycastedHitsAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), raycastDistance, triggerColliderQuery, layerMask_MaxOf1);


	public static HashSet<Collider> allRaycastedCollidersFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		HashSet<Collider> collidersFound = new HashSet<Collider>();

		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		if (ensureInclusionOfPositionalColliders)
		{
			collidersFound = raycastingPosition.positionalColliders(triggerColliderQuery, layerMask_MaxOf1);
		}

		return direction.allNonpositionallyRaycastedHitsFrom(raycastingPosition, raycastDistance, triggerColliderQuery, layerMask_MaxOf1)
			.colliders()
			.addToGet(collidersFound);
	}

	public static HashSet<Collider> allRaycastedCollidersAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.allRaycastedCollidersFrom(position, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Collider> allRaycastedCollidersAlong(this Component component, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().allRaycastedCollidersAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<Collider> allRaycastedCollidersAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.allRaycastedCollidersAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Collider> allRaycastedCollidersAlong(this GameObject gameObject, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().allRaycastedCollidersAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<Collider> allRaycastedCollidersAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.allRaycastedCollidersAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);


	public static HashSet<GameObject> allRaycastedObjectsFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	Pass.positionVia(raycastingPosition_PositionProvider, new Func<Vector3, HashSet<GameObject>>
			(
				raycastingPosition =>
				direction.allRaycastedCollidersFrom
				(
					raycastingPosition,
					raycastDistance,
					ensureInclusionOfPositionalColliders,
					triggerColliderQuery,
					layerMask_MaxOf1
				).uniqueObjects()
			));

	public static HashSet<GameObject> allRaycastedObjectsAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.allRaycastedObjectsFrom(position, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<GameObject> allRaycastedObjectsAlong(this Component component, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().allRaycastedObjectsAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<GameObject> allRaycastedObjectsAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.allRaycastedObjectsAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<GameObject> allRaycastedObjectsAlong(this GameObject gameObject, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().allRaycastedObjectsAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<GameObject> allRaycastedObjectsAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.allRaycastedObjectsAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);


	public static HashSet<Rigidbody> allRaycastedRigidbodiesFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	Pass.positionVia(raycastingPosition_PositionProvider, new Func<Vector3, HashSet<Rigidbody>>
			(
				raycastingPosition =>
				direction.allRaycastedCollidersFrom
				(
					raycastingPosition,
					raycastDistance,
					ensureInclusionOfPositionalColliders,
					triggerColliderQuery,
					layerMask_MaxOf1
				).uniqueRigidbodies()
			));

	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.allRaycastedRigidbodiesFrom(position, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlong(this Component component, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().allRaycastedRigidbodiesAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.allRaycastedRigidbodiesAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlong(this GameObject gameObject, Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().allRaycastedRigidbodiesAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.allRaycastedRigidbodiesAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for all results (not just the first hit)




	#region raycasting for just the first result
	// methods: return the first raycast hit \collider\object\rigidbody (respectively) within the given distance of the given raycasting position provider along this given direction, using the given layer mask and trigger collider query //


	public static RaycastHit firstNonpositionallyRaycastedHitFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		RaycastHit raycastHit;
		Physics.Raycast
		(
			Provide.positionVia(raycastingPosition_PositionProvider),
			direction,
			out raycastHit,
			raycastDistance,
			layerMask_MaxOf1.firstOtherwise(Default.layerMask),
			triggerColliderQuery
		);
		return raycastHit;
	}

	public static RaycastHit firstNonpositionallyRaycastedHitAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.firstNonpositionallyRaycastedHitFrom(position, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static RaycastHit firstNonpositionallyRaycastedHitAlong(this Component component, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().firstNonpositionallyRaycastedHitAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static RaycastHit firstNonpositionallyRaycastedHitAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.firstNonpositionallyRaycastedHitAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static RaycastHit firstNonpositionallyRaycastedHitAlong(this GameObject gameObject, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().firstNonpositionallyRaycastedHitAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static RaycastHit firstNonpositionallyRaycastedHitAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.firstNonpositionallyRaycastedHitAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), raycastDistance, triggerColliderQuery, layerMask_MaxOf1);


	public static Collider firstNonpositionallyRaycastedColliderFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		RaycastHit raycastHit = direction.firstNonpositionallyRaycastedHitFrom(raycastingPosition, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

		return raycastHit.collider;
	}

	public static Collider firstNonpositionallyRaycastedColliderAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.firstNonpositionallyRaycastedColliderFrom(position, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static Collider firstNonpositionallyRaycastedColliderAlong(this Component component, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().firstNonpositionallyRaycastedColliderAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static Collider firstNonpositionallyRaycastedColliderAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.firstNonpositionallyRaycastedColliderAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static Collider firstNonpositionallyRaycastedColliderAlong(this GameObject gameObject, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().firstNonpositionallyRaycastedColliderAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static Collider firstNonpositionallyRaycastedColliderAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.firstNonpositionallyRaycastedColliderAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), raycastDistance, triggerColliderQuery, layerMask_MaxOf1);


	public static GameObject firstNonpositionallyRaycastedObjectFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		RaycastHit raycastHit = direction.firstNonpositionallyRaycastedHitFrom(raycastingPosition, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

		return raycastHit.gameObject();
	}

	public static GameObject firstNonpositionallyRaycastedObjectAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.firstNonpositionallyRaycastedObjectFrom(position, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static GameObject firstNonpositionallyRaycastedObjectAlong(this Component component, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().firstNonpositionallyRaycastedObjectAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static GameObject firstNonpositionallyRaycastedObjectAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.firstNonpositionallyRaycastedObjectAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static GameObject firstNonpositionallyRaycastedObjectAlong(this GameObject gameObject, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().firstNonpositionallyRaycastedObjectAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static GameObject firstNonpositionallyRaycastedObjectAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.firstNonpositionallyRaycastedObjectAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), raycastDistance, triggerColliderQuery, layerMask_MaxOf1);


	public static Rigidbody firstNonpositionallyRaycastedRigidbodyFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		RaycastHit raycastHit = direction.firstNonpositionallyRaycastedHitFrom(raycastingPosition, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

		return raycastHit.rigidbody;
	}

	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(this Vector3 position, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.firstNonpositionallyRaycastedRigidbodyFrom(position, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(this Component component, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().firstNonpositionallyRaycastedRigidbodyAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(this Component component, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.firstNonpositionallyRaycastedRigidbodyAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(this GameObject gameObject, Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().firstNonpositionallyRaycastedRigidbodyAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(this GameObject gameObject, Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.firstNonpositionallyRaycastedRigidbodyAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for just the first result




	#region raycasting for however many results
	// methods: return the set of raycast hits \colliders\objects\rigidbodies (respectively) within the given distance of the given raycasting position provider along this given direction, using the given layer mask and trigger collider query, only forcing the first object raycasted according to the given 'firstHitOnly' boolean, ensuring inclusion of positional colliders (where not returning raycast hits) if not (per 'firstHitOnly') only forcing the first object raycasted according to the given 'ensureInclusionOfPositionalCollidersIfNotFirstHitOnly' boolean //


	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
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

	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(this Vector3 position, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.nonpositionallyRaycastedHitsFrom(position, firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(this Component component, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().nonpositionallyRaycastedHitsAlong(direction, firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(this Component component, Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.nonpositionallyRaycastedHitsAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(this GameObject gameObject, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().nonpositionallyRaycastedHitsAlong(direction, firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(this GameObject gameObject, Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.nonpositionallyRaycastedHitsAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);


	public static HashSet<Collider> raycastedCollidersFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
	{
		Vector3 raycastingPosition = Provide.positionVia(raycastingPosition_PositionProvider);

		return
			firstHitOnly ?
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
					ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
					triggerColliderQuery,
					layerMask_MaxOf1
				);
	}

	public static HashSet<Collider> raycastedCollidersAlong(this Vector3 position, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.raycastedCollidersFrom(position, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Collider> raycastedCollidersAlong(this Component component, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().raycastedCollidersAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<Collider> raycastedCollidersAlongLocal(this Component component, Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.raycastedCollidersAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Collider> raycastedCollidersAlong(this GameObject gameObject, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().raycastedCollidersAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<Collider> raycastedCollidersAlongLocal(this GameObject gameObject, Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.raycastedCollidersAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);


	public static HashSet<GameObject> raycastedObjectsFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	Pass.positionVia(raycastingPosition_PositionProvider, new Func<Vector3, HashSet<GameObject>>
			(
				raycastingPosition =>
				direction.raycastedCollidersFrom
				(
					raycastingPosition,
					firstHitOnly,
					raycastDistance,
					ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
					triggerColliderQuery,
					layerMask_MaxOf1
				).uniqueObjects()
			));

	public static HashSet<GameObject> raycastedObjectsAlong(this Vector3 position, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.raycastedObjectsFrom(position, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<GameObject> raycastedObjectsAlong(this Component component, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().raycastedObjectsAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<GameObject> raycastedObjectsAlongLocal(this Component component, Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.raycastedObjectsAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<GameObject> raycastedObjectsAlong(this GameObject gameObject, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().raycastedObjectsAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<GameObject> raycastedObjectsAlongLocal(this GameObject gameObject, Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.raycastedObjectsAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);


	public static HashSet<Rigidbody> raycastedRigidbodiesFrom(this Vector3 direction, dynamic raycastingPosition_PositionProvider, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	Pass.positionVia(raycastingPosition_PositionProvider, new Func<Vector3, HashSet<Rigidbody>>
			(
				raycastingPosition =>
				direction.raycastedCollidersFrom
				(
					raycastingPosition,
					firstHitOnly,
					raycastDistance,
					ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
					triggerColliderQuery,
					layerMask_MaxOf1
				).uniqueRigidbodies()
			));

	public static HashSet<Rigidbody> raycastedRigidbodiesAlong(this Vector3 position, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> direction.raycastedRigidbodiesFrom(position, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Rigidbody> raycastedRigidbodiesAlong(this Component component, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.position().raycastedRigidbodiesAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(this Component component, Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> component.raycastedRigidbodiesAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component), firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Rigidbody> raycastedRigidbodiesAlong(this GameObject gameObject, Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.position().raycastedRigidbodiesAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(this GameObject gameObject, Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> gameObject.raycastedRigidbodiesAlong(localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject), firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for however many results
}