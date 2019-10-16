using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Mono Behaviour:
// #auto #execution
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
	private AutoBehaviourT planToExecuteAfter_(float delay, Delegate function, params object[] parameters)
		=> planToExecuteAfter(delay, function, parameters);
	public AutoBehaviourT planToExecuteAfter(float delay, Action action, params object[] parameters)
		=> planToExecuteAfter_(delay, action, parameters);
	#endregion planning to execute methods


	#region planning to execute functions\actions at the end of the current frame

	// methods: plan to execute the given function with the given parameters at the end of the current frame, then return this (derived auto) behaviour //
	public AutoBehaviourT atEndOfFrameExecute(Delegate function, params object[] parameters)
		=> selfAfter(()=> startCoroutine(atEndOfFrameExecute_Coroutine(function, parameters)));
	private IEnumerator atEndOfFrameExecute_Coroutine(Delegate function, params object[] parameters)
	{
		yield return new WaitForEndOfFrame();      // wait until the end of the current frame
		function.execute(parameters);      // then, execute the given function with the given parameters
	}
	private AutoBehaviourT atEndOfFrameExecute_(Delegate function, params object[] parameters)
		=> atEndOfFrameExecute(function, parameters);
	public AutoBehaviourT atEndOfFrameExecute(Action action, params object[] parameters)
		=> atEndOfFrameExecute_(action, parameters);
	#endregion planning to execute functions\actions at the end of the current frame
}