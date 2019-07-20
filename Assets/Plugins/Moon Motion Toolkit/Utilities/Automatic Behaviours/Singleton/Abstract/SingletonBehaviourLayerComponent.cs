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
	#region methods/properties


	// methods for: destruction //

	public static new void destroy(Func<SingletonBehaviourT, bool> function)
		=> automaticBehaviour.destroy(function(singleton));

	public static new void destroy(bool boolean = true)
		=> automaticBehaviour.destroy(boolean);


	// methods for: inspector //

	// method: hide this component in the inspector, then return this component //
	public static new SingletonBehaviourT hideInInspector()
		=> automaticBehaviour.hideInInspector();

	// method: show this component in the inspector, then return this component //
	public static new SingletonBehaviourT unhideInInspector()
		=> automaticBehaviour.unhideInInspector();


	// methods for: requirement via RequireComponent //

	public static new bool requires_ViaReflection<ComponentTPotentiallyRequired>(bool considerInheritedRequireComponents = true) where ComponentTPotentiallyRequired : Component
		=> automaticBehaviour.requires_ViaReflection<ComponentTPotentiallyRequired>(considerInheritedRequireComponents);

	public static new bool required_ViaReflection(bool considerInheritedRequireComponents = true)
		=> automaticBehaviour.required_ViaReflection(considerInheritedRequireComponents);


	// methods for: adding components //

	// method: add a new component of the specified class to this component's game object, then return the new component //
	public static new ComponentT add<ComponentT>() where ComponentT : Component
		=> automaticBehaviour.add<ComponentT>();

	// method: add a new component of the specified class to this component's game object, then return this component's game object //
	public static new GameObject afterAdding<ComponentT>() where ComponentT : Component
		=> automaticBehaviour.afterAdding<ComponentT>();

	// method: if this game object has none of the specified component, add a new component of the specified class to this game object, then return the first such component on this game object //
	public static new ComponentT ensure<ComponentT>() where ComponentT : Component
		=> automaticBehaviour.ensure<ComponentT>();


	// methods for: determining local components //

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

	public static new bool anyComponentOtherThan(Component component, Func<Component, bool> function, bool includeInactiveComponents = true)
		=> automaticBehaviour.anyComponentOtherThan(component, function, includeInactiveComponents);

	public static new bool anyOtherComponent(Func<Component, bool> function, bool includeInactiveComponents = true)
		=> automaticBehaviour.anyOtherComponent(function, includeInactiveComponents);

	public static new bool anyAutomaticBehaviours(bool includeInactiveComponents = true)
		=> automaticBehaviour.anyAutomaticBehaviours(includeInactiveComponents);

	public static new bool anyOtherAutomaticBehaviours(bool includeInactiveComponents = true)
		=> automaticBehaviour.anyOtherAutomaticBehaviours(includeInactiveComponents);


	// methods for: getting local components //

	// method: return this component's game object's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT first<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.first<ComponentT>(includeInactiveComponents);

	// method: return an array of the specified class of components, optionally including inactive components according to the given boolean, on this component's game object //
	public static new IEnumerable<ComponentT> select<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.select<ComponentT>(includeInactiveComponents);

	// method: return an enumerable of all components on this component's game object, optionally including inactive components according to the given boolean //
	public static new IEnumerable<Component> components(bool includeInactiveComponents = true)
		=> automaticBehaviour.components();

	// method: return an enumerable of all automatic behaviours on this component's game object, optionally including inactive components according to the given boolean //
	public static new IEnumerable<IAutomaticBehaviour> automaticBehaviours(bool includeInactiveComponents = true)
		=> automaticBehaviour.automaticBehaviours(includeInactiveComponents);


	// methods for: iterating local components //

	public static new IEnumerable<ComponentT> forEach<ComponentT>(Action<ComponentT> action, bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.forEach(action, includeInactiveComponents);


	// methods for: getting child components //

	// method: return this component's game object's first child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT selectChild<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.selectChild<ComponentT>(includeInactiveComponents);

	// method: return this component's game object's last child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT lastChild<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.lastChild<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's game object's child components of the specified class, optionally including inactive components according to the given boolean //
	public static new IEnumerable<ComponentT> selectChildren<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.selectChildren<ComponentT>(includeInactiveComponents);


	// methods for: getting child or self components //

	// method: return this component's first local or child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstLocalOrChild<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.firstLocalOrChild<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's local and child components of the specified class, optionally including inactive components according to the given boolean //
	public static new ComponentT[] localAndChildren<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.localAndChildren<ComponentT>(includeInactiveComponents);


	// methods for: getting parent components //

	// method: return this component's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstParent<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.firstParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static new IEnumerable<ComponentT> selectParent<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.selectParent<ComponentT>(includeInactiveComponents);

	// method: return this component's first parent component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstAncestor<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.firstAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's parent components of the specified class, optionally including inactive components according to the given boolean //
	public static new ComponentT[] selectAncestor<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.selectAncestor<ComponentT>(includeInactiveComponents);


	// methods for: getting parent or self components //

	// method: return this component's first local or parent component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstLocalOrAncestor<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.firstLocalOrAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's local and parent components of the specified class, optionally including inactive components according to the given boolean //
	public static new ComponentT[] selectLocalAndAncestor<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.selectLocalAndAncestor<ComponentT>(includeInactiveComponents);


	// methods for: searching for self or parent based on comparison //

	// method: return the first game object out of the game object for this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static new GameObject selfOrAncestorWith<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.selfOrAncestorWith<ComponentT>(includeInactiveComponents);

	// method: return the transform of the first game object out of this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static new Transform selfOrAncestorTransformWith<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> automaticBehaviour.selfOrAncestorTransformWith<ComponentT>(includeInactiveComponents);
	#endregion methods/properties
}