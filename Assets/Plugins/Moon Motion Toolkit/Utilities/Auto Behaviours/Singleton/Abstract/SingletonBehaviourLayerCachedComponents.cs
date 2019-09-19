using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Cached Components:
// #auto
// • provides this singleton behaviour with static access to its auto behaviour's cached components layer
public abstract class	SingletonBehaviourLayerCachedComponents<SingletonBehaviourT> :
					SingletonBehaviourLayerAttributeDetection<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	// methods //


	// method: cachingly return the component of the specified class in the cached components, optionally adding the specified type of component if none is found //
	public static new ComponentT cache<ComponentT>(bool addComponentIfNoneFound = false) where ComponentT : Component
		=> autoBehaviour.cache<ComponentT>(addComponentIfNoneFound);

	// method: untrack the cached components for this game object, then return the cached component dictionary for this game object //
	public static new bool tryToUncache()
		=> autoBehaviour.tryToUncache();
}