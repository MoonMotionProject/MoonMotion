using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Locked Local Scale
// • constantly updates this object's local scale to be the local scale it had at awake 
[CacheTransform] [RequireComponent(typeof(TrackLocalScaleAtAwake))]
public class LockedLocalScale : AutomaticBehaviour<LockedLocalScale>
{
	// updating //

	
	// at each update: //
	protected virtual void Update()
		=> setLocalScale(localScaleAwake);
}