using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Pause At Start:
// • at the start, pauses the editor
//   · this happens optionally based on Whether To Pause At Start
[InitializeOnLoad]
public static class PauseAtStart
{
	static PauseAtStart()
	{
		EditorApplication.playModeStateChanged += pause;
	}

	private static void pause(PlayModeStateChange playModeStateChange)
	{
		if (WhetherToPauseAtStart.state && (playModeStateChange == PlayModeStateChange.EnteredPlayMode))
		{
			Pause.editor();
		}
	}
}