﻿using System;
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
	public static new bool isWithinDistanceOf
	(
		object position_PositionProvider,
		float thresholdDistance,
		bool treatOtherPositionNullAsInfinitelyDistant = Default.treatingOfNullAsARelevantValue
	)
		=>	autoBehaviour.isWithinDistanceOf
			(
				position_PositionProvider,
				thresholdDistance,
				treatOtherPositionNullAsInfinitelyDistant
			);
	public static new bool isNotWithinDistanceOf
	(
		object position_PositionProvider,
		float thresholdDistance,
		bool treatOtherPositionNullAsInfinitelyDistant = Default.treatingOfNullAsARelevantValue
	)
		=>	autoBehaviour.isNotWithinDistanceOf
			(
				position_PositionProvider,
				thresholdDistance,
				treatOtherPositionNullAsInfinitelyDistant
			);
	public static new bool isWithinDistanceOf<OtherSingletonBehaviourT>
	(
		float thresholdDistance,
		bool treatOtherPositionNullAsInfinitelyDistant = Default.treatingOfNullAsARelevantValue
	) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=>	autoBehaviour.isWithinDistanceOf<OtherSingletonBehaviourT>
			(
				thresholdDistance,
				treatOtherPositionNullAsInfinitelyDistant
			);
	public static new bool isNotWithinDistanceOf<OtherSingletonBehaviourT>
	(
		float thresholdDistance,
		bool treatOtherPositionNullAsInfinitelyDistant = Default.treatingOfNullAsARelevantValue
	) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=>	autoBehaviour.isNotWithinDistanceOf<OtherSingletonBehaviourT>
			(
				thresholdDistance,
				treatOtherPositionNullAsInfinitelyDistant
			);
	public static new bool isWithinDistanceOfCamera
	(
		float thresholdDistance,
		bool treatOtherPositionNullAsInfinitelyDistant = Default.treatingOfNullAsARelevantValue
	)
		=>	autoBehaviour.isWithinDistanceOfCamera
			(
				thresholdDistance,
				treatOtherPositionNullAsInfinitelyDistant
			);
	public static new bool isNotWithinDistanceOfCamera
	(
		float thresholdDistance,
		bool treatOtherPositionNullAsInfinitelyDistant = Default.treatingOfNullAsARelevantValue
	)
		=>	autoBehaviour.isNotWithinDistanceOfCamera
			(
				thresholdDistance,
				treatOtherPositionNullAsInfinitelyDistant
			);
	public static new bool isWithinDistanceOfPlayer
	(
		float thresholdDistance,
		bool treatOtherPositionNullAsInfinitelyDistant = Default.treatingOfNullAsARelevantValue
	)
		=>	autoBehaviour.isWithinDistanceOfPlayer
			(
				thresholdDistance,
				treatOtherPositionNullAsInfinitelyDistant
			);
	public static new bool isNotWithinDistanceOfPlayer
	(
		float thresholdDistance,
		bool treatOtherPositionNullAsInfinitelyDistant = Default.treatingOfNullAsARelevantValue
	)
		=>	autoBehaviour.isNotWithinDistanceOfPlayer
			(
				thresholdDistance,
				treatOtherPositionNullAsInfinitelyDistant
			);
	#endregion is within distance of
	
	#region as position provider is within distance of nearest point on solid collider
	public static new bool positionallyIsWithinSolidDistanceOf(object solidCollider_SolidColliderProvider, float thresholdDistance)
		=> autoBehaviour.positionallyIsWithinSolidDistanceOf(solidCollider_SolidColliderProvider, thresholdDistance);
	public static new bool positionallyIsNotWithinSolidDistanceOf(object solidCollider_SolidColliderProvider, float thresholdDistance)
		=> autoBehaviour.positionallyIsNotWithinSolidDistanceOf(solidCollider_SolidColliderProvider, thresholdDistance);
	#endregion as position provider is within distance of nearest point on solid collider
	
	#region as position provider is within distance of nearest point on solid collider otherwise position
	public static new bool positionallyIsWithinIdeallySolidDistanceOf
	(
		object colliderOtherwisePosition_ColliderOtherwisePositionProvider,
		float thresholdDistance,
		bool treatOtherProviderNullAsInfinitelyDistant = Default.treatingOfNullAsARelevantValue
	)
		=>	autoBehaviour
				.positionallyIsWithinIdeallySolidDistanceOf
				(
					colliderOtherwisePosition_ColliderOtherwisePositionProvider,
					thresholdDistance,
					treatOtherProviderNullAsInfinitelyDistant
				);
	public static new bool positionallyIsNotWithinIdeallySolidDistanceOf
	(
		object colliderOtherwisePosition_ColliderOtherwisePositionProvider,
		float thresholdDistance,
		bool treatOtherProviderNullAsInfinitelyDistant = Default.treatingOfNullAsARelevantValue
	)
		=>	autoBehaviour
				.positionallyIsNotWithinIdeallySolidDistanceOf
				(
					colliderOtherwisePosition_ColliderOtherwisePositionProvider,
					thresholdDistance,
					treatOtherProviderNullAsInfinitelyDistant
				);
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


	#region rendering bounds
	
	public static new Vector3 renderingBoundsDimensions => autoBehaviour.renderingBoundsDimensions;
	public static new float shortestRenderingBound => autoBehaviour.shortestRenderingBound;
	public static new float longestRenderingBound => autoBehaviour.longestRenderingBound;
	#endregion rendering bounds
}