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


	#region planning to execute methods

	// method: plan to execute the method on this mono behaviour with the given name after the given delay, then return this (derived automatic) behaviour //
	public static new AutomaticBehaviour<SingletonBehaviourT> planToExecuteAfter(float delay, string methodName)
		=> automaticBehaviour.planToExecuteAfter(delay, methodName);

	// methods: plan to execute the given function with the given parameters after the given delay, then return this (derived automatic) behaviour //
	public static new AutomaticBehaviour<SingletonBehaviourT> planToExecuteAfter(float delay, Delegate function, params object[] parameters)
		=> automaticBehaviour.planToExecuteAfter(delay, function, parameters);
	public static new AutomaticBehaviour<SingletonBehaviourT> planToExecuteAfter(float delay, Action action, params object[] parameters)
		=> automaticBehaviour.planToExecuteAfter(delay, action, parameters);
	#endregion planning to execute methods


	#region planning to execute functions\actions next frame

	public static new AutomaticBehaviour<SingletonBehaviourT> nextFrameExecute(Delegate function, params object[] parameters)
		=> automaticBehaviour.nextFrameExecute(function, parameters);
	public static new AutomaticBehaviour<SingletonBehaviourT> nextFrameExecute(Action action, params object[] parameters)
		=> automaticBehaviour.nextFrameExecute(action, parameters);
	#endregion planning to execute functions\actions next frame
}