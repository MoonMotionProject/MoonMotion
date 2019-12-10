#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Tabbing To Game When Headset Is Worn:
// • according to a menubar toggle, does\ does not tab to the Game window when the headset is worn
[InitializeOnLoad]
public static class TabbingToGameWhenHeadsetIsWorn
{
	#region event handling

	static TabbingToGameWhenHeadsetIsWorn()
	{
		EditorApplication.update += potentiallyTabToGameForHeadsetBeingWorn;
	}

	private static void potentiallyTabToGameForHeadsetBeingWorn()
	{
		if (state)
		{
			if (Headset.isApparentlyBeingWorn)
			{
				TabTo.game();
			}
		}
	}
	#endregion event handling


	#region menubar toggle

	private const string menuItem = "Headset Tabbing/Tab To Game When Headset Is Worn";

	public static bool state => Menu.GetChecked(menuItem);

	[MenuItem(menuItem)]
	public static void toggleWhetherToTabToGameWhenHeadsetIsWorn()
		=> Menu.SetChecked(menuItem, !state);
	#endregion menubar toggle
}
#endif