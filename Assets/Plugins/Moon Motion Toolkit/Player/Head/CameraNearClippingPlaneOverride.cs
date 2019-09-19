using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Camera Near Clipping Plane Override
// • serves as a workaround to set a Camera component's "Clipping Planes" - "Near" value with the allowance of going below the Camera component's inspector limit of 0.01
//   · only sets the value at the start (instead of at each update, so as to avoid being unnecessarily taxing)
//   · for at least Vive camera viewing, it would seem the inspector limit has good reason, as going below the limit can cause flickering black lines in the distance, seemingly only at a certain distance far enough away, especially noticeable in scenes where you can see a large enough distance away
[RequireComponent(typeof(Camera))]
public class CameraNearClippingPlaneOverride : AutoBehaviour<CameraNearClippingPlaneOverride>
{
	// variables //

	
	// setting: value to override to //
	public float clippingPlaneNear = 0.001f;




	// updating //

	
	// at the start: override to the specified value // 
	private void Start()
	{
		camera.nearClipPlane = clippingPlaneNear;
	}
}