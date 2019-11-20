using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Cached Components:
// • provides this behaviour with caching of its components via a dictionary and a method
// #auto #component #correspondence #lodespondence
public abstract class	AutoBehaviourLayerCachedComponents<AutoBehaviourT> :
					AutoBehaviourLayerAttributeDetection<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	// method: cachingly return the component of the specified class in the cached components for this game object, optionally adding the specified type of component if none is found //
	public ComponentT cache<ComponentT>(bool addComponentIfNoneFound = false) where ComponentT : Component
		=> gameObject.cache<ComponentT>(addComponentIfNoneFound);

	// method: cachingly return the corresponding rigidbody for this game object, optionally adding a rigidbody to this game object if none is found //
	public ComponentT cacheCorresponding<ComponentT>(bool addComponentIfNoneFound = false) where ComponentT : Component
		=> gameObject.cacheCorresponding<ComponentT>(addComponentIfNoneFound);

	// method: cachingly return the lodesponding rigidbody for this game object, optionally adding a rigidbody to this game object if none is found //
	public ComponentT cacheLodesponding<ComponentT>(bool addComponentIfNoneFound = false) where ComponentT : Component
		=> gameObject.cacheLodesponding<ComponentT>(addComponentIfNoneFound);

	// method: untrack the cached components for this game object, then return whether this game object actually had cached components //
	public bool tryToUncache()
		=> gameObject.tryToUncache();
}