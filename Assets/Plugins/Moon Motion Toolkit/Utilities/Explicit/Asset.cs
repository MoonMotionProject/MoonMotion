#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
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
					filenameForAssetIdee(assetIdee).matches(simpleClassName)) :
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


	#region to filetitles

	// method: return the asset filetitle for the given project path //
	public static string filetitleForProjectPath(string projectPath)
		=> System.IO.Path.GetFileName(projectPath);

	// method: return the asset filetitle for the given asset idee //
	public static string filetitleForAssetIdee(this string assetIdee)
		=> filetitleForProjectPath(Project.pathForAssetIdee(assetIdee));
	#endregion to filetitles


	#region to filenames

	// method: return the asset filename for the given project path //
	public static string filenameForProjectPath(this string projectPath)
		=> System.IO.Path.GetFileNameWithoutExtension(projectPath);

	// method: return the asset filename for the given asset idee //
	public static string filenameForAssetIdee(this string assetIdee)
		=> filenameForProjectPath(Project.pathForAssetIdee(assetIdee));
	#endregion to filenames


	#region to assets

	// method: return the asset of the specified type at the given project path //
	public static AssetT atProjectPathOfType<AssetT>(string projectPath) where AssetT : class
		=> AssetDatabase.LoadAssetAtPath(projectPath, typeof(AssetT)) as AssetT;

	// method: return the asset of the specified type at the given asset path //
	public static AssetT atAssetPathOfType<AssetT>(string assetPath) where AssetT : class
		=> atProjectPathOfType<AssetT>(Project.pathFor(assetPath));
	#endregion to assets


	#region to asset paths
	
	// method: return the asset path for the asset with the given title at the given asset address //
	public static string pathFor(string assetTitle, string assetAddress)
		=> assetAddress.ress()+assetTitle;
	#endregion to asset paths
	#endregion conversion
}
#endif