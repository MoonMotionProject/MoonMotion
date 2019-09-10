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
	#region coroutines

	// method: have this behaviour have Unity start a coroutine using the given enumerator, then return the started coroutine //
	public static new Coroutine startCoroutine(IEnumerator enumerator)
		=> automaticBehaviour.startCoroutine(enumerator);
	#endregion coroutines


	#region planning to execute functions\actions next frame

	public static new AutomaticBehaviour<SingletonBehaviourT> nextFrameExecute(Delegate function, params object[] parameters)
		=> automaticBehaviour.nextFrameExecute(function, parameters);
	public static new AutomaticBehaviour<SingletonBehaviourT> nextFrameExecute(Action action, params object[] parameters)
		=> automaticBehaviour.nextFrameExecute(action, parameters);
	#endregion planning to execute functions\actions next frame
}