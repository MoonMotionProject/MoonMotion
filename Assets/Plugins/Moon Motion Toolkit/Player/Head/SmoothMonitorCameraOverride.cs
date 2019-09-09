using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Smooth Monitor Camera Override: has this smooth monitor camera override smoothly follow the player's head transform //
[CacheTransform]
public class SmoothMonitorCameraOverride : SingletonBehaviour<SmoothMonitorCameraOverride>
{
	// variables //

	
	// manual connections //

	[BoxGroup("Head Connection")]
	[Tooltip("the head transform of the player for this smooth monitor camera override to follow")]
	public Transform headTransform;


	// settings for: smoothing //

	[BoxGroup("Smoothing")]
	[Tooltip("the duration by which to finish smoothing position after movement of the head transform has stopped")]
    public float positionSmoothingDuration = .3f;

	[BoxGroup("Smoothing")]
	[Tooltip("the speed by which to smooth rotation")]
	public float rotationSmoothingSpeed = 5f;

	[Tooltip("the position velocity referenced by the 'SmoothDamp' call used for position smoothing")]
    private Vector3 positionVelocity = FloatsVector.zeroes;




	// updating //

	
	// at each update: //
	private void Update()
	{
		// smooth this smooth monitor camera override's position to that of the head transform's //
        transform.position = Vector3.SmoothDamp(transform.position, headTransform.position, ref positionVelocity, positionSmoothingDuration);

		// smooth this smooth monitor camera override's rotation to that of the head transform's //
        transform.rotation = Quaternion.Slerp(transform.rotation, headTransform.rotation, rotationSmoothingSpeed * Time.deltaTime);
	}
}