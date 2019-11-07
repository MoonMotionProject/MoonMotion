#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Focused: provides a property for the focused editor window //
public static class Focused
{
	public static EditorWindow window => EditorWindow.focusedWindow;
}
#endif