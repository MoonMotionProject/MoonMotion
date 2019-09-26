using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Raycast Query Extensions: provides extension methods for handling raycast queries //
public static class RaycastQueryExtensions
{
	#region determination

	// method: return whether this given raycast query queries for colliders at the raycasting position //
	public static bool queriesPositionalColliders(this RaycastQuery raycastQuery)
		=> raycastQuery == RaycastQuery.unlimitedHitsAndAllPositionalColliders;

	// method: return whether this given raycast query queries for only the first hit //
	public static bool queriesOnlyFirstHit(this RaycastQuery raycastQuery)
		=> raycastQuery == RaycastQuery.firstHit;
	#endregion determination
}