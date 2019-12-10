using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Locality Extensions:
// • provides extension methods for handling locality
// #local #family #transform #component
public static class LocalityExtensions
{
	#region determining local components

	// method: return whether this given game object has any of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool hasAny<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(gameObject.pick<ComponentT>(includeInactiveComponents));
	// method: return whether this given transform has any of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool hasAny<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.hasAny<ComponentT>(includeInactiveComponents);
	// method: return whether this given component's game object has any of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool hasAny<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.hasAny<ComponentT>(includeInactiveComponents);
	// method: return whether this given raycast hit's game object has any of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool hasAny<ComponentT>(this RaycastHit raycastHit, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> raycastHit.gameObject().hasAny<ComponentT>(includeInactiveComponents);

	// methods: return whether this given provided game object has any of the specified type of component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool hasAny<ComponentT>
	(
		this GameObject gameObject,
		Func<ComponentT, bool> function,
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentT : Component
		=> gameObject.pick<ComponentT>(includeInactiveComponents).hasAny(function);
	public static bool hasAny<ComponentT>
	(
		this Transform transform,
		Func<ComponentT, bool> function,
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentT : Component
		=> transform.gameObject.hasAny(function, includeInactiveComponents);
	public static bool hasAny<ComponentT>
	(
		this Component component,
		Func<ComponentT, bool> function,
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentT : Component
		=> component.gameObject.hasAny(function, includeInactiveComponents);

	/* (via reflection) */
	// methods: return whether this given provided game object has any component of the specified interface, optionally including inactive components according to the given boolean //
	public static bool hasAnyI<ComponentI>
	(
		this GameObject gameObject,
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentI : class
	{
		if (Interfaces.doesNotInclude<ComponentI>())
		{
			return false.returnWithError(typeof(ComponentI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return gameObject.pickI<ComponentI>(includeInactiveComponents).hasAny();
	}
	public static bool hasAnyI<ComponentI>
	(
		this Transform transform,
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentI : class
		=> transform.gameObject.hasAnyI<ComponentI>(includeInactiveComponents);
	public static bool hasAnyI<ComponentI>
	(
		this Component component,
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentI : class
		=> component.gameObject.hasAnyI<ComponentI>(includeInactiveComponents);

	/* (via reflection) */
	// methods: return whether this given provided game object has any component of the specified interface for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool hasAnyI<ComponentI>
	(
		this GameObject gameObject,
		Func<ComponentI, bool> function,
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentI : class
	{
		if (Interfaces.doesNotInclude<ComponentI>())
		{
			return false.returnWithError(typeof(ComponentI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return gameObject.pickI<ComponentI>(includeInactiveComponents).hasAny(function);
	}
	public static bool hasAnyI<ComponentI>
	(
		this Transform transform,
		Func<ComponentI, bool> function,
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentI : class
		=> transform.gameObject.hasAnyI(function, includeInactiveComponents);
	public static bool hasAnyI<ComponentI>
	(
		this Component component,
		Func<ComponentI, bool> function,
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentI : class
		=> component.gameObject.hasAnyI(function, includeInactiveComponents);

	// method: return whether this given game object has none of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool hasNo<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> !gameObject.hasAny<ComponentT>(includeInactiveComponents);

	// method: return whether this given transform has none of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool hasNo<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.hasNo<ComponentT>(includeInactiveComponents);

	// method: return whether this given component's game object has none of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool hasNo<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.hasNo<ComponentT>(includeInactiveComponents);

	// method: return whether this given game object contains any components other than the specified component, optionally including inactive components according to the given boolean //
	public static bool hasAnyComponentOtherThan(this GameObject gameObject, Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.components(includeInactiveComponents).containsOtherThan(component);

	// method: return whether this given transform contains any components other than the given component, optionally including inactive components according to the given boolean //
	public static bool hasAnyComponentOtherThan(this Transform transform, Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> transform.gameObject.hasAnyComponentOtherThan(component, includeInactiveComponents);

	// method: return whether this given component's game object has any components other than this given component, optionally including inactive components according to the given boolean //
	public static bool hasAnyOtherComponent(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.gameObject.hasAnyComponentOtherThan(component, includeInactiveComponents);

	// method: return whether this given game object contains any components other than the given component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool hasAnyComponentExcept(this GameObject gameObject, Component component, Func<Component, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.components(includeInactiveComponents).except(component).hasAny(function);

	// method: return whether this given transform contains any components other than the given component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool hasAnyComponentExcept(this Transform transform, Component component, Func<Component, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> transform.gameObject.hasAnyComponentExcept(component, function, includeInactiveComponents);

	// method: return whether this given component's game object has any components other than this given component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool hasAnyOtherComponent(this Component component, Func<Component, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.gameObject.hasAnyComponentExcept(component, function, includeInactiveComponents);

	// method: return whether this given game object has any auto behaviours, optionally including inactive components according to the given boolean //
	public static bool hasAnyAutoBehaviours(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> Any.itemsIn(gameObject.autoBehaviours(includeInactiveComponents));

	// method: return whether this given transform has any auto behaviours, optionally including inactive components according to the given boolean //
	public static bool hasAnyAutoBehaviours(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> transform.gameObject.hasAnyAutoBehaviours(includeInactiveComponents);

	// method: return whether this given component's game object has any auto behaviours, optionally including inactive components according to the given boolean //
	public static bool hasAnyAutoBehaviours(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.gameObject.hasAnyAutoBehaviours(includeInactiveComponents);

	// method: return whether this given auto behaviour's game object has any other auto behaviours, optionally including inactive components according to the given boolean //
	public static bool hasAnyOtherAutoBehaviours<AutoBehaviourT>(this AutoBehaviourT autoBehaviour, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
		=> autoBehaviour.autoBehaviours().containsOtherThan(autoBehaviour);
	#endregion determining local components


	#region accessing local components

	// method: return this given game object's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT first<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=>	includeInactiveComponents ?
				gameObject.GetComponent<ComponentT>() :
				gameObject.pick<ComponentT>(false).firstOtherwiseDefault();
	// method: return this given transform's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT first<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.first<ComponentT>(includeInactiveComponents);
	// method: return this given component's game object's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT first<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.first<ComponentT>(includeInactiveComponents);
	/* (via reflection) */
	// method: return this given game object's first component of the specified interface (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentI firstI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (Interfaces.doesNotInclude<ComponentI>())
		{
			return default(ComponentI).returnWithError(typeof(ComponentI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return	includeInactiveComponents ?
					gameObject.GetComponent<ComponentI>() :
					gameObject.pickI<ComponentI>(false).firstOtherwiseDefault();
	}
	
	// method: return an accessor for the specified class of components in these given game objects, optionally including inactive components according to the given boolean //
	public static IEnumerable<ComponentT> accessEachFirst<ComponentT>(this GameObject[] gameObjects, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObjects.accessFromYull(gameObject => gameObject.first<ComponentT>(includeInactiveComponents));
	// method: return an accessor for the specified class of components in these given transforms, optionally including inactive components according to the given boolean //
	public static IEnumerable<ComponentT> accessEachFirst<ComponentT>(this Transform[] transforms, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transforms.accessFromYull(transform => transform.first<ComponentT>(includeInactiveComponents));

	// method: return a list of the specified class of components, optionally including inactive components according to the given boolean, on this given game object //
	public static List<ComponentT> pick<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=>	gameObject.GetComponents<ComponentT>().where(component =>
				component.isActiveGlobally(),
				!includeInactiveComponents);
	// method: return a list of the specified class of components, optionally including inactive components according to the given boolean, on this given transform //
	public static List<ComponentT> pick<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.pick<ComponentT>(includeInactiveComponents);
	// method: return a list of the specified class of components on this given component's game object, optionally including inactive components according to the given boolean //
	public static List<ComponentT> pick<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.pick<ComponentT>(includeInactiveComponents);
	/* (via reflection) */
	// method: return a list of the specified interface of components, optionally including inactive components according to the given boolean, on this given game object //
	public static List<ComponentI> pickI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (Interfaces.doesNotInclude<ComponentI>())
		{
			return default(List<ComponentI>).returnWithError(typeof(ComponentI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return	gameObject.GetComponents<ComponentI>().where(component =>
					component.castTo<Component>().isActiveGlobally(),
					!includeInactiveComponents);
	}

	// method: return the set of unique components of the specified type that are attached to any of the given game objects, optionally including inactive components according to the given boolean //
	public static HashSet<ComponentT> unique<ComponentT>(this IEnumerable<GameObject> gameObjects, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObjects.pickUniqueNested(gameObject => gameObject.pick<ComponentT>(includeInactiveComponents));

	// method: return a list of all components on this given component's game object, optionally including inactive components according to the given boolean //
	public static List<Component> components(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.pick<Component>(includeInactiveComponents);
	// method: return a list of all components on this given component's game object, optionally including inactive components according to the given boolean //
	public static List<Component> components(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> transform.gameObject.components();
	// method: return a list of all components on this given component's game object, optionally including inactive components according to the given boolean //
	public static List<Component> components(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.gameObject.components();

	// method: return a list of all auto behaviours on this given game object, optionally including inactive components according to the given boolean //
	public static List<IAutoBehaviour> autoBehaviours(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.pickI<IAutoBehaviour>(includeInactiveComponents);
	// method: return a list of all auto behaviours on this given transform's game object, optionally including inactive components according to the given boolean //
	public static List<IAutoBehaviour> autoBehaviours(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> transform.gameObject.autoBehaviours();
	// method: return a list of all auto behaviours on this given component's game object, optionally including inactive components according to the given boolean //
	public static List<IAutoBehaviour> autoBehaviours(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.gameObject.autoBehaviours();
	#endregion accessing local components


	#region picking upon local components

	public static TResult pickUponFirstIfAny<ComponentT, TResult>(this GameObject gameObject, Func<ComponentT, TResult> function, Func<TResult> fallbackfunction) where ComponentT : Component
	{
		if (fallbackfunction.isNull())
		{
			return default(TResult).returnWithError("given null fallback function");
		}

		if (gameObject.hasAny<ComponentT>())
		{
			return function(gameObject.first<ComponentT>());
		}
		else
		{
			return fallbackfunction();
		}
	}
	#endregion picking upon local components


	#region iterating local components

	// method: invoke the given action on each of the specified class of components on this given game object, optionally including inactive components according to the given boolean, then return this given game object //
	public static GameObject forEach<ComponentT>(this GameObject gameObject, Action<ComponentT> action, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.after(()=>
			gameObject.pick<ComponentT>(includeInactiveComponents).forEach(action));
	// method: invoke the given action on each of the specified class of components on this given transform's game object, optionally including inactive components according to the given boolean, then return this given transform //
	public static Transform forEach<ComponentT>(this Transform transform, Action<ComponentT> action, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.forEach(action, includeInactiveComponents).transform;
	// method: invoke the given action on each of the specified class of components on this given component's game object, optionally including inactive components according to the given boolean, then return this given component //
	public static ComponentTThis forEach<ComponentTThis, ComponentTEach>(this ComponentTThis component, Action<ComponentTEach> action, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentTThis : Component where ComponentTEach : Component
		=> component.after(()=>
			component.gameObject.forEach(action, includeInactiveComponents));

	// methods: invoke the given action on each component on this given provided game object, optionally including inactive components according to the given boolean, then return this given game object //
	public static GameObject forEachComponent(this GameObject gameObject, Action<Component> action, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=>	gameObject.forEach(action, includeInactiveComponents);
	public static ComponentT forEachComponent<ComponentT>(this ComponentT component, Action<Component> action, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.forEachComponent(action, includeInactiveComponents));

	// method: (via reflection:) invoke the given action on each component on this given game object that is not derived from the specified type, optionally including inactive components according to the given boolean, then return this given game object //
	public static GameObject forEachComponentThatIsNotDerivedFrom_ViaReflection<ComponentT>(this GameObject gameObject, Action<Component> action, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=>	gameObject.forEachComponent(component =>
			{
				if (component.isNotDerivedFrom_ViaReflection<ComponentT>())
				{
					action(component);
				}
			}, includeInactiveComponents);
	#endregion iterating local components
}