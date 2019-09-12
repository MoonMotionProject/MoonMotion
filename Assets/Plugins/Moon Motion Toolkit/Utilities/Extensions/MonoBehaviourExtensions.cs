﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

// Mono Behaviour Extensions: provides extension methods for handling mono behaviours //
// #auto
public static class MonoBehaviourExtensions
{
	#region asset path

	// method: return the asset path of this given mono behaviour's script asset //
	public static string assetPath(this MonoBehaviour monoBehaviour)
		=> Asset.pathForMonoBehaviour(monoBehaviour);
	#endregion asset path


	#region coroutines

	// method: have this given mono behaviour have Unity start a coroutine using the given enumerator, then return the started coroutine //
	public static Coroutine startCoroutine(this MonoBehaviour monoBehaviour, IEnumerator enumerator)
		=> monoBehaviour.StartCoroutine(enumerator);
	#endregion coroutines


	#region planning to execute methods

	// method: plan to execute the method on this given mono behaviour with the given name after the given delay, then return this given mono behaviour //
	public static MonoBehaviour planToExecute(this MonoBehaviour monoBehaviour, string methodName, float delay)
		=> monoBehaviour.after(()=>
			monoBehaviour.Invoke(methodName, delay));
	#endregion planning to execute methods


	#region conversion

	// method: return this given mono behaviour as a Unity script file //
	public static MonoScript asScript(this MonoBehaviour monoBehaviour)
		=> MonoScript.FromMonoBehaviour(monoBehaviour);
	#endregion conversion
}