#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

// Layout:
// • provides properties and methods for handling the editor layout
// #layouts
public static class Layout
{
	public static Type type => "UnityEditor.WindowLayout,UnityEditor".asClassNameToType();

	public static void saveAs(string assetName, string assetAddress = "Layouts")
	{
		Assets.ensureFolderFor(assetAddress);
		
		string assetPath = Asset.pathFor(assetName+".asset", assetAddress);

		type.GetMethod
		(
			"SaveWindowLayout",
			BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static,
			null,
			new Type[]
			{
				typeof(string)
			},
			null
		).Invoke
		(
			null,
			new object[]
			{
				Filepath.forAssetPath(assetPath)
			}
		);

		Import.asset(assetPath);
	}
	
	public static void load(string assetName, string assetAddress = "Layouts")
	{
		type.GetMethod
		(
			"LoadWindowLayout",
			BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static,
			null,
			new Type[]
			{
				typeof(string),
				typeof(bool)
			},
			null
		).Invoke
		(
			null,
			new object[]
			{
				Filepath.forAsset(assetName+".asset", assetAddress),
				false
			}
		);
	}
	
	public static void reloadAs(string assetName, string assetAddress = "Layouts")
	{
		saveAs(assetName, assetAddress);
		load(assetName, assetAddress);
	}
	
	public static void reload(string assetAddress = "Layouts")
		=> reloadAs("Last Reloaded Layout");
}
#endif