#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Editor Window Extensions:
// • provides extension methods for handling editor windows
public static class EditorWindowExtensions
{
	// method: show this given editor window, then return it //
	public static EditorWindow show(this EditorWindow editorWindow)
		=>	editorWindow.after(()=>
				editorWindow.Show());
}
#endif