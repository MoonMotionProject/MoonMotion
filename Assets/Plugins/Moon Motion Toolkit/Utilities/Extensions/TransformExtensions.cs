using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Transform Extensions: provides extension methods for handling transforms //
// #auto #transform
public static class TransformExtensions
{
	#region accessing

	// method: return a selection of the transforms for this given enumerable of game objects //
	public static IEnumerable<Transform> selectTransforms(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.select(gameObject => gameObject.transform);
	#endregion accessing


	#region identification

	// method: return whether this given transform's game object is named 'Player' //
	public static bool isPlayer(this Transform transform)
		=> transform.gameObject.isPlayer();
	#endregion identification


	#region destruction

	// method: destroy the game object of this given transform //
	public static void destroyObject(this Transform transform)
		=> transform.gameObject.destroy();
	#endregion destruction


	#region activity

	// method: return whether this given transform is active locally //
	public static bool activeLocally(this Transform transform)
		=> transform.gameObject.activeLocally();

	// method: return whether this given transform is active globally //
	public static bool activeGlobally(this Transform transform)
		=> transform.gameObject.activeGlobally();

	// method: set the activity of this given transform to the given boolean, then return this given transform //
	public static Transform setActivityTo(this Transform transform, bool activity)
		=> transform.gameObject.setActivityTo(activity).transform;

	// method: activate this given transform, then return it //
	public static Transform activate(this Transform transform)
		=> transform.gameObject.activate().transform;

	// method: deactivate this given transform, then return it //
	public static Transform deactivate(this Transform transform)
		=> transform.gameObject.activate().transform;

	// method: toggle the activity of this given transform using the given toggling, then return this given transform //
	public static Transform toggleActivityBy(this Transform transform, Toggling toggling)
		=> transform.gameObject.toggleActivityBy(toggling).transform;

	// method: toggle the activity of these given transforms using the given toggling, then return them //
	public static Transform[] toggleActivityBy(this Transform[] transforms, Toggling toggling)
		=> transforms.forEach(transform => transform.toggleActivityBy(toggling));

	// method: set the activity of these given transforms to the given boolean, then return them //
	public static Transform[] setActivityTo(this Transform[] transforms, bool activity)
		=> transforms.forEach(transform => transform.setActivityTo(activity));

	// method: activate these given transforms, then return them //
	public static Transform[] activate(this Transform[] transforms)
		=> transforms.setActivityTo(true);

	// method: deactivate these given transforms, then return them //
	public static Transform[] deactivate(this Transform[] transforms)
		=> transforms.setActivityTo(false);
	#endregion activity


	#region calling local methods

	// method: call all of this transform's game object's mono behaviours' defined methods (ignoring inherited methods that haven't been overriden) with the given name, then return this given game object //
	public static Transform callAllLocal(this Transform transform, string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver)
		=> transform.gameObject.callAllLocal(methodName, sendMessageOptions).transform;

	// method: have all mono behaviours on this transform's game object validate (if they have OnValidate defined), then return this given transform //
	public static Transform validate(this Transform transform)
		=> transform.gameObject.validate().transform;
	#endregion calling local methods


	#region advanced rotation

	// method: (according to the given boolean:) have this given transform look at the given target position with the specified axes, then return this given transform //
	public static Transform lookAt(this Transform transform, Vector3 targetPosition, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
	{
		Vector3 initialRotation = transform.localEulerAngles;

		if (boolean)
		{
			transform.LookAt(targetPosition);
			if (!withX)
			{
				transform.setLocalEulerAngleXTo(initialRotation.x);
			}
			if (!withY)
			{
				transform.setLocalEulerAngleYTo(initialRotation.y);
			}
			if (!withZ)
			{
				transform.setLocalEulerAngleZTo(initialRotation.z);
			}
		}

		return transform;
	}

	// method: (according to the given boolean:) have this given transform look at the given target transform with the specified axes, then return this given transform //
	public static Transform lookAt(this Transform transform, Transform targetTransform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> transform.lookAt(targetTransform.position, boolean);

	// method: (according to the given boolean:) have this given transform look at the given target transform with the specified axes, then return this given transform //
	public static Transform lookAt(this Transform transform, GameObject targetObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> transform.lookAt(targetObject.transform, boolean);

	// method: (according to the given boolean:) have this given transform look at the given target component's transform with the specified axes, then return this given transform //
	public static Transform lookAt(this Transform transform, Component targetComponent, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> transform.lookAt(targetComponent.transform, boolean);

	// method: (according to the given boolean:) have this given transform look at the main camera with the specified axes, then return this given transform //
	public static Transform lookAtCamera(this Transform transform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> transform.lookAt(Camera.main, boolean);

	// method: (according to the given boolean:) have this given transform rotate by the given (x, y, and z) rotation angles, then return this given transform //
	public static Transform rotate(this Transform transform, Vector3 rotationAngles, bool boolean = true)
	{
		if (boolean)
		{
			transform.Rotate(rotationAngles);
		}

		return transform;
	}

	// method: (according to the given boolean:) have this given transform rotate by the given x, y, and z rotation angles, then return this given transform //
	public static Transform rotate(this Transform transform, float x, float y, float z, bool boolean = true)
	{
		if (boolean)
		{
			transform.Rotate(x, y, z);
		}

		return transform;
	}

	// method: (according to the given boolean:) have this given transform rotate by the given x rotation angle, then return this given transform //
	public static Transform rotateX(this Transform transform, float x, bool boolean = true)
		=> transform.rotate(Vectors.zeroesVector.withX(x), boolean);

	// method: (according to the given boolean:) have this given transform rotate by the given y rotation angle, then return this given transform //
	public static Transform rotateY(this Transform transform, float y, bool boolean = true)
		=> transform.rotate(Vectors.zeroesVector.withY(y), boolean);

	// method: (according to the given boolean:) have this given transform rotate by the given z rotation angle, then return this given transform //
	public static Transform rotateZ(this Transform transform, float z, bool boolean = true)
		=> transform.rotate(Vectors.zeroesVector.withZ(z), boolean);

	// method: (according to the given boolean:) have this given transform rotate by 180° on the x axis, then return this given transform //
	public static Transform flipX(this Transform transform, bool boolean = true)
		=> transform.rotateX(180f, boolean);

	// method: (according to the given boolean:) have this given transform rotate by 180° on the y axis, then return this given transform //
	public static Transform flipY(this Transform transform, bool boolean = true)
		=> transform.rotateY(180f, boolean);

	// method: (according to the given boolean:) have this given transform rotate by 180° on the z axis, then return this given transform //
	public static Transform flipZ(this Transform transform, bool boolean = true)
		=> transform.rotateZ(180f, boolean);
	#endregion advanced rotation


	#region directions

	// method: return the vector for the forward direction relative to this given transform //
	public static Vector3 forward(this Transform transform)
		=> transform.forward;

	// method: return the vector for the backward direction relative to this given transform //
	public static Vector3 backward(this Transform transform)
		=> -transform.forward;

	// method: return the vector for the right direction relative to this given transform //
	public static Vector3 right(this Transform transform)
		=> transform.right;

	// method: return the vector for the left direction relative to this given transform //
	public static Vector3 left(this Transform transform)
		=> -transform.right;

	// method: return the vector for the up direction relative to this given transform //
	public static Vector3 up(this Transform transform)
		=> transform.up;

	// method: return the vector for the down direction relative to this given transform //
	public static Vector3 down(this Transform transform)
		=> -transform.up;

	// method: return the direction vector for the given direction as relative to this given transform //
	public static Vector3 vectorForRelativeDirection(this Transform transform, Direction direction)
		=> direction.asDirectionVectorRelativeTo(transform);
	#endregion directions


	#region transformation averages

	// method: determine the average of these given transforms' local positions //
	public static Vector3 averageLocalPosition(this Transform[] transforms)
		=> transforms.selectLocalPositions().average();

	// method: determine the average of these given transforms' local scales //
	public static Vector3 averageLocalScale(this Transform[] transforms)
		=> transforms.selectLocalScales().average();

	// method: determine the average of these given transforms' (global) positions //
	public static Vector3 averagePosition(this Transform[] transforms)
		=> transforms.selectPositions().average();
	#endregion transformation averages


	#region casting

	// method: return the enumerable (of child transforms) for this given transform //
	public static IEnumerable<Transform> asEnumerable(this Transform transform)
		=> transform.castToIEnumerable<Transform>();
	#endregion casting
}