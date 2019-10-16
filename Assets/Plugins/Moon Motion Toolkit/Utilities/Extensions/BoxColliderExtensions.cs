using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Box Collider Extensions: provides extension methods for handling box colliders
// #primitives
public static class BoxColliderExtensions
{
	#region center position

	// method: return the local center position of this given box collider //
	public static Vector3 localCenterPosition(this BoxCollider boxCollider)
		=> boxCollider.center;
	
	// method: return the (global) center position of this given box collider //
	public static Vector3 centerPosition(this BoxCollider boxCollider)
		=> boxCollider.localCenterPosition().asLocalPositionToGlobalPositionFrom(boxCollider);
	#endregion center position
}