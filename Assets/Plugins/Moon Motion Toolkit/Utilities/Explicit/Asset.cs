#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Asset: provides methods for handling assets (see also: 'AssetFile.cs') //
public static class Asset
{
	#region filtering all asset idees

	// method: return an array of asset idees for all assets filtered by the given filter string //
	public static string[] ideesFilteredBy(string filterString)
		=> AssetDatabase.FindAssets(filterString);

	// method: return an array of script asset idees for all script assets filtered by the given filter string //
	public static string[] scriptIdeesFilteredBy(string filterString)
		=> ideesFilteredBy(filterString+" t:script");
	#endregion filtering all asset idees




	#region conversion


	#region to idees

	// method: return the asset idee of the script asset with the given simple class name, if any asset matches (otherwise returning null) //
	public static string ideeForSimpleClassName(string simpleClassName)
	{
		string[] filteredScriptAssetIdees = scriptIdeesFilteredBy(simpleClassName);

		if (Any.itemsIn(filteredScriptAssetIdees))
		{
			string matchingAssetIdee = Exactly.oneIn(filteredScriptAssetIdees) ?
											filteredScriptAssetIdees.first() :
											filteredScriptAssetIdees.isPlural() ?
												filteredScriptAssetIdees.firstWhere(assetIdee =>
					AssetFile.titleForAssetIdee(assetIdee).matches(simpleClassName)) :
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

	// method: return the asset path of the asset for the given asset idee //
	public static string pathForAssetIdee(string assetIdee)
		=> AssetDatabase.GUIDToAssetPath(assetIdee);

	// method: return the asset path of the script asset with the given simple class name //
	public static string pathForSimpleClassName(string simpleClassName)
		=> pathForAssetIdee(ideeForSimpleClassName(simpleClassName));

	// method: return the asset path of the script asset with the given script asset type (class of a script asset) //
	public static string pathForScriptAssetType(Type scriptAssetType)
		=> pathForSimpleClassName(scriptAssetType.simpleClassName());
	
	// method: return the asset path of the given mono behaviour's script asset //
	public static string pathForMonoBehaviour(MonoBehaviour monoBehaviour)
		=> AssetDatabase.GetAssetPath(monoBehaviour.asScript());
	#endregion to asset paths
	#endregion conversion
}
#endif