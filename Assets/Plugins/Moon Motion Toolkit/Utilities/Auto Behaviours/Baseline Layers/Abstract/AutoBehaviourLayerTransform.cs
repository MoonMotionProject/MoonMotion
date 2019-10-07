using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Auto Behaviour Layer Transform:
// #auto #transform
// • provides this behaviour with methods and automatically-connected properties for its transform
public abstract class	AutoBehaviourLayerTransform<AutoBehaviourT> :
					AutoBehaviourLayerTransformations<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region transform

	public new Transform transform => inheritorHasAttribute<CacheTransformAttribute>() ? cache<Transform>() : component.transform;     // the transform property is only worth caching (since that takes up memory) when accessed a lot, like every frame in Update, so that property only uses caching according to the respective attribute; see https://forum.unity.com/threads/cache-transform-really-needed.356875/ for discussion of this //
	#endregion transform


	#region sibling indexing

	public int siblingIndex => transform.siblingIndex();
	#endregion sibling indexing


	#region accessing siblings

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


	#region accessing piblings

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
	#endregion accessing piblings


	#region counting children

	public bool childless => component.childless();

	public bool anyChildren()
		=> component.hasAnyChildren();

	public bool pluralChildren => component.pluralChildren();
	#endregion counting children


	#region accessing children

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
	#endregion accessing children


	#region destroying children

	public AutoBehaviourT destroyChild(int childIndex)
		=> selfAfter(()=> transform.destroyChild(childIndex));
	
	public AutoBehaviourT destroyChildIfItExists(int childIndex)
		=> selfAfter(()=> transform.destroyChildIfItExists(childIndex));
	
	public AutoBehaviourT destroyFirstChild()
		=> selfAfter(()=> transform.destroyFirstChild());
	
	public AutoBehaviourT destroyFirstChildIfItExists()
		=> selfAfter(()=> transform.destroyFirstChildIfItExists());
	
	public AutoBehaviourT destroyLastChild()
		=> selfAfter(()=> transform.destroyLastChild());
	
	public AutoBehaviourT destroyLastChildIfItExists()
		=> selfAfter(()=> transform.destroyLastChildIfItExists());
	
	public AutoBehaviourT destroyLastChildIfItExists<ComponentT>() where ComponentT : Component
		=> selfAfter(()=> transform.destroyLastChildIfItExists<ComponentT>());

	public AutoBehaviourT destroyChildren()
		=> selfAfter(()=> transform.destroyChildren());
	#endregion destroying children


	#region child iteration
	public AutoBehaviourT forEachChildTransform(Action<Transform> action)
		=> selfAfter(()=> transform.forEachChildTransform(action));
	public AutoBehaviourT setActivityOfChildrenTo(bool boolean)
		=> selfAfter(()=> transform.setActivityOfChildrenTo(boolean));
	public AutoBehaviourT activateChildren()
		=> selfAfter(()=> transform.activateChildren());
	public AutoBehaviourT deactivateChildren()
		=> selfAfter(()=> transform.deactivateChildren());
	#endregion child iteration


	#region euler rotation

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given (x, y, and z) rotation angles, then return this behaviour's transform //
	public AutoBehaviourT rotate(Vector3 rotationAngles, bool boolean = true)
		=> selfAfter(()=> transform.rotate(rotationAngles, boolean));

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x, y, and z rotation angles, then return this behaviour's transform //
	public AutoBehaviourT rotate(float x, float y, float z, bool boolean = true)
		=> selfAfter(()=> transform.rotate(x, y, z, boolean));

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x rotation angle, then return this behaviour's transform //
	public AutoBehaviourT rotateX(float x, bool boolean = true)
		=> selfAfter(()=> transform.rotateZ(x, boolean));

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given y rotation angle, then return this behaviour's transform //
	public AutoBehaviourT rotateY(float y, bool boolean = true)
		=> selfAfter(()=> transform.rotateZ(y, boolean));

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given z rotation angle, then return this behaviour's transform //
	public AutoBehaviourT rotateZ(float z, bool boolean = true)
		=> selfAfter(()=> transform.rotateZ(z, boolean));
	#endregion euler rotation


	#region flipping
	// methods: (according to the given boolean:) have this behaviour's transform rotate by 180° on the respective axis, then return this behaviour's transform //

	public AutoBehaviourT flipX(bool boolean = true)
		=> selfAfter(()=> transform.flipX(boolean));
	
	public AutoBehaviourT flipY(bool boolean = true)
		=> selfAfter(()=> transform.flipY(boolean));
	
	public AutoBehaviourT flipZ(bool boolean = true)
		=> selfAfter(()=> transform.flipZ(boolean));
	#endregion flipping


	#region facing
	
	public AutoBehaviourT face(Vector3 targetPosition, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> selfAfter(()=> transform.face(targetPosition, withX, withY, withZ, boolean, upDirection_MaxOf1));
	
	public AutoBehaviourT face(Transform targetTransform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> selfAfter(()=> transform.face(targetTransform, withX, withY, withZ, boolean, upDirection_MaxOf1));
	
	public AutoBehaviourT face(GameObject targetObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> selfAfter(()=> transform.face(targetObject.transform, withX, withY, withZ, boolean, upDirection_MaxOf1));
	
	public AutoBehaviourT face(Component targetComponent, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> selfAfter(()=> transform.face(targetComponent, withX, withY, withZ, boolean, upDirection_MaxOf1));
	
	public AutoBehaviourT faceCamera(bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> selfAfter(()=> transform.faceCamera(withX, withY, withZ, boolean, upDirection_MaxOf1));
	#endregion facing


	#region directions
	
	public Vector3 forwardLocal => transform.forward();
	
	public Vector3 backwardLocal => transform.backward();
	
	public Vector3 rightLocal => transform.right();
	
	public Vector3 leftLocal => transform.left();
	
	public Vector3 upLocal => transform.up();
	
	public Vector3 downLocal => transform.down();
	
	public Vector3 relativeDirectionFor(BasicDirection basicDirection)
		=> transform.relativeDirectionFor(basicDirection);
	#endregion directions


	#region direction distinctivity conversion

	// method: return the local direction relative to this behaviour's transform for this given global direction //
	public Vector3 localDirectionForGlobalDirection(Vector3 globalDirection)
		=> globalDirection.asGlobalDirectionToLocalDirectionRelativeTo(transform);

	// method: return the global direction for this given local direction relative to this behaviour's transform //
	public Vector3 globalDirectionForLocalDirection(Vector3 localDirection)
		=> localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(transform);
	#endregion direction distinctivity conversion


	#region distance
	
	public float distanceWith(Vector3 otherPosition)
		=> position.distanceWith(otherPosition);
	public float distanceWith(Transform otherTransform)
		=> position.distanceWith(otherTransform);
	public float distanceWith(GameObject otherGameObject)
		=> position.distanceWith(otherGameObject);
	public float distanceWith(Component otherComponent)
		=> position.distanceWith(otherComponent);
	public float distanceWith(RaycastHit raycastHit)
		=> position.distanceWith(raycastHit);
	public float distanceWithCamera()
		=> position.distanceWithCamera();

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


	#region determining another position along the given direction

	public Vector3 positionAlong(Vector3 direction, float distance)
		=> position.positionAlong(direction, distance);
	#endregion determining another position along the given direction
}