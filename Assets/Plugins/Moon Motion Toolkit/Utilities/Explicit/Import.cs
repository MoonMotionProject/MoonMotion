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
	// method: (according to the given boolean:) import the asset at the given asset path //
	public static void assetAtAssetPath(string assetPath, bool boolean = true)
	{
		if (boolean)
		{
			AssetDatabase.ImportAsset(assetPath);
		}
	}

	// method: (according to the given boolean:) import the given asset Unity object //
	public static void asset(Object assetUnityObject, bool boolean = true)
		=>	assetAtAssetPath(Asset.pathForAsset(assetUnityObject),
				boolean);

	// method: import the given asset Unity object if it actually has an asset path //
	public static void assetIfItActuallyHasAnAssetPath(Object assetUnityObject)
		=>	asset(assetUnityObject,
				Asset.pathForAsset(assetUnityObject).isNotEmptyNorNull());
}
#endif