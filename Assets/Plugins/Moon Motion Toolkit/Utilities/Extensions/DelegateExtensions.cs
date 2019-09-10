using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate Extensions: provides extension methods for handling delegates //
public static class DelegateExtensions
{
	#region executing

	// method: execute this given function with the given parameters (if any given) (passed in the same order as given) //
	public static void execute(this Delegate function, params object[] parameters)
		=> function.DynamicInvoke(parameters);
	#endregion executing
}