﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Mono Behaviour:
// #auto
// • provides this behaviour with direct access to its extension methods for being a mono behaviour
public abstract class	AutomaticBehaviourLayerMonoBehaviour<AutomaticBehaviourT> :
					AutomaticBehaviourLayerBehaviour<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	#region coroutines

	// method: have this mono behaviour have Unity start a coroutine using the given enumerator, then return the started coroutine //
	public Coroutine startCoroutine(IEnumerator enumerator)
		=> monoBehaviour.startCoroutine(enumerator);
	#endregion coroutines


	#region planning to execute methods

	// method: plan to execute the method on this mono behaviour with the given name after the given delay, then return this (derived automatic) behaviour //
	public AutomaticBehaviourT planToExecute(string methodName, float delay)
		=> selfAfter(()=> monoBehaviour.planToExecute(methodName, delay));
	#endregion planning to execute methods


	#region planning to execute functions\actions next frame

	public AutomaticBehaviourT nextFrameExecute(Delegate function, params object[] parameters)
		=> selfAfter(()=> startCoroutine(nextFrameExecute_Coroutine(function, parameters)));
	private IEnumerator nextFrameExecute_Coroutine(Delegate function, params object[] parameters)
	{
		yield return null;      // skip this frame
		function.execute(parameters);      // then (by the next frame) execute the given function
	}
	public AutomaticBehaviourT nextFrameExecute_(Delegate function, params object[] parameters)
		=> nextFrameExecute(function, parameters);
	public AutomaticBehaviourT nextFrameExecute(Action action, params object[] parameters)
		=> nextFrameExecute_(action, parameters);
	#endregion planning to execute functions\actions next frame
}