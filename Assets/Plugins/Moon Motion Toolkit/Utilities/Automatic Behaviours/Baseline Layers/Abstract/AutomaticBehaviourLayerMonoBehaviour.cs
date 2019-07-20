using System;
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
	// methods for: coroutines //

	// method: have this mono behaviour have Unity start a coroutine using the given enumerator, then return the started coroutine //
	public Coroutine startCoroutine(IEnumerator enumerator)
		=> monoBehaviour.startCoroutine(enumerator);


	// methods for: planning to execute methods //

	// method: plan to execute the method on this mono behaviour with the given name after the given delay, then return this mono behaviour //
	public MonoBehaviour planToExecute(string methodName, float delay)
		=> monoBehaviour.planToExecute(methodName, delay);
}