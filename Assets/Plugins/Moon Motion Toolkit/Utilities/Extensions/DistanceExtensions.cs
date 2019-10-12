using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Distance Extensions: provides extension methods for handling distances (magnitudes of displacement) //
public static class DistanceExtensions
{
	#region distance with

	// method: return the distance with this given pair and the other given pair //
	public static float distanceWith(this Vector2 pair, Vector2 otherPair)
		=> Vector2.Distance(pair, otherPair);

	// method: return the distance with this given vector and the other given vector //
	public static float distanceWith(this Vector3 vector, Vector3 otherVector)
		=> Vector3.Distance(vector, otherVector);
	// method: return the distance with this given position and the given transform //
	public static float distanceWith(this Vector3 position, Transform transform)
		=> position.distanceWith(transform.position);
	// method: return the distance with this given position and the given game object //
	public static float distanceWith(this Vector3 position, GameObject gameObject)
		=> position.distanceWith(gameObject.position());
	// method: return the distance with this given position and the given component //
	public static float distanceWith(this Vector3 position, Component component)
		=> position.distanceWith(component.position());
	// method: return the distance with this given position and the given raycast hit //
	public static float distanceWith(this Vector3 position, RaycastHit raycastHit)
		=> position.distanceWith(raycastHit.position());
	// method: return the distance with this given position and the main camera //
	public static float distanceWithCamera(this Vector3 position)
		=> position.distanceWith(Camera.main);

	// method: return the distance with this given game object and the given position //
	public static float distanceWith(this GameObject gameObject, Vector3 position)
		=> gameObject.position().distanceWith(position);
	// method: return the distance with this given game object and the given transform //
	public static float distanceWith(this GameObject gameObject, Transform transform)
		=> gameObject.position().distanceWith(transform.position);
	// method: return the distance with this given game object and the other given game object //
	public static float distanceWith(this GameObject gameObject, GameObject otherGameObject)
		=> gameObject.position().distanceWith(otherGameObject.position());
	// method: return the distance with this given game object and the given component //
	public static float distanceWith(this GameObject gameObject, Component component)
		=> gameObject.position().distanceWith(component.position());
	// method: return the distance with this given game object and the given raycast hit //
	public static float distanceWith(this GameObject gameObject, RaycastHit raycastHit)
		=> gameObject.distanceWith(raycastHit.position());
	// method: return the distance with this given game object and the main camera //
	public static float distanceWithCamera(this GameObject gameObject)
		=> gameObject.position().distanceWithCamera();

	// method: return the distance with this given transform and the given position //
	public static float distanceWith(this Transform transform, Vector3 position)
		=> transform.position.distanceWith(position);
	// method: return the distance with this given transform and the other given transform //
	public static float distanceWith(this Transform transform, Transform otherTransform)
		=> transform.position.distanceWith(otherTransform.position);
	// method: return the distance with this given transform and the given game object //
	public static float distanceWith(this Transform transform, GameObject gameObject)
		=> transform.position.distanceWith(gameObject.position());
	// method: return the distance with this given transform and the given component //
	public static float distanceWith(this Transform transform, Component component)
		=> transform.position.distanceWith(component.position());
	// method: return the distance with this given transform and the given raycast hit //
	public static float distanceWith(this Transform transform, RaycastHit raycastHit)
		=> transform.distanceWith(raycastHit.position());
	// method: return the distance with this given transform and the main camera //
	public static float distanceWithCamera(this Transform transform)
		=> transform.position.distanceWithCamera();

	// method: return the distance with this given component and the given position //
	public static float distanceWith(this Component component, Vector3 position)
		=> component.position().distanceWith(position);
	// method: return the distance with this given transform and the given transform //
	public static float distanceWith(this Component component, Transform transform)
		=> component.position().distanceWith(transform.position);
	// method: return the distance with this given component and the given game object //
	public static float distanceWith(this Component component, GameObject gameObject)
		=> component.position().distanceWith(gameObject.position());
	// method: return the distance with this given component and the other given component //
	public static float distanceWith(this Component component, Component otherComponent)
		=> component.position().distanceWith(otherComponent.position());
	// method: return the distance with this given component and the given raycast hit //
	public static float distanceWith(this Component component, RaycastHit raycastHit)
		=> component.distanceWith(raycastHit.position());
	// method: return the distance with this given component and the main camera //
	public static float distanceWithCamera(this Component component)
		=> component.position().distanceWithCamera();
	#endregion distance with


