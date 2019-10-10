using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Match Some Transformations to Target
// #transform #transformations
[CacheTransform]
public abstract class	MatchSomeTransformationsToTarget<MatchSomeTransformationsToTargetT> :
					AutoBehaviour<MatchSomeTransformationsToTargetT>
						where MatchSomeTransformationsToTargetT : MatchSomeTransformationsToTarget<MatchSomeTransformationsToTargetT>
{
	// variables //

	
	// settings //

	[BoxGroup("Target")]
	[Tooltip("the target transform to match to")]
	public Transform targetTransform;




	// properties //
	
	public Transform targetTransformOtherwiseThisTransform => targetTransform ? targetTransform : transform;
	
	
	

	// methods //

	
	// method: set the target transform to the given provided transform, then return this (derived) behaviour //
	public MatchSomeTransformationsToTargetT setTargetTo(object targetTransform_TransformProvider)
		=> selfAfter(()=> targetTransform = Provide.transformVia(targetTransform_TransformProvider));

	// method: set the target transform to null (such that the self transform is used as a fallback, instead), then return this (derived) behaviour //
	public MatchSomeTransformationsToTargetT setTargetToNull()
		=> selfAfter(()=> targetTransform = null);
}