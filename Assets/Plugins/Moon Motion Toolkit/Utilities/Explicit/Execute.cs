using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Execute:
// • provides methods for handling execution
// #coroutines #execution
public static class Execute
{
	#region planning to execute functions after a delay

	// methods: (have the ether) plan to execute the given function with the given parameters after the given delay, then return the new coroutine that will do so //
	public static Coroutine after(float delay, Delegate function, params object[] parameters)
		=> Ether.behaviour.executeAfter(delay, function, parameters);
	public static Coroutine after(float delay, Action action, params object[] parameters)
		=> Ether.behaviour.executeAfter(delay, action, parameters);
	#endregion planning to execute functions after a delay
	

	#region planning to execute functions\actions at next check

	// methods: (have the ether) plan to execute the given function with the given parameters at the next coroutine check, then return the new coroutine that will do so //
	public static Coroutine atNextCheck(Delegate function, params object[] parameters)
		=> Ether.behaviour.atNextCheckExecute(function, parameters);
	public static Coroutine atNextCheck(Action action, params object[] parameters)
		=> Ether.behaviour.atNextCheckExecute(action, parameters);
	#endregion planning to execute functions\actions at next check


	#region planning to execute functions\actions now and at every check

	// methods: (have the ether) plan to execute the given function with the given parameters at every coroutine check, then return the new coroutine that will do so //
	public static Coroutine nowAndAtEveryCheck(Delegate function, params object[] parameters)
		=> Ether.behaviour.nowAndAtEveryCheckExecute(function, parameters);
	public static Coroutine nowAndAtEveryCheck(Action action, params object[] parameters)
		=> Ether.behaviour.nowAndAtEveryCheckExecute(action, parameters);
	#endregion planning to execute functions\actions now and at every check


	#region planning to execute functions\actions at next check and every check after

	// methods: (have the ether) plan to execute the given function with the given parameters at every coroutine check, then return the new coroutine that will do so //
	public static Coroutine atNextCheckAndEveryCheckAfter(Delegate function, params object[] parameters)
		=> Ether.behaviour.atNextCheckAndEveryCheckAfterExecute(function, parameters);
	public static Coroutine atNextCheckAndEveryCheckAfter(Action action, params object[] parameters)
		=> Ether.behaviour.atNextCheckAndEveryCheckAfterExecute(action, parameters);
	#endregion planning to execute functions\actions at next check and every check after


	#region planning to execute functions\actions at the end of the current frame

	// methods: (have the ether) plan to execute the given function with the given parameters at the end of the current frame, then return the new coroutine that will do so //
	public static Coroutine atEndOfFrame(Delegate function, params object[] parameters)
		=> Ether.behaviour.atEndOfFrameExecute(function, parameters);
	public static Coroutine atEndOfFrame(Action action, params object[] parameters)
		=> Ether.behaviour.atEndOfFrameExecute(action, parameters);
	#endregion planning to execute functions\actions at the end of the current frame
}