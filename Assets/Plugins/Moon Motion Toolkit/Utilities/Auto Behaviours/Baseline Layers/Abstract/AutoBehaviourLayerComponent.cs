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
	public void destroyThisBehaviour(bool boolean = true)
		=> component.destroy(boolean);
	#endregion of this component
	
	#region of the other given component
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

	public bool hasAny<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAny<ComponentT>(includeInactiveComponents);

	public bool hasAny<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAny(function, includeInactiveComponents);

	public bool hasAnyI<ComponentI>
	(
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentI : class
		=> gameObject.hasAnyI<ComponentI>(includeInactiveComponents);
	
	public bool hasNo<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasNo<ComponentT>(includeInactiveComponents);

	public bool hasAnyComponentOtherThan(Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.hasAnyComponentOtherThan(component, includeInactiveComponents);

	public bool hasAnyOtherComponent(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.hasAnyOtherComponent(includeInactiveComponents);

	public bool hasAnyComponentExcept(Component component, Func<Component, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.hasAnyComponentExcept(component, function, includeInactiveComponents);

	public bool hasAnyOtherComponent(Func<Component, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> component.hasAnyOtherComponent(function, includeInactiveComponents);

	public bool hasAnyAutoBehaviours(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.hasAnyAutoBehaviours(includeInactiveComponents);

	public bool hasAnyOtherAutoBehaviours(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> self.hasAnyOtherAutoBehaviours<AutoBehaviourT>(includeInactiveComponents);
	#endregion determining local components


	#region accessing local components
	
	public ComponentT first<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.first<ComponentT>(includeInactiveComponents);
	public ComponentI firstI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> gameObject.firstI<ComponentI>(includeInactiveComponents);

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


	#region picking upon local components

	public TResult pickUponFirstIfAny<ComponentT, TResult>(Func<ComponentT, TResult> function, Func<TResult> fallbackfunction) where ComponentT : Component
		=> gameObject.pickUponFirstIfAny(function, fallbackfunction);
	#endregion picking upon local components


	#region determining descendant components

	// method: return whether this game object has any of the specified type of descendant component, optionally including inactive components according to the given boolean //
	public bool hasAnyDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAnyDescendant<ComponentT>(includeInactiveComponents);
	#endregion determining descendant components


	#region accessing descendant components
	
	public ComponentT firstDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstDescendant<ComponentT>(includeInactiveComponents);
	
	public ComponentT lastDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.lastDescendant<ComponentT>(includeInactiveComponents);
	
	public List<ComponentT> descendants<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.descendants<ComponentT>(includeInactiveComponents);
	#endregion accessing descendant components


	#region determining local or descendant components
	
	public bool hasAnyLocalOrDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAnyLocalOrDescendant<ComponentT>(includeInactiveComponents);
	#endregion determining local or descendant components


	#region accessing local or descendant components
	
	public ComponentT firstLocalOrDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstLocalOrDescendant<ComponentT>(includeInactiveComponents);
	
	public ComponentT[] localAndDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.localAndDescendant<ComponentT>(includeInactiveComponents);
	
	public ComponentI[] localAndDescendantI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> gameObject.localAndDescendantI<ComponentI>(includeInactiveComponents);

	public HashSet<GameObject> localAndDescendantObjectsWithI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> gameObject.localAndDescendantObjectsWithI<ComponentI>(includeInactiveComponents);
	#endregion accessing local or descendant components


	#region accessing parent components

	// method: return this component's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public ComponentT firstParent<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstParent<ComponentT>(includeInactiveComponents);

	// method: return a list of this component's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public List<ComponentT> parental<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.parental<ComponentT>(includeInactiveComponents);
	#endregion accessing parent components


	#region accessing ancestral components
	
	public ComponentT firstAncestor<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstAncestor<ComponentT>(includeInactiveComponents);
	
	public ComponentT[] ancestral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.ancestral<ComponentT>(includeInactiveComponents);
	#endregion accessing ancestral components


	#region determining ancestral components
	
	public bool hasAnyAncestral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAnyAncestral<ComponentT>(includeInactiveComponents);
	#endregion determining ancestral components


	#region accessing local or ancestral components

	// method: return this component's first local or parent component of the specified class, optionally including inactive components according to the given boolean (null if none found) //
	public ComponentT firstLocalOrAncestor<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstLocalOrAncestor<ComponentT>(includeInactiveComponents);

	// method: return an array of this component's local and parent components of the specified class, optionally including inactive components according to the given boolean //
	public ComponentT[] localAndAncestral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.localAndAncestral<ComponentT>(includeInactiveComponents);
	#endregion accessing local or ancestral components


	#region searching for self or ancestor based on comparison

	// method: return the first game object out of the game object for this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public GameObject firstSelfOrAncestorObjectWith<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstSelfOrAncestorObjectWith<ComponentT>(includeInactiveComponents);

	// method: return the transform of the first game object out of this component and its parent game objects (searching upward) to have a component of the given type (null if none found), optionally including inactive components according to the given boolean //
	public Transform firstSelfOrAncestorTransformWith<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstSelfOrAncestorTransformWith<ComponentT>(includeInactiveComponents);
	#endregion searching for self or ancestor based on comparison
}