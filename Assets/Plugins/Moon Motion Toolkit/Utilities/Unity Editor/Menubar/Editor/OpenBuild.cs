using System.Reflection;
using UnityEditor;
using UnityEngine;

// Menubar Build:
// • provides menubar commands to:
//   · open the build folder
//   · launch the build executable
public static class MenubarBuild
{
	[MenuItem("Build/Open Folder &%#b")]
	public static void openFolder()
		=> Application.OpenURL("file://"+Build.folderPath);

	[MenuItem("Build/Launch Executable &%b")]
	public static void launchExecutable()
		=> Application.OpenURL("file://"+Build.executablePath);
}