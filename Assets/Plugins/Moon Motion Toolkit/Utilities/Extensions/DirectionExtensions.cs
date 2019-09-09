using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Direction Extensions: provides extension methods for handling directions (vectrals of displacement) //
public static class DirectionExtensions
{
	#region from other

	// method: return the direction from the other given vector to this given vector //
	public static Vector3 directionFrom(this Vector3 vector, Vector3 otherVector)
		=> vector.displacementFrom(otherVector).vectral();
	// method: return the direction from the given transform to this given position //
	public static Vector3 directionFrom(this Vector3 position, Transform transform)
		=> position.directionFrom(transform.position);
	// method: return the direction from the given game object to this given position //
	public static Vector3 directionFrom(this Vector3 position, GameObject gameObject)
		=> position.directionFrom(gameObject.position());
	// method: return the direction from the given component to this given position //
	public static Vector3 directionFrom(this Vector3 position, Component component)
		=> position.directionFrom(component.position());
	// method: return the direction from the main camera to this given position //
	public static Vector3 directionFromCamera(this Vector3 position)
		=> position.directionFrom(Camera.main);

	// method: return the direction from the given position to this given game object //
	public static Vector3 directionFrom(this GameObject gameObject, Vector3 position)
		=> gameObject.position().directionFrom(position);
	// method: return the direction from the given transform to this given game object //
	public static Vector3 directionFrom(this GameObject gameObject, Transform transform)
		=> gameObject.position().directionFrom(transform.position);
	// method: return the direction from the other given game object to this given game object //
	public static Vector3 directionFrom(this GameObject gameObject, GameObject otherGameObject)
		=> gameObject.position().directionFrom(otherGameObject.position());
	// method: return the direction from the given component to this given game object //
	public static Vector3 directionFrom(this GameObject gameObject, Component component)
		=> gameObject.position().directionFrom(component.position());
	// method: return the direction from the main camera to this given game object //
	public static Vector3 directionFromCamera(this GameObject gameObject)
		=> gameObject.position().directionFromCamera();

	// method: return the direction from the given position to this given transform //
	public static Vector3 directionFrom(this Transform transform, Vector3 position)
		=> transform.position.directionFrom(position);
	// method: return the direction from the other given transform to this given transform //
	public static Vector3 directionFrom(this Transform transform, Transform otherTransform)
		=> transform.position.directionFrom(otherTransform.position);
	// method: return the direction from the given game object to this given transform //
	public static Vector3 directionFrom(this Transform transform, GameObject gameObject)
		=> transform.position.directionFrom(gameObject.position());
	// method: return the direction from the given component to this given transform //
	public static Vector3 directionFrom(this Transform transform, Component component)
		=> transform.position.directionFrom(component.position());
	// method: return the direction from the main camera to this given transform //
	public static Vector3 directionFromCamera(this Transform transform)
		=> transform.position.directionFromCamera();

	// method: return the direction from the given position to this given component //
	public static Vector3 directionFrom(this Component component, Vector3 position)
		=> component.position().directionFrom(position);
	// method: return the direction from the given transform to this given transform //
	public static Vector3 directionFrom(this Component component, Transform transform)
		=> component.position().directionFrom(transform.position);
	// method: return the direction from the given game object to this given component //
	public static Vector3 directionFrom(this Component component, GameObject gameObject)
		=> component.position().directionFrom(gameObject.position());
	// method: return the direction from the other given component to this given transform //
	public static Vector3 directionFrom(this Component component, Component otherComponent)
		=> component.position().directionFrom(otherComponent.position());
	// method: return the direction from the main camera to this given component //
	public static Vector3 directionFromCamera(this Component component)
		=> component.position().directionFromCamera();
	#endregion from other


	#region to other

