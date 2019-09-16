using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attachment Extensions: provides extension methods for handling attachment //
public static class AttachmentExtensions
{
	#region GameObject

	// method: return a selection of the game objects these given components are attached to //
	public static IEnumerable<GameObject> selectObjects(this IEnumerable<Component> components)
		=> components.select(component => component.gameObject);
	// method: return a list of the game objects these given components are attached to //
	public static List<GameObject> objects(this IEnumerable<Component> components)
		=> components.selectObjects().manifest();
	// method: return the set of the game objects these given components are attached to //
	public static HashSet<GameObject> uniqueObjects(this IEnumerable<Component> components)
		=> components.selectObjects().toSet();
	#endregion GameObject


	#region Rigidbody (assumes max one per object)

	// method: return the rigidbody attached to this given game object (null if none found), optionally including inactive rigidbodies according to the given boolean //
	public static Rigidbody rigidbody(this GameObject gameObject, bool includeInactiveRigidbodies = true)
		=> gameObject.first<Rigidbody>(includeInactiveRigidbodies);
	// method: return the rigidbody attached to this given component (null if none found), optionally including inactive rigidbodies according to the given boolean //
	public static Rigidbody rigidbody(this Component component, bool includeInactiveRigidbodies = true)
		=> component.first<Rigidbody>(includeInactiveRigidbodies);

	// method: return a selection of all rigidbodies these given game objects are attached to //
	public static IEnumerable<Rigidbody> selectRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.select(gameObject => gameObject.rigidbody()).onlyYull();
	// method: return a selection of all rigidbodies these given components are attached to //
	public static IEnumerable<Rigidbody> selectRigidbodies(this IEnumerable<Component> components)
		=> components.select(component => component.rigidbody()).onlyYull();

	// method: return a list of all rigidbodies these given game objects are attached to //
	public static List<Rigidbody> rigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.selectRigidbodies().manifest();
	// method: return a list of all rigidbodies these given components are attached to //
	public static List<Rigidbody> rigidbodies(this IEnumerable<Component> components)
		=> components.selectRigidbodies().manifest();

	// method: return the set of all rigidbodies these given game objects are attached to //
	public static HashSet<Rigidbody> uniqueRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.selectRigidbodies().toSet();
	// method: return the set of all rigidbodies these given components are attached to //
	public static HashSet<Rigidbody> uniqueRigidbodies(this IEnumerable<Component> components)
		=> components.selectRigidbodies().toSet();
	#endregion Rigidbody (assumes max one per object)


	#region ComponentT

	// method: return this given component if it is attached to the given game object, otherwise returning null //
	public static ComponentT whereOn<ComponentT>(this ComponentT component, GameObject gameObject) where ComponentT : Component
	{
		if (component.gameObject == gameObject)
		{
			return component;
		}

		return null;
	}
	// method: return this given component if it is attached to the given transform, otherwise returning null //
	public static ComponentT whereOn<ComponentT>(this ComponentT component, Transform transform) where ComponentT : Component
	{
		if (component.transform == transform)
		{
			return component;
		}

		return null;
	}

	// method: return this given component if it is not attached to the given game object, otherwise returning null //
	public static ComponentT whereNotOn<ComponentT>(this ComponentT component, GameObject gameObject) where ComponentT : Component
	{
		if (component.gameObject != gameObject)
		{
			return component;
		}

		return null;
	}
	// method: return this given component if it is not attached to the given transform, otherwise returning null //
	public static ComponentT whereNotOn<ComponentT>(this ComponentT component, Transform transform) where ComponentT : Component
	{
		if (component.transform != transform)
		{
			return component;
		}

		return null;
	}
	#endregion attachment
}