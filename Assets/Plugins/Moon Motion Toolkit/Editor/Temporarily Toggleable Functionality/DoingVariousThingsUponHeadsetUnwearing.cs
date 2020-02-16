using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Doing Various Things Upon Headset Unwearing:
// • upon the headset unwearing (being taken off), does various things
//   · these things happen optionally based on the corresponding menu settings
[InitializeOnLoad]
public static class DoingVariousThingsUponHeadsetUnwearing
{
	static DoingVariousThingsUponHeadsetUnwearing()
	{
		Execute.atNextEditorCheckAndEveryCheckAfter(doVariousThingsForHeadsetUnwearing);
	}
	
	private static bool headsetApparentlyBeingWornPreviously = false;
	
	private static void doVariousThingsForHeadsetUnwearing()
	{
		if (headsetApparentlyBeingWornPreviously && Headset.isApparentlyNotBeingWorn)
		{
			if (MoonMotionProjectMenubar.doTabToSceneUponHeadsetUnwearing)
			{
				TabTo.scene();		// give this a chance to execute first
			}
			if (UnityIs.playing && MoonMotionProjectMenubar.doPauseIfPlayingUponHeadsetUnwearing)
			{
				Pause.editor();
			}
		}
			
		headsetApparentlyBeingWornPreviously = Headset.isApparentlyBeingWorn;
	}
}