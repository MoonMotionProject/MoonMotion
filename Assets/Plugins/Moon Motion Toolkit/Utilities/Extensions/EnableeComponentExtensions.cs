using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enablee Component Extensions: provides extension methods for handling enablee components (components which have enablement state)
// #dynamics
public static class EnableeComponentExtensions
{
	#region enablement of these given enablee components

	// method: set the enablement of these given enablee components to the given boolean, then return a list of these given enablee components //
	public static List<ComponentT> setEnablementsTo<ComponentT>(this IEnumerable<ComponentT> enableeComponents, bool enablement) where ComponentT : Component
		=> enableeComponents.forEachManifested(enableeComponent => enableeComponent.setEnablementTo(enablement));

	// method: enable these given enablee components, then return a list of these given enablee components //
	public static List<ComponentT> enableEach<ComponentT>(this IEnumerable<ComponentT> enableeComponents) where ComponentT : Component
		=> enableeComponents.forEachManifested(enableeComponent => enableeComponent.enable());

	// method: disable these given enablee components, then return a list of these given enablee components //
	public static List<ComponentT> disableEach<ComponentT>(this IEnumerable<ComponentT> enableeComponents) where ComponentT : Component
		=> enableeComponents.forEachManifested(enableeComponent => enableeComponent.disable());

	// method: toggle the enablement of these given enablee components using the given toggling, then return a list of these given enablee components //
	public static List<ComponentT> toggleEnablementsBy<ComponentT>(this IEnumerable<ComponentT> enableeComponents, Toggling toggling) where ComponentT : Component
		=> enableeComponents.forEachManifested(enableeComponent => enableeComponent.toggleEnablementBy(toggling));
	#endregion enablement of these given enablee components


	#region enablement of this given enablee component

	private static bool enablementOf(dynamic dynamo)
		=> dynamo.enabled;

	// method: return the enablement of this given enablee component //
	public static bool enablement(this Component enableeComponent)
		=> enablementOf(enableeComponent);

	private static void setEnablementOf(dynamic dynamo, bool enablement)
		=> dynamo.enabled = enablement;

	// method: set the enablement of this given enablee component to the given boolean, then return this given enablee component //
	public static ComponentT setEnablementTo<ComponentT>(this ComponentT enableeComponent, bool enablement) where ComponentT : Component
		=> enableeComponent.after(()=>
			setEnablementOf(enableeComponent, enablement));

	// method: enable this given enablee component, then return it //
	public static ComponentT enable<ComponentT>(this ComponentT enableeComponent) where ComponentT : Component
		=> enableeComponent.setEnablementTo(true);

	// method: disable this given enablee component, then return it //
	public static ComponentT disable<ComponentT>(this ComponentT enableeComponent) where ComponentT : Component
		=> enableeComponent.setEnablementTo(false);

	// method: toggle the enablement of this given enablee component using the given toggling, then return this given enablee component //
	public static ComponentT toggleEnablementBy<ComponentT>(this ComponentT enableeComponent, Toggling toggling) where ComponentT : Component
		=> enableeComponent.setEnablementTo(enablementOf(enableeComponent).toggledBy(toggling));
	#endregion enablement of this given enablee component
}
