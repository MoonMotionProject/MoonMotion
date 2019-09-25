using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collision Extensions: provides extension methods for handling collisions
// #collision
public static class CollisionExtensions
{
	// method: switch collision between the layer for this given string as a layer name and the layer for the given other layer name based on the given boolean, then return this given string //
	public static void setCollisionWith(this string string_, string otherLayer, bool collision)
		=> string_.after(()=>
			Physics.IgnoreLayerCollision(
				LayerMask.NameToLayer(string_),
				LayerMask.NameToLayer(otherLayer),
				!collision));
}