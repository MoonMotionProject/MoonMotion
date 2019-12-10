using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interfaces:
// • provides methods for handling interfaces
// #types #reflection
public static class Interfaces
{
	#region interface determination

	// method: return whether the specified type is an interface //
	public static bool includes<I>() where I : class
		=> typeof(I).isAnInterface();
	public static bool doesNotInclude<I>() where I : class
		=> !includes<I>();
	#endregion interface determination
}