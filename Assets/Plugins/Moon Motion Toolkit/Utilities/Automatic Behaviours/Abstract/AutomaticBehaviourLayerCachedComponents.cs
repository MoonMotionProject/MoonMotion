using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Cached Components:
// #auto
// • provides this behaviour with caching of its components via a dictionary and a method
public abstract class	AutomaticBehaviourLayerCachedComponents<AutomaticBehaviourT> :
					AutomaticBehaviourLayerStaticShortcuts<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	// variables //

	
	// a dictionary of cached components on this object keyed by their type //
	private Dictionary<Type, Component> cachedComponents = new Dictionary<Type, Component>();




	// methods //

	
	// method: return/cache the component of the specified type in the cached components //
	public TComponent cachedComponent<TComponent>() where TComponent : Component
	{
		return (TComponent) cachedComponents.cache(typeof(TComponent), GetComponent<TComponent>());
	}
}