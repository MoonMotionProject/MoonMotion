using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Transform:
// #auto
// • provides this behaviour with methods and automatically-connected properties for its transform
public abstract class	AutomaticBehaviourLayerTransform<AutomaticBehaviourT> :
					AutomaticBehaviourLayerGameObject<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	// properties/methods //

	
	// properties/methods for: transform hierarchy //

	public new Transform transform
	{
		// the transform property is only worth caching (since that takes up memory) when accessed a lot, like every frame in Update, so that property only uses caching according to the respective attribute; see https://forum.unity.com/threads/cache-transform-really-needed.356875/ for discussion of this //
		get {return inheritorHasAttribute<CacheTransformAttribute>() ? cachedComponent<Transform>() : ((Component)(this)).transform;}
	}

	public Transform parent
	{
		get {return transform.parent;}
	}
	public Transform setParent(Transform parentTransform, bool boolean = true)
		=> transform.setParent(parentTransform, boolean);
	public Transform setParent(GameObject parentObject, bool boolean = true)
		=> transform.setParent(parentObject, boolean);
	public Transform setParent(Component parentComponent, bool boolean = true)
		=> transform.setParent(parentComponent, boolean);
	public Transform unparent(bool boolean = true)
		=> transform.unparent(boolean);


	// methods for: child iteration //
	
	public Transform forEachChildTransform(Action<Transform> action)
		=> transform.forEachChildTransform(action);

	public Transform setEnablementOfChildrenTo(bool boolean)
		=> transform.setEnablementOfChildrenTo(boolean);
	
	public Transform destroyChildren()
		=> transform.destroyChildren();


	// properties/methods for: value transformations //

	public Vector3 localPosition
	{
		get {return transform.localPosition;}
	}
	public Transform setLocalPosition(Vector3 localPosition, bool boolean = true)
		=> transform.setLocalPosition(localPosition, boolean);
	public Transform resetLocalPosition(bool boolean = true)
		=> transform.resetLocalPosition(boolean);


	public float localPositionX
	{
		get {return transform.localPosition.x;}
	}
	public Transform setLocalPositionX(float x, bool boolean = true)
		=> transform.setLocalPositionX(x, boolean);
	public Transform resetLocalPositionX(bool boolean = true)
		=> transform.resetLocalPositionX(boolean);

	public float localPositionY
	{
		get {return transform.localPosition.y;}
	}
	public Transform setLocalPositionY(float y, bool boolean = true)
		=> transform.setLocalPositionY(y, boolean);
	public Transform resetLocalPositionY(bool boolean = true)
		=> transform.resetLocalPositionY(boolean);

	public float localPositionZ
	{
		get {return transform.localPosition.z;}
	}
	public Transform setLocalPositionZ(float z, bool boolean = true)
		=> transform.setLocalPositionZ(z, boolean);
	public Transform resetLocalPositionZ(bool boolean = true)
		=> transform.resetLocalPositionZ(boolean);

	public Quaternion localRotation
	{
		get {return transform.localRotation;}
	}
	public Transform setLocalRotation(Quaternion localRotation, bool boolean = true)
		=> transform.setLocalRotation(localRotation, boolean);
	public Transform resetLocalRotation(bool boolean = true)
		=> transform.resetLocalRotation(boolean);

	public Vector3 localEulerAngles
	{
		get {return transform.localEulerAngles;}
	}
	public Transform setLocalEulerAngles(Vector3 localEulerAngles, bool boolean = true)
		=> transform.setLocalEulerAngles(localEulerAngles, boolean);
	public Transform resetLocalEulerAngles(bool boolean = true)
		=> transform.resetLocalEulerAngles(boolean);

	public float localEulerAngleX
	{
		get {return transform.localEulerAngleX();}
	}
	public Transform setLocalEulerAngleX(float localEulerAngleX, bool boolean = true)
		=> transform.setLocalEulerAngleX(localEulerAngleX, boolean);
	public Transform resetLocalEulerAngleX(bool boolean = true)
		=> transform.resetLocalEulerAngleX(boolean);

	public float localEulerAngleY
	{
		get {return transform.localEulerAngleY();}
	}
	public Transform setLocalEulerAngleY(float localEulerAngleY, bool boolean = true)
		=> transform.setLocalEulerAngleY(localEulerAngleY, boolean);
	public Transform resetLocalEulerAngleY(bool boolean = true)
		=> transform.resetLocalEulerAngleY(boolean);

	public float localEulerAngleZ
	{
		get {return transform.localEulerAngleZ();}
	}
	public Transform setLocalEulerAngleZ(float localEulerAngleZ, bool boolean = true)
		=> transform.setLocalEulerAngleZ(localEulerAngleZ, boolean);
	public Transform resetLocalEulerAngleZ(bool boolean = true)
		=> transform.resetLocalEulerAngleZ(boolean);

	public Vector3 localScale
	{
		get {return transform.localScale;}
	}
	public Transform setLocalScale(Vector3 localScale, bool boolean = true)
		=> transform.setLocalScale(localScale, boolean);
	public Transform resetLocalScale(bool boolean = true)
		=> transform.resetLocalScale(boolean);

	public float localScaleX
	{
		get {return transform.localScale.x;}
	}
	public Transform setLocalScaleX(float x, bool boolean = true)
		=> transform.setLocalScaleX(x, boolean);
	public Transform resetLocalScaleX(bool boolean = true)
		=> transform.resetLocalScaleX(boolean);

	public float localScaleY
	{
		get {return transform.localScale.y;}
	}
	public Transform setLocalScaleY(float y, bool boolean = true)
		=> transform.setLocalScaleY(y, boolean);
	public Transform resetLocalScaleY(bool boolean = true)
		=> transform.resetLocalScaleY(boolean);

	public float localScaleZ
	{
		get {return transform.localScale.z;}
	}
	public Transform setLocalScaleZ(float z, bool boolean = true)
		=> transform.setLocalScaleZ(z, boolean);
	public Transform resetLocalScaleZ(bool boolean = true)
		=> transform.resetLocalScaleZ(boolean);
	
	public Transform setLocals(Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> transform.setLocals(localPosition, localRotation, localScale, boolean);
	public Transform resetLocals(bool boolean = true)
		=> transform.resetLocals(boolean);

	public Transform setLocals(Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> transform.setLocals(localPosition, localEulerAngles, localScale, boolean);
	
	public Transform setLocals(Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> transform.setLocals(localPosition, localRotation, boolean);
	
	public Transform setLocals(Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> transform.setLocals(localRotation, localScale, boolean);

	public Vector3 position
	{
		get {return transform.position;}
	}
	public Transform setPosition(Vector3 position, bool boolean = true)
		=> transform.setPosition(position, boolean);
	public Transform resetPosition(bool boolean = true)
		=> transform.resetPosition(boolean);

	public float positionX
	{
		get {return transform.position.x;}
	}
	public Transform setPositionX(float x, bool boolean = true)
		=> transform.setPositionX(x, boolean);
	public Transform resetPositionX(bool boolean = true)
		=> transform.resetPositionX(boolean);

	public float positionY
	{
		get {return transform.position.y;}
	}
	public Transform setPositionY(float y, bool boolean = true)
		=> transform.setPositionY(y, boolean);
	public Transform resetPositionY(bool boolean = true)
		=> transform.resetPositionY(boolean);

	public float positionZ
	{
		get {return transform.position.z;}
	}
	public Transform setPositionZ(float z, bool boolean = true)
		=> transform.setPositionZ(z, boolean);
	public Transform resetPositionZ(bool boolean = true)
		=> transform.resetPositionZ(boolean);

	public Quaternion rotation
	{
		get {return transform.rotation;}
	}
	public Transform setRotation(Quaternion rotation, bool boolean = true)
		=> transform.setRotation(rotation, boolean);
	public Transform resetRotation(bool boolean = true)
		=> transform.resetRotation(boolean);

	public Vector3 eulerAngles
	{
		get {return transform.eulerAngles;}
	}
	public Transform setEulerAngles(Vector3 eulerAngles, bool boolean = true)
		=> transform.setEulerAngles(eulerAngles, boolean);
	public Transform resetEulerAngles(bool boolean = true)
		=> transform.resetEulerAngles(boolean);

	public float eulerAngleX
	{
		get {return transform.eulerAngleX();}
	}
	public Transform setEulerAngleX(float eulerAngleX, bool boolean = true)
		=> transform.setEulerAngleX(eulerAngleX, boolean);
	public Transform resetEulerAngleX(bool boolean = true)
		=> transform.resetEulerAngleX(boolean);

	public float eulerAngleY
	{
		get {return transform.eulerAngleY();}
	}
	public Transform setEulerAngleY(float eulerAngleY, bool boolean = true)
		=> transform.setEulerAngleY(eulerAngleY, boolean);
	public Transform resetEulerAngleY(bool boolean = true)
		=> transform.resetEulerAngleY(boolean);

	public float eulerAngleZ
	{
		get {return transform.eulerAngleZ();}
	}
	public Transform setEulerAngleZ(float eulerAngleZ, bool boolean = true)
		=> transform.setEulerAngleZ(eulerAngleZ, boolean);
	public Transform resetEulerAngleZ(bool boolean = true)
		=> transform.resetEulerAngleZ(boolean);
	
	public Transform setGlobals(Vector3 position, Quaternion rotation, bool boolean = true)
		=> transform.setGlobals(position, rotation, boolean);
	public Transform resetGlobals(bool boolean = true)
		=> transform.resetGlobals(boolean);

	public Transform setGlobals(Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> transform.setGlobals(position, eulerAngles, boolean);
	
	public Transform setGlobalsAndLocalScale(Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> transform.setGlobalsAndLocalScale(position, rotation, localScale, boolean);
	
	public Transform setGlobalsAndLocalScale(Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> transform.setGlobalsAndLocalScale(position, eulerAngles, localScale, boolean);


	// methods for: advanced rotation //

	// method: (according to the given boolean:) have this behaviour's transform look at the given target position, then return this behaviour's transform //
	public Transform lookAt(Vector3 targetPosition, bool boolean = true)
		=> transform.lookAt(targetPosition, boolean);

	// method: (according to the given boolean:) have this behaviour's transform look at the given target transform, then return this behaviour's transform //
	public Transform lookAt(Transform targetTransform, bool boolean = true)
		=> transform.lookAt(targetTransform, boolean);

	// method: (according to the given boolean:) have this behaviour's transform look at the given target transform, then return this behaviour's transform //
	public Transform lookAt(GameObject targetObject, bool boolean = true)
		=> transform.lookAt(targetObject.transform, boolean);

	// method: (according to the given boolean:) have this given transform look at the main camera, then return this given transform //
	public Transform lookAtCamera(bool boolean = true)
		=> transform.lookAtCamera(boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given (x, y, and z) rotation angles, then return this behaviour's transform //
	public Transform rotate(Vector3 rotationAngles, bool boolean = true)
		=> transform.rotate(rotationAngles, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x, y, and z rotation angles, then return this behaviour's transform //
	public Transform rotate(float x, float y, float z, bool boolean = true)
		=> transform.rotate(x, y, z, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x rotation angle, then return this behaviour's transform //
	public Transform rotateX(float x, bool boolean = true)
		=> transform.rotateZ(x, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given y rotation angle, then return this behaviour's transform //
	public Transform rotateY(float y, bool boolean = true)
		=> transform.rotateZ(y, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given z rotation angle, then return this behaviour's transform //
	public Transform rotateZ(float z, bool boolean = true)
		=> transform.rotateZ(z, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by 180° on the x axis, then return this behaviour's transform //
	public Transform flipX(bool boolean = true)
		=> transform.flipX(boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by 180° on the y axis, then return this behaviour's transform //
	public Transform flipY(bool boolean = true)
		=> transform.flipY(boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by 180° on the z axis, then return this behaviour's transform //
	public Transform flipZ(bool boolean = true)
		=> transform.flipZ(boolean);


	// methods for: distance //

	// method: return the closest (by position) of the given game objects to this behaviour's transform //
	public GameObject closestOf(IEnumerable<GameObject> gameObjects)
		=> transform.closestOf(gameObjects);

	// method: return the closest (by position) of the given transforms to this behaviour's transform //
	public Transform closestOf(IEnumerable<Transform> transforms)
		=> transform.closestOf(transforms);

	// method: return the closest of the given positions to this behaviour's transform's position //
	public Vector3 closestOf(IEnumerable<Vector3> positions)
		=> transform.closestOf(positions);

	// method: return the farthest (by position) of the given game objects to this behaviour's transform //
	public GameObject farthestOf(IEnumerable<GameObject> gameObjects)
		=> transform.farthestOf(gameObjects);

	// method: return the farthest (by position) of the given transforms to this behaviour's transform //
	public Transform farthestOf(IEnumerable<Transform> transforms)
		=> transform.farthestOf(transforms);

	// method: return the farthest of the given positions to this behaviour's transform's position //
	public Vector3 farthestOf(IEnumerable<Vector3> positions)
		=> transform.farthestOf(positions);
}