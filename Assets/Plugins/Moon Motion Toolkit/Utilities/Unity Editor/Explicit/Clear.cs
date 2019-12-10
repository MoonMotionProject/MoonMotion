#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

// Clear: provides methods for clearing things //
public static class Clear
{
	// method: clear the console
	// reference: https://answers.unity.com/questions/707636/clear-console-window.html
	public static void console_ViaReflection()
		=> New.genericObject.invoke(typeof(SceneView).assembly().classNamed("UnityEditor.LogEntries").methodNamed("Clear"));
}
#endif