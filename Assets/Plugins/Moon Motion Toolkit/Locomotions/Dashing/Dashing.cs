using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Valve.VR.InteractionSystem;

// Dashing:
// • provides the player with the dashing locomotion
public class Dashing : SingletonBehaviour<Dashing>, ILocomotion
{
	// variables //

	
	// settings //

	[Tooltip("the controller operations by which to dash")]
	[ReorderableList]
	public ControllerOperation[] operations;




	// methods //

	
	// method: dash to the given raycast hit //
	private void dashTo(RaycastHit raycastHit)
	{
		MoonMotionPlayer.zeroVelocities();
		MoonMotionPlayer.setPositionForMovingBodyPositionTo(raycastHit);
	}




	// updating //

	
	// at each update: //
	private void Update()
	{
		if (operations.operated())
		{
			if (DashingOutlining.outlinedObject)
			{
				dashTo(DashingOutlining.outliningRaycastHit.GetValueOrDefault());
			}
		}
	}
}