using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Component Extensions: provides extension methods for handling components //
// #auto #component
public static class ComponentExtensions
{
	#region destruction

	// method: destroy this given component's game object according to the given booleanic function upon this given component, then return the result of that function //
	public static bool destroyObject<ComponentT>(this ComponentT component, Func<ComponentT, bool> function) where ComponentT : Component
		=> function(component).after(result =>
		{
			if (result)
			{
				component.gameObject.destroy();
			}
		});

	// method: (according to the given boolean:) destroy this given component's game object //
	public static void destroyObject(this Component component, bool boolean = true)
		=> boolean.after(()=>
			component.destroyObject(component_ => boolean));

	// method: destroy all components in this given enumerable of components for which the given function returns true, then return this given enumerable //
	public static IEnumerable<ComponentT> destroyWhere<ComponentT>(this IEnumerable<ComponentT> enumerable, Func<ComponentT, bool> function) where ComponentT : Component
		=> enumerable.forEach(component => component.destroy(function));

	// method: destroy all objects of components in this given set of components for which the given function returns true, then return this given set //
	public static HashSet<ComponentT> destroyObjectsWhere<ComponentT>(this HashSet<ComponentT> set, Func<ComponentT, bool> function) where ComponentT : Component
		=> set.forEach(component => component.destroyObject(function));
	
	// method: destroy this given game object's first component of the specified class (if any), optionally including inactive components according to the given boolean, then return this given game object //
	public static GameObject destroyFirstIfAny<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
	{
		ComponentT first = gameObject.first<ComponentT>(includeInactiveComponents);

		if (first)
		{
			first.destroy();
		}

		return gameObject;
	}
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


	#region calling local methods

	// method: (according to the given boolean:) call all of this component's game object's mono behaviours' defined methods (ignoring inherited methods that haven't been overriden) with the given name, then return this given game object //
	public static ComponentT callAllLocal<ComponentT>(this ComponentT component, string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.callAllLocal(methodName, sendMessageOptions, boolean));

