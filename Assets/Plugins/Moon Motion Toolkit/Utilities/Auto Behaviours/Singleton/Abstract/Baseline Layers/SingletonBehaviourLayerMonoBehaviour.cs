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
	
	public static new Coroutine startCoroutine(Coroute coroute, Delegate function, params object[] parameters)
		=> autoBehaviour.startCoroutine(coroute, function, parameters);
	public static new Coroutine startCoroutine(Coroute coroute, Action action)
		=> autoBehaviour.startCoroutine(coroute, action);
	
	public static new Coroutine startRepeatingCoroutine(Delegate function, bool startNowVersusAtNextCheck = Default.repeatingCoroutineStartingNowVersusAtNextCheck, params object[] parameters)
		=> autoBehaviour.startRepeatingCoroutine(function, startNowVersusAtNextCheck, parameters);
	public static new Coroutine startRepeatingCoroutine(Action action, bool startNowVersusAtNextCheck = Default.repeatingCoroutineStartingNowVersusAtNextCheck)
		=> autoBehaviour.startRepeatingCoroutine(action, startNowVersusAtNextCheck);
	
	public static new AutoBehaviour<SingletonBehaviourT> stopCoroutine(Coroutine coroutine)
		=> autoBehaviour.stopCoroutine(coroutine);
	
	public static new AutoBehaviour<SingletonBehaviourT> stopAllCoroutines()
		=> autoBehaviour.stopAllCoroutines();
	#endregion coroutines


	#region planning to execute methods after a delay
	
	public static new AutoBehaviour<SingletonBehaviourT> executeAtNextCheck_IfInEditor(Action<SingletonBehaviourT> action, bool silenceNullBehaviourError = Default.errorSilencing)
		=> autoBehaviour.executeAtNextCheck_IfInEditor(action, silenceNullBehaviourError);
	
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
}