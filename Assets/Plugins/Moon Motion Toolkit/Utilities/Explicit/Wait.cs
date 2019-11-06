using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Wait:
// • provides properties and methods returning coroutine waits (enumerators used to have coroutines wait)
// #coroutines #execution
public static class Wait
{
	public static IEnumerator untilNextCheck {get {yield return null;}}
	public static IEnumerator untilEndOfFrame {get {yield return new WaitForEndOfFrame();}}
	public static IEnumerator untilNextFixedUpdate {get {yield return new WaitForFixedUpdate();}}
	public static IEnumerator delay(float seconds)
	{
		yield return new WaitForSeconds(seconds);
	}
	public static IEnumerator delayInRealtime(float seconds)
	{
		yield return new WaitForSecondsRealtime(seconds);
	}
	public static IEnumerator until(Func<bool> function)
	{
		yield return new WaitUntil(function);
	}
	public static IEnumerator whilst(Func<bool> function)
	{
		yield return new WaitWhile(function);
	}
}