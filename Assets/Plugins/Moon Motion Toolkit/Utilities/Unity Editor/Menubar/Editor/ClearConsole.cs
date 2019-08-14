using System.Reflection;
using UnityEditor;
using UnityEngine;

// Clear Console:
// • provides a menubar command to clear the console
// • based on code from: https://answers.unity.com/questions/707636/clear-console-window.html
public static class ClearConsole
{
	[MenuItem("Status/Clear Console %q")]
	public static void clearConsole()
	{
		var assembly = Assembly.GetAssembly(typeof(SceneView));
		var type = assembly.GetType("UnityEditor.LogEntries");
		var method = type.GetMethod("Clear");
		method.Invoke(new object(), null);
	}
}