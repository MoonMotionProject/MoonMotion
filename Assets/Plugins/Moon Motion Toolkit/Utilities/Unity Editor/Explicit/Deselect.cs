#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Deselect:
// • provides methods for deselecting (in the editor)
public static class Deselect
{
	public static void all()
	{
		Select.onlyAssetsFolder();
		Select.only(New.arrayOf<Object>());
	}
}
#endif