using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Transform:
// #auto #transform
// • provides this singleton behaviour with static access to its automatic behaviour's transform layer
public abstract class SingletonBehaviourLayerTransform<SingletonBehaviourT> :
					SingletonBehaviourLayerGameObject<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region sibling indexing

	public static new int siblingIndex => automaticBehaviour.siblingIndex;
	#endregion sibling indexing


	#region accessing siblings

	public static new IEnumerable<Transform> selectSiblingAndSelfTransforms => automaticBehaviour.selectSiblingAndSelfTransforms;
	public static new Transform[] siblingAndSelfTransforms => automaticBehaviour.siblingAndSelfTransforms;

	public static new IEnumerable<GameObject> selectSiblingAndSelfObjects => automaticBehaviour.selectSiblingAndSelfObjects;
	public static new GameObject[] siblingAndSelfObjects => automaticBehaviour.siblingAndSelfObjects;

	public static new IEnumerable<Transform> selectSiblingTransforms => automaticBehaviour.selectSiblingTransforms;
	public static new IEnumerable<Transform> siblingTransforms => automaticBehaviour.siblingTransforms;

	public static new IEnumerable<GameObject> selectSiblingObjects => automaticBehaviour.selectSiblingObjects;
	public static new IEnumerable<GameObject> siblingObjects => automaticBehaviour.siblingObjects;
	#endregion siblings


	#region descendants

	public static new bool isLocalToOrDescendantOf(Transform otherTransform)
		=> automaticBehaviour.isLocalToOrDescendantOf(otherTransform);

	public static new bool isLocalToOrDescendantOf(GameObject otherGameObject)
		=> automaticBehaviour.isLocalToOrDescendantOf(otherGameObject);

	public static new bool isLocalToOrDescendantOf(Component otherComponent)
		=> automaticBehaviour.isLocalToOrDescendantOf(otherComponent);

	public static new bool isLocalToOrDescendantOf<OtherSingletonBehaviourT>() where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> automaticBehaviour.isLocalToOrDescendantOf<OtherSingletonBehaviourT>();
	#endregion descendants


	#region parent

	public static new bool parentless => automaticBehaviour.parentless;
	public static new Transform parent => automaticBehaviour.parent;
	public static new Transform setParentTo(Transform parentTransform, bool boolean = true)
		=> automaticBehaviour.setParentTo(parentTransform, boolean);
	public static new Transform setParentTo(GameObject parentObject, bool boolean = true)
		=> automaticBehaviour.setParentTo(parentObject, boolean);
	public static new Transform setParentTo(Component parentComponent, bool boolean = true)
		=> automaticBehaviour.setParentTo(parentComponent, boolean);
	public static new Transform setParentTo<ParentSingletonBehaviourT>(bool boolean = true) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> automaticBehaviour.setParentTo<ParentSingletonBehaviourT>(boolean);
	public static new Transform unparent(bool boolean = true)
		=> automaticBehaviour.unparent(boolean);
	#endregion parent


	#region pibling indexing

	public static new int piblingIndex => automaticBehaviour.piblingIndex;
	#endregion pibling indexing


	#region accessing piblings

	public static new Transform piblingTransform(int piblingIndex)
		=> automaticBehaviour.piblingTransform(piblingIndex);

	public static new Transform correspondingPiblingTransform => automaticBehaviour.correspondingPiblingTransform;

	public static new GameObject piblingObject(int piblingIndex)
		=> automaticBehaviour.piblingObject(piblingIndex);

	public static new Transform firstPiblingTransform => automaticBehaviour.firstPiblingTransform;

	public static new GameObject firstPiblingObject => automaticBehaviour.firstPiblingObject;

	public static new Transform lastPiblingTransform => automaticBehaviour.lastPiblingTransform;

	public static new GameObject lastPiblingObject => automaticBehaviour.lastPiblingObject;

	public static new IEnumerable<Transform> selectPiblingTransforms => automaticBehaviour.selectPiblingTransforms;
	public static new Transform[] piblingTransforms => automaticBehaviour.piblingTransforms;

	public static new IEnumerable<GameObject> selectPiblingObjects => automaticBehaviour.selectPiblingObjects;
	public static new GameObject[] piblingObjects => automaticBehaviour.piblingObjects;
	#endregion accessing piblings


	#region counting children

	public static new bool childless => automaticBehaviour.childless;

	public static new bool anyChildren()
		=> automaticBehaviour.anyChildren();

	public static new bool pluralChildren => automaticBehaviour.pluralChildren;
	#endregion counting children


	#region accessing children

	public static new Transform childTransform(int childIndex)
		=> automaticBehaviour.childTransform(childIndex);

	public static new GameObject childObject(int childIndex)
		=> automaticBehaviour.childObject(childIndex);

	public static new Transform firstChildTransform => automaticBehaviour.firstChildTransform;

	public static new GameObject firstChildObject => automaticBehaviour.firstChildObject;

	public static new Transform lastChildTransform => automaticBehaviour.lastChildTransform;

	public static new GameObject lastChildObject => automaticBehaviour.lastChildObject;

	public static new IEnumerable<Transform> selectChildTransforms => automaticBehaviour.selectChildTransforms();
	public static new Transform[] childTransforms => automaticBehaviour.childTransforms;

	public static new IEnumerable<GameObject> selectChildObjects => automaticBehaviour.selectChildObjects();
	public static new GameObject[] childObjects => automaticBehaviour.childObjects;
	#endregion accessing children


	#region destroying children

	public static new AutomaticBehaviour<SingletonBehaviourT> destroyChild(int childIndex)
		=> automaticBehaviour.destroyChild(childIndex);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> destroyChildIfItExists(int childIndex)
		=> automaticBehaviour.destroyChildIfItExists(childIndex);

	public static new AutomaticBehaviour<SingletonBehaviourT> destroyFirstChild()
		=> automaticBehaviour.destroyFirstChild();

	public static new AutomaticBehaviour<SingletonBehaviourT> destroyFirstChildIfItExists()
		=> automaticBehaviour.destroyFirstChildIfItExists();

	public static new AutomaticBehaviour<SingletonBehaviourT> destroyLastChild()
		=> automaticBehaviour.destroyLastChild();

	public static new AutomaticBehaviour<SingletonBehaviourT> destroyLastChildIfItExists()
		=> automaticBehaviour.destroyLastChildIfItExists();

	public static new AutomaticBehaviour<SingletonBehaviourT> destroyLastChildIfItExists<ComponentT>() where ComponentT : Component
		=> automaticBehaviour.destroyLastChildIfItExists<ComponentT>();

	public static new AutomaticBehaviour<SingletonBehaviourT> destroyChildren()
		=> automaticBehaviour.destroyChildren();
	#endregion destroying children


	#region child iteration
	public static new AutomaticBehaviour<SingletonBehaviourT> forEachChildTransform(Action<Transform> action)
		=> automaticBehaviour.forEachChildTransform(action);
	public static new AutomaticBehaviour<SingletonBehaviourT> setActivityOfChildrenTo(bool boolean)
		=> automaticBehaviour.setActivityOfChildrenTo(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> activateChildren()
		=> automaticBehaviour.activateChildren();
	public static new AutomaticBehaviour<SingletonBehaviourT> deactivateChildren()
		=> automaticBehaviour.deactivateChildren();
	#endregion child iteration


	#region transformations

	public static new Vector3 localPosition => automaticBehaviour.localPosition;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionTo(Vector3 localPosition, bool boolean = true)
		=> automaticBehaviour.setLocalPositionTo(localPosition, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPositionTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalPosition(bool boolean = true)
		=> automaticBehaviour.resetLocalPosition(boolean);


	public static new float localPositionX => automaticBehaviour.localPosition.x;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionXTo(float x, bool boolean = true)
		=> automaticBehaviour.setLocalPositionXTo(x, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionXTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPositionXTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalPositionX(bool boolean = true)
		=> automaticBehaviour.resetLocalPositionX(boolean);

	public static new float localPositionY => automaticBehaviour.localPosition.y;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionYTo(float y, bool boolean = true)
		=> automaticBehaviour.setLocalPositionYTo(y, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionYTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPositionYTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalPositionY(bool boolean = true)
		=> automaticBehaviour.resetLocalPositionY(boolean);

	public static new float localPositionZ => automaticBehaviour.localPosition.z;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionZTo(float z, bool boolean = true)
		=> automaticBehaviour.setLocalPositionZTo(z, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalPositionZTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPositionZTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalPositionZ(bool boolean = true)
		=> automaticBehaviour.resetLocalPositionZ(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> negateLocalPositionY(bool boolean = true)
		=> automaticBehaviour.negateLocalPositionY(boolean);

	public static new Quaternion localRotation => automaticBehaviour.localRotation;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalRotationTo(Quaternion localRotation, bool boolean = true)
		=> automaticBehaviour.setLocalRotationTo(localRotation, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalRotationTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalRotationTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalRotation(bool boolean = true)
		=> automaticBehaviour.resetLocalRotation(boolean);

	public static new Vector3 localEulerAngles => automaticBehaviour.localEulerAngles;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAnglesTo(Vector3 localEulerAngles, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAnglesTo(localEulerAngles, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAnglesTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalEulerAngles(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngles(boolean);

	public static new float localEulerAngleX => automaticBehaviour.localEulerAngleX;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleXTo(float localEulerAngleX, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleXTo(localEulerAngleX, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleXTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalEulerAngleX(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngleX(boolean);

	public static new float localEulerAngleY => automaticBehaviour.localEulerAngleY;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleYTo(float localEulerAngleY, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleYTo(localEulerAngleY, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleYTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalEulerAngleY(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngleY(boolean);

	public static new float localEulerAngleZ => automaticBehaviour.localEulerAngleZ;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleZTo(float localEulerAngleZ, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleZTo(localEulerAngleZ, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleZTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalEulerAngleZ(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngleZ(boolean);

	public static new Vector3 localScale => automaticBehaviour.localScale;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleTo(Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocalScaleTo(localScale, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScaleTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalScale(bool boolean = true)
		=> automaticBehaviour.resetLocalScale(boolean);

	public static new float localScaleX => automaticBehaviour.localScale.x;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleXTo(float x, bool boolean = true)
		=> automaticBehaviour.setLocalScaleXTo(x, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleXTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScaleXTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalScaleX(bool boolean = true)
		=> automaticBehaviour.resetLocalScaleX(boolean);

	public static new float localScaleY => automaticBehaviour.localScale.y;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleYTo(float y, bool boolean = true)
		=> automaticBehaviour.setLocalScaleYTo(y, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleYTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScaleYTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalScaleY(bool boolean = true)
		=> automaticBehaviour.resetLocalScaleY(boolean);

	public static new float localScaleZ => automaticBehaviour.localScale.z;
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleZTo(float z, bool boolean = true)
		=> automaticBehaviour.setLocalScaleZTo(z, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalScaleZTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScaleZTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocalScaleZ(bool boolean = true)
		=> automaticBehaviour.resetLocalScaleZ(boolean);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(localPosition, localRotation, localScale, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetLocals(bool boolean = true)
		=> automaticBehaviour.resetLocals(boolean);

	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(localPosition, localEulerAngles, localScale, boolean);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(localPosition, localRotation, boolean);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsTo(Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocalsTo(localRotation, localScale, boolean);

	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalsParentlyForRelativeTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalsParentlyForRelativeTo(otherGameObject, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalsParentlyForRelativeTo(otherComponent, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setLocalsParentlyForRelativeTo<OtherSingletonBehaviourT>(bool boolean = true) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> automaticBehaviour.setLocalsParentlyForRelativeTo<OtherSingletonBehaviourT>(boolean);

	public static new Vector3 position => automaticBehaviour.position;
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionTo(Vector3 position, bool boolean = true)
		=> automaticBehaviour.setPositionTo(position, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPositionTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetPosition(bool boolean = true)
		=> automaticBehaviour.resetPosition(boolean);

	public static new float positionX => automaticBehaviour.position.x;
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionXTo(float x, bool boolean = true)
		=> automaticBehaviour.setPositionXTo(x, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionXTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPositionXTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetPositionX(bool boolean = true)
		=> automaticBehaviour.resetPositionX(boolean);

	public static new float positionY => automaticBehaviour.position.y;
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionYTo(float y, bool boolean = true)
		=> automaticBehaviour.setPositionYTo(y, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionYTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPositionYTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetPositionY(bool boolean = true)
		=> automaticBehaviour.resetPositionY(boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> negatePositionY(bool boolean = true)
		=> automaticBehaviour.negatePositionY(boolean);

	public static new float positionZ => automaticBehaviour.position.z;
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionZTo(float z, bool boolean = true)
		=> automaticBehaviour.setPositionZTo(z, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setPositionZTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPositionZTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetPositionZ(bool boolean = true)
		=> automaticBehaviour.resetPositionZ(boolean);

	public static new Quaternion rotation => automaticBehaviour.rotation;
	public static new AutomaticBehaviour<SingletonBehaviourT> setRotationTo(Quaternion rotation, bool boolean = true)
		=> automaticBehaviour.setRotationTo(rotation, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setRotationTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setRotationTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetRotation(bool boolean = true)
		=> automaticBehaviour.resetRotation(boolean);

	public static new Vector3 eulerAngles => automaticBehaviour.eulerAngles;
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAnglesTo(Vector3 eulerAngles, bool boolean = true)
		=> automaticBehaviour.setEulerAnglesTo(eulerAngles, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAnglesTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetEulerAngles(bool boolean = true)
		=> automaticBehaviour.resetEulerAngles(boolean);

	public static new float eulerAngleX => automaticBehaviour.eulerAngleX;
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleXTo(float eulerAngleX, bool boolean = true)
		=> automaticBehaviour.setEulerAngleXTo(eulerAngleX, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAngleXTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetEulerAngleX(bool boolean = true)
		=> automaticBehaviour.resetEulerAngleX(boolean);

	public static new float eulerAngleY => automaticBehaviour.eulerAngleY;
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleYTo(float eulerAngleY, bool boolean = true)
		=> automaticBehaviour.setEulerAngleYTo(eulerAngleY, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAngleYTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetEulerAngleY(bool boolean = true)
		=> automaticBehaviour.resetEulerAngleY(boolean);

	public static new float eulerAngleZ => automaticBehaviour.eulerAngleZ;
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleZTo(float eulerAngleZ, bool boolean = true)
		=> automaticBehaviour.setEulerAngleZTo(eulerAngleZ, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAngleZTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetEulerAngleZ(bool boolean = true)
		=> automaticBehaviour.resetEulerAngleZ(boolean);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsTo(Vector3 position, Quaternion rotation, bool boolean = true)
		=> automaticBehaviour.setGlobalsTo(position, rotation, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setGlobalsTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsTo(Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> automaticBehaviour.setGlobalsTo(position, eulerAngles, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetGlobals(bool boolean = true)
		=> automaticBehaviour.resetGlobals(boolean);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setGlobalsAndLocalScaleTo(position, rotation, localScale, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setGlobalsAndLocalScaleTo(otherTransform, boolean);
	public static new AutomaticBehaviour<SingletonBehaviourT> resetGlobalsAndLocalScale(bool boolean = true)
		=> automaticBehaviour.resetGlobalsAndLocalScale(boolean);

	public static new AutomaticBehaviour<SingletonBehaviourT> setGlobalsAndLocalScaleTo(Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setGlobalsAndLocalScaleTo(position, eulerAngles, localScale, boolean);
	#endregion transformations


	#region advanced rotation

	// method: (according to the given boolean:) have this behaviour's transform look at the given target position with the specified axes, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> lookAt(Vector3 targetPosition, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> automaticBehaviour.lookAt(targetPosition, withX, withY, withZ, boolean);

	// method: (according to the given boolean:) have this behaviour's transform look at the given target transform with the specified axes, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> lookAt(Transform targetTransform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> automaticBehaviour.lookAt(targetTransform, withX, withY, withZ, boolean);

	// method: (according to the given boolean:) have this behaviour's transform look at the given target transform with the specified axes, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> lookAt(GameObject targetObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> automaticBehaviour.lookAt(targetObject.transform, withX, withY, withZ, boolean);

	// method: (according to the given boolean:) have this behaviour's transform look at the given target component's transform with the specified axes, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> lookAt(Component targetComponent, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> automaticBehaviour.lookAt(targetComponent, withX, withY, withZ, boolean);

	// method: (according to the given boolean:) have this given transform look at the main camera with the specified axes, then return this given transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> lookAtCamera(bool withX = true, bool withY = true, bool withZ = true, bool boolean = true)
		=> automaticBehaviour.lookAtCamera(withX, withY, withZ, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given (x, y, and z) rotation angles, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> rotate(Vector3 rotationAngles, bool boolean = true)
		=> automaticBehaviour.rotate(rotationAngles, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x, y, and z rotation angles, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> rotate(float x, float y, float z, bool boolean = true)
		=> automaticBehaviour.rotate(x, y, z, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x rotation angle, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> rotateX(float x, bool boolean = true)
		=> automaticBehaviour.rotateZ(x, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given y rotation angle, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> rotateY(float y, bool boolean = true)
		=> automaticBehaviour.rotateZ(y, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given z rotation angle, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> rotateZ(float z, bool boolean = true)
		=> automaticBehaviour.rotateZ(z, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by 180° on the x axis, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> flipX(bool boolean = true)
		=> automaticBehaviour.flipX(boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by 180° on the y axis, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> flipY(bool boolean = true)
		=> automaticBehaviour.flipY(boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by 180° on the z axis, then return this behaviour's transform //
	public static new AutomaticBehaviour<SingletonBehaviourT> flipZ(bool boolean = true)
		=> automaticBehaviour.flipZ(boolean);
	#endregion advanced rotation


	#region directions

	// method: return the vector for the forward direction relative to this transform //
	public static new Vector3 forwardLocal => automaticBehaviour.forwardLocal;

	// method: return the vector for the backward direction relative to this transform //
	public static new Vector3 backwardLocal => automaticBehaviour.backwardLocal;

	// method: return the vector for the right direction relative to this transform //
	public static new Vector3 rightLocal => automaticBehaviour.rightLocal;

	// method: return the vector for the left direction relative to this transform //
	public static new Vector3 leftLocal => automaticBehaviour.leftLocal;

	// method: return the vector for the up direction relative to this transform //
	public static new Vector3 upLocal => automaticBehaviour.upLocal;

	// method: return the vector for the down direction relative to this transform //
	public static new Vector3 downLocal => automaticBehaviour.downLocal;

	// method: return the vector for the given basic direction relative to this transform //
	public static new Vector3 vectorForRelativeDirection(BasicDirection basicDirection)
		=> automaticBehaviour.vectorForRelativeDirection(basicDirection);
	#endregion directions


	#region distance

	// method: return the closest of the given positions to this behaviour's transform's position //
	public static new Vector3 closestOf(IEnumerable<Vector3> positions)
		=> automaticBehaviour.closestOf(positions);
	// method: return the closest (by position) of the given transforms to this behaviour's transform //
	public static new Transform closestOf(IEnumerable<Transform> transforms)
		=> automaticBehaviour.closestOf(transforms);
	// method: return the closest (by position) of the given game objects to this behaviour's transform //
	public static new GameObject closestOf(IEnumerable<GameObject> gameObjects)
		=> automaticBehaviour.closestOf(gameObjects);

	// method: return the farthest of the given positions to this behaviour's transform's position //
	public static new Vector3 farthestOf(IEnumerable<Vector3> positions)
		=> automaticBehaviour.farthestOf(positions);
	// method: return the farthest (by position) of the given transforms to this behaviour's transform //
	public static new Transform farthestOf(IEnumerable<Transform> transforms)
		=> automaticBehaviour.farthestOf(transforms);
	// method: return the farthest (by position) of the given game objects to this behaviour's transform //
	public static new GameObject farthestOf(IEnumerable<GameObject> gameObjects)
		=> automaticBehaviour.farthestOf(gameObjects);
	#endregion distance


	#region targetedly forcing

	public static new AutomaticBehaviour<SingletonBehaviourT> forceTarget(dynamic targetRigidbodies_RigidbodiesProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, AutomaticBehaviour<SingletonBehaviourT>>(targetRigidbodies =>
				automaticBehaviour.forceTarget(targetRigidbodies, tug, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp)));

	public static new AutomaticBehaviour<SingletonBehaviourT> attract(dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, AutomaticBehaviour<SingletonBehaviourT>>(targetRigidbodies =>
				automaticBehaviour.attract(targetRigidbodies, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp)));

	public static new AutomaticBehaviour<SingletonBehaviourT> repel(dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=> Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, AutomaticBehaviour<SingletonBehaviourT>>(targetRigidbodies =>
			   automaticBehaviour.repel(targetRigidbodies, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp)));
	#endregion targetedly forcing


	#region radially forcing

	public static new List<GameObject> forceRadially(Tug tug, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.forceRadially(tug, magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public static new List<GameObject> suck(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.suck(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public static new List<GameObject> repulse(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.repulse(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radially forcing
}