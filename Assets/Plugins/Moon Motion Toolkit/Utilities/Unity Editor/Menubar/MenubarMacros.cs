#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

// Menubar Macros:
// • provides various editor macros as menubar operations
public static class MenubarMacros
{
	[MenuItem("Macros/Clear Console %q")]
	public static void clearConsole()
		=> Clear.console_ViaReflection();
	
	[MenuItem("Macros/Freshen Layout %w")]
	public static void freshenLayout()
	{
		Clear.console_ViaReflection();
		Assets.collapse_ViaReflection();
		Assets.openFolder_ViaReflection();
		Hierarchy.collapseAllObjects();
		Deselect.all();
		AutoBehaviours.validateAllInHierarchy();
	}

	[MenuItem("Macros/Create New Object (at origin) %e")]		// (and select it)
	public static void createNewObject()
		=> New.gameObject.select_IfInEditor();
	
	[MenuItem("Macros/Open Build Folder &%#b")]
	public static void openBuildFolder()
		=> Application.OpenURL("file://"+Build.folderPath);

	[MenuItem("Macros/Launch Build Executable &%b")]
	public static void launchBuildExecutable()
		=> Application.OpenURL("file://"+Build.executablePath);
}
#endif