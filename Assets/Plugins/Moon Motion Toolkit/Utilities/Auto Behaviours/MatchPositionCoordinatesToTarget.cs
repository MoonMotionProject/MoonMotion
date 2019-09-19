using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Match Position Coordinates to Target:
// • updates this object's position to match a set target transform's position, for only those coordinate axes toggled as needing to be matched
[CacheTransform]
public class MatchPositionCoordinatesToTarget : AutoBehaviour<MatchPositionCoordinatesToTarget>
{
	// variables //


	// settings //

	[Header("Target")]
	[Tooltip("the target transform to match to")]
	public Transform targetTransform;

	[Header("Coordinate Matching Toggles")]
	[Tooltip("whether to match the x coordinate")]
	public bool matchX = true;
	[Tooltip("whether to match the y coordinate")]
	public bool matchY = true;
	[Tooltip("whether to match the z coordinate")]
	public bool matchZ = true;




	// updating //

	
	// at each update: //
	protected virtual void Update()
	{
		setPositionTo	(transform.position
							.withX(targetTransform.positionX(), matchX)
							.withY(targetTransform.positionY(), matchY)
							.withZ(targetTransform.positionZ(), matchZ)
						);
	}
}