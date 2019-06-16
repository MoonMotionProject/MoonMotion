using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Face Player Camera: updates this object to always face the player camera //
[CacheTransform]
public class FacePlayerCamera : AutomaticBehaviour<FacePlayerCamera>
{
	// variables //

	
	// settings //
	[Tooltip("whether to flip the y rotation after facing the player camera (useful for text)")]
	public bool flipYAfterFacing = true;




	// updating //


	// at each update: //
	protected virtual void Update()
    {
        lookAtCamera();
		flipY(flipYAfterFacing);
	}
}