using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Transform:
// #auto #transform #force
// • provides this singleton behaviour with static access to its automatic behaviour's transform layer
public abstract class	SingletonBehaviourLayerTransform<SingletonBehaviourT> :
					SingletonBehaviourLayerTransformations<SingletonBehaviourT>
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


	#region euler rotation

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
	#endregion euler rotation


	#region flipping
	// method: (according to the given boolean:) have this behaviour's transform rotate by 180° on the respective axis, then return this behaviour's transform //

	public static new AutomaticBehaviour<SingletonBehaviourT> flipX(bool boolean = true)
		=> automaticBehaviour.flipX(boolean);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> flipY(bool boolean = true)
		=> automaticBehaviour.flipY(boolean);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> flipZ(bool boolean = true)
		=> automaticBehaviour.flipZ(boolean);
	#endregion flipping


	#region facing
	
	public static new AutomaticBehaviour<SingletonBehaviourT> face(Vector3 targetPosition, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> automaticBehaviour.face(targetPosition, withX, withY, withZ, boolean, upDirection_MaxOf1);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> face(Transform targetTransform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> automaticBehaviour.face(targetTransform, withX, withY, withZ, boolean, upDirection_MaxOf1);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> face(GameObject targetObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> automaticBehaviour.face(targetObject.transform, withX, withY, withZ, boolean, upDirection_MaxOf1);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> face(Component targetComponent, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> automaticBehaviour.face(targetComponent, withX, withY, withZ, boolean, upDirection_MaxOf1);
	
	public static new AutomaticBehaviour<SingletonBehaviourT> faceCamera(bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> automaticBehaviour.faceCamera(withX, withY, withZ, boolean, upDirection_MaxOf1);
	#endregion facing


	#region directions
	
	public static new Vector3 forwardLocal => automaticBehaviour.forwardLocal;
	
	public static new Vector3 backwardLocal => automaticBehaviour.backwardLocal;
	
	public static new Vector3 rightLocal => automaticBehaviour.rightLocal;
	
	public static new Vector3 leftLocal => automaticBehaviour.leftLocal;
	
	public static new Vector3 upLocal => automaticBehaviour.upLocal;
	
	public static new Vector3 downLocal => automaticBehaviour.downLocal;
	
	public static new Vector3 relativeDirectionFor(BasicDirection basicDirection)
		=> automaticBehaviour.relativeDirectionFor(basicDirection);
	#endregion directions


	#region direction distinctivity conversion

	// method: return the local direction relative to this behaviour's transform for this given global direction //
	public static new Vector3 localDirectionForGlobalDirection(Vector3 globalDirection)
		=> automaticBehaviour.localDirectionForGlobalDirection(globalDirection);

	// method: return the global direction for this given local direction relative to this behaviour's transform //
	public static new Vector3 globalDirectionForLocalDirection(Vector3 localDirection)
		=> automaticBehaviour.globalDirectionForLocalDirection(localDirection);
	#endregion direction distinctivity conversion


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


	#region position

	#region determining another position along the given direction
	public static new Vector3 positionAlong(Vector3 direction, float distance)
		=> automaticBehaviour.positionAlong(direction, distance);
	#endregion determining another position along the given direction
	#endregion position


	#region positional collision

	public static new HashSet<Collider> positionalColliders(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.positionalColliders(triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> positionalObjects(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.positionalObjects(triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> positionalRigidbodies(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1);
	#endregion positional collision


	#region raycasting for all results (not just the first hit)

	public static new HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.allNonpositionallyRaycastedHitsAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.allNonpositionallyRaycastedHitsAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Collider> allRaycastedCollidersAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.allRaycastedCollidersAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> allRaycastedCollidersAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.allRaycastedCollidersAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> allRaycastedObjectsAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.allRaycastedObjectsAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> allRaycastedObjectsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.allRaycastedObjectsAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> allRaycastedRigidbodiesAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.allRaycastedRigidbodiesAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.allRaycastedRigidbodiesAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for all results (not just the first hit)


	#region raycasting for just the first result

	public static new RaycastHit firstNonpositionallyRaycastedHitAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.firstNonpositionallyRaycastedHitAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new RaycastHit firstNonpositionallyRaycastedHitAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.firstNonpositionallyRaycastedHitAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new Collider firstNonpositionallyRaycastedColliderAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.firstNonpositionallyRaycastedColliderAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new Collider firstNonpositionallyRaycastedColliderAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.firstNonpositionallyRaycastedColliderAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new GameObject firstNonpositionallyRaycastedObjectAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.firstNonpositionallyRaycastedObjectAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new GameObject firstNonpositionallyRaycastedObjectAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.firstNonpositionallyRaycastedObjectAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.firstNonpositionallyRaycastedRigidbodyAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.firstNonpositionallyRaycastedRigidbodyAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for just the first result


	#region raycasting for however many results

	public static new HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.nonpositionallyRaycastedHitsAlong(direction, firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.nonpositionallyRaycastedHitsAlongLocal(localDirection, firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Collider> raycastedCollidersAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.raycastedCollidersAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Collider> raycastedCollidersAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.raycastedCollidersAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> raycastedObjectsAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.raycastedObjectsAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<GameObject> raycastedObjectsAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.raycastedObjectsAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> raycastedRigidbodiesAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.raycastedRigidbodiesAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public static new HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.raycastedRigidbodiesAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for however many results


	#region radial collision

	public static new HashSet<Collider> collidersWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.collidersWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> objectsWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.objectsWithin(radius, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<Rigidbody> rigidbodiesWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.rigidbodiesWithin(radius, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radial collision


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


	#region raycastedly forcing

	public static new HashSet<GameObject> forceRaycastedly(Tug tug, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	automaticBehaviour.forceRaycastedly
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
		=>	automaticBehaviour.pullAlong
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
		=>	automaticBehaviour.pushAlong
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
		=> automaticBehaviour.forceRadially(tug, magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> suck(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.suck(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public static new HashSet<GameObject> repulse(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> automaticBehaviour.repulse(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radially forcing
}