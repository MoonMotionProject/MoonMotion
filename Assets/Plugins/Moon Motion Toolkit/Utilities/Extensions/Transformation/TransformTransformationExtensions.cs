using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Transform Transformation Extensions: provides extension methods for handling transform transformations
// #auto #transform #transformations
public static class TransformTransformationExtensions
{
	// method: return a selection of local positions corresponding to these given transforms //
	public static IEnumerable<Vector3> selectLocalPositions(this IList<Transform> transforms)
		=> transforms.select(transform => transform.localPosition);
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
	// method: (according to the given boolean:) reset this given transform's local position to zeroes, then return this given transform //
	public static Transform resetLocalPosition(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionTo(Vector3.zero, boolean);



	// method: return this given transform's local x position //
	public static float localPositionX(this Transform transform)
		=> transform.localPosition.x;
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
	// method: (according to the given boolean:) reset this given transform's local x position to zero, then return this given transform //
	public static Transform resetLocalPositionX(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionXTo(0f, boolean);



	// method: return this given transform's local y position //
	public static float localPositionY(this Transform transform)
		=> transform.localPosition.y;
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
		=> transform.setLocalPositionYTo(component.localPositionY(), boolean);// method: (according to the given boolean:) reset this given transform's local y position to zero, then return this given transform //
	public static Transform resetLocalPositionY(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionYTo(0f, boolean);
	// method: (according to the given boolean:) negate this given transform's local y position, then return this given transform //
	public static Transform negateLocalPositionY(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionYTo(-transform.localPositionY(), boolean);



	// method: return this given transform's local z position //
	public static float localPositionZ(this Transform transform)
		=> transform.localPosition.z;
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
	// method: (according to the given boolean:) reset this given transform's local z position to zero, then return this given transform //
	public static Transform resetLocalPositionZ(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionZTo(0f, boolean);



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
	// method: (according to the given boolean:) reset this given transform's local rotation to no rotation, then return this given transform //
	public static Transform resetLocalRotation(this Transform transform, bool boolean = true)
		=> transform.setLocalRotationTo(Quaternion.identity, boolean);



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
	// method: (according to the given boolean:) reset this given transform's local euler angles to zeroes, then return this given transform //
	public static Transform resetLocalEulerAngles(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(Vector3.zero, boolean);



	// method: return this given transform's local x euler angle //
	public static float localEulerAngleX(this Transform transform)
		=> transform.localEulerAngles.x;
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
	// method: (according to the given boolean:) reset this given transform's local x euler angle to zero, then return this given transform //
	public static Transform resetLocalEulerAngleX(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAngleXTo(0f, boolean);



	// method: return this given transform's local y euler angle //
	public static float localEulerAngleY(this Transform transform)
		=> transform.localEulerAngles.y;
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
	// method: (according to the given boolean:) reset this given transform's local y euler angle to zero, then return this given transform //
	public static Transform resetLocalEulerAngleY(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAngleYTo(0f, boolean);



	// method: return this given transform's local z euler angle //
	public static float localEulerAngleZ(this Transform transform)
		=> transform.localEulerAngles.z;
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
	// method: (according to the given boolean:) reset this given transform's local z euler angle to zero, then return this given transform //
	public static Transform resetLocalEulerAngleZ(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAngleZTo(0f, boolean);



	// method: return a selection of local scales corresponding to these given transforms //
	public static IEnumerable<Vector3> selectLocalScales(this IList<Transform> transforms)
		=> transforms.select(transform => transform.localScale);
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
	// method: (according to the given boolean:) reset this given transform's local scale to ones, then return this given transform //
	public static Transform resetLocalScale(this Transform transform, bool boolean = true)
		=> transform.setLocalScaleTo(Vector3.one, boolean);



	// method: return this given transform's local x scale //
	public static float localScaleX(this Transform transform)
		=> transform.localScale.x;
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
	// method: (according to the given boolean:) reset this given transform's local x scale to one, then return this given transform //
	public static Transform resetLocalScaleX(this Transform transform, bool boolean = true)
		=> transform.setLocalScaleXTo(1f, boolean);



	// method: return this given transform's local y scale //
	public static float localScaleY(this Transform transform)
		=> transform.localScale.y;
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
	// method: (according to the given boolean:) reset this given transform's local y scale to one, then return this given transform //
	public static Transform resetLocalScaleY(this Transform transform, bool boolean = true)
		=> transform.setLocalScaleYTo(1f, boolean);


	
	// method: return this given transform's local z scale //
	public static float localScaleZ(this Transform transform)
		=> transform.localScale.z;
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
	// method: (according to the given boolean:) reset this given transform's local z scale to one, then return this given transform //
	public static Transform resetLocalScaleZ(this Transform transform, bool boolean = true)
		=> transform.setLocalScaleZTo(1f, boolean);



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
	// method: (according to the given boolean:) reset this given transform's local transformations (local position, local rotation, local scale) respectively to the zeroes, no rotation, and ones, then return this given transform //
	public static Transform resetLocals(this Transform transform, bool boolean = true)
		=> transform.setLocalsTo(Vector3.zero, Quaternion.identity, Vector3.one, boolean);



	// method: (according to the given boolean:) set this given transform's local transformations to its parent's while temporarily childed to the other given transform, then return this given transform //
	public static Transform setLocalsParentlyForRelativeTo(this Transform transform, Transform otherTransform, bool boolean = true)
	{
		Transform extervalParent = transform.parent;
		return transform.actUponWithParentTemporarilySwappedTo(otherTransform,
			transform_ => transform_.setLocalsTo(extervalParent),
		boolean);
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



	// method: return a selection of (global) positions corresponding to these given transforms //
	public static IEnumerable<Vector3> selectPositions(this IList<Transform> transforms)
		=> transforms.select(transform => transform.position);
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
	// method: (according to the given boolean:) set this given transform's position to the given raycast hit's position, then return this given transform //
	public static Transform setPositionTo(this Transform transform, RaycastHit raycastHit, bool boolean = true)
		=> transform.setPositionTo(raycastHit.position(), boolean);
	// method: (according to the given boolean:) reset this given transform's (global) position to zeroes, then return this given transform //
	public static Transform resetPosition(this Transform transform, bool boolean = true)
		=> transform.setPositionTo(Vector3.zero, boolean);
	// method: (according to the given boolean:) displace this given transform's (global) position by the given displacement, then return this given transform //
	public static Transform displacePositionBy(this Transform transform, Vector3 displacement, bool boolean = true)
		=> transform.setPositionTo(transform.position + displacement, boolean);



	// method: return this given transform's (global) x position //
	public static float positionX(this Transform transform)
		=> transform.position.x;
	// methods: (assumes this transform has a rigidbody attached:) (according to the given boolean:) move this given transform's (global) x position to the given x position provider (try to set, but respect collisions in the way), then return this given transform //
	public static Transform movePositionXTo(this Transform transform, float x, bool boolean = true)
		=> transform.correspondingRigidbody().movePositionXTo(x, boolean).transform;
	public static Transform movePositionXTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.movePositionXTo(otherTransform.position.x, boolean);
	public static Transform movePositionXTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.movePositionXTo(gameObject.position().x, boolean);
	public static Transform movePositionXTo(this Transform transform, Component component, bool boolean = true)
		=> transform.movePositionXTo(component.position().x, boolean);
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
	// method: (according to the given boolean:) reset this given transform's (global) x position to zero, then return this given transform //
	public static Transform resetPositionX(this Transform transform, bool boolean = true)
		=> transform.setPositionXTo(0f, boolean);



	// method: return this given transform's (global) y position //
	public static float positionY(this Transform transform)
		=> transform.position.y;
	// methods: (assumes this transform has a rigidbody attached:) (according to the given boolean:) move this given transform's (global) y position to the given y position provider (try to set, but respect collisions in the way), then return this given transform //
	public static Transform movePositionYTo(this Transform transform, float y, bool boolean = true)
		=> transform.correspondingRigidbody().movePositionYTo(y, boolean).transform;
	public static Transform movePositionYTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.movePositionYTo(otherTransform.position.y, boolean);
	public static Transform movePositionYTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.movePositionYTo(gameObject.position().y, boolean);
	public static Transform movePositionYTo(this Transform transform, Component component, bool boolean = true)
		=> transform.movePositionYTo(component.position().y, boolean);
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
	// method: (according to the given boolean:) reset this given transform's (global) y position to zero, then return this given transform //
	public static Transform resetPositionY(this Transform transform, bool boolean = true)
		=> transform.setPositionYTo(0f, boolean);
	// method: (according to the given boolean:) negate this given transform's (global) y position, then return this given transform //
	public static Transform negatePositionY(this Transform transform, bool boolean = true)
		=> transform.setPositionYTo(-transform.positionY(), boolean);



	// method: return this given transform's (global) z position //
	public static float positionZ(this Transform transform)
		=> transform.position.z;
	// methods: (assumes this transform has a rigidbody attached:) (according to the given boolean:) move this given transform's (global) z position to the given z position provider (try to set, but respect collisions in the way), then return this given transform //
	public static Transform movePositionZTo(this Transform transform, float z, bool boolean = true)
		=> transform.correspondingRigidbody().movePositionZTo(z, boolean).transform;
	public static Transform movePositionZTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=> transform.movePositionZTo(otherTransform.position.z, boolean);
	public static Transform movePositionZTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.movePositionZTo(gameObject.position().z, boolean);
	public static Transform movePositionZTo(this Transform transform, Component component, bool boolean = true)
		=> transform.movePositionZTo(component.position().z, boolean);
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
	// method: (according to the given boolean:) reset this given transform's (global) z position to zero, then return this given transform //
	public static Transform resetPositionZ(this Transform transform, bool boolean = true)
		=> transform.setPositionZTo(0f, boolean);



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
	// method: (according to the given boolean:) reset this given transform's (global) rotation to no rotation, then return this given transform //
	public static Transform resetRotation(this Transform transform, bool boolean = true)
		=> transform.setRotationTo(Quaternion.identity, boolean);



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
	// method: (according to the given boolean:) reset this given transform's (global) euler angles to zeroes, then return this given transform //
	public static Transform resetEulerAngles(this Transform transform, bool boolean = true)
		=> transform.setEulerAnglesTo(Vector3.zero, boolean);



	// method: return this given transform's x euler angle //
	public static float eulerAngleX(this Transform transform)
		=> transform.eulerAngles.x;
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
	// method: (according to the given boolean:) reset this given transform's (global) x euler angle to zero, then return this given transform //
	public static Transform resetEulerAngleX(this Transform transform, bool boolean = true)
		=> transform.setEulerAngleXTo(0f, boolean);



	// method: return this given transform's y euler angle //
	public static float eulerAngleY(this Transform transform)
		=> transform.eulerAngles.y;
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
	// method: (according to the given boolean:) reset this given transform's (global) y euler angle to zero, then return this given transform //
	public static Transform resetEulerAngleY(this Transform transform, bool boolean = true)
		=> transform.setEulerAngleYTo(0f, boolean);



	// method: return this given transform's z euler angle //
	public static float eulerAngleZ(this Transform transform)
		=> transform.eulerAngles.z;
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
	// method: (according to the given boolean:) reset this given transform's (global) z euler angle to zero, then return this given transform //
	public static Transform resetEulerAngleZ(this Transform transform, bool boolean = true)
		=> transform.setEulerAngleZTo(0f, boolean);



	// method: (according to the given boolean:) set this given transform's (global) scale to the other given transform's (global) scale, then return this given transform //
	public static Transform setScaleTo(this Transform transform, Transform otherTransform, bool boolean = true)
		=>	transform.actUponWithParentTemporarilySwappedTo(otherTransform,
				transform_ => transform_.resetLocalScale(),
			boolean);
	// method: (according to the given boolean:) set this given transform's (global) scale to the given game object's (global) scale, then return this given transform //
	public static Transform setScaleTo(this Transform transform, GameObject gameObject, bool boolean = true)
		=> transform.setScaleTo(gameObject.transform, boolean);
	// method: (according to the given boolean:) set this given transform's (global) scale to the given component's (global) scale, then return this given transform //
	public static Transform setScaleTo(this Transform transform, Component component, bool boolean = true)
		=> transform.setScaleTo(component.transform, boolean);



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
	// method: (according to the given boolean:) reset this given transform's global transformations (global position, global rotation) respectively to zeroes and no rotation //
	public static Transform resetGlobals(this Transform transform, bool boolean = true)
		=> transform.setGlobalsTo(Vector3.zero, Quaternion.identity, boolean);



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
	// method: (according to the given boolean:) reset this given transform's global transformations (global position, global rotation) and local scale respectively to zeroes, no rotation, and ones //
	public static Transform resetGlobalsAndLocalScale(this Transform transform, bool boolean = true)
		=> transform.setGlobalsAndLocalScaleTo(Vector3.zero, Quaternion.identity, Vector3.one, boolean);



	// method: (according to the given boolean:) set this given transform's (global) transformations respectively to the given (global) position and (global) rotation, and set this given transform's (global) scale to the (global) scale of the given provided other transform, then return this given transform //
	public static Transform setTransformationsTo(this Transform transform, Vector3 position, Quaternion rotation, object otherTransform_TransformProvider, bool boolean = true)
	{
		Transform otherTransform = Provide.transformVia(otherTransform_TransformProvider);

		return transform
				.setGlobalsTo(position, rotation, boolean)
				.setScaleTo(otherTransform, boolean);
	}
	// method: (according to the given boolean:) set this given transform's (global) transformations respectively to the given (global) position and (global) euler angles, and set this given transform's (global) scale to the (global) scale of the given provided other transform, then return this given transform //
	public static Transform setTransformationsTo(this Transform transform, Vector3 position, Vector3 eulerAngles, object otherTransform_TransformProvider, bool boolean = true)
	{
		Transform otherTransform = Provide.transformVia(otherTransform_TransformProvider);

		return transform
				.setGlobalsTo(position, eulerAngles, boolean)
				.setScaleTo(otherTransform, boolean);
	}
	// method: (according to the given boolean:) set this given transform's (global) transformations respectively to (global) transformations of the given provided other transform, then return this given transform //
	public static Transform setTransformationsTo(this Transform transform, object otherTransform_TransformProvider, bool boolean = true)
	{
		Transform otherTransform = Provide.transformVia(otherTransform_TransformProvider);

		return transform
				.setGlobalsTo(otherTransform, boolean)
				.setScaleTo(otherTransform, boolean);
	}
}