using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Game Object Extensions: provides extension methods for handling game objects //
// #auto
public static class GameObjectExtensions
{
	// methods for: creating fresh game objects //

	// method: create a fresh game object with the given name, with the given parent, optionally transformed to match its parent's transformations //
	public static GameObject create(string name = "GameObject", Transform parent = null, bool matchParentPosition = true, bool matchParentRotation = true, bool matchParentScale = true)
		=> new GameObject(name).setParent(parent)
			.resetLocalPosition(matchParentPosition)
			.resetLocalRotation(matchParentRotation)
			.resetLocalScale(matchParentScale);

	// method: create a fresh game object with the given name, with the given parent, optionally transformed to match its parent's position and rotation, optionally transformed to match its parent's scale //
	public static GameObject create(string name = "GameObject", Transform parent = null, bool matchParentPositionAndRotation = true, bool matchParentScale = true)
		=> create(name, parent, matchParentPositionAndRotation, matchParentPositionAndRotation, matchParentScale);

	// method: create a fresh game object with the given name, with the given parent, optionally transformed to match (all of) its parent's transformations //
	public static GameObject create(string name = "GameObject", Transform parent = null, bool matchParentTransformations = true)
		=> create(name, parent, matchParentTransformations, matchParentTransformations);


	// methods for: creating templated game objects //

	// method: create an instance of this given object template (object instance or prefab), with the given name (using the template's name if empty (which is the default)), with the given parent, optionally transformed to match its parent's transformations //
	public static GameObject create(this GameObject template, string name = "", Transform parent = null, bool matchParentPosition = true, bool matchParentRotation = true, bool matchParentScale = true)
		=> UnityEngine.Object.Instantiate(template)
			.setName(name.replaceIfEmpty(template.name))
			.setParent(parent)
			.resetLocalPosition(matchParentPosition)
			.resetLocalRotation(matchParentRotation)
			.resetLocalScale(matchParentScale);

	// method: create an instance of this given object template (object instance or prefab), with the given name (using the template's name if empty (which is the default)), with the given parent, optionally transformed to match its parent's position and rotation, optionally transformed to match its parent's scale //
	public static GameObject create(this GameObject template, string name = "", Transform parent = null, bool matchParentPositionAndRotation = true, bool matchParentScale = true)
		=> create(template, name, parent, matchParentPositionAndRotation, matchParentPositionAndRotation, matchParentScale);

	// method: create an instance of this given object template (object instance or prefab), with the given name (using the template's name if empty (which is the default)), with the given parent, optionally transformed to match (all of) its parent's transformations //
	public static GameObject create(this GameObject template, string name = "", Transform parent = null, bool matchParentTransformations = true)
		=> create(template, name, parent, matchParentTransformations, matchParentTransformations);


	// methods for: destruction //

	// method: destroy this given game object //
	public static void destroy(this GameObject gameObject)
		=> UnityEngine.Object.Destroy(gameObject);


	// methods for: enablement //

	// method: set the enablement of this given game object to the given boolean, then return this given game object //
	public static GameObject setEnablementTo(this GameObject gameObject, bool boolean)
	{
		gameObject.SetActive(boolean);

		return gameObject;
	}

	// method: enable this given game object, then return it //
	public static GameObject enable(this GameObject gameObject)
		=> gameObject.setEnablementTo(true);

	// method: disable this given game object, then return it //
	public static GameObject disable(this GameObject gameObject)
		=> gameObject.setEnablementTo(false);

	// method: toggle the enablement of these given game objects using the given toggling, then return them //
	public static GameObject[] toggleEnablementBy(this GameObject[] gameObjects, Toggling toggling)
	{
		gameObjects.forEach(gameObject => gameObject.setEnablementTo(gameObject.activeSelf.toggledBy(toggling)));

		return gameObjects;
	}

	// method: set the enablement of these given game objects to the given boolean, then return them //
	public static GameObject[] setEnablementTo(this GameObject[] gameObjects, bool boolean)
	{
		gameObjects.forEach(gameObject => gameObject.setEnablementTo(boolean));

		return gameObjects;
	}
	
	// method: enable these given game objects, then return them //
	public static GameObject[] enable(this GameObject[] gameObjects)
		=> gameObjects.setEnablementTo(true);

