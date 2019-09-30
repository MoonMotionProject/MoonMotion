using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TrackCollideds : TrackingBehaviour<TrackCollideds>
{
	// variables //


	// trackings //

	[ReadOnly]
	public new HashSet<Collider> collidedColliders = new HashSet<Collider>();




	// updating //


	// upon validation (defined here so that the OnValidate derived from CommonBehaviour can be found using reflection): //
	public override void OnValidate()
		=> base.OnValidate();
	
	// upon colliding: //
	private void OnCollisionEnter(Collision collision)
		=> collidedColliders.add(collision.collider);

	// upon uncolliding: //
	private void OnCollisionExit(Collision collision)
		=> collidedColliders.remove(collision.collider);
}