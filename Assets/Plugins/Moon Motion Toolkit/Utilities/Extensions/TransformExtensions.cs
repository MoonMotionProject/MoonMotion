using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Transform Extensions: provides extension methods for handling transforms //
// #auto
public static class TransformExtensions
{
	// methods for: enablement //

	// method: set the enablement of this given transform's game object to the given boolean, then return this given transform //
	public static Transform setEnablementTo(this Transform transform, bool boolean)
		=> transform.gameObject.setEnablementTo(boolean).transform;
	
	
	// methods for: destruction //
		
	// method: destroy the game object of this given transform //
	public static void destroy(this Transform transform)
		=> transform.gameObject.destroy();


	// methods for: transform parent //

	// method: return the parent object of this given transform //
	public static GameObject parentObject(this Transform transform)
		=> transform.parent.gameObject;

	// method: (according to the given boolean:) set this given transform's parent to the given parent transform, then return this given transform //
	public static Transform setParent(this Transform transform, Transform parent, bool boolean = true)
	{
		if (boolean)
		{
			transform.SetParent(parent);
		}

		return transform;
	}

	// method: (according to the given boolean:) set this given transform's parent to the transform of the given game object, then return this given transform //
	public static Transform setParent(this Transform transform, GameObject parentObject, bool boolean = true)
		=> transform.setParent(parentObject.transform, boolean);

	// method: (according to the given boolean:) set this given transform's parent to the transform of the given component, then return this given transform //
	public static Transform setParent(this Transform transform, Component parentComponent, bool boolean = true)
		=> transform.setParent(parentComponent.transform, boolean);

	// method: (according to the given boolean:) unparent this given transform (set its parent to null), then return this given transform //
	public static Transform unparent(this Transform transform, bool boolean = true)
		=> transform.setParent(((Transform) null), boolean);


	// methods for: children iteration //

	// method: invoke the given action on each child transform of this given transform, then return this given transform //
	public static Transform forEachChildTransform(this Transform transform, Action<Transform> action)
	{
		transform.asEnumerable().forEach(action);

		return transform;
	}
	
	// method: set the enablement of all child objects of this given transform to the given boolean, then return this given transform //
	public static Transform setEnablementOfChildrenTo(this Transform transform, bool boolean)
		=> transform.forEachChildTransform(childTransform => childTransform.gameObject.setEnablementTo(boolean));
	
	// method: destroy all of the children of this given transform, then return this given transform //
	public static Transform destroyChildren(this Transform transform)
	{
		for (int i = transform.childCount - 1; i >= 0; i--)
		{
			transform.GetChild(i).destroy();
		}

		return transform;
	}


	// methods for: getting transformations //

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

	// method: return this given transform's local x scale //
	public static float localScaleX(this Transform transform)
		=> transform.localScale.x;

	// method: return this given transform's local y scale //
	public static float localScaleY(this Transform transform)
		=> transform.localScale.y;

	// method: return this given transform's local z scale //
	public static float localScaleZ(this Transform transform)
		=> transform.localScale.z;

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


	// methods for: setting transformations //

	// method: (according to the given boolean:) set this given transform's local position to the given local position, then return this given transform //
	public static Transform setLocalPosition(this Transform transform, Vector3 localPosition, bool boolean = true)
	{
		if (boolean)
		{
			transform.localPosition = localPosition;
		}

		return transform;
	}

	// method: (according to the given boolean:) set this given transform's local position to the local position for the given x, y, and z values, then return this given transform //
	public static Transform setLocalPosition(this Transform transform, float x, float y, float z, bool boolean = true)
		=> transform.setLocalPosition(new Vector3(x, y, z), boolean);

	// method: (according to the given boolean:) set this given transform's local x position to the given x value, then return this given transform //
	public static Transform setLocalPositionX(this Transform transform, float x, bool boolean = true)
		=> transform.setLocalPosition(transform.localPosition.withX(x), boolean);

	// method: (according to the given boolean:) set this given transform's local y position to the given y value, then return this given transform //
	public static Transform setLocalPositionY(this Transform transform, float y, bool boolean = true)
		=> transform.setLocalPosition(transform.localPosition.withY(y), boolean);

	// method: (according to the given boolean:) set this given transform's local z position to the given z value, then return this given transform //
	public static Transform setLocalPositionZ(this Transform transform, float z, bool boolean = true)
		=> transform.setLocalPosition(transform.localPosition.withZ(z), boolean);

