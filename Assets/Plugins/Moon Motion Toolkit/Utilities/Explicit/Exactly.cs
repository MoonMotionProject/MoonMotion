using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Exactly: provides methods for determining whether the given enumerable has exactly the respective number of items //
public static class Exactly
{
	public static bool oneIn<TItem>(IEnumerable<TItem> enumerable)
		=> enumerable.hasExactlyOne();
}