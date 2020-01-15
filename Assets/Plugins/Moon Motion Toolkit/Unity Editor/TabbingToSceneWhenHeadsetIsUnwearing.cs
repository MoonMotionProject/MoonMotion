#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Tabbing To Scene When Headset Is Unwearing:
// • according to a menubar toggle, does not \does tab to the Scene window when the headset is unworn
// • Pausing When Headset Is Unwearing gives a chance to potentially tab to scene for headset unwearing before pausing
[InitializeOnLoad]
public static class TabbingToSceneWhenHeadsetIsUnwearing
{
	#region event handling
	
	static TabbingToSceneWhenHeadsetIsUnwearing()
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

	private const string menuItem = "Headset Tabbing/Do Not Tab To Scene When Headset Is Unwearing";

	public static bool state => Menu.GetChecked(menuItem);

	[MenuItem(menuItem)]
	public static void toggleWhetherToNotTabToSceneWhenHeadsetIsUnwearing()
		=> Menu.SetChecked(menuItem, !state);
	#endregion menubar toggle
}
#endif