using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Distance Extensions: provides extension methods for handling distances (magnitudes of displacement) //
public static class DistanceExtensions
{
	#region distance with
	// methods: return the distance with this given provided pair\vector/position and the other given pair\vector/position, specified singleton behaviour, or the main camera (respectively) //
	
	public static float distanceWith(this Vector2 pair, Vector2 otherPair)
		=> Vector2.Distance(pair, otherPair);
	public static float distanceWith(this Vector3 vector, Vector3 otherVector)
		=> Vector3.Distance(vector, otherVector);
	public static float distanceWith(this Vector3 position, object otherPosition_PositionProvider)
		=> position.distanceWith(otherPosition_PositionProvider.providePosition());
	public static float distanceWith<SingletonBehaviourT>(this Vector3 position) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> position.distanceWith(SingletonBehaviour<SingletonBehaviourT>.position);
	public static float distanceWithCamera(this Vector3 position)
		=> position.distanceWith(Camera.main);
	
	public static float distanceWith(this GameObject gameObject, object otherPosition_PositionProvider)
		=> gameObject.position().distanceWith(otherPosition_PositionProvider);
	public static float distanceWith<SingletonBehaviourT>(this GameObject gameObject) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> gameObject.distanceWith(SingletonBehaviour<SingletonBehaviourT>.position);
	public static float distanceWithCamera(this GameObject gameObject)
		=> gameObject.position().distanceWithCamera();
	
	public static float distanceWith(this Component component, object otherPosition_PositionProvider)
		=> component.position().distanceWith(otherPosition_PositionProvider);
	public static float distanceWith<SingletonBehaviourT>(this Component component) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> component.distanceWith(SingletonBehaviour<SingletonBehaviourT>.position);
	public static float distanceWithCamera(this Component component)
		=> component.position().distanceWithCamera();
	#endregion distance with


	#region nearest of

	// method: return the nearest vector of the given vectors to this given vector //
	public static Vector3 nearestOf(this Vector3 vector, IEnumerable<Vector3> vectors)
		=> vectors.minProviderOtherwiseDefault(otherVector => vector.distanceWith(otherVector));

