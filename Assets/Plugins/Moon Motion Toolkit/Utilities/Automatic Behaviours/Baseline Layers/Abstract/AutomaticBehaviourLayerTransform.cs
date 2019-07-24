using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Transform:
// #auto #transform
// • provides this behaviour with methods and automatically-connected properties for its transform
public abstract class	AutomaticBehaviourLayerTransform<AutomaticBehaviourT> :
					AutomaticBehaviourLayerGameObject<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	#region transform

	public new Transform transform => inheritorHasAttribute<CacheTransformAttribute>() ? cache<Transform>() : component.transform;     // the transform property is only worth caching (since that takes up memory) when accessed a lot, like every frame in Update, so that property only uses caching according to the respective attribute; see https://forum.unity.com/threads/cache-transform-really-needed.356875/ for discussion of this //
	#endregion transform


	#region sibling indexing

	public int siblingIndex => transform.siblingIndex();
	#endregion sibling indexing


	#region getting siblings

	public IEnumerable<Transform> selectSiblingAndSelfTransforms => transform.selectSiblingAndSelfTransforms();
	public Transform[] siblingAndSelfTransforms => transform.siblingAndSelfTransforms();

	public IEnumerable<GameObject> selectSiblingAndSelfObjects => transform.selectSiblingAndSelfObjects();
	public GameObject[] siblingAndSelfObjects => transform.siblingAndSelfObjects();

	public IEnumerable<Transform> selectSiblingTransforms => transform.selectSiblingTransforms();
	public IEnumerable<Transform> siblingTransforms => transform.siblingTransforms();

	public IEnumerable<GameObject> selectSiblingObjects => transform.selectSiblingObjects();
	public IEnumerable<GameObject> siblingObjects => transform.siblingObjects();
	#endregion siblings


	#region descendants

	public bool isLocalToOrDescendantOf(Transform otherTransform)
		=> transform.isLocalToOrDescendantOf(otherTransform);
	
	public bool isLocalToOrDescendantOf(GameObject otherGameObject)
		=> transform.isLocalToOrDescendantOf(otherGameObject);
	
	public bool isLocalToOrDescendantOf(Component otherComponent)
		=> transform.isLocalToOrDescendantOf(otherComponent);
	
	public bool isLocalToOrDescendantOf<SingletonBehaviourT>() where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> transform.isLocalToOrDescendantOf<SingletonBehaviourT>();
	#endregion descendants


	#region parent

	public bool parentless => transform.parentless();
	public Transform parent => transform.parent;
	public Transform setParentTo(Transform parentTransform, bool boolean = true)
		=> transform.setParentTo(parentTransform, boolean);
	public Transform setParentTo(GameObject parentObject, bool boolean = true)
		=> transform.setParentTo(parentObject, boolean);
	public Transform setParentTo(Component parentComponent, bool boolean = true)
		=> transform.setParentTo(parentComponent, boolean);
	public Transform setParentTo<ParentSingletonBehaviourT>(bool boolean = true) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> transform.setParentTo<ParentSingletonBehaviourT>(boolean);
	public Transform unparent(bool boolean = true)
		=> transform.unparent(boolean);
	#endregion parent


	#region pibling indexing
	
	public int piblingIndex => transform.piblingIndex();
	#endregion pibling indexing


	#region getting piblings

	public Transform piblingTransform(int piblingIndex)
		=> transform.piblingTransform(piblingIndex);

	public Transform correspondingPiblingTransform => transform.correspondingPiblingTransform();

	public GameObject piblingObject(int piblingIndex)
		=> transform.piblingObject(piblingIndex);

	public Transform firstPiblingTransform => transform.firstPiblingTransform();

	public GameObject firstPiblingObject => transform.firstPiblingObject();

	public Transform lastPiblingTransform => transform.lastPiblingTransform();

	public GameObject lastPiblingObject => transform.lastPiblingObject();

	public IEnumerable<Transform> selectPiblingTransforms => transform.selectPiblingTransforms();
	public Transform[] piblingTransforms => transform.piblingTransforms();

	public IEnumerable<GameObject> selectPiblingObjects => transform.selectPiblingObjects();
	public GameObject[] piblingObjects => transform.piblingObjects();
	#endregion getting piblings


	#region counting children

	public bool childless => component.childless();

	public bool anyChildren()
		=> component.anyChildren();

	public bool pluralChildren => component.pluralChildren();
	#endregion counting children


	#region getting children

	public Transform childTransform(int childIndex)
		=> transform.childTransform(childIndex);

	public GameObject childObject(int childIndex)
		=> transform.childObject(childIndex);

	public Transform firstChildTransform => transform.firstChildTransform();

	public GameObject firstChildObject => transform.firstChildObject();

	public Transform lastChildTransform => transform.lastChildTransform();

	public GameObject lastChildObject => transform.lastChildObject();

	public IEnumerable<Transform> selectChildTransforms => transform.selectChildTransforms();
	public Transform[] childTransforms => transform.childTransforms();

	public IEnumerable<GameObject> selectChildObjects => transform.selectChildObjects();
	public GameObject[] childObjects => transform.childObjects();
	#endregion getting children


	#region destroying children

	public Transform destroyChild(int childIndex)
		=> transform.destroyChild(childIndex);
	
	public Transform destroyChildIfItExists(int childIndex)
		=> transform.destroyChildIfItExists(childIndex);
	
	public Transform destroyFirstChild()
		=> transform.destroyFirstChild();
	
	public Transform destroyFirstChildIfItExists()
		=> transform.destroyFirstChildIfItExists();
	
	public Transform destroyLastChild()
		=> transform.destroyLastChild();
	
	public Transform destroyLastChildIfItExists()
		=> transform.destroyLastChildIfItExists();
	
	public Transform destroyLastChildIfItExists<ComponentT>() where ComponentT : Component
		=> transform.destroyLastChildIfItExists<ComponentT>();

	public Transform destroyChildren()
		=> transform.destroyChildren();
	#endregion destroying children


	#region child iteration

	public Transform forEachChildTransform(Action<Transform> action)
		=> transform.forEachChildTransform(action);

	public Transform setActivityOfChildrenTo(bool boolean)
		=> transform.setActivityOfChildrenTo(boolean);
	#endregion child iteration


	#region transformations

	public Vector3 localPosition => transform.localPosition;
	public Transform setLocalPositionTo(Vector3 localPosition, bool boolean = true)
		=> transform.setLocalPositionTo(localPosition, boolean);
	public Transform setLocalPositionTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalPositionTo(otherTransform, boolean);
	public Transform setLocalPositionTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalPositionTo(otherGameObject, boolean);
	public Transform setLocalPositionTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalPositionTo(otherComponent, boolean);
	public Transform resetLocalPosition(bool boolean = true)
		=> transform.resetLocalPosition(boolean);


	public float localPositionX => transform.localPosition.x;
	public Transform setLocalPositionXTo(float x, bool boolean = true)
		=> transform.setLocalPositionXTo(x, boolean);
	public Transform setLocalPositionXTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalPositionXTo(otherTransform, boolean);
	public Transform resetLocalPositionX(bool boolean = true)
		=> transform.resetLocalPositionX(boolean);

	public float localPositionY => transform.localPosition.y;
	public Transform setLocalPositionYTo(float y, bool boolean = true)
		=> transform.setLocalPositionYTo(y, boolean);
	public Transform setLocalPositionYTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalPositionYTo(otherTransform, boolean);
	public Transform setLocalPositionYTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalPositionYTo(otherGameObject, boolean);
	public Transform setLocalPositionYTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalPositionYTo(otherComponent, boolean);
	public Transform resetLocalPositionY(bool boolean = true)
		=> transform.resetLocalPositionY(boolean);

	public float localPositionZ => transform.localPosition.z;
	public Transform setLocalPositionZTo(float z, bool boolean = true)
		=> transform.setLocalPositionZTo(z, boolean);
	public Transform setLocalPositionZTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalPositionZTo(otherTransform, boolean);
	public Transform setLocalPositionZTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalPositionZTo(otherGameObject, boolean);
	public Transform setLocalPositionZTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalPositionZTo(otherComponent, boolean);
	public Transform resetLocalPositionZ(bool boolean = true)
		=> transform.resetLocalPositionZ(boolean);

	public Quaternion localRotation => transform.localRotation;
	public Transform setLocalRotationTo(Quaternion localRotation, bool boolean = true)
		=> transform.setLocalRotationTo(localRotation, boolean);
	public Transform setLocalRotationTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalRotationTo(otherTransform, boolean);
	public Transform setLocalRotationTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalRotationTo(otherGameObject, boolean);
	public Transform setLocalRotationTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalRotationTo(otherComponent, boolean);
	public Transform resetLocalRotation(bool boolean = true)
		=> transform.resetLocalRotation(boolean);

	public Vector3 localEulerAngles => transform.localEulerAngles;
	public Transform setLocalEulerAnglesTo(Vector3 localEulerAngles, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(localEulerAngles, boolean);
	public Transform setLocalEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(otherTransform, boolean);
	public Transform setLocalEulerAnglesTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(otherGameObject, boolean);
	public Transform setLocalEulerAnglesTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalEulerAnglesTo(otherComponent, boolean);
	public Transform resetLocalEulerAngles(bool boolean = true)
		=> transform.resetLocalEulerAngles(boolean);

	public float localEulerAngleX => transform.localEulerAngleX();
	public Transform setLocalEulerAngleXTo(float localEulerAngleX, bool boolean = true)
		=> transform.setLocalEulerAngleXTo(localEulerAngleX, boolean);
	public Transform setLocalEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAngleXTo(otherTransform, boolean);
	public Transform setLocalEulerAngleXTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalEulerAngleXTo(otherGameObject, boolean);
	public Transform setLocalEulerAngleXTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalEulerAngleXTo(otherComponent, boolean);
	public Transform resetLocalEulerAngleX(bool boolean = true)
		=> transform.resetLocalEulerAngleX(boolean);

	public float localEulerAngleY => transform.localEulerAngleY();
	public Transform setLocalEulerAngleYTo(float localEulerAngleY, bool boolean = true)
		=> transform.setLocalEulerAngleYTo(localEulerAngleY, boolean);
	public Transform setLocalEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAngleYTo(otherTransform, boolean);
	public Transform setLocalEulerAngleYTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalEulerAngleYTo(otherGameObject, boolean);
	public Transform setLocalEulerAngleYTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalEulerAngleYTo(otherComponent, boolean);
	public Transform resetLocalEulerAngleY(bool boolean = true)
		=> transform.resetLocalEulerAngleY(boolean);

	public float localEulerAngleZ => transform.localEulerAngleZ();
	public Transform setLocalEulerAngleZTo(float localEulerAngleZ, bool boolean = true)
		=> transform.setLocalEulerAngleZTo(localEulerAngleZ, boolean);
	public Transform setLocalEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAngleZTo(otherTransform, boolean);
	public Transform setLocalEulerAngleZTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalEulerAngleZTo(otherGameObject, boolean);
	public Transform setLocalEulerAngleZTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalEulerAngleZTo(otherComponent, boolean);
	public Transform resetLocalEulerAngleZ(bool boolean = true)
		=> transform.resetLocalEulerAngleZ(boolean);

	public Vector3 localScale => transform.localScale;
	public Transform setLocalScaleTo(Vector3 localScale, bool boolean = true)
		=> transform.setLocalScaleTo(localScale, boolean);
	public Transform setLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalScaleTo(otherTransform, boolean);
	public Transform setLocalScaleTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalScaleTo(otherGameObject, boolean);
	public Transform setLocalScaleTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalScaleTo(otherComponent, boolean);
	public Transform resetLocalScale(bool boolean = true)
		=> transform.resetLocalScale(boolean);

	public float localScaleX => transform.localScale.x;
	public Transform setLocalScaleXTo(float x, bool boolean = true)
		=> transform.setLocalScaleXTo(x, boolean);
	public Transform setLocalScaleXTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalScaleXTo(otherTransform, boolean);
	public Transform setLocalScaleXTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalScaleXTo(otherGameObject, boolean);
	public Transform setLocalScaleXTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalScaleXTo(otherComponent, boolean);
	public Transform resetLocalScaleX(bool boolean = true)
		=> transform.resetLocalScaleX(boolean);

	public float localScaleY => transform.localScale.y;
	public Transform setLocalScaleYTo(float y, bool boolean = true)
		=> transform.setLocalScaleYTo(y, boolean);
	public Transform setLocalScaleYTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalScaleYTo(otherTransform, boolean);
	public Transform setLocalScaleYTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalScaleYTo(otherGameObject, boolean);
	public Transform setLocalScaleYTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalScaleYTo(otherComponent, boolean);
	public Transform resetLocalScaleY(bool boolean = true)
		=> transform.resetLocalScaleY(boolean);

	public float localScaleZ => transform.localScale.z;
	public Transform setLocalScaleZTo(float z, bool boolean = true)
		=> transform.setLocalScaleZTo(z, boolean);
	public Transform setLocalScaleZTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalScaleZTo(otherTransform, boolean);
	public Transform setLocalScaleZTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalScaleZTo(otherGameObject, boolean);
	public Transform setLocalScaleZTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalScaleZTo(otherComponent, boolean);
	public Transform resetLocalScaleZ(bool boolean = true)
		=> transform.resetLocalScaleZ(boolean);
	
	public Transform setLocalsTo(Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> transform.setLocalsTo(localPosition, localRotation, localScale, boolean);
	public Transform setLocalsTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalsTo(otherTransform, boolean);
	public Transform setLocalsTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalsTo(otherGameObject, boolean);
	public Transform setLocalsTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalsTo(otherComponent, boolean);
	public Transform resetLocals(bool boolean = true)
		=> transform.resetLocals(boolean);

	public Transform setLocalsTo(Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> transform.setLocalsTo(localPosition, localEulerAngles, localScale, boolean);
	
	public Transform setLocalsTo(Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> transform.setLocalsTo(localPosition, localRotation, boolean);
	
	public Transform setLocalsTo(Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> transform.setLocalsTo(localRotation, localScale, boolean);
	
	public Transform setLocalsParentlyForRelativeTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalsParentlyForRelativeTo(otherTransform, boolean);
	public Transform setLocalsParentlyForRelativeTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalsParentlyForRelativeTo(otherGameObject, boolean);
	public Transform setLocalsParentlyForRelativeTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalsParentlyForRelativeTo(otherComponent, boolean);
	public Transform setLocalsParentlyForRelativeTo<SingletonBehaviourT>(bool boolean = true) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> transform.setLocalsParentlyForRelativeTo<SingletonBehaviourT>(boolean);

	public Vector3 position => transform.position;
	public Transform setPositionTo(Vector3 position, bool boolean = true)
		=> transform.setPositionTo(position, boolean);
	public Transform setPositionTo(Transform otherTransform, bool boolean = true)
		=> transform.setPositionTo(otherTransform, boolean);
	public Transform setPositionTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setPositionTo(otherGameObject, boolean);
	public Transform setPositionTo(Component otherComponent, bool boolean = true)
		=> transform.setPositionTo(otherComponent, boolean);
	public Transform resetPosition(bool boolean = true)
		=> transform.resetPosition(boolean);

	public float positionX => transform.position.x;
	public Transform setPositionXTo(float x, bool boolean = true)
		=> transform.setPositionXTo(x, boolean);
	public Transform setPositionXTo(Transform otherTransform, bool boolean = true)
		=> transform.setPositionXTo(otherTransform, boolean);
	public Transform setPositionXTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setPositionXTo(otherGameObject, boolean);
	public Transform setPositionXTo(Component otherComponent, bool boolean = true)
		=> transform.setPositionXTo(otherComponent, boolean);
	public Transform resetPositionX(bool boolean = true)
		=> transform.resetPositionX(boolean);

	public float positionY => transform.position.y;
	public Transform setPositionYTo(float y, bool boolean = true)
		=> transform.setPositionYTo(y, boolean);
	public Transform setPositionYTo(Transform otherTransform, bool boolean = true)
		=> transform.setPositionYTo(otherTransform, boolean);
	public Transform setPositionYTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setPositionYTo(otherGameObject, boolean);
	public Transform setPositionYTo(Component otherComponent, bool boolean = true)
		=> transform.setPositionYTo(otherComponent, boolean);
	public Transform resetPositionY(bool boolean = true)
		=> transform.resetPositionY(boolean);

	public float positionZ => transform.position.z;
	public Transform setPositionZTo(float z, bool boolean = true)
		=> transform.setPositionZTo(z, boolean);
	public Transform setPositionZTo(Transform otherTransform, bool boolean = true)
		=> transform.setPositionZTo(otherTransform, boolean);
	public Transform setPositionZTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setPositionZTo(otherGameObject, boolean);
	public Transform setPositionZTo(Component otherComponent, bool boolean = true)
		=> transform.setPositionZTo(otherComponent, boolean);
	public Transform resetPositionZ(bool boolean = true)
		=> transform.resetPositionZ(boolean);

	public Quaternion rotation => transform.rotation;
	public Transform setRotationTo(Quaternion rotation, bool boolean = true)
		=> transform.setRotationTo(rotation, boolean);
	public Transform setRotationTo(Transform otherTransform, bool boolean = true)
		=> transform.setRotationTo(otherTransform, boolean);
	public Transform setRotationTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setRotationTo(otherGameObject, boolean);
	public Transform setRotationTo(Component otherComponent, bool boolean = true)
		=> transform.setRotationTo(otherComponent, boolean);
	public Transform resetRotation(bool boolean = true)
		=> transform.resetRotation(boolean);

	public Vector3 eulerAngles => transform.eulerAngles;
	public Transform setEulerAnglesTo(Vector3 eulerAngles, bool boolean = true)
		=> transform.setEulerAnglesTo(eulerAngles, boolean);
	public Transform setEulerAnglesTo(Transform otherTransform, bool boolean = true)
		=> transform.setEulerAnglesTo(otherTransform, boolean);
	public Transform setEulerAnglesTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setEulerAnglesTo(otherGameObject, boolean);
	public Transform setEulerAnglesTo(Component otherComponent, bool boolean = true)
		=> transform.setEulerAnglesTo(otherComponent, boolean);
	public Transform resetEulerAngles(bool boolean = true)
		=> transform.resetEulerAngles(boolean);

	public float eulerAngleX => transform.eulerAngleX();
	public Transform setEulerAngleXTo(float eulerAngleX, bool boolean = true)
		=> transform.setEulerAngleXTo(eulerAngleX, boolean);
	public Transform setEulerAngleXTo(Transform otherTransform, bool boolean = true)
		=> transform.setEulerAngleXTo(otherTransform, boolean);
	public Transform setEulerAngleXTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setEulerAngleXTo(otherGameObject, boolean);
	public Transform setEulerAngleXTo(Component otherComponent, bool boolean = true)
		=> transform.setEulerAngleXTo(otherComponent, boolean);
	public Transform resetEulerAngleX(bool boolean = true)
		=> transform.resetEulerAngleX(boolean);

	public float eulerAngleY => transform.eulerAngleY();
	public Transform setEulerAngleYTo(float eulerAngleY, bool boolean = true)
		=> transform.setEulerAngleYTo(eulerAngleY, boolean);
	public Transform setEulerAngleYTo(Transform otherTransform, bool boolean = true)
		=> transform.setEulerAngleYTo(otherTransform, boolean);
	public Transform setEulerAngleYTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setEulerAngleYTo(otherGameObject, boolean);
	public Transform setEulerAngleYTo(Component otherComponent, bool boolean = true)
		=> transform.setEulerAngleYTo(otherComponent, boolean);
	public Transform resetEulerAngleY(bool boolean = true)
		=> transform.resetEulerAngleY(boolean);

	public float eulerAngleZ => transform.eulerAngleZ();
	public Transform setEulerAngleZTo(float eulerAngleZ, bool boolean = true)
		=> transform.setEulerAngleZTo(eulerAngleZ, boolean);
	public Transform setEulerAngleZTo(Transform otherTransform, bool boolean = true)
		=> transform.setEulerAngleZTo(otherTransform, boolean);
	public Transform setEulerAngleZTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setEulerAngleZTo(otherGameObject, boolean);
	public Transform setEulerAngleZTo(Component otherComponent, bool boolean = true)
		=> transform.setEulerAngleZTo(otherComponent, boolean);
	public Transform resetEulerAngleZ(bool boolean = true)
		=> transform.resetEulerAngleZ(boolean);
	
	public Transform setGlobalsTo(Vector3 position, Quaternion rotation, bool boolean = true)
		=> transform.setGlobalsTo(position, rotation, boolean);
	public Transform setGlobalsTo(Transform otherTransform, bool boolean = true)
		=> transform.setGlobalsTo(otherTransform, boolean);
	public Transform setGlobalsTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setGlobalsTo(otherGameObject, boolean);
	public Transform setGlobalsTo(Component otherComponent, bool boolean = true)
		=> transform.setGlobalsTo(otherComponent, boolean);
	public Transform resetGlobals(bool boolean = true)
		=> transform.resetGlobals(boolean);

	public Transform setGlobalsTo(Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> transform.setGlobalsTo(position, eulerAngles, boolean);
	
	public Transform setGlobalsAndLocalScaleTo(Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> transform.setGlobalsAndLocalScaleTo(position, rotation, localScale, boolean);
	public Transform setGlobalsAndLocalScaleTo(Transform otherTransform, bool boolean = true)
		=> transform.setGlobalsAndLocalScaleTo(otherTransform, boolean);
	public Transform setGlobalsAndLocalScaleTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setGlobalsAndLocalScaleTo(otherGameObject, boolean);
	public Transform setGlobalsAndLocalScaleTo(Component otherComponent, bool boolean = true)
		=> transform.setGlobalsAndLocalScaleTo(otherComponent, boolean);
	public Transform resetGlobalsAndLocalScale(bool boolean = true)
		=> transform.resetGlobalsAndLocalScale(boolean);

	public Transform setGlobalsAndLocalScaleTo(Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> transform.setGlobalsAndLocalScaleTo(position, eulerAngles, localScale, boolean);
	#endregion transformations


	#region advanced rotation

	// method: (according to the given boolean:) have this behaviour's transform look at the given target position, then return this behaviour's transform //
	public Transform lookAt(Vector3 targetPosition, bool boolean = true)
		=> transform.lookAt(targetPosition, boolean);

	// method: (according to the given boolean:) have this behaviour's transform look at the given target transform, then return this behaviour's transform //
	public Transform lookAt(Transform targetTransform, bool boolean = true)
		=> transform.lookAt(targetTransform, boolean);

	// method: (according to the given boolean:) have this behaviour's transform look at the given target transform, then return this behaviour's transform //
	public Transform lookAt(GameObject targetObject, bool boolean = true)
		=> transform.lookAt(targetObject.transform, boolean);

	// method: (according to the given boolean:) have this behaviour's transform look at the given target component's transform, then return this behaviour's transform //
	public Transform lookAt(Component targetComponent, bool boolean = true)
		=> transform.lookAt(targetComponent, boolean);

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
	#endregion advanced rotation


	#region directions

	// the forward direction relative to this transform //
	public Vector3 forwardLocal => transform.forward();

	// the backward direction relative to this transform //
	public Vector3 backwardLocal => transform.backward();

	// the right direction relative to this transform //
	public Vector3 rightLocal => transform.right();

	// the left direction relative to this transform //
	public Vector3 leftLocal => transform.left();

	// the up direction relative to this transform //
	public Vector3 upLocal => transform.up();

	// the down direction relative to this transform //
	public Vector3 downLocal => transform.down();

	// method: return the direction vector for the given direction relative to this transform //
	public Vector3 vectorForRelativeDirection(Direction direction)
		=> transform.vectorForRelativeDirection(direction);
	#endregion directions


	#region distance

	// method: return the closest of the given positions to this behaviour's transform's position //
	public Vector3 closestOf(IEnumerable<Vector3> positions)
		=> transform.closestOf(positions);
	// method: return the closest (by position) of the given transforms to this behaviour's transform //
	public Transform closestOf(IEnumerable<Transform> transforms)
		=> transform.closestOf(transforms);
	// method: return the closest (by position) of the given game objects to this behaviour's transform //
	public GameObject closestOf(IEnumerable<GameObject> gameObjects)
		=> transform.closestOf(gameObjects);

	// method: return the farthest of the given positions to this behaviour's transform's position //
	public Vector3 farthestOf(IEnumerable<Vector3> positions)
		=> transform.farthestOf(positions);
	// method: return the farthest (by position) of the given transforms to this behaviour's transform //
	public Transform farthestOf(IEnumerable<Transform> transforms)
		=> transform.farthestOf(transforms);
	// method: return the farthest (by position) of the given game objects to this behaviour's transform //
	public GameObject farthestOf(IEnumerable<GameObject> gameObjects)
		=> transform.farthestOf(gameObjects);
	#endregion distance
}