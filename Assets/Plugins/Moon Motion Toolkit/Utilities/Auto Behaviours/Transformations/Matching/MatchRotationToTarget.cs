using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Match Rotation to Target:
// • updates this object's rotation to match the rotation of the target transform (otherwise this transform)
// #transformers
public class MatchRotationToTarget : MatchSomeTransformationsToTarget<MatchRotationToTarget>
{
	// updating //

	
	// at each update: //
	public override void update()
		=> setRotationTo(targetTransformOtherwiseThisTransform);
}