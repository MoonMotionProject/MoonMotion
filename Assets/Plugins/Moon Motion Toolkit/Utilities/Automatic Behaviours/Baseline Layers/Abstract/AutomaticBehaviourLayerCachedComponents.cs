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
	// methods //


	// method: cachingly return the component of the specified class in the cached components for this game object, optionally adding the specified type of component if none is found //
	public ComponentT cache<ComponentT>(bool addComponentIfNoneFound = false) where ComponentT : Component
		=> gameObject.cache<ComponentT>(addComponentIfNoneFound);

	// method: untrack the cached components for this game object, then return the cached component dictionary for this game object //
	public bool uncache()
		=> gameObject.uncache();
}