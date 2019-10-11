using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Directude Extensions: provides extension methods for handling directudes (direction magnitudes vectors) //
public static class DirectudeExtensions
{
	// method: return the directude with this given vector and the other given vector //
	public static Vector3 directudeWith(this Vector3 vector, Vector3 otherVector)
		=> vector.directionFrom(otherVector).magnitudes();
	// method: return the directude with this given position and the given transform //
	public static Vector3 directudeWith(this Vector3 position, Transform transform)
		=> position.directudeWith(transform.position);
	// method: return the directude with this given position and the given game object //
	public static Vector3 directudeWith(this Vector3 position, GameObject gameObject)
		=> position.directudeWith(gameObject.position());
	// method: return the directude with this given position and the given component //
	public static Vector3 directudeWith(this Vector3 position, Component component)
		=> position.directudeWith(component.position());
	// method: return the directude with this given position and the main camera //
	public static Vector3 directudeWithCamera(this Vector3 position)
		=> position.directudeWith(Camera.main);

	// method: return the directude with this given game object and the given position //
	public static Vector3 directudeWith(this GameObject gameObject, Vector3 position)
		=> gameObject.position().directudeWith(position);
	// method: return the directude with this given game object and the given transform //
	public static Vector3 directudeWith(this GameObject gameObject, Transform transform)
		=> gameObject.position().directudeWith(transform.position);
	// method: return the directude with this given game object and the other given game object //
	public static Vector3 directudeWith(this GameObject gameObject, GameObject otherGameObject)
		=> gameObject.position().directudeWith(otherGameObject.position());
	// method: return the directude with this given game object and the given component //
	public static Vector3 directudeWith(this GameObject gameObject, Component component)
		=> gameObject.position().directudeWith(component.position());
	// method: return the directude with this given game object and the main camera //
	public static Vector3 directudeWithCamera(this GameObject gameObject)
		=> gameObject.position().directudeWithCamera();

	// method: return the directude with this given transform and the given position //
	public static Vector3 directudeWith(this Transform transform, Vector3 position)
		=> transform.position.directudeWith(position);
	// method: return the directude with this given transform and the other given transform //
	public static Vector3 directudeWith(this Transform transform, Transform otherTransform)
		=> transform.position.directudeWith(otherTransform.position);
	// method: return the directude with this given transform and the given game object //
	public static Vector3 directudeWith(this Transform transform, GameObject gameObject)
		=> transform.position.directudeWith(gameObject.position());
	// method: return the directude with this given transform and the given component //
	public static Vector3 directudeWith(this Transform transform, Component component)
		=> transform.position.directudeWith(component.position());
	// method: return the directude with this given transform and the main camera //
	public static Vector3 directudeWithCamera(this Transform transform)
		=> transform.position.directudeWithCamera();

	// method: return the directude with this given component and the given position //
	public static Vector3 directudeWith(this Component component, Vector3 position)
		=> component.position().directudeWith(position);
	// method: return the directude with this given transform and the given transform //
	public static Vector3 directudeWith(this Component component, Transform transform)
		=> component.position().directudeWith(transform.position);
	// method: return the directude with this given component and the given game object //
	public static Vector3 directudeWith(this Component component, GameObject gameObject)
		=> component.position().directudeWith(gameObject.position());
	// method: return the directude with this given component and the other given component //
	public static Vector3 directudeWith(this Component component, Component otherComponent)
		=> component.position().directudeWith(otherComponent.position());
	// method: return the directude with this given component and the main camera //
	public static Vector3 directudeWithCamera(this Component component)
		=> component.position().directudeWithCamera();
}