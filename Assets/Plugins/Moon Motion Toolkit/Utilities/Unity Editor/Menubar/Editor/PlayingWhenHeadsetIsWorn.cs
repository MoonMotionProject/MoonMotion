using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Playing When Headset Is Worn:
// • according to a menubar toggle, plays when the headset is worn
[InitializeOnLoad]
public static class PlayingWhenHeadsetIsWorn
{
	#region event handling

	static PlayingWhenHeadsetIsWorn()
	{
		EditorApplication.update += potentiallyPlayForHeadsetBeingWorn;
	}

	private static void potentiallyPlayForHeadsetBeingWorn()
	{
		if (UnityIs.inEditorEditMode)
		{
			if (state)
			{
				if (Headset.isApparentlyBeingWorn)
				{
					Play.editor();
				}
			}
		}
	}
	#endregion event handling


	#region menubar toggle

	private const string menuItem = "Play/When Headset Is Worn";

	public static bool state => Menu.GetChecked(menuItem);

	[MenuItem(menuItem)]
	public static void toggleWhetherToPlayWhenHeadsetIsWorn()
		=> Menu.SetChecked(menuItem, !state);
	#endregion menubar toggle
}