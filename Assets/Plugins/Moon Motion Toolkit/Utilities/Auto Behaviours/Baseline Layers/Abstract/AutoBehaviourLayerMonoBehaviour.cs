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
	#region coroutines

	// method: have this mono behaviour have Unity start a coroutine using the given enumerator, then return the started coroutine //
	public Coroutine startCoroutine(IEnumerator enumerator)
		=> monoBehaviour.startCoroutine(enumerator);

	// method: have this mono behaviour have Unity start a coroutine using the given action and following the given coroute, then return the started coroutine //
	public Coroutine startCoroutine(Action action, Coroute coroute)
	{
		switch (coroute)
		{
			case Coroute.atNextCheck:
				return atNextCheckExecute(action);
			case Coroute.nowAndAtEveryCheck:
				return nowAndAtEveryCheckExecute(action);
			case Coroute.atNextCheckAndEveryCheckAfter:
				return atNextCheckAndEveryCheckAfterExecute(action);
			case Coroute.atEndOfFrame:
				return atEndOfFrameExecute(action);
			default:
				return startCoroutine(action, Default.coroute).returnWithError("the Auto Behaviour Layer Mono Behaviour on "+self+" had startCoroutine called with an unrecognized coroute given");
		}
	}

	// method: have this mono behaviour have Unity start a repeating coroutine using the given action, starting now versus at next check according to the given boolean, then return the started coroutine //
	public Coroutine startRepeatingCoroutine(Action action, bool startNowVersusAtNextCheck = true)
		=>	startCoroutine
			(
				action,
				startNowVersusAtNextCheck ?
					Coroute.nowAndAtEveryCheck :
					Coroute.atNextCheckAndEveryCheckAfter
			);

	// method: stop the given coroutine, then return this (derived auto) behaviour //
	public AutoBehaviourT stopCoroutine(Coroutine coroutine)
		=> selfAfter(()=> StopCoroutine(coroutine));

	// method: stop all coroutines, then return this (derived auto) behaviour //
	public AutoBehaviourT stopAllCoroutines()
		=> selfAfter(()=> StopAllCoroutines());
	#endregion coroutines


	#region planning to execute methods

	// method: plan to execute the method on this mono behaviour with the given name after the given delay, then return this (derived auto) behaviour //
	public AutoBehaviourT planToExecuteAfter(float delay, string methodName)
		=> selfAfter(()=> monoBehaviour.planToExecuteAfter(delay, methodName));

	// methods: plan to execute the given function with the given parameters after the given delay, then return the new coroutine that will do so //
	public Coroutine planToExecuteAfter(float delay, Delegate function, params object[] parameters)
		=> startCoroutine(planToExecuteAfter_Coroutine(delay, function, parameters));
	private IEnumerator planToExecuteAfter_Coroutine(float delay, Delegate function, params object[] parameters)
	{
		if (delay.isNonzero())
		{
			yield return Wait.delay(delay);
		}
		
		function.execute(parameters);
	}
	private Coroutine planToExecuteAfter_(float delay, Delegate function, params object[] parameters)
		=> planToExecuteAfter(delay, function, parameters);
	public Coroutine planToExecuteAfter(float delay, Action action, params object[] parameters)
		=> planToExecuteAfter_(delay, action, parameters);
	#endregion planning to execute methods


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