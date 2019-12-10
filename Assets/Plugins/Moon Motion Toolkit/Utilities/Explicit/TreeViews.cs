using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

// #reflection
public static class TreeViews
{
	public static readonly Type controllerType_ViaReflection
		= EditorAssembly.classNamed("UnityEditor.IMGUI.Controls.TreeViewController");
	public static readonly Type dataSourceType_ViaReflection
		= EditorAssembly.classNamed("UnityEditor.IMGUI.Controls.TreeViewDataSource");
	public static readonly Type gameObjectDataSourceType_ViaReflection
		= EditorAssembly.classNamed("UnityEditor.GameObjectTreeViewDataSource");
	
	public static object itemFor_ViaReflection(int instanceIdee, object treeViewController)
		=>	treeViewController.invokeGetResult
			(
				controllerType_ViaReflection.nonpublicInstanceMethodNamed("GetItemAndRowIndex"),
				instanceIdee, null
			);

	public static readonly PropertyInfo property_data
		= controllerType_ViaReflection.publicInstancePropertyNamed("data");
	public static object dataOf_ViaReflection(object treeViewController)
		=> treeViewController.valueOf(property_data);
	public static bool expansionOf_ViaReflection(int instanceIdee, object treeViewController)
		=>	dataOf_ViaReflection(treeViewController).invokeGetResult
			(
				dataSourceType_ViaReflection.methodNamed
				(
					"IsExpanded",
					typeof(int)
				),
				instanceIdee
			).castTo<bool>();
}