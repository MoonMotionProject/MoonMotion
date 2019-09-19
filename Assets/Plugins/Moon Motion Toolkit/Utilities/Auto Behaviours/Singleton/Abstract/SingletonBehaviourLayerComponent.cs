using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Component:
// #auto #component
// • provides this singleton behaviour with static access to its automatic behaviour's component layer
public abstract class	SingletonBehaviourLayerComponent<SingletonBehaviourT> :
					SingletonBehaviourLayerTransform<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region destruction

	public static new void destroy(Func<SingletonBehaviourT, bool> function)
		=> automaticBehaviour.destroy(function(singleton));

	public static new void destroy(bool boolean = true)
		=> automaticBehaviour.destroy(boolean);
	#endregion destruction


	#region inspector

	// method: hide this component in the inspector, then return this component //
	public static new AutomaticBehaviour<SingletonBehaviourT> hideInInspector()
		=> automaticBehaviour.hideInInspector();

	// method: show this component in the inspector, then return this component //
	public static new AutomaticBehaviour<SingletonBehaviourT> unhideInInspector()
		=> automaticBehaviour.unhideInInspector();
	#endregion inspector


	#region requirement via RequireComponent

	public static new bool requires_ViaReflection<ComponentTPotentiallyRequired>(bool considerInheritedRequireComponents = true) where ComponentTPotentiallyRequired : Component
		=> automaticBehaviour.requires_ViaReflection<ComponentTPotentiallyRequired>(considerInheritedRequireComponents);

	public static new bool required_ViaReflection(bool considerInheritedRequireComponents = true)
		=> automaticBehaviour.required_ViaReflection(considerInheritedRequireComponents);
	#endregion requirement via RequireComponent


	#region adding components

	// method: add a new component of the specified class to this component's game object, then return the new component //
	public static new ComponentT addGet<ComponentT>() where ComponentT : Component
		=> automaticBehaviour.addGet<ComponentT>();

	// method: add a new component of the specified class to this component's game object, then return this component's game object //
	public static new GameObject add<ComponentT>() where ComponentT : Component
		=> automaticBehaviour.add<ComponentT>();

	// method: if this game object has none of the specified component, add a new component of the specified class to this game object, then return the first such component on this game object //
	public static new ComponentT ensured<ComponentT>() where ComponentT : Component
		=> automaticBehaviour.ensured<ComponentT>();
	#endregion adding components


	#region determining local components

	public static new bool any<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.any<ComponentT>(includeInactiveComponents);

	public static new bool any<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.any(function, includeInactiveComponents);

	public static new bool hasNo<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.hasNo<ComponentT>(includeInactiveComponents);

	public static new bool anyComponentOtherThan(Component component, bool includeInactiveComponents = true)
		=> automaticBehaviour.anyComponentOtherThan(component, includeInactiveComponents);

	public static new bool anyOtherComponent(bool includeInactiveComponents = true)
		=> automaticBehaviour.anyOtherComponent(includeInactiveComponents);

	public static new bool anyComponentExcept(Component component, Func<Component, bool> function, bool includeInactiveComponents = true)
		=> automaticBehaviour.anyComponentExcept(component, function, includeInactiveComponents);

	public static new bool anyOtherComponent(Func<Component, bool> function, bool includeInactiveComponents = true)
		=> automaticBehaviour.anyOtherComponent(function, includeInactiveComponents);

	public static new bool anyAutomaticBehaviours(bool includeInactiveComponents = true)
		=> automaticBehaviour.anyAutomaticBehaviours(includeInactiveComponents);

	public static new bool anyOtherAutomaticBehaviours(bool includeInactiveComponents = true)
		=> automaticBehaviour.anyOtherAutomaticBehaviours(includeInactiveComponents);
	#endregion determining local components


	#region accessing local components

	// method: return this component's game object's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT first<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.first<ComponentT>(includeInactiveComponents);

	// method: return a list of the specified class of components, optionally including inactive components according to the given boolean, on this component's game object //
	public static new List<ComponentT> pick<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.pick<ComponentT>(includeInactiveComponents);

	// method: return a list of all components on this component's game object, optionally including inactive components according to the given boolean //
	public static new List<Component> components(bool includeInactiveComponents = true)
		=> automaticBehaviour.components();

	// method: return a list of all automatic behaviours on this component's game object, optionally including inactive components according to the given boolean //
	public static new List<IAutomaticBehaviour> automaticBehaviours(bool includeInactiveComponents = true)
		=> automaticBehaviour.automaticBehaviours(includeInactiveComponents);
	#endregion accessing local components


	#region iterating local components

	public static new AutomaticBehaviour<SingletonBehaviourT> forEach<ComponentT>(Action<ComponentT> action, bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.forEach(action, includeInactiveComponents);
	#endregion iterating local components


	#region determining child components

	// method: return whether this game object has any of the specified type of child component, optionally including inactive components according to the given boolean //
	public static new bool anyChildren<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.anyChildren<ComponentT>(includeInactiveComponents);
	#endregion determining child components


	#region accessing child components

	// method: return this component's game object's first child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstChild<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.firstChild<ComponentT>(includeInactiveComponents);

	// method: return this component's game object's last child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT lastChild<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.lastChild<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's game object's child components of the specified class, optionally including inactive components according to the given boolean //
	public static new IEnumerable<ComponentT> children<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.children<ComponentT>(includeInactiveComponents);
	#endregion accessing child components


	#region accessing child or self components

	// method: return this component's first local or child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstLocalOrChild<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.firstLocalOrChild<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's local and child components of the specified class, optionally including inactive components according to the given boolean //
	public static new ComponentT[] localAndChildren<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.localAndChildren<ComponentT>(includeInactiveComponents);
	#endregion accessing child or self components


	#region accessing parent components

	// method: return this component's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstParent<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.firstParent<ComponentT>(includeInactiveComponents);

	// method: return a list of this component's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static new List<ComponentT> parental<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.parental<ComponentT>(includeInactiveComponents);

	// method: return this component's first parent component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstAncestor<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.firstAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's parent components of the specified class, optionally including inactive components according to the given boolean //
	public static new ComponentT[] ancestral<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.ancestral<ComponentT>(includeInactiveComponents);
	#endregion accessing parent components


	#region accessing parent or self components

	// method: return this component's first local or parent component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstLocalOrAncestor<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.firstLocalOrAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's local and parent components of the specified class, optionally including inactive components according to the given boolean //
	public static new ComponentT[] localAndAncestral<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.localAndAncestral<ComponentT>(includeInactiveComponents);
	#endregion accessing parent or self components


	#region searching for self or parent based on comparison

	// method: return the first game object out of the game object for this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static new GameObject selfOrAncestorObjectWith<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.selfOrAncestorObjectWith<ComponentT>(includeInactiveComponents);

	// method: return the transform of the first game object out of this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static new Transform selfOrAncestorTransformWith<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.selfOrAncestorTransformWith<ComponentT>(includeInactiveComponents);
	#endregion searching for self or parent based on comparison
}