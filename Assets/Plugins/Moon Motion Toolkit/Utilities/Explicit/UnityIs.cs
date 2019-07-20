using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity Is: provides properties for determing context within Unity //
public static class UnityIs
{
	public static bool inEditor => Application.isEditor;
	public static bool inBuild => !inEditor;
	public static bool playing => Application.isPlaying;
	public static bool inEditorPlayMode => inEditor.and(playing);
	public static bool inEditorEditMode => inEditor.butNot(playing);
}