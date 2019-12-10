using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// No:
// • provides methods for determining content of enumerables
// #enumerables #selection
public static class No
{
	#region in given enumerable

	public static bool itemsIn<TItem>(IEnumerable<TItem> enumerable)
		=> !Any.itemsIn(enumerable);
	#endregion in given enumerable

	
	#region in selection
	#if UNITY_EDITOR
	
	public static bool selectedGameObjects => !Any.selectedGameObjects;
	#endif
	#endregion in selection
}