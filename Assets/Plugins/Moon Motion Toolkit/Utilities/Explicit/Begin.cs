using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Begin: provides methods for beginning things
// #coroutines #execution
public static class Begin
{
	#region coroutines

	// method: have the ether have Unity begin a coroutine using the given enumerator, then return the begun coroutine //
	public static Coroutine coroutine(IEnumerator enumerator)
		=> Ether.beginCoroutine(enumerator);

	// methods: have the ether have Unity begin a coroutine using the given function executing the given parameters and following the given coroute, then return the begun coroutine //
	public static Coroutine coroutine(Coroute coroute, Delegate function, params object[] parameters)
		=> Ether.beginCoroutine(coroute, function, parameters);
	public static Coroutine coroutine(Coroute coroute, Action action)
		=> Ether.beginCoroutine(coroute, action);
	
	public static Coroutine coroutineWithInterval(float interval, Coroute coroute, Delegate function, params object[] parameters)
		=> Ether.beginCoroutineWithInterval(interval, coroute, function, parameters);
	public static Coroutine coroutineWithInterval(float interval, Coroute coroute, Action action)
		=> Ether.beginCoroutineWithInterval(interval, coroute, action);

	// methods: have the ether have Unity begin a repeating coroutine using the given function executing the given parameters, beginning now versus at next check according to the given boolean, then return the begun coroutine //
	public static Coroutine repeatingCoroutine(Delegate function, bool beginNowVersusAtNextCheck = Default.beginningNowVersusAtNextCycle, params object[] parameters)
		=> Ether.beginRepeatingCoroutine(function, beginNowVersusAtNextCheck, parameters);
	public static Coroutine repeatingCoroutine(Action action, bool beginNowVersusAtNextCheck = Default.beginningNowVersusAtNextCycle)
		=> Ether.beginRepeatingCoroutine(action, beginNowVersusAtNextCheck);
	
	public static Coroutine coroutineRepeatingEvery(float interval, Delegate function, bool beginNowVersusAfterFirstInterval = Default.beginningNowVersusAtNextCycle, params object[] parameters)
		=> Ether.beginCoroutineRepeatingEvery(interval, function, beginNowVersusAfterFirstInterval, parameters);
	public static Coroutine coroutineRepeatingEvery(float interval, Action action, bool beginNowVersusAfterFirstInterval = Default.beginningNowVersusAtNextCycle)
		=> Ether.beginCoroutineRepeatingEvery(interval, action, beginNowVersusAfterFirstInterval);
	#endregion coroutines
}