#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

// Layout: provides properties and methods for handling the editor layout //
public static class Layout
{
	public static Type type => Type.GetType("UnityEditor.WindowLayout,UnityEditor");

	public static void saveAs(string assetName, string assetAddress = "Layouts")
	{
		Assets.ensureFolderForAddress(assetAddress);
		
		string assetTitle = assetName+".asset";

		type.GetMethod
		(
			"SaveWindowLayout",
			BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static,
			null,
			new Type[] {typeof(string)},
			null
		).Invoke
		(
			null,
			new object[]
			{
				Address.forAssetAddress(assetAddress)+"\\"+assetTitle
			}
		);

		Import.assetTitled(assetTitle, assetAddress);
	}
	
	public static void load(string assetName, string assetAddress = "Layouts")
	{
		type.GetMethod
		(
			"LoadWindowLayout",
			BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static,
			null,
			new Type[] {typeof(string), typeof(bool)},
			null
		).Invoke
		(
			null,
			new object[]
			{
				Address.forAssetAddress(assetAddress)+"\\"+assetName+".asset",
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