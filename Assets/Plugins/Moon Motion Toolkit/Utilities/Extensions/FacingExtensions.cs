using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Facing Extensions: provides extension methods for facing //
public static class FacingExtensions
{
	// method: (according to the given boolean:) have this given transform face the given target position with the specified axes, then return this given transform //
	public static Transform face(this Transform transform, Vector3 targetPosition, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
	{
		Vector3 initialLocalEulerAngles = transform.localEulerAngles;

		if (boolean)
		{
			transform.LookAt(targetPosition);
			if (!withX)
			{
				transform.setLocalEulerAngleXTo(initialLocalEulerAngles.x);
			}
			if (!withY)
			{
				transform.setLocalEulerAngleYTo(initialLocalEulerAngles.y);
			}
			if (!withZ)
			{
				transform.setLocalEulerAngleZTo(initialLocalEulerAngles.z);
			}
		}

		return transform;
	}
	// method: (according to the given boolean:) have this given game object face the given target position with the specified axes, then return this given game object //
	public static GameObject face(this GameObject gameObject, Vector3 targetPosition, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> gameObject.transform.face(targetPosition, withX, withY, withZ, boolean).gameObject;

	// method: (according to the given boolean:) have this given transform face the given target transform with the specified axes, then return this given transform //
	public static Transform face(this Transform transform, Transform targetTransform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> transform.face(targetTransform.position, withX, withY, withZ, boolean);
	// method: (according to the given boolean:) have this given game object face the given target transform with the specified axes, then return this given game object //
	public static GameObject face(this GameObject gameObject, Transform targetTransform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> gameObject.transform.face(targetTransform, withX, withY, withZ, boolean).gameObject;

	// method: (according to the given boolean:) have this given transform face the given target object with the specified axes, then return this given transform //
	public static Transform face(this Transform transform, GameObject targetObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> transform.face(targetObject.transform, withX, withY, withZ, boolean);
	// method: (according to the given boolean:) have this given game object face the given target object with the specified axes, then return this given game object //
	public static GameObject face(this GameObject gameObject, GameObject targetObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> gameObject.transform.face(targetObject, withX, withY, withZ, boolean).gameObject;

	// method: (according to the given boolean:) have this given transform face the given target component with the specified axes, then return this given transform //
	public static Transform face(this Transform transform, Component targetComponent, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> transform.face(targetComponent.transform, withX, withY, withZ, boolean);
	// method: (according to the given boolean:) have this given game object face the given target component with the specified axes, then return this given game object //
	public static GameObject face(this GameObject gameObject, Component targetComponent, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> gameObject.transform.face(targetComponent.transform, withX, withY, withZ, boolean).gameObject;

	// method: (according to the given boolean:) have this given transform face the main camera with the specified axes, then return this given transform //
	public static Transform faceCamera(this Transform transform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> transform.face(Camera.main, withX, withY, withZ, boolean);
	// method: (according to the given boolean:) have this given game object face the main camera with the specified axes, then return this given game object //
	public static GameObject faceCamera(this GameObject gameObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> gameObject.transform.faceCamera(boolean, withX, withY, withZ).gameObject;
}