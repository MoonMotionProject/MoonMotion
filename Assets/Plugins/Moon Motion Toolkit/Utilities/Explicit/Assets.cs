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
	public const string folderName = "Assets";
	public static string folderNameRessed = folderName.ress();
	public static string address = Project.path;
	public static string path = address.ress();
	
	public static void ensureFolderFor(string assetAddress)
	{
		if (!AssetDatabase.IsValidFolder(Assets.folderNameRessed+assetAddress))
		{
			AssetDatabase.CreateFolder(Assets.folderName, assetAddress);
		}
	}

	// method: return the set of assets of the specified type corresponding to each of the given project paths //
	public static HashSet<AssetT> atProjectPathsOfType<AssetT>(IEnumerable<string> projectPaths) where AssetT : class
		=>	projectPaths.pickUnique(projectPath =>
				Asset.atProjectPathOfType<AssetT>(projectPath));

	// method: (via reflection:) return the set of assets of the specified type //
	public static HashSet<AssetT> ofType_ViaReflection<AssetT>() where AssetT : class
		=> atProjectPathsOfType<AssetT>(Project.pathsForAssetsOfType_ViaReflection<AssetT>());
	// method: (via reflection:) return the list of assets of the specified type //
	public static List<AssetT> manifestedOfType_ViaReflection<AssetT>() where AssetT : class
		=> ofType_ViaReflection<AssetT>().manifested();

	// method: (via reflection:) return the set of assets not from the Moon Motion Toolkit that are of the specified type //
	public static HashSet<AssetT> notFromMoonMotionToolkitOfType_ViaReflection<AssetT>() where AssetT : class
		=> atProjectPathsOfType<AssetT>(Project.pathsForNonMoonMotionToolkitAssetsOfType_ViaReflection<AssetT>());
	// method: (via reflection:) return the list of assets not from the Moon Motion Toolkit that are of the specified type //
	public static List<AssetT> notFromMoonMotionToolkitManifestedOfType_ViaReflection<AssetT>() where AssetT : class
		=> notFromMoonMotionToolkitOfType_ViaReflection<AssetT>().manifested();
}
#endif