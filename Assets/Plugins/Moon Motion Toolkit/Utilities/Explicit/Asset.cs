#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

// Asset:
// • provides properties and methods for handling assets
// #assets
public static class Asset
{
	#region filtering all asset idees

	// method: return an array of asset idees for all assets filtered by the given filter string //
	public static string[] ideesForAssetsFilteredBy(string filterString)
		=> AssetDatabase.FindAssets(filterString);
	public static string[] ideesForAssets => ideesForAssetsFilteredBy("");

	// method: return an array of script asset idees for all script assets filtered by the given filter string //
	public static string[] ideesForScriptAssetsFilteredBy(string filterString)
		=> ideesForAssetsFilteredBy("t:Script "+filterString);
	public static string[] ideesForScriptAssets => ideesForScriptAssetsFilteredBy("");

	// method: return an array of prefab asset idees for all prefab assets filtered by the given filter string //
	public static string[] ideesForPrefabAssetsFilteredBy(string filterString)
		=> ideesForAssetsFilteredBy("t:Prefab "+filterString);
	public static string[] ideesForPrefabAssets => ideesForPrefabAssetsFilteredBy("");
	#endregion filtering all asset idees




	#region filtering all asset paths

	// method: return the set of asset paths for all assets filtered by the given filter string //
	public static HashSet<string> pathsForAssetsFilteredBy(string filterString)
		=> ideesForAssetsFilteredBy(filterString).pickUnique(idee => pathForAssetIdee(idee));
	public static HashSet<string> pathsForAssets => pathsForAssetsFilteredBy("");

	// method: return the set of script asset paths for all script assets filtered by the given filter string //
	public static HashSet<string> pathsForScriptAssetsFilteredBy(string filterString)
		=> ideesForScriptAssetsFilteredBy(filterString).pickUnique(idee => pathForAssetIdee(idee));
	public static HashSet<string> pathsForScriptAssets => pathsForScriptAssetsFilteredBy("");

	// method: return the set of prefab asset paths for all prefab assets filtered by the given filter string //
	public static HashSet<string> pathsForPrefabAssetsFilteredBy(string filterString)
		=> ideesForPrefabAssetsFilteredBy(filterString).pickUnique(idee => pathForAssetIdee(idee));
	public static HashSet<string> pathsForPrefabAssets => pathsForPrefabAssetsFilteredBy("");
	#endregion filtering all asset paths




	#region conversion


	#region to idees

	// method: return the asset idee of the script asset with the given simple class name, if any asset matches (otherwise returning null) //
	public static string ideeForSimpleClassName(string simpleClassName)
	{
		string[] filteredScriptAssetIdees = ideesForScriptAssetsFilteredBy(simpleClassName);

		if (Any.itemsIn(filteredScriptAssetIdees))
		{
			string matchingAssetIdee = filteredScriptAssetIdees.hasExactlyOne() ?
											filteredScriptAssetIdees.first() :
											filteredScriptAssetIdees.isPlural() ?
												filteredScriptAssetIdees.firstWhere(assetIdee =>
					filetitleForAssetIdee(assetIdee).matches(simpleClassName)) :
												"";

			if (matchingAssetIdee.isNotEmptyNorNull())
			{
				return matchingAssetIdee;
			}
		}
		return ("no asset idee found for given simple class name of '"+simpleClassName+"'")
				.printAsErrorAndReturnDefault<string>();
	}
	#endregion to idees
	

	#region to asset paths
	
	// method: return the asset path of the given asset Unity object //
	public static string pathForAsset(UnityEngine.Object assetUnityObject)
		=> AssetDatabase.GetAssetPath(assetUnityObject);
	
	// method: return the asset path of the given mono behaviour's script asset //
	public static string pathForMonoBehaviour(MonoBehaviour monoBehaviour)
		=> pathForAsset(monoBehaviour.asScript());

	// method: return the asset path of the asset for the given asset idee //
	public static string pathForAssetIdee(string assetIdee)
		=> AssetDatabase.GUIDToAssetPath(assetIdee);

	// method: return the asset path of the script asset with the given simple class name //
	public static string pathForSimpleClassName(string simpleClassName)
		=> pathForAssetIdee(ideeForSimpleClassName(simpleClassName));

	// method: return the asset path of the script asset with the given script asset type (class of a script asset) //
	public static string pathForScriptAssetType(Type scriptAssetType)
		=> pathForSimpleClassName(scriptAssetType.simpleClassName());
	#endregion to asset paths


	#region to filenames

	// method: return the asset filename for the given asset path //
	public static string filenameForAssetPath(string assetPath)
		=> Path.GetFileName(assetPath);

	// method: return the asset filename for the given asset idee //
	public static string filenameForAssetIdee(this string assetIdee)
		=> filenameForAssetPath(pathForAssetIdee(assetIdee));
	#endregion to filenames


	#region to filetitles

	// method: return the asset filetitle for the given asset path //
	public static string filetitleForAssetPath(this string assetPath)
		=> Path.GetFileNameWithoutExtension(assetPath);

	// method: return the asset filetitle for the given asset idee //
	public static string filetitleForAssetIdee(this string assetIdee)
		=> filetitleForAssetPath(pathForAssetIdee(assetIdee));
	#endregion to filetitles


	#region to assets

	// method: return the asset of the specified type at the given asset path //
	public static AssetT atPathOfType<AssetT>(string assetPath) where AssetT : class
		=> AssetDatabase.LoadAssetAtPath(assetPath, typeof(AssetT)) as AssetT;
	#endregion to assets
	#endregion conversion
}
#endif