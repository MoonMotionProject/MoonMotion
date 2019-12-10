using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lodality Extensions:
// • provides extension methods for handling lodal (local or descendant beingness)
// #lodality #family #transform #component
public static class LodalityExtensions
{
	#region determining lodality

	// method: return whether this given transform is lodal to the other given transform //
	public static bool isLodalTo(this Transform transform, Transform otherTransform)
		=> transform.IsChildOf(otherTransform);
	// method: return whether this given game object is lodal to the given transform //
	public static bool isLodalTo(this GameObject gameObject, Transform transform)
		=> gameObject.transform.isLodalTo(transform);
	// method: return whether this given component is lodal to the given transform //
	public static bool isLodalTo(this Component component, Transform transform)
		=> component.transform.isLodalTo(transform);

	// method: return whether this given transform is lodal to the given game object //
	public static bool isLodalTo(this Transform transform, GameObject gameObject)
		=> transform.isLodalTo(gameObject.transform);
	// method: return whether this given game object is lodal to the other given game object //
	public static bool isLodalTo(this GameObject gameObject, GameObject otherGameObject)
		=> gameObject.transform.isLodalTo(otherGameObject);
	// method: return whether this given component is lodal to the given game object //
	public static bool isLodalTo(this Component component, GameObject gameObject)
		=> component.transform.isLodalTo(gameObject);

	// method: return whether this given transform is lodal to the given component //
	public static bool isLodalTo(this Transform transform, Component component)
		=> transform.isLodalTo(component);
	// method: return whether this given game object is lodal to the given component //
	public static bool isLodalTo(this GameObject gameObject, Component component)
		=> gameObject.transform.isLodalTo(component);
	// method: return whether this given component is lodal to the other given component //
	public static bool isLodalTo(this Component component, Component otherComponent)
		=> component.transform.isLodalTo(otherComponent);

	// method: return whether this given transform is lodal to the specified singleton behaviour class //
	public static bool isLodalTo<SingletonBehaviourT>(this Transform transform) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> transform.isLodalTo(SingletonBehaviour<SingletonBehaviourT>.transform);
	// method: return whether this given game object is lodal to the specified singleton behaviour class //
	public static bool isLodalTo<SingletonBehaviourT>(this GameObject gameObject) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> gameObject.transform.isLodalTo<SingletonBehaviourT>();
	// method: return whether this given component is lodal to the specified singleton behaviour class //
	public static bool isLodalTo<SingletonBehaviourT>(this Component component) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> component.transform.isLodalTo<SingletonBehaviourT>();

