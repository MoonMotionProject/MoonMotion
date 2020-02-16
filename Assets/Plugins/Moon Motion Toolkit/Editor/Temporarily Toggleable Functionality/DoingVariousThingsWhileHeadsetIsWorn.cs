using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Doing Various Things While Headset Is Worn:
// • while the headset is worn, does various things
//   · these things happen optionally based on the corresponding menu settings
[InitializeOnLoad]
public static class DoingVariousThingsWhileHeadsetIsWorn
{
	static DoingVariousThingsWhileHeadsetIsWorn()
	{
		Execute.atNextEditorCheckAndEveryCheckAfter(doVariousThingsForHeadsetBeingWorn);
	}
	
	private static void doVariousThingsForHeadsetBeingWorn()
	{
		if (Headset.isApparentlyBeingWorn)
		{
			if (MoonMotionProjectMenubar.doTabToGameWhileHeadsetIsWorn)
			{
				TabTo.game();
			}
			if (UnityIs.notPlaying && MoonMotionProjectMenubar.doPlayWhileHeadsetIsWorn)
			{
				Play.editor();
			}
		}
	}
}