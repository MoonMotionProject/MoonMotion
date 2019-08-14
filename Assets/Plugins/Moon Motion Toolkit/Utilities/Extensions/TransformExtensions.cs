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


	#region accessing transformations

	// methods: return a selection of local positions corresponding to these given transforms //
	public static IEnumerable<Vector3> selectLocalPositions(this IList<Transform> transforms)
		=> transforms.select(transform => transform.localPosition);

	// method: return this given transform's local x position //
	public static float localPositionX(this Transform transform)
		=> transform.localPosition.x;

	// method: return this given transform's local y position //
	public static float localPositionY(this Transform transform)
		=> transform.localPosition.y;

	// method: return this given transform's local z position //
	public static float localPositionZ(this Transform transform)
		=> transform.localPosition.z;

	// method: return this given transform's local x euler angle //
	public static float localEulerAngleX(this Transform transform)
		=> transform.localEulerAngles.x;

	// method: return this given transform's local y euler angle //
	public static float localEulerAngleY(this Transform transform)
		=> transform.localEulerAngles.y;

	// method: return this given transform's local z euler angle //
	public static float localEulerAngleZ(this Transform transform)
		=> transform.localEulerAngles.z;

	// methods: return a selection of local scales corresponding to these given transforms //
	public static IEnumerable<Vector3> selectLocalScales(this IList<Transform> transforms)
		=> transforms.select(transform => transform.localScale);

	// method: return this given transform's local x scale //
	public static float localScaleX(this Transform transform)
		=> transform.localScale.x;

	// method: return this given transform's local y scale //
	public static float localScaleY(this Transform transform)
		=> transform.localScale.y;

	// method: return this given transform's local z scale //
	public static float localScaleZ(this Transform transform)
		=> transform.localScale.z;

	// methods: return a selection of (global) positions corresponding to these given transforms //
	public static IEnumerable<Vector3> selectPositions(this IList<Transform> transforms)
		=> transforms.select(transform => transform.position);

	// method: return this given transform's (global) x position //
	public static float positionX(this Transform transform)
		=> transform.position.x;

	// method: return this given transform's (global) y position //
	public static float positionY(this Transform transform)
		=> transform.position.y;

	// method: return this given transform's (global) z position //
	public static float positionZ(this Transform transform)
		=> transform.position.z;

	// method: return this given transform's x euler angle //
	public static float eulerAngleX(this Transform transform)
		=> transform.eulerAngles.x;

	// method: return this given transform's y euler angle //
	public static float eulerAngleY(this Transform transform)
		=> transform.eulerAngles.y;

	// method: return this given transform's z euler angle //
	public static float eulerAngleZ(this Transform transform)
		=> transform.eulerAngles.z;
	#endregion accessing transformations


	#region setting transformations

	// method: (according to the given boolean:) set this given transform's local position to the given local position, then return this given transform //
	public static Transform setLocalPositionTo(this Transform transform, Vector3 localPosition, bool boolean = true)
	{
		if (boolean)
		{
			transform.localPosition = localPosition;
		}

		return transform;
	}
	// method: (according to the given boolean:) set this given transform's local position to the local position for the given x, y, and z values, then return this given transform //
	public static Transform setLocalPositionTo(this Transform transform, float x, float y, float z, bool boolean = true)
		=> transform.setLocalPositionTo(new Vector3(x, y, z), boolean);
	// method: (according to the given boolean:) set this given transform's local position to the other given transform's local position, then return this given transform //
	public static Transform setLocalPositionTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalPositionTo(otherTransform.localPosition, boolean);
	// method: (according to the given boolean:) set this given transform's local position to the given game object's local position, then return this given transform //
	public static Transform setLocalPositionTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalPositionTo(gameObject.localPosition(), boolean);
	// method: (according to the given boolean:) set this given transform's local position to the given component's local position, then return this given transform //
	public static Transform setLocalPositionTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalPositionTo(component.localPosition(), boolean);

	// method: (according to the given boolean:) set this given transform's local x position to the given x value, then return this given transform //
	public static Transform setLocalPositionXTo(this Transform transform, float x, bool boolean = true)
		=> transform.setLocalPositionTo(transform.localPosition.withX(x), boolean);
	// method: (according to the given boolean:) set this given transform's local x position to the other given transform's local x position, then return this given transform //
	public static Transform setLocalPositionXTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalPositionXTo(otherTransform.localPositionX(), boolean);
	// method: (according to the given boolean:) set this given transform's local x position to the given game object's local x position, then return this given transform //
	public static Transform setLocalPositionXTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalPositionXTo(gameObject.localPositionX(), boolean);
	// method: (according to the given boolean:) set this given transform's local x position to the given component's local x position, then return this given transform //
	public static Transform setLocalPositionXTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalPositionXTo(component.localPositionX(), boolean);

	// method: (according to the given boolean:) set this given transform's local y position to the given y value, then return this given transform //
	public static Transform setLocalPositionYTo(this Transform transform, float y, bool boolean = true)
		=> transform.setLocalPositionTo(transform.localPosition.withY(y), boolean);
	// method: (according to the given boolean:) set this given transform's local y position to the other given transform's local y position, then return this given transform //
	public static Transform setLocalPositionYTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalPositionYTo(otherTransform.localPositionY(), boolean);
	// method: (according to the given boolean:) set this given transform's local y position to the given game object's local y position, then return this given transform //
	public static Transform setLocalPositionYTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalPositionYTo(gameObject.localPositionY(), boolean);
	// method: (according to the given boolean:) set this given transform's local y position to the given component's local y position, then return this given transform //
	public static Transform setLocalPositionYTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalPositionYTo(component.localPositionY(), boolean);

	// method: (according to the given boolean:) set this given transform's local z position to the given z value, then return this given transform //
	public static Transform setLocalPositionZTo(this Transform transform, float z, bool boolean = true)
		=> transform.setLocalPositionTo(transform.localPosition.withZ(z), boolean);
	// method: (according to the given boolean:) set this given transform's local z position to the other given transform's local z position, then return this given transform //
	public static Transform setLocalPositionZTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalPositionZTo(otherTransform.localPositionZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local z position to the given game object's local z position, then return this given transform //
	public static Transform setLocalPositionZTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalPositionZTo(gameObject.localPositionZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local z position to the given component's local z position, then return this given transform //
	public static Transform setLocalPositionZTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalPositionZTo(component.localPositionZ(), boolean);

	// method: (according to the given boolean:) set this given transform's local rotation to the given local rotation, then return this given transform //
	public static Transform setLocalRotationTo(this Transform transform, Quaternion localRotation, bool boolean = true)
	{
		if (boolean)
		{
			transform.localRotation = localRotation;
		}

		return transform;
	}
	// method: (according to the given boolean:) set this given transform's local rotation to the other given transform's local rotation, then return this given transform //
	public static Transform setLocalRotationTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalRotationTo(otherTransform.localRotation, boolean);
	// method: (according to the given boolean:) set this given transform's local rotation to the given game object's local rotation, then return this given transform //
	public static Transform setLocalRotationTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalRotationTo(gameObject.localRotation(), boolean);
	// method: (according to the given boolean:) set this given transform's local rotation to the given component's local rotation, then return this given transform //
	public static Transform setLocalRotationTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalRotationTo(component.localRotation(), boolean);

	// method: (according to the given boolean:) set this given transform's local euler angles to the given local euler angles, then return this given transform //
	public static Transform setLocalEulerAnglesTo(this Transform transform, Vector3 localEulerAngles, bool boolean = true)
	{
		if (boolean)
		{
			transform.localEulerAngles = localEulerAngles;
		}

		return transform;
	}

	// method: (according to the given boolean:) set this given transform's local euler angles to the local euler angles for the given x, y, and z values, then return this given transform //
	public static Transform setLocalEulerAnglesTo(this Transform transform, float x, float y, float z, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(new Vector3(x, y, z), boolean);
	// method: (according to the given boolean:) set this given transform's local euler angles to the other given transform's local euler angles, then return this given transform //
	public static Transform setLocalEulerAnglesTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(otherTransform.localEulerAngles, boolean);
	// method: (according to the given boolean:) set this given transform's local euler angles to the given game object's local euler angles, then return this given transform //
	public static Transform setLocalEulerAnglesTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(gameObject.localEulerAngles(), boolean);
	// method: (according to the given boolean:) set this given transform's local euler angles to the given component's local euler angles, then return this given transform //
	public static Transform setLocalEulerAnglesTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(component.localEulerAngles(), boolean);

	// method: (according to the given boolean:) set this given transform's local x euler angle to the given x value, then return this given transform //
	public static Transform setLocalEulerAngleXTo(this Transform transform, float x, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(transform.localEulerAngles.withX(x), boolean);
	// method: (according to the given boolean:) set this given transform's local x euler angle to the other given transform's local x euler angle, then return this given transform //
	public static Transform setLocalEulerAngleXTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAngleXTo(otherTransform.localEulerAngleX(), boolean);
	// method: (according to the given boolean:) set this given transform's local x euler angle to the given game object's local x euler angle, then return this given transform //
	public static Transform setLocalEulerAngleXTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalEulerAngleXTo(gameObject.localEulerAngleX(), boolean);
	// method: (according to the given boolean:) set this given transform's local x euler angle to the given component's local x euler angle, then return this given transform //
	public static Transform setLocalEulerAngleXTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalEulerAngleXTo(component.localEulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given transform's local y euler angle to the given y value, then return this given transform //
	public static Transform setLocalEulerAngleYTo(this Transform transform, float y, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(transform.localEulerAngles.withY(y), boolean);
	// method: (according to the given boolean:) set this given transform's local y euler angle to the other given transform's local y euler angle, then return this given transform //
	public static Transform setLocalEulerAngleYTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAngleYTo(otherTransform.localEulerAngleY(), boolean);
	// method: (according to the given boolean:) set this given transform's local y euler angle to the given game object's local y euler angle, then return this given transform //
	public static Transform setLocalEulerAngleYTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalEulerAngleYTo(gameObject.localEulerAngleY(), boolean);
	// method: (according to the given boolean:) set this given transform's local y euler angle to the given component's local y euler angle, then return this given transform //
	public static Transform setLocalEulerAngleYTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalEulerAngleYTo(component.localEulerAngleY(), boolean);


	// method: (according to the given boolean:) set this given transform's local z euler angle to the given z value, then return this given transform //
	public static Transform setLocalEulerAngleZTo(this Transform transform, float z, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(transform.localEulerAngles.withZ(z), boolean);
	// method: (according to the given boolean:) set this given transform's local z euler angle to the other given transform's local z euler angle, then return this given transform //
	public static Transform setLocalEulerAngleZTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAngleZTo(otherTransform.localEulerAngleZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local z euler angle to the given game object's local z euler angle, then return this given transform //
	public static Transform setLocalEulerAngleZTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalEulerAngleZTo(gameObject.localEulerAngleZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local z euler angle to the given component's local z euler angle, then return this given transform //
	public static Transform setLocalEulerAngleZTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalEulerAngleZTo(component.localEulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's local scale to the given local scale, then return this given transform //
	public static Transform setLocalScaleTo(this Transform transform, Vector3 localScale, bool boolean = true)
	{
		if (boolean)
		{
			transform.localScale = localScale.clampedToBeValidScale();
		}

		return transform;
	}
	// method: (according to the given boolean:) set this given transform's local scale to the local scale for the given x, y, and z values, then return this given transform //
	public static Transform setLocalScaleTo(this Transform transform, float x, float y, float z, bool boolean = true)
		=> transform.setLocalScaleTo(new Vector3(x, y, z), boolean);
	// method: (according to the given boolean:) set this given transform's local scale to the other given transform's local scale, then return this given transform //
	public static Transform setLocalScaleTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalScaleTo(otherTransform.localScale, boolean);
	// method: (according to the given boolean:) set this given transform's local scale to the given game object's local scale, then return this given transform //
	public static Transform setLocalScaleTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalScaleTo(gameObject.localScale(), boolean);
	// method: (according to the given boolean:) set this given transform's local scale to the given component's local scale, then return this given transform //
	public static Transform setLocalScaleTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalScaleTo(component.localScale(), boolean);

	// method: (according to the given boolean:) set this given transform's local x scale to the given x value, then return this given transform //
	public static Transform setLocalScaleXTo(this Transform transform, float x, bool boolean = true)
		=> transform.setLocalScaleTo(transform.localScale.withX(x), boolean);
	// method: (according to the given boolean:) set this given transform's local x scale to the other given transform's local x scale, then return this given transform //
	public static Transform setLocalScaleXTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalScaleXTo(otherTransform.localScaleX(), boolean);
	// method: (according to the given boolean:) set this given transform's local x scale to the given game object's local x scale, then return this given transform //
	public static Transform setLocalScaleXTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalScaleXTo(gameObject.localScaleX(), boolean);
	// method: (according to the given boolean:) set this given transform's local x scale to the given component's local x scale, then return this given transform //
	public static Transform setLocalScaleXTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalScaleXTo(component.localScaleX(), boolean);

	// method: (according to the given boolean:) set this given transform's local y scale to the given y value, then return this given transform //
	public static Transform setLocalScaleYTo(this Transform transform, float y, bool boolean = true)
		=> transform.setLocalScaleTo(transform.localScale.withY(y), boolean);
	// method: (according to the given boolean:) set this given transform's local y scale to the other given transform's local y scale, then return this given transform //
	public static Transform setLocalScaleYTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalScaleYTo(otherTransform.localScaleY(), boolean);
	// method: (according to the given boolean:) set this given transform's local y scale to the given game object's local y scale, then return this given transform //
	public static Transform setLocalScaleYTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalScaleYTo(gameObject.localScaleY(), boolean);
	// method: (according to the given boolean:) set this given transform's local y scale to the given component's local y scale, then return this given transform //
	public static Transform setLocalScaleYTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalScaleYTo(component.localScaleY(), boolean);

	// method: (according to the given boolean:) set this given transform's local z scale to the given z value, then return this given transform //
	public static Transform setLocalScaleZTo(this Transform transform, float z, bool boolean = true)
		=> transform.setLocalScaleTo(transform.localScale.withZ(z), boolean);
	// method: (according to the given boolean:) set this given transform's local z scale to the other given transform's local z scale, then return this given transform //
	public static Transform setLocalScaleZTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalScaleZTo(otherTransform.localScaleZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local z scale to the given game object's local z scale, then return this given transform //
	public static Transform setLocalScaleZTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalScaleZTo(gameObject.localScaleZ(), boolean);
	// method: (according to the given boolean:) set this given transform's local z scale to the given component's local z scale, then return this given transform //
	public static Transform setLocalScaleZTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalScaleZTo(component.localScaleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's local transformations (local position, local rotation, local scale) respectively to the given local position, local rotation, and local scale, then return this given transform //
	public static Transform setLocalsTo(this Transform transform, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> transform
			.setLocalPositionTo(localPosition, boolean)
			.setLocalRotationTo(localRotation, boolean)
			.setLocalScaleTo(localScale, boolean);
	// method: (according to the given boolean:) set this given transform's local transformations (local position, local euler angles, local scale) respectively to the given local position, local euler angles, and local scale, then return this given transform //
	public static Transform setLocalsTo(this Transform transform, Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> transform
			.setLocalPositionTo(localPosition, boolean)
			.setLocalEulerAnglesTo(localEulerAngles, boolean)
			.setLocalScaleTo(localScale, boolean);
	// method: (according to the given boolean:) set this given transform's local transformations (local position, local rotation, local scale) respectively to the other given transform's local position, local rotation, and local scale, then return this given transform //
	public static Transform setLocalsTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setLocalsTo(otherTransform.localPosition, otherTransform.localRotation, otherTransform.localScale, boolean);
	// method: (according to the given boolean:) set this given transform's local transformations (local position, local rotation, local scale) respectively to the given game object's local position, local rotation, and local scale, then return this given transform //
	public static Transform setLocalsTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalsTo(gameObject.localPosition(), gameObject.localRotation(), gameObject.localScale(), boolean);
	// method: (according to the given boolean:) set this given transform's local transformations (local position, local rotation, local scale) respectively to the given component's local position, local rotation, and local scale, then return this given transform //
	public static Transform setLocalsTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalsTo(component.localPosition(), component.localRotation(), component.localScale(), boolean);
	// method: (according to the given boolean:) set this given transform's (nonscale) local transformations (local position, local rotation) respectively to the given local position and local rotation //
	public static Transform setLocalsTo(this Transform transform, Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> transform.setLocalPositionTo(localPosition, boolean).setLocalRotationTo(localRotation, boolean);
	// method: (according to the given boolean:) set this given transform's (nonposition) local transformations (local rotation, local scale) respectively to the given local rotation and local scale //
	public static Transform setLocalsTo(this Transform transform, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> transform.setLocalRotationTo(localRotation, boolean).setLocalScaleTo(localScale, boolean);

	// method: (according to the given boolean:) set this given transform's local transformations to its parent's while temporarily childed to the other given transform, then return this given transform //
	public static Transform setLocalsParentlyForRelativeTo(this Transform transform, Transform otherTransform, bool boolean = true)
	{
		Transform extervalParent = transform.parent;
		return transform.actUponWithParentTemporarilySwappedTo(otherTransform, transform_ => transform_.setLocalsTo(extervalParent), boolean);
	}
	// method: (according to the given boolean:) set this given transform's local transformations to its parent's while temporarily childed to the given game object, then return this given transform //
	public static Transform setLocalsParentlyForRelativeTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setLocalsParentlyForRelativeTo(gameObject.transform, boolean);
	// method: (according to the given boolean:) set this given transform's local transformations to its parent's while temporarily childed to the given component, then return this given transform //
	public static Transform setLocalsParentlyForRelativeTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setLocalsParentlyForRelativeTo(component.transform, boolean);
	// method: (according to the given boolean:) set this given transform's local transformations to its parent's while temporarily childed to the transform of the specified singleton behaviour class, then return this given transform //
	public static Transform setLocalsParentlyForRelativeTo<SingletonBehaviourT>(this Transform transform, bool boolean = true) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> transform.setLocalsParentlyForRelativeTo(SingletonBehaviour<SingletonBehaviourT>.transform, boolean);

	// method: (according to the given boolean:) set this given transform's (global) position to the given (global) position, then return this given transform //
	public static Transform setPositionTo(this Transform transform, Vector3 position, bool boolean = true)
	{
		if (boolean)
		{
			transform.position = position;
		}

		return transform;
	}
	// method: (according to the given boolean:) set this given transform's (global) position to the (global) position for the given x, y, and z values, then return this given transform //
	public static Transform setPositionTo(this Transform transform, float x, float y, float z, bool boolean = true)
		=> transform.setPositionTo(new Vector3(x, y, z), boolean);
	// method: (according to the given boolean:) set this given transform's position to the other given transform's position, then return this given transform //
	public static Transform setPositionTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setPositionTo(otherTransform.position, boolean);
	// method: (according to the given boolean:) set this given transform's position to the given game object's position, then return this given transform //
	public static Transform setPositionTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setPositionTo(gameObject.position(), boolean);
	// method: (according to the given boolean:) set this given transform's position to the given component's position, then return this given transform //
	public static Transform setPositionTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setPositionTo(component.position(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) x position to the given x value, then return this given transform //
	public static Transform setPositionXTo(this Transform transform, float x, bool boolean = true)
		=> transform.setPositionTo(transform.position.withX(x), boolean);
	// method: (according to the given boolean:) set this given transform's (global) x position to the other given transform's (global) x position, then return this given transform //
	public static Transform setPositionXTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setPositionXTo(otherTransform.positionX(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) x position to the given game object's (global) x position, then return this given transform //
	public static Transform setPositionXTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setPositionXTo(gameObject.positionX(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) x position to the given component's (global) x position, then return this given transform //
	public static Transform setPositionXTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setPositionXTo(component.positionX(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) y position to the given y value, then return this given transform //
	public static Transform setPositionYTo(this Transform transform, float y, bool boolean = true)
		=> transform.setPositionTo(transform.position.withY(y), boolean);
	// method: (according to the given boolean:) set this given transform's (global) y position to the other given transform's (global) y position, then return this given transform //
	public static Transform setPositionYTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setPositionYTo(otherTransform.positionY(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) y position to the given game object's (global) y position, then return this given transform //
	public static Transform setPositionYTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setPositionYTo(gameObject.positionY(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) y position to the given component's (global) y position, then return this given transform //
	public static Transform setPositionYTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setPositionYTo(component.positionY(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) z position to the given z value, then return this given transform //
	public static Transform setPositionZTo(this Transform transform, float z, bool boolean = true)
		=> transform.setPositionTo(transform.position.withZ(z), boolean);
	// method: (according to the given boolean:) set this given transform's (global) z position to the other given transform's (global) z position, then return this given transform //
	public static Transform setPositionZTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setPositionZTo(otherTransform.positionZ(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) z position to the given game object's (global) z position, then return this given transform //
	public static Transform setPositionZTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setPositionZTo(gameObject.positionZ(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) z position to the given component's (global) z position, then return this given transform //
	public static Transform setPositionZTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setPositionZTo(component.positionZ(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) rotation to the given (global) rotation, then return this given transform //
	public static Transform setRotationTo(this Transform transform, Quaternion rotation, bool boolean = true)
	{
		if (boolean)
		{
			transform.rotation = rotation;
		}

		return transform;
	}
	// method: (according to the given boolean:) set this given transform's (global) rotation to the other given transform's (global) rotation, then return this given transform //
	public static Transform setRotationTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setRotationTo(otherTransform.rotation, boolean);
	// method: (according to the given boolean:) set this given transform's (global) rotation to the given game object's (global) rotation, then return this given transform //
	public static Transform setRotationTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setRotationTo(gameObject.rotation(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) rotation to the given component's (global) rotation, then return this given transform //
	public static Transform setRotationTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setRotationTo(component.rotation(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) euler angles to the given (global) euler angles, then return this given transform //
	public static Transform setEulerAnglesTo(this Transform transform, Vector3 eulerAngles, bool boolean = true)
	{
		if (boolean)
		{
			transform.eulerAngles = eulerAngles;
		}

		return transform;
	}
	// method: (according to the given boolean:) set this given transform's (global) euler angles to the (global) euler angles for the given x, y, and z values, then return this given transform //
	public static Transform setEulerAnglesTo(this Transform transform, float x, float y, float z, bool boolean = true)
		=> transform.setEulerAnglesTo(new Vector3(x, y, z), boolean);
	// method: (according to the given boolean:) set this given transform's (global) euler angles to the other given transform's (global) euler angles, then return this given transform //
	public static Transform setEulerAnglesTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setEulerAnglesTo(otherTransform.eulerAngles, boolean);
	// method: (according to the given boolean:) set this given transform's (global) euler angles to the given game object's (global) euler angles, then return this given transform //
	public static Transform setEulerAnglesTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setEulerAnglesTo(gameObject.eulerAngles(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) euler angles to the given component's (global) euler angles, then return this given transform //
	public static Transform setEulerAnglesTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setEulerAnglesTo(component.eulerAngles(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) x euler angle to the given x value, then return this given transform //
	public static Transform setEulerAngleXTo(this Transform transform, float x, bool boolean = true)
		=> transform.setEulerAnglesTo(transform.eulerAngles.withX(x), boolean);
	// method: (according to the given boolean:) set this given transform's (global) x euler angle to the other given transform's (global) x euler angle, then return this given transform //
	public static Transform setEulerAngleXTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setEulerAngleXTo(otherTransform.eulerAngleX(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) x euler angle to the given game object's (global) x euler angle, then return this given transform //
	public static Transform setEulerAngleXTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setEulerAngleXTo(gameObject.eulerAngleX(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) x euler angle to the given component's (global) x euler angles, then return this given transform //
	public static Transform setEulerAngleXTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setEulerAngleXTo(component.eulerAngleX(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) y euler angle to the given y value, then return this given transform //
	public static Transform setEulerAngleYTo(this Transform transform, float y, bool boolean = true)
		=> transform.setEulerAnglesTo(transform.eulerAngles.withY(y), boolean);
	// method: (according to the given boolean:) set this given transform's (global) y euler angle to the other given transform's (global) y euler angle, then return this given transform //
	public static Transform setEulerAngleYTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setEulerAngleYTo(otherTransform.eulerAngleY(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) y euler angle to the given game object's (global) y euler angle, then return this given transform //
	public static Transform setEulerAngleYTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setEulerAngleYTo(gameObject.eulerAngleY(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) y euler angle to the given component's (global) y euler angles, then return this given transform //
	public static Transform setEulerAngleYTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setEulerAngleYTo(component.eulerAngleY(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) z euler angle to the given z value, then return this given transform //
	public static Transform setEulerAngleZTo(this Transform transform, float z, bool boolean = true)
		=> transform.setEulerAnglesTo(transform.eulerAngles.withZ(z), boolean);
	// method: (according to the given boolean:) set this given transform's (global) z euler angle to the other given transform's (global) z euler angle, then return this given transform //
	public static Transform setEulerAngleZTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setEulerAngleZTo(otherTransform.eulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's (global) z euler angle to the given game object's (global) z euler angle, then return this given transform //
	public static Transform setEulerAngleZTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setEulerAngleZTo(gameObject.eulerAngleZ(), boolean);
	// method: (according to the given boolean:) set this given transform's (global) z euler angle to the given component's (global) z euler angles, then return this given transform //
	public static Transform setEulerAngleZTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setEulerAngleZTo(component.eulerAngleZ(), boolean);

	// method: (according to the given boolean:) set this given transform's global transformations (global position, global rotation) respectively to the given (global) position and (global) rotation //
	public static Transform setGlobalsTo(this Transform transform, Vector3 position, Quaternion rotation, bool boolean = true)
		=> transform
					.setPositionTo(position, boolean)
					.setRotationTo(rotation, boolean);
	// method: (according to the given boolean:) set this given transform's global transformations (global position, global rotation) respectively to the other given transform's (global) position and (global) rotation //
	public static Transform setGlobalsTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setGlobalsTo(otherTransform.position, otherTransform.rotation, boolean);
	// method: (according to the given boolean:) set this given transform's global transformations (global position, global rotation) respectively to the given game object's (global) position and (global) rotation //
	public static Transform setGlobalsTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setGlobalsTo(gameObject.position(), gameObject.rotation(), boolean);
	// method: (according to the given boolean:) set this given transform's global transformations (global position, global rotation) respectively to the given component's (global) position and (global) rotation //
	public static Transform setGlobalsTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setGlobalsTo(component.position(), component.rotation(), boolean);

	// method: (according to the given boolean:) set this given transform's global transformations (global position, global euler angles) respectively to the given (global) position and (global) euler angles //
	public static Transform setGlobalsTo(this Transform transform, Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> transform
					.setPositionTo(position, boolean)
					.setEulerAnglesTo(eulerAngles, boolean);

	// method: (according to the given boolean:) set this given transform's global transformations (global position, global rotation) and local scale respectively to the given (global) position and (global) rotation and local scale //
	public static Transform setGlobalsAndLocalScaleTo(this Transform transform, Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> transform
					.setGlobalsTo(position, rotation, boolean)
					.setLocalScaleTo(localScale, boolean);
	// method: (according to the given boolean:) set this given transform's global transformations (global position, global euler angles) and local scale respectively to the other given transform's (global) position and (global) euler angles and local scale //
	public static Transform setGlobalsAndLocalScaleTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.setGlobalsAndLocalScaleTo(otherTransform.position, otherTransform.rotation, otherTransform.localScale, boolean);
	// method: (according to the given boolean:) set this given transform's global transformations (global position, global euler angles) and local scale respectively to the given game object's (global) position and (global) euler angles and local scale //
	public static Transform setGlobalsAndLocalScaleTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setGlobalsAndLocalScaleTo(gameObject.position(), gameObject.rotation(), gameObject.localScale(), boolean);
	// method: (according to the given boolean:) set this given transform's global transformations (global position, global euler angles) and local scale respectively to the given component's (global) position and (global) euler angles and local scale //
	public static Transform setGlobalsAndLocalScaleTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setGlobalsAndLocalScaleTo(component.position(), component.rotation(), component.localScale(), boolean);
	// method: (according to the given boolean:) set this given transform's global transformations (global position, global euler angles) and local scale respectively to the given (global) position and (global) euler angles and local scale //
	public static Transform setGlobalsAndLocalScaleTo(this Transform transform, Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> transform
					.setGlobalsTo(position, eulerAngles, boolean)
					.setLocalScaleTo(localScale, boolean);
	#endregion setting transformations


	#region resetting transformations

	// method: (according to the given boolean:) reset this given transform's local position to zeroes, then return this given transform //
	public static Transform resetLocalPosition(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionTo(Vector3.zero, boolean);

	// method: (according to the given boolean:) reset this given transform's local x position to zero, then return this given transform //
	public static Transform resetLocalPositionX(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionXTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local y position to zero, then return this given transform //
	public static Transform resetLocalPositionY(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionYTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local z position to zero, then return this given transform //
	public static Transform resetLocalPositionZ(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionZTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local rotation to no rotation, then return this given transform //
	public static Transform resetLocalRotation(this Transform transform, bool boolean = true)
		=> transform.setLocalRotationTo(Quaternion.identity, boolean);

	// method: (according to the given boolean:) reset this given transform's local euler angles to zeroes, then return this given transform //
	public static Transform resetLocalEulerAngles(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(Vector3.zero, boolean);

	// method: (according to the given boolean:) reset this given transform's local x euler angle to zero, then return this given transform //
	public static Transform resetLocalEulerAngleX(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAngleXTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local y euler angle to zero, then return this given transform //
	public static Transform resetLocalEulerAngleY(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAngleYTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local z euler angle to zero, then return this given transform //
	public static Transform resetLocalEulerAngleZ(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAngleZTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local scale to ones, then return this given transform //
	public static Transform resetLocalScale(this Transform transform, bool boolean = true)
		=> transform.setLocalScaleTo(Vector3.one, boolean);

	// method: (according to the given boolean:) reset this given transform's local x scale to one, then return this given transform //
	public static Transform resetLocalScaleX(this Transform transform, bool boolean = true)
		=> transform.setLocalScaleXTo(1f, boolean);

	// method: (according to the given boolean:) reset this given transform's local y scale to one, then return this given transform //
	public static Transform resetLocalScaleY(this Transform transform, bool boolean = true)
		=> transform.setLocalScaleYTo(1f, boolean);

	// method: (according to the given boolean:) reset this given transform's local z scale to one, then return this given transform //
	public static Transform resetLocalScaleZ(this Transform transform, bool boolean = true)
		=> transform.setLocalScaleZTo(1f, boolean);

	// method: (according to the given boolean:) reset this given transform's local transformations (local position, local rotation, local scale) respectively to the zeroes, no rotation, and ones, then return this given transform //
	public static Transform resetLocals(this Transform transform, bool boolean = true)
		=> transform.setLocalsTo(Vector3.zero, Quaternion.identity, Vector3.one, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) position to zeroes, then return this given transform //
	public static Transform resetPosition(this Transform transform, bool boolean = true)
		=> transform.setPositionTo(Vector3.zero, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) x position to zero, then return this given transform //
	public static Transform resetPositionX(this Transform transform, bool boolean = true)
		=> transform.setPositionXTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) y position to zero, then return this given transform //
	public static Transform resetPositionY(this Transform transform, bool boolean = true)
		=> transform.setPositionYTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) z position to zero, then return this given transform //
	public static Transform resetPositionZ(this Transform transform, bool boolean = true)
		=> transform.setPositionZTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) rotation to no rotation, then return this given transform //
	public static Transform resetRotation(this Transform transform, bool boolean = true)
		=> transform.setRotationTo(Quaternion.identity, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) euler angles to zeroes, then return this given transform //
	public static Transform resetEulerAngles(this Transform transform, bool boolean = true)
		=> transform.setEulerAnglesTo(Vector3.zero, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) x euler angle to zero, then return this given transform //
	public static Transform resetEulerAngleX(this Transform transform, bool boolean = true)
		=> transform.setEulerAngleXTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) y euler angle to zero, then return this given transform //
	public static Transform resetEulerAngleY(this Transform transform, bool boolean = true)
		=> transform.setEulerAngleYTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) z euler angle to zero, then return this given transform //
	public static Transform resetEulerAngleZ(this Transform transform, bool boolean = true)
		=> transform.setEulerAngleZTo(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's global transformations (global position, global rotation) respectively to zeroes and no rotation //
	public static Transform resetGlobals(this Transform transform, bool boolean = true)
		=> transform.setGlobalsTo(Vector3.zero, Quaternion.identity, boolean);

	// method: (according to the given boolean:) reset this given transform's global transformations (global position, global rotation) and local scale respectively to zeroes, no rotation, and ones //
	public static Transform resetGlobalsAndLocalScale(this Transform transform, bool boolean = true)
		=> transform.setGlobalsAndLocalScaleTo(Vector3.zero, Quaternion.identity, Vector3.one, boolean);
	#endregion resetting transformations


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