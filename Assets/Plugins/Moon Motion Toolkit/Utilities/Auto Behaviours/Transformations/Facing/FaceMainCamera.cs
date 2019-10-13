using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Face Main Camera: updates this object to always face the main camera
// #transform #transformations
[CacheTransform]
public class FaceMainCamera : AutoBehaviour<FaceMainCamera>
{
	// variables //

	
	// settings //
	[Tooltip("whether to flip the y rotation after facing the main camera (useful for text)")]
	public bool flipYAfterFacing = true;




	// updating //


	// at each update: //
	protected virtual void Update()
    {
        faceCamera();
		flipY(flipYAfterFacing);
	}
}