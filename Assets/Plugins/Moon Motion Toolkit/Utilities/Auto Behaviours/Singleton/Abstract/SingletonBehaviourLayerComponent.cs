using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Component:
// #auto #component
// • provides this singleton behaviour with static access to its auto behaviour's component layer
public abstract class	SingletonBehaviourLayerComponent<SingletonBehaviourT> :
					SingletonBehaviourLayerTransform<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region destruction

	#region of this component
	public static new void destroyThisBehaviour(Func<SingletonBehaviourT, bool> function)
		=> autoBehaviour.destroyThisBehaviour(function);
	public static new void destroyThisBehaviour(bool boolean = true)
		=> autoBehaviour.destroyThisBehaviour(boolean);
	#endregion of this component
	
	#region of the other given component
	public static new void destroy(Component otherComponent, Func<Component, bool> function)
		=> autoBehaviour.destroy(otherComponent, function);
	public static new void destroy(Component otherComponent, bool boolean = true)
		=> autoBehaviour.destroy(otherComponent, boolean);
	#endregion of the other given component
	#endregion destruction


	#region inspector

	// method: hide this component in the inspector, then return this component //
	public static new AutoBehaviour<SingletonBehaviourT> hideInInspector()
		=> autoBehaviour.hideInInspector();

	// method: show this component in the inspector, then return this component //
	public static new AutoBehaviour<SingletonBehaviourT> unhideInInspector()
		=> autoBehaviour.unhideInInspector();
	#endregion inspector


	#region requirement via RequireComponent

	public static new bool requires_ViaReflection<ComponentTPotentiallyRequired>(bool considerInheritedRequireComponents = true) where ComponentTPotentiallyRequired : Component
		=> autoBehaviour.requires_ViaReflection<ComponentTPotentiallyRequired>(considerInheritedRequireComponents);

	public static new bool required_ViaReflection(bool considerInheritedRequireComponents = true)
		=> autoBehaviour.required_ViaReflection(considerInheritedRequireComponents);
	#endregion requirement via RequireComponent


	#region adding components

	// method: add a new component of the specified class to this component's game object, then return the new component //
	public static new ComponentT addGet<ComponentT>() where ComponentT : Component
		=> autoBehaviour.addGet<ComponentT>();

	// method: add a new component of the specified class to this component's game object, then return this component's game object //
	public static new GameObject add<ComponentT>() where ComponentT : Component
		=> autoBehaviour.add<ComponentT>();
	
	public static new ComponentT ensured<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.ensured<ComponentT>(includeInactiveComponents);
	#endregion adding components


	#region determining local components

	public static new bool any<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.any<ComponentT>(includeInactiveComponents);

	public static new bool any<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.any(function, includeInactiveComponents);

	public static new bool hasNo<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.hasNo<ComponentT>(includeInactiveComponents);

	public static new bool anyComponentOtherThan(Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.anyComponentOtherThan(component, includeInactiveComponents);

	public static new bool anyOtherComponent(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.anyOtherComponent(includeInactiveComponents);

	public static new bool anyComponentExcept(Component component, Func<Component, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.anyComponentExcept(component, function, includeInactiveComponents);

	public static new bool anyOtherComponent(Func<Component, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.anyOtherComponent(function, includeInactiveComponents);

	public static new bool anyAutoBehaviours(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.anyAutoBehaviours(includeInactiveComponents);

	public static new bool anyOtherAutoBehaviours(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.anyOtherAutoBehaviours(includeInactiveComponents);
	#endregion determining local components


	#region accessing local components

	// method: return this component's game object's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT first<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.first<ComponentT>(includeInactiveComponents);

	// method: return a list of the specified class of components, optionally including inactive components according to the given boolean, on this component's game object //
	public static new List<ComponentT> pick<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.pick<ComponentT>(includeInactiveComponents);

	// method: return a list of all components on this component's game object, optionally including inactive components according to the given boolean //
	public static new List<Component> components(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.components();

	// method: return a list of all auto behaviours on this component's game object, optionally including inactive components according to the given boolean //
	public static new List<IAutoBehaviour> autoBehaviours(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.autoBehaviours(includeInactiveComponents);
	#endregion accessing local components


	#region iterating local components

	public static new AutoBehaviour<SingletonBehaviourT> forEach<ComponentT>(Action<ComponentT> action, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.forEach(action, includeInactiveComponents);
	#endregion iterating local components


	#region determining child components

	// method: return whether this game object has any of the specified type of child component, optionally including inactive components according to the given boolean //
	public static new bool anyChildren<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.anyChildren<ComponentT>(includeInactiveComponents);
	#endregion determining child components


	#region accessing child components

	// method: return this component's game object's first child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstChild<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstChild<ComponentT>(includeInactiveComponents);

	// method: return this component's game object's last child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT lastChild<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.lastChild<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's game object's child components of the specified class, optionally including inactive components according to the given boolean //
	public static new IEnumerable<ComponentT> children<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.children<ComponentT>(includeInactiveComponents);
	#endregion accessing child components


	#region accessing child or self components

	// method: return this component's first local or child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstLocalOrChild<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstLocalOrChild<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's local and child components of the specified class, optionally including inactive components according to the given boolean //
	public static new ComponentT[] localAndChildren<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.localAndChildren<ComponentT>(includeInactiveComponents);
	
	public static new ComponentI[] localAndChildrenI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> autoBehaviour.localAndChildrenI<ComponentI>(includeInactiveComponents);

	public static new HashSet<GameObject> localAndChildrenObjectsWithI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> autoBehaviour.localAndChildrenObjectsWithI<ComponentI>(includeInactiveComponents);
	#endregion accessing child or self components


	#region accessing parent components

	// method: return this component's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstParent<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstParent<ComponentT>(includeInactiveComponents);

	// method: return a list of this component's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static new List<ComponentT> parental<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.parental<ComponentT>(includeInactiveComponents);

	// method: return this component's first parent component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstAncestor<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's parent components of the specified class, optionally including inactive components according to the given boolean //
	public static new ComponentT[] ancestral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.ancestral<ComponentT>(includeInactiveComponents);
	#endregion accessing parent components


	#region accessing parent or self components

	// method: return this component's first local or parent component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static new ComponentT firstLocalOrAncestor<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstLocalOrAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's local and parent components of the specified class, optionally including inactive components according to the given boolean //
	public static new ComponentT[] localAndAncestral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.localAndAncestral<ComponentT>(includeInactiveComponents);
	#endregion accessing parent or self components


	#region searching for self or parent based on comparison

	// method: return the first game object out of the game object for this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static new GameObject selfOrAncestorObjectWith<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.selfOrAncestorObjectWith<ComponentT>(includeInactiveComponents);

	// method: return the transform of the first game object out of this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public static new Transform selfOrAncestorTransformWith<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.selfOrAncestorTransformWith<ComponentT>(includeInactiveComponents);
	#endregion searching for self or parent based on comparison
}