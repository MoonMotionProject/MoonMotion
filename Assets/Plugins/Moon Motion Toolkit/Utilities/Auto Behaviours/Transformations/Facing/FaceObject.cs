using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Face Object:
// • has this object face the target object, only on the set axes
// #transform #transformations
public class FaceObject : AutoBehaviour<FaceObject>
{
	// variables //

	
	// settings //

	public GameObject targetObject;
	public bool faceX, faceY, faceZ = true;




	// methods //

	
	// method: face the target object //
	private void faceTarget()
		=> face(targetObject, faceX, faceY, faceZ);




	// updating //


	// at each update: //
	private void Update()
		=> faceTarget();
}