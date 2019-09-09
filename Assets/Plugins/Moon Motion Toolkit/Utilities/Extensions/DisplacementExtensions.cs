using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Displacement Extensions: provides extension methods for handling displacements (directional distances) //
public static class DisplacementExtensions
{
	#region from other

	// method: return the displacement from the other given vector to this given vector //
	public static Vector3 displacementFrom(this Vector3 vector, Vector3 otherVector)
		=> vector - otherVector;
	// method: return the displacement from the given transform to this given position //
	public static Vector3 displacementFrom(this Vector3 position, Transform transform)
		=> position.displacementFrom(transform.position);
	// method: return the displacement from the given game object to this given position //
	public static Vector3 displacementFrom(this Vector3 position, GameObject gameObject)
		=> position.displacementFrom(gameObject.position());
	// method: return the displacement from the given component to this given position //
	public static Vector3 displacementFrom(this Vector3 position, Component component)
		=> position.displacementFrom(component.position());
	// method: return the displacement from the main camera to this given position //
	public static Vector3 displacementFromCamera(this Vector3 position)
		=> position.displacementFrom(Camera.main);

	// method: return the displacement from the given position to this given game object //
	public static Vector3 displacementFrom(this GameObject gameObject, Vector3 position)
		=> gameObject.position().displacementFrom(position);
	// method: return the displacement from the given transform to this given game object //
	public static Vector3 displacementFrom(this GameObject gameObject, Transform transform)
		=> gameObject.position().displacementFrom(transform.position);
	// method: return the displacement from the other given game object to this given game object //
	public static Vector3 displacementFrom(this GameObject gameObject, GameObject otherGameObject)
		=> gameObject.position().displacementFrom(otherGameObject.position());
	// method: return the displacement from the given component to this given game object //
	public static Vector3 displacementFrom(this GameObject gameObject, Component component)
		=> gameObject.position().displacementFrom(component.position());
	// method: return the displacement from the main camera to this given game object //
	public static Vector3 displacementFromCamera(this GameObject gameObject)
		=> gameObject.position().displacementFromCamera();

	// method: return the displacement from the given position to this given transform //
	public static Vector3 displacementFrom(this Transform transform, Vector3 position)
		=> transform.position.displacementFrom(position);
	// method: return the displacement from the other given transform to this given transform //
	public static Vector3 displacementFrom(this Transform transform, Transform otherTransform)
		=> transform.position.displacementFrom(otherTransform.position);
	// method: return the displacement from the given game object to this given transform //
	public static Vector3 displacementFrom(this Transform transform, GameObject gameObject)
		=> transform.position.displacementFrom(gameObject.position());
	// method: return the displacement from the given component to this given transform //
	public static Vector3 displacementFrom(this Transform transform, Component component)
		=> transform.position.displacementFrom(component.position());
	// method: return the displacement from the main camera to this given transform //
	public static Vector3 displacementFromCamera(this Transform transform)
		=> transform.position.displacementFromCamera();

	// method: return the displacement from the given position to this given component //
	public static Vector3 displacementFrom(this Component component, Vector3 position)
		=> component.position().displacementFrom(position);
	// method: return the displacement from the given transform to this given transform //
	public static Vector3 displacementFrom(this Component component, Transform transform)
		=> component.position().displacementFrom(transform.position);
	// method: return the displacement from the given game object to this given component //
	public static Vector3 displacementFrom(this Component component, GameObject gameObject)
		=> component.position().displacementFrom(gameObject.position());
	// method: return the displacement from the other given component to this given transform //
	public static Vector3 displacementFrom(this Component component, Component otherComponent)
		=> component.position().displacementFrom(otherComponent.position());
	// method: return the displacement from the main camera to this given component //
	public static Vector3 displacementFromCamera(this Component component)
		=> component.position().displacementFromCamera();
	#endregion from other


	#region to other

	// method: return the displacement to the other given vector from this given vector //
	public static Vector3 displacementTo(this Vector3 vector, Vector3 otherVector)
		=> otherVector - vector;
	// method: return the displacement to the given transform from this given position //
	public static Vector3 displacementTo(this Vector3 position, Transform transform)
		=> position.displacementTo(transform.position);
	// method: return the displacement to the given game object from this given position //
	public static Vector3 displacementTo(this Vector3 position, GameObject gameObject)
		=> position.displacementTo(gameObject.position());
	// method: return the displacement to the given component from this given position //
	public static Vector3 displacementTo(this Vector3 position, Component component)
		=> position.displacementTo(component.position());
	// method: return the displacement to the main camera from this given position //
	public static Vector3 displacementToCamera(this Vector3 position)
		=> position.displacementTo(Camera.main);

	// method: return the displacement to the given position from this given game object //
	public static Vector3 displacementTo(this GameObject gameObject, Vector3 position)
		=> gameObject.position().displacementTo(position);
	// method: return the displacement to the given transform from this given game object //
	public static Vector3 displacementTo(this GameObject gameObject, Transform transform)
		=> gameObject.position().displacementTo(transform.position);
	// method: return the displacement to the other given game object from this given game object //
	public static Vector3 displacementTo(this GameObject gameObject, GameObject otherGameObject)
		=> gameObject.position().displacementTo(otherGameObject.position());
	// method: return the displacement to the given component from this given game object //
	public static Vector3 displacementTo(this GameObject gameObject, Component component)
		=> gameObject.position().displacementTo(component.position());
	// method: return the displacement to the main camera from this given game object //
	public static Vector3 displacementToCamera(this GameObject gameObject)
		=> gameObject.position().displacementToCamera();

	// method: return the displacement to the given position from this given transform //
	public static Vector3 displacementTo(this Transform transform, Vector3 position)
		=> transform.position.displacementTo(position);
	// method: return the displacement to the other given transform from this given transform //
	public static Vector3 displacementTo(this Transform transform, Transform otherTransform)
		=> transform.position.displacementTo(otherTransform.position);
	// method: return the displacement to the given game object from this given transform //
	public static Vector3 displacementTo(this Transform transform, GameObject gameObject)
		=> transform.position.displacementTo(gameObject.position());
	// method: return the displacement to the given component from this given transform //
	public static Vector3 displacementTo(this Transform transform, Component component)
		=> transform.position.displacementTo(component.position());
	// method: return the displacement to the main camera from this given transform //
	public static Vector3 displacementToCamera(this Transform transform)
		=> transform.position.displacementToCamera();

	// method: return the displacement to the given position from this given component //
	public static Vector3 displacementTo(this Component component, Vector3 position)
		=> component.position().displacementTo(position);
	// method: return the displacement to the given transform from this given transform //
	public static Vector3 displacementTo(this Component component, Transform transform)
		=> component.position().displacementTo(transform.position);
	// method: return the displacement to the given game object from this given component //
	public static Vector3 displacementTo(this Component component, GameObject gameObject)
		=> component.position().displacementTo(gameObject.position());
	// method: return the displacement to the other given component from this given transform //
	public static Vector3 displacementTo(this Component component, Component otherComponent)
		=> component.position().displacementTo(otherComponent.position());
	// method: return the displacement to the main camera from this given component //
	public static Vector3 displacementToCamera(this Component component)
		=> component.position().displacementToCamera();
	#endregion to other
}