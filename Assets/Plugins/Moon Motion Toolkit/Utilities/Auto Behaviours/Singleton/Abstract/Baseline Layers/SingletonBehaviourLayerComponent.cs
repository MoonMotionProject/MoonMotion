using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Component:
// #auto #component #family
// • provides this singleton behaviour with static access to its auto behaviour's component layer
public abstract class	SingletonBehaviourLayerComponent<SingletonBehaviourT> :
					SingletonBehaviourLayerTransform<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region destruction

	#region of this component
	public static new void destroyThisBehaviour(bool boolean = true)
		=> autoBehaviour.destroyThisBehaviour(boolean);
	#endregion of this component
	
	#region of the other given component
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

	public static new bool requires_ViaAdditionalReflection<ComponentTPotentiallyRequired>(bool considerInheritedRequireComponents = true) where ComponentTPotentiallyRequired : Component
		=> autoBehaviour.requires_ViaAdditionalReflection<ComponentTPotentiallyRequired>(considerInheritedRequireComponents);

	public static new bool isRequired_ViaAdditionalReflection(bool considerInheritedRequireComponents = true)
		=> autoBehaviour.isRequired_ViaAdditionalReflection(considerInheritedRequireComponents);
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

	public static new bool hasAny<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.hasAny<ComponentT>(includeInactiveComponents);

	public static new bool hasAny<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.hasAny(function, includeInactiveComponents);

	public static new bool hasAnyI<ComponentI>
	(
		bool includeInactiveComponents = Default.inclusionOfInactiveComponents
	) where ComponentI : class
		=> autoBehaviour.hasAnyI<ComponentI>(includeInactiveComponents);

	public static new bool hasNo<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.hasNo<ComponentT>(includeInactiveComponents);

	public static new bool hasAnyComponentOtherThan(Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.hasAnyComponentOtherThan(component, includeInactiveComponents);

	public static new bool hasAnyOtherComponent(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.hasAnyOtherComponent(includeInactiveComponents);

	public static new bool hasAnyComponentExcept(Component component, Func<Component, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.hasAnyComponentExcept(component, function, includeInactiveComponents);

	public static new bool hasAnyOtherComponent(Func<Component, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.hasAnyOtherComponent(function, includeInactiveComponents);

	public static new bool hasAnyAutoBehaviours(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.hasAnyAutoBehaviours(includeInactiveComponents);

	public static new bool hasAnyOtherAutoBehaviours(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.hasAnyOtherAutoBehaviours(includeInactiveComponents);
	#endregion determining local components


	#region accessing local components
	
	public static new ComponentT first<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.first<ComponentT>(includeInactiveComponents);
	public static new ComponentI firstI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> autoBehaviour.firstI<ComponentI>(includeInactiveComponents);

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


	#region picking upon local components

	public static new TResult pickUponFirstIfAny<ComponentT, TResult>(Func<ComponentT, TResult> function, Func<TResult> fallbackfunction) where ComponentT : Component
		=> autoBehaviour.pickUponFirstIfAny(function, fallbackfunction);
	#endregion picking upon local components
}