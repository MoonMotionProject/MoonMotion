using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Mono Behaviour:
// #auto
// • provides this behaviour with direct access to its extension methods for being a mono behaviour
public abstract class	AutoBehaviourLayerMonoBehaviour<AutoBehaviourT> :
					AutoBehaviourLayerBehaviour<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region coroutines

	// method: have this mono behaviour have Unity start a coroutine using the given enumerator, then return the started coroutine //
	public Coroutine startCoroutine(IEnumerator enumerator)
		=> monoBehaviour.startCoroutine(enumerator);
	#endregion coroutines


	#region planning to execute methods

	// method: plan to execute the method on this mono behaviour with the given name after the given delay, then return this (derived auto) behaviour //
	public AutoBehaviourT planToExecuteAfter(float delay, string methodName)
		=> selfAfter(()=> monoBehaviour.planToExecuteAfter(delay, methodName));

	// methods: plan to execute the given function with the given parameters after the given delay, then return this (derived auto) behaviour //
	public AutoBehaviourT planToExecuteAfter(float delay, Delegate function, params object[] parameters)
		=> selfAfter(()=> startCoroutine(planToExecuteAfter_Coroutine(delay, function, parameters)));
	private IEnumerator planToExecuteAfter_Coroutine(float delay, Delegate function, params object[] parameters)
	{
		yield return new WaitForSeconds(delay);      // wait the delay
		function.execute(parameters);      // then (after the delay) execute the given function with the given parameters
	}
	public AutoBehaviourT planToExecuteAfter_(float delay, Delegate function, params object[] parameters)
		=> planToExecuteAfter(delay, function, parameters);
	public AutoBehaviourT planToExecuteAfter(float delay, Action action, params object[] parameters)
		=> planToExecuteAfter_(delay, action, parameters);
	#endregion planning to execute methods


	#region planning to execute functions\actions next frame

	// methods: plan to execute the given function with the given parameters sometime next frame, then return this (derived auto) behaviour //
	public AutoBehaviourT nextFrameExecute(Delegate function, params object[] parameters)
		=> selfAfter(()=> startCoroutine(nextFrameExecute_Coroutine(function, parameters)));
	private IEnumerator nextFrameExecute_Coroutine(Delegate function, params object[] parameters)
	{
		yield return null;      // skip this frame
		function.execute(parameters);      // then (by the next frame) execute the given function with the given parameters
	}
	public AutoBehaviourT nextFrameExecute_(Delegate function, params object[] parameters)
		=> nextFrameExecute(function, parameters);
	public AutoBehaviourT nextFrameExecute(Action action, params object[] parameters)
		=> nextFrameExecute_(action, parameters);
	#endregion planning to execute functions\actions next frame
}