using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Any: provides methods for determining content //
public static class Any
{
	public static bool itemsIn<TItem>(IEnumerable<TItem> enumerable)
		=> enumerable.hasAny();
}