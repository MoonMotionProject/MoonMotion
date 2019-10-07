using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Distance Extensions: provides extension methods for handling distances (magnitudes of displacement) //
public static class DistanceExtensions
{
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


	// method: return the closest vector of the given vectors to this given vector //
	public static Vector3 closestOf(this Vector3 vector, IEnumerable<Vector3> vectors)
		=> vectors.minBy(otherVector => vector.distanceWith(otherVector));

	// method: return the closest of the given positions to this given game object's position //
	public static Vector3 closestOf(this GameObject gameObject, IEnumerable<Vector3> positions)
		=> positions.minBy(position => gameObject.distanceWith(position));
	// method: return the closest (by position) of the given transforms to this given game object //
	public static Transform closestOf(this GameObject gameObject, IEnumerable<Transform> transforms)
		=> transforms.minBy(transform => gameObject.distanceWith(transform));
	// method: return the closest (by position) of the given game objects to this given game object //
	public static GameObject closestOf(this GameObject gameObject, IEnumerable<GameObject> gameObjects)
		=> gameObjects.minBy(otherGameObject => gameObject.distanceWith(otherGameObject));

	// method: return the closest of the given positions to this given transform's position //
	public static Vector3 closestOf(this Transform transform, IEnumerable<Vector3> positions)
		=> positions.minBy(position => transform.distanceWith(position));
	// method: return the closest (by position) of the given transforms to this given transform //
	public static Transform closestOf(this Transform transform, IEnumerable<Transform> transforms)
		=> transforms.minBy(otherTransform => transform.distanceWith(otherTransform));
	// method: return the closest (by position) of the given game objects to this given transform //
	public static GameObject closestOf(this Transform transform, IEnumerable<GameObject> gameObjects)
		=> gameObjects.minBy(gameObject => transform.distanceWith(gameObject));


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
}