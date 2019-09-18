using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Positional Collision Extensions: provides extension methods for handling positional collisions //
public static class PositionalCollisionExtensions
{
	// methods: return the set of colliders\objects\rigidbodies (respectively) at this given position provider, using the given layer mask and trigger collider query //

	
	public static HashSet<Collider> positionalColliders(this Vector3 centerPosition, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerPosition.collidersWithin
			(
				0f,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static HashSet<Collider> positionalColliders(this Component centerComponent, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.position().positionalColliders(triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Collider> positionalColliders(this GameObject centerObject, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.position().positionalColliders(triggerColliderQuery, layerMask_MaxOf1);


	public static HashSet<GameObject> positionalObjects(this Vector3 centerPosition, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerPosition.positionalColliders
			(
				triggerColliderQuery,
				layerMask_MaxOf1
			).uniqueObjects();

	public static HashSet<GameObject> positionalObjects(this Component centerComponent, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.position().positionalObjects(triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<GameObject> positionalObjects(this GameObject centerObject, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.position().positionalObjects(triggerColliderQuery, layerMask_MaxOf1);


	public static HashSet<Rigidbody> positionalRigidbodies(this Vector3 centerPosition, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerPosition.positionalColliders
			(
				triggerColliderQuery,
				layerMask_MaxOf1
			).uniqueRigidbodies();

	public static HashSet<Rigidbody> positionalRigidbodies(this Component centerComponent, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.position().positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Rigidbody> positionalRigidbodies(this GameObject centerObject, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.position().positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1);
}