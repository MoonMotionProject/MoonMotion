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


	#region getting siblings

	public static new Transform[] siblingAndSelfTransforms => automaticBehaviour.siblingAndSelfTransforms;

	public static new GameObject[] siblingAndSelfObjects => automaticBehaviour.siblingAndSelfObjects;

	public static new IEnumerable<Transform> siblingTransforms => automaticBehaviour.siblingTransforms;

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
	public static new Transform setParent(Transform parentTransform, bool boolean = true)
		=> automaticBehaviour.setParent(parentTransform, boolean);
	public static new Transform setParent(GameObject parentObject, bool boolean = true)
		=> automaticBehaviour.setParent(parentObject, boolean);
	public static new Transform setParent(Component parentComponent, bool boolean = true)
		=> automaticBehaviour.setParent(parentComponent, boolean);
	public static new Transform setParent<ParentSingletonBehaviourT>(bool boolean = true) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> automaticBehaviour.setParent<ParentSingletonBehaviourT>(boolean);
	public static new Transform unparent(bool boolean = true)
		=> automaticBehaviour.unparent(boolean);
	#endregion parent


	#region pibling indexing

	public static new int piblingIndex => automaticBehaviour.piblingIndex;
	#endregion pibling indexing


	#region getting piblings

	public static new Transform piblingTransform(int piblingIndex)
		=> automaticBehaviour.piblingTransform(piblingIndex);

	public static new Transform correspondingPiblingTransform => automaticBehaviour.correspondingPiblingTransform;

	public static new GameObject piblingObject(int piblingIndex)
		=> automaticBehaviour.piblingObject(piblingIndex);

	public static new Transform firstPiblingTransform => automaticBehaviour.firstPiblingTransform;

	public static new GameObject firstPiblingObject => automaticBehaviour.firstPiblingObject;

	public static new Transform lastPiblingTransform => automaticBehaviour.lastPiblingTransform;

	public static new GameObject lastPiblingObject => automaticBehaviour.lastPiblingObject;

	public static new Transform[] piblingTransforms => automaticBehaviour.piblingTransforms;

	public static new GameObject[] piblingObjects => automaticBehaviour.piblingObjects;
	#endregion getting piblings


	#region counting children

	public static new bool childless => automaticBehaviour.childless;

	public static new bool anyChildren => automaticBehaviour.anyChildren;

	public static new bool pluralChildren => automaticBehaviour.pluralChildren;
	#endregion counting children


	#region getting children

	public static new Transform childTransform(int childIndex)
		=> automaticBehaviour.childTransform(childIndex);

	public static new GameObject childObject(int childIndex)
		=> automaticBehaviour.childObject(childIndex);

	public static new Transform firstChildTransform => automaticBehaviour.firstChildTransform;

	public static new GameObject firstChildObject => automaticBehaviour.firstChildObject;

	public static new Transform lastChildTransform => automaticBehaviour.lastChildTransform;

	public static new GameObject lastChildObject => automaticBehaviour.lastChildObject;

	public static new Transform[] childTransforms => automaticBehaviour.childTransforms;

	public static new GameObject[] childObjects => automaticBehaviour.childObjects;
	#endregion getting children


	#region destroying children

	public static new Transform destroyChild(int childIndex)
		=> automaticBehaviour.destroyChild(childIndex);
	
	public static new Transform destroyChildIfItExists(int childIndex)
		=> automaticBehaviour.destroyChildIfItExists(childIndex);

	public static new Transform destroyFirstChild()
		=> automaticBehaviour.destroyFirstChild();

	public static new Transform destroyFirstChildIfItExists()
		=> automaticBehaviour.destroyFirstChildIfItExists();

	public static new Transform destroyLastChild()
		=> automaticBehaviour.destroyLastChild();

	public static new Transform destroyLastChildIfItExists()
		=> automaticBehaviour.destroyLastChildIfItExists();

	public static new Transform destroyLastChildIfItExists<ComponentT>() where ComponentT : Component
		=> automaticBehaviour.destroyLastChildIfItExists<ComponentT>();

	public static new Transform destroyChildren()
		=> automaticBehaviour.destroyChildren();
	#endregion destroying children


	#region child iteration

	public static new Transform forEachChildTransform(Action<Transform> action)
		=> automaticBehaviour.forEachChildTransform(action);

	public static new Transform setActivityOfChildrenTo(bool boolean)
		=> automaticBehaviour.setActivityOfChildrenTo(boolean);
	#endregion child iteration


	#region transformations

	public static new Vector3 localPosition => automaticBehaviour.localPosition;
	public static new Transform setLocalPosition(Vector3 localPosition, bool boolean = true)
		=> automaticBehaviour.setLocalPosition(localPosition, boolean);
	public static new Transform setLocalPosition(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPosition(otherTransform, boolean);
	public static new Transform resetLocalPosition(bool boolean = true)
		=> automaticBehaviour.resetLocalPosition(boolean);


	public static new float localPositionX => automaticBehaviour.localPosition.x;
	public static new Transform setLocalPositionX(float x, bool boolean = true)
		=> automaticBehaviour.setLocalPositionX(x, boolean);
	public static new Transform setLocalPositionX(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPositionX(otherTransform, boolean);
	public static new Transform resetLocalPositionX(bool boolean = true)
		=> automaticBehaviour.resetLocalPositionX(boolean);

	public static new float localPositionY => automaticBehaviour.localPosition.y;
	public static new Transform setLocalPositionY(float y, bool boolean = true)
		=> automaticBehaviour.setLocalPositionY(y, boolean);
	public static new Transform setLocalPositionY(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPositionY(otherTransform, boolean);
	public static new Transform resetLocalPositionY(bool boolean = true)
		=> automaticBehaviour.resetLocalPositionY(boolean);

	public static new float localPositionZ => automaticBehaviour.localPosition.z;
	public static new Transform setLocalPositionZ(float z, bool boolean = true)
		=> automaticBehaviour.setLocalPositionZ(z, boolean);
	public static new Transform setLocalPositionZ(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalPositionZ(otherTransform, boolean);
	public static new Transform resetLocalPositionZ(bool boolean = true)
		=> automaticBehaviour.resetLocalPositionZ(boolean);

	public static new Quaternion localRotation => automaticBehaviour.localRotation;
	public static new Transform setLocalRotation(Quaternion localRotation, bool boolean = true)
		=> automaticBehaviour.setLocalRotation(localRotation, boolean);
	public static new Transform setLocalRotation(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalRotation(otherTransform, boolean);
	public static new Transform resetLocalRotation(bool boolean = true)
		=> automaticBehaviour.resetLocalRotation(boolean);

	public static new Vector3 localEulerAngles => automaticBehaviour.localEulerAngles;
	public static new Transform setLocalEulerAngles(Vector3 localEulerAngles, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngles(localEulerAngles, boolean);
	public static new Transform setLocalEulerAngles(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngles(otherTransform, boolean);
	public static new Transform resetLocalEulerAngles(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngles(boolean);

	public static new float localEulerAngleX => automaticBehaviour.localEulerAngleX;
	public static new Transform setLocalEulerAngleX(float localEulerAngleX, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleX(localEulerAngleX, boolean);
	public static new Transform setLocalEulerAngleX(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleX(otherTransform, boolean);
	public static new Transform resetLocalEulerAngleX(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngleX(boolean);

	public static new float localEulerAngleY => automaticBehaviour.localEulerAngleY;
	public static new Transform setLocalEulerAngleY(float localEulerAngleY, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleY(localEulerAngleY, boolean);
	public static new Transform setLocalEulerAngleY(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleY(otherTransform, boolean);
	public static new Transform resetLocalEulerAngleY(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngleY(boolean);

	public static new float localEulerAngleZ => automaticBehaviour.localEulerAngleZ;
	public static new Transform setLocalEulerAngleZ(float localEulerAngleZ, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleZ(localEulerAngleZ, boolean);
	public static new Transform setLocalEulerAngleZ(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalEulerAngleZ(otherTransform, boolean);
	public static new Transform resetLocalEulerAngleZ(bool boolean = true)
		=> automaticBehaviour.resetLocalEulerAngleZ(boolean);

	public static new Vector3 localScale => automaticBehaviour.localScale;
	public static new Transform setLocalScale(Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocalScale(localScale, boolean);
	public static new Transform setLocalScale(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScale(otherTransform, boolean);
	public static new Transform resetLocalScale(bool boolean = true)
		=> automaticBehaviour.resetLocalScale(boolean);

	public static new float localScaleX => automaticBehaviour.localScale.x;
	public static new Transform setLocalScaleX(float x, bool boolean = true)
		=> automaticBehaviour.setLocalScaleX(x, boolean);
	public static new Transform setLocalScaleX(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScaleX(otherTransform, boolean);
	public static new Transform resetLocalScaleX(bool boolean = true)
		=> automaticBehaviour.resetLocalScaleX(boolean);

	public static new float localScaleY => automaticBehaviour.localScale.y;
	public static new Transform setLocalScaleY(float y, bool boolean = true)
		=> automaticBehaviour.setLocalScaleY(y, boolean);
	public static new Transform setLocalScaleY(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScaleY(otherTransform, boolean);
	public static new Transform resetLocalScaleY(bool boolean = true)
		=> automaticBehaviour.resetLocalScaleY(boolean);

	public static new float localScaleZ => automaticBehaviour.localScale.z;
	public static new Transform setLocalScaleZ(float z, bool boolean = true)
		=> automaticBehaviour.setLocalScaleZ(z, boolean);
	public static new Transform setLocalScaleZ(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalScaleZ(otherTransform, boolean);
	public static new Transform resetLocalScaleZ(bool boolean = true)
		=> automaticBehaviour.resetLocalScaleZ(boolean);
	
	public static new Transform setLocals(Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocals(localPosition, localRotation, localScale, boolean);
	public static new Transform setLocals(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocals(otherTransform, boolean);
	public static new Transform resetLocals(bool boolean = true)
		=> automaticBehaviour.resetLocals(boolean);

	public static new Transform setLocals(Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocals(localPosition, localEulerAngles, localScale, boolean);
	
	public static new Transform setLocals(Vector3 localPosition, Quaternion localRotation, bool boolean = true)
		=> automaticBehaviour.setLocals(localPosition, localRotation, boolean);
	
	public static new Transform setLocals(Quaternion localRotation, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setLocals(localRotation, localScale, boolean);

	public static new Transform setLocalsParentlyForRelativeTo(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setLocalsParentlyForRelativeTo(otherTransform, boolean);
	public static new Transform setLocalsParentlyForRelativeTo(GameObject otherGameObject, bool boolean = true)
		=> automaticBehaviour.setLocalsParentlyForRelativeTo(otherGameObject, boolean);
	public static new Transform setLocalsParentlyForRelativeTo(Component otherComponent, bool boolean = true)
		=> automaticBehaviour.setLocalsParentlyForRelativeTo(otherComponent, boolean);
	public static new Transform setLocalsParentlyForRelativeTo<OtherSingletonBehaviourT>(bool boolean = true) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> automaticBehaviour.setLocalsParentlyForRelativeTo<OtherSingletonBehaviourT>(boolean);

	public static new Vector3 position => automaticBehaviour.position;
	public static new Transform setPosition(Vector3 position, bool boolean = true)
		=> automaticBehaviour.setPosition(position, boolean);
	public static new Transform setPosition(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPosition(otherTransform, boolean);
	public static new Transform resetPosition(bool boolean = true)
		=> automaticBehaviour.resetPosition(boolean);

	public static new float positionX => automaticBehaviour.position.x;
	public static new Transform setPositionX(float x, bool boolean = true)
		=> automaticBehaviour.setPositionX(x, boolean);
	public static new Transform setPositionX(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPositionX(otherTransform, boolean);
	public static new Transform resetPositionX(bool boolean = true)
		=> automaticBehaviour.resetPositionX(boolean);

	public static new float positionY => automaticBehaviour.position.y;
	public static new Transform setPositionY(float y, bool boolean = true)
		=> automaticBehaviour.setPositionY(y, boolean);
	public static new Transform setPositionY(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPositionY(otherTransform, boolean);
	public static new Transform resetPositionY(bool boolean = true)
		=> automaticBehaviour.resetPositionY(boolean);

	public static new float positionZ => automaticBehaviour.position.z;
	public static new Transform setPositionZ(float z, bool boolean = true)
		=> automaticBehaviour.setPositionZ(z, boolean);
	public static new Transform setPositionZ(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setPositionZ(otherTransform, boolean);
	public static new Transform resetPositionZ(bool boolean = true)
		=> automaticBehaviour.resetPositionZ(boolean);

	public static new Quaternion rotation => automaticBehaviour.rotation;
	public static new Transform setRotation(Quaternion rotation, bool boolean = true)
		=> automaticBehaviour.setRotation(rotation, boolean);
	public static new Transform setRotation(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setRotation(otherTransform, boolean);
	public static new Transform resetRotation(bool boolean = true)
		=> automaticBehaviour.resetRotation(boolean);

	public static new Vector3 eulerAngles => automaticBehaviour.eulerAngles;
	public static new Transform setEulerAngles(Vector3 eulerAngles, bool boolean = true)
		=> automaticBehaviour.setEulerAngles(eulerAngles, boolean);
	public static new Transform setEulerAngles(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAngles(otherTransform, boolean);
	public static new Transform resetEulerAngles(bool boolean = true)
		=> automaticBehaviour.resetEulerAngles(boolean);

	public static new float eulerAngleX => automaticBehaviour.eulerAngleX;
	public static new Transform setEulerAngleX(float eulerAngleX, bool boolean = true)
		=> automaticBehaviour.setEulerAngleX(eulerAngleX, boolean);
	public static new Transform setEulerAngleX(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAngleX(otherTransform, boolean);
	public static new Transform resetEulerAngleX(bool boolean = true)
		=> automaticBehaviour.resetEulerAngleX(boolean);

	public static new float eulerAngleY => automaticBehaviour.eulerAngleY;
	public static new Transform setEulerAngleY(float eulerAngleY, bool boolean = true)
		=> automaticBehaviour.setEulerAngleY(eulerAngleY, boolean);
	public static new Transform setEulerAngleY(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAngleY(otherTransform, boolean);
	public static new Transform resetEulerAngleY(bool boolean = true)
		=> automaticBehaviour.resetEulerAngleY(boolean);

	public static new float eulerAngleZ => automaticBehaviour.eulerAngleZ;
	public static new Transform setEulerAngleZ(float eulerAngleZ, bool boolean = true)
		=> automaticBehaviour.setEulerAngleZ(eulerAngleZ, boolean);
	public static new Transform setEulerAngleZ(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setEulerAngleZ(otherTransform, boolean);
	public static new Transform resetEulerAngleZ(bool boolean = true)
		=> automaticBehaviour.resetEulerAngleZ(boolean);
	
	public static new Transform setGlobals(Vector3 position, Quaternion rotation, bool boolean = true)
		=> automaticBehaviour.setGlobals(position, rotation, boolean);
	public static new Transform setGlobals(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setGlobals(otherTransform, boolean);
	public static new Transform resetGlobals(bool boolean = true)
		=> automaticBehaviour.resetGlobals(boolean);

	public static new Transform setGlobals(Vector3 position, Vector3 eulerAngles, bool boolean = true)
		=> automaticBehaviour.setGlobals(position, eulerAngles, boolean);
	
	public static new Transform setGlobalsAndLocalScale(Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setGlobalsAndLocalScale(position, rotation, localScale, boolean);
	public static new Transform setGlobalsAndLocalScale(Transform otherTransform, bool boolean = true)
		=> automaticBehaviour.setGlobalsAndLocalScale(otherTransform, boolean);
	public static new Transform resetGlobalsAndLocalScale(bool boolean = true)
		=> automaticBehaviour.resetGlobalsAndLocalScale(boolean);

	public static new Transform setGlobalsAndLocalScale(Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true)
		=> automaticBehaviour.setGlobalsAndLocalScale(position, eulerAngles, localScale, boolean);
	#endregion transformations


	#region advanced rotation

	// method: (according to the given boolean:) have this behaviour's transform look at the given target position, then return this behaviour's transform //
	public static new Transform lookAt(Vector3 targetPosition, bool boolean = true)
		=> automaticBehaviour.lookAt(targetPosition, boolean);

	// method: (according to the given boolean:) have this behaviour's transform look at the given target transform, then return this behaviour's transform //
	public static new Transform lookAt(Transform targetTransform, bool boolean = true)
		=> automaticBehaviour.lookAt(targetTransform, boolean);

	// method: (according to the given boolean:) have this behaviour's transform look at the given target transform, then return this behaviour's transform //
	public static new Transform lookAt(GameObject targetObject, bool boolean = true)
		=> automaticBehaviour.lookAt(targetObject.transform, boolean);

	// method: (according to the given boolean:) have this behaviour's transform look at the given target component's transform, then return this behaviour's transform //
	public static new Transform lookAt(Component targetComponent, bool boolean = true)
		=> automaticBehaviour.lookAt(targetComponent, boolean);

	// method: (according to the given boolean:) have this given transform look at the main camera, then return this given transform //
	public static new Transform lookAtCamera(bool boolean = true)
		=> automaticBehaviour.lookAtCamera(boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given (x, y, and z) rotation angles, then return this behaviour's transform //
	public static new Transform rotate(Vector3 rotationAngles, bool boolean = true)
		=> automaticBehaviour.rotate(rotationAngles, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x, y, and z rotation angles, then return this behaviour's transform //
	public static new Transform rotate(float x, float y, float z, bool boolean = true)
		=> automaticBehaviour.rotate(x, y, z, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x rotation angle, then return this behaviour's transform //
	public static new Transform rotateX(float x, bool boolean = true)
		=> automaticBehaviour.rotateZ(x, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given y rotation angle, then return this behaviour's transform //
	public static new Transform rotateY(float y, bool boolean = true)
		=> automaticBehaviour.rotateZ(y, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given z rotation angle, then return this behaviour's transform //
	public static new Transform rotateZ(float z, bool boolean = true)
		=> automaticBehaviour.rotateZ(z, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by 180° on the x axis, then return this behaviour's transform //
	public static new Transform flipX(bool boolean = true)
		=> automaticBehaviour.flipX(boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by 180° on the y axis, then return this behaviour's transform //
	public static new Transform flipY(bool boolean = true)
		=> automaticBehaviour.flipY(boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by 180° on the z axis, then return this behaviour's transform //
	public static new Transform flipZ(bool boolean = true)
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

	// method: return the vector for the given direction relative to this transform //
	public static new Vector3 vectorForRelativeDirection(Direction direction)
		=> automaticBehaviour.vectorForRelativeDirection(direction);
	#endregion directions


	#region distance

	// method: return the closest (by position) of the given game objects to this behaviour's transform //
	public static new GameObject closestOf(IEnumerable<GameObject> gameObjects)
		=> automaticBehaviour.closestOf(gameObjects);

	// method: return the closest (by position) of the given transforms to this behaviour's transform //
	public static new Transform closestOf(IEnumerable<Transform> transforms)
		=> automaticBehaviour.closestOf(transforms);

	// method: return the closest of the given positions to this behaviour's transform's position //
	public static new Vector3 closestOf(IEnumerable<Vector3> positions)
		=> automaticBehaviour.closestOf(positions);

	// method: return the farthest (by position) of the given game objects to this behaviour's transform //
	public static new GameObject farthestOf(IEnumerable<GameObject> gameObjects)
		=> automaticBehaviour.farthestOf(gameObjects);

	// method: return the farthest (by position) of the given transforms to this behaviour's transform //
	public static new Transform farthestOf(IEnumerable<Transform> transforms)
		=> automaticBehaviour.farthestOf(transforms);

	// method: return the farthest of the given positions to this behaviour's transform's position //
	public static new Vector3 farthestOf(IEnumerable<Vector3> positions)
		=> automaticBehaviour.farthestOf(positions);
	#endregion distance
}