#if MOON_MOTION_TOOLKIT
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Pausing When Headset Is Unwearing:
// • according to a menubar toggle, pauses when the headset is unwearing
// • gives Tabbing To Scene When Headset Is Unworn a chance to execute first
[InitializeOnLoad]
public static class PausingWhenHeadsetIsUnwearing
{
	#region event handling
	
	static PausingWhenHeadsetIsUnwearing()
	{
		EditorApplication.update += potentiallyPauseForHeadsetUnwearing;
	}
	
	private static bool headsetApparentlyBeingWornPreviously = false;
	
	private static void potentiallyPauseForHeadsetUnwearing()
	{
		if (UnityIs.inEditorPlayMode)
		{
			if (state)
			{
				if (headsetApparentlyBeingWornPreviously && Headset.isApparentlyNotBeingWorn)
				{
					// pause, but give Tabbing To Scene When Headset Is Unworn a chance to execute first //
					TabbingToSceneWhenHeadsetIsUnwearing.potentiallyTabToSceneForHeadsetUnwearing();
					Pause.editor();
				}
			}
			
			headsetApparentlyBeingWornPreviously = Headset.isApparentlyBeingWorn;
		}
	}
	#endregion event handling
	
	
	#region menubar toggle
	
	private const string menuItem = "Pause/When Headset Is Unwearing";
	
	public static bool state => Menu.GetChecked(menuItem);
	
	[MenuItem(menuItem)]
	public static void toggleWhetherToNotPauseWhenHeadsetIsUnwearing()
		=> Menu.SetChecked(menuItem, !state);
	#endregion menubar toggle
}
#endif
#endif