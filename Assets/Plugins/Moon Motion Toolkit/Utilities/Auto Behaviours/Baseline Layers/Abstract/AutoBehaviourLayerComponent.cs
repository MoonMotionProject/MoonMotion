using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Component:
// #auto #component #family
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


	#region inspector

	// method: hide this component in the inspector, then return this behaviour //
	public AutoBehaviourT hideInInspector()
		=> selfAfter(()=> component.hideInInspector());

	// method: hide this component in the inspector, then return this behaviour //
	public AutoBehaviourT unhideInInspector()
		=> selfAfter(()=> component.unhideInInspector());
	#endregion inspector


	#region requirement via RequireComponent

	public bool requires_ViaAdditionalReflection<ComponentTPotentiallyRequired>(bool considerInheritedRequireComponents = true) where ComponentTPotentiallyRequired : Component
		=> component.requires_ViaAdditionalReflection<ComponentTPotentiallyRequired>(considerInheritedRequireComponents);
	
	public bool isRequired_ViaAdditionalReflection(bool considerInheritedRequireComponents = true)
		=> self.isRequired_ViaAdditionalReflection<AutoBehaviourT>(considerInheritedRequireComponents);
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
}