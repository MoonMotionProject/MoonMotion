using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Mono Behaviour:
// #auto #mono #coroutines #execution
// • provides this singleton behaviour with static access to its auto behaviour's mono behaviour layer
public abstract class	SingletonBehaviourLayerMonoBehaviour<SingletonBehaviourT> :
					SingletonBehaviourLayerBehaviour<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region coroutines
	
	public static new Coroutine startCoroutine(IEnumerator enumerator)
		=> autoBehaviour.startCoroutine(enumerator);
	
	public static new AutoBehaviour<SingletonBehaviourT> stopCoroutine(Coroutine coroutine)
		=> autoBehaviour.stopCoroutine(coroutine);
	
	public static new AutoBehaviour<SingletonBehaviourT> stopAllCoroutines()
		=> autoBehaviour.stopAllCoroutines();
	#endregion coroutines


	#region planning to execute methods
	
	public static new AutoBehaviour<SingletonBehaviourT> planToExecuteAfter(float delay, string methodName)
		=> autoBehaviour.planToExecuteAfter(delay, methodName);
	
	public static new Coroutine planToExecuteAfter(float delay, Delegate function, params object[] parameters)
		=> autoBehaviour.planToExecuteAfter(delay, function, parameters);
	public static new Coroutine planToExecuteAfter(float delay, Action action, params object[] parameters)
		=> autoBehaviour.planToExecuteAfter(delay, action, parameters);
	#endregion planning to execute methods


	#region planning to execute functions\actions at next check
	
	public static new Coroutine atNextCheckExecute(Delegate function, params object[] parameters)
		=> autoBehaviour.atNextCheckExecute(function, parameters);
	public static new Coroutine atNextCheckExecute(Action action, params object[] parameters)
		=> autoBehaviour.atNextCheckExecute(action, parameters);
	#endregion planning to execute functions\actions at next check


	#region planning to execute functions\actions now and at every check
	
	public static new Coroutine nowAndAtEveryCheckExecute(Delegate function, params object[] parameters)
		=> autoBehaviour.nowAndAtEveryCheckExecute(function, parameters);
	public static new Coroutine nowAndAtEveryCheckExecute(Action action, params object[] parameters)
		=> autoBehaviour.nowAndAtEveryCheckExecute(action, parameters);
	#endregion planning to execute functions\actions now and at every check


	#region planning to execute functions\actions at the end of the current frame

	public static new Coroutine atEndOfFrameExecute(Delegate function, params object[] parameters)
		=> autoBehaviour.atEndOfFrameExecute(function, parameters);
	public static new Coroutine atEndOfFrameExecute(Action action, params object[] parameters)
		=> autoBehaviour.atEndOfFrameExecute(action, parameters);
	#endregion planning to execute functions\actions at the end of the current frame
}