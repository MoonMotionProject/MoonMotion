using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Component Extensions: provides extension methods for handling components //
// #auto #component
public static class ComponentExtensions
{
	#region identification

	// method: return whether this given component's game object is named 'Player' //
	public static bool isPlayer(this Component component)
		=> component.gameObject.isPlayer();
	#endregion identification
	
	
	#region destruction

	// method: destroy this given component's game object according to the given booleanic function upon this given component //
	public static void destroyObject<ComponentT>(this ComponentT component, Func<ComponentT, bool> function) where ComponentT : Component
	{
		if (function(component))
		{
			component.gameObject.destroy();
		}
	}

	// method: (according to the given boolean:) destroy this given component's game object //
	public static void destroyObject(this Component component, bool boolean = true)
		=> component.destroyObject(component_ => boolean);

	// method: destroy all components in this given enumerable of components for which the given function returns true, then return this given enumerable //
	public static IEnumerable<ComponentT> destroyWhere<ComponentT>(this IEnumerable<ComponentT> enumerable, Func<ComponentT, bool> function) where ComponentT : Component
		=> enumerable.forEach(component => component.destroy(function));

	// method: destroy all objects of components in this given set of components for which the given function returns true, then return this given set //
	public static HashSet<ComponentT> destroyObjectsWhere<ComponentT>(this HashSet<ComponentT> set, Func<ComponentT, bool> function) where ComponentT : Component
		=> set.forEach(component => component.destroyObject(function));
	#endregion destruction


	#region activity

	// method: return whether this given component's game object is active locally //
	public static bool activeLocally(this Component component)
		=> component.gameObject.activeLocally();

	// method: return whether this given component's game object is active globally //
	public static bool activeGlobally(this Component component)
		=> component.gameObject.activeGlobally();

