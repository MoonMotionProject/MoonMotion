using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Smooth Monitor Camera Override: has this smooth monitor camera override smoothly follow the player's head transform //
public class SmoothMonitorCameraOverride : MonoBehaviour
{
	// variables //

	
	public Transform headTransform;		// connection - manual: the head transform of the player for this smooth monitor camera override to follow
    public float positionSmoothingDuration = .3f;		// setting: the duration by which to finish smoothing position after movement of the head transform has stopped
	public float rotationSmoothingSpeed = 5f;		// setting: the speed by which to smooth rotation
    private Vector3 positionVelocity = Vector3.zero;		// tracking: the position velocity referenced by the 'SmoothDamp' call used for position smoothing




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