#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEngine;

// Clear Console:
// • provides a menubar command to clear the console
// • based on code from: https://answers.unity.com/questions/707636/clear-console-window.html
public static class ClearConsole
{
	[MenuItem("Status/Clear Console &%q")]
	public static void clearConsole()
	{
		Clear.console_ViaReflection();
	}
}
#endif