	// method: disable these given game objects, then return them //
	public static GameObject[] disable(this GameObject[] gameObjects)
		=> gameObjects.setEnablementTo(false);


	// methods for: transform parent //

	// method: return this given game object's parent //
	public static Transform parent(this GameObject gameObject)
		=> gameObject.transform.parent;

	// method: return this given game object's parent object //
	public static GameObject parentObject(this GameObject gameObject)
		=> gameObject.parent().gameObject;

	// method: (according to the given boolean:) set this given game object's parent to the given parent transform, then return this given game object //
	public static GameObject setParent(this GameObject gameObject, Transform parent, bool boolean = true)
		=> gameObject.transform.setParent(parent, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's parent to the transform of the given game object, then return this given game object //
	public static GameObject setParent(this GameObject gameObject, GameObject parentObject, bool boolean = true)
		=> gameObject.setParent(parentObject.transform, boolean);

	// method: (according to the given boolean:) set this given game object's parent to the transform of the given component, then return this given game object //
	public static GameObject setParent(this GameObject gameObject, Component parentComponent, bool boolean = true)
		=> gameObject.setParent(parentComponent.transform, boolean);

	// method: (according to the given boolean:) unparent this given game object (set its parent to null), then return this given game object //
	public static GameObject unparent(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.unparent(boolean).gameObject;


	// methods for: children iteration //

	// method: invoke the given action on each child transform of this given game object, then return this given game object //
	public static GameObject forEachChildTransform(this GameObject gameObject, Action<Transform> action)
		=> gameObject.transform.forEachChildTransform(action).gameObject;

	// method: set the enablement of all child objects of this given game object to the given boolean, then return this given game object //
	public static GameObject setEnablementOfChildrenTo(this GameObject gameObject, bool boolean)
		=> gameObject.transform.setEnablementOfChildrenTo(boolean).gameObject;

	// method: destroy all of the children of this given game object, then return this given game object //
	public static GameObject destroyChildren(this GameObject gameObject)
		=> gameObject.transform.destroyChildren().gameObject;


	// methods for: getting transformations //

	// method: return this given game object's local position //
	public static Vector3 localPosition(this GameObject gameObject)
		=> gameObject.transform.localPosition;

	// method: return this given game object's local x position //
	public static float localPositionX(this GameObject gameObject)
		=> gameObject.transform.localPositionX();

	// method: return this given game object's local y position //
	public static float localPositionY(this GameObject gameObject)
		=> gameObject.transform.localPositionY();

	// method: return this given game object's local z position //
	public static float localPositionZ(this GameObject gameObject)
		=> gameObject.transform.localPositionZ();

	// method: return this given game object's local rotation //
	public static Quaternion localRotation(this GameObject gameObject)
		=> gameObject.transform.localRotation;

	// method: return this given game object's local euler angles //
	public static Vector3 localEulerAngles(this GameObject gameObject)
		=> gameObject.transform.localEulerAngles;

	// method: return this given game object's local x euler angle //
	public static float localEulerAngleX(this GameObject gameObject)
		=> gameObject.transform.localEulerAngleX();

	// method: return this given game object's local y euler angle //
	public static float localEulerAngleY(this GameObject gameObject)
		=> gameObject.transform.localEulerAngleY();

	// method: return this given game object's local z euler angle //
	public static float localEulerAngleZ(this GameObject gameObject)
		=> gameObject.transform.localEulerAngleZ();

	// method: return this given game object's local scale //
	public static Vector3 localScale(this GameObject gameObject)
		=> gameObject.transform.localScale;

	// method: return this given game object's local x scale //
	public static float localScaleX(this GameObject gameObject)
		=> gameObject.transform.localScaleX();

	// method: return this given game object's local y scale //
	public static float localScaleY(this GameObject gameObject)
		=> gameObject.transform.localScaleY();

	// method: return this given game object's local z scale //
	public static float localScaleZ(this GameObject gameObject)
		=> gameObject.transform.localScaleZ();

	// method: return this given game object's (global) position //
	public static Vector3 position(this GameObject gameObject)
		=> gameObject.transform.position;

	// method: return this given game object's (global) x position //
	public static float positionX(this GameObject gameObject)
		=> gameObject.transform.positionX();

	// method: return this given game object's (global) y position //
	public static float positionY(this GameObject gameObject)
		=> gameObject.transform.positionY();

	// method: return this given game object's (global) z position //
	public static float positionZ(this GameObject gameObject)
		=> gameObject.transform.positionZ();

	// method: return this given game object's (global) rotation //
	public static Quaternion rotation(this GameObject gameObject)
		=> gameObject.transform.rotation;

	// method: return this given game object's (global) euler angles //
	public static Vector3 eulerAngles(this GameObject gameObject)
		=> gameObject.transform.eulerAngles;

	// method: return this given game object's (global) x euler angle //
	public static float eulerAngleX(this GameObject gameObject)
		=> gameObject.transform.eulerAngleX();

	// method: return this given game object's (global) y euler angle //
	public static float eulerAngleY(this GameObject gameObject)
		=> gameObject.transform.eulerAngleY();

	// method: return this given game object's (global) z euler angle //
	public static float eulerAngleZ(this GameObject gameObject)
		=> gameObject.transform.eulerAngleZ();


	// methods for: setting transformations //

	// method: (according to the given boolean:) set this given game object's local position to the given local position, then return this given game object //
	public static GameObject setLocalPosition(this GameObject gameObject, Vector3 localPosition, bool boolean = true)
		=> gameObject.transform.setLocalPosition(localPosition, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local position to the local position for the given x, y, and z values, then return this given game object //
	public static GameObject setLocalPosition(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.setLocalPosition(new Vector3(x, y, z), boolean);

	// method: (according to the given boolean:) set this given game object's local x position to the given x value, then return this given game object //
	public static GameObject setLocalPositionX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setLocalPositionX(x, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local y position to the given y value, then return this given game object //
	public static GameObject setLocalPositionY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setLocalPositionY(y, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local z position to the given z value, then return this given game object //
	public static GameObject setLocalPositionZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setLocalPositionZ(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local rotation to the given local rotation, then return this given game object //
	public static GameObject setLocalRotation(this GameObject gameObject, Quaternion localRotation, bool boolean = true)
		=> gameObject.transform.setLocalRotation(localRotation, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local euler angles to the given local euler angles, then return this given game object //
	public static GameObject setLocalEulerAngles(this GameObject gameObject, Vector3 localEulerAngles, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngles(localEulerAngles, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local euler angles to the local euler angles for the given x, y, and z values, then return this given game object //
	public static GameObject setLocalEulerAngles(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngles(x, y, z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local x euler angle to the given x value, then return this given game object //
	public static GameObject setLocalEulerAngleX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngleX(x, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local y euler angle to the given y value, then return this given game object //
	public static GameObject setLocalEulerAngleY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngleY(y, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local z euler angle to the given z value, then return this given game object //
	public static GameObject setLocalEulerAngleZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setLocalEulerAngleZ(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local scale to the given local scale, then return this given game object //
	public static GameObject setLocalScale(this GameObject gameObject, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocalScale(localScale, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local scale to the local scale for the given x, y, and z values, then return this given game object //
	public static GameObject setLocalScale(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.setLocalScale(new Vector3(x, y, z), boolean);

	// method: (according to the given boolean:) set this given game object's local x scale to the given x value, then return this given game object //
	public static GameObject setLocalScaleX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setLocalScaleX(x, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local y scale to the given y value, then return this given game object //
	public static GameObject setLocalScaleY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setLocalScaleY(y, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local z scale to the given z value, then return this given game object //
	public static GameObject setLocalScaleZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setLocalScaleZ(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local transformations (local position, local rotation, local scale) respectively to the given local position, local rotation, and local scale, then return this given game object //
	public static GameObject setLocals(this GameObject gameObject, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocals(localPosition, localRotation, localScale, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's local transformations (local position, local euler angles, local scale) respectively to the given local position, local euler angles, and local scale, then return this given game object //
	public static GameObject setLocals(this GameObject gameObject, Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocals(localPosition, localEulerAngles, localScale, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (nonscale) local transformations (local position, local rotation) respectively to the given local position and local rotation //
	public static GameObject setLocals(this GameObject gameObject, Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> gameObject.transform.setLocals(localPosition, localRotation, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (nonposition) local transformations (local rotation, local scale) respectively to the given local rotation and local scale //
	public static GameObject setLocals(this GameObject gameObject, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setLocals(localRotation, localScale, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) position to the given (global) position, then return this given game object //
	public static GameObject setPosition(this GameObject gameObject, Vector3 position, bool boolean = true)
		=> gameObject.transform.setPosition(position, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) position to the (global) position for the given x, y, and z values, then return this given game object //
	public static GameObject setPosition(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.setPosition(new Vector3(x, y, z), boolean);

	// method: (according to the given boolean:) set this given game object's (global) x position to the given x value, then return this given game object //
	public static GameObject setPositionX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setPositionX(x, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) y position to the given y value, then return this given game object //
	public static GameObject setPositionY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setPositionY(y, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) z position to the given z value, then return this given game object //
	public static GameObject setPositionZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setPositionZ(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) rotation to the given (global) rotation, then return this given game object //
	public static GameObject setRotation(this GameObject gameObject, Quaternion rotation, bool boolean = true)
		=> gameObject.transform.setRotation(rotation, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) euler angles to the given (global) euler angles, then return this given game object //
	public static GameObject setEulerAngles(this GameObject gameObject, Vector3 eulerAngles, bool boolean = true)
		=> gameObject.transform.setEulerAngles(eulerAngles, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) euler angles to the (global) euler angles for the given x, y, and z values, then return this given game object //
	public static GameObject setEulerAngles(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.transform.setEulerAngles(x, y, z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) x euler angle to the given x value, then return this given game object //
	public static GameObject setEulerAngleX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.setEulerAngleX(x, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) y euler angle to the given y value, then return this given game object //
	public static GameObject setEulerAngleY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.setEulerAngleY(y, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's (global) z euler angle to the given z value, then return this given game object //
	public static GameObject setEulerAngleZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.setEulerAngleZ(z, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) respectively to the given (global) position and (global) rotation //
	public static GameObject setGlobals(this GameObject gameObject, Vector3 position, Quaternion rotation, bool boolean = true)
		=> gameObject.transform.setGlobals(position, rotation, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global euler angles) respectively to the given (global) position and (global) euler angles //
	public static GameObject setGlobals(this GameObject gameObject, Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> gameObject.transform.setGlobals(position, eulerAngles, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global rotation) and local scale respectively to the given (global) position and (global) rotation and local scale //
	public static GameObject setGlobalsAndLocalScale(this GameObject gameObject, Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setGlobalsAndLocalScale(position, rotation, localScale, boolean).gameObject;

	// method: (according to the given boolean:) set this given game object's global transformations (global position, global euler angles) and local scale respectively to the given (global) position and (global) euler angles and local scale //
	public static GameObject setGlobalsAndLocalScale(this GameObject gameObject, Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> gameObject.transform.setGlobalsAndLocalScale(position, eulerAngles, localScale, boolean).gameObject;


	// methods for: resetting transformations //

	// method: (according to the given boolean:) reset this given game object's local position to zeroes, then return this given game object //
	public static GameObject resetLocalPosition(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPosition(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local x position to zero, then return this given game object //
	public static GameObject resetLocalPositionX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPositionX(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local y position to zero, then return this given game object //
	public static GameObject resetLocalPositionY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPositionY(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local z position to zero, then return this given game object //
	public static GameObject resetLocalPositionZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalPositionZ(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local rotation to no rotation, then return this given game object //
	public static GameObject resetLocalRotation(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalRotation(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local euler angles to zeroes, then return this given game object //
	public static GameObject resetLocalEulerAngles(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngles(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local x euler angle to zero, then return this given game object //
	public static GameObject resetLocalEulerAngleX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngleX(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local y euler angle to zero, then return this given game object //
	public static GameObject resetLocalEulerAngleY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngleY(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local z euler angle to zero, then return this given game object //
	public static GameObject resetLocalEulerAngleZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalEulerAngleZ(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local scale to ones, then return this given game object //
	public static GameObject resetLocalScale(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScale(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local x scale to one, then return this given game object //
	public static GameObject resetLocalScaleX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScaleX(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local y scale to one, then return this given game object //
	public static GameObject resetLocalScaleY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScaleY(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local z scale to one, then return this given game object //
	public static GameObject resetLocalScaleZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocalScaleZ(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's local transformations (local position, local rotation, local scale) respectively to the zeroes, no rotation, and ones, then return this given game object //
	public static GameObject resetLocals(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetLocals(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) position to zeroes, then return this given game object //
	public static GameObject resetPosition(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPosition(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) x position to zero, then return this given game object //
	public static GameObject resetPositionX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPositionX(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) y position to zero, then return this given game object //
	public static GameObject resetPositionY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPositionY(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) z position to zero, then return this given game object //
	public static GameObject resetPositionZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetPositionZ(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) rotation to no rotation, then return this given game object //
	public static GameObject resetRotation(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetRotation(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) euler angles to zeroes, then return this given game object //
	public static GameObject resetEulerAngles(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngles(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) x euler angles to zero, then return this given game object //
	public static GameObject resetEulerAngleX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngleX(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) y euler angles to zero, then return this given game object //
	public static GameObject resetEulerAngleY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngleY(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's (global) z euler angles to zero, then return this given game object //
	public static GameObject resetEulerAngleZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetEulerAngleZ(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's global transformations (global position, global rotation) respectively to zeroes and no rotation //
	public static GameObject resetGlobals(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetGlobals(boolean).gameObject;

	// method: (according to the given boolean:) reset this given game object's global transformations (global position, global rotation) and local scale respectively to zeroes, no rotation, and ones //
	public static GameObject resetGlobalsAndLocalScale(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.resetGlobalsAndLocalScale(boolean).gameObject;


	// methods for: advanced rotation //

	// method: (according to the given boolean:) have this given game object look at the given target position, then return this given game object //
	public static GameObject lookAt(this GameObject gameObject, Vector3 targetPosition, bool boolean = true)
		=> gameObject.transform.lookAt(targetPosition, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object look at the given target transform, then return this given game object //
	public static GameObject lookAt(this GameObject gameObject, Transform targetTransform, bool boolean = true)
		=> gameObject.lookAt(targetTransform, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object look at the given target transform, then return this given game object //
	public static GameObject lookAt(this GameObject gameObject, GameObject targetObject, bool boolean = true)
		=> gameObject.transform.lookAt(targetObject).gameObject;

	// method: (according to the given boolean:) have this given game object look at the main camera, then return this given game object //
	public static GameObject lookAtCamera(this GameObject gameObject, bool boolean = true)
		=> gameObject.lookAt(Camera.main.transform, boolean);

	// method: (according to the given boolean:) have this given game object rotate by the given (x, y, and z) rotation angles, then return this given game object //
	public static GameObject rotate(this GameObject gameObject, Vector3 rotationAngles, bool boolean = true)
		=> gameObject.transform.rotate(rotationAngles, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by the given x, y, and z rotation angles, then return this given game object //
	public static GameObject rotate(this GameObject gameObject, float x, float y, float z, bool boolean = true)
		=> gameObject.transform.rotate(x, y, z, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by the given x rotation angle, then return this given game object //
	public static GameObject rotateX(this GameObject gameObject, float x, bool boolean = true)
		=> gameObject.transform.rotateX(x, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by the given y rotation angle, then return this given game object //
	public static GameObject rotateY(this GameObject gameObject, float y, bool boolean = true)
		=> gameObject.transform.rotateY(y, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by the given z rotation angle, then return this given game object //
	public static GameObject rotateZ(this GameObject gameObject, float z, bool boolean = true)
		=> gameObject.transform.rotateZ(z, boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by 180° on the x axis, then return this given game object //
	public static GameObject flipX(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.flipX(boolean).gameObject;
	
	// method: (according to the given boolean:) have this given game object rotate by 180° on the y axis, then return this given game object //
	public static GameObject flipY(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.flipY(boolean).gameObject;

	// method: (according to the given boolean:) have this given game object rotate by 180° on the z axis, then return this given game object //
	public static GameObject flipZ(this GameObject gameObject, bool boolean = true)
		=> gameObject.transform.flipZ(boolean).gameObject;


	// methods for: distance //

	// method: return the closest (by position) of the given game objects to this given game object //
	public static GameObject closestOf(this GameObject gameObject, IEnumerable<GameObject> gameObjects)
		=> gameObjects.itemWithMin(otherGameObject => gameObject.position().distanceWith(otherGameObject.position()));

	// method: return the closest (by position) of the given transforms to this given game object //
	public static Transform closestOf(this GameObject gameObject, IEnumerable<Transform> transforms)
		=> transforms.itemWithMin(otherTransform => gameObject.position().distanceWith(otherTransform.position));

	// method: return the closest of the given positions to this given game object's position //
	public static Vector3 closestOf(this GameObject gameObject, IEnumerable<Vector3> positions)
		=> positions.itemWithMin(otherPosition => gameObject.position().distanceWith(otherPosition));

	// method: return the farthest (by position) of the given game objects to this given game object //
	public static GameObject farthestOf(this GameObject gameObject, IEnumerable<GameObject> gameObjects)
		=> gameObjects.itemWithMax(otherGameObject => gameObject.position().distanceWith(otherGameObject.position()));

	// method: return the farthest (by position) of the given transforms to this given game object //
	public static Transform farthestOf(this GameObject gameObject, IEnumerable<Transform> transforms)
		=> transforms.itemWithMax(otherTransform => gameObject.position().distanceWith(otherTransform.position));

	// method: return the farthest of the given positions to this given game object's position //
	public static Vector3 farthestOf(this GameObject gameObject, IEnumerable<Vector3> positions)
		=> positions.itemWithMax(otherPosition => gameObject.position().distanceWith(otherPosition));


	// methods for: conversions to transformations //

	// methods: return an array of local positions corresponding to this given array of game objects //
	public static Vector3[] asLocalPositions(this GameObject[] gameObjects)
		=> gameObjects.Select(gameObject => gameObject.localPosition()).ToArray();

	// methods: return an array of local scales corresponding to this given array of game objects //
	public static Vector3[] asLocalScales(this GameObject[] gameObjects)
		=> gameObjects.Select(gameObject => gameObject.localScale()).ToArray();

	// methods: return an array of (world) positions corresponding to this given array of game objects //
	public static Vector3[] asPositions(this GameObject[] gameObjects)
		=> gameObjects.Select(gameObject => gameObject.position()).ToArray();


	// methods for: printing //

	// method: have this given game object print the given string, prefixed with this given game object's name, then retun this given game object //
	public static GameObject printNamely(this GameObject gameObject, string string_)
	{
		(gameObject.name+": "+string_).print();

		return gameObject;
	}


	// methods for: child lights //

	public static float[] getChildLightsIntensities(this GameObject gameObject)
		=> gameObject.GetComponentsInChildren<Light>().intensities();
	
	public static GameObject setChildLightsIntensities(this GameObject gameObject, float[] targetIntensities)
	{
		gameObject.GetComponentsInChildren<Light>().setIntensitiesTo(targetIntensities);

		return gameObject;
	}

	public static GameObject setChildLightsIntensities(this GameObject gameObject, float targetIntensity)
		=> gameObject.setChildLightsIntensities(new float[] {targetIntensity});

	public static GameObject renderChildLightsBy(this GameObject gameObject, LightRenderMode lightRenderMode)
	{
		gameObject.GetComponentsInChildren<Light>().renderBy(lightRenderMode);

		return gameObject;
	}

	public static GameObject renderChildLightsByPixel(this GameObject gameObject)
		=> gameObject.renderChildLightsBy(LightRenderMode.ForcePixel);

	public static GameObject renderChildLightsByVertex(this GameObject gameObject)
		=> gameObject.renderChildLightsBy(LightRenderMode.ForceVertex);

	// methods for: child particles systems //

	public static GameObject togglePlayingChildParticlesSystems(this GameObject gameObject, bool boolean)
	{
		gameObject.GetComponentsInChildren<ParticleSystem>().togglePlaying(boolean);

		return gameObject;
	}

	public static GameObject playChildParticlesSystems(this GameObject gameObject, bool boolean)
	{
		gameObject.GetComponentsInChildren<ParticleSystem>().play(boolean);

		return gameObject;
	}

	public static GameObject stopChildParticlesSystems(this GameObject gameObject, bool boolean)
	{
		gameObject.GetComponentsInChildren<ParticleSystem>().stop(boolean);

		return gameObject;
	}
}