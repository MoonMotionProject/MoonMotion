using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attachment Extensions: provides extension methods for handling attachment //
public static class AttachmentExtensions
{
	#region GameObject

	// method: return the game object attached to this given raycast hit //
	public static GameObject gameObject(this RaycastHit raycastHit)
		=> raycastHit.transform.gameObject;

	// method: return a selection of each of the game objects that each of the respective yull components of these given components is attached to //
	public static IEnumerable<GameObject> selectObjects(this IEnumerable<Component> components)
		=> components.onlyYull().select(component => component.gameObject);
	// method: return a selection of each of the game objects that are attached to each of these respective given raycast hits //
	public static IEnumerable<GameObject> selectObjects(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.select(raycastHit => raycastHit.gameObject());

	// method: return a list of each of the game objects that each of the respective yull components of these given components is attached to //
	public static List<GameObject> objects(this IEnumerable<Component> components)
		=> components.onlyYull().selectObjects().manifest();
	// method: return a list of each of the game objects that are attached to each of these respective given raycast hits //
	public static List<GameObject> objects(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.selectObjects().manifest();

	// method: return the set of all (unique) game objects that the yull components of these given components are attached to //
	public static HashSet<GameObject> uniqueObjects(this IEnumerable<Component> components)
		=> components.onlyYull().selectObjects().toSet();
	// method: return the set of all (unique) game objects attached to these given raycast hits //
	public static HashSet<GameObject> uniqueObjects(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.selectObjects().toSet();
	#endregion GameObject


	#region Rigidbody

	// method: return the rigidbody attached to this given game object (null if none found), optionally including inactive rigidbodies according to the given boolean //
	public static Rigidbody rigidbody(this GameObject gameObject, bool includeInactiveRigidbodies = true)
		=> gameObject.first<Rigidbody>(includeInactiveRigidbodies);
	// method: return the rigidbody attached to this given component (null if none found), optionally including inactive rigidbodies according to the given boolean //
	public static Rigidbody rigidbody(this Component component, bool includeInactiveRigidbodies = true)
		=> component.first<Rigidbody>(includeInactiveRigidbodies);

	// method: return a selection of each of the yull first rigidbodies that each of the respective yull game objects of these given game objects is attached to //
	public static IEnumerable<Rigidbody> selectRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.onlyYull().select(gameObject => gameObject.rigidbody()).onlyYull();
	// method: return a selection of each of the yull first rigidbodies that each of the respective yull components of these given components is attached to //
	public static IEnumerable<Rigidbody> selectRigidbodies(this IEnumerable<Component> components)
		=> components.onlyYull().select(component => component.rigidbody()).onlyYull();
	// method: return a selection of each of the rigidbodies that are attached to each of these respective given raycast hits //
	public static IEnumerable<Rigidbody> selectRigidbodies(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.select(raycastHit => raycastHit.rigidbody);

	// method: return a list of each of the yull first rigidbodies that each of the respective yull game objects of these given game objects is attached to //
	public static List<Rigidbody> rigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.selectRigidbodies().manifest();
	// method: return a list of each of the yull first rigidbodies that each of the respective yull components of these given components is attached to //
	public static List<Rigidbody> rigidbodies(this IEnumerable<Component> components)
		=> components.selectRigidbodies().manifest();
	// method: return a list of each of the rigidbodies that are attached to each of these respective given raycast hits //
	public static List<Rigidbody> rigidbodies(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.selectRigidbodies().manifest();

	// method: return the set of all unique, yull, first rigidbodies that the yull game objects of these given game objects are attached to //
	public static HashSet<Rigidbody> uniqueRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.selectRigidbodies().toSet();
	// method: return the set of all unique, yull, first rigidbodies that the yull components of these given components are attached to //
	public static HashSet<Rigidbody> uniqueRigidbodies(this IEnumerable<Component> components)
		=> components.selectRigidbodies().toSet();
	// method: return the set of all unique, yull rigidbodies attached to these given raycast hits //
	public static HashSet<Rigidbody> uniqueRigidbodies(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.selectRigidbodies().toSet();
	#endregion Rigidbody


	#region Collider

	// method: return a selection of each of the colliders that are attached to each of these respective given raycast hits //
	public static IEnumerable<Collider> selectColliders(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.select(raycastHit => raycastHit.collider);

	// method: return a list of each of the colliders that are attached to each of these respective given raycast hits //
	public static List<Collider> colliders(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.selectColliders().manifest();
	#endregion Collider


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