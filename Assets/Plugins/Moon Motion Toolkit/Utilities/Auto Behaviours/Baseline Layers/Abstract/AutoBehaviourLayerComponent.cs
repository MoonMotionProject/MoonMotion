using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Component:
// #auto #component
// • provides this behaviour with direct access to its extension methods for being a component
public abstract class	AutoBehaviourLayerComponent<AutoBehaviourT> :
					AutoBehaviourLayerTransform<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region destruction

	#region of this component
	public void destroyThisBehaviour(Func<AutoBehaviourT, bool> function)
		=> self.destroy(function);
	public void destroyThisBehaviour(bool boolean = true)
		=> component.destroy(boolean);
	#endregion of this component
	
	#region of the other given component
	public void destroy(Component otherComponent, Func<Component, bool> function)
		=> otherComponent.destroy(function);
	public void destroy(Component otherComponent, bool boolean = true)
		=> otherComponent.destroy(boolean);
	#endregion of the other given component
	#endregion destruction


	#region accessing piblings

	// a selection of the same components on this component's piblings //
	public IEnumerable<AutoBehaviourT> selectEachFirstPibling => self.selectEachFirstPibling();

	// a list of the same components on this component's piblings //
	public List<AutoBehaviourT> eachFirstPibling => self.eachFirstPibling();
	#endregion accessing piblings


	#region inspector

	// method: hide this component in the inspector, then return this behaviour //
	public AutoBehaviourT hideInInspector()
		=> selfAfter(()=> component.hideInInspector());

	// method: hide this component in the inspector, then return this behaviour //
	public AutoBehaviourT unhideInInspector()
		=> selfAfter(()=> component.unhideInInspector());
	#endregion inspector


	#region requirement via RequireComponent

	public bool requires_ViaReflection<ComponentTPotentiallyRequired>(bool considerInheritedRequireComponents = true) where ComponentTPotentiallyRequired : Component
		=> component.requires_ViaReflection<ComponentTPotentiallyRequired>(considerInheritedRequireComponents);
	
	public bool required_ViaReflection(bool considerInheritedRequireComponents = true)
		=> self.required_ViaReflection<AutoBehaviourT>(considerInheritedRequireComponents);
	#endregion requirement via RequireComponent


	#region adding components

	// method: add a new component of the specified class to this component's game object, then return the new component //
	public ComponentT addGet<ComponentT>() where ComponentT : Component
		=> gameObject.addGet<ComponentT>();

	// method: add a new component of the specified class to this component's game object, then return this component's game object //
	public GameObject add<ComponentT>() where ComponentT : Component
		=> gameObject.add<ComponentT>();
	
	public ComponentT ensured<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.ensured<ComponentT>(includeInactiveComponents);
	#endregion adding components


	#region determining local components

	public bool any<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAny<ComponentT>(includeInactiveComponents);

	public bool any<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAny(function, includeInactiveComponents);
	
	public bool hasNo<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasNo<ComponentT>(includeInactiveComponents);

	public bool anyComponentOtherThan(Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.hasAnyComponentOtherThan(component, includeInactiveComponents);

	public bool anyOtherComponent(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.hasAnyOtherComponent(includeInactiveComponents);

	public bool anyComponentExcept(Component component, Func<Component, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.hasAnyComponentExcept(component, function, includeInactiveComponents);

	public bool anyOtherComponent(Func<Component, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.hasAnyOtherComponent(function, includeInactiveComponents);

	public bool anyAutoBehaviours(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.hasAnyAutoBehaviours(includeInactiveComponents);

	public bool anyOtherAutoBehaviours(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> self.hasAnyOtherAutoBehaviours<AutoBehaviourT>(includeInactiveComponents);
	#endregion determining local components


	#region accessing local components

	// method: return this component's game object's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT first<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.first<ComponentT>(includeInactiveComponents);

	// method: return a list of the specified class of components, optionally including inactive components according to the given boolean, on this component's game object //
	public List<ComponentT> pick<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.pick<ComponentT>(includeInactiveComponents);

	// method: return a list of all components on this component's game object, optionally including inactive components according to the given boolean //
	public List<Component> components(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.components(includeInactiveComponents);

	// method: return a list of all auto behaviours on this component's game object, optionally including inactive components according to the given boolean //
	public List<IAutoBehaviour> autoBehaviours(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.autoBehaviours(includeInactiveComponents);
	#endregion accessing local components


	#region iterating local components

	public AutoBehaviourT forEach<ComponentT>(Action<ComponentT> action, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> selfAfter(()=> gameObject.forEach(action, includeInactiveComponents));
	#endregion iterating local components


	#region determining child components

	// method: return whether this game object has any of the specified type of child component, optionally including inactive components according to the given boolean //
	public bool anyChildren<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAnyChildren<ComponentT>(includeInactiveComponents);
	#endregion determining child components


	#region accessing child components

	// method: return this component's game object's first child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT firstChild<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstChild<ComponentT>(includeInactiveComponents);

	// method: return this component's game object's last child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT lastChild<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.lastChild<ComponentT>(includeInactiveComponents);

	// method: return a list of this given component's child components of the specified class, optionally including inactive components according to the given boolean //
	public List<ComponentT> children<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.children<ComponentT>(includeInactiveComponents);
	#endregion accessing child components


	#region accessing child or self components

	// method: return this component's first local or child component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT firstLocalOrChild<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstLocalOrChild<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's local and child components of the specified class, optionally including inactive components according to the given boolean //
	public ComponentT[] localAndChildren<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.localAndChildren<ComponentT>(includeInactiveComponents);
	
	public ComponentI[] localAndChildrenI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> gameObject.localAndChildrenI<ComponentI>(includeInactiveComponents);

	public HashSet<GameObject> localAndChildrenObjectsWithI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> gameObject.localAndChildrenObjectsWithI<ComponentI>(includeInactiveComponents);
	#endregion accessing child or self components


	#region accessing parent components

	// method: return this component's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT firstParent<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstParent<ComponentT>(includeInactiveComponents);

	// method: return a list of this component's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public List<ComponentT> parental<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.parental<ComponentT>(includeInactiveComponents);

	// method: return this component's game object's first parent component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT firstAncestor<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's parent components of the specified class, optionally including inactive components according to the given boolean //
	public ComponentT[] ancestral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.ancestral<ComponentT>(includeInactiveComponents);
	#endregion accessing parent components


	#region accessing parent or self components

	// method: return this component's first local or parent component of the specified class, optionally including inactive components according to the given boolean (null if none found) //
	public ComponentT firstLocalOrAncestor<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstLocalOrAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's local and parent components of the specified class, optionally including inactive components according to the given boolean //
	public ComponentT[] localAndAncestral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.localAndAncestral<ComponentT>(includeInactiveComponents);
	#endregion accessing parent or self components


	#region searching for self or parent based on comparison

	// method: return the first game object out of the game object for this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public GameObject selfOrAncestorObjectWith<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.selfOrAncestorObjectWith<ComponentT>(includeInactiveComponents);

	// method: return the transform of the first game object out of this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public Transform selfOrAncestorTransformWith<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.selfOrAncestorTransformWith<ComponentT>(includeInactiveComponents);
	#endregion searching for self or parent based on comparison
}