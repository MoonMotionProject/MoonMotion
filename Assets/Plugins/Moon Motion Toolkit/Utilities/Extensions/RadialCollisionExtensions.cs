using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Radial Collision Extensions: provides extension methods for handling radial collisions
// #collision
public static class RadialCollisionExtensions
{
	// methods: return the set of colliders\objects\rigidbodies (respectively) within the given radius of this given center position provider, using the given layer mask and trigger collider query //

	
	public static HashSet<Collider> collidersWithin(this Vector3 centerPosition, float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	Physics.OverlapSphere
			(
				centerPosition,
				radius,
				layerMask_MaxOf1.firstOtherwise(Default.layerMask),
				triggerColliderQuery
			).toSet();

	public static HashSet<Collider> collidersWithin(this Component centerComponent, float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.position().collidersWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Collider> collidersWithin(this GameObject centerObject, float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.position().collidersWithin(radius, triggerColliderQuery, layerMask_MaxOf1);


	public static HashSet<GameObject> objectsWithin(this Vector3 centerPosition, float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerPosition.collidersWithin
			(
				radius,
				triggerColliderQuery,
				layerMask_MaxOf1
			).uniqueObjects();

	public static HashSet<GameObject> objectsWithin(this Component centerComponent, float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.position().objectsWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<GameObject> objectsWithin(this GameObject centerObject, float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.position().objectsWithin(radius, triggerColliderQuery, layerMask_MaxOf1);


	public static HashSet<Rigidbody> rigidbodiesWithin(this Vector3 centerPosition, float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	centerPosition.collidersWithin
			(
				radius,
				triggerColliderQuery,
				layerMask_MaxOf1
			).uniqueRigidbodies();

	public static HashSet<Rigidbody> rigidbodiesWithin(this Component centerComponent, float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerComponent.position().rigidbodiesWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public static HashSet<Rigidbody> rigidbodiesWithin(this GameObject centerObject, float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> centerObject.position().rigidbodiesWithin(radius, triggerColliderQuery, layerMask_MaxOf1);
}