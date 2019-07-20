using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Mono Behaviour:
// #auto
// • provides this singleton behaviour with static access to its automatic behaviour's mono behaviour layer
public abstract class	SingletonBehaviourLayerMonoBehaviour<SingletonBehaviourT> :
					SingletonBehaviourLayerBehaviour<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	// methods for: coroutines //

	// method: have this behaviour have Unity start a coroutine using the given enumerator, then return the started coroutine //
	public static new Coroutine startCoroutine(IEnumerator enumerator)
		=> automaticBehaviour.startCoroutine(enumerator);
}