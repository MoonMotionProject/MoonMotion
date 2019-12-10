using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Component Extensions: provides extension methods for handling components //
// #component
public static class ComponentExtensions
{
	#region destruction

	// method: destroy this given component's game object according to the given booleanic function upon this given component, then return the result of that function //
	public static bool destroyObject<ComponentT>(this ComponentT component, Func<ComponentT, bool> function) where ComponentT : Component
		=>	function(component).returnAndUse(result =>
			{
				if (result)
				{
					component.gameObject.destroy();
				}
			});

	// method: (according to the given boolean:) destroy this given component's game object //
	public static void destroyObject(this Component component, bool boolean = true)
		=> boolean.returnAnd(()=>
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
	
	// method: (via reflection:) destroy all components on this given game object – besides its transform – which are not derived from the specified type, optionally including inactive components according to the given boolean, then return this given game object //
	public static GameObject destroyAllComponentsNotDerivedFrom_ViaReflection<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=>	gameObject.forEachComponentThatIsNotDerivedFrom_ViaReflection<ComponentT>(component =>
				component.destroy(component.derivedTypeIsNot_ViaReflection<Transform>()),
				includeInactiveComponents);
	#endregion destruction


	#region activity

	// method: return whether this given component's game object is active locally //
	public static bool isActiveLocally(this Component component)
		=> component.gameObject.isActiveLocally();
	// method: return whether this given component's game object is inactive locally //
	public static bool isInactiveLocally(this Component component)
		=> component.gameObject.isInactiveLocally();

	// method: return whether this given component's game object is active globally //
	public static bool isActiveGlobally(this Component component)
		=> component.gameObject.isActiveGlobally();
	// method: return whether this given component's game object is inactive globally //
	public static bool isInactiveGlobally(this Component component)
		=> component.gameObject.isInactiveGlobally();

	// method: set the activity of this given component's game object to the given boolean, then return this given component //
	public static ComponentT setActivityTo<ComponentT>(this ComponentT component, bool activity) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.setActivityTo(activity));

	// method: activate this given component, then return it //
	public static ComponentT activate<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.activate());

	// method: deactivate this given component, then return it //
	public static ComponentT deactivate<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.activate());

	// method: toggle the activity of this given component using the given toggling, then return this given component //
	public static ComponentT toggleActivityBy<ComponentT>(this ComponentT component, Toggling toggling) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.toggleActivityBy(toggling));

	// method: toggle the activity of these given components using the given toggling, then return them //
	public static ComponentT[] toggleActivityBy<ComponentT>(this ComponentT[] components, Toggling toggling) where ComponentT : Component
		=> components.forEach(component => component.toggleActivityBy(toggling));

	// method: set the activity of these given components to the given boolean, then return them //
	public static ComponentT[] setActivityTo<ComponentT>(this ComponentT[] components, bool activity) where ComponentT : Component
		=> components.forEach(component => component.setActivityTo(activity));

	// method: activate these given components, then return them //
	public static ComponentT[] activate<ComponentT>(this ComponentT[] components) where ComponentT : Component
		=> components.setActivityTo(true);

	// method: deactivate these given components, then return them //
	public static ComponentT[] deactivate<ComponentT>(this ComponentT[] components) where ComponentT : Component
		=> components.setActivityTo(false);
	#endregion activity


	#region calling local methods

	// method: (according to the given boolean:) execute all of this component's game object's mono behaviours' defined methods (ignoring inherited methods that haven't been overriden) with the given name, then return this given game object //
	public static ComponentT executeAllLocal<ComponentT>(this ComponentT component, string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.executeAllLocal(methodName, sendMessageOptions, boolean));

	// method: (if in the editor:) have this given component's game object validate, then return this given component //
	public static ComponentT validateObject_IfInEditor<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.validate_IfInEditor());

	/* (via reflection) */
	public static ComponentI validateObjectViaThisI_IfInEditor<ComponentI>(this ComponentI component) where ComponentI : class
	{
		if (Interfaces.doesNotInclude<ComponentI>())
		{
			return default(ComponentI).returnWithError(typeof(ComponentI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return	component.after(()=>
					component.castTo<Component>().validateObject_IfInEditor());
	}

	// method: (if in the editor:) have this given set of components' game objects validate, then return this given set of components //
	public static HashSet<ComponentT> validateObjects_IfInEditor<ComponentT>(this HashSet<ComponentT> components) where ComponentT : Component
		=> components.forEach(component => component.validateObject_IfInEditor());

	/* (via reflection) */
	public static HashSet<ComponentI> validateObjectsViaTheseI_IfInEditor<ComponentI>(this HashSet<ComponentI> components) where ComponentI : class
	{
		if (Interfaces.doesNotInclude<ComponentI>())
		{
			return default(HashSet<ComponentI>).returnWithError(typeof(ComponentI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return	components.after(()=>
					components.forEach(component => component.validateObjectViaThisI_IfInEditor()));
	}
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
}