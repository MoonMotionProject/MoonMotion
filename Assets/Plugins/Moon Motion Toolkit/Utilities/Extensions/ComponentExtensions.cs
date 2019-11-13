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
		=> enumerable.forEach(component => component.destroy(function(component)));

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

	public static GameObject destroyEach<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=>	gameObject.forEach<ComponentT>(component =>
				component.destroy(),
				includeInactiveComponents);
	
	// method: destroy all components on this given game object that are not of the specified type (nor the given game object's transform), optionally including inactive components according to the given boolean, then return this given game object //
	public static GameObject destroyAllComponentsThatAreNot<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=>	gameObject.forEachComponentThatIsNot<ComponentT>(component =>
				component.destroy(component.isNot<Transform>()),
				includeInactiveComponents);
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

	// method: (according to the given boolean:) execute all of this component's game object's mono behaviours' defined methods (ignoring inherited methods that haven't been overriden) with the given name, then return this given game object //
	public static ComponentT executeAllLocal<ComponentT>(this ComponentT component, string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.executeAllLocal(methodName, sendMessageOptions, boolean));

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


	#region duplicating components
	
	/* not yet implemented; this looks like the best reference: http://answers.unity.com/answers/641022/view.html
	// method: add a duplicate of the first component of the specified type on the given provided other game object to this given game object, then return this given game object //
	public static GameObject addDuplicate<ComponentT>(this GameObject gameObject, object otherGameObject_GameObjectProvider)
		where ComponentT : Component
	{
		
	}*/
	#endregion duplicating components
	

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

	// methods: return whether this given provided game object has any component of the specified interface, optionally including inactive components according to the given boolean //
	public static bool hasAnyI<ComponentI>
	(
		this GameObject gameObject,
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentI : class
	{
		if (!typeof(ComponentI).IsInterface)
		{
			return false.returnWithError(typeof(ComponentI).simpleClassName()+" is not an interface");
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

	// methods: return whether this given provided game object has any component of the specified interface for which the given function returns true, optionally including inactive components according to the given boolean //
	public static bool hasAnyI<ComponentI>
	(
		this GameObject gameObject,
		Func<ComponentI, bool> function,
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentI : class
	{
		if (!typeof(ComponentI).IsInterface)
		{
			return false.returnWithError(typeof(ComponentI).simpleClassName()+" is not an interface");
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
	// method: return this given game object's first component of the specified interface (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentI firstI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (!typeof(ComponentI).IsInterface)
		{
			return default(ComponentI).returnWithError(typeof(ComponentI).simpleClassName()+" is not an interface");
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

	// method: invoke the given action on each component that is not of the specified type on this given game object, optionally including inactive components according to the given boolean, then return this given game object //
	public static GameObject forEachComponentThatIsNot<ComponentT>(this GameObject gameObject, Action<Component> action, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=>	gameObject.forEachComponent(component =>
			{
				if (component.isNot<ComponentT>())
				{
					action(component);
				}
			}, includeInactiveComponents);
	#endregion iterating local components


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


	#region determining descendant components

	// method: return whether this given game object has any of the specified type of descendant component, optionally including inactive components according to the given boolean //
	public static bool hasAnyDescendant<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(gameObject.descendants<ComponentT>(includeInactiveComponents));

	// method: return whether this given transform has any of the specified type of descendant component, optionally including inactive components according to the given boolean //
	public static bool hasAnyDescendant<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(transform.descendants<ComponentT>(includeInactiveComponents));

	// method: return whether this given component has any of the specified type of descendant component, optionally including inactive components according to the given boolean //
	public static bool hasAnyDescendant<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(component.descendants<ComponentT>(includeInactiveComponents));
	#endregion determining descendant components


	#region accessing descendant components

	// method: return this given game object's first descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstDescendant<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.descendants<ComponentT>(includeInactiveComponents).FirstOrDefault();

	// method: return this given transform's first descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstDescendant<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.firstDescendant<ComponentT>(includeInactiveComponents);

	// method: return this given component's first descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstDescendant<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.firstDescendant<ComponentT>(includeInactiveComponents);

	// method: return this given game object's last descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastDescendant<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.descendants<ComponentT>(includeInactiveComponents).LastOrDefault();

	// method: return this given transform's last descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastDescendant<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.lastDescendant<ComponentT>(includeInactiveComponents);

	// method: return this given component's last descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT lastDescendant<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.lastDescendant<ComponentT>(includeInactiveComponents);

	// method: return a list of this given game object's descendant components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> descendants<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.GetComponentsInChildren<ComponentT>(includeInactiveComponents).where(component => component.whereNotOn(gameObject));

	// method: return a list of this given transform's descendant components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> descendants<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.descendants<ComponentT>(includeInactiveComponents);

	// method: return a list of this given component's descendant components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> descendants<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.descendants<ComponentT>(includeInactiveComponents);
	#endregion accessing descendant components


	#region determining local or descendant components

	// method: return whether this given game object has any of the specified type of local or descendant component, optionally including inactive components according to the given boolean //
	public static bool hasAnyLocalOrDescendant<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(gameObject.localAndDescendant<ComponentT>(includeInactiveComponents));

	// method: return whether this given transform has any of the specified type of local or descendant component, optionally including inactive components according to the given boolean //
	public static bool hasAnyLocalOrDescendant<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(transform.localAndDescendant<ComponentT>(includeInactiveComponents));

	// method: return whether this given component has any of the specified type of local or descendant component, optionally including inactive components according to the given boolean //
	public static bool hasAnyLocalOrDescendant<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(component.localAndDescendant<ComponentT>(includeInactiveComponents));

	// method: return whether this given raycast hit's game object has any of the specified type of local or descendant component, optionally including inactive components according to the given boolean //
	public static bool hasAnyLocalOrDescendant<ComponentT>(this RaycastHit raycastHit, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(raycastHit.localAndDescendant<ComponentT>(includeInactiveComponents));
	
	public static bool hasAnyLocalOrDescendantI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (!typeof(ComponentI).IsInterface)
		{
			return false.returnWithError(typeof(ComponentI).simpleClassName()+" is not an interface");
		}

		return Any.itemsIn(gameObject.localAndDescendantI<ComponentI>(includeInactiveComponents));
	}
	#endregion determining local or descendant components


	#region accessing local or descendant components

	// method: return this given game object's first local or descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrDescendant<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.GetComponentInChildren<ComponentT>(includeInactiveComponents);
	// method: return this given transform's first local or descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrDescendant<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.GetComponentInChildren<ComponentT>(includeInactiveComponents);
	// method: return this given component's first local or descendant component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstLocalOrDescendant<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.GetComponentInChildren<ComponentT>(includeInactiveComponents);
	
	public static GameObject firstLocalOrDescendantObjectWith<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstLocalOrDescendant<ComponentT>().gameObject;
	public static GameObject firstLocalOrDescendantObjectWith<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.firstLocalOrDescendant<ComponentT>().gameObject;
	
	public static ComponentI firstLocalOrDescendantI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (!typeof(ComponentI).IsInterface)
		{
			return default(ComponentI).returnWithError(typeof(ComponentI).simpleClassName()+" is not an interface");
		}

		return gameObject.GetComponentInChildren<ComponentI>(includeInactiveComponents);
	}

	// method: return an array of this given game object's local and descendant components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndDescendant<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.GetComponentsInChildren<ComponentT>(includeInactiveComponents);
	// method: return an array of this given component's local and descendant components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndDescendant<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.GetComponentsInChildren<ComponentT>(includeInactiveComponents);
	// method: return an array of this given raycast hit's game object's local and descendant components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] localAndDescendant<ComponentT>(this RaycastHit raycastHit, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> raycastHit.transform.localAndDescendant<ComponentT>(includeInactiveComponents);
	
	// method: return an array of the specified interface of components, optionally including inactive components according to the given boolean, which are local or descendant to this given game object //
	public static ComponentI[] localAndDescendantI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (!typeof(ComponentI).IsInterface)
		{
			return default(ComponentI[]).returnWithError(typeof(ComponentI).simpleClassName()+" is not an interface");
		}

		return gameObject.GetComponentsInChildren<ComponentI>(includeInactiveComponents);
	}

	// method: return the set of game objects with the specified interface of components, optionally including inactive components according to the given boolean, which are local or descendant to this given game object //
	public static HashSet<GameObject> localAndDescendantObjectsWithI<ComponentI>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
	{
		if (!typeof(ComponentI).IsInterface)
		{
			return default(HashSet<GameObject>).returnWithError(typeof(ComponentI).simpleClassName()+" is not an interface");
		}

		return gameObject.localAndDescendant<Component>(includeInactiveComponents).where(monoBehaviour =>
			monoBehaviour is ComponentI).uniqueObjects();
	}
	#endregion accessing local or descendant components


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
	#endregion accessing parent components


	#region accessing ancestral components

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
		=>	gameObject.hasAnyParent() ?
				gameObject.parent().GetComponentsInParent<ComponentT>(includeInactiveComponents) :
				new ComponentT[] {};

	// method: return an array of this given transform's ancestral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] ancestral<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.parent.GetComponentsInParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this given component's ancestral components of the specified class, optionally including inactive components according to the given boolean //
	public static ComponentT[] ancestral<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.parent().GetComponentsInParent<ComponentT>(includeInactiveComponents);
	#endregion accessing ancestral components


	#region determining ancestral components

	// method: return whether this given game object has any of the specified type of ancestral component, optionally including inactive components according to the given boolean //
	public static bool hasAnyAncestral<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> Any.itemsIn(gameObject.ancestral<ComponentT>(includeInactiveComponents));

	// method: return whether this given component has any of the specified type of ancestral component, optionally including inactive components according to the given boolean //
	public static bool hasAnyAncestral<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.hasAnyAncestral<ComponentT>();
	#endregion determining ancestral components

	
	#region accessing local or ancestral components

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
	#endregion accessing local or ancestral components


	#region searching for self or ancestor based on comparison

	// method: return the first game object out of this given game object and its ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static GameObject firstSelfOrAncestorObjectWith<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
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
	public static GameObject firstSelfOrAncestorObjectWith<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.firstSelfOrAncestorObjectWith<ComponentT>(includeInactiveComponents);

	// method: return the transform of the first game object out of this given game object and its ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static Transform firstSelfOrAncestorTransformWith<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstSelfOrAncestorObjectWith<ComponentT>(includeInactiveComponents).transform;

	// method: return the transform of the first game object out of the game object for this component and that game object's ancestor game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static Transform firstSelfOrAncestorTransformWith<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.firstSelfOrAncestorTransformWith<ComponentT>(includeInactiveComponents);
	#endregion searching for self or ancestor based on comparison
}