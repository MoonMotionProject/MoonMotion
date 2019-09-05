using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For Each: provides methods for iterating //
public static class ForEach
{
	#region iterating ranges

	// method: execute the given action for each index in the range from the given start integer to the given end integer //
	public static void inRange(int start, int end, Action action)
	{
		for (int index = start; index <= end; index++)
		{
			action();
		}
	}

	// method: execute the given action upon the current index for each index in the range from the given start integer to the given end integer //
	public static void inRange(int start, int end, Action<int> action)
	{
		for (int index = start; index <= end; index++)
		{
			action(index);
		}
	}
	#endregion iterating ranges


	#region iterating counts

	// method: execute the given action for each index in the range for the given count, starting from the given starting index (0 by default), then return that count //
	public static int inCount(int count, Action action, int startingIndex = 0)
		=> count.after(()=>
			inRange(startingIndex, startingIndex + (count - 1), action));

	// method: execute the given action upon the current index for each index in the range for the given count, starting from the given starting index (0 by default), then return that count //
	public static int inCount(int count, Action<int> action, int startingIndex = 0)
		=> count.after(()=>
			inRange(startingIndex, startingIndex + (count - 1), action));
	#endregion iterating counts
}