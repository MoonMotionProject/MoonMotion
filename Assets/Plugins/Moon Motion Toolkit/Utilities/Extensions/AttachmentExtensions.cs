using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attachment Extensions: provides extension methods for handling attachment //
public static class AttachmentExtensions
{
	#region retrieval
	

	#region GameObject

	// method: return the game object attached to this given raycast hit //
	public static GameObject gameObject(this RaycastHit raycastHit)
	{
		if (raycastHit.transform)
		{
			return raycastHit.transform.gameObject;
		}
		return null;
	}
	// method: return the game object attached to this given (nullable) raycast hit (null, if the nullable raycast hit is null) //
	public static GameObject gameObjectIfYull(this RaycastHit? raycastHit)
		=> raycastHit?.gameObject();

	// method: return a selection of each of the game objects that each of the respective yull components of these given components is attached to //
	public static IEnumerable<GameObject> selectObjects(this IEnumerable<Component> components)
		=> components.onlyYull().select(component => component.gameObject);
	// method: return a selection of each of the game objects that are attached to each of these respective given raycast hits //
	public static IEnumerable<GameObject> selectObjects(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.select(raycastHit => raycastHit.gameObject());

	// method: return a list of each of the game objects that each of the respective yull components of these given components is attached to //
	public static List<GameObject> objects(this IEnumerable<Component> components)
		=> components.onlyYull().selectObjects().manifested();
	// method: return a list of each of the game objects that are attached to each of these respective given raycast hits //
	public static List<GameObject> objects(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.selectObjects().manifested();

	// method: return the set of all (unique) game objects that the yull components of these given components are attached to //
	public static HashSet<GameObject> uniqueObjects(this IEnumerable<Component> components)
		=> components.onlyYull().selectObjects().toSet();
	// method: return the set of all (unique) game objects attached to these given raycast hits //
	public static HashSet<GameObject> uniqueObjects(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.selectObjects().toSet();
	#endregion GameObject


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
	#endregion ComponentT


	#region Collider

	// method: return the collider attached to this given (nullable) raycast hit (null, if the nullable raycast hit is null) //
	public static Collider colliderIfYull(this RaycastHit? raycastHit)
		=> raycastHit?.collider;

	// method: return a selection of each of the colliders that are attached to each of these respective given raycast hits //
	public static IEnumerable<Collider> selectColliders(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.select(raycastHit => raycastHit.collider);

	// method: return a list of each of the colliders that are attached to each of these respective given raycast hits //
	public static List<Collider> colliders(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.selectColliders().manifested();
	#endregion Collider


	#region Rigidbody

	// method: return the rigidbody attached to this given game object (null if none found) //
	public static Rigidbody rigidbody(this GameObject gameObject)
		=> gameObject.first<Rigidbody>();
	// method: return the rigidbody attached to this given component (null if none found) //
	public static Rigidbody rigidbody(this Component component)
		=> component.first<Rigidbody>();
	// method: return the rigidbody attached to this given (nullable) raycast hit (null if the nullable raycast hit is null) //
	public static Rigidbody rigidbodyIfYull(this RaycastHit? raycastHit)
		=> raycastHit?.rigidbody;

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
		=> gameObjects.selectRigidbodies().manifested();
	// method: return a list of each of the yull first rigidbodies that each of the respective yull components of these given components is attached to //
	public static List<Rigidbody> rigidbodies(this IEnumerable<Component> components)
		=> components.selectRigidbodies().manifested();
	// method: return a list of each of the rigidbodies that are attached to each of these respective given raycast hits //
	public static List<Rigidbody> rigidbodies(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.selectRigidbodies().manifested();

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


	#region Renderer

	// method: return the renderer attached to this given game object (null if none found), optionally including inactive renderers according to the given boolean //
	public static Renderer renderer(this GameObject gameObject, bool includeInactiveRenderers = true)
		=> gameObject.first<Renderer>(includeInactiveRenderers);
	// method: return the renderer attached to this given component (null if none found), optionally including inactive renderers according to the given boolean //
	public static Renderer renderer(this Component component, bool includeInactiveRenderers = true)
		=> component.first<Renderer>(includeInactiveRenderers);

	// method: return the ensured renderer (if no first renderer, an add gotten mesh renderer) attached to this given game object, optionally including inactive renderers according to the given boolean //
	public static Renderer ensuredRenderer(this GameObject gameObject, bool includeInactiveRenderers = true)
		=> gameObject.ensured<Renderer, MeshRenderer>();
	// method: return the ensured renderer (if no first renderer, an add gotten mesh renderer) attached to this given component, optionally including inactive renderers according to the given boolean //
	public static Renderer ensuredRenderer(this Component component, bool includeInactiveRenderers = true)
		=> component.ensured<Renderer, MeshRenderer>();

	// method: return a selection of each of the yull first renderers that each of the respective yull game objects of these given game objects is attached to //
	public static IEnumerable<Renderer> selectRenderers(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.onlyYull().select(gameObject => gameObject.renderer()).onlyYull();
	// method: return a selection of each of the yull first renderers that each of the respective yull components of these given components is attached to //
	public static IEnumerable<Renderer> selectRenderers(this IEnumerable<Component> components)
		=> components.onlyYull().select(component => component.renderer()).onlyYull();

	// method: return a list of each of the yull first renderers that each of the respective yull game objects of these given game objects is attached to //
	public static List<Renderer> renderers(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.selectRenderers().manifested();
	// method: return a list of each of the yull first renderers that each of the respective yull components of these given components is attached to //
	public static List<Renderer> renderers(this IEnumerable<Component> components)
		=> components.selectRenderers().manifested();

	// method: return the set of all unique, yull, first renderers that the yull game objects of these given game objects are attached to //
	public static HashSet<Renderer> uniqueRenderers(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.selectRenderers().toSet();
	// method: return the set of all unique, yull, first renderers that the yull components of these given components are attached to //
	public static HashSet<Renderer> uniqueRenderers(this IEnumerable<Component> components)
		=> components.selectRenderers().toSet();
	#endregion Renderer


	#region MeshFilter

	public static MeshFilter meshFilter(this GameObject gameObject, bool includeInactiveMeshFilters = true)
		=> gameObject.first<MeshFilter>(includeInactiveMeshFilters);
	public static MeshFilter meshFilter(this Component component, bool includeInactiveMeshFilters = true)
		=> component.first<MeshFilter>(includeInactiveMeshFilters);

	public static MeshFilter ensuredMeshFilter(this GameObject gameObject)
		=> gameObject.ensured<MeshFilter>();
	public static MeshFilter ensuredMeshFilter(this Component component)
		=> component.ensured<MeshFilter>();
	#endregion MeshFilter
	#endregion retrieval
}