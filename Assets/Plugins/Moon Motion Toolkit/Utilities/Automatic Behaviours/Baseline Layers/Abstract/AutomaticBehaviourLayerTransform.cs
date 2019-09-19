using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Automatic Behaviour Layer Transform:
// #auto #transform
// • provides this behaviour with methods and automatically-connected properties for its transform
public abstract class	AutomaticBehaviourLayerTransform<AutomaticBehaviourT> :
					AutomaticBehaviourLayerTransformations<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
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
		=> component.anyChildren();

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

	public AutomaticBehaviourT destroyChild(int childIndex)
		=> selfAfter(()=> transform.destroyChild(childIndex));
	
	public AutomaticBehaviourT destroyChildIfItExists(int childIndex)
		=> selfAfter(()=> transform.destroyChildIfItExists(childIndex));
	
	public AutomaticBehaviourT destroyFirstChild()
		=> selfAfter(()=> transform.destroyFirstChild());
	
	public AutomaticBehaviourT destroyFirstChildIfItExists()
		=> selfAfter(()=> transform.destroyFirstChildIfItExists());
	
	public AutomaticBehaviourT destroyLastChild()
		=> selfAfter(()=> transform.destroyLastChild());
	
	public AutomaticBehaviourT destroyLastChildIfItExists()
		=> selfAfter(()=> transform.destroyLastChildIfItExists());
	
	public AutomaticBehaviourT destroyLastChildIfItExists<ComponentT>() where ComponentT : Component
		=> selfAfter(()=> transform.destroyLastChildIfItExists<ComponentT>());

	public AutomaticBehaviourT destroyChildren()
		=> selfAfter(()=> transform.destroyChildren());
	#endregion destroying children


	#region child iteration
	public AutomaticBehaviourT forEachChildTransform(Action<Transform> action)
		=> selfAfter(()=> transform.forEachChildTransform(action));
	public AutomaticBehaviourT setActivityOfChildrenTo(bool boolean)
		=> selfAfter(()=> transform.setActivityOfChildrenTo(boolean));
	public AutomaticBehaviourT activateChildren()
		=> selfAfter(()=> transform.activateChildren());
	public AutomaticBehaviourT deactivateChildren()
		=> selfAfter(()=> transform.deactivateChildren());
	#endregion child iteration


	#region euler rotation

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given (x, y, and z) rotation angles, then return this behaviour's transform //
	public AutomaticBehaviourT rotate(Vector3 rotationAngles, bool boolean = true)
		=> selfAfter(()=> transform.rotate(rotationAngles, boolean));

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x, y, and z rotation angles, then return this behaviour's transform //
	public AutomaticBehaviourT rotate(float x, float y, float z, bool boolean = true)
		=> selfAfter(()=> transform.rotate(x, y, z, boolean));

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given x rotation angle, then return this behaviour's transform //
	public AutomaticBehaviourT rotateX(float x, bool boolean = true)
		=> selfAfter(()=> transform.rotateZ(x, boolean));

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given y rotation angle, then return this behaviour's transform //
	public AutomaticBehaviourT rotateY(float y, bool boolean = true)
		=> selfAfter(()=> transform.rotateZ(y, boolean));

	// method: (according to the given boolean:) have this behaviour's transform rotate by the given z rotation angle, then return this behaviour's transform //
	public AutomaticBehaviourT rotateZ(float z, bool boolean = true)
		=> selfAfter(()=> transform.rotateZ(z, boolean));
	#endregion euler rotation


	#region flipping
	// methods: (according to the given boolean:) have this behaviour's transform rotate by 180° on the respective axis, then return this behaviour's transform //

	public AutomaticBehaviourT flipX(bool boolean = true)
		=> selfAfter(()=> transform.flipX(boolean));
	
	public AutomaticBehaviourT flipY(bool boolean = true)
		=> selfAfter(()=> transform.flipY(boolean));
	
	public AutomaticBehaviourT flipZ(bool boolean = true)
		=> selfAfter(()=> transform.flipZ(boolean));
	#endregion flipping


	#region facing
	
	public AutomaticBehaviourT face(Vector3 targetPosition, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> selfAfter(()=> transform.face(targetPosition, withX, withY, withZ, boolean, upDirection_MaxOf1));
	
	public AutomaticBehaviourT face(Transform targetTransform, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> selfAfter(()=> transform.face(targetTransform, withX, withY, withZ, boolean, upDirection_MaxOf1));
	
	public AutomaticBehaviourT face(GameObject targetObject, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> selfAfter(()=> transform.face(targetObject.transform, withX, withY, withZ, boolean, upDirection_MaxOf1));
	
	public AutomaticBehaviourT face(Component targetComponent, bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> selfAfter(()=> transform.face(targetComponent, withX, withY, withZ, boolean, upDirection_MaxOf1));
	
	public AutomaticBehaviourT faceCamera(bool withX = true, bool withY = true, bool withZ = true, bool boolean = true, params Vector3[] upDirection_MaxOf1)
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


	#region position

	#region determining another position along the given direction
	public Vector3 positionAlong(Vector3 direction, float distance)
		=> position.positionAlong(direction, distance);
	#endregion determining another position along the given direction
	#endregion position


	#region positional collision

	public HashSet<Collider> positionalColliders(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.positionalColliders(triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<GameObject> positionalObjects(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.positionalObjects(triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<Rigidbody> positionalRigidbodies(QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.positionalRigidbodies(triggerColliderQuery, layerMask_MaxOf1);
	#endregion positional collision


	#region raycasting for all results (not just the first hit)

	public HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.allNonpositionallyRaycastedHitsAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<RaycastHit> allNonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allNonpositionallyRaycastedHitsAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<Collider> allRaycastedCollidersAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.allRaycastedCollidersAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<Collider> allRaycastedCollidersAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allRaycastedCollidersAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<GameObject> allRaycastedObjectsAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.allRaycastedObjectsAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<GameObject> allRaycastedObjectsAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allRaycastedObjectsAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<Rigidbody> allRaycastedRigidbodiesAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.allRaycastedRigidbodiesAlong(direction, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<Rigidbody> allRaycastedRigidbodiesAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalColliders = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.allRaycastedRigidbodiesAlongLocal(localDirection, raycastDistance, ensureInclusionOfPositionalColliders, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for all results (not just the first hit)


	#region raycasting for just the first result

	public RaycastHit firstNonpositionallyRaycastedHitAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.firstNonpositionallyRaycastedHitAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public RaycastHit firstNonpositionallyRaycastedHitAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedHitAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public Collider firstNonpositionallyRaycastedColliderAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.firstNonpositionallyRaycastedColliderAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public Collider firstNonpositionallyRaycastedColliderAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedColliderAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public GameObject firstNonpositionallyRaycastedObjectAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.firstNonpositionallyRaycastedObjectAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public GameObject firstNonpositionallyRaycastedObjectAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedObjectAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public Rigidbody firstNonpositionallyRaycastedRigidbodyAlong(Vector3 direction, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.firstNonpositionallyRaycastedRigidbodyAlong(direction, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public Rigidbody firstNonpositionallyRaycastedRigidbodyAlongLocal(Vector3 localDirection, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.firstNonpositionallyRaycastedRigidbodyAlongLocal(localDirection, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for just the first result


	#region raycasting for however many results

	public HashSet<RaycastHit> nonpositionallyRaycastedHitsAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.nonpositionallyRaycastedHitsAlong(direction, firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<RaycastHit> nonpositionallyRaycastedHitsAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.nonpositionallyRaycastedHitsAlongLocal(localDirection, firstHitOnly, raycastDistance, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<Collider> raycastedCollidersAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.raycastedCollidersAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<Collider> raycastedCollidersAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.raycastedCollidersAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<GameObject> raycastedObjectsAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.raycastedObjectsAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<GameObject> raycastedObjectsAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.raycastedObjectsAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<Rigidbody> raycastedRigidbodiesAlong(Vector3 direction, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.raycastedRigidbodiesAlong(direction, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	public HashSet<Rigidbody> raycastedRigidbodiesAlongLocal(Vector3 localDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float raycastDistance = Default.raycastingDistance, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> transform.raycastedRigidbodiesAlongLocal(localDirection, firstHitOnly, raycastDistance, ensureInclusionOfPositionalCollidersIfNotFirstHitOnly, triggerColliderQuery, layerMask_MaxOf1);
	#endregion raycasting for however many results


	#region radial collision

	public HashSet<Collider> collidersWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.collidersWithin(radius, triggerColliderQuery, layerMask_MaxOf1);
	
	public HashSet<GameObject> objectsWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.objectsWithin(radius, triggerColliderQuery, layerMask_MaxOf1);
	
	public HashSet<Rigidbody> rigidbodiesWithin(float radius, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.rigidbodiesWithin(radius, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radial collision


	#region targetedly forcing

	public AutomaticBehaviourT forceTarget(dynamic targetRigidbodies_RigidbodiesProvider, Tug tug, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, AutomaticBehaviourT>(targetRigidbodies =>
				selfAfter(()=> position.forceTarget(targetRigidbodies, tug, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp))));

	public AutomaticBehaviourT attract(dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, AutomaticBehaviourT>(targetRigidbodies =>
				selfAfter(()=>
					position.attract(targetRigidbodies, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp))));

	public AutomaticBehaviourT repel(dynamic targetRigidbodies_RigidbodiesProvider, float magnitude = Default.forceMagnitude, float reach = Default.forceReach, InterpolationCurve reachMagnitudeZeroingCurve = Default.forceCurve, bool zeroForceOutsideReach = Default.directionalForceZeroingOutsideReach, bool clamp = Default.directionalForceClamping)
		=>	Pass.rigidbodiesVia(targetRigidbodies_RigidbodiesProvider, new Func<IEnumerable<Rigidbody>, AutomaticBehaviourT>(targetRigidbodies =>
				selfAfter(()=>
					position.repel(targetRigidbodies, magnitude, reach, reachMagnitudeZeroingCurve, zeroForceOutsideReach, clamp))));
	#endregion targetedly forcing


	#region raycastedly forcing

	public HashSet<GameObject> forceRaycastedly(Tug tug, Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	position.forceRaycastedly
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

	public HashSet<GameObject> pullAlong(Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	position.pullAlong
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
	
	public HashSet<GameObject> pushAlong(Vector3 raycastDirection, bool firstHitOnly = Default.raycastingForcingFirstHitOnly, float magnitude = Default.forceMagnitude, float raycastDistance = Default.raycastingDistance, InterpolationCurve raycastDistanceMagnitudeZeroingCurve = Default.forceCurve, bool ensureInclusionOfPositionalCollidersIfNotFirstHitOnly = Default.raycastingEnsuranceOfInclusionOfPositionalColliders, QueryTriggerInteraction triggerColliderQuery = Default.raycastingTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=>	position.pushAlong
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

	public HashSet<GameObject> forceRadially(Tug tug, float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.forceRadially(tug, magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<GameObject> suck(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.suck(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);

	public HashSet<GameObject> repulse(float magnitude = Default.forceMagnitude, float radius = Default.forceRadius, InterpolationCurve radiusDistanceMagnitudeZeroingCurve = Default.forceCurve, QueryTriggerInteraction triggerColliderQuery = Default.radialTriggerColliderQuery, params LayerMask[] layerMask_MaxOf1)
		=> position.repulse(magnitude, radius, radiusDistanceMagnitudeZeroingCurve, triggerColliderQuery, layerMask_MaxOf1);
	#endregion radially forcing
}