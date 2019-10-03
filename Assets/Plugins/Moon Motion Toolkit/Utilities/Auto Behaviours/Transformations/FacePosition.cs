using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Face Object:
// • has this object face the target position, only on the set axes
// #transform #transformations
public class FacePosition : AutoBehaviour<FacePosition>
{
	// variables //

	
	// settings //

	public Vector3 targetPosition;
	public bool faceX = true;
	public bool faceY = true;
	public bool faceZ = true;




	// methods //

	
	// method: face the target object //
	private void faceTarget()
		=> face(targetPosition, faceX, faceY, faceZ);




	// updating //


	// at each update: //
	private void Update()
		=> faceTarget();
}