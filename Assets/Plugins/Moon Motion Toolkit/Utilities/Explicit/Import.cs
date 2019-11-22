#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Import:
// • provides methods for importing assets
// #assets
public static class Import
{
	// method: (according to the given boolean:) import the asset at the given project path //
	public static void assetAtProjectPath(string projectPath, bool boolean = true)
	{
		if (boolean)
		{
			AssetDatabase.ImportAsset(projectPath);
		}
	}

	// method: (according to the given boolean:) import the asset for the given asset path //
	public static void asset(string assetPath, bool boolean = true)
		=> assetAtProjectPath(Project.pathFor(assetPath), boolean);

	// method: (according to the given boolean:) import the asset with the given title at the given asset address //
	public static void asset(string assetTitle, string assetAddress, bool boolean = true)
		=> assetAtProjectPath(Project.pathFor(assetTitle, assetAddress), boolean);

	// method: (according to the given boolean:) import the given asset Unity object //
	public static void asset(Object assetUnityObject, bool boolean = true)
		=>	assetAtProjectPath(Project.pathForAsset(assetUnityObject),
				boolean);

	// method: import the given asset Unity object if it is in the assets //
	public static void assetIfInAssets(Object assetUnityObject)
		=>	asset(assetUnityObject,
				Project.pathForAsset(assetUnityObject).isNotEmptyNorNull());
}
#endif