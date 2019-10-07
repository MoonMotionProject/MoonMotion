using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Raycast Hit Extensions: provides extension methods for handling raycast hits
// #raycasting
public static class RaycastHitExtensions
{
	// method: return the position of this given raycast hit //
	public static Vector3 position(this RaycastHit raycastHit)
		=> raycastHit.point;
}