using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Mono Behaviour:
// #auto #mono #coroutines #execution
// • provides this behaviour with direct access to its extension methods for being a mono behaviour
public abstract class	AutoBehaviourLayerMonoBehaviour<AutoBehaviourT> :
					AutoBehaviourLayerBehaviour<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region starting and stopping coroutines

	// method: have this mono behaviour have Unity start a coroutine using the given enumerator, then return the started coroutine //
	public Coroutine startCoroutine(IEnumerator enumerator)
		=> monoBehaviour.startCoroutine(enumerator);
	
	// methods: have this mono behaviour have Unity start a coroutine using the given function executing the given parameters and following the given coroute, then return the started coroutine //
	public Coroutine startCoroutine(Coroute coroute, Delegate function, params object[] parameters)
	{
		switch (coroute)
		{
			case Coroute.atNextCheck:
				return atNextCheckExecute(function, parameters);
			case Coroute.nowAndAtEveryCheck:
				return nowAndAtEveryCheckExecute(function, parameters);
			case Coroute.atNextCheckAndEveryCheckAfter:
				return atNextCheckAndEveryCheckAfterExecute(function, parameters);
			case Coroute.atEndOfFrame:
				return atEndOfFrameExecute(function, parameters);
			default:
				return startCoroutine(Default.coroute, function, parameters).returnWithError("the Auto Behaviour Layer Mono Behaviour on "+self+" had startCoroutine called with an unrecognized coroute given, so default coroute chosen as fallback");
		}
	}
	private Coroutine startCoroutine_(Coroute coroute, Delegate function, params object[] parameters)
		=> startCoroutine(coroute, function, parameters);
	public Coroutine startCoroutine(Coroute coroute, Action action)
		=> startCoroutine_(coroute, action);
	
	// methods: have this mono behaviour have Unity start a repeating coroutine using the given function executing the given parameters, starting now versus at next check according to the given boolean, then return the started coroutine //
	public Coroutine startRepeatingCoroutine(Delegate function, bool startNowVersusAtNextCheck = Default.repeatingCoroutineStartingNowVersusAtNextCheck, params object[] parameters)
		=>	startCoroutine
			(
				startNowVersusAtNextCheck ?
					Coroute.nowAndAtEveryCheck :
					Coroute.atNextCheckAndEveryCheckAfter,
				function,
				parameters
			);
	private Coroutine startRepeatingCoroutine_(Delegate function, bool startNowVersusAtNextCheck = Default.repeatingCoroutineStartingNowVersusAtNextCheck, params object[] parameters)
		=> startRepeatingCoroutine(function, startNowVersusAtNextCheck, parameters);
	public Coroutine startRepeatingCoroutine(Action action, bool startNowVersusAtNextCheck = Default.repeatingCoroutineStartingNowVersusAtNextCheck)
		=> startRepeatingCoroutine_(action, startNowVersusAtNextCheck);

	// method: stop this mono behaviour's given coroutine, then return this (derived auto) behaviour //
	public AutoBehaviourT stopCoroutine(Coroutine coroutine)
		=> selfAfter(()=> StopCoroutine(coroutine));

	// method: stop all of this mono behaviour's coroutines, then return this (derived auto) behaviour //
	public AutoBehaviourT stopAllCoroutines()
		=> selfAfter(()=> StopAllCoroutines());
	#endregion starting and stopping coroutines


	#region planning to execute functions after a delay
	
	// method: plan to execute the given action upon this (derived auto) behaviour at the next editor check (if this mono behaviour is still yull), then return this (derived auto) behaviour //
	public AutoBehaviourT executeAtNextCheck_IfInEditor(Action<AutoBehaviourT> action, bool silenceNullBehaviourError = Default.errorSilencing)
		=> selfAfter(()=> Execute.atNextCheckFor_IfInEditor(self, action, silenceNullBehaviourError));

	// method: plan to execute the method on this mono behaviour with the given name after the given delay, then return this (derived auto) behaviour //
	public AutoBehaviourT executeAfter(float delay, string methodName)
		=> selfAfter(()=> monoBehaviour.executeAfter(delay, methodName));

	// methods: plan to execute the given function with the given parameters after the given delay, then return the new coroutine that will do so //
	public Coroutine executeAfter(float delay, Delegate function, params object[] parameters)
		=> startCoroutine(executeAfter_Coroutine(delay, function, parameters));
	private IEnumerator executeAfter_Coroutine(float delay, Delegate function, params object[] parameters)
	{
		if (delay.isNonzero())
		{
			yield return Wait.delay(delay);
		}
		
		function.execute(parameters);
	}
	private Coroutine executeAfter_(float delay, Delegate function, params object[] parameters)
		=> executeAfter(delay, function, parameters);
	public Coroutine executeAfter(float delay, Action action, params object[] parameters)
		=> executeAfter_(delay, action, parameters);
	#endregion planning to execute functions after a delay


	#region planning to execute functions\actions at next check

	// methods: plan to execute the given function with the given parameters at the next coroutine check, then return the new coroutine that will do so //
	public Coroutine atNextCheckExecute(Delegate function, params object[] parameters)
		=> startCoroutine(atNextCheckExecute_Coroutine(function, parameters));
	private IEnumerator atNextCheckExecute_Coroutine(Delegate function, params object[] parameters)
	{
		yield return Wait.untilNextCheck;
		function.execute(parameters);
	}
	private Coroutine atNextCheckExecute_(Delegate function, params object[] parameters)
		=> atNextCheckExecute(function, parameters);
	public Coroutine atNextCheckExecute(Action action, params object[] parameters)
		=> atNextCheckExecute_(action, parameters);
	#endregion planning to execute functions\actions at next check


	#region planning to execute functions\actions now and at every check

	// methods: plan to execute the given function with the given parameters at every coroutine check, then return the new coroutine that will do so //
	public Coroutine nowAndAtEveryCheckExecute(Delegate function, params object[] parameters)
		=> startCoroutine(nowAndAtEveryCheckExecute_Coroutine(function, parameters));
	private IEnumerator nowAndAtEveryCheckExecute_Coroutine(Delegate function, params object[] parameters)
	{
		while (true)
		{
			function.execute(parameters);
			yield return Wait.untilNextCheck;
		}
	}
	private Coroutine nowAndAtEveryCheckExecute_(Delegate function, params object[] parameters)
		=> nowAndAtEveryCheckExecute(function, parameters);
	public Coroutine nowAndAtEveryCheckExecute(Action action, params object[] parameters)
		=> nowAndAtEveryCheckExecute_(action, parameters);
	#endregion planning to execute functions\actions now and at every check


	#region planning to execute functions\actions at next check and every check after

	// methods: plan to execute the given function with the given parameters at every coroutine check, then return the new coroutine that will do so //
	public Coroutine atNextCheckAndEveryCheckAfterExecute(Delegate function, params object[] parameters)
		=> startCoroutine(atNextCheckAndEveryCheckAfterExecute_Coroutine(function, parameters));
	private IEnumerator atNextCheckAndEveryCheckAfterExecute_Coroutine(Delegate function, params object[] parameters)
	{
		yield return atNextCheckExecute_Coroutine(function, parameters);
		yield return nowAndAtEveryCheckExecute_Coroutine(function, parameters);
	}
	private Coroutine atNextCheckAndEveryCheckAfterExecute_(Delegate function, params object[] parameters)
		=> atNextCheckAndEveryCheckAfterExecute(function, parameters);
	public Coroutine atNextCheckAndEveryCheckAfterExecute(Action action, params object[] parameters)
		=> atNextCheckAndEveryCheckAfterExecute_(action, parameters);
	#endregion planning to execute functions\actions at next check and every check after


	#region planning to execute functions\actions at the end of the current frame

	// methods: plan to execute the given function with the given parameters at the end of the current frame, then return the new coroutine that will do so //
	public Coroutine atEndOfFrameExecute(Delegate function, params object[] parameters)
		=> startCoroutine(atEndOfFrameExecute_Coroutine(function, parameters));
	private IEnumerator atEndOfFrameExecute_Coroutine(Delegate function, params object[] parameters)
	{
		yield return Wait.untilEndOfFrame;
		function.execute(parameters);
	}
	private Coroutine atEndOfFrameExecute_(Delegate function, params object[] parameters)
		=> atEndOfFrameExecute(function, parameters);
	public Coroutine atEndOfFrameExecute(Action action, params object[] parameters)
		=> atEndOfFrameExecute_(action, parameters);
	#endregion planning to execute functions\actions at the end of the current frame
}