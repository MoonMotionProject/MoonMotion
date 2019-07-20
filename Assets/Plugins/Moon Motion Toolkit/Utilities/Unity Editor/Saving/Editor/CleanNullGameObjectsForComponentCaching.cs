using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Clean Null Game Objects For Component Caching Upon Save:
// • upon saving, cleans nulls from the dictionary in Component Caching Extensions
public class CleanNullGameObjectsForComponentCachingUponSave : UnityEditor.AssetModificationProcessor
{
	static string[] OnWillSaveAssets(string[] paths)
	{
		ComponentCachingExtensions.clean();

		return paths;
	}
}