	// method: (according to the given boolean:) set this given transform's local rotation to the given local rotation, then return this given transform //
	public static Transform setLocalRotation(this Transform transform, Quaternion localRotation, bool boolean = true)
	{
		if (boolean)
		{
			transform.localRotation = localRotation;
		}

		return transform;
	}

	// method: (according to the given boolean:) set this given transform's local euler angles to the given local euler angles, then return this given transform //
	public static Transform setLocalEulerAngles(this Transform transform, Vector3 localEulerAngles, bool boolean = true)
	{
		if (boolean)
		{
			transform.localEulerAngles = localEulerAngles;
		}

		return transform;
	}

	// method: (according to the given boolean:) set this given transform's local euler angles to the local euler angles for the given x, y, and z values, then return this given transform //
	public static Transform setLocalEulerAngles(this Transform transform, float x, float y, float z, bool boolean = true)
		=> transform.setLocalEulerAngles(new Vector3(x, y, z), boolean);

	// method: (according to the given boolean:) set this given transform's local x euler angle to the given x value, then return this given transform //
	public static Transform setLocalEulerAngleX(this Transform transform, float x, bool boolean = true)
		=> transform.setLocalEulerAngles(transform.localEulerAngles.withX(x), boolean);

	// method: (according to the given boolean:) set this given transform's local y euler angle to the given y value, then return this given transform //
	public static Transform setLocalEulerAngleY(this Transform transform, float y, bool boolean = true)
		=> transform.setLocalEulerAngles(transform.localEulerAngles.withY(y), boolean);

	// method: (according to the given boolean:) set this given transform's local z euler angle to the given z value, then return this given transform //
	public static Transform setLocalEulerAngleZ(this Transform transform, float z, bool boolean = true)
		=> transform.setLocalEulerAngles(transform.localEulerAngles.withZ(z), boolean);

	// method: (according to the given boolean:) set this given transform's local scale to the given local scale, then return this given transform //
	public static Transform setLocalScale(this Transform transform, Vector3 localScale, bool boolean = true)
	{
		if (boolean)
		{
			transform.localScale = localScale.clampedToBeValidScale();
		}

		return transform;
	}

	// method: (according to the given boolean:) set this given transform's local scale to the local scale for the given x, y, and z values, then return this given transform //
	public static Transform setLocalScale(this Transform transform, float x, float y, float z, bool boolean = true)
		=> transform.setLocalScale(new Vector3(x, y, z), boolean);

	// method: (according to the given boolean:) set this given transform's local x scale to the given x value, then return this given transform //
	public static Transform setLocalScaleX(this Transform transform, float x, bool boolean = true)
		=> transform.setLocalScale(transform.localScale.withX(x), boolean);

	// method: (according to the given boolean:) set this given transform's local y scale to the given y value, then return this given transform //
	public static Transform setLocalScaleY(this Transform transform, float y, bool boolean = true)
		=> transform.setLocalScale(transform.localScale.withY(y), boolean);

	// method: (according to the given boolean:) set this given transform's local z scale to the given z value, then return this given transform //
	public static Transform setLocalScaleZ(this Transform transform, float z, bool boolean = true)
		=> transform.setLocalScale(transform.localScale.withZ(z), boolean);

