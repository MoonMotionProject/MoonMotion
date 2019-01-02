using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collisions: provides a method for setting collision between two layers based on their names //
public static class Collisions
{
	// method: set collision between the two layers for the two given layer names based on the given boolean //
	public static void setCollisionBetween(string firstLayer, string secondLayer, bool collision)
	{
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer(firstLayer), LayerMask.NameToLayer(secondLayer), !collision);
	}
}