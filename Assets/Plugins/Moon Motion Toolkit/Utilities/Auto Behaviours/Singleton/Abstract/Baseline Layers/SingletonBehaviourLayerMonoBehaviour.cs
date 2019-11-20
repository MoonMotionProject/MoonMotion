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
	
	public static new Coroutine beginCoroutine(IEnumerator enumerator)
		=> autoBehaviour.beginCoroutine(enumerator);
	
	public static new Coroutine beginCoroutine(Coroute coroute, Delegate function, params object[] parameters)
		=> autoBehaviour.beginCoroutine(coroute, function, parameters);
	public static new Coroutine beginCoroutine(Coroute coroute, Action action)
		=> autoBehaviour.beginCoroutine(coroute, action);
	
	public static new Coroutine beginCoroutineWithInterval(float interval, Coroute coroute, Delegate function, params object[] parameters)
		=> autoBehaviour.beginCoroutineWithInterval(interval, coroute, function, parameters);
	public static new Coroutine beginCoroutineWithInterval(float interval, Coroute coroute, Action action)
		=> autoBehaviour.beginCoroutineWithInterval(interval, coroute, action);
	
	public static new Coroutine beginRepeatingCoroutine(Delegate function, bool beginNowVersusAtNextCheck = Default.beginningNowVersusAtNextCycle, params object[] parameters)
		=> autoBehaviour.beginRepeatingCoroutine(function, beginNowVersusAtNextCheck, parameters);
	public static new Coroutine beginRepeatingCoroutine(Action action, bool beginNowVersusAtNextCheck = Default.beginningNowVersusAtNextCycle)
		=> autoBehaviour.beginRepeatingCoroutine(action, beginNowVersusAtNextCheck);
	
	public static new Coroutine beginCoroutineRepeatingEvery(float interval, Delegate function, bool beginNowVersusAfterFirstInterval = Default.beginningNowVersusAtNextCycle, params object[] parameters)
		=> autoBehaviour.beginCoroutineRepeatingEvery(interval, function, beginNowVersusAfterFirstInterval, parameters);
	public static new Coroutine beginCoroutineRepeatingEvery(float interval, Action action, bool beginNowVersusAfterFirstInterval = Default.beginningNowVersusAtNextCycle)
		=> autoBehaviour.beginCoroutineRepeatingEvery(interval, action, beginNowVersusAfterFirstInterval);
	
	public static new AutoBehaviour<SingletonBehaviourT> stopCoroutine(Coroutine coroutine)
		=> autoBehaviour.stopCoroutine(coroutine);
	
	public static new AutoBehaviour<SingletonBehaviourT> stopAllCoroutines()
		=> autoBehaviour.stopAllCoroutines();
	#endregion coroutines


	#region planning to execute methods after a delay
	
	public static new AutoBehaviour<SingletonBehaviourT> executeAfter(float delay, string methodName)
		=> autoBehaviour.executeAfter(delay, methodName);
	
	public static new Coroutine executeAfter(float delay, Delegate function, params object[] parameters)
		=> autoBehaviour.executeAfter(delay, function, parameters);
	public static new Coroutine executeAfter(float delay, Action action, params object[] parameters)
		=> autoBehaviour.executeAfter(delay, action, parameters);
	#endregion planning to execute methods after a delay


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


	#region planning to execute functions\actions at next check and every check after
	
	public static new Coroutine atNextCheckAndEveryCheckAfterExecute(Delegate function, params object[] parameters)
		=> autoBehaviour.atNextCheckAndEveryCheckAfterExecute(function, parameters);
	public static new Coroutine atNextCheckAndEveryCheckAfterExecute(Action action, params object[] parameters)
		=> autoBehaviour.atNextCheckAndEveryCheckAfterExecute(action, parameters);
	#endregion planning to execute functions\actions at next check and every check after


	#region planning to execute functions\actions at the end of the current frame

	public static new Coroutine atEndOfFrameExecute(Delegate function, params object[] parameters)
		=> autoBehaviour.atEndOfFrameExecute(function, parameters);
	public static new Coroutine atEndOfFrameExecute(Action action, params object[] parameters)
		=> autoBehaviour.atEndOfFrameExecute(action, parameters);
	#endregion planning to execute functions\actions at the end of the current frame


	#region planning to execute functions\actions now and on interval
	
	public static new Coroutine executeNowAndEvery(float interval, Delegate function, params object[] parameters)
		=> autoBehaviour.executeNowAndEvery(interval, function, parameters);
	public static new Coroutine executeNowAndEvery(float interval, Action action, params object[] parameters)
		=> autoBehaviour.executeNowAndEvery(interval, action, parameters);
	#endregion planning to execute functions\actions now and on interval


	#region planning to execute functions\actions after every interval
		
	public static new Coroutine executeAfterEvery(float interval, Delegate function, params object[] parameters)
		=> autoBehaviour.executeAfterEvery(interval, function, parameters);
	public static new Coroutine executeAfterEvery(float interval, Action action, params object[] parameters)
		=> autoBehaviour.executeAfterEvery(interval, action, parameters);
	#endregion planning to execute functions\actions after every interval
}