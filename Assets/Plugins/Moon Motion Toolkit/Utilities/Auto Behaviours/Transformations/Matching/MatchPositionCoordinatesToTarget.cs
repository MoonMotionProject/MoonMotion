using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Match Position Coordinates to Target:
// • updates this object's position to match the position coordinates of the target transform (otherwise this transform), for only those coordinate axes toggled as needing to be matched
// #transform #transformations
public class MatchPositionCoordinatesToTarget : MatchSomeTransformationsToTarget<MatchPositionCoordinatesToTarget>
{
	// variables //


	// settings //
	
	[BoxGroup("Coordinate Matching")]
	[Tooltip("whether to match the x coordinate")]
	public bool matchX = true;

	[BoxGroup("Coordinate Matching")]
	[Tooltip("whether to match the y coordinate")]
	public bool matchY = true;

	[BoxGroup("Coordinate Matching")]
	[Tooltip("whether to match the z coordinate")]
	public bool matchZ = true;




	// updating //

	
	// at each update: //
	public virtual void Update()
	{
		setPositionTo	(transform.position
							.withX(targetTransformOtherwiseThisTransform.positionX(), matchX)
							.withY(targetTransformOtherwiseThisTransform.positionY(), matchY)
							.withZ(targetTransformOtherwiseThisTransform.positionZ(), matchZ)
						);
	}
}