using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Match Position to Target:
// • updates this object's position to match the position of the target transform (otherwise this transform)
// #transform #transformations
public class MatchPositionToTarget : MatchSomeTransformationsToTarget<MatchPositionToTarget>
{
	// updating //

	
	// at each update: //
	public virtual void Update()
		=> setPositionTo(targetTransformOtherwiseThisTransform);
}