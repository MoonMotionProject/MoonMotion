using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Deselect At Start:
// • at the start, deselects the (entire current) selection
//   · this happens optionally based on (the opposite state of) Whether To Not Deselect At Start
[InitializeOnLoad]
public static class DeselectAtStart
{
	static DeselectAtStart()
	{
		Execute.atNextPlaymodeChange_IfInEditor(deselect);
	}

	private static void deselect(PlayModeStateChange playModeStateChange)
	{
		if (!WhetherToNotDeselectAtStart.state && (playModeStateChange == PlayModeStateChange.EnteredPlayMode))
		{
			Deselect.all();
		}
	}
}