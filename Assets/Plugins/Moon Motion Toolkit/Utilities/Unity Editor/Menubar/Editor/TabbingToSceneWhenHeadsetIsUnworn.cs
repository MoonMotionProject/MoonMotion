using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Tabbing To Scene When Headset Is Unworn:
// • according to a menubar toggle, does not \does tab to the Scene window when the headset is unworn
[InitializeOnLoad]
public static class TabbingToSceneWhenHeadsetIsUnworn
{
	#region event handling

	static TabbingToSceneWhenHeadsetIsUnworn()
	{
		EditorApplication.update += potentiallyTabToSceneForHeadsetUnwearing;
	}

	private static bool headsetApparentlyBeingWornPreviously = false;

	public static void potentiallyTabToSceneForHeadsetUnwearing()
	{
		if (!state)
		{
			if (headsetApparentlyBeingWornPreviously && Headset.isApparentlyNotBeingWorn)
			{
				TabTo.scene();
			}
		}

		headsetApparentlyBeingWornPreviously = Headset.isApparentlyBeingWorn;
	}
	#endregion event handling


	#region menubar toggle

	private const string menuItem = "Headset Tabbing/Do Not Tab To Scene When Headset Is Unworn";

	public static bool state => Menu.GetChecked(menuItem);

	[MenuItem(menuItem)]
	public static void toggleWhetherToNotTabToSceneWhenHeadsetIsUnworn()
		=> Menu.SetChecked(menuItem, !state);
	#endregion menubar toggle
}