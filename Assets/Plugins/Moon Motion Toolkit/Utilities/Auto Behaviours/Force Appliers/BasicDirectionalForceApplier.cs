using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Basic Directional Force Applier:
// • at each physics update, applies basic directional force to the ensured corresponding rigidbody
// #force
public class BasicDirectionalForceApplier : AutoBehaviour<BasicDirectionalForceApplier>
{
	// variables //


	// settings //
	
	public BasicDirection basicDirection = Default.basicDirection;
	public Distinctivity distinctivity = Default.basicDirectionDistinctivity;
	public float magnitude = Default.forceMagnitude;




	// updating //


	// at each physics update: //
	public override void physicsUpdate()
		=> applyForceAlong(basicDirection, distinctivity, magnitude);
}