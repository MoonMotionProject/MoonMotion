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

	public Transform[] siblingAndSelfTransforms => transform.siblingAndSelfTransforms();
	
	public GameObject[] siblingAndSelfObjects => transform.siblingAndSelfObjects();

	public IEnumerable<Transform> siblingTransforms => transform.siblingTransforms();

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
	public Transform setParent(Transform parentTransform, bool boolean = true)
		=> transform.setParent(parentTransform, boolean);
	public Transform setParent(GameObject parentObject, bool boolean = true)
		=> transform.setParent(parentObject, boolean);
	public Transform setParent(Component parentComponent, bool boolean = true)
		=> transform.setParent(parentComponent, boolean);
	public Transform setParent<ParentSingletonBehaviourT>(bool boolean = true) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> transform.setParent<ParentSingletonBehaviourT>(boolean);
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

	public Transform[] piblingTransforms => transform.piblingTransforms();
	
	public GameObject[] piblingObjects => transform.piblingObjects();
	#endregion getting piblings


	#region counting children

	public bool childless => component.childless();

	public bool anyChildren => component.anyChildren();

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

	public Transform[] childTransforms => transform.childTransforms();

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
	public Transform setLocalPosition(Vector3 localPosition, bool boolean = true)
		=> transform.setLocalPosition(localPosition, boolean);
	public Transform setLocalPosition(Transform otherTransform, bool boolean = true)
		=> transform.setLocalPosition(otherTransform, boolean);
	public Transform setLocalPosition(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalPosition(otherGameObject, boolean);
	public Transform setLocalPosition(Component otherComponent, bool boolean = true)
		=> transform.setLocalPosition(otherComponent, boolean);
	public Transform resetLocalPosition(bool boolean = true)
		=> transform.resetLocalPosition(boolean);


	public float localPositionX => transform.localPosition.x;
	public Transform setLocalPositionX(float x, bool boolean = true)
		=> transform.setLocalPositionX(x, boolean);
	public Transform setLocalPositionX(Transform otherTransform, bool boolean = true)
		=> transform.setLocalPositionX(otherTransform, boolean);
	public Transform resetLocalPositionX(bool boolean = true)
		=> transform.resetLocalPositionX(boolean);

	public float localPositionY => transform.localPosition.y;
	public Transform setLocalPositionY(float y, bool boolean = true)
		=> transform.setLocalPositionY(y, boolean);
	public Transform setLocalPositionY(Transform otherTransform, bool boolean = true)
		=> transform.setLocalPositionY(otherTransform, boolean);
	public Transform setLocalPositionY(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalPositionY(otherGameObject, boolean);
	public Transform setLocalPositionY(Component otherComponent, bool boolean = true)
		=> transform.setLocalPositionY(otherComponent, boolean);
	public Transform resetLocalPositionY(bool boolean = true)
		=> transform.resetLocalPositionY(boolean);

	public float localPositionZ => transform.localPosition.z;
	public Transform setLocalPositionZ(float z, bool boolean = true)
		=> transform.setLocalPositionZ(z, boolean);
	public Transform setLocalPositionZ(Transform otherTransform, bool boolean = true)
		=> transform.setLocalPositionZ(otherTransform, boolean);
	public Transform setLocalPositionZ(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalPositionZ(otherGameObject, boolean);
	public Transform setLocalPositionZ(Component otherComponent, bool boolean = true)
		=> transform.setLocalPositionZ(otherComponent, boolean);
	public Transform resetLocalPositionZ(bool boolean = true)
		=> transform.resetLocalPositionZ(boolean);

	public Quaternion localRotation => transform.localRotation;
	public Transform setLocalRotation(Quaternion localRotation, bool boolean = true)
		=> transform.setLocalRotation(localRotation, boolean);
	public Transform setLocalRotation(Transform otherTransform, bool boolean = true)
		=> transform.setLocalRotation(otherTransform, boolean);
	public Transform setLocalRotation(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalRotation(otherGameObject, boolean);
	public Transform setLocalRotation(Component otherComponent, bool boolean = true)
		=> transform.setLocalRotation(otherComponent, boolean);
	public Transform resetLocalRotation(bool boolean = true)
		=> transform.resetLocalRotation(boolean);

	public Vector3 localEulerAngles => transform.localEulerAngles;
	public Transform setLocalEulerAngles(Vector3 localEulerAngles, bool boolean = true)
		=> transform.setLocalEulerAngles(localEulerAngles, boolean);
	public Transform setLocalEulerAngles(Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAngles(otherTransform, boolean);
	public Transform setLocalEulerAngles(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalEulerAngles(otherGameObject, boolean);
	public Transform setLocalEulerAngles(Component otherComponent, bool boolean = true)
		=> transform.setLocalEulerAngles(otherComponent, boolean);
	public Transform resetLocalEulerAngles(bool boolean = true)
		=> transform.resetLocalEulerAngles(boolean);

	public float localEulerAngleX => transform.localEulerAngleX();
	public Transform setLocalEulerAngleX(float localEulerAngleX, bool boolean = true)
		=> transform.setLocalEulerAngleX(localEulerAngleX, boolean);
	public Transform setLocalEulerAngleX(Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAngleX(otherTransform, boolean);
	public Transform setLocalEulerAngleX(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalEulerAngleX(otherGameObject, boolean);
	public Transform setLocalEulerAngleX(Component otherComponent, bool boolean = true)
		=> transform.setLocalEulerAngleX(otherComponent, boolean);
	public Transform resetLocalEulerAngleX(bool boolean = true)
		=> transform.resetLocalEulerAngleX(boolean);

	public float localEulerAngleY => transform.localEulerAngleY();
	public Transform setLocalEulerAngleY(float localEulerAngleY, bool boolean = true)
		=> transform.setLocalEulerAngleY(localEulerAngleY, boolean);
	public Transform setLocalEulerAngleY(Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAngleY(otherTransform, boolean);
	public Transform setLocalEulerAngleY(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalEulerAngleY(otherGameObject, boolean);
	public Transform setLocalEulerAngleY(Component otherComponent, bool boolean = true)
		=> transform.setLocalEulerAngleY(otherComponent, boolean);
	public Transform resetLocalEulerAngleY(bool boolean = true)
		=> transform.resetLocalEulerAngleY(boolean);

	public float localEulerAngleZ => transform.localEulerAngleZ();
	public Transform setLocalEulerAngleZ(float localEulerAngleZ, bool boolean = true)
		=> transform.setLocalEulerAngleZ(localEulerAngleZ, boolean);
	public Transform setLocalEulerAngleZ(Transform otherTransform, bool boolean = true)
		=> transform.setLocalEulerAngleZ(otherTransform, boolean);
	public Transform setLocalEulerAngleZ(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalEulerAngleZ(otherGameObject, boolean);
	public Transform setLocalEulerAngleZ(Component otherComponent, bool boolean = true)
		=> transform.setLocalEulerAngleZ(otherComponent, boolean);
	public Transform resetLocalEulerAngleZ(bool boolean = true)
		=> transform.resetLocalEulerAngleZ(boolean);

	public Vector3 localScale => transform.localScale;
	public Transform setLocalScale(Vector3 localScale, bool boolean = true)
		=> transform.setLocalScale(localScale, boolean);
	public Transform setLocalScale(Transform otherTransform, bool boolean = true)
		=> transform.setLocalScale(otherTransform, boolean);
	public Transform setLocalScale(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalScale(otherGameObject, boolean);
	public Transform setLocalScale(Component otherComponent, bool boolean = true)
		=> transform.setLocalScale(otherComponent, boolean);
	public Transform resetLocalScale(bool boolean = true)
		=> transform.resetLocalScale(boolean);

	public float localScaleX => transform.localScale.x;
	public Transform setLocalScaleX(float x, bool boolean = true)
		=> transform.setLocalScaleX(x, boolean);
	public Transform setLocalScaleX(Transform otherTransform, bool boolean = true)
		=> transform.setLocalScaleX(otherTransform, boolean);
	public Transform setLocalScaleX(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalScaleX(otherGameObject, boolean);
	public Transform setLocalScaleX(Component otherComponent, bool boolean = true)
		=> transform.setLocalScaleX(otherComponent, boolean);
	public Transform resetLocalScaleX(bool boolean = true)
		=> transform.resetLocalScaleX(boolean);

	public float localScaleY => transform.localScale.y;
	public Transform setLocalScaleY(float y, bool boolean = true)
		=> transform.setLocalScaleY(y, boolean);
	public Transform setLocalScaleY(Transform otherTransform, bool boolean = true)
		=> transform.setLocalScaleY(otherTransform, boolean);
	public Transform setLocalScaleY(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalScaleY(otherGameObject, boolean);
	public Transform setLocalScaleY(Component otherComponent, bool boolean = true)
		=> transform.setLocalScaleY(otherComponent, boolean);
	public Transform resetLocalScaleY(bool boolean = true)
		=> transform.resetLocalScaleY(boolean);

	public float localScaleZ => transform.localScale.z;
	public Transform setLocalScaleZ(float z, bool boolean = true)
		=> transform.setLocalScaleZ(z, boolean);
	public Transform setLocalScaleZ(Transform otherTransform, bool boolean = true)
		=> transform.setLocalScaleZ(otherTransform, boolean);
	public Transform setLocalScaleZ(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalScaleZ(otherGameObject, boolean);
	public Transform setLocalScaleZ(Component otherComponent, bool boolean = true)
		=> transform.setLocalScaleZ(otherComponent, boolean);
	public Transform resetLocalScaleZ(bool boolean = true)
		=> transform.resetLocalScaleZ(boolean);
	
	public Transform setLocals(Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> transform.setLocals(localPosition, localRotation, localScale, boolean);
	public Transform setLocals(Transform otherTransform, bool boolean = true)
		=> transform.setLocals(otherTransform, boolean);
	public Transform setLocals(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocals(otherGameObject, boolean);
	public Transform setLocals(Component otherComponent, bool boolean = true)
		=> transform.setLocals(otherComponent, boolean);
	public Transform resetLocals(bool boolean = true)
		=> transform.resetLocals(boolean);

	public Transform setLocals(Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> transform.setLocals(localPosition, localEulerAngles, localScale, boolean);
	
	public Transform setLocals(Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> transform.setLocals(localPosition, localRotation, boolean);
	
	public Transform setLocals(Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> transform.setLocals(localRotation, localScale, boolean);
	
	public Transform setLocalsParentlyForRelativeTo(Transform otherTransform, bool boolean = true)
		=> transform.setLocalsParentlyForRelativeTo(otherTransform, boolean);
	public Transform setLocalsParentlyForRelativeTo(GameObject otherGameObject, bool boolean = true)
		=> transform.setLocalsParentlyForRelativeTo(otherGameObject, boolean);
	public Transform setLocalsParentlyForRelativeTo(Component otherComponent, bool boolean = true)
		=> transform.setLocalsParentlyForRelativeTo(otherComponent, boolean);
	public Transform setLocalsParentlyForRelativeTo<SingletonBehaviourT>(bool boolean = true) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> transform.setLocalsParentlyForRelativeTo<SingletonBehaviourT>(boolean);

	public Vector3 position => transform.position;
	public Transform setPosition(Vector3 position, bool boolean = true)
		=> transform.setPosition(position, boolean);
	public Transform setPosition(Transform otherTransform, bool boolean = true)
		=> transform.setPosition(otherTransform, boolean);
	public Transform setPosition(GameObject otherGameObject, bool boolean = true)
		=> transform.setPosition(otherGameObject, boolean);
	public Transform setPosition(Component otherComponent, bool boolean = true)
		=> transform.setPosition(otherComponent, boolean);
	public Transform resetPosition(bool boolean = true)
		=> transform.resetPosition(boolean);

	public float positionX => transform.position.x;
	public Transform setPositionX(float x, bool boolean = true)
		=> transform.setPositionX(x, boolean);
	public Transform setPositionX(Transform otherTransform, bool boolean = true)
		=> transform.setPositionX(otherTransform, boolean);
	public Transform setPositionX(GameObject otherGameObject, bool boolean = true)
		=> transform.setPositionX(otherGameObject, boolean);
	public Transform setPositionX(Component otherComponent, bool boolean = true)
		=> transform.setPositionX(otherComponent, boolean);
	public Transform resetPositionX(bool boolean = true)
		=> transform.resetPositionX(boolean);

	public float positionY => transform.position.y;
	public Transform setPositionY(float y, bool boolean = true)
		=> transform.setPositionY(y, boolean);
	public Transform setPositionY(Transform otherTransform, bool boolean = true)
		=> transform.setPositionY(otherTransform, boolean);
	public Transform setPositionY(GameObject otherGameObject, bool boolean = true)
		=> transform.setPositionY(otherGameObject, boolean);
	public Transform setPositionY(Component otherComponent, bool boolean = true)
		=> transform.setPositionY(otherComponent, boolean);
	public Transform resetPositionY(bool boolean = true)
		=> transform.resetPositionY(boolean);

	public float positionZ => transform.position.z;
	public Transform setPositionZ(float z, bool boolean = true)
		=> transform.setPositionZ(z, boolean);
	public Transform setPositionZ(Transform otherTransform, bool boolean = true)
		=> transform.setPositionZ(otherTransform, boolean);
	public Transform setPositionZ(GameObject otherGameObject, bool boolean = true)
		=> transform.setPositionZ(otherGameObject, boolean);
	public Transform setPositionZ(Component otherComponent, bool boolean = true)
		=> transform.setPositionZ(otherComponent, boolean);
	public Transform resetPositionZ(bool boolean = true)
		=> transform.resetPositionZ(boolean);

	public Quaternion rotation => transform.rotation;
	public Transform setRotation(Quaternion rotation, bool boolean = true)
		=> transform.setRotation(rotation, boolean);
	public Transform setRotation(Transform otherTransform, bool boolean = true)
		=> transform.setRotation(otherTransform, boolean);
	public Transform setRotation(GameObject otherGameObject, bool boolean = true)
		=> transform.setRotation(otherGameObject, boolean);
	public Transform setRotation(Component otherComponent, bool boolean = true)
		=> transform.setRotation(otherComponent, boolean);
	public Transform resetRotation(bool boolean = true)
		=> transform.resetRotation(boolean);

	public Vector3 eulerAngles => transform.eulerAngles;
	public Transform setEulerAngles(Vector3 eulerAngles, bool boolean = true)
		=> transform.setEulerAngles(eulerAngles, boolean);
	public Transform setEulerAngles(Transform otherTransform, bool boolean = true)
		=> transform.setEulerAngles(otherTransform, boolean);
	public Transform setEulerAngles(GameObject otherGameObject, bool boolean = true)
		=> transform.setEulerAngles(otherGameObject, boolean);
	public Transform setEulerAngles(Component otherComponent, bool boolean = true)
		=> transform.setEulerAngles(otherComponent, boolean);
	public Transform resetEulerAngles(bool boolean = true)
		=> transform.resetEulerAngles(boolean);

	public float eulerAngleX => transform.eulerAngleX();
	public Transform setEulerAngleX(float eulerAngleX, bool boolean = true)
		=> transform.setEulerAngleX(eulerAngleX, boolean);
	public Transform setEulerAngleX(Transform otherTransform, bool boolean = true)
		=> transform.setEulerAngleX(otherTransform, boolean);
	public Transform setEulerAngleX(GameObject otherGameObject, bool boolean = true)
		=> transform.setEulerAngleX(otherGameObject, boolean);
	public Transform setEulerAngleX(Component otherComponent, bool boolean = true)
		=> transform.setEulerAngleX(otherComponent, boolean);
	public Transform resetEulerAngleX(bool boolean = true)
		=> transform.resetEulerAngleX(boolean);

	public float eulerAngleY => transform.eulerAngleY();
	public Transform setEulerAngleY(float eulerAngleY, bool boolean = true)
		=> transform.setEulerAngleY(eulerAngleY, boolean);
	public Transform setEulerAngleY(Transform otherTransform, bool boolean = true)
		=> transform.setEulerAngleY(otherTransform, boolean);
	public Transform setEulerAngleY(GameObject otherGameObject, bool boolean = true)
		=> transform.setEulerAngleY(otherGameObject, boolean);
	public Transform setEulerAngleY(Component otherComponent, bool boolean = true)
		=> transform.setEulerAngleY(otherComponent, boolean);
	public Transform resetEulerAngleY(bool boolean = true)
		=> transform.resetEulerAngleY(boolean);

	public float eulerAngleZ => transform.eulerAngleZ();
	public Transform setEulerAngleZ(float eulerAngleZ, bool boolean = true)
		=> transform.setEulerAngleZ(eulerAngleZ, boolean);
	public Transform setEulerAngleZ(Transform otherTransform, bool boolean = true)
		=> transform.setEulerAngleZ(otherTransform, boolean);
	public Transform setEulerAngleZ(GameObject otherGameObject, bool boolean = true)
		=> transform.setEulerAngleZ(otherGameObject, boolean);
	public Transform setEulerAngleZ(Component otherComponent, bool boolean = true)
		=> transform.setEulerAngleZ(otherComponent, boolean);
	public Transform resetEulerAngleZ(bool boolean = true)
		=> transform.resetEulerAngleZ(boolean);
	
	public Transform setGlobals(Vector3 position, Quaternion rotation, bool boolean = true)
		=> transform.setGlobals(position, rotation, boolean);
	public Transform setGlobals(Transform otherTransform, bool boolean = true)
		=> transform.setGlobals(otherTransform, boolean);
	public Transform setGlobals(GameObject otherGameObject, bool boolean = true)
		=> transform.setGlobals(otherGameObject, boolean);
	public Transform setGlobals(Component otherComponent, bool boolean = true)
		=> transform.setGlobals(otherComponent, boolean);
	public Transform resetGlobals(bool boolean = true)
		=> transform.resetGlobals(boolean);

	public Transform setGlobals(Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> transform.setGlobals(position, eulerAngles, boolean);
	
	public Transform setGlobalsAndLocalScale(Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> transform.setGlobalsAndLocalScale(position, rotation, localScale, boolean);
	public Transform setGlobalsAndLocalScale(Transform otherTransform, bool boolean = true)
		=> transform.setGlobalsAndLocalScale(otherTransform, boolean);
	public Transform setGlobalsAndLocalScale(GameObject otherGameObject, bool boolean = true)
		=> transform.setGlobalsAndLocalScale(otherGameObject, boolean);
	public Transform setGlobalsAndLocalScale(Component otherComponent, bool boolean = true)
		=> transform.setGlobalsAndLocalScale(otherComponent, boolean);
	public Transform resetGlobalsAndLocalScale(bool boolean = true)
		=> transform.resetGlobalsAndLocalScale(boolean);

	public Transform setGlobalsAndLocalScale(Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> transform.setGlobalsAndLocalScale(position, eulerAngles, localScale, boolean);
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
	#endregion distance
}