	// method: return the nearest of the given positions to this given game object's position //
	public static Vector3 nearestOf(this GameObject gameObject, IEnumerable<Vector3> positions)
		=> positions.minProviderOtherwiseDefault(position => gameObject.distanceWith(position));
	// method: return the nearest (by position) of the given game objects to this given game object //
	public static GameObject nearestOf(this GameObject gameObject, IEnumerable<GameObject> gameObjects)
		=> gameObjects.minProviderOtherwiseDefault(otherGameObject => gameObject.distanceWith(otherGameObject));
	// method: return the nearest (by position) of the given components to this given game object //
	public static ComponentT nearestOf<ComponentT>(this GameObject gameObject, IEnumerable<ComponentT> components) where ComponentT : Component
		=> components.minProviderOtherwiseDefault(component => gameObject.distanceWith(component));
	// method: (via reflection if error:) return the nearest (by position) of the given interfaces (implemented by mono behaviours) to this given game object //
	public static MonoBehaviourI nearestOfI<MonoBehaviourI>(this GameObject gameObject, IEnumerable<MonoBehaviourI> interfaces) where MonoBehaviourI : class
	{
		if (!typeof(MonoBehaviourI).IsInterface)
		{
			return default(MonoBehaviourI).returnWithError(typeof(MonoBehaviourI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return interfaces.minProviderOtherwiseDefault(interface_ => gameObject.distanceWith(interface_.castTo<MonoBehaviour>()));
	}

	// method: return the nearest of the given positions to this given transform's position //
	public static Vector3 nearestOf(this Transform transform, IEnumerable<Vector3> positions)
		=> positions.minProviderOtherwiseDefault(position => transform.distanceWith(position));
	// method: return the nearest (by position) of the given game objects to this given transform //
	public static GameObject nearestOf(this Transform transform, IEnumerable<GameObject> gameObjects)
		=> gameObjects.minProviderOtherwiseDefault(gameObject => transform.distanceWith(gameObject));
	// method: return the nearest (by position) of the given components to this given transform //
	public static ComponentT nearestOf<ComponentT>(this Transform transform, IEnumerable<ComponentT> components) where ComponentT : Component
		=> components.minProviderOtherwiseDefault(component => transform.distanceWith(component));
	// method: return the nearest (by position) of the given interfaces (implemented by mono behaviours) to this given transform //
	public static MonoBehaviourI nearestOfI<MonoBehaviourI>(this Transform transform, IEnumerable<MonoBehaviourI> interfaces) where MonoBehaviourI : class
		=> transform.gameObject.nearestOfI(interfaces);
	#endregion nearest of


	#region farthest of

	// method: return the farthest vector of the given vectors to this given vector //
	public static Vector3 farthestOf(this Vector3 vector, IEnumerable<Vector3> vectors)
		=> vectors.maxProviderOtherwiseDefault(otherVector => vector.distanceWith(otherVector));

	// method: return the farthest of the given positions to this given game object's position //
	public static Vector3 farthestOf(this GameObject gameObject, IEnumerable<Vector3> positions)
		=> positions.maxProviderOtherwiseDefault(position => gameObject.distanceWith(position));
	// method: return the farthest (by position) of the given transforms to this given game object //
	public static Transform farthestOf(this GameObject gameObject, IEnumerable<Transform> transforms)
		=> transforms.maxProviderOtherwiseDefault(transform => gameObject.distanceWith(transform));
	// method: return the farthest (by position) of the given game objects to this given game object //
	public static GameObject farthestOf(this GameObject gameObject, IEnumerable<GameObject> gameObjects)
		=> gameObjects.maxProviderOtherwiseDefault(otherGameObject => gameObject.distanceWith(otherGameObject));

	// method: return the farthest of the given positions to this given transform's position //
	public static Vector3 farthestOf(this Transform transform, IEnumerable<Vector3> positions)
		=> positions.maxProviderOtherwiseDefault(position => transform.distanceWith(position));
	// method: return the farthest (by position) of the given transforms to this given transform //
	public static Transform farthestOf(this Transform transform, IEnumerable<Transform> transforms)
		=> transforms.maxProviderOtherwiseDefault(otherTransform => transform.distanceWith(otherTransform));
	// method: return the farthest (by position) of the given game objects to this given transform //
	public static GameObject farthestOf(this Transform transform, IEnumerable<GameObject> gameObjects)
		=> gameObjects.maxProviderOtherwiseDefault(gameObject => transform.distanceWith(gameObject));
	#endregion farthest of


	#region is within distance of
	// methods: return whether this given provided position is\isn't (respectively) within the given threshold distance of the other given provided position, specified singleton behaviour, the player (body), or the main camera (respectively) //

	public static bool isWithinDistanceOf(this object position_PositionProvider, object otherPosition_PositionProvider, float thresholdDistance)
		=>	Yull.areBoth(position_PositionProvider, otherPosition_PositionProvider) &&
			position_PositionProvider.providePosition()
				.distanceWith(otherPosition_PositionProvider.providePosition()) <= thresholdDistance;
	public static bool isNotWithinDistanceOf(this object position_PositionProvider, object otherPosition_PositionProvider, float thresholdDistance)
		=> !position_PositionProvider.isWithinDistanceOf(otherPosition_PositionProvider, thresholdDistance);
	public static bool isWithinDistanceOf<SingletonBehaviourT>(this object position_PositionProvider, float thresholdDistance) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> position_PositionProvider.isWithinDistanceOf(SingletonBehaviour<SingletonBehaviourT>.position, thresholdDistance);
	public static bool isNotWithinDistanceOf<SingletonBehaviourT>(this object position_PositionProvider, float thresholdDistance) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> !position_PositionProvider.isWithinDistanceOf<SingletonBehaviourT>(thresholdDistance);
	public static bool isWithinDistanceOfCamera(this object position_PositionProvider, float thresholdDistance)
		=> position_PositionProvider.isWithinDistanceOf(Camera.main, thresholdDistance);
	public static bool isNotWithinDistanceOfCamera(this object position_PositionProvider, float thresholdDistance)
		=> !position_PositionProvider.isNotWithinDistanceOfCamera(thresholdDistance);
	public static bool isWithinDistanceOfPlayer(this object position_PositionProvider, float thresholdDistance)
		=> position_PositionProvider.isWithinDistanceOf<MoonMotionBody>(thresholdDistance);
	public static bool isNotWithinDistanceOfPlayer(this object position_PositionProvider, float thresholdDistance)
		=> !position_PositionProvider.isWithinDistanceOfPlayer(thresholdDistance);
	#endregion is within distance of


	#region as position provider is within distance of nearest point on solid collider
	public static bool positionallyIsWithinSolidDistanceOf(this object position_PositionProvider, object solidCollider_SolidColliderProvider, float thresholdDistance)
	{
		Vector3 position = position_PositionProvider.providePosition();

		return	position
				.isWithinDistanceOf
				(
					solidCollider_SolidColliderProvider
						.provideSolidCollider()
							.nearestPointToPosition(position),
					thresholdDistance
				);
	}
	public static bool positionallyIsNotWithinSolidDistanceOf(this object position_PositionProvider, object solidCollider_SolidColliderProvider, float thresholdDistance)
		=> !position_PositionProvider.positionallyIsWithinSolidDistanceOf(solidCollider_SolidColliderProvider, thresholdDistance);
	#endregion as position provider is within distance of nearest point on solid collider


	#region as position provider is within distance of nearest point on solid collider otherwise position
	public static bool positionallyIsWithinIdeallySolidDistanceOf(this object position_PositionProvider, object colliderOtherwisePosition_ColliderOtherwisePositionProvider, float thresholdDistance)
	{
		Collider potentialSolidCollider = colliderOtherwisePosition_ColliderOtherwisePositionProvider.provideSolidCollider();
		return	potentialSolidCollider.isYull() ?
					position_PositionProvider.positionallyIsWithinSolidDistanceOf
					(
						potentialSolidCollider,
						thresholdDistance
					) :
					position_PositionProvider.isWithinDistanceOf
					(
						colliderOtherwisePosition_ColliderOtherwisePositionProvider.providePosition(),
						thresholdDistance
					);
	}
	public static bool positionallyIsNotWithinIdeallySolidDistanceOf(this object position_PositionProvider, object colliderOtherwisePosition_ColliderOtherwisePositionProvider, float thresholdDistance)
		=>	!position_PositionProvider.positionallyIsWithinIdeallySolidDistanceOf
			(
				colliderOtherwisePosition_ColliderOtherwisePositionProvider,
				thresholdDistance
			);
	#endregion as position provider is within distance of nearest point on solid collider otherwise position


	#region is more distant than
	// methods: return whether this given provided position is more distant from the given provided distance position than the other given provided position //

	public static bool isMoreDistantThan(this Vector3 position, object otherPosition_PositionProvider, object distancePosition_PositionProvider)
	{
		Vector3 distancePosition = distancePosition_PositionProvider.providePosition();

		return position.distanceWith(distancePosition) > otherPosition_PositionProvider.providePosition().distanceWith(distancePosition);
	}
	public static bool isMoreDistantThan(this GameObject gameObject, object distancePosition_PositionProvider, object otherPosition_PositionProvider)
		=> gameObject.position().isMoreDistantThan(otherPosition_PositionProvider, distancePosition_PositionProvider);
	public static bool isMoreDistantThan(this Component component, object distancePosition_PositionProvider, object otherPosition_PositionProvider)
		=> component.position().isMoreDistantThan(otherPosition_PositionProvider, distancePosition_PositionProvider);
	#endregion is more distant than


	#region is more distant in same directionality as
	// methods: return whether this given provided position is more distant from the given provided reference position than the other given provided position //

	public static bool isMoreDistantInSameDirectionalityAs(this Vector3 position, object otherPosition_PositionProvider, object referencePosition_PositionProvider)
		=>	position.isMoreDistantThan(otherPosition_PositionProvider, referencePosition_PositionProvider) &&
				referencePosition_PositionProvider.providePosition().directionalitySameTowardBoth(position, otherPosition_PositionProvider);
	public static bool isMoreDistantInSameDirectionalityAs(this GameObject gameObject, object otherPosition_PositionProvider, object referencePosition_PositionProvider)
		=> gameObject.position().isMoreDistantInSameDirectionalityAs(otherPosition_PositionProvider, referencePosition_PositionProvider);
	public static bool isMoreDistantInSameDirectionalityAs(this Component component, object otherPosition_PositionProvider, object referencePosition_PositionProvider)
		=> component.position().isMoreDistantInSameDirectionalityAs(otherPosition_PositionProvider, referencePosition_PositionProvider);
	#endregion is more distant in same directionality as


	#region nearest position to be at distance from target
	// methods: return the nearest position to this given provided position that there is to be at the given distance from the given provided target position, specified singleton behaviour, or the main camera (respectively) //

	public static Vector3 nearestPositionToBeAtDistanceFrom(this Vector3 position, object targetPosition_PositionProvider, float distanceFromTarget)
	{
		Vector3 targetPosition = targetPosition_PositionProvider.providePosition();

		return targetPosition.withDisplacement(targetPosition.directionTo(position) * distanceFromTarget);
	}
	public static Vector3 nearestPositionToBeAtDistanceFrom<SingletonBehaviourT>(this Vector3 position, float distanceFromTarget) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> position.nearestPositionToBeAtDistanceFrom(SingletonBehaviour<SingletonBehaviourT>.position, distanceFromTarget);
	public static Vector3 nearestPositionToBeAtDistanceFromCameraOf(this Vector3 position, float distanceFromCamera)
		=> position.nearestPositionToBeAtDistanceFrom(Camera.main, distanceFromCamera);
	
	public static Vector3 nearestPositionToBeAtDistanceFrom(this GameObject gameObject, object targetPosition_PositionProvider, float distanceFromTarget)
		=> gameObject.position().nearestPositionToBeAtDistanceFrom(targetPosition_PositionProvider, distanceFromTarget);
	public static Vector3 nearestPositionToBeAtDistanceFrom<SingletonBehaviourT>(this GameObject gameObject, float distanceFromTarget) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> gameObject.position().nearestPositionToBeAtDistanceFrom<SingletonBehaviourT>(distanceFromTarget);
	public static Vector3 nearestPositionToBeAtDistanceFromCameraOf(this GameObject gameObject, float distanceFromCamera)
		=> gameObject.position().nearestPositionToBeAtDistanceFromCameraOf(distanceFromCamera);
	
	public static Vector3 nearestPositionToBeAtDistanceFrom(this Component component, object targetPosition_PositionProvider, float distanceFromTarget)
		=> component.position().nearestPositionToBeAtDistanceFrom(targetPosition_PositionProvider, distanceFromTarget);
	public static Vector3 nearestPositionToBeAtDistanceFrom<SingletonBehaviourT>(this Component component, float distanceFromTarget) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> component.position().nearestPositionToBeAtDistanceFrom<SingletonBehaviourT>(distanceFromTarget);
	public static Vector3 nearestPositionToBeAtDistanceFromCameraOf(this Component component, float distanceFromCamera)
		=> component.position().nearestPositionToBeAtDistanceFromCameraOf(distanceFromCamera);
	#endregion nearest position to be at distance from target
}