	// method: set the activity of this given component's game object to the given boolean, then return this given component //
	public static ComponentT setActivityTo<ComponentT>(this ComponentT component, bool activity) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.setActivityTo(activity));
	#endregion activity


	#region attachment

	// method: return this given component if it is attached to the given game object, otherwise returning null //
	public static ComponentT whereOn<ComponentT>(this ComponentT component, GameObject gameObject) where ComponentT : Component
	{
		if (component.gameObject == gameObject)
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

	// method: return this given component if it is attached to the given transform, otherwise returning null //
	public static ComponentT whereOn<ComponentT>(this ComponentT component, Transform transform) where ComponentT : Component
	{
		if (component.transform == transform)
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


	#region connection

	// method: return the array of game objects corresponding to these given components //
	public static GameObject[] gameObjects(this Component[] components)
		=> components.Select(component => component.gameObject).ToArray();
	#endregion connection


	#region calling local methods

	// method: (according to the given boolean:) call all of this component's game object's mono behaviours' defined methods (ignoring inherited methods that haven't been overriden) with the given name, then return this given game object //
	public static ComponentT callAllLocal<ComponentT>(this ComponentT component, string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.callAllLocal(methodName, sendMessageOptions, boolean));

	// method: have all mono behaviours on this component's game object validate (if they have OnValidate defined), then return this given component //
	public static ComponentT validate<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.validate());
	#endregion calling local methods


	#region inspector

	// method: hide this given component in the inspector, then return this given component //
	public static ComponentT hideInInspector<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			component.hideFlags = HideFlags.HideInInspector);

	// method: hide this given component in the inspector, then return this given component //
	public static ComponentT unhideInInspector<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			{if (component.hideFlags == HideFlags.HideInInspector) component.hideFlags = HideFlags.None;});
	#endregion inspector


	#region adding components

	// method: add a new component of the specified class to this given game object, then return the new component //
	public static ComponentT add<ComponentT>(this GameObject gameObject) where ComponentT : Component
		=> gameObject.AddComponent<ComponentT>();

	// method: add a new component of the specified class to this given transform's game object, then return the new component //
	public static ComponentT add<ComponentT>(this Transform transform) where ComponentT : Component
		=> transform.gameObject.add<ComponentT>();

	// method: add a new component of the specified class to this given component's game object, then return the new component //
	public static NewComponentT add<NewComponentT>(this Component component) where NewComponentT : Component
		=> component.gameObject.add<NewComponentT>();

	// method: add a new component of the specified class to this given game object, then return this given game object //
	public static GameObject afterAdding<ComponentT>(this GameObject gameObject) where ComponentT : Component
		=>	gameObject.after(()=>
				gameObject.add<ComponentT>());

	// method: add a new component of the specified class to this given transform's game object, then return this given transform //
	public static Transform afterAdding<ComponentT>(this Transform transform) where ComponentT : Component
		=> transform.gameObject.afterAdding<ComponentT>().transform;

	// method: add a new component of the specified class to this given component's game object, then return this given component //
	public static ThisComponentT afterAdding<ThisComponentT, NewComponentT>(this ThisComponentT component) where ThisComponentT : Component where NewComponentT : Component
	{
		component.gameObject.afterAdding<NewComponentT>();

		return component;
	}

	// method: if this given game object has none of the specified component, add a new component of the specified class to this given game object, then return the first such component on this given game object //
	public static ComponentT ensure<ComponentT>(this GameObject gameObject) where ComponentT : Component
		=> gameObject.first<ComponentT>() ?? gameObject.add<ComponentT>();

	// method: if this given transform's game object has none of the specified component, add a new component of the specified class to this given transform's game object, then return the first such component on this given transform's game object //
	public static ComponentT ensure<ComponentT>(this Transform transform) where ComponentT : Component
		=> transform.gameObject.ensure<ComponentT>();

	// method: if this given component's game object has none of the specified component, add a new component of the specified class to this given component's game object, then return the first such component on this given component's game object //
	public static ComponentT ensure<ComponentT>(this Component component) where ComponentT : Component
		=> component.gameObject.ensure<ComponentT>();
	#endregion adding components


	#region getting components in a given array

	// method: return an enumerable of the specified class of components, optionally including inactive components according to the given boolean, in these given game objects //
	public static IEnumerable<ComponentT> select<ComponentT>(this GameObject[] gameObjects, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObjects.selectWhereYull(gameObject => gameObject.first<ComponentT>(includeInactiveComponents));

	// method: return an enumerable of the specified class of components, optionally including inactive components according to the given boolean, in these given transforms //
	public static IEnumerable<ComponentT> select<ComponentT>(this Transform[] transforms, bool includeInactiveComponents = true) where ComponentT : Component
		=> transforms.selectWhereYull(transform => transform.first<ComponentT>(includeInactiveComponents));
	#endregion getting components in a given array


	#region determining local components

	// method: return whether this game object has any of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool any<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.select<ComponentT>(includeInactiveComponents).any();

	// method: return whether this transform has any of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool any<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.any<ComponentT>(includeInactiveComponents);

	// method: return whether this component's game object has any of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool any<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.any<ComponentT>(includeInactiveComponents);

	// method: return whether this game object has any of the specified type of component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool any<ComponentT>(this GameObject gameObject, Func<ComponentT, bool> function, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.select<ComponentT>(includeInactiveComponents).any(function);

	// method: return whether this transform's game object has any of the specified type of component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool any<ComponentT>(this Transform transform, Func<ComponentT, bool> function, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.any(function, includeInactiveComponents);

	// method: return whether this component's game object has any of the specified type of component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool any<ComponentT>(this Component component, Func<ComponentT, bool> function, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.any(function, includeInactiveComponents);

	// method: return whether this game object has none of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool hasNo<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> !gameObject.any<ComponentT>(includeInactiveComponents);

	// method: return whether this transform has none of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool hasNo<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.hasNo<ComponentT>(includeInactiveComponents);

	// method: return whether this component's game object has none of the specified type of component, optionally including inactive components according to the given boolean //
	public static bool hasNo<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.hasNo<ComponentT>(includeInactiveComponents);

	// method: return whether this game object contains any components other than the specified component, optionally including inactive components according to the given boolean //
	public static bool anyComponentOtherThan(this GameObject gameObject, Component component, bool includeInactiveComponents = true)
		=> gameObject.components(includeInactiveComponents).containsOtherThan(component);

	// method: return whether this transform contains any components other than the given component, optionally including inactive components according to the given boolean //
	public static bool anyComponentOtherThan(this Transform transform, Component component, bool includeInactiveComponents = true)
		=> transform.gameObject.anyComponentOtherThan(component, includeInactiveComponents);

	// method: return whether this component's game object has any components other than this given component, optionally including inactive components according to the given boolean //
	public static bool anyOtherComponent(this Component component, bool includeInactiveComponents = true)
		=> component.gameObject.anyComponentOtherThan(component, includeInactiveComponents);

	// method: return whether this game object contains any components other than the given component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool anyComponentOtherThan(this GameObject gameObject, Component component, Func<Component, bool> function, bool includeInactiveComponents = true)
		=> gameObject.components(includeInactiveComponents).whereNot(component).any(function);

	// method: return whether this transform contains any components other than the given component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool anyComponentOtherThan(this Transform transform, Component component, Func<Component, bool> function, bool includeInactiveComponents = true)
		=> transform.gameObject.anyComponentOtherThan(component, function, includeInactiveComponents);

	// method: return whether this component's game object has any components other than this given component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool anyOtherComponent(this Component component, Func<Component, bool> function, bool includeInactiveComponents = true)
		=> component.gameObject.anyComponentOtherThan(component, function, includeInactiveComponents);

	// method: return whether this game object has any automatic behaviours, optionally including inactive components according to the given boolean //
	public static bool anyAutomaticBehaviours(this GameObject gameObject, bool includeInactiveComponents = true)
		=> gameObject.automaticBehaviours(includeInactiveComponents).any();

	// method: return whether this transform has any automatic behaviours, optionally including inactive components according to the given boolean //
	public static bool anyAutomaticBehaviours(this Transform transform, bool includeInactiveComponents = true)
		=> transform.gameObject.anyAutomaticBehaviours(includeInactiveComponents);

	// method: return whether this component's game object has any automatic behaviours, optionally including inactive components according to the given boolean //
	public static bool anyAutomaticBehaviours(this Component component, bool includeInactiveComponents = true)
		=> component.gameObject.anyAutomaticBehaviours(includeInactiveComponents);

	// method: return whether this automatic behaviour's game object has any other automatic behaviours, optionally including inactive components according to the given boolean //
	public static bool anyOtherAutomaticBehaviours<AutomaticBehaviourT>(this AutomaticBehaviourT automaticBehaviour, bool includeInactiveComponents = true) where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
		=> automaticBehaviour.automaticBehaviours().containsOtherThan(automaticBehaviour);
	#endregion determining local components


	#region getting local components

	// method: return this given game object's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT first<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> includeInactiveComponents ? gameObject.GetComponent<ComponentT>() : gameObject.select<ComponentT>(false).FirstOrDefault();

	// method: return an enumerable of the specified class of components, optionally including inactive components according to the given boolean, on this given game object //
	public static IEnumerable<ComponentT> select<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.GetComponents<ComponentT>().where(
			component => component.gameObject.activeInHierarchy,
			!includeInactiveComponents);

	// method: return an enumerable of the specified interface of components, optionally including inactive components according to the given boolean, on this given game object //
	public static IEnumerable<ComponentI> selectI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentI : class
	{
		if (!typeof(ComponentI).IsInterface)
		{
			return default(IEnumerable<ComponentI>).returnWithError(typeof(ComponentI).Name+" is not an interface");
		}

		return gameObject.GetComponents<ComponentI>().where(
				component => (component.castTo<Component>().gameObject.activeInHierarchy),
				!includeInactiveComponents);
	}

	// method: return this given transform's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT first<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.first<ComponentT>(includeInactiveComponents);

	// method: return an enumerable of the specified class of components, optionally including inactive components according to the given boolean, on this given transform //
	public static IEnumerable<ComponentT> select<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.select<ComponentT>(includeInactiveComponents);

	// method: return this given component's game object's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT first<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.first<ComponentT>(includeInactiveComponents);

	// method: return an enumerable of the specified class of components on this given component's game object, optionally including inactive components according to the given boolean //
	public static IEnumerable<ComponentT> select<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.select<ComponentT>(includeInactiveComponents);

	// method: return an enumerable of all components on this given component's game object, optionally including inactive components according to the given boolean //
	public static IEnumerable<Component> components(this GameObject gameObject, bool includeInactiveComponents = true)
		=> gameObject.select<Component>(includeInactiveComponents);

	// method: return an enumerable of all components on this given component's game object, optionally including inactive components according to the given boolean //
	public static IEnumerable<Component> components(this Transform transform, bool includeInactiveComponents = true)
		=> transform.gameObject.components();

	// method: return an enumerable of all components on this given component's game object, optionally including inactive components according to the given boolean //
	public static IEnumerable<Component> components(this Component component, bool includeInactiveComponents = true)
		=> component.gameObject.components();

	// method: return an enumerable of all automatic behaviours on this given game object, optionally including inactive components according to the given boolean //
	public static IEnumerable<IAutomaticBehaviour> automaticBehaviours(this GameObject gameObject, bool includeInactiveComponents = true)
		=> gameObject.selectI<IAutomaticBehaviour>(includeInactiveComponents);
	
	// method: return an enumerable of all automatic behaviours on this given transform's game object, optionally including inactive components according to the given boolean //
	public static IEnumerable<IAutomaticBehaviour> automaticBehaviours(this Transform transform, bool includeInactiveComponents = true)
		=> transform.gameObject.automaticBehaviours();

	// method: return an enumerable of all automatic behaviours on this given component's game object, optionally including inactive components according to the given boolean //
	public static IEnumerable<IAutomaticBehaviour> automaticBehaviours(this Component component, bool includeInactiveComponents = true)
		=> component.gameObject.automaticBehaviours();
	#endregion getting local components


	#region iterating local components

	// method: invoke the given action on each of the specified class of components on this given game object, optionally including inactive components according to the given boolean, then return an enumerable of those components //
	public static IEnumerable<ComponentT> forEach<ComponentT>(this GameObject gameObject, Action<ComponentT> action, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.select<ComponentT>(includeInactiveComponents).forEach(action);

	// method: invoke the given action on each of the specified class of components on this given transform's game object, optionally including inactive components according to the given boolean, then return an enumerable of those components //
	public static IEnumerable<ComponentT> forEach<ComponentT>(this Transform transform, Action<ComponentT> action, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.forEach(action, includeInactiveComponents);

	// method: invoke the given action on each of the specified class of components on this given component's game object, optionally including inactive components according to the given boolean, then return an enumerable of those components //
	public static IEnumerable<ComponentT> forEach<ComponentT>(this Component component, Action<ComponentT> action, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.forEach(action, includeInactiveComponents);
	#endregion iterating local components


	#region getting child components

	// method: return this given game object's first child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT selectChild<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.selectChildren<ComponentT>(includeInactiveComponents).FirstOrDefault();

	// method: return this given transform's first child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT selectChild<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.selectChild<ComponentT>(includeInactiveComponents);

	// method: return this given component's first child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT selectChild<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.selectChild<ComponentT>(includeInactiveComponents);

	// method: return this given game object's last child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastChild<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.selectChildren<ComponentT>(includeInactiveComponents).LastOrDefault();

	// method: return this given transform's last child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastChild<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.lastChild<ComponentT>(includeInactiveComponents);

	// method: return this given component's last child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastChild<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.lastChild<ComponentT>(includeInactiveComponents);

	// method: return an enumerable of this given game object's child components of the specified class, optionally including inactive components according to the given boolean //
	public static IEnumerable<ComponentT> selectChildren<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.GetComponentsInChildren<ComponentT>(includeInactiveComponents).where(component => component.whereNotOn(gameObject));

	// method: return an enumerable of this given transform's child components of the specified class, optionally including inactive components according to the given boolean //
	public static IEnumerable<ComponentT> selectChildren<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.selectChildren<ComponentT>(includeInactiveComponents);

	// method: return an enumerable of this given component's child components of the specified class, optionally including inactive components according to the given boolean //
	public static IEnumerable<ComponentT> selectChildren<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.selectChildren<ComponentT>(includeInactiveComponents);
	#endregion getting child components


	#region getting child or self components

	// method: return this given game object's first local or child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrChild<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.GetComponentInChildren<ComponentT>(includeInactiveComponents);

	// method: return this given transform's first local or child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrChild<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.GetComponentInChildren<ComponentT>(includeInactiveComponents);

	// method: return this given component's first local or child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrChild<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.GetComponentInChildren<ComponentT>(includeInactiveComponents);

	// method: return an array of this given game object's local and child components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndChildren<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.GetComponentsInChildren<ComponentT>(includeInactiveComponents);

	// method: return an array of this given transform's local and child components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndChildren<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.GetComponentsInChildren<ComponentT>(includeInactiveComponents);

	// method: return an array of this given component's local and child components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndChildren<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.GetComponentsInChildren<ComponentT>(includeInactiveComponents);
	#endregion getting child or self components


	#region getting parent components

	// method: return this given game object's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstParent<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.parent().first<ComponentT>(includeInactiveComponents);

	// method: return this given transform's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstParent<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.firstParent<ComponentT>(includeInactiveComponents);

	// method: return this given component's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstParent<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.firstParent<ComponentT>(includeInactiveComponents);

	// method: return an enumerable of this given game object's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static IEnumerable<ComponentT> selectParent<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.parent().select<ComponentT>(includeInactiveComponents);

	// method: return an enumerable of this given transform's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static IEnumerable<ComponentT> selectParent<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.selectParent<ComponentT>(includeInactiveComponents);

	// method: return an enumerable of this given component's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static IEnumerable<ComponentT> selectParent<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.selectParent<ComponentT>(includeInactiveComponents);

	// method: return this given game object's first ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstAncestor<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.transform.firstAncestor<ComponentT>(includeInactiveComponents);

	// method: return this given transform's first ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstAncestor<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> includeInactiveComponents ? transform.selectAncestor<ComponentT>(true).FirstOrDefault() : transform.parent.GetComponentInParent<ComponentT>();

	// method: return this given component's first ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstAncestor<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.transform.firstAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this given game object's ancestor components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] selectAncestor<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.parent().GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given transform's ancestor components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] selectAncestor<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.parent.GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given component's ancestor components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] selectAncestor<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.parent().GetComponentsInParent<ComponentT>(includeInactiveComponents);
	#endregion getting parent components


	#region getting parent or self components

	// method: return this given game object's first local or ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrAncestor<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> includeInactiveComponents ? gameObject.GetComponentsInParent<ComponentT>(true).FirstOrDefault() : gameObject.GetComponentInParent<ComponentT>();

	// method: return this given transform's first local or ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrAncestor<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.gameObject.firstLocalOrAncestor<ComponentT>(includeInactiveComponents);

	// method: return this given component's first local or ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrAncestor<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.firstLocalOrAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this given game object's local and ancestor components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] selectLocalAndAncestor<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given transform's local and ancestor components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] selectLocalAndAncestor<ComponentT>(this Transform transform, bool includeInactiveComponents = true) where ComponentT : Component
		=> transform.GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given component's local and ancestor components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] selectLocalAndAncestor<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.GetComponentsInParent<ComponentT>(includeInactiveComponents);
	#endregion getting parent or self components


	#region searching for self or parent based on comparison

	// method: return the first game object out of this given game object and its ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static GameObject selfOrAncestorWith<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
	{
		if (gameObject.first<ComponentT>(includeInactiveComponents))
		{
			return gameObject;
		}

		Transform transformAtCurrentLevel = gameObject.transform;
		while (transformAtCurrentLevel.parent)
		{
			Transform parentTransform = transformAtCurrentLevel.parent;
			if (parentTransform.first<ComponentT>(includeInactiveComponents))
			{
				return parentTransform.gameObject;
			}

			transformAtCurrentLevel = parentTransform;
		}

		return null;
	}

	// method: return the first game object out of the game object for this component and that game object's ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static GameObject selfOrAncestorWith<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.selfOrAncestorWith<ComponentT>(includeInactiveComponents);

	// method: return the transform of the first game object out of this given game object and its ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static Transform selfOrAncestorTransformWith<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.selfOrAncestorWith<ComponentT>(includeInactiveComponents).transform;

	// method: return the transform of the first game object out of the game object for this component and that game object's ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static Transform selfOrAncestorTransformWith<ComponentT>(this Component component, bool includeInactiveComponents = true) where ComponentT : Component
		=> component.gameObject.selfOrAncestorTransformWith<ComponentT>(includeInactiveComponents);
	#endregion searching for self or parent based on comparison


	#region getting transformations

	// method: return the local position of the transform of this given component //
	public static Vector3 localPosition<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localPosition;

	// method: return the local x position of the transform of this given component //
	public static float localPositionX<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localPositionX();

	// method: return the local y position of the transform of this given component //
	public static float localPositionY<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localPositionY();

	// method: return the local z position of the transform of this given component //
	public static float localPositionZ<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localPositionZ();

	// method: return the local rotation of the transform of this given component //
	public static Quaternion localRotation<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localRotation;

	// method: return the local euler angles of the transform of this given component //
	public static Vector3 localEulerAngles<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localEulerAngles;

	// method: return the local x euler angle of the transform of this given component //
	public static float localEulerAngleX<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localEulerAngleX();

	// method: return the local y euler angle of the transform of this given component //
	public static float localEulerAngleY<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localEulerAngleY();

	// method: return the local z euler angle of the transform of this given component //
	public static float localEulerAngleZ<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localEulerAngleZ();

	// method: return the local scale of the transform of this given component //
	public static Vector3 localScale<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localScale;

	// method: return the local x scale of the transform of this given component //
	public static float localScaleX<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localScaleX();

	// method: return the local y scale of the transform of this given component //
	public static float localScaleY<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localScaleY();

	// method: return the local z scale of the transform of this given component //
	public static float localScaleZ<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.localScaleZ();

	// method: return the (global) position of the transform of this given component //
	public static Vector3 position<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.position;

	// method: return the (global) x position of the transform of this given component //
	public static float positionX<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.positionX();

	// method: return the (global) y position of the transform of this given component //
	public static float positionY<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.positionY();

	// method: return the (global) z position of the transform of this given component //
	public static float positionZ<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.positionZ();

	// method: return the (global) rotation of the transform of this given component //
	public static Quaternion rotation<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.rotation;

	// method: return the (global) euler angles of the transform of this given component //
	public static Vector3 eulerAngles<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.eulerAngles;

	// method: return the (global) x euler angle of the transform of this given component //
	public static float eulerAngleX<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.eulerAngleX();

	// method: return the (global) y euler angle of the transform of this given component //
	public static float eulerAngleY<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.eulerAngleY();

	// method: return the (global) z euler angle of the transform of this given component //
	public static float eulerAngleZ<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.eulerAngleZ();
	#endregion getting transformations


	#region setting transformations

	// method: (according to the given boolean:) set the local position of the transform of this given component to the given local position, then return this given component //
	public static ComponentT setLocalPosition<ComponentT>(this ComponentT component, Vector3 localPosition, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalPosition(localPosition, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local position of the transform of this given component to the local position for the given x, y, and z values, then return this given component //
	public static ComponentT setLocalPosition<ComponentT>(this ComponentT component, float x, float y, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalPosition(x, y, z, boolean);

		return component;
	}

	public static ComponentT setLocalPosition<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalPosition(transform.localPosition, boolean);

	public static ComponentT setLocalPosition<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalPosition(gameObject.localPosition(), boolean);

	public static ComponentT setLocalPosition<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalPosition(otherComponent.localPosition(), boolean);


	// method: (according to the given boolean:) set the local x position of the transform of this given component to the given x value, then return this given component //
	public static ComponentT setLocalPositionX<ComponentT>(this ComponentT component, float x, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalPositionX(x, boolean);

		return component;
	}

	public static ComponentT setLocalPositionX<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionX(transform.localPositionX(), boolean);

	public static ComponentT setLocalPositionX<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionX(gameObject.localPositionX(), boolean);

	public static ComponentT setLocalPositionX<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionX(otherComponent.localPositionX(), boolean);

	// method: (according to the given boolean:) set the local y position of the transform of this given component to the given y value, then return this given component //
	public static ComponentT setLocalPositionY<ComponentT>(this ComponentT component, float y, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalPositionY(y, boolean);

		return component;
	}

	public static ComponentT setLocalPositionY<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionY(transform.localPositionY(), boolean);

	public static ComponentT setLocalPositionY<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionY(gameObject.localPositionY(), boolean);

	public static ComponentT setLocalPositionY<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionY(otherComponent.localPositionY(), boolean);

	// method: (according to the given boolean:) set the local z position of the transform of this given component to the given z value, then return this given component //
	public static ComponentT setLocalPositionZ<ComponentT>(this ComponentT component, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalPositionZ(z, boolean);

		return component;
	}

	public static ComponentT setLocalPositionZ<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionZ(transform.localPositionZ(), boolean);

	public static ComponentT setLocalPositionZ<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionZ(gameObject.localPositionZ(), boolean);

	public static ComponentT setLocalPositionZ<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalPositionZ(otherComponent.localPositionZ(), boolean);

	// method: (according to the given boolean:) set the local rotation of the transform of this given component to the given local rotation, then return this given component //
	public static ComponentT setLocalRotation<ComponentT>(this ComponentT component, Quaternion localRotation, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalRotation(localRotation, boolean);

		return component;
	}

	public static ComponentT setLocalRotation<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalRotation(transform.localRotation, boolean);

	public static ComponentT setLocalRotation<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalRotation(gameObject.localRotation(), boolean);

	public static ComponentT setLocalRotation<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalRotation(otherComponent.localRotation(), boolean);

	// method: (according to the given boolean:) set the local euler angles of the transform of this given component to the given local euler angles, then return this given component //
	public static ComponentT setLocalEulerAngles<ComponentT>(this ComponentT component, Vector3 localEulerAngles, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalEulerAngles(localEulerAngles, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local euler angles of the transform of this given component to the local euler angles for the given x, y, and z values, then return this given component //
	public static ComponentT setLocalEulerAngles<ComponentT>(this ComponentT component, float x, float y, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalEulerAngles(x, y, z, boolean);

		return component;
	}

	public static ComponentT setLocalEulerAngles<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngles(transform.localEulerAngles, boolean);

	public static ComponentT setLocalEulerAngles<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngles(gameObject.localEulerAngles(), boolean);

	public static ComponentT setLocalEulerAngles<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngles(otherComponent.localEulerAngles(), boolean);

	// method: (according to the given boolean:) set the local x euler angle of the transform of this given component to the given x value, then return this given component //
	public static ComponentT setLocalEulerAngleX<ComponentT>(this ComponentT component, float x, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalEulerAngleX(x, boolean);

		return component;
	}

	public static ComponentT setLocalEulerAngleX<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleX(transform.localEulerAngleX(), boolean);

	public static ComponentT setLocalEulerAngleX<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleX(gameObject.localEulerAngleX(), boolean);

	public static ComponentT setLocalEulerAngleX<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleX(otherComponent.localEulerAngleX(), boolean);

	// method: (according to the given boolean:) set the local y euler angle of the transform of this given component to the given y value, then return this given component //
	public static ComponentT setLocalEulerAngleY<ComponentT>(this ComponentT component, float y, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalEulerAngleY(y, boolean);

		return component;
	}

	public static ComponentT setLocalEulerAngleY<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleY(transform.localEulerAngleY(), boolean);

	public static ComponentT setLocalEulerAngleY<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleY(gameObject.localEulerAngleY(), boolean);

	public static ComponentT setLocalEulerAngleY<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleY(otherComponent.localEulerAngleY(), boolean);

	// method: (according to the given boolean:) set the local z euler angle of the transform of this given component to the given z value, then return this given component //
	public static ComponentT setLocalEulerAngleZ<ComponentT>(this ComponentT component, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalEulerAngleZ(z, boolean);

		return component;
	}

	public static ComponentT setLocalEulerAngleZ<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleZ(transform.localEulerAngleZ(), boolean);

	public static ComponentT setLocalEulerAngleZ<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleZ(gameObject.localEulerAngleZ(), boolean);

	public static ComponentT setLocalEulerAngleZ<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalEulerAngleZ(otherComponent.localEulerAngleZ(), boolean);

	// method: (according to the given boolean:) set the local scale of the transform of this given component to the given local scale, then return this given component //
	public static ComponentT setLocalScale<ComponentT>(this ComponentT component, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalScale(localScale, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the local scale of the transform of this given component to the local scale for the given x, y, and z values, then return this given component //
	public static ComponentT setLocalScale<ComponentT>(this ComponentT component, float x, float y, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalScale(x, y, z, boolean);

		return component;
	}

	public static ComponentT setLocalScale<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalScale(transform.localScale, boolean);

	public static ComponentT setLocalScale<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalScale(gameObject.localScale(), boolean);

	public static ComponentT setLocalScale<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalScale(otherComponent.localScale(), boolean);

	// method: (according to the given boolean:) set the local x scale of the transform of this given component to the given x value, then return this given component //
	public static ComponentT setLocalScaleX<ComponentT>(this ComponentT component, float x, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalScaleX(x, boolean);

		return component;
	}

	public static ComponentT setLocalScaleX<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleX(transform.localScaleX(), boolean);

	public static ComponentT setLocalScaleX<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleX(gameObject.localScaleX(), boolean);

	public static ComponentT setLocalScaleX<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleX(otherComponent.localScaleX(), boolean);

	// method: (according to the given boolean:) set the local y scale of the transform of this given component to the given y value, then return this given component //
	public static ComponentT setLocalScaleY<ComponentT>(this ComponentT component, float y, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalScaleY(y, boolean);

		return component;
	}

	public static ComponentT setLocalScaleY<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleY(transform.localScaleY(), boolean);

	public static ComponentT setLocalScaleY<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleY(gameObject.localScaleY(), boolean);

	public static ComponentT setLocalScaleY<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleY(otherComponent.localScaleY(), boolean);

	// method: (according to the given boolean:) set the local z scale of the transform of this given component to the given z value, then return this given component //
	public static ComponentT setLocalScaleZ<ComponentT>(this ComponentT component, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalScaleZ(z, boolean);

		return component;
	}

	public static ComponentT setLocalScaleZ<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleZ(transform.localScaleZ(), boolean);

	public static ComponentT setLocalScaleZ<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleZ(gameObject.localScaleZ(), boolean);

	public static ComponentT setLocalScaleZ<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocalScaleZ(otherComponent.localScaleZ(), boolean);

	// method: (according to the given boolean:) set the local transformations (local position, local rotation, local scale) for the transform of this given component respectively to the given local position, local rotation, and local scale, then return this given component //
	public static ComponentT setLocals<ComponentT>(this ComponentT component, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocals(localPosition, localRotation, localScale, boolean);

		return component;
	}

	public static ComponentT setLocals<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setLocals(transform.localPosition, transform.localRotation, transform.localScale, boolean);

	public static ComponentT setLocals<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setLocals(gameObject.localPosition(), gameObject.localRotation(), gameObject.localScale(), boolean);

	public static ComponentT setLocals<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setLocals(otherComponent.localPosition(), otherComponent.localRotation(), otherComponent.localScale(), boolean);

	// method: (according to the given boolean:) set the local transformations (local position, local euler angles, local scale) for the transform of this given component respectively to the given local position, local euler angles, and local scale, then return this given component //
	public static ComponentT setLocals<ComponentT>(this ComponentT component, Vector3 localPosition, Vector3 localEulerAngles, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocals(localPosition, localEulerAngles, localScale, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (nonscale) local transformations (local position, local rotation) for the transform of this given component respectively to the given local position and local rotation //
	public static ComponentT setLocals<ComponentT>(this ComponentT component, Vector3 localPosition, Quaternion localRotation, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocals(localPosition, localRotation, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (nonposition) local transformations (local rotation, local scale) for the transform of this given component respectively to the given local rotation and local scale //
	public static ComponentT setLocals<ComponentT>(this ComponentT component, Quaternion localRotation, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocals(localRotation, localScale, boolean);

		return component;
	}

	// method: (according to the given boolean:) set this given component's transform's local transformations to its parent's while temporarily childed to the given transform, then return this given component //
	public static ComponentT setLocalsParentlyForRelativeTo<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalsParentlyForRelativeTo(transform, boolean);

		return component;
	}

	// method: (according to the given boolean:) set this given component's transform's local transformations to its parent's while temporarily childed to the given game object, then return this given component //
	public static ComponentT setLocalsParentlyForRelativeTo<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalsParentlyForRelativeTo(gameObject, boolean);

		return component;
	}

	// method: (according to the given boolean:) set this given component's transform's local transformations to its parent's while temporarily childed to the other given component, then return this given component //
	public static ComponentT setLocalsParentlyForRelativeTo<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
	{
		component.transform.setLocalsParentlyForRelativeTo(otherComponent, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) position for the transform of this given component to the given (global) position, then return this given component //
	public static ComponentT setPosition<ComponentT>(this ComponentT component, Vector3 position, bool boolean = true) where ComponentT : Component
	{
		component.transform.setPosition(position, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) position for the transform of this given component to the (global) position for the given x, y, and z values, then return this given component //
	public static ComponentT setPosition<ComponentT>(this ComponentT component, float x, float y, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setPosition(x, y, z, boolean);

		return component;
	}

	public static ComponentT setPosition<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setPosition(transform.position, boolean);

	public static ComponentT setPosition<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setPosition(gameObject.position(), boolean);

	public static ComponentT setPosition<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setPosition(otherComponent.position(), boolean);

	// method: (according to the given boolean:) set the (global) x position for the transform of this given component to the given x value, then return this given component //
	public static ComponentT setPositionX<ComponentT>(this ComponentT component, float x, bool boolean = true) where ComponentT : Component
	{
		component.transform.setPositionX(x, boolean);

		return component;
	}

	public static ComponentT setPositionX<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setPositionX(transform.positionX(), boolean);

	public static ComponentT setPositionX<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setPositionX(gameObject.positionX(), boolean);

	public static ComponentT setPositionX<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setPositionX(otherComponent.positionX(), boolean);

	// method: (according to the given boolean:) set the (global) y position for the transform of this given component to the given y value, then return this given component //
	public static ComponentT setPositionY<ComponentT>(this ComponentT component, float y, bool boolean = true) where ComponentT : Component
	{
		component.transform.setPositionY(y, boolean);

		return component;
	}

	public static ComponentT setPositionY<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setPositionY(transform.positionY(), boolean);

	public static ComponentT setPositionY<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setPositionY(gameObject.positionY(), boolean);

	public static ComponentT setPositionY<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setPositionY(otherComponent.positionY(), boolean);

	// method: (according to the given boolean:) set the (global) z position for the transform of this given component to the given z value, then return this given component //
	public static ComponentT setPositionZ<ComponentT>(this ComponentT component, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setPositionZ(z, boolean);

		return component;
	}

	public static ComponentT setPositionZ<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setPositionY(transform.positionZ(), boolean);

	public static ComponentT setPositionZ<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setPositionY(gameObject.positionZ(), boolean);

	public static ComponentT setPositionZ<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setPositionY(otherComponent.positionZ(), boolean);

	// method: (according to the given boolean:) set the (global) rotation for the transform of this given component to the given (global) rotation, then return this given component //
	public static ComponentT setRotation<ComponentT>(this ComponentT component, Quaternion rotation, bool boolean = true) where ComponentT : Component
	{
		component.transform.setRotation(rotation, boolean);

		return component;
	}

	public static ComponentT setRotation<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setRotation(transform.rotation, boolean);

	public static ComponentT setRotation<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setRotation(gameObject.rotation(), boolean);

	public static ComponentT setRotation<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setRotation(otherComponent.rotation(), boolean);

	// method: (according to the given boolean:) set the (global) euler angles of the transform of this given component to the given (global) euler angles, then return this given component //
	public static ComponentT setEulerAngles<ComponentT>(this ComponentT component, Vector3 eulerAngles, bool boolean = true) where ComponentT : Component
	{
		component.transform.setEulerAngles(eulerAngles, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the (global) euler angles of the transform of this given component to the (global) euler angles for the given x, y, and z values, then return this given component //
	public static ComponentT setEulerAngles<ComponentT>(this ComponentT component, float x, float y, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setEulerAngles(x, y, z, boolean);

		return component;
	}

	public static ComponentT setEulerAngles<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngles(transform.eulerAngles, boolean);

	public static ComponentT setEulerAngles<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngles(gameObject.eulerAngles(), boolean);

	public static ComponentT setEulerAngles<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngles(otherComponent.eulerAngles(), boolean);

	// method: (according to the given boolean:) set the (global) x euler angle of the transform of this given component to the given x value, then return this given component //
	public static ComponentT setEulerAngleX<ComponentT>(this ComponentT component, float x, bool boolean = true) where ComponentT : Component
	{
		component.transform.setEulerAngleX(x, boolean);

		return component;
	}

	public static ComponentT setEulerAngleX<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleX(transform.eulerAngleX(), boolean);

	public static ComponentT setEulerAngleX<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleX(gameObject.eulerAngleX(), boolean);

	public static ComponentT setEulerAngleX<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleX(otherComponent.eulerAngleX(), boolean);

	// method: (according to the given boolean:) set the (global) y euler angle of the transform of this given component to the given y value, then return this given component //
	public static ComponentT setEulerAngleY<ComponentT>(this ComponentT component, float y, bool boolean = true) where ComponentT : Component
	{
		component.transform.setEulerAngleY(y, boolean);

		return component;
	}

	public static ComponentT setEulerAngleY<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleY(transform.eulerAngleY(), boolean);

	public static ComponentT setEulerAngleY<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleY(gameObject.eulerAngleY(), boolean);

	public static ComponentT setEulerAngleY<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleY(otherComponent.eulerAngleY(), boolean);

	// method: (according to the given boolean:) set the (global) z euler angle of the transform of this given component to the given z value, then return this given component //
	public static ComponentT setEulerAngleZ<ComponentT>(this ComponentT component, float z, bool boolean = true) where ComponentT : Component
	{
		component.transform.setEulerAngleZ(z, boolean);

		return component;
	}

	public static ComponentT setEulerAngleZ<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleZ(transform.eulerAngleZ(), boolean);

	public static ComponentT setEulerAngleZ<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleZ(gameObject.eulerAngleZ(), boolean);

	public static ComponentT setEulerAngleZ<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setEulerAngleZ(otherComponent.eulerAngleZ(), boolean);

	// method: (according to the given boolean:) set the global transformations (global position, global rotation) for the transform of this given component respectively to the given (global) position and (global) rotation //
	public static ComponentT setGlobals<ComponentT>(this ComponentT component, Vector3 position, Quaternion rotation, bool boolean = true) where ComponentT : Component
	{
		component.transform.setGlobals(position, rotation, boolean);

		return component;
	}

	public static ComponentT setGlobals<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setGlobals(transform.position, transform.rotation, boolean);

	public static ComponentT setGlobals<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setGlobals(gameObject.position(), gameObject.rotation(), boolean);

	public static ComponentT setGlobals<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setGlobals(otherComponent.position(), otherComponent.rotation(), boolean);

	// method: (according to the given boolean:) set the global transformations (global position, global euler angles) for the transform of this given component respectively to the given (global) position and (global) euler angles //
	public static ComponentT setGlobals<ComponentT>(this ComponentT component, Vector3 position, Vector3 eulerAngles, bool boolean = true) where ComponentT : Component
	{
		component.transform.setGlobals(position, eulerAngles, boolean);

		return component;
	}

	// method: (according to the given boolean:) set the global transformations (global position, global rotation) and local scale for the transform of this given component respectively to the given (global) position and (global) rotation and local scale //
	public static ComponentT setGlobalsAndLocalScale<ComponentT>(this ComponentT component, Vector3 position, Quaternion rotation, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setGlobalsAndLocalScale(position, rotation, localScale, boolean);

		return component;
	}

	public static ComponentT setGlobalsAndLocalScale<ComponentT>(this ComponentT component, Transform transform, bool boolean = true) where ComponentT : Component
		=> component.setGlobalsAndLocalScale(transform.position, transform.rotation, transform.localScale, boolean);

	public static ComponentT setGlobalsAndLocalScale<ComponentT>(this ComponentT component, GameObject gameObject, bool boolean = true) where ComponentT : Component
		=> component.setGlobalsAndLocalScale(gameObject.position(), gameObject.rotation(), gameObject.localScale(), boolean);

	public static ComponentT setGlobalsAndLocalScale<ComponentT>(this ComponentT component, Component otherComponent, bool boolean = true) where ComponentT : Component
		=> component.setGlobalsAndLocalScale(otherComponent.position(), otherComponent.rotation(), otherComponent.localScale(), boolean);

	// method: (according to the given boolean:) set the global transformations (global position, global euler angles) and local scale for the transform of this given component respectively to the given (global) position and (global) euler angles and local scale //
	public static ComponentT setGlobalsAndLocalScale<ComponentT>(this ComponentT component, Vector3 position, Vector3 eulerAngles, Vector3 localScale, bool boolean = true) where ComponentT : Component
	{
		component.transform.setGlobalsAndLocalScale(position, eulerAngles, localScale, boolean);

		return component;
	}
	#endregion setting transformations


	#region resetting transformations

	// method: (according to the given boolean:) reset the local position for the transform of this given component to zeroes, then return this given component //
	public static ComponentT resetLocalPosition<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalPosition(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local x position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalPositionX<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalPositionX(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the localy position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalPositionY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalPositionY(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local z position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalPositionZ<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalPositionZ(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local rotation for the transform of this given component to no rotation, then return this given component //
	public static ComponentT resetLocalRotation<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalRotation(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local euler angles for the transform of this given component to zeroes, then return this given component //
	public static ComponentT resetLocalEulerAngles<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalEulerAngles(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local x euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalEulerAngleX<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalEulerAngleX(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local y euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalEulerAngleY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalEulerAngleY(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local z euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetLocalEulerAngleZ<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalEulerAngleZ(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local scale for the transform of this given component to ones, then return this given component //
	public static ComponentT resetLocalScale<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalScale(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local x scale for the transform of this given component to one, then return this given component //
	public static ComponentT resetLocalScaleX<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalScaleX(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local y scale for the transform of this given component to one, then return this given component //
	public static ComponentT resetLocalScaleY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalScaleY(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local z scale for the transform of this given component to one, then return this given component //
	public static ComponentT resetLocalScaleZ<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocalScaleZ(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the local transformations (local position, local rotation, local scale) for the transform of this given component respectively to the zeroes, no rotation, and ones, then return this given component //
	public static ComponentT resetLocals<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetLocals(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) position for the transform of this given component to zeroes, then return this given component //
	public static ComponentT resetPosition<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetPosition(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) x position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetPositionX<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetPositionX(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) y position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetPositionY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetPositionY(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) z position for the transform of this given component to zero, then return this given component //
	public static ComponentT resetPositionZ<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetPositionZ(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) rotation for the transform of this given component to no rotation, then return this given component //
	public static ComponentT resetRotation<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetRotation(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) euler angles for the transform of this given component to zeroes, then return this given component //
	public static ComponentT resetEulerAngles<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetEulerAngles(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) x euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetEulerAngleX<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetEulerAngleX(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) y euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetEulerAngleY<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetEulerAngleY(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the (global) z euler angle for the transform of this given component to zero, then return this given component //
	public static ComponentT resetEulerAngleZ<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetEulerAngleZ(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the global transformations (global position, global rotation) for the transform of this given component respectively to zeroes and no rotation //
	public static ComponentT resetGlobals<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetGlobals(boolean);

		return component;
	}

	// method: (according to the given boolean:) reset the global transformations (global position, global rotation) and local scale for the transform of this given component respectively to zeroes, no rotation, and ones //
	public static ComponentT resetGlobalsAndLocalScale<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
	{
		component.transform.resetGlobalsAndLocalScale(boolean);

		return component;
	}
	#endregion resetting transformations
}