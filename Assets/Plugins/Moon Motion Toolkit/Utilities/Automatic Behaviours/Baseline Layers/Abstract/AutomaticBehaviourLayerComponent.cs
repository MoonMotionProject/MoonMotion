using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Component:
// #auto #component
// • provides this behaviour with direct access to its extension methods for being a component
public abstract class	AutomaticBehaviourLayerComponent<AutomaticBehaviourT> :
					AutomaticBehaviourLayerTransform<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	#region destruction

	public void destroy(Func<AutomaticBehaviourT, bool> function)
		=> component.destroy(function(automaticBehaviour));

	public void destroy(bool boolean = true)
		=> component.destroy(boolean);
	#endregion destruction


	#region getting piblings

	// an array of the same components on this component's piblings //
	public IEnumerable<AutomaticBehaviourT> piblings => automaticBehaviour.piblings();
	#endregion getting piblings


	#region inspector

	// method: hide this component in the inspector, then return this component //
	public AutomaticBehaviourT hideInInspector()
		=> component.hideInInspector().castTo<AutomaticBehaviourT>();

	// method: hide this component in the inspector, then return this component //
	public AutomaticBehaviourT unhideInInspector()
		=> component.unhideInInspector().castTo<AutomaticBehaviourT>();
	#endregion inspector


	#region requirement via RequireComponent

	public bool requires_ViaReflection<ComponentTPotentiallyRequired>(bool considerInheritedRequireComponents = true) where ComponentTPotentiallyRequired : Component
		=> component.requires_ViaReflection<ComponentTPotentiallyRequired>(considerInheritedRequireComponents);
	
	public bool required_ViaReflection(bool considerInheritedRequireComponents = true)
		=> automaticBehaviour.required_ViaReflection<AutomaticBehaviourT>(considerInheritedRequireComponents);
	#endregion requirement via RequireComponent


	#region adding components

	// method: add a new component of the specified class to this component's game object, then return the new component //
	public ComponentT add<ComponentT>() where ComponentT : Component
		=> gameObject.add<ComponentT>();

	// method: add a new component of the specified class to this component's game object, then return this component's game object //
	public GameObject afterAdding<ComponentT>() where ComponentT : Component
		=> gameObject.afterAdding<ComponentT>();

	// method: if this game object has none of the specified component, add a new component of the specified class to this game object, then return the first such component on this game object //
	public ComponentT ensure<ComponentT>() where ComponentT : Component
		=> gameObject.ensure<ComponentT>();
	#endregion adding components


	#region determining local components

	public bool any<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.any<ComponentT>(includeInactiveComponents);

	public bool any<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.any(function, includeInactiveComponents);
	
	public bool hasNo<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.hasNo<ComponentT>(includeInactiveComponents);

	public bool anyComponentOtherThan(Component component, bool includeInactiveComponents = true)
		=> gameObject.anyComponentOtherThan(component, includeInactiveComponents);

	public bool anyOtherComponent(bool includeInactiveComponents = true)
		=> component.anyOtherComponent(includeInactiveComponents);

	public bool anyComponentOtherThan(Component component, Func<Component, bool> function, bool includeInactiveComponents = true)
		=> gameObject.anyComponentOtherThan(component, function, includeInactiveComponents);

	public bool anyOtherComponent(Func<Component, bool> function, bool includeInactiveComponents = true)
		=> component.anyOtherComponent(function, includeInactiveComponents);

	public bool anyAutomaticBehaviours(bool includeInactiveComponents = true)
		=> gameObject.anyAutomaticBehaviours(includeInactiveComponents);

	public bool anyOtherAutomaticBehaviours(bool includeInactiveComponents = true)
		=> automaticBehaviour.anyOtherAutomaticBehaviours<AutomaticBehaviourT>(includeInactiveComponents);
	#endregion determining local components


	#region getting local components

	// method: return this component's game object's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT first<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.first<ComponentT>(includeInactiveComponents);

	// method: return an array of the specified class of components, optionally including inactive components according to the given boolean, on this component's game object //
	public IEnumerable<ComponentT> select<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.select<ComponentT>(includeInactiveComponents);

	// method: return an enumerable of all components on this component's game object, optionally including inactive components according to the given boolean //
	public IEnumerable<Component> components(bool includeInactiveComponents = true)
		=> gameObject.components(includeInactiveComponents);

	// method: return an enumerable of all automatic behaviours on this component's game object, optionally including inactive components according to the given boolean //
	public IEnumerable<IAutomaticBehaviour> automaticBehaviours(bool includeInactiveComponents = true)
		=> component.automaticBehaviours(includeInactiveComponents);
	#endregion getting local components


	#region iterating local components

	public IEnumerable<ComponentT> forEach<ComponentT>(Action<ComponentT> action, bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.forEach(action, includeInactiveComponents);
	#endregion iterating local components


	#region getting child components

	// method: return this component's game object's first child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT selectChild<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.selectChild<ComponentT>(includeInactiveComponents);

	// method: return this component's game object's last child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT lastChild<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.lastChild<ComponentT>(includeInactiveComponents);

	// method: return an array of this given component's child components of the specified class, optionally including inactive components according to the given boolean //
	public IEnumerable<ComponentT> selectChildren<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.selectChildren<ComponentT>(includeInactiveComponents);
	#endregion getting child components


	#region getting child or self components

	// method: return this component's first local or child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT firstLocalOrChild<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.firstLocalOrChild<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's local and child components of the specified class, optionally including inactive components according to the given boolean //
	public ComponentT[] localAndChildren<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.localAndChildren<ComponentT>(includeInactiveComponents);
	#endregion getting child or self components


	#region getting parent components

	// method: return this component's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT firstParent<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.firstParent<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public IEnumerable<ComponentT> selectParent<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.selectParent<ComponentT>(includeInactiveComponents);

	// method: return this component's game object's first parent component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT firstAncestor<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.firstAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's parent components of the specified class, optionally including inactive components according to the given boolean //
	public ComponentT[] selectAncestor<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.selectAncestor<ComponentT>(includeInactiveComponents);
	#endregion getting parent components


	#region getting parent or self components

	// method: return this component's first local or parent component of the specified class, optionally including inactive components according to the given boolean (null if none found) //
	public ComponentT firstLocalOrAncestor<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.firstLocalOrAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's local and parent components of the specified class, optionally including inactive components according to the given boolean //
	public ComponentT[] selectLocalAndAncestor<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.selectLocalAndAncestor<ComponentT>(includeInactiveComponents);
	#endregion getting parent or self components


	#region searching for self or parent based on comparison

	// method: return the first game object out of the game object for this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public GameObject selfOrAncestorWith<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.selfOrAncestorWith<ComponentT>(includeInactiveComponents);

	// method: return the transform of the first game object out of this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public Transform selfOrAncestorTransformWith<ComponentT>(bool includeInactiveComponents = true) where ComponentT : Component
		=> gameObject.selfOrAncestorTransformWith<ComponentT>(includeInactiveComponents);
	#endregion searching for self or parent based on comparison
}