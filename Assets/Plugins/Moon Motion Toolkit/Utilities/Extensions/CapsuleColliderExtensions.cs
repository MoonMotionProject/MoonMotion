using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Capsule Collider Extensions: provides extension methods for handling capsule colliders
// #primitives
public static class CapsuleColliderExtensions
{
	#region center position

	// method: return the local center position of this given capsule collider //
	public static Vector3 localCenterPosition(this CapsuleCollider capsuleCollider)
		=> capsuleCollider.center;
	
	// method: return the (global) center position of this given capsule collider //
	public static Vector3 centerPosition(this CapsuleCollider capsuleCollider)
		=> capsuleCollider.localCenterPosition().asLocalPositionToGlobalPositionFrom(capsuleCollider);
	#endregion center position


	#region height

	// method: return the halfheight of this given capsule collider //
	public static float halfheight(this CapsuleCollider capsuleCollider)
		=> capsuleCollider.height.halved();
	#endregion height
}