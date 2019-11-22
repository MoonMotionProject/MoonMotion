﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Mono Behaviour Extensions: provides extension methods for handling mono behaviours //
// #mono #coroutines #execution
public static class MonoBehaviourExtensions
{
	#if UNITY_EDITOR
	#region project path

	// method: return the project path of this given mono behaviour's script asset //
	public static string projectPath(this MonoBehaviour monoBehaviour)
		=> Project.pathForMonoBehaviour(monoBehaviour);
	#endregion project path
	#endif


	#region coroutines

	// method: have this given mono behaviour have Unity begin a coroutine using the given enumerator, then return the begun coroutine //
	public static Coroutine beginCoroutine(this MonoBehaviour monoBehaviour, IEnumerator enumerator)
		=> monoBehaviour.StartCoroutine(enumerator);
	#endregion coroutines


	#region planning to execute methods

	// method: plan to execute the method on this given mono behaviour with the given name after the given delay, then return this given mono behaviour //
	public static MonoBehaviour executeAfter(this MonoBehaviour monoBehaviour, float delay, string methodName)
		=> monoBehaviour.after(()=>
			monoBehaviour.Invoke(methodName, delay));
	#endregion planning to execute methods


	#region conversion

	#if UNITY_EDITOR
	// method: return this given mono behaviour as a Unity script file //
	public static MonoScript asScript(this MonoBehaviour monoBehaviour)
		=> MonoScript.FromMonoBehaviour(monoBehaviour);
	#endif
	#endregion conversion
}