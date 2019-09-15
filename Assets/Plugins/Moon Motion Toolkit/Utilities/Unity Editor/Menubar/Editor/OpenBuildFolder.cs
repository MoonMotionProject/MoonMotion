using System.Reflection;
using UnityEditor;
using UnityEngine;

// Open Build Folder:
// • provides a menubar command to open the build folder
public static class OpenBuildFolder
{
	[MenuItem("Explorer/Open Build Folder &%#b")]
	public static void openBuildFolder()
		=> Application.OpenURL("file://"+Product.buildFolderPath);
}