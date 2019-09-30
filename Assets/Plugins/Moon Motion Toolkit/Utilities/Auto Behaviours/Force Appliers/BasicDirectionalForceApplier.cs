using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Basic Directional Force Applier:
// • at each physics update, applies basic directional force
// #force
[RequireComponent(typeof(Rigidbody))]
public class BasicDirectionalForceApplier : AutoBehaviour<BasicDirectionalForceApplier>
{
	// variables //


	// settings //
	
	public BasicDirection basicDirection = Default.basicDirection;
	public Distinctivity distinctivity = Default.basicDirectionDistinctivity;
	public float magnitude = Default.forceMagnitude;




	// updating //


	// at each physics update: //
	private void FixedUpdate()
		=> applyForceAlong(basicDirection, distinctivity, magnitude);
}