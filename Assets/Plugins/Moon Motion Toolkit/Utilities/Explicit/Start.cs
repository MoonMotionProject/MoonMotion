using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Start: provides methods for starting things
// #coroutines #execution
public static class Start
{
	#region coroutines

	// method: have the ether have Unity start a coroutine using the given enumerator, then return the started coroutine //
	public static Coroutine coroutine(IEnumerator enumerator)
		=> Ether.startCoroutine(enumerator);

	// methods: have the ether have Unity start a coroutine using the given function executing the given parameters and following the given coroute, then return the started coroutine //
	public static Coroutine coroutine(Coroute coroute, Delegate function, params object[] parameters)
		=> Ether.startCoroutine(coroute, function, parameters);
	public static Coroutine coroutine(Coroute coroute, Action action)
		=> Ether.startCoroutine(coroute, action);
	
	public static Coroutine coroutineWithInterval(float interval, Coroute coroute, Delegate function, params object[] parameters)
		=> Ether.startCoroutineWithInterval(interval, coroute, function, parameters);
	public static Coroutine coroutineWithInterval(float interval, Coroute coroute, Action action)
		=> Ether.startCoroutineWithInterval(interval, coroute, action);

	// methods: have the ether have Unity start a repeating coroutine using the given function executing the given parameters, starting now versus at next check according to the given boolean, then return the started coroutine //
	public static Coroutine repeatingCoroutine(Delegate function, bool startNowVersusAtNextCheck = Default.startingNowVersusAtNextCycle, params object[] parameters)
		=> Ether.startRepeatingCoroutine(function, startNowVersusAtNextCheck, parameters);
	public static Coroutine repeatingCoroutine(Action action, bool startNowVersusAtNextCheck = Default.startingNowVersusAtNextCycle)
		=> Ether.startRepeatingCoroutine(action, startNowVersusAtNextCheck);
	
	public static Coroutine coroutineRepeatingEvery(float interval, Delegate function, bool startNowVersusAfterFirstInterval = Default.startingNowVersusAtNextCycle, params object[] parameters)
		=> Ether.startCoroutineRepeatingEvery(interval, function, startNowVersusAfterFirstInterval, parameters);
	public static Coroutine coroutineRepeatingEvery(float interval, Action action, bool startNowVersusAfterFirstInterval = Default.startingNowVersusAtNextCycle)
		=> Ether.startCoroutineRepeatingEvery(interval, action, startNowVersusAfterFirstInterval);
	#endregion coroutines
}