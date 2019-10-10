using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Match Transformations to Target:
// • updates this object's transformations to match the transformations of the target transform (otherwise this transform)
// #transform #transformations
public class MatchTransformationsToTarget : MatchSomeTransformationsToTarget<MatchTransformationsToTarget>
{
	// updating //

	
	// at each update: //
	public virtual void Update()
		=> setTransformationsTo(targetTransformOtherwiseThisTransform);
}

public static class MatchTransformationsToTargetExtensions
{
	// method: ensure a Match Transformations To Target behaviour on this given game object, set the target transform of the Match Transformations To Target behaviour to the given provided target transform, have the behaviour update, then return this given game object //
	public static GameObject ensuredlyMatchTransformationsTo(this GameObject gameObject, object targetTransform_TransformProvider)
	{
		Transform targetTransform = Provide.transformVia(targetTransform_TransformProvider);

		return gameObject.ensureActUpon<MatchTransformationsToTarget>(matchTransformationsToTarget =>
			matchTransformationsToTarget.setTargetTo(targetTransform).Update());
	}
	// method: ensure a Match Transformations To Target behaviour on this given game object, set the target transform of the Match Transformations To Target behaviour to null, then return this given game object //
	public static GameObject ensuredlyMatchTransformationsToNull(this GameObject gameObject)
		=> gameObject.ensureActUpon<MatchTransformationsToTarget>(matchTransformationsToTarget =>
			matchTransformationsToTarget.setTargetToNull());
}