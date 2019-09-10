using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Clean Null Game Objects For Component Caching Upon Changing Editor Mode:
// • upon changing editor mode, cleans nulls from the dictionary in Component Caching Extensions
[InitializeOnLoad]
public static class CleanNullGameObjectsForComponentCachingUponChangingEditorMode
{
	static CleanNullGameObjectsForComponentCachingUponChangingEditorMode()
	{
		EditorApplication.playModeStateChanged += cleanNullGameObjectsForComponentCaching;
	}

	private static void cleanNullGameObjectsForComponentCaching(PlayModeStateChange playModeStateChange)
		=> ComponentCachingExtensions.clean();
}