	// method: (according to the given boolean:) set this given transform's local transformations (local position, local rotation, local scale) respectively to the given local position, local rotation, and local scale, then return this given transform //
	public static Transform setLocals(this Transform transform, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> transform
			.setLocalPosition(localPosition, boolean)
			.setLocalRotation(localRotation, boolean)
			.setLocalScale(localScale, boolean);

	// method: (according to the given boolean:) set this given transform's local transformations (local position, local euler angles, local scale) respectively to the given local position, local euler angles, and local scale, then return this given transform //
	public static Transform setLocals(this Transform transform, Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> transform
			.setLocalPosition(localPosition, boolean)
			.setLocalEulerAngles(localEulerAngles, boolean)
			.setLocalScale(localScale, boolean);

	// method: (according to the given boolean:) set this given transform's (nonscale) local transformations (local position, local rotation) respectively to the given local position and local rotation //
	public static Transform setLocals(this Transform transform, Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> transform.setLocalPosition(localPosition, boolean).setLocalRotation(localRotation, boolean);

	// method: (according to the given boolean:) set this given transform's (nonposition) local transformations (local rotation, local scale) respectively to the given local rotation and local scale //
	public static Transform setLocals(this Transform transform, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> transform.setLocalRotation(localRotation, boolean).setLocalScale(localScale, boolean);

	// method: (according to the given boolean:) set this given transform's (global) position to the given (global) position, then return this given transform //
	public static Transform setPosition(this Transform transform, Vector3 position, bool boolean = true)
	{
		if (boolean)
		{
			transform.position = position;
		}

		return transform;
	}

	// method: (according to the given boolean:) set this given transform's (global) position to the (global) position for the given x, y, and z values, then return this given transform //
	public static Transform setPosition(this Transform transform, float x, float y, float z, bool boolean = true)
		=> transform.setPosition(new Vector3(x, y, z), boolean);

	// method: (according to the given boolean:) set this given transform's (global) x position to the given x value, then return this given transform //
	public static Transform setPositionX(this Transform transform, float x, bool boolean = true)
		=> transform.setPosition(transform.position.withX(x), boolean);

	// method: (according to the given boolean:) set this given transform's (global) y position to the given y value, then return this given transform //
	public static Transform setPositionY(this Transform transform, float y, bool boolean = true)
		=> transform.setPosition(transform.position.withY(y), boolean);

	// method: (according to the given boolean:) set this given transform's (global) z position to the given z value, then return this given transform //
	public static Transform setPositionZ(this Transform transform, float z, bool boolean = true)
		=> transform.setPosition(transform.position.withZ(z), boolean);

	// method: (according to the given boolean:) set this given transform's (global) rotation to the given (global) rotation, then return this given transform //
	public static Transform setRotation(this Transform transform, Quaternion rotation, bool boolean = true)
	{
		if (boolean)
		{
			transform.rotation = rotation;
		}

		return transform;
	}

	// method: (according to the given boolean:) set this given transform's (global) euler angles to the given (global) euler angles, then return this given transform //
	public static Transform setEulerAngles(this Transform transform, Vector3 eulerAngles, bool boolean = true)
	{
		if (boolean)
		{
			transform.eulerAngles = eulerAngles;
		}

		return transform;
	}

	// method: (according to the given boolean:) set this given transform's (global) euler angles to the (global) euler angles for the given x, y, and z values, then return this given transform //
	public static Transform setEulerAngles(this Transform transform, float x, float y, float z, bool boolean = true)
		=> transform.setEulerAngles(new Vector3(x, y, z), boolean);

	// method: (according to the given boolean:) set this given transform's (global) x euler angle to the given x value, then return this given transform //
	public static Transform setEulerAngleX(this Transform transform, float x, bool boolean = true)
		=> transform.setEulerAngles(transform.eulerAngles.withX(x), boolean);

	// method: (according to the given boolean:) set this given transform's (global) y euler angle to the given y value, then return this given transform //
	public static Transform setEulerAngleY(this Transform transform, float y, bool boolean = true)
		=> transform.setEulerAngles(transform.eulerAngles.withY(y), boolean);

	// method: (according to the given boolean:) set this given transform's (global) z euler angle to the given z value, then return this given transform //
	public static Transform setEulerAngleZ(this Transform transform, float z, bool boolean = true)
		=> transform.setEulerAngles(transform.eulerAngles.withZ(z), boolean);

	// method: (according to the given boolean:) set this given transform's global transformations (global position, global rotation) respectively to the given (global) position and (global) rotation //
	public static Transform setGlobals(this Transform transform, Vector3 position, Quaternion rotation, bool boolean = true)
		=> transform
					.setPosition(position, boolean)
					.setRotation(rotation, boolean);

	// method: (according to the given boolean:) set this given transform's global transformations (global position, global euler angles) respectively to the given (global) position and (global) euler angles //
	public static Transform setGlobals(this Transform transform, Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> transform
					.setPosition(position, boolean)
					.setEulerAngles(eulerAngles, boolean);

	// method: (according to the given boolean:) set this given transform's global transformations (global position, global rotation) and local scale respectively to the given (global) position and (global) rotation and local scale //
	public static Transform setGlobalsAndLocalScale(this Transform transform, Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> transform
					.setGlobals(position, rotation, boolean)
					.setLocalScale(localScale, boolean);

	// method: (according to the given boolean:) set this given transform's global transformations (global position, global euler angles) and local scale respectively to the given (global) position and (global) euler angles and local scale //
	public static Transform setGlobalsAndLocalScale(this Transform transform, Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> transform
					.setGlobals(position, eulerAngles, boolean)
					.setLocalScale(localScale, boolean);


	// methods for: resetting transformations //

	// method: (according to the given boolean:) reset this given transform's local position to zeroes, then return this given transform //
	public static Transform resetLocalPosition(this Transform transform, bool boolean = true)
		=> transform.setLocalPosition(Vector3.zero, boolean);

	// method: (according to the given boolean:) reset this given transform's local x position to zero, then return this given transform //
	public static Transform resetLocalPositionX(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionX(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local y position to zero, then return this given transform //
	public static Transform resetLocalPositionY(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionY(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local z position to zero, then return this given transform //
	public static Transform resetLocalPositionZ(this Transform transform, bool boolean = true)
		=> transform.setLocalPositionZ(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local rotation to no rotation, then return this given transform //
	public static Transform resetLocalRotation(this Transform transform, bool boolean = true)
		=> transform.setLocalRotation(Quaternion.identity, boolean);

	// method: (according to the given boolean:) reset this given transform's local euler angles to zeroes, then return this given transform //
	public static Transform resetLocalEulerAngles(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAngles(Vector3.zero, boolean);

	// method: (according to the given boolean:) reset this given transform's local x euler angle to zero, then return this given transform //
	public static Transform resetLocalEulerAngleX(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAngleX(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local y euler angle to zero, then return this given transform //
	public static Transform resetLocalEulerAngleY(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAngleY(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local z euler angle to zero, then return this given transform //
	public static Transform resetLocalEulerAngleZ(this Transform transform, bool boolean = true)
		=> transform.setLocalEulerAngleZ(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's local scale to ones, then return this given transform //
	public static Transform resetLocalScale(this Transform transform, bool boolean = true)
		=> transform.setLocalScale(Vector3.one, boolean);

	// method: (according to the given boolean:) reset this given transform's local x scale to one, then return this given transform //
	public static Transform resetLocalScaleX(this Transform transform, bool boolean = true)
		=> transform.setLocalScaleX(1f, boolean);

	// method: (according to the given boolean:) reset this given transform's local y scale to one, then return this given transform //
	public static Transform resetLocalScaleY(this Transform transform, bool boolean = true)
		=> transform.setLocalScaleY(1f, boolean);

	// method: (according to the given boolean:) reset this given transform's local z scale to one, then return this given transform //
	public static Transform resetLocalScaleZ(this Transform transform, bool boolean = true)
		=> transform.setLocalScaleZ(1f, boolean);

	// method: (according to the given boolean:) reset this given transform's local transformations (local position, local rotation, local scale) respectively to the zeroes, no rotation, and ones, then return this given transform //
	public static Transform resetLocals(this Transform transform, bool boolean = true)
		=> transform.setLocals(Vector3.zero, Quaternion.identity, Vector3.one, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) position to zeroes, then return this given transform //
	public static Transform resetPosition(this Transform transform, bool boolean = true)
		=> transform.setPosition(Vector3.zero, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) x position to zero, then return this given transform //
	public static Transform resetPositionX(this Transform transform, bool boolean = true)
		=> transform.setPositionX(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) y position to zero, then return this given transform //
	public static Transform resetPositionY(this Transform transform, bool boolean = true)
		=> transform.setPositionY(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) z position to zero, then return this given transform //
	public static Transform resetPositionZ(this Transform transform, bool boolean = true)
		=> transform.setPositionZ(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) rotation to no rotation, then return this given transform //
	public static Transform resetRotation(this Transform transform, bool boolean = true)
		=> transform.setRotation(Quaternion.identity, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) euler angles to zeroes, then return this given transform //
	public static Transform resetEulerAngles(this Transform transform, bool boolean = true)
		=> transform.setEulerAngles(Vector3.zero, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) x euler angle to zero, then return this given transform //
	public static Transform resetEulerAngleX(this Transform transform, bool boolean = true)
		=> transform.setEulerAngleX(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) y euler angle to zero, then return this given transform //
	public static Transform resetEulerAngleY(this Transform transform, bool boolean = true)
		=> transform.setEulerAngleY(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's (global) z euler angle to zero, then return this given transform //
	public static Transform resetEulerAngleZ(this Transform transform, bool boolean = true)
		=> transform.setEulerAngleZ(0f, boolean);

	// method: (according to the given boolean:) reset this given transform's global transformations (global position, global rotation) respectively to zeroes and no rotation //
	public static Transform resetGlobals(this Transform transform, bool boolean = true)
		=> transform.setGlobals(Vector3.zero, Quaternion.identity, boolean);

	// method: (according to the given boolean:) reset this given transform's global transformations (global position, global rotation) and local scale respectively to zeroes, no rotation, and ones //
	public static Transform resetGlobalsAndLocalScale(this Transform transform, bool boolean = true)
		=> transform.setGlobalsAndLocalScale(Vector3.zero, Quaternion.identity, Vector3.one, boolean);


	// methods for: advanced rotation //

	// method: (according to the given boolean:) have this given transform look at the given target position, then return this given transform //
	public static Transform lookAt(this Transform transform, Vector3 targetPosition, bool boolean = true)
	{
		if (boolean)
		{
			transform.LookAt(targetPosition);
		}

		return transform;
	}

	// method: (according to the given boolean:) have this given transform look at the given target transform, then return this given transform //
	public static Transform lookAt(this Transform transform, Transform targetTransform, bool boolean = true)
		=> transform.lookAt(targetTransform.position, boolean);

	// method: (according to the given boolean:) have this given transform look at the given target transform, then return this given transform //
	public static Transform lookAt(this Transform transform, GameObject targetObject, bool boolean = true)
		=> targetObject.transform.lookAt(targetObject.position(), boolean);

	// method: (according to the given boolean:) have this given transform look at the main camera, then return this given transform //
	public static Transform lookAtCamera(this Transform transform, bool boolean = true)
		=> transform.lookAt(Camera.main.transform, boolean);

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


	// methods for: distance //

	// method: return the closest (by position) of the given game objects to this given transform //
	public static GameObject closestOf(this Transform transform, IEnumerable<GameObject> gameObjects)
		=> gameObjects.itemWithMin(otherGameObject => transform.position.distanceWith(otherGameObject.position()));

	// method: return the closest (by position) of the given transforms to this given transform //
	public static Transform closestOf(this Transform transform, IEnumerable<Transform> transforms)
		=> transforms.itemWithMin(otherTransform => transform.position.distanceWith(otherTransform.position));

	// method: return the closest of the given positions to this given transform's position //
	public static Vector3 closestOf(this Transform transform, IEnumerable<Vector3> positions)
		=> positions.itemWithMin(otherPosition => transform.position.distanceWith(otherPosition));

	// method: return the farthest (by position) of the given game objects to this given transform //
	public static GameObject farthestOf(this Transform transform, IEnumerable<GameObject> gameObjects)
		=> gameObjects.itemWithMax(otherGameObject => transform.position.distanceWith(otherGameObject.position()));

	// method: return the farthest (by position) of the given transforms to this given transform //
	public static Transform farthestOf(this Transform transform, IEnumerable<Transform> transforms)
		=> transforms.itemWithMax(otherTransform => transform.position.distanceWith(otherTransform.position));

	// method: return the farthest of the given positions to this given transform's position //
	public static Vector3 farthestOf(this Transform transform, IEnumerable<Vector3> positions)
		=> positions.itemWithMax(otherPosition => transform.position.distanceWith(otherPosition));


	// methods for: transformation averages //

	// method: determine the average of these given transforms' local positions //
	public static Vector3 averageLocalPosition(this Transform[] transforms)
		=> transforms.asLocalPositions().average();

	// method: determine the average of these given transforms' local scales //
	public static Vector3 averageLocalScale(this Transform[] transforms)
		=> transforms.asLocalScales().average();

	// method: determine the average of these given transforms' (global) positions //
	public static Vector3 averagePosition(this Transform[] transforms)
		=> transforms.asPositions().average();


	// methods for: conversion //

	// method: return the enumerable version of this given transform //
	public static IEnumerable<Transform> asEnumerable(this Transform transform)
		=> transform.Cast<Transform>();

	// methods: return an array of local positions corresponding to this given array of transforms //
	public static Vector3[] asLocalPositions(this Transform[] transforms)
		=> transforms.Select(transform => transform.localPosition).ToArray();

	// methods: return an array of local scales corresponding to this given array of transforms //
	public static Vector3[] asLocalScales(this Transform[] transforms)
		=> transforms.Select(transform => transform.localScale).ToArray();

	// methods: return an array of (world) positions corresponding to this given array of transforms //
	public static Vector3[] asPositions(this Transform[] transforms)
		=> transforms.Select(transform => transform.position).ToArray();
}