	#region nearest of

	// method: return the nearest vector of the given vectors to this given vector //
	public static Vector3 nearestOf(this Vector3 vector, IEnumerable<Vector3> vectors)
		=> vectors.minBy(otherVector => vector.distanceWith(otherVector));

	// method: return the nearest of the given positions to this given game object's position //
	public static Vector3 nearestOf(this GameObject gameObject, IEnumerable<Vector3> positions)
		=> positions.minBy(position => gameObject.distanceWith(position));
	// method: return the nearest (by position) of the given transforms to this given game object //
	public static Transform nearestOf(this GameObject gameObject, IEnumerable<Transform> transforms)
		=> transforms.minBy(transform => gameObject.distanceWith(transform));
	// method: return the nearest (by position) of the given game objects to this given game object //
	public static GameObject nearestOf(this GameObject gameObject, IEnumerable<GameObject> gameObjects)
		=> gameObjects.minBy(otherGameObject => gameObject.distanceWith(otherGameObject));

	// method: return the nearest of the given positions to this given transform's position //
	public static Vector3 nearestOf(this Transform transform, IEnumerable<Vector3> positions)
		=> positions.minBy(position => transform.distanceWith(position));
	// method: return the nearest (by position) of the given transforms to this given transform //
	public static Transform nearestOf(this Transform transform, IEnumerable<Transform> transforms)
		=> transforms.minBy(otherTransform => transform.distanceWith(otherTransform));
	// method: return the nearest (by position) of the given game objects to this given transform //
	public static GameObject nearestOf(this Transform transform, IEnumerable<GameObject> gameObjects)
		=> gameObjects.minBy(gameObject => transform.distanceWith(gameObject));
	#endregion nearest of


	#region farthest of

	// method: return the farthest vector of the given vectors to this given vector //
	public static Vector3 farthestOf(this Vector3 vector, IEnumerable<Vector3> vectors)
		=> vectors.maxBy(otherVector => vector.distanceWith(otherVector));

	// method: return the farthest of the given positions to this given game object's position //
	public static Vector3 farthestOf(this GameObject gameObject, IEnumerable<Vector3> positions)
		=> positions.maxBy(position => gameObject.distanceWith(position));
	// method: return the farthest (by position) of the given transforms to this given game object //
	public static Transform farthestOf(this GameObject gameObject, IEnumerable<Transform> transforms)
		=> transforms.maxBy(transform => gameObject.distanceWith(transform));
	// method: return the farthest (by position) of the given game objects to this given game object //
	public static GameObject farthestOf(this GameObject gameObject, IEnumerable<GameObject> gameObjects)
		=> gameObjects.maxBy(otherGameObject => gameObject.distanceWith(otherGameObject));

	// method: return the farthest of the given positions to this given transform's position //
	public static Vector3 farthestOf(this Transform transform, IEnumerable<Vector3> positions)
		=> positions.maxBy(position => transform.distanceWith(position));
	// method: return the farthest (by position) of the given transforms to this given transform //
	public static Transform farthestOf(this Transform transform, IEnumerable<Transform> transforms)
		=> transforms.maxBy(otherTransform => transform.distanceWith(otherTransform));
	// method: return the farthest (by position) of the given game objects to this given transform //
	public static GameObject farthestOf(this Transform transform, IEnumerable<GameObject> gameObjects)
		=> gameObjects.maxBy(gameObject => transform.distanceWith(gameObject));
	#endregion farthest of


	#region is within distance of

	// method: return whether this given position is within the given threshold distance of the given provided position //
	public static bool isWithinDistanceOf(this Vector3 position, object position_PositionProvider, float thresholdDistance)
		=> position.distanceWith(position_PositionProvider.providePosition()) <= thresholdDistance;
	// method: return whether this given game object is within the given threshold distance of the given provided position //
	public static bool isWithinDistanceOf(this GameObject gameObject, object position_PositionProvider, float thresholdDistance)
		=> gameObject.position().isWithinDistanceOf(position_PositionProvider, thresholdDistance);
	// method: return whether this given component is within the given threshold distance of the given provided position //
	public static bool isWithinDistanceOf(this Component component, object position_PositionProvider, float thresholdDistance)
		=> component.position().isWithinDistanceOf(position_PositionProvider, thresholdDistance);
	#endregion is within distance of


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
}