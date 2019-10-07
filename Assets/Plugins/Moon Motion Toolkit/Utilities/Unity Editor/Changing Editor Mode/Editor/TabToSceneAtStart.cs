using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Tab To Scene At Start:
// • at the start, tabs to the Scene window (so as to not annoyingly switch to the Game window)
//   · this happens optionally based on Whether To Tab To Scene At Start
[InitializeOnLoad]
public static class TabToSceneAtStart
{
	static TabToSceneAtStart()
	{
		EditorApplication.playModeStateChanged += tabToScene;
	}

	private static void tabToScene(PlayModeStateChange playModeStateChange)
	{
		if (WhetherToTabToSceneAtStart.state && (playModeStateChange == PlayModeStateChange.EnteredPlayMode))
		{
			TabTo.scene();
		}
	}
}