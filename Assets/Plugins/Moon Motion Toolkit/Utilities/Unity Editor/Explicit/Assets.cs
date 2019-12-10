#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

// Assets:
// • provides functionality for handling assets
// #assets
public static class Assets
{
	#region state


	#region window
	public static Type windowType_ViaReflection => EditorAssembly.classNamed("UnityEditor.ProjectBrowser");
	public static UnityEngine.Object ensuredWindow_ViaReflection
	{
		get
		{
			UnityEngine.Object[] assetsWindowsAlreadyOpen = Resources.FindObjectsOfTypeAll(windowType_ViaReflection);
			
			return	Any.itemsIn(assetsWindowsAlreadyOpen) ?
						assetsWindowsAlreadyOpen.first() :
						New.assetsWindow_ViaReflection;
		}
	}
	public static object treeViewControllerFor_ViaReflection(UnityEngine.Object assetsWindow)
		=> assetsWindow.valueOf(windowType_ViaReflection.nonpublicInstanceFieldNamed("m_FolderTree"));
	public static object ensuredWindowTreeViewController_ViaReflection
		=> treeViewControllerFor_ViaReflection(ensuredWindow_ViaReflection);
	public static object treeViewItemFor_ViaReflection(object treeViewController)
		=> TreeViews.itemFor_ViaReflection(instanceIdee, treeViewController);
	public const string columnationEnumPropertyName = "m_ViewMode";
	#endregion window
	
	#region filepathing
	public const string folderName = "Assets";
	public static string folderNameRess = folderName.ress();
	public const string projectPath = folderName;
	public const string assetAddress = "";
	public const string assetPath = "";
	public static string address = Project.filepath;
	public static string filepath = Project.filepathRess+folderName;
	public static string filepathRess = filepath.ress();
	#endregion filepathing

	#region assethood
	public static readonly UnityEngine.Object folder = Asset.folderAtAssetPath(assetPath);
	#endregion assethood

	#region instancing
	public static readonly int instanceIdee = folder.instanceIdee();
	#endregion instancing
	#endregion state








	#region accessing assets
	

	public static UnityEngine.Object first
		=> Asset.atAssetPathOfType<UnityEngine.Object>(Asset.pathForFirstAsset);
	
	// method: return the set of assets of the specified type corresponding to each of the given project paths //
	public static HashSet<AssetT> atProjectPathsOfType<AssetT>(IEnumerable<string> projectPaths) where AssetT : UnityEngine.Object
		=>	projectPaths.pickUnique(projectPath =>
				Asset.atProjectPathOfType<AssetT>(projectPath));

	// method: (via reflection:) return the set of assets of the specified type //
	public static HashSet<AssetT> ofType_ViaReflection<AssetT>() where AssetT : UnityEngine.Object
		=> atProjectPathsOfType<AssetT>(Project.pathsForAssetsOfType_ViaReflection<AssetT>());
	// method: (via reflection:) return the list of assets of the specified type //
	public static List<AssetT> manifestedOfType_ViaReflection<AssetT>() where AssetT : UnityEngine.Object
		=> ofType_ViaReflection<AssetT>().manifested();

	// method: (via reflection:) return the set of assets not from the Moon Motion Toolkit that are of the specified type //
	public static HashSet<AssetT> notFromMoonMotionToolkitOfType_ViaReflection<AssetT>() where AssetT : UnityEngine.Object
		=> atProjectPathsOfType<AssetT>(Project.pathsForNonMoonMotionToolkitAssetsOfType_ViaReflection<AssetT>());
	// method: (via reflection:) return the list of assets not from the Moon Motion Toolkit that are of the specified type //
	public static List<AssetT> notFromMoonMotionToolkitManifestedOfType_ViaReflection<AssetT>() where AssetT : UnityEngine.Object
		=> notFromMoonMotionToolkitOfType_ViaReflection<AssetT>().manifested();
	#endregion accessing assets








	#region methods




	#region window manipulation

	#region columnation mode switching
	public static void switchToTwoColumnsModeIn_ViaReflection(UnityEngine.Object assetsWindow)
	{
		if (assetsWindow.asSerializedObject().FindProperty(columnationEnumPropertyName).enumValueIndex != 1)
		{
			assetsWindow.invoke(windowType_ViaReflection.nonpublicInstanceMethodNamed("SetTwoColumns"));
		}
	}
	public static void switchToTwoColumnsMode_ViaReflection()
		=> switchToTwoColumnsModeIn_ViaReflection(ensuredWindow_ViaReflection);
	public static void switchToOneColumnModeIn_ViaReflection(UnityEngine.Object assetsWindow)
	{
		if (assetsWindow.asSerializedObject().FindProperty(columnationEnumPropertyName).enumValueIndex != 0)
		{
			assetsWindow.invoke(windowType_ViaReflection.nonpublicInstanceMethodNamed("SetOneColumn"));
		}
	}
	public static void switchToOneColumnMode_ViaReflection()
		=> switchToOneColumnModeIn_ViaReflection(ensuredWindow_ViaReflection);
	#endregion columnation mode switching

	#region folder opening
	public static void openFolder_ViaReflection(string folderAssetPath)
	{
		UnityEngine.Object assetsWindowToUse = ensuredWindow_ViaReflection;

		// switch the assets window to use to "two columns" mode (since that mode is necessary for opening folders) //
		switchToTwoColumnsModeIn_ViaReflection(assetsWindowToUse);
		
		assetsWindowToUse.invoke
		(
			windowType_ViaReflection.nonpublicInstanceMethodNamed("ShowFolderContents"),
			Instance.ideeForAssetPath(folderAssetPath), true
		);
	}
	public static void openFolder_ViaReflection()
		=> openFolder_ViaReflection("");
	#endregion folder opening

	// method: (via reflection:) collapse the assets (collapse all asset folders (those visible in the 'Project' window)) (– not including the 'Assets' folder)
	// reference: https://forum.unity.com/threads/collapse-all-folders-in-project-all-gameobjects-in-hierarchy-editor-script.502256/
    public static void collapse_ViaReflection()
	{
		object treeViewController = ensuredWindowTreeViewController_ViaReflection;
		object assetsTreeViewItem = treeViewItemFor_ViaReflection(treeViewController);
		MethodInfo method_ChangeExpandedState
			= TreeViews.controllerType_ViaReflection.nonpublicInstanceMethodNamed("ChangeExpandedState");
		treeViewController.invoke
		(
			method_ChangeExpandedState,
			assetsTreeViewItem, false, true
		);
		treeViewController.invoke
		(
			method_ChangeExpandedState,
			assetsTreeViewItem, true, false
		);
	}
	#endregion window manipulation


	#region ensuring assets
	
	public static void ensureFolderFor(string assetAddress)
	{
		if (!AssetDatabase.IsValidFolder(Assets.folderNameRess+assetAddress))
		{
			AssetDatabase.CreateFolder(Assets.folderName, assetAddress);
		}
	}
	#endregion ensuring assets
	#endregion methods
}
#endif