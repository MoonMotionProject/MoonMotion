using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sphere Collider Extensions: provides extension methods for handling sphere colliders
// #primitives
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
}