	// method: return the direction to the other given vector from this given vector //
	public static Vector3 directionTo(this Vector3 vector, Vector3 otherVector)
		=> vector.displacementTo(otherVector).vectral();
	// method: return the direction to the given transform from this given position //
	public static Vector3 directionTo(this Vector3 position, Transform transform)
		=> position.directionTo(transform.position);
	// method: return the direction to the given game object from this given position //
	public static Vector3 directionTo(this Vector3 position, GameObject gameObject)
		=> position.directionTo(gameObject.position());
	// method: return the direction to the given component from this given position //
	public static Vector3 directionTo(this Vector3 position, Component component)
		=> position.directionTo(component.position());
	// method: return the direction to the main camera from this given position //
	public static Vector3 directionToCamera(this Vector3 position)
		=> position.directionTo(Camera.main);

	// method: return the direction to the given position from this given game object //
	public static Vector3 directionTo(this GameObject gameObject, Vector3 position)
		=> gameObject.position().directionTo(position);
	// method: return the direction to the given transform from this given game object //
	public static Vector3 directionTo(this GameObject gameObject, Transform transform)
		=> gameObject.position().directionTo(transform.position);
	// method: return the direction to the other given game object from this given game object //
	public static Vector3 directionTo(this GameObject gameObject, GameObject otherGameObject)
		=> gameObject.position().directionTo(otherGameObject.position());
	// method: return the direction to the given component from this given game object //
	public static Vector3 directionTo(this GameObject gameObject, Component component)
		=> gameObject.position().directionTo(component.position());
	// method: return the direction to the main camera from this given game object //
	public static Vector3 directionToCamera(this GameObject gameObject)
		=> gameObject.position().directionToCamera();

	// method: return the direction to the given position from this given transform //
	public static Vector3 directionTo(this Transform transform, Vector3 position)
		=> transform.position.directionTo(position);
	// method: return the direction to the other given transform from this given transform //
	public static Vector3 directionTo(this Transform transform, Transform otherTransform)
		=> transform.position.directionTo(otherTransform.position);
	// method: return the direction to the given game object from this given transform //
	public static Vector3 directionTo(this Transform transform, GameObject gameObject)
		=> transform.position.directionTo(gameObject.position());
	// method: return the direction to the given component from this given transform //
	public static Vector3 directionTo(this Transform transform, Component component)
		=> transform.position.directionTo(component.position());
	// method: return the direction to the main camera from this given transform //
	public static Vector3 directionToCamera(this Transform transform)
		=> transform.position.directionToCamera();

	// method: return the direction to the given position from this given component //
	public static Vector3 directionTo(this Component component, Vector3 position)
		=> component.position().directionTo(position);
	// method: return the direction to the given transform from this given transform //
	public static Vector3 directionTo(this Component component, Transform transform)
		=> component.position().directionTo(transform.position);
	// method: return the direction to the given game object from this given component //
	public static Vector3 directionTo(this Component component, GameObject gameObject)
		=> component.position().directionTo(gameObject.position());
	// method: return the direction to the other given component from this given transform //
	public static Vector3 directionTo(this Component component, Component otherComponent)
		=> component.position().directionTo(otherComponent.position());
	// method: return the direction to the main camera from this given component //
	public static Vector3 directionToCamera(this Component component)
		=> component.position().directionToCamera();
	#endregion to other


	#region for tug upon other

	// method: return the direction for the given tug upon the other given vector from this given vector //
	public static Vector3 directionForTugUpon(this Vector3 vector, Vector3 otherVector, Tug tug)
		=> vector.directionFrom(otherVector) * tug.asSign();
	// method: return the direction for the given tug upon the given transform from this given position //
	public static Vector3 directionForTugUpon(this Vector3 position, Transform transform, Tug tug)
		=> position.directionForTugUpon(transform.position, tug);
	// method: return the direction for the given tug upon the given game object from this given position //
	public static Vector3 directionForTugUpon(this Vector3 position, GameObject gameObject, Tug tug)
		=> position.directionForTugUpon(gameObject.position(), tug);
	// method: return the direction for the given tug upon the given component from this given position //
	public static Vector3 directionForTugUpon(this Vector3 position, Component component, Tug tug)
		=> position.directionForTugUpon(component.position(), tug);
	// method: return the direction for the given tug upon the main camera from this given position //
	public static Vector3 directionForTugUponCamera(this Vector3 position, Tug tug)
		=> position.directionForTugUpon(Camera.main, tug);

