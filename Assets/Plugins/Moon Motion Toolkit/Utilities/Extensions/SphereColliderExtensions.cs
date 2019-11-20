using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sphere Collider Extensions: provides extension methods for handling sphere colliders
// #collider #primitives
public static class SphereColliderExtensions
{
	#region center position

	// method: return the local center position of this given sphere collider //
	public static Vector3 localCenterPosition(this SphereCollider sphereCollider)
		=> sphereCollider.center;
	
	// method: return the (global) center position of this given sphere collider //
	public static Vector3 centerPosition(this SphereCollider sphereCollider)
		=> sphereCollider.localCenterPosition().asLocalPositionToGlobalPositionFrom(sphereCollider);
	#endregion center position


	#region setting radius

	// method: set the radius of this given sphere collider to the given radius, then return this given sphere collider //
	public static SphereCollider setRadiusTo(this SphereCollider sphereCollider, float radius)
		=>	sphereCollider.after(()=>
				sphereCollider.radius = radius);
	#endregion setting radius
}