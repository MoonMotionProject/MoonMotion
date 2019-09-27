using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Positional Collision Extensions: provides extension methods for handling positional collisions
// #collision
public static class PositionalCollisionExtensions
{
	// methods: return the set of colliders\objects\rigidbodies (respectively) at this given position provider, using the given trigger collider query and layer mask //


	#region with colliders
	
	public static HashSet<Collider> positionalColliders(this Vector3 centerPosition, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerPosition.collidersWithin
			(
				0f,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	public static bool hasAnyPositionalColliders(this Vector3 centerPosition, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerPosition.positionalColliders(triggerColliderQuery, layerMask_MaxOf1).hasAny();

	public static HashSet<Collider> positionalColliders(this Component centerComponent, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.position().positionalColliders(triggerColliderQuery, layerMask_MaxOf1);
	public static bool hasAnyPositionalColliders(this Component centerComponent, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.positionalColliders(triggerColliderQuery, layerMask_MaxOf1).hasAny();

	public static HashSet<Collider> positionalColliders(this GameObject centerObject, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.position().positionalColliders(triggerColliderQuery, layerMask_MaxOf1);
	public static bool hasAnyPositionalColliders(this GameObject centerObject, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.positionalColliders(triggerColliderQuery, layerMask_MaxOf1).hasAny();
	#endregion with colliders


	#region with objects

	public static HashSet<GameObject> positionalObjects(this Vector3 centerPosition, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerPosition.positionalColliders
			(
				triggerColliderQuery,
				layerMask_MaxOf1
			).uniqueObjects();
	public static bool hasAnyPositionalObjects(this Vector3 centerPosition, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerPosition.positionalObjects(triggerColliderQuery, layerMask_MaxOf1).hasAny();

	public static HashSet<GameObject> positionalObjects(this Component centerComponent, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.position().positionalObjects(triggerColliderQuery, layerMask_MaxOf1);
	public static bool hasAnyPositionalObjects(this Component centerComponent, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.positionalObjects(triggerColliderQuery, layerMask_MaxOf1).hasAny();

	public static HashSet<GameObject> positionalObjects(this GameObject centerObject, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.position().positionalObjects(triggerColliderQuery, layerMask_MaxOf1);
	public static bool hasAnyPositionalObjects(this GameObject centerObject, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.positionalObjects(triggerColliderQuery, layerMask_MaxOf1).hasAny();
	#endregion with objects


	#region with rigidbodies

	public static HashSet<Rigidbody> positionalRigidbodies(this Vector3 centerPosition, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerPosition.positionalColliders
			(
				triggerColliderQuery,
				layerMask_MaxOf1
			).uniqueRigidbodies();
	public static bool hasAnyPositionalRigidbodies(this Vector3 centerPosition, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerPosition.positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1).hasAny();

	public static HashSet<Rigidbody> positionalRigidbodies(this Component centerComponent, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.position().positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1);
	public static bool hasAnyPositionalRigidbodies(this Component centerComponent, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1).hasAny();

	public static HashSet<Rigidbody> positionalRigidbodies(this GameObject centerObject, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.position().positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1);
	public static bool hasAnyPositionalRigidbodies(this GameObject centerObject, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1).hasAny();
	#endregion with rigidbodies
}