	// method: return the direction for the given tug upon the given position from this given game object //
	public static Vector3 directionForTugUpon(this GameObject gameObject, Vector3 position, Tug tug)
		=> gameObject.position().directionForTugUpon(position, tug);
	// method: return the direction for the given tug upon the given transform from this given game object //
	public static Vector3 directionForTugUpon(this GameObject gameObject, Transform transform, Tug tug)
		=> gameObject.position().directionForTugUpon(transform.position, tug);
	// method: return the direction for the given tug upon the other given game object from this given game object //
	public static Vector3 directionForTugUpon(this GameObject gameObject, GameObject otherGameObject, Tug tug)
		=> gameObject.position().directionForTugUpon(otherGameObject.position(), tug);
	// method: return the direction for the given tug upon the given component from this given game object //
	public static Vector3 directionForTugUpon(this GameObject gameObject, Component component, Tug tug)
		=> gameObject.position().directionForTugUpon(component.position(), tug);
	// method: return the direction for the given tug upon the main camera from this given game object //
	public static Vector3 directionForTugUponCamera(this GameObject gameObject, Tug tug)
		=> gameObject.position().directionForTugUponCamera(tug);

	// method: return the direction for the given tug upon the given position from this given transform //
	public static Vector3 directionForTugUpon(this Transform transform, Vector3 position, Tug tug)
		=> transform.position.directionForTugUpon(position, tug);
	// method: return the direction for the given tug upon the other given transform from this given transform //
	public static Vector3 directionForTugUpon(this Transform transform, Transform otherTransform, Tug tug)
		=> transform.position.directionForTugUpon(otherTransform.position, tug);
	// method: return the direction for the given tug upon the given game object from this given transform //
	public static Vector3 directionForTugUpon(this Transform transform, GameObject gameObject, Tug tug)
		=> transform.position.directionForTugUpon(gameObject.position(), tug);
	// method: return the direction for the given tug upon the given component from this given transform //
	public static Vector3 directionForTugUpon(this Transform transform, Component component, Tug tug)
		=> transform.position.directionForTugUpon(component.position(), tug);
	// method: return the direction for the given tug upon the main camera from this given transform //
	public static Vector3 directionForTugUponCamera(this Transform transform, Tug tug)
		=> transform.position.directionForTugUponCamera(tug);

	// method: return the direction for the given tug upon the given position from this given component //
	public static Vector3 directionForTugUpon(this Component component, Vector3 position, Tug tug)
		=> component.position().directionForTugUpon(position, tug);
	// method: return the direction for the given tug upon the given transform from this given transform //
	public static Vector3 directionForTugUpon(this Component component, Transform transform, Tug tug)
		=> component.position().directionForTugUpon(transform.position, tug);
	// method: return the direction for the given tug upon the given game object from this given component //
	public static Vector3 directionForTugUpon(this Component component, GameObject gameObject, Tug tug)
		=> component.position().directionForTugUpon(gameObject.position(), tug);
	// method: return the direction for the given tug upon the other given component from this given transform //
	public static Vector3 directionForTugUpon(this Component component, Component otherComponent, Tug tug)
		=> component.position().directionForTugUpon(otherComponent.position(), tug);
	// method: return the direction for the given tug upon the main camera from this given component //
	public static Vector3 directionForTugUponCamera(this Component component, Tug tug)
		=> component.position().directionForTugUponCamera(tug);
	#endregion for tug upon other
}