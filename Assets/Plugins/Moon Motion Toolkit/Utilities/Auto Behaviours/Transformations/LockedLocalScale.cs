using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Locked Local Scale
// • constantly updates this object's local scale to be the local scale it had at awake
// #transformers
[CacheTransform] [RequireComponent(typeof(TrackLocalScaleAtAwake))]
public class LockedLocalScale : AutoBehaviour<LockedLocalScale>
{
	// updating //

	
	// at each update: //
	public override void update()
		=> setLocalScaleTo(localScaleAwake);
}