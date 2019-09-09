using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Randomly: provides methods for randomly handling //
public static class Randomly
{
	#region choosing

	// method: return a random item out of this given enumerable //
	public static TItem chosenFrom<TItem>(IEnumerable<TItem> enumerable)
		=> enumerable.randomItem();
	// method: return a random object out of these given objects //
	public static ObjectT chosenFrom<ObjectT>(params ObjectT[] objects)
		=> chosenFrom(objects.asEnumerable());
	#endregion choosing
}