using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Match Transformations to Target:
// • updates this object's transformations to match the transformations of the target transform (otherwise this transform)
// #transformers
public class MatchTransformationsToTarget : MatchSomeTransformationsToTarget<MatchTransformationsToTarget>
{
	// variables //


	[BoxGroup("Offset")]
	[Tooltip("the displacement by which to offset this object's position after matching its transformations to the target")]
	public Vector3 positionOffset = Default.displacement;




	// methods //

	// method: (according to the given boolean:) set the position offset to the given position offset, then return this behaviour //
	public MatchTransformationsToTarget setPositionOffsetTo(Vector3 givenPositionOffset, bool boolean = true)
		=>	selfAfter(()=>
				positionOffset = givenPositionOffset,
				boolean);
	
	
	
	
	// updating //

	
	// at each update: //
	public override void update()
		=> setTransformationsTo(targetTransformOtherwiseThisTransform).displacePositionBy(positionOffset);
}

public static class MatchTransformationsToTargetExtensions
{
	// method: ensure a Match Transformations To Target behaviour on this given game object, set the target transform of the Match Transformations To Target behaviour to the given provided target transform, set the position offset of the Match Transformations To Target behaviour to the given position offset if the given boolean is true, have the behaviour update, then return this given game object //
	public static GameObject ensuredlyMatchTransformationsTo(this GameObject gameObject, object targetTransform_TransformProvider, Vector3? positionOffset = null, bool changePositionOffset = true)
		=>	gameObject.ensureActUpon<MatchTransformationsToTarget>(matchTransformationsToTarget =>
				matchTransformationsToTarget
					.setTargetTo
					(
						targetTransform_TransformProvider.provideTransform()
					)
					.setPositionOffsetTo
					(
						positionOffset.GetValueOrDefault(),
						changePositionOffset
					)
					.update());
	// method: ensure a Match Transformations To Target behaviour on this given game object, set the target transform of the Match Transformations To Target behaviour to null, set the position offset of the Match Transformations To Target behaviour to the given position offset if the given boolean is true, have the behaviour update, then return this given game object //
	public static GameObject ensuredlyMatchTransformationsToNull(this GameObject gameObject, Vector3? positionOffset = null, bool changePositionOffset = true)
		=>	gameObject.ensureActUpon<MatchTransformationsToTarget>(matchTransformationsToTarget =>
				matchTransformationsToTarget
					.setTargetToNull()
					.setPositionOffsetTo
					(
						positionOffset.GetValueOrDefault(),
						changePositionOffset
					)
					.update());
}