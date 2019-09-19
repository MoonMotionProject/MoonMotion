using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Transform:
// #auto #transform #force
// • provides this singleton behaviour with static access to its auto behaviour's transform layer
public abstract class	SingletonBehaviourLayerTransform<SingletonBehaviourT> :
					SingletonBehaviourLayerTransformations<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region sibling indexing

	public static new int siblingIndex => autoBehaviour.siblingIndex;
	#endregion sibling indexing


	#region accessing siblings

	public static new IEnumerable<Transform> selectSiblingAndSelfTransforms => autoBehaviour.selectSiblingAndSelfTransforms;
	public static new Transform[] siblingAndSelfTransforms => autoBehaviour.siblingAndSelfTransforms;

	public static new IEnumerable<GameObject> selectSiblingAndSelfObjects => autoBehaviour.selectSiblingAndSelfObjects;
	public static new GameObject[] siblingAndSelfObjects => autoBehaviour.siblingAndSelfObjects;

	public static new IEnumerable<Transform> selectSiblingTransforms => autoBehaviour.selectSiblingTransforms;
	public static new IEnumerable<Transform> siblingTransforms => autoBehaviour.siblingTransforms;

	public static new IEnumerable<GameObject> selectSiblingObjects => autoBehaviour.selectSiblingObjects;
	public static new IEnumerable<GameObject> siblingObjects => autoBehaviour.siblingObjects;
	#endregion siblings


	#region descendants

	public static new bool isLocalToOrDescendantOf(Transform otherTransform)
		=> autoBehaviour.isLocalToOrDescendantOf(otherTransform);

	public static new bool isLocalToOrDescendantOf(GameObject otherGameObject)
		=> autoBehaviour.isLocalToOrDescendantOf(otherGameObject);

	public static new bool isLocalToOrDescendantOf(Component otherComponent)
		=> autoBehaviour.isLocalToOrDescendantOf(otherComponent);

	public static new bool isLocalToOrDescendantOf<OtherSingletonBehaviourT>() where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.isLocalToOrDescendantOf<OtherSingletonBehaviourT>();
	#endregion descendants


	#region parent

	public static new bool parentless => autoBehaviour.parentless;
	public static new Transform parent => autoBehaviour.parent;
	public static new Transform setParentTo(Transform parentTransform, bool boolean = true)
		=> autoBehaviour.setParentTo(parentTransform, boolean);
	public static new Transform setParentTo(GameObject parentObject, bool boolean = true)
		=> autoBehaviour.setParentTo(parentObject, boolean);
	public static new Transform setParentTo(Component parentComponent, bool boolean = true)
		=> autoBehaviour.setParentTo(parentComponent, boolean);
	public static new Transform setParentTo<ParentSingletonBehaviourT>(bool boolean = true) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> autoBehaviour.setParentTo<ParentSingletonBehaviourT>(boolean);
	public static new Transform unparent(bool boolean = true)
		=> autoBehaviour.unparent(boolean);
	#endregion parent


	#region pibling indexing

	public static new int piblingIndex => autoBehaviour.piblingIndex;
	#endregion pibling indexing


	#region accessing piblings

	public static new Transform piblingTransform(int piblingIndex)
		=> autoBehaviour.piblingTransform(piblingIndex);

	public static new Transform correspondingPiblingTransform => autoBehaviour.correspondingPiblingTransform;

	public static new GameObject piblingObject(int piblingIndex)
		=> autoBehaviour.piblingObject(piblingIndex);

	public static new Transform firstPiblingTransform => autoBehaviour.firstPiblingTransform;

	public static new GameObject firstPiblingObject => autoBehaviour.firstPiblingObject;

	public static new Transform lastPiblingTransform => autoBehaviour.lastPiblingTransform;

	public static new GameObject lastPiblingObject => autoBehaviour.lastPiblingObject;

	public static new IEnumerable<Transform> selectPiblingTransforms => autoBehaviour.selectPiblingTransforms;
	public static new Transform[] piblingTransforms => autoBehaviour.piblingTransforms;

	public static new IEnumerable<GameObject> selectPiblingObjects => autoBehaviour.selectPiblingObjects;
	public static new GameObject[] piblingObjects => autoBehaviour.piblingObjects;
	#endregion accessing piblings


	#region counting children

	public static new bool childless => autoBehaviour.childless;

	public static new bool anyChildren()
		=> autoBehaviour.anyChildren();

	public static new bool pluralChildren => autoBehaviour.pluralChildren;
	#endregion counting children


	#region accessing children

	public static new Transform childTransform(int childIndex)
		=> autoBehaviour.childTransform(childIndex);

	public static new GameObject childObject(int childIndex)
		=> autoBehaviour.childObject(childIndex);

	public static new Transform firstChildTransform => autoBehaviour.firstChildTransform;

	public static new GameObject firstChildObject => autoBehaviour.firstChildObject;

	public static new Transform lastChildTransform => autoBehaviour.lastChildTransform;

	public static new GameObject lastChildObject => autoBehaviour.lastChildObject;

	public static new IEnumerable<Transform> selectChildTransforms => autoBehaviour.selectChildTransforms();
	public static new Transform[] childTransforms => autoBehaviour.childTransforms;

	public static new IEnumerable<GameObject> selectChildObjects => autoBehaviour.selectChildObjects();
	public static new GameObject[] childObjects => autoBehaviour.childObjects;
	#endregion accessing children


	#region destroying children

	public static new AutoBehaviour<SingletonBehaviourT> destroyChild(int childIndex)
		=> autoBehaviour.destroyChild(childIndex);
	
	public static new AutoBehaviour<SingletonBehaviourT> destroyChildIfItExists(int childIndex)
		=> autoBehaviour.destroyChildIfItExists(childIndex);

	public static new AutoBehaviour<SingletonBehaviourT> destroyFirstChild()
		=> autoBehaviour.destroyFirstChild();

	public static new AutoBehaviour<SingletonBehaviourT> destroyFirstChildIfItExists()
		=> autoBehaviour.destroyFirstChildIfItExists();

	public static new AutoBehaviour<SingletonBehaviourT> destroyLastChild()
		=> autoBehaviour.destroyLastChild();

	public static new AutoBehaviour<SingletonBehaviourT> destroyLastChildIfItExists()
		=> autoBehaviour.destroyLastChildIfItExists();

	public static new AutoBehaviour<SingletonBehaviourT> destroyLastChildIfItExists<ComponentT>() where ComponentT : Component
		=> autoBehaviour.destroyLastChildIfItExists<ComponentT>();

	public static new AutoBehaviour<SingletonBehaviourT> destroyChildren()
		=> autoBehaviour.destroyChildren();
	#endregion destroying children


	#region child iteration
	public static new AutoBehaviour<SingletonBehaviourT> forEachChildTransform(Action<Transform> action)
		=> autoBehaviour.forEachChildTransform(action);
	public static new AutoBehaviour<SingletonBehaviourT> setActivityOfChildrenTo(bool boolean)
		=> autoBehaviour.setActivityOfChildrenTo(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> activateChildren()
		=> autoBehaviour.activateChildren();
	public static new AutoBehaviour<SingletonBehaviourT> deactivateChildren()
		=> autoBehaviour.deactivateChildren();
	#endregion child iteration


	#region euler rotation

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given (x, y, and z) rotation angles, then return this behaviour's transform //
	public static new AutoBehaviour<SingletonBehaviourT> rotate(Vector3 rotationAngles, bool boolean = true)
		=> autoBehaviour.rotate(rotationAngles, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x, y, and z rotation angles, then return this behaviour's transform //
	public static new AutoBehaviour<SingletonBehaviourT> rotate(float x, float y, float z, bool boolean = true)
		=> autoBehaviour.rotate(x, y, z, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x rotation angle, then return this behaviour's transform //
	public static new AutoBehaviour<SingletonBehaviourT> rotateX(float x, bool boolean = true)
		=> autoBehaviour.rotateZ(x, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given y rotation angle, then return this behaviour's transform //
	public static new AutoBehaviour<SingletonBehaviourT> rotateY(float y, bool boolean = true)
		=> autoBehaviour.rotateZ(y, boolean);

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given z rotation angle, then return this behaviour's transform //
	public static new AutoBehaviour<SingletonBehaviourT> rotateZ(float z, bool boolean = true)
		=> autoBehaviour.rotateZ(z, boolean);
	#endregion euler rotation


	#region flipping
	// method: (according to the given boolean:) have this behaviour's transform rotate by 180° on the respective axis, then return this behaviour's transform //

	public static new AutoBehaviour<SingletonBehaviourT> flipX(bool boolean = true)
		=> autoBehaviour.flipX(boolean);
	
	public static new AutoBehaviour<SingletonBehaviourT> flipY(bool boolean = true)
		=> autoBehaviour.flipY(boolean);
	
	public static new AutoBehaviour<SingletonBehaviourT> flipZ(bool boolean = true)
		=> autoBehaviour.flipZ(boolean);
	#endregion flipping


	#region facing
	
	public static new AutoBehaviour<SingletonBehaviourT> face(Vector3 targetPosition, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> autoBehaviour.face(targetPosition, withX, withY, withZ, boolean, upDirection_MaxOf1);
	
	public static new AutoBehaviour<SingletonBehaviourT> face(Transform targetTransform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> autoBehaviour.face(targetTransform, withX, withY, withZ, boolean, upDirection_MaxOf1);
	
	public static new AutoBehaviour<SingletonBehaviourT> face(GameObject targetObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> autoBehaviour.face(targetObject.transform, withX, withY, withZ, boolean, upDirection_MaxOf1);
	
	public static new AutoBehaviour<SingletonBehaviourT> face(Component targetComponent, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> autoBehaviour.face(targetComponent, withX, withY, withZ, boolean, upDirection_MaxOf1);
	
	public static new AutoBehaviour<SingletonBehaviourT> faceCamera(bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> autoBehaviour.faceCamera(withX, withY, withZ, boolean, upDirection_MaxOf1);
	#endregion facing


	#region directions
	
	public static new Vector3 forwardLocal => autoBehaviour.forwardLocal;
	
	public static new Vector3 backwardLocal => autoBehaviour.backwardLocal;
	
	public static new Vector3 rightLocal => autoBehaviour.rightLocal;
	
	public static new Vector3 leftLocal => autoBehaviour.leftLocal;
	
	public static new Vector3 upLocal => autoBehaviour.upLocal;
	
	public static new Vector3 downLocal => autoBehaviour.downLocal;
	
	public static new Vector3 relativeDirectionFor(BasicDirection basicDirection)
		=> autoBehaviour.relativeDirectionFor(basicDirection);
	#endregion directions


	#region direction distinctivity conversion

	// method: return the local direction relative to this behaviour's transform for this given global direction //
	public static new Vector3 localDirectionForGlobalDirection(Vector3 globalDirection)
		=> autoBehaviour.localDirectionForGlobalDirection(globalDirection);

	// method: return the global direction for this given local direction relative to this behaviour's transform //
	public static new Vector3 globalDirectionForLocalDirection(Vector3 localDirection)
		=> autoBehaviour.globalDirectionForLocalDirection(localDirection);
	#endregion direction distinctivity conversion


	#region distance

	// method: return the closest of the given positions to this behaviour's transform's position //
	public static new Vector3 closestOf(IEnumerable<Vector3> positions)
		=> autoBehaviour.closestOf(positions);
	// method: return the closest (by position) of the given transforms to this behaviour's transform //
	public static new Transform closestOf(IEnumerable<Transform> transforms)
		=> autoBehaviour.closestOf(transforms);
	// method: return the closest (by position) of the given game objects to this behaviour's transform //
	public static new GameObject closestOf(IEnumerable<GameObject> gameObjects)
		=> autoBehaviour.closestOf(gameObjects);

	// method: return the farthest of the given positions to this behaviour's transform's position //
	public static new Vector3 farthestOf(IEnumerable<Vector3> positions)
		=> autoBehaviour.farthestOf(positions);
	// method: return the farthest (by position) of the given transforms to this behaviour's transform //
	public static new Transform farthestOf(IEnumerable<Transform> transforms)
		=> autoBehaviour.farthestOf(transforms);
	// method: return the farthest (by position) of the given game objects to this behaviour's transform //
	public static new GameObject farthestOf(IEnumerable<GameObject> gameObjects)
		=> autoBehaviour.farthestOf(gameObjects);
	#endregion distance


	#region position

	#region determining another position along the given direction
	public static new Vector3 positionAlong(Vector3 direction, float distance)
		=> autoBehaviour.positionAlong(direction, distance);
	#endregion determining another position along the given direction
	#endregion position


	#region positional collision

	public static new HashSet<Collider> positionalColliders(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.positionalColliders(triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> positionalObjects(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.positionalObjects(triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> positionalRigidbodies(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1);
	#endregion positional collision


	#region raycasting for all results (not just the first hit)

	public static new HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allNonpositionallyRaycastedHitsAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allNonpositionallyRaycastedHitsAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Collider> allRaycastedCollidersAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedCollidersAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> allRaycastedCollidersAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedCollidersAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> allRaycastedObjectsAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedObjectsAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> allRaycastedObjectsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedObjectsAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> allRaycastedRigidbodiesAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedRigidbodiesAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.allRaycastedRigidbodiesAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for all results (not just the first hit)


	#region raycasting for just the first result

	public static new RaycastHit firstNonpositionallyRaycastedHitAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedHitAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new RaycastHit firstNonpositionallyRaycastedHitAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedHitAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new Collider firstNonpositionallyRaycastedColliderAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedColliderAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new Collider firstNonpositionallyRaycastedColliderAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedColliderAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new GameObject firstNonpositionallyRaycastedObjectAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedObjectAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new GameObject firstNonpositionallyRaycastedObjectAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedObjectAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedRigidbodyAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.firstNonpositionallyRaycastedRigidbodyAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for just the first result


	#region raycasting for however many results

	public static new HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.nonpositionallyRaycastedHitsAlong(direction, firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.nonpositionallyRaycastedHitsAlongLocal(localDirection, firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Collider> raycastedCollidersAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedCollidersAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> raycastedCollidersAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedCollidersAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> raycastedObjectsAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedObjectsAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> raycastedObjectsAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedObjectsAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> raycastedRigidbodiesAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedRigidbodiesAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.raycastedRigidbodiesAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for however many results


	#region radial collision

	public static new HashSet<Collider> collidersWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.collidersWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> objectsWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.objectsWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> rigidbodiesWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.rigidbodiesWithin(radius, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radial collision


	#region targetedly forcing

	public static new AutoBehaviour<SingletonBehaviourT> forceTarget(dynamic targetRigidbodies_RigidbodiesProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, AutoBehaviour<SingletonBehaviourT>>(targetRigidbodies =>
				autoBehaviour.forceTarget(targetRigidbodies, tug, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp)));

	public static new AutoBehaviour<SingletonBehaviourT> attract(dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, AutoBehaviour<SingletonBehaviourT>>(targetRigidbodies =>
				autoBehaviour.attract(targetRigidbodies, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp)));

	public static new AutoBehaviour<SingletonBehaviourT> repel(dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=> Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, AutoBehaviour<SingletonBehaviourT>>(targetRigidbodies =>
			   autoBehaviour.repel(targetRigidbodies, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp)));
	#endregion targetedly forcing


	#region raycastedly forcing

	public static new HashSet<GameObject> forceRaycastedly(Tug tug, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	autoBehaviour.forceRaycastedly
			(
				tug,
				raycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static new HashSet<GameObject> pullAlong(Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	autoBehaviour.pullAlong
			(
				raycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);

	public static new HashSet<GameObject> pushAlong(Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	autoBehaviour.pushAlong
			(
				raycastDirection,
				firstHitOnly,
				magnitude,
				raycastDistance,
				raycastDistanceMagnitudeZeroingCurve,
				ensureInclusionOfPositionalCollidersIfNotFirstHitOnly,
				triggerColliderQuery,
				layerMask_MaxOf1
			);
	#endregion raycastedly forcing


	#region radially forcing

	public static new HashSet<GameObject> forceRadially(Tug tug, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.forceRadially(tug, magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> suck(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.suck(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> repulse(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> autoBehaviour.repulse(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radially forcing
}