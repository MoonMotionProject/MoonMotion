using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Function Extensions: provides extension methods for handling functions //
public static class FunctionExtensions
{
	#region logic

	// method: return the given action on the specified type predicated with this given booleanic function upon the specified type //
	public static Action<ObjectT> predicating<ObjectT>(this Func<ObjectT, bool> function, Action<ObjectT> action)
		=> action.predicatedWith(function);
	
	// method: return this given function negated //
	public static Func<ObjectT, bool> negated<ObjectT>(this Func<ObjectT, bool> function)
		=> (object_ => !function(object_));
	#endregion logic


	#region conversion

	// method: return the predicate corresponding to this given (predicate) function //
	public static Predicate<ObjectT> asPredicate<ObjectT>(this Func<ObjectT, bool> function)
		=> (object_ => function(object_));
	#endregion conversion
}