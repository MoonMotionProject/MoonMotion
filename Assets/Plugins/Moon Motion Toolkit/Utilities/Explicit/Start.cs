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

	// methods: have the ether have Unity start a repeating coroutine using the given function executing the given parameters, starting now versus at next check according to the given boolean, then return the started coroutine //
	public static Coroutine repeatingCoroutine(Delegate function, bool startNowVersusAtNextCheck = Default.repeatingCoroutineStartingNowVersusAtNextCheck, params object[] parameters)
		=> Ether.startRepeatingCoroutine(function, startNowVersusAtNextCheck, parameters);
	public static Coroutine repeatingCoroutine(Action action, bool startNowVersusAtNextCheck = Default.repeatingCoroutineStartingNowVersusAtNextCheck)
		=> Ether.startRepeatingCoroutine(action, startNowVersusAtNextCheck);
	#endregion coroutines
}