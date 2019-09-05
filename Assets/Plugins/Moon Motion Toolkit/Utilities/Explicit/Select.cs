using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Select: provides methods for yielding in iteration //
public static class Select
{
	#region yielding while iterating ranges

	// method: return a selection of the given function upon the current index for each index in the range from the given start integer to the given end integer //
	public static IEnumerable<TResult> forRange<TResult>(int start, int end, Func<int, TResult> function)
	{
		for (int index = start; index <= end; index++)
		{
			yield return function(index);
		}
	}
	#endregion yielding while iterating ranges


	#region yielding while iterating counts

	// method: return a selection of the given function upon the current index for each index in the range for the given count, starting from the given starting index (0 by default) //
	public static IEnumerable<TResult> forCount<TResult>(int count, Func<int, TResult> function, int startingIndex = 0)
		=> forRange(startingIndex, startingIndex + (count - 1), function);
	#endregion yielding while iterating counts
}