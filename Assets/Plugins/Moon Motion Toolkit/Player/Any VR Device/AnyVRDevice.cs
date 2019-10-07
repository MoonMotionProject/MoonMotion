using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Any VR Device: provides properties about any VR devices //
public static class AnyVRDevice
{
	// whether any VR device is touched
	// only accurate while playing (since controller input isn't processed in editor edit mode)
	public static bool isTouched =>
		Headset.isApparentlyBeingWorn ||
		(AnyControllerOperationTracker.singleton && AnyControllerOperationTracker.state);
}