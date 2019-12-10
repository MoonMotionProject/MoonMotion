using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Any:
// • provides methods for determining content of enumerables
// #enumerables #selection
public static class Any
{
	#region in given enumerable

	public static bool itemsIn<TItem>(IEnumerable<TItem> enumerable)
		=> enumerable.hasAny();
	#endregion in given enumerable

	
	#region in selection
	#if UNITY_EDITOR
	
	public static bool selectedGameObjects => Selected.gameObject.isYull();
	#endif
	#endregion in selection
}