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


	#region for affinity about other

	// method: return the direction for the given affinity upon the other given vector from this given vector //
	public static Vector3 directionForAffinityAbout(this Vector3 vector, Vector3 otherVector, Affinity affinity)
		=> vector.directionFrom(otherVector) * affinity.asSign();
	// method: return the direction for the given affinity upon the given transform from this given position //
	public static Vector3 directionForAffinityAbout(this Vector3 position, Transform transform, Affinity affinity)
		=> position.directionForAffinityAbout(transform.position, affinity);
	// method: return the direction for the given affinity upon the given game object from this given position //
	public static Vector3 directionForAffinityAbout(this Vector3 position, GameObject gameObject, Affinity affinity)
		=> position.directionForAffinityAbout(gameObject.position(), affinity);
	// method: return the direction for the given affinity upon the given component from this given position //
	public static Vector3 directionForAffinityAbout(this Vector3 position, Component component, Affinity affinity)
		=> position.directionForAffinityAbout(component.position(), affinity);
	// method: return the direction for the given affinity upon the main camera from this given position //
	public static Vector3 directionForAffinityAboutCamera(this Vector3 position, Affinity affinity)
		=> position.directionForAffinityAbout(Camera.main, affinity);

	// method: return the direction for the given affinity upon the given position from this given game object //
	public static Vector3 directionForAffinityAbout(this GameObject gameObject, Vector3 position, Affinity affinity)
		=> gameObject.position().directionForAffinityAbout(position, affinity);
	// method: return the direction for the given affinity upon the given transform from this given game object //
	public static Vector3 directionForAffinityAbout(this GameObject gameObject, Transform transform, Affinity affinity)
		=> gameObject.position().directionForAffinityAbout(transform.position, affinity);
	// method: return the direction for the given affinity upon the other given game object from this given game object //
	public static Vector3 directionForAffinityAbout(this GameObject gameObject, GameObject otherGameObject, Affinity affinity)
		=> gameObject.position().directionForAffinityAbout(otherGameObject.position(), affinity);
	// method: return the direction for the given affinity upon the given component from this given game object //
	public static Vector3 directionForAffinityAbout(this GameObject gameObject, Component component, Affinity affinity)
		=> gameObject.position().directionForAffinityAbout(component.position(), affinity);
	// method: return the direction for the given affinity upon the main camera from this given game object //
	public static Vector3 directionForAffinityAboutCamera(this GameObject gameObject, Affinity affinity)
		=> gameObject.position().directionForAffinityAboutCamera(affinity);

	// method: return the direction for the given affinity upon the given position from this given transform //
	public static Vector3 directionForAffinityAbout(this Transform transform, Vector3 position, Affinity affinity)
		=> transform.position.directionForAffinityAbout(position, affinity);
	// method: return the direction for the given affinity upon the other given transform from this given transform //
	public static Vector3 directionForAffinityAbout(this Transform transform, Transform otherTransform, Affinity affinity)
		=> transform.position.directionForAffinityAbout(otherTransform.position, affinity);
	// method: return the direction for the given affinity upon the given game object from this given transform //
	public static Vector3 directionForAffinityAbout(this Transform transform, GameObject gameObject, Affinity affinity)
		=> transform.position.directionForAffinityAbout(gameObject.position(), affinity);
	// method: return the direction for the given affinity upon the given component from this given transform //
	public static Vector3 directionForAffinityAbout(this Transform transform, Component component, Affinity affinity)
		=> transform.position.directionForAffinityAbout(component.position(), affinity);
	// method: return the direction for the given affinity upon the main camera from this given transform //
	public static Vector3 directionForAffinityAboutCamera(this Transform transform, Affinity affinity)
		=> transform.position.directionForAffinityAboutCamera(affinity);

	// method: return the direction for the given affinity upon the given position from this given component //
	public static Vector3 directionForAffinityAbout(this Component component, Vector3 position, Affinity affinity)
		=> component.position().directionForAffinityAbout(position, affinity);
	// method: return the direction for the given affinity upon the given transform from this given transform //
	public static Vector3 directionForAffinityAbout(this Component component, Transform transform, Affinity affinity)
		=> component.position().directionForAffinityAbout(transform.position, affinity);
	// method: return the direction for the given affinity upon the given game object from this given component //
	public static Vector3 directionForAffinityAbout(this Component component, GameObject gameObject, Affinity affinity)
		=> component.position().directionForAffinityAbout(gameObject.position(), affinity);
	// method: return the direction for the given affinity upon the other given component from this given transform //
	public static Vector3 directionForAffinityAbout(this Component component, Component otherComponent, Affinity affinity)
		=> component.position().directionForAffinityAbout(otherComponent.position(), affinity);
	// method: return the direction for the given affinity upon the main camera from this given component //
	public static Vector3 directionForAffinityAboutCamera(this Component component, Affinity affinity)
		=> component.position().directionForAffinityAboutCamera(affinity);
	#endregion for affinity about other


	#region distinctivity conversion

	// method: return the local direction relative to the given transform for this given global direction //
	public static Vector3 asGlobalDirectionToLocalDirectionRelativeTo(this Vector3 globalDirection, Transform transform)
		=> transform.InverseTransformDirection(globalDirection);
	// method: return the local direction relative to the given component for this given global direction //
	public static Vector3 asGlobalDirectionToLocalDirectionRelativeTo(this Vector3 globalDirection, Component component)
		=> globalDirection.asGlobalDirectionToLocalDirectionRelativeTo(component.transform);
	// method: return the local direction relative to the given game object for this given global direction //
	public static Vector3 asGlobalDirectionToLocalDirectionRelativeTo(this Vector3 globalDirection, GameObject gameObject)
		=> globalDirection.asGlobalDirectionToLocalDirectionRelativeTo(gameObject.transform);

	// method: return the global direction for this given local direction relative to the given transform //
	public static Vector3 asLocalDirectionToGlobalDirectionFromRelativityOf(this Vector3 localDirection, Transform transform)
		=> transform.TransformDirection(localDirection);
	// method: return the global direction for this given local direction relative to the given component //
	public static Vector3 asLocalDirectionToGlobalDirectionFromRelativityOf(this Vector3 localDirection, Component component)
		=> localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(component.transform);
	// method: return the global direction for this given local direction relative to the given game object //
	public static Vector3 asLocalDirectionToGlobalDirectionFromRelativityOf(this Vector3 localDirection, GameObject gameObject)
		=> localDirection.asLocalDirectionToGlobalDirectionFromRelativityOf(gameObject.transform);

	// method: return the local direction for this given direction with the given distinctivity, relative to the given transform if local //
	public static Vector3 toLocalDirectionFromDistinctivityOf(this Vector3 direction, Distinctivity currentDirectionDistinctivity, Transform potentialTransform)
		=> currentDirectionDistinctivity.isRelative() ?
				direction :
				direction.asGlobalDirectionToLocalDirectionRelativeTo(potentialTransform);
	// method: return the local direction for this given direction with the given distinctivity, relative to the given transform if local //
	public static Vector3 toLocalDirectionFromDistinctivityOf(this Vector3 direction, Distinctivity currentDirectionDistinctivity, Component potentialComponent)
		=> direction.toLocalDirectionFromDistinctivityOf(currentDirectionDistinctivity, potentialComponent.transform);
	// method: return the local direction for this given direction with the given distinctivity, relative to the given transform if local //
	public static Vector3 toLocalDirectionFromDistinctivityOf(this Vector3 direction, Distinctivity currentDirectionDistinctivity, GameObject potentialObject)
		=> direction.toLocalDirectionFromDistinctivityOf(currentDirectionDistinctivity, potentialObject.transform);

	// method: return the global direction for this given direction with the given distinctivity, relative to the given transform if local //
	public static Vector3 toGlobalDirectionFromDistinctivityOf(this Vector3 direction, Distinctivity currentDirectionDistinctivity, Transform potentialTransform)
		=>	currentDirectionDistinctivity.isAbsolute() ?
				direction :
				direction.asLocalDirectionToGlobalDirectionFromRelativityOf(potentialTransform);
	// method: return the global direction for this given direction with the given distinctivity, relative to the given component if local //
	public static Vector3 toGlobalDirectionFromDistinctivityOf(this Vector3 direction, Distinctivity currentDirectionDistinctivity, Component potentialComponent)
		=> direction.toGlobalDirectionFromDistinctivityOf(currentDirectionDistinctivity, potentialComponent.transform);
	// method: return the global direction for this given direction with the given distinctivity, relative to the given game object if local //
	public static Vector3 toGlobalDirectionFromDistinctivityOf(this Vector3 direction, Distinctivity currentDirectionDistinctivity, GameObject potentialObject)
		=> direction.toGlobalDirectionFromDistinctivityOf(currentDirectionDistinctivity, potentialObject.transform);
	#endregion distinctivity conversion
}