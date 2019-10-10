using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sliding
// • classifies this locomotion as the "sliding" locomotion
// • continuously moves this object's position by the set velocity, scaled by the multiplier setting
public class Sliding : MonoBehaviour, ILocomotion
{
	// variables //

	
	public Vector3 velocity = new Vector3(1f, 1f, 1f);		// setting: the velocity by which to continuously move this object's position
	public float multiplier = .01f;		// setting: the multiplier by which to scale the velocity used




	// updating //


	// at each physics update: //
	private void FixedUpdate()
	{
		transform.position += (velocity * multiplier * Time.fixedDeltaTime);
	}
}