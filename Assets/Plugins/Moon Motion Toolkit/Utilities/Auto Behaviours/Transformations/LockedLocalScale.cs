using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Locked Local Scale
// • constantly updates this object's local scale to be the local scale it had at awake
// #transform #transformations
[CacheTransform] [RequireComponent(typeof(TrackLocalScaleAtAwake))]
public class LockedLocalScale : AutoBehaviour<LockedLocalScale>
{
	// updating //

	
	// at each update: //
	protected virtual void Update()
		=> setLocalScaleTo(localScaleAwake);
}