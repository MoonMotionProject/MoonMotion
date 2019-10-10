using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Playing When Headset Is Unworn:
// • according to a menubar toggle, does not \does pause when the headset is unworn
[InitializeOnLoad]
public static class PausingWhenHeadsetIsUnworn
{
	#region event handling

	static PausingWhenHeadsetIsUnworn()
	{
		EditorApplication.update += potentiallyPauseForHeadsetUnwearing;
	}

	private static bool headsetApparentlyBeingWornPreviously = false;

	private static void potentiallyPauseForHeadsetUnwearing()
	{
		if (UnityIs.inEditorPlayMode)
		{
			if (!state)
			{
				if (headsetApparentlyBeingWornPreviously && Headset.isApparentlyNotBeingWorn)
				{
					TabbingToSceneWhenHeadsetIsUnworn.potentiallyTabToSceneForHeadsetUnwearing();		// give Tabbing To Scene When Headset Is Unworn a chance to execute first
					Pause.editor();
				}
			}

			headsetApparentlyBeingWornPreviously = Headset.isApparentlyBeingWorn;
		}
	}
	#endregion event handling


	#region menubar toggle

	private const string menuItem = "Pause/Do Not Pause When Headset Is Unwearing";

	public static bool state => Menu.GetChecked(menuItem);

	[MenuItem(menuItem)]
	public static void toggleWhetherToNotPauseWhenHeadsetIsUnwearing()
		=> Menu.SetChecked(menuItem, !state);
	#endregion menubar toggle
}