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

	// method: return an accessor for each of the game objects that each of the respective yull components of these given components is attached to //
	public static IEnumerable<GameObject> accessObjects(this IEnumerable<Component> components)
		=> components.onlyYull().access(component => component.gameObject);
	// method: return an accessor for each of the game objects that are attached to each of these respective given raycast hits //
	public static IEnumerable<GameObject> accessObjects(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.access(raycastHit => raycastHit.gameObject());

	// method: return a list of each of the game objects that each of the respective yull components of these given components is attached to //
	public static List<GameObject> objects(this IEnumerable<Component> components)
		=> components.onlyYull().accessObjects().manifested();
	// method: return a list of each of the game objects that are attached to each of these respective given raycast hits //
	public static List<GameObject> objects(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.accessObjects().manifested();

	// method: return the set of all (unique) game objects that the yull components of these given components are attached to //
	public static HashSet<GameObject> uniqueObjects(this IEnumerable<Component> components)
		=> components.onlyYull().accessObjects().uniques();
	// method: return the set of all (unique) game objects attached to these given raycast hits //
	public static HashSet<GameObject> uniqueObjects(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.accessObjects().uniques();
	
	// method: return the set of all unique game objects that the yull components of this given component are attached to //
	public static HashSet<GameObject> uniqueObjects(this Component component)
		=> component.startEnumerable().uniqueObjects();
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


	#region DefaultAutoBehaviour

	public static DefaultAutoBehaviour defaultAutoBehaviour(this GameObject gameObject, bool includeInactiveDefaultAutoBehaviours = true)
		=> gameObject.first<DefaultAutoBehaviour>(includeInactiveDefaultAutoBehaviours);
	public static DefaultAutoBehaviour defaultAutoBehaviour(this Component component, bool includeInactiveDefaultAutoBehaviours = true)
		=> component.first<DefaultAutoBehaviour>(includeInactiveDefaultAutoBehaviours);

	public static DefaultAutoBehaviour ensuredDefaultAutoBehaviour(this GameObject gameObject)
		=> gameObject.ensured<DefaultAutoBehaviour>();
	public static DefaultAutoBehaviour ensuredDefaultAutoBehaviour(this Component component)
		=> component.ensured<DefaultAutoBehaviour>();
	#endregion DefaultAutoBehaviour


	#region Collider

	// method: return the collider attached to this given (nullable) raycast hit (null, if the nullable raycast hit is null) //
	public static Collider colliderIfYull(this RaycastHit? raycastHit)
		=> raycastHit?.collider;

	// method: return an accessor for each of the colliders that are attached to each of these respective given raycast hits //
	public static IEnumerable<Collider> accessColliders(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.access(raycastHit => raycastHit.collider);

	// method: return a list of each of the colliders that are attached to each of these respective given raycast hits //
	public static List<Collider> colliders(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.accessColliders().manifested();
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

	// method: return an accessor for each of the yull first rigidbodies that each of the respective yull game objects of these given game objects is attached to //
	public static IEnumerable<Rigidbody> accessRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.onlyYull().access(gameObject => gameObject.rigidbody()).onlyYull();
	// method: return an accessor for each of the yull first rigidbodies that each of the respective yull components of these given components is attached to //
	public static IEnumerable<Rigidbody> accessRigidbodies(this IEnumerable<Component> components)
		=> components.onlyYull().access(component => component.rigidbody()).onlyYull();
	// method: return an accessor for each of the rigidbodies that are attached to each of these respective given raycast hits //
	public static IEnumerable<Rigidbody> accessRigidbodies(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.access(raycastHit => raycastHit.rigidbody);

	// method: return a list of each of the yull first rigidbodies that each of the respective yull game objects of these given game objects is attached to //
	public static List<Rigidbody> rigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.accessRigidbodies().manifested();
	// method: return a list of each of the yull first rigidbodies that each of the respective yull components of these given components is attached to //
	public static List<Rigidbody> rigidbodies(this IEnumerable<Component> components)
		=> components.accessRigidbodies().manifested();
	// method: return a list of each of the rigidbodies that are attached to each of these respective given raycast hits //
	public static List<Rigidbody> rigidbodies(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.accessRigidbodies().manifested();
	
	// method: return a list of the yull first rigidbodies attached to this given game object //
	public static List<Rigidbody> rigidbodies(this GameObject gameObject)
		=> gameObject.startEnumerable().rigidbodies();
	// method: return a list of the yull first rigidbodies attached to this given component //
	public static List<Rigidbody> rigidbodies(this Component component)
		=> component.startEnumerable().rigidbodies();

	// method: return the set of all unique, yull, first rigidbodies that the yull game objects of these given game objects are attached to //
	public static HashSet<Rigidbody> uniqueRigidbodies(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.accessRigidbodies().uniques();
	// method: return the set of all unique, yull, first rigidbodies that the yull components of these given components are attached to //
	public static HashSet<Rigidbody> uniqueRigidbodies(this IEnumerable<Component> components)
		=> components.accessRigidbodies().uniques();
	// method: return the set of all unique, yull rigidbodies attached to these given raycast hits //
	public static HashSet<Rigidbody> uniqueRigidbodies(this IEnumerable<RaycastHit> raycastHits)
		=> raycastHits.accessRigidbodies().uniques();
	
	// method: return the set of all unique, yull, first rigidbodies that the yull game objects of this given game object is attached to //
	public static HashSet<Rigidbody> uniqueRigidbodies(this GameObject gameObject)
		=> gameObject.startEnumerable().uniqueRigidbodies();
	// method: return the set of all unique, yull, first rigidbodies that the yull components of this given game component is attached to //
	public static HashSet<Rigidbody> uniqueRigidbodies(this Component component)
		=> component.startEnumerable().uniqueRigidbodies();
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

	// method: return an accessor for each of the yull first renderers that each of the respective yull game objects of these given game objects is attached to //
	public static IEnumerable<Renderer> accessRenderers(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.onlyYull().access(gameObject => gameObject.renderer()).onlyYull();
	// method: return an accessor for each of the yull first renderers that each of the respective yull components of these given components is attached to //
	public static IEnumerable<Renderer> accessRenderers(this IEnumerable<Component> components)
		=> components.onlyYull().access(component => component.renderer()).onlyYull();

	// method: return a list of each of the yull first renderers that each of the respective yull game objects of these given game objects is attached to //
	public static List<Renderer> renderers(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.accessRenderers().manifested();
	// method: return a list of each of the yull first renderers that each of the respective yull components of these given components is attached to //
	public static List<Renderer> renderers(this IEnumerable<Component> components)
		=> components.accessRenderers().manifested();

	// method: return the set of all unique, yull, first renderers that the yull game objects of these given game objects are attached to //
	public static HashSet<Renderer> uniqueRenderers(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.accessRenderers().uniques();
	// method: return the set of all unique, yull, first renderers that the yull components of these given components are attached to //
	public static HashSet<Renderer> uniqueRenderers(this IEnumerable<Component> components)
		=> components.accessRenderers().uniques();
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

	public static MeshFilter firstLodalMeshFilter(this GameObject gameObject, bool includeInactiveMeshFilters = true)
		=> gameObject.firstLodal<MeshFilter>(includeInactiveMeshFilters);
	public static MeshFilter firstLodalMeshFilter(this Component component, bool includeInactiveMeshFilters = true)
		=> component.firstLodal<MeshFilter>(includeInactiveMeshFilters);
	#endregion MeshFilter
	#endregion retrieval
}