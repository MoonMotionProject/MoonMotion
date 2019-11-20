using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Cached Components:
// • provides this singleton behaviour with static access to its auto behaviour's cached components layer
// #auto #component #correspondence #lodespondence
public abstract class	SingletonBehaviourLayerCachedComponents<SingletonBehaviourT> :
					SingletonBehaviourLayerAttributeDetection<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	public static new ComponentT cache<ComponentT>(bool addComponentIfNoneFound = false)
		where ComponentT : Component
		=> autoBehaviour.cache<ComponentT>(addComponentIfNoneFound);
	
	public static new ComponentT cacheCorresponding<ComponentT>(bool addComponentIfNoneFound = false)
		where ComponentT : Component
		=> autoBehaviour.cacheCorresponding<ComponentT>(addComponentIfNoneFound);
	
	public static new ComponentT cacheLodesponding<ComponentT>(bool addComponentIfNoneFound = false)
		where ComponentT : Component
		=> autoBehaviour.cacheLodesponding<ComponentT>(addComponentIfNoneFound);
	
	public static new bool tryToUncache()
		=> autoBehaviour.tryToUncache();
}