#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

// Assets:
// • provides properties methods for handling Assets
// #assets
public static class Assets
{
	public static string address = Directory.GetCurrentDirectory()+"\\Assets\\";
	
	public static void ensureFolderForAddress(string assetAddress)
	{
		if (!AssetDatabase.IsValidFolder("Assets\\"+assetAddress))
		{
			AssetDatabase.CreateFolder("Assets", assetAddress);
		}
	}

	// method: return the set of assets of the specified type corresponding to each of the given asset paths //
	public static HashSet<AssetT> atPathsOfType<AssetT>(IEnumerable<string> assetPaths) where AssetT : class
		=>	assetPaths.pickUnique(assetPath =>
				Asset.atPathOfType<AssetT>(assetPath));

	// method: (via reflection:) return the set of assets of the specified type //
	public static HashSet<AssetT> ofType_ViaReflection<AssetT>() where AssetT : class
		=> atPathsOfType<AssetT>(Asset.pathsForAssetsOfType_ViaReflection<AssetT>());
	// method: (via reflection:) return the list of assets of the specified type //
	public static List<AssetT> manifestedOfType_ViaReflection<AssetT>() where AssetT : class
		=> ofType_ViaReflection<AssetT>().manifested();

	// method: (via reflection:) return the set of assets not from the Moon Motion Toolkit that are of the specified type //
	public static HashSet<AssetT> notFromMoonMotionToolkitOfType_ViaReflection<AssetT>() where AssetT : class
		=> atPathsOfType<AssetT>(Asset.pathsForNonMoonMotionToolkitAssetsOfType_ViaReflection<AssetT>());
	// method: (via reflection:) return the list of assets not from the Moon Motion Toolkit that are of the specified type //
	public static List<AssetT> notFromMoonMotionToolkitManifestedOfType_ViaReflection<AssetT>() where AssetT : class
		=> notFromMoonMotionToolkitOfType_ViaReflection<AssetT>().manifested();
}
#endif