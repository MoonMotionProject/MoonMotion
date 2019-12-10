using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif
using UnityEngine;

// Project: provides members for the project //
public static class Project
{
	#region constants
	

	#if UNITY_EDITOR
	public static string filepath => Directory.GetCurrentDirectory();
	public static string filepathRess => filepath.ress();
	#endif
	
	#region name
	public static string name => Application.productName;
	public static string nameWithoutSpaces => name.withoutSpaces();
	#endregion name
	
	public static string company => Application.companyName;
	#endregion constants




	#region filtering all project paths
	#if UNITY_EDITOR


	// method: return the set of project paths for all assets filtered by the given filter string //
	public static HashSet<string> pathsForAssetsFilteredBy(string filterString)
		=> Asset.ideesForAssetsFilteredBy(filterString).pickUnique(idee => pathForAssetIdee(idee));
	public static HashSet<string> pathsForAssets => pathsForAssetsFilteredBy("");

	// method: (via reflection:) return the set of project paths for all assets of the specified type //
	public static HashSet<string> pathsForAssetsOfType_ViaReflection<AssetT>() where AssetT : class
		=> pathsForAssetsFilteredBy("t:"+typeof(AssetT).simpleClassName_ViaReflection());

	// method: (via reflection:) return the set of project paths for all assets of the specified type //
	public static HashSet<string> pathsForNonMoonMotionToolkitAssetsOfType_ViaReflection<AssetT>() where AssetT : class
		=>	pathsForAssetsOfType_ViaReflection<AssetT>()
				.uniquesWhere(assetPath => assetPath.doesNotContain(MoonMotion.toolkitName));

	// method: return the set of script project paths for all script assets filtered by the given filter string //
	public static HashSet<string> pathsForScriptAssetsFilteredBy(string filterString)
		=> Asset.ideesForScriptAssetsFilteredBy(filterString).pickUnique(idee => pathForAssetIdee(idee));
	public static HashSet<string> pathsForScriptAssets => pathsForScriptAssetsFilteredBy("");

	// method: return the set of prefab project paths for all prefab assets filtered by the given filter string //
	public static HashSet<string> pathsForPrefabAssetsFilteredBy(string filterString)
		=> Asset.ideesForPrefabAssetsFilteredBy(filterString).pickUnique(idee => pathForAssetIdee(idee));
	public static HashSet<string> pathsForPrefabAssets => pathsForPrefabAssetsFilteredBy("");
	#endif
	#endregion filtering all project paths




	#region conversion
	

	#region to project paths
	#if UNITY_EDITOR

	// method: return the project path for the asset with the given title at the given asset address //
	public static string pathFor(string assetPath)
		=> Assets.folderName.withPotentialRessingSuffix(assetPath);

	// method: return the project path for the asset with the given title at the given asset address //
	public static string pathFor(string assetTitle, string assetAddress)
		=> pathFor(assetAddress.ress()+assetTitle);
	
	// method: return the project path of the given asset Unity object //
	public static string pathForAsset(UnityEngine.Object assetUnityObject)
		=> AssetDatabase.GetAssetPath(assetUnityObject);
	
	// method: return the project path of the given mono behaviour's script asset //
	public static string pathForMonoBehaviour(MonoBehaviour monoBehaviour)
		=> pathForAsset(monoBehaviour.asScript());

	// method: return the project path of the asset for the given asset idee //
	public static string pathForAssetIdee(string assetIdee)
		=> AssetDatabase.GUIDToAssetPath(assetIdee);

	// method: return the project path of the script asset with the given simple class name //
	public static string pathForSimpleClassName(string simpleClassName)
		=> pathForAssetIdee(Asset.ideeForSimpleClassName(simpleClassName));

	// method: (via reflection:) return the project path of the script asset with the given script asset type (class of a script asset) //
	public static string pathForScriptAssetType_ViaReflection(Type scriptAssetType)
		=> pathForSimpleClassName(scriptAssetType.simpleClassName_ViaReflection());
	#endif
	#endregion to project paths
	#endregion conversion
}
