using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Yield Each: provides methods for yielding in iteration //
public static class YieldEach
{
	// methods for: yielding while iterating ranges //

	// method: yield the given function upon the current index for each index in the range from the given start integer to the given end integer //
	public static IEnumerable<TResult> inRange<TResult>(int start, int end, Func<int, TResult> function)
	{
		for (int index = start; index <= end; index++)
		{
			yield return function(index);
		}
	}


	// methods for: yielding while iterating counts //

	// method: yield the given function upon the current index for each index in the range for the given count, starting from the given starting index (0 by default), then return that count //
	public static IEnumerable<TResult> inCount<TResult>(int count, Func<int, TResult> function, int startingIndex = 0)
		=> inRange(startingIndex, startingIndex + (count - 1), function);
}