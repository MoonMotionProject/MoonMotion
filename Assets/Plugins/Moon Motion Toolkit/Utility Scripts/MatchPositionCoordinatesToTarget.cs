using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Match Position Coordinates to Target: updates this object's position to match a set target transform's position, for only those axes toggled as needing to be matched
public class MatchPositionCoordinatesToTarget : MonoBehaviour
{
	// variables //

	
	// connection: the target transform to match to //
	[Header("Target")]
	public Transform targetTransform;
	
	// settings: toggles for whether to match each axis in particular, respectively //
	[Header("Coordinate Matching Toggles")]
	public bool matchX = true, matchY = true, matchZ = true;




	// updating //

	
	// at each update: //
	protected virtual void Update()
	{
		// determine: the position of this object, the position of the target transform //
		Vector3 currentPosition = transform.position;
		Vector3 targetPosition = targetTransform.position;

		// based on the matching toggles, determine the intended position coordinate for each axis, respectively //
		float intendedXPosition = (matchX ? targetPosition.x : currentPosition.x);
		float intendedYPosition = (matchY ? targetPosition.y : currentPosition.y);
		float intendedZPosition = (matchZ ? targetPosition.z : currentPosition.z);

		// set this object's position to the position for the determined intended position coordinates //
		transform.position = new Vector3(intendedXPosition, intendedYPosition, intendedZPosition);
	}
}