using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Face Main Camera: updates this object to always face the main camera
// #transformers
[CacheTransform]
public class FaceMainCamera : AutoBehaviour<FaceMainCamera>
{
	// variables //

	
	// settings //
	[Tooltip("whether to flip the y rotation after facing the main camera (useful for text)")]
	public bool flipYAfterFacing = true;




	// updating //


	// at each update: //
	public override void update()
    {
        faceCamera();
		flipY(flipYAfterFacing);
	}
}