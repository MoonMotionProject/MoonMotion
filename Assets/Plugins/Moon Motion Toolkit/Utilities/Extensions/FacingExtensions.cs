using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Facing Extensions: provides extension methods for facing //
public static class FacingExtensions
{
	// methods: (according to the given boolean:) have this given transform provider face the given target position provider with the specified axes and the given up direction to prefer (if one is given, otherwise defaulting to the global up direction), then return this given transform //

	
	public static Transform face(this Transform transform, Vector3 targetPosition, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
	{
		Vector3 initialLocalEulerAngles = transform.localEulerAngles;

		if (boolean)
		{
			transform.LookAt(targetPosition, upDirection_MaxOf1.firstOtherwise(Direction.up));
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
	public static GameObject face(this GameObject gameObject, Vector3 targetPosition, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> gameObject.transform.face(targetPosition, withX, withY, withZ, boolean, upDirection_MaxOf1).gameObject;
	
	public static Transform face(this Transform transform, Transform targetTransform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> transform.face(targetTransform.position, withX, withY, withZ, boolean, upDirection_MaxOf1);
	public static GameObject face(this GameObject gameObject, Transform targetTransform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> gameObject.transform.face(targetTransform, withX, withY, withZ, boolean, upDirection_MaxOf1).gameObject;
	
	public static Transform face(this Transform transform, GameObject targetObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> transform.face(targetObject.transform, withX, withY, withZ, boolean, upDirection_MaxOf1);
	public static GameObject face(this GameObject gameObject, GameObject targetObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> gameObject.transform.face(targetObject, withX, withY, withZ, boolean, upDirection_MaxOf1).gameObject;
	
	public static Transform face(this Transform transform, Component targetComponent, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> transform.face(targetComponent.transform, withX, withY, withZ, boolean, upDirection_MaxOf1);
	public static GameObject face(this GameObject gameObject, Component targetComponent, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> gameObject.transform.face(targetComponent.transform, withX, withY, withZ, boolean, upDirection_MaxOf1).gameObject;
	
	public static Transform faceCamera(this Transform transform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
	{
		if (Camera.main)
		{
			transform.face(Camera.main, withX, withY, withZ, boolean, upDirection_MaxOf1);
		}

		return transform;
	}
	public static GameObject faceCamera(this GameObject gameObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> gameObject.transform.faceCamera(withX, withY, withZ, boolean, upDirection_MaxOf1).gameObject;
}