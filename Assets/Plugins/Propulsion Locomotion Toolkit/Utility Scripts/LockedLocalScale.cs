using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Locked Local Scale
// • tracks this objects's original local scale before the start
// • constantly updates this object's local scale to be its original local scale
public class LockedLocalScale : MonoBehaviour
{
	// variables //

	
	// tracking: this object's original local scale //
	protected Vector3 localScaleOriginal;




	// updating //

	
	// before the start: //
	protected virtual void Awake()
	{
		// track this object's original local scale //
		localScaleOriginal = transform.localScale;
	}

	// at each update: //
	protected virtual void Update()
	{
		// set this object's local scale to be its original local scale //
		transform.localScale = localScaleOriginal;
	}
}