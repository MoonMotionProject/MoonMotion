#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Whether To Not Deselect At Start:
// • determines whether Deselect At Start does not run
[InitializeOnLoad]
public static class WhetherToNotDeselectAtStart
{
	private const string menuItem = "At Start/Do Not Deselect &%#T";

	public static bool state => Menu.GetChecked(menuItem);

	[MenuItem(menuItem)]
	public static void toggleWhetherToNotDeselectAtStart()
		=> Menu.SetChecked(menuItem, !state);
}
#endif