	// method: (if in the editor:) have all mono behaviours on this component's game object validate (if they have OnValidate defined), then return this given component //
	public static ComponentT validate_IfInEditor<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.validate_IfInEditor());
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
	public static ComponentT addGet<ComponentT>(this GameObject gameObject) where ComponentT : Component
		=> gameObject.AddComponent<ComponentT>();
	// method: add a new component of the specified class to this given component's game object, then return the new component //
	public static NewComponentT addGet<NewComponentT>(this Component component) where NewComponentT : Component
		=> component.gameObject.addGet<NewComponentT>();

	// method: add a new component of the specified class to this given game object, execute the given action upon the new component, then return this given game object //
	public static GameObject addActUpon<ComponentT>(this GameObject gameObject, Action<ComponentT> action) where ComponentT : Component
		=> gameObject.after(()=>
			action(gameObject.addGet<ComponentT>()));
	// method: add a new component of the specified class to this given component, execute the given action upon the new component, then return this given component's game object //
	public static GameObject addActUpon<NewComponentT>(this Component component, Action<NewComponentT> action) where NewComponentT : Component
		=> component.gameObject.addActUpon(action);

	// method: add a new component of the specified class to this given game object, then return this given game object //
	public static GameObject add<ComponentT>(this GameObject gameObject) where ComponentT : Component
		=>	gameObject.after(()=>
				gameObject.addGet<ComponentT>());
	// method: add a new component of the specified class to this given component's game object, then return this given component's game object //
	public static GameObject add<NewComponentT>(this Component component) where NewComponentT : Component
		=> component.gameObject.add<NewComponentT>();

	// method: if this given game object has none of the specified component, optionally including inactive components according to the given boolean, add a new component of the specified class to this given game object, then return the first such component on this given game object //
	public static ComponentT ensured<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.first<ComponentT>(includeInactiveComponents).ifYullOtherwise(()=>
			gameObject.addGet<ComponentT>());
	// method: if this given component's game object has none of the specified component, optionally including inactive components according to the given boolean, add a new component of the specified class to this given component's game object, then return the first such component on this given component's game object //
	public static ComponentT ensured<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.ensured<ComponentT>(includeInactiveComponents);

	// method: if this given game object has none of the specified component to ensure, optionally including inactive components according to the given boolean, add a new component of the specified component class to add (derived from the specified component class to ensure) to this given game object, then return the first such specified component to ensure on this given game object //
	public static ComponentTToEnsure ensured<ComponentTToEnsure, ComponentTToAdd>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentTToEnsure : Component where ComponentTToAdd : ComponentTToEnsure
		=> gameObject.first<ComponentTToEnsure>(includeInactiveComponents).ifYullOtherwise(()=>
			gameObject.addGet<ComponentTToAdd>());
	// method: if this given component's game object has none of the specified component to ensure, optionally including inactive components according to the given boolean, add a new component of the specified component class to add (derived from the specified component class to ensure) to this given component's game object, then return the first such specified component to ensure on this given component's game object //
	public static ComponentTToEnsure ensured<ComponentTToEnsure, ComponentTToAdd>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentTToEnsure : Component where ComponentTToAdd : ComponentTToEnsure
		=> component.gameObject.ensured<ComponentTToEnsure, ComponentTToAdd>(includeInactiveComponents);

	// method: if this given game object has none of the specified component, optionally including inactive components according to the given boolean, add a new component of the specified class to this given game object, then return this given game object //
	public static GameObject ensure<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.after(()=>
			gameObject.ensured<ComponentT>(includeInactiveComponents));
	// method: if this given component's game object has none of the specified component, optionally including inactive components according to the given boolean, add a new component of the specified class to this given component's game object, then return this given component's game object //
	public static GameObject ensure<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.ensure<ComponentT>(includeInactiveComponents);

	// method: if this given game object has none of the specified component, optionally including inactive components according to the given boolean, add a new component of the specified class to this given game object, execute the given action on the first such component on this given game object, then return this given game object //
	public static GameObject ensureActUpon<ComponentT>(this GameObject gameObject, Action<ComponentT> action, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.after(()=>
			action(gameObject.ensured<ComponentT>()));
	// method: if this given component's game object has none of the specified component, optionally including inactive components according to the given boolean, add a new component of the specified class to this given component's game object, execute the given action on the first such component on this given component's game object, then return this given component's game object //
	public static GameObject ensureActUpon<ComponentT>(this Component component, Action<ComponentT> action, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.ensureActUpon<ComponentT>(action, includeInactiveComponents);
	#endregion adding components


	#region accessing components in a given array

	// method: return a selection of the specified class of components in these given game objects, optionally including inactive components according to the given boolean //
	public static IEnumerable<ComponentT> selectEachFirst<ComponentT>(this GameObject[] gameObjects, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObjects.selectFromYull(gameObject => gameObject.first<ComponentT>(includeInactiveComponents));

	// method: return a selection of the specified class of components in these given transforms, optionally including inactive components according to the given boolean //
	public static IEnumerable<ComponentT> selectEachFirst<ComponentT>(this Transform[] transforms, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transforms.selectFromYull(transform => transform.first<ComponentT>(includeInactiveComponents));
	#endregion accessing components in a given array


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

	// method: return whether this given game object has any of the specified type of component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool hasAny<ComponentT>(this GameObject gameObject, Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.pick<ComponentT>(includeInactiveComponents).hasAny(function);
	// method: return whether this given transform's game object has any of the specified type of component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool hasAny<ComponentT>(this Transform transform, Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.hasAny(function, includeInactiveComponents);
	// method: return whether this given component's game object has any of the specified type of component for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool hasAny<ComponentT>(this Component component, Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.hasAny(function, includeInactiveComponents);

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
		=> includeInactiveComponents ? gameObject.GetComponent<ComponentT>() : gameObject.pick<ComponentT>(false).FirstOrDefault();
	// method: return this given transform's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT first<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.first<ComponentT>(includeInactiveComponents);
	// method: return this given component's game object's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT first<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.first<ComponentT>(includeInactiveComponents);

	// method: return a list of the specified class of components, optionally including inactive components according to the given boolean, on this given game object //
	public static List<ComponentT> pick<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=>	gameObject.GetComponents<ComponentT>().where(component =>
				component.activeGlobally(),
				!includeInactiveComponents);
	// method: return a list of the specified class of components, optionally including inactive components according to the given boolean, on this given transform //
	public static List<ComponentT> pick<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.pick<ComponentT>(includeInactiveComponents);
	// method: return a list of the specified class of components on this given component's game object, optionally including inactive components according to the given boolean //
	public static List<ComponentT> pick<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.pick<ComponentT>(includeInactiveComponents);

	// method: return a list of the specified interface of components, optionally including inactive components according to the given boolean, on this given game object //
	public static List<ComponentI> pickI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (!typeof(ComponentI).IsInterface)
		{
			return default(List<ComponentI>).returnWithError(typeof(ComponentI).simpleClassName()+" is not an interface");
		}

		return	gameObject.GetComponents<ComponentI>().where(component =>
					component.castTo<Component>().activeGlobally(),
					!includeInactiveComponents);
	}

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
	#endregion iterating local components


	#region determining child components

	// method: return whether this given game object has any of the specified type of child component, optionally including inactive components according to the given boolean //
	public static bool hasAnyChildren<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(gameObject.children<ComponentT>(includeInactiveComponents));

	// method: return whether this given transform has any of the specified type of child component, optionally including inactive components according to the given boolean //
	public static bool hasAnyChildren<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(transform.children<ComponentT>(includeInactiveComponents));

	// method: return whether this given component has any of the specified type of child component, optionally including inactive components according to the given boolean //
	public static bool hasAnyChildren<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(component.children<ComponentT>(includeInactiveComponents));
	#endregion determining child components


	#region accessing child components

	// method: return this given game object's first child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstChild<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.children<ComponentT>(includeInactiveComponents).FirstOrDefault();

	// method: return this given transform's first child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstChild<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.firstChild<ComponentT>(includeInactiveComponents);

	// method: return this given component's first child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstChild<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.firstChild<ComponentT>(includeInactiveComponents);

	// method: return this given game object's last child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastChild<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.children<ComponentT>(includeInactiveComponents).LastOrDefault();

	// method: return this given transform's last child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastChild<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.lastChild<ComponentT>(includeInactiveComponents);

	// method: return this given component's last child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastChild<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.lastChild<ComponentT>(includeInactiveComponents);

	// method: return a list of this given game object's child components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> children<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.GetComponentsInChildren<ComponentT>(includeInactiveComponents).where(component => component.whereNotOn(gameObject));

	// method: return a list of this given transform's child components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> children<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.children<ComponentT>(includeInactiveComponents);

	// method: return a list of this given component's child components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> children<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.children<ComponentT>(includeInactiveComponents);
	#endregion accessing child components


	#region accessing child or self components

	// method: return this given game object's first local or child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrChild<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.GetComponentInChildren<ComponentT>(includeInactiveComponents);
	// method: return this given transform's first local or child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrChild<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.GetComponentInChildren<ComponentT>(includeInactiveComponents);
	// method: return this given component's first local or child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrChild<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.GetComponentInChildren<ComponentT>(includeInactiveComponents);

	// method: return an array of this given game object's local and child components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndChildren<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.GetComponentsInChildren<ComponentT>(includeInactiveComponents);
	// method: return an array of this given transform's local and child components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndChildren<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.GetComponentsInChildren<ComponentT>(includeInactiveComponents);
	// method: return an array of this given component's local and child components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndChildren<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.GetComponentsInChildren<ComponentT>(includeInactiveComponents);
	
	// method: return an array of the specified interface of components, optionally including inactive components according to the given boolean, which are local or child to this given game object //
	public static ComponentI[] localAndChildrenI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (!typeof(ComponentI).IsInterface)
		{
			return default(ComponentI[]).returnWithError(typeof(ComponentI).simpleClassName()+" is not an interface");
		}

		return gameObject.GetComponentsInChildren<ComponentI>(includeInactiveComponents);
	}

	// method: return the set of game objects with the specified interface of components, optionally including inactive components according to the given boolean, which are local or child to this given game object //
	public static HashSet<GameObject> localAndChildrenObjectsWithI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (!typeof(ComponentI).IsInterface)
		{
			return default(HashSet<GameObject>).returnWithError(typeof(ComponentI).simpleClassName()+" is not an interface");
		}

		return gameObject.localAndChildren<Component>(includeInactiveComponents).where(monoBehaviour =>
			monoBehaviour is ComponentI).uniqueObjects();
	}
	#endregion accessing child or self components


	#region accessing parent components

	// method: return this given game object's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstParent<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.parent().first<ComponentT>(includeInactiveComponents);

	// method: return this given transform's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstParent<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.firstParent<ComponentT>(includeInactiveComponents);

	// method: return this given component's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstParent<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.firstParent<ComponentT>(includeInactiveComponents);

	// method: return a list of this given game object's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> parental<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.parent().pick<ComponentT>(includeInactiveComponents);

	// method: return a list of this given transform's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> parental<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.parental<ComponentT>(includeInactiveComponents);

	// method: return a list of this given component's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> parental<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.parental<ComponentT>(includeInactiveComponents);

	// method: return this given game object's first ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstAncestor<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.transform.firstAncestor<ComponentT>(includeInactiveComponents);

	// method: return this given transform's first ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstAncestor<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> includeInactiveComponents ? transform.ancestral<ComponentT>(true).FirstOrDefault() : transform.parent.GetComponentInParent<ComponentT>();

	// method: return this given component's first ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstAncestor<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.transform.firstAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this given game object's ancestral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] ancestral<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.parent().GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given transform's ancestral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] ancestral<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.parent.GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given component's ancestral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] ancestral<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.parent().GetComponentsInParent<ComponentT>(includeInactiveComponents);
	#endregion accessing parent components


	#region accessing parent or self components

	// method: return this given game object's first local or ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrAncestor<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> includeInactiveComponents ? gameObject.GetComponentsInParent<ComponentT>(true).FirstOrDefault() : gameObject.GetComponentInParent<ComponentT>();

	// method: return this given transform's first local or ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrAncestor<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.firstLocalOrAncestor<ComponentT>(includeInactiveComponents);

	// method: return this given component's first local or ancestor component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrAncestor<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.firstLocalOrAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this given game object's local and ancestral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndAncestral<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given transform's local and ancestral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndAncestral<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given component's local and ancestral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndAncestral<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.GetComponentsInParent<ComponentT>(includeInactiveComponents);
	#endregion accessing parent or self components


	#region searching for self or parent based on comparison

	// method: return the first game object out of this given game object and its ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static GameObject selfOrAncestorObjectWith<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
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
	public static GameObject selfOrAncestorObjectWith<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.selfOrAncestorObjectWith<ComponentT>(includeInactiveComponents);

	// method: return the transform of the first game object out of this given game object and its ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static Transform selfOrAncestorTransformWith<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.selfOrAncestorObjectWith<ComponentT>(includeInactiveComponents).transform;

	// method: return the transform of the first game object out of the game object for this component and that game object's ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static Transform selfOrAncestorTransformWith<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.selfOrAncestorTransformWith<ComponentT>(includeInactiveComponents);
	#endregion searching for self or parent based on comparison
}