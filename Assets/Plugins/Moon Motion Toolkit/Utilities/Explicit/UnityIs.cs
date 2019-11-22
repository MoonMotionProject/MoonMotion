using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Unity Is: provides properties for determing context within Unity //
public static class UnityIs
{
	public static bool inEditor => Application.isEditor;
	public static bool inBuild => !inEditor;
	public static bool playing => Application.isPlaying;
	public static bool notPlaying => !playing;
	public static bool inEditorPlayMode => inEditor.and(playing);
	public static bool inEditorEditMode => inEditor.and(notPlaying);
	#if UNITY_EDITOR
	public static bool paused => EditorApplication.isPaused;
	public static bool unpaused => !paused;
	#else
	public static bool paused => false;
	public static bool unpaused => true;
	#endif
	public static bool playingPaused => playing.and(paused);
	public static bool playingUnpaused => playing.and(unpaused);
	#if UNITY_EDITOR
	public static bool compiling => EditorApplication.isCompiling;
	#endif
}