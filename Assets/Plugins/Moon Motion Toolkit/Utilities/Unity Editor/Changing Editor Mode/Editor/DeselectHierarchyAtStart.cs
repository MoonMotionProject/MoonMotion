using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Deselect Hierarchy At Start:
// • at the start, deselects the current hierarchy selection
//   · this happens optionally based on Whether To Deselect Hierarchy At Start
[InitializeOnLoad]
public static class DeselectHierarchyAtStart
{
	static DeselectHierarchyAtStart()
	{
		EditorApplication.playModeStateChanged += deselectHierarchy;
	}

	private static void deselectHierarchy(PlayModeStateChange playModeStateChange)
	{
		if ((WhetherToDeselectHierarchyAtStart.state) && (playModeStateChange == PlayModeStateChange.EnteredPlayMode))
		{
			Hierarchy.deselect();
		}
	}
}