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
				return startCoroutine(Default.coroute, function, parameters).returnWithError("the Auto Behaviour Layer Mono Behaviour on "+self+" had startCoroutine called with the coroute "+coroute+" given, which is not accepted by this method, so the default coroute was chosen as a fallback");
		}
	}
	private Coroutine _startCoroutine(Coroute coroute, Delegate function, params object[] parameters)
		=> startCoroutine(coroute, function, parameters);
	public Coroutine startCoroutine(Coroute coroute, Action action)
		=> _startCoroutine(coroute, action);
	
	// methods: have this mono behaviour have Unity start a coroutine using the given interval and the given function executing the given parameters and following the given coroute, then return the started coroutine //
	public Coroutine startCoroutineWithInterval(float interval, Coroute coroute, Delegate function, params object[] parameters)
	{
		switch (coroute)
		{
			case Coroute.nowAndOnInterval:
				return executeNowAndEvery(interval, function, parameters);
			case Coroute.afterEachInterval:
				return executeAfterEvery(interval, function, parameters);
			default:
				return startCoroutine(Default.coroute, function, parameters).returnWithError("the Auto Behaviour Layer Mono Behaviour on "+self+" had startCoroutineWithInterval called with the coroute "+coroute+" given, which is not accepted by this method, so the default coroute was chosen as a fallback");
		}
	}
	private Coroutine _startCoroutineWithInterval(float interval, Coroute coroute, Delegate function, params object[] parameters)
		=> startCoroutineWithInterval(interval, coroute, function, parameters);
	public Coroutine startCoroutineWithInterval(float interval, Coroute coroute, Action action)
		=> _startCoroutineWithInterval(interval, coroute, action);
	
	// methods: have this mono behaviour have Unity start a repeating coroutine using the given function executing the given parameters, starting now versus at next check according to the given boolean, then return the started coroutine //
	public Coroutine startRepeatingCoroutine(Delegate function, bool startNowVersusAtNextCheck = Default.startingNowVersusAtNextCycle, params object[] parameters)
		=>	startCoroutine
			(
				startNowVersusAtNextCheck ?
					Coroute.nowAndAtEveryCheck :
					Coroute.atNextCheckAndEveryCheckAfter,
				function,
				parameters
			);
	private Coroutine _startRepeatingCoroutine(Delegate function, bool startNowVersusAtNextCheck = Default.startingNowVersusAtNextCycle, params object[] parameters)
		=> startRepeatingCoroutine(function, startNowVersusAtNextCheck, parameters);
	public Coroutine startRepeatingCoroutine(Action action, bool startNowVersusAtNextCheck = Default.startingNowVersusAtNextCycle)
		=> _startRepeatingCoroutine(action, startNowVersusAtNextCheck);
	
	// methods: have this mono behaviour have Unity start a repeating coroutine using the given interval and the given function executing the given parameters, starting now versus after the first interval according to the given boolean, then return the started coroutine //
	public Coroutine startCoroutineRepeatingEvery(float interval, Delegate function, bool startNowVersusAfterFirstInterval = Default.startingNowVersusAtNextCycle, params object[] parameters)
		=>	startCoroutineWithInterval
			(
				interval,
				startNowVersusAfterFirstInterval ?
					Coroute.nowAndOnInterval :
					Coroute.afterEachInterval,
				function,
				parameters
			);
	private Coroutine _startCoroutineRepeatingEvery(float interval, Delegate function, bool startNowVersusAfterFirstInterval = Default.startingNowVersusAtNextCycle, params object[] parameters)
		=> startCoroutineRepeatingEvery(interval, function, startNowVersusAfterFirstInterval, parameters);
	public Coroutine startCoroutineRepeatingEvery(float interval, Action action, bool startNowVersusAfterFirstInterval = Default.startingNowVersusAtNextCycle)
		=> _startCoroutineRepeatingEvery(interval, action, startNowVersusAfterFirstInterval);

	// method: stop this mono behaviour's given coroutine, then return this (derived auto) behaviour //
	public AutoBehaviourT stopCoroutine(Coroutine coroutine)
		=> selfAfter(()=> StopCoroutine(coroutine));

	// method: stop all of this mono behaviour's coroutines, then return this (derived auto) behaviour //
	public AutoBehaviourT stopAllCoroutines()
		=> selfAfter(()=> StopAllCoroutines());
	#endregion starting and stopping coroutines


	#region planning to execute functions\actions after a delay

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
			yield return Wait.delayOf(delay);
		}
		
		function.execute(parameters);
	}
	private Coroutine _executeAfter(float delay, Delegate function, params object[] parameters)
		=> executeAfter(delay, function, parameters);
	public Coroutine executeAfter(float delay, Action action, params object[] parameters)
		=> _executeAfter(delay, action, parameters);
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
	private Coroutine _atNextCheckExecute(Delegate function, params object[] parameters)
		=> atNextCheckExecute(function, parameters);
	public Coroutine atNextCheckExecute(Action action, params object[] parameters)
		=> _atNextCheckExecute(action, parameters);
	#endregion planning to execute functions\actions at next check


	#region planning to execute functions\actions now and at every check

	// methods: plan to execute the given function with the given parameters now and at every coroutine check, then return the new coroutine that will do so //
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
	private Coroutine _nowAndAtEveryCheckExecute(Delegate function, params object[] parameters)
		=> nowAndAtEveryCheckExecute(function, parameters);
	public Coroutine nowAndAtEveryCheckExecute(Action action, params object[] parameters)
		=> _nowAndAtEveryCheckExecute(action, parameters);
	#endregion planning to execute functions\actions now and at every check


	#region planning to execute functions\actions at next check and every check after

	// methods: plan to execute the given function with the given parameters at every coroutine check, then return the new coroutine that will do so //
	public Coroutine atNextCheckAndEveryCheckAfterExecute(Delegate function, params object[] parameters)
		=> startCoroutine(atNextCheckAndEveryCheckAfterExecute_Coroutine(function, parameters));
	private IEnumerator atNextCheckAndEveryCheckAfterExecute_Coroutine(Delegate function, params object[] parameters)
	{
		while (true)
		{
			yield return Wait.untilNextCheck;
			function.execute(parameters);
		}
	}
	private Coroutine _atNextCheckAndEveryCheckAfterExecute(Delegate function, params object[] parameters)
		=> atNextCheckAndEveryCheckAfterExecute(function, parameters);
	public Coroutine atNextCheckAndEveryCheckAfterExecute(Action action, params object[] parameters)
		=> _atNextCheckAndEveryCheckAfterExecute(action, parameters);
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
	private Coroutine _atEndOfFrameExecute(Delegate function, params object[] parameters)
		=> atEndOfFrameExecute(function, parameters);
	public Coroutine atEndOfFrameExecute(Action action, params object[] parameters)
		=> _atEndOfFrameExecute(action, parameters);
	#endregion planning to execute functions\actions at the end of the current frame


	#region planning to execute functions\actions now and on interval

	// methods: plan to execute the given function with the given parameters now and on the given interval, then return the new coroutine that will do so //
	public Coroutine executeNowAndEvery(float interval, Delegate function, params object[] parameters)
		=> startCoroutine(executeNowAndEvery_Coroutine(interval, function, parameters));
	private IEnumerator executeNowAndEvery_Coroutine(float interval, Delegate function, params object[] parameters)
	{
		while (true)
		{
			function.execute(parameters);
			yield return Wait.delayOf(interval);
		}
	}
	private Coroutine _executeNowAndEvery(float interval, Delegate function, params object[] parameters)
		=> executeNowAndEvery(interval, function, parameters);
	public Coroutine executeNowAndEvery(float interval, Action action, params object[] parameters)
		=> _executeNowAndEvery(interval, action, parameters);
	#endregion planning to execute functions\actions now and on interval


	#region planning to execute functions\actions after every interval

	// methods: plan to execute the given function with the given parameters after every interval (for the given interval), then return the new coroutine that will do so //
	public Coroutine executeAfterEvery(float interval, Delegate function, params object[] parameters)
		=> startCoroutine(executeAfterEvery_Coroutine(interval, function, parameters));
	private IEnumerator executeAfterEvery_Coroutine(float interval, Delegate function, params object[] parameters)
	{
		while (true)
		{
			yield return Wait.delayOf(interval);
			function.execute(parameters);
		}
	}
	private Coroutine _executeAfterEvery(float interval, Delegate function, params object[] parameters)
		=> executeAfterEvery(interval, function, parameters);
	public Coroutine executeAfterEvery(float interval, Action action, params object[] parameters)
		=> _executeAfterEvery(interval, action, parameters);
	#endregion planning to execute functions\actions after every interval
}