using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Deselect Hierarchy Upon Changing Editor Mode:
// • upon changing editor mode, deselects the current hierarchy selection
[InitializeOnLoad]      // ensures that this class's constructor is called every time the project recompiles
public static class DeselectHierarchyUponChangingEditorMode
{
	static DeselectHierarchyUponChangingEditorMode()
	{
		EditorApplication.playModeStateChanged += deselectHierarchy;
	}

	private static void deselectHierarchy(PlayModeStateChange playModeStateChange)
		=> Hierarchy.deselect();
}