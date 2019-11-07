using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Transform:
// #auto #transform #parent
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
	
	public static new bool hasAnyParent => autoBehaviour.hasAnyParent;
	public static new bool isParentless => autoBehaviour.isParentless;
	public static new bool parentIs(object potentialParentTransform_TransformProvider)
		=> autoBehaviour.parentIs(potentialParentTransform_TransformProvider);
	public static new bool parentIs<OtherSingletonBehaviourT>()
		where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.parentIs<OtherSingletonBehaviourT>();
	public static new bool parentIsNot(object potentialParentTransform_TransformProvider)
		=> autoBehaviour.parentIsNot(potentialParentTransform_TransformProvider);
	public static new bool parentIsNot<OtherSingletonBehaviourT>()
		where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.parentIsNot<OtherSingletonBehaviourT>();
	public static new Transform parent => autoBehaviour.parent;
	public static new GameObject parentObject => autoBehaviour.parentObject;
	public static new Transform setParentTo(object parentTransform_TransformProvider, bool boolean = true)
		=> autoBehaviour.setParentTo(parentTransform_TransformProvider, boolean);
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

	public static new bool isChildless => autoBehaviour.isChildless;

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


	#region accessing descendants
	
	public static new List<Transform> descendantTransforms => autoBehaviour.descendantTransforms;
	
	public static new List<GameObject> descendantObjects => autoBehaviour.descendantObjects;
	#endregion accessing descendants


	#region destroying descendants

	public static new AutoBehaviour<SingletonBehaviourT> destroyLastDescendantObjectWithComponentIfItExists<ComponentT>() where ComponentT : Component
		=> autoBehaviour.destroyLastDescendantObjectWithComponentIfItExists<ComponentT>();
	#endregion destroying descendants


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

	public static new AutoBehaviour<SingletonBehaviourT> faceWithY(object targetPosition_PositionProvider, bool boolean = true, params Vector3[] upDirection_MaxOf1)
		=> autoBehaviour.faceWithY(targetPosition_PositionProvider, boolean, upDirection_MaxOf1);
	#endregion facing


	#region displacement

	#region from other
	public static new Vector3 displacementFrom(object otherPosition_PositionProvider)
		=> autoBehaviour.displacementFrom(otherPosition_PositionProvider);
	public static new Vector3 displacementFrom<OtherSingletonBehaviourT>() where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.displacementFrom<OtherSingletonBehaviourT>();
	public static new Vector3 displacementFromCamera()
		=> autoBehaviour.displacementFromCamera();
	#endregion from other

	#region to other
	public static new Vector3 displacementTo(object otherPosition_PositionProvider)
		=> autoBehaviour.displacementTo(otherPosition_PositionProvider);
	public static new Vector3 displacementTo<OtherSingletonBehaviourT>() where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.displacementTo<OtherSingletonBehaviourT>();
	public static new Vector3 displacementToCamera()
		=> autoBehaviour.displacementToCamera();
	#endregion to other

	#region with displacement
	public static new Vector3 positionWithDisplacement(Vector3 displacement)
		=> autoBehaviour.positionWithDisplacement(displacement);
	#endregion with displacement
	#endregion displacement


	#region basic directions
	
	public static new Vector3 forwardLocal => autoBehaviour.forwardLocal;
	
	public static new Vector3 backwardLocal => autoBehaviour.backwardLocal;
	
	public static new Vector3 rightLocal => autoBehaviour.rightLocal;
	
	public static new Vector3 leftLocal => autoBehaviour.leftLocal;
	
	public static new Vector3 upLocal => autoBehaviour.upLocal;
	
	public static new Vector3 downLocal => autoBehaviour.downLocal;
	
	public static new Vector3 relativeDirectionFor(BasicDirection basicDirection)
		=> autoBehaviour.relativeDirectionFor(basicDirection);
	#endregion basic directions


	#region direction

	#region from other
	public static new Vector3 directionFrom(object otherPosition_PositionProvider)
		=> autoBehaviour.directionFrom(otherPosition_PositionProvider);
	public static new Vector3 directionFrom<OtherSingletonBehaviourT>() where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.directionFrom<OtherSingletonBehaviourT>();
	public static new Vector3 directionFromCamera()
		=> autoBehaviour.directionFromCamera();
	#endregion from other

	#region to other
	public static new Vector3 directionTo(object otherPosition_PositionProvider)
		=> autoBehaviour.directionTo(otherPosition_PositionProvider);
	public static new Vector3 directionTo<OtherSingletonBehaviourT>() where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.directionTo<OtherSingletonBehaviourT>();
	public static new Vector3 directionToCamera()
		=> autoBehaviour.directionToCamera();
	#endregion to other

	#region direction distinctivity conversion
	// method: return the local direction relative to this behaviour's transform for this given global direction //
	public static new Vector3 localDirectionForGlobalDirection(Vector3 globalDirection)
		=> autoBehaviour.localDirectionForGlobalDirection(globalDirection);
	// method: return the global direction for this given local direction relative to this behaviour's transform //
	public static new Vector3 globalDirectionForLocalDirection(Vector3 localDirection)
		=> autoBehaviour.globalDirectionForLocalDirection(localDirection);
	#endregion direction distinctivity conversion
	#endregion direction
	

	#region directionality

	#region directionality same toward both
	public static new bool directionalitySameTowardBoth(object firstOtherPosition_PositionProvider, object secondOtherPosition_PositionProvider)
		=>	autoBehaviour.directionalitySameTowardBoth
			(
				firstOtherPosition_PositionProvider,
				secondOtherPosition_PositionProvider
			);
	public static new bool directionalitySameTowardBoth<OtherSingletonBehaviourT>(object secondOtherPosition_PositionProvider) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=>	autoBehaviour.directionalitySameTowardBoth<OtherSingletonBehaviourT>(secondOtherPosition_PositionProvider);
	#endregion directionality same toward both
	#endregion directionality


	#region distance

	#region distance with
	public static new float distanceWith(Vector3 otherPosition)
		=> autoBehaviour.distanceWith(otherPosition);
	public static new float distanceWith(object otherPosition_PositionProvider)
		=> autoBehaviour.distanceWith(otherPosition_PositionProvider);
	public static new float distanceWith<OtherSingletonBehaviourT>() where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.distanceWith<OtherSingletonBehaviourT>();
	public static new float distanceWithCamera()
		=> autoBehaviour.distanceWithCamera();
	#endregion distance with

	#region nearest of
	public static new Vector3 nearestOf(IEnumerable<Vector3> positions)
		=> autoBehaviour.nearestOf(positions);
	public static new ComponentT nearestOf<ComponentT>(IEnumerable<ComponentT> components) where ComponentT : Component
		=> autoBehaviour.nearestOf(components);
	public static new GameObject nearestOf(IEnumerable<GameObject> gameObjects)
		=> autoBehaviour.nearestOf(gameObjects);
	public static new MonoBehaviourI nearestOfI<MonoBehaviourI>(IEnumerable<MonoBehaviourI> components) where MonoBehaviourI : class
		=> autoBehaviour.nearestOfI(components);
	#endregion nearest of

	#region farthest of
	public static new Vector3 farthestOf(IEnumerable<Vector3> positions)
		=> autoBehaviour.farthestOf(positions);
	public static new Transform farthestOf(IEnumerable<Transform> transforms)
		=> autoBehaviour.farthestOf(transforms);
	public static new GameObject farthestOf(IEnumerable<GameObject> gameObjects)
		=> autoBehaviour.farthestOf(gameObjects);
	#endregion farthest of

	#region is within distance of
	public static new bool isWithinDistanceOf(object position_PositionProvider, float thresholdDistance)
		=> autoBehaviour.isWithinDistanceOf(position_PositionProvider, thresholdDistance);
	public static new bool isNotWithinDistanceOf(object position_PositionProvider, float thresholdDistance)
		=> autoBehaviour.isNotWithinDistanceOf(position_PositionProvider, thresholdDistance);
	public static new bool isWithinDistanceOf<OtherSingletonBehaviourT>(float thresholdDistance) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.isWithinDistanceOf<OtherSingletonBehaviourT>(thresholdDistance);
	public static new bool isNotWithinDistanceOf<OtherSingletonBehaviourT>(float thresholdDistance) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.isNotWithinDistanceOf<OtherSingletonBehaviourT>(thresholdDistance);
	public static new bool isWithinDistanceOfCamera(float thresholdDistance)
		=> autoBehaviour.isWithinDistanceOfCamera(thresholdDistance);
	public static new bool isNotWithinDistanceOfCamera(float thresholdDistance)
		=> autoBehaviour.isNotWithinDistanceOfCamera(thresholdDistance);
	public static new bool isWithinDistanceOfPlayer(float thresholdDistance)
		=> autoBehaviour.isWithinDistanceOfPlayer(thresholdDistance);
	public static new bool isNotWithinDistanceOfPlayer(float thresholdDistance)
		=> autoBehaviour.isNotWithinDistanceOfPlayer(thresholdDistance);
	#endregion is within distance of
	
	#region as position provider is within distance of nearest point on solid collider
	public static new bool positionallyIsWithinSolidDistanceOf(object solidCollider_SolidColliderProvider, float thresholdDistance)
		=> autoBehaviour.positionallyIsWithinSolidDistanceOf(solidCollider_SolidColliderProvider, thresholdDistance);
	public static new bool positionallyIsNotWithinSolidDistanceOf(object solidCollider_SolidColliderProvider, float thresholdDistance)
		=> autoBehaviour.positionallyIsNotWithinSolidDistanceOf(solidCollider_SolidColliderProvider, thresholdDistance);
	#endregion as position provider is within distance of nearest point on solid collider
	
	#region as position provider is within distance of nearest point on solid collider otherwise position
	public static new bool positionallyIsWithinIdeallySolidDistanceOf(object colliderOtherwisePosition_ColliderOtherwisePositionProvider, float thresholdDistance)
		=> autoBehaviour.positionallyIsWithinIdeallySolidDistanceOf(colliderOtherwisePosition_ColliderOtherwisePositionProvider, thresholdDistance);
	public static new bool positionallyIsNotWithinIdeallySolidDistanceOf(object colliderOtherwisePosition_ColliderOtherwisePositionProvider, float thresholdDistance)
		=> autoBehaviour.positionallyIsNotWithinIdeallySolidDistanceOf(colliderOtherwisePosition_ColliderOtherwisePositionProvider, thresholdDistance);
	#endregion as position provider is within distance of nearest point on solid collider otherwise position
	
	#region is more distant than
	public static new bool isMoreDistantThan(object otherPosition_PositionProvider, object distancePosition_PositionProvider)
		=> autoBehaviour.isMoreDistantThan(otherPosition_PositionProvider, distancePosition_PositionProvider);
	#endregion is more distant than
	
	#region is more distant in same directionality as
	public static new bool isMoreDistantInSameDirectionalityAs(object otherPosition_PositionProvider, object referencePosition_PositionProvider)
		=> autoBehaviour.isMoreDistantInSameDirectionalityAs(otherPosition_PositionProvider, referencePosition_PositionProvider);
	#endregion is more distant in same directionality as

	#region nearest position to be at distance from target
	public static new Vector3 nearestPositionToBeAtDistanceFrom(object targetPosition_PositionProvider, float distanceFromTarget)
		=> autoBehaviour.nearestPositionToBeAtDistanceFrom(targetPosition_PositionProvider, distanceFromTarget);
	public static new Vector3 nearestPositionToBeAtDistanceFrom<OtherSingletonBehaviourT>(float distanceFromTarget) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.nearestPositionToBeAtDistanceFrom<OtherSingletonBehaviourT>(distanceFromTarget);
	public static new Vector3 nearestPositionToBeAtDistanceFromCameraOf(float distanceFromCamera)
		=> autoBehaviour.nearestPositionToBeAtDistanceFromCameraOf(distanceFromCamera);
	#endregion nearest position to be at distance from target
	#endregion distance


	#region position

	#region determining another position along the given direction
	public static new Vector3 positionAlong(Vector3 direction, float distance)
		=> autoBehaviour.positionAlong(direction, distance);
	#endregion determining another position along the given direction
	
	#region determining another position ahead of the provided transform
	public static new Vector3 positionAheadBy(float distance)
		=> autoBehaviour.positionAheadBy(distance);
	#endregion determining another position ahead of the provided transform
	
	#region determining another position relative to the provided position, along the forward direction of the provided transform
	public static new Vector3 positionAlongForwardOf(object transform_TransformProvider, float distance)
		=> autoBehaviour.positionAlongForwardOf(transform_TransformProvider, distance);
	#endregion determining another position relative to the provided position, along the forward direction of the provided transform
	#endregion position
}