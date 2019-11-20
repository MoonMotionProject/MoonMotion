#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEngine;

// Clear Console:
// • provides a menubar command to clear the console and deselect
public static class ClearConsoleAndDeselect
{
	[MenuItem("Status/Clear Console And Deselect %q")]
	public static void clearConsoleAndDeselect()
	{
		Clear.console_ViaReflection();
		Hierarchy.deselect();
	}
}
#endif