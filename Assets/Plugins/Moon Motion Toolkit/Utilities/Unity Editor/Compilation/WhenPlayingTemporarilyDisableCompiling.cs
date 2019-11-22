#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// #compilation
[InitializeOnLoad]
public static class WhenPlayingTemporarilyDisableCompiling
{
	static WhenPlayingTemporarilyDisableCompiling()
	{
		EditorApplication.playModeStateChanged += playModeStateChange =>
		{
			if (playModeStateChange == PlayModeStateChange.EnteredPlayMode)
			{
				EditorApplication.LockReloadAssemblies();
			}
			else if (playModeStateChange == PlayModeStateChange.ExitingPlayMode)
			{
				EditorApplication.UnlockReloadAssemblies();
			}
		};
	}
}
#endif