	// method: return whether this given game object has any of the specified type of lodal component, optionally including inactive components according to the given boolean //
	public static bool hasAnyLodal<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(gameObject.lodal<ComponentT>(includeInactiveComponents));
	public static bool hasNoLodal<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> !gameObject.hasAnyLodal<ComponentT>(includeInactiveComponents);
	public static bool hasAnyLodalSolid<ColliderT>(this GameObject gameObject, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> Any.itemsIn(gameObject.lodalSolid<ColliderT>(includeInactiveColliders));
	public static bool hasAnyLodalTrigger<ColliderT>(this GameObject gameObject, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> Any.itemsIn(gameObject.lodalTrigger<ColliderT>(includeInactiveColliders));
	public static bool hasAnyLodal<ComponentT>(this GameObject gameObject, Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.lodal<ComponentT>(includeInactiveComponents).hasAny(function);
	public static bool hasNoLodal<ComponentT>(this GameObject gameObject, Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAnyLodal(function, includeInactiveComponents);

	// method: return whether this given transform has any of the specified type of lodal component, optionally including inactive components according to the given boolean //
	public static bool hasAnyLodal<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(transform.lodal<ComponentT>(includeInactiveComponents));

	// method: return whether this given component has any of the specified type of lodal component, optionally including inactive components according to the given boolean //
	public static bool hasAnyLodal<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(component.lodal<ComponentT>(includeInactiveComponents));

	// method: return whether this given raycast hit's game object has any of the specified type of lodal component, optionally including inactive components according to the given boolean //
	public static bool hasAnyLodal<ComponentT>(this RaycastHit raycastHit, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(raycastHit.lodal<ComponentT>(includeInactiveComponents));
	
	/* (via reflection) */
	public static bool hasAnyLodalI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (Interfaces.doesNotInclude<ComponentI>())
		{
			return false.returnWithError(typeof(ComponentI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return Any.itemsIn(gameObject.lodalI<ComponentI>(includeInactiveComponents));
	}
	#endregion determining lodality


	#region accessing lodals

	// method: return this given game object's first lodal component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLodal<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.GetComponentInChildren<ComponentT>(includeInactiveComponents);
	// method: return this given transform's first lodal component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLodal<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.GetComponentInChildren<ComponentT>(includeInactiveComponents);
	// method: return this given component's first lodal component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLodal<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.GetComponentInChildren<ComponentT>(includeInactiveComponents);
	// method: return this given raycast hit's first lodal component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLodal<ComponentT>(this RaycastHit raycastHit, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> raycastHit.transform.firstLodal<ComponentT>(includeInactiveComponents);

	public static ComponentT firstLodalWhere<ComponentT>(this GameObject gameObject, Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.lodal<ComponentT>(includeInactiveComponents).firstWhere(function);

	public static ColliderT firstLodalSolid<ColliderT>(this GameObject gameObject, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> gameObject.lodalSolid<ColliderT>(includeInactiveColliders).first();
	public static ColliderT firstLodalSolid<ColliderT>(this Component component, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> component.gameObject.firstLodalSolid<ColliderT>(includeInactiveColliders);

	public static ColliderT firstLodalTrigger<ColliderT>(this GameObject gameObject, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> gameObject.lodalTrigger<ColliderT>(includeInactiveColliders).first();
	public static ColliderT firstLodalTrigger<ColliderT>(this Component component, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> component.gameObject.firstLodalTrigger<ColliderT>(includeInactiveColliders);
	
	public static GameObject firstLodalObjectWith<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstLodal<ComponentT>().gameObject;
	public static GameObject firstLodalObjectWith<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.firstLodal<ComponentT>().gameObject;
	
	/* (via reflection) */
	public static ComponentI firstLodalI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (Interfaces.doesNotInclude<ComponentI>())
		{
			return default(ComponentI).returnWithError(typeof(ComponentI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return gameObject.GetComponentInChildren<ComponentI>(includeInactiveComponents);
	}

	// method: return an array of this given game object's lodal components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] lodal<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.GetComponentsInChildren<ComponentT>(includeInactiveComponents);
	// method: return an array of this given component's lodal components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] lodal<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.GetComponentsInChildren<ComponentT>(includeInactiveComponents);
	// method: return an array of this given raycast hit's game object's lodal components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] lodal<ComponentT>(this RaycastHit raycastHit, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> raycastHit.transform.lodal<ComponentT>(includeInactiveComponents);
	public static HashSet<ColliderT> lodalSolid<ColliderT>(this GameObject gameObject, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> gameObject.lodal<ColliderT>(includeInactiveColliders).uniquesWhere(lodalCollider => lodalCollider.isSolid());
	public static HashSet<ColliderT> lodalSolid<ColliderT>(this Component component, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> component.gameObject.lodalSolid<ColliderT>(includeInactiveColliders);
	public static HashSet<ColliderT> lodalTrigger<ColliderT>(this GameObject gameObject, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> gameObject.lodal<ColliderT>(includeInactiveColliders).uniquesWhere(lodalCollider => lodalCollider.isTrigger);
	public static HashSet<ColliderT> lodalTrigger<ColliderT>(this Component component, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> component.gameObject.lodalTrigger<ColliderT>(includeInactiveColliders);
	
	/* (via reflection) */
	// method: return an array of the specified interface of components, optionally including inactive components according to the given boolean, which are lodal to this given game object //
	public static ComponentI[] lodalI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (Interfaces.doesNotInclude<ComponentI>())
		{
			return default(ComponentI[]).returnWithError(typeof(ComponentI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return gameObject.GetComponentsInChildren<ComponentI>(includeInactiveComponents);
	}

	/* (via reflection) */
	// method: return the set of game objects with the specified interface of components, optionally including inactive components according to the given boolean, which are lodal to this given game object //
	public static HashSet<GameObject> lodalObjectsWithI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (Interfaces.doesNotInclude<ComponentI>())
		{
			return default(HashSet<GameObject>).returnWithError(typeof(ComponentI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return gameObject.lodal<Component>(includeInactiveComponents).where(monoBehaviour =>
			monoBehaviour is ComponentI).uniqueObjects();
	}
	#endregion accessing lodals
}