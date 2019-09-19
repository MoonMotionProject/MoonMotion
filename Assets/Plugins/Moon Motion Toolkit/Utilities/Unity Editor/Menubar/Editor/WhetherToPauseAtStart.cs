using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Whether To Pause At Start:
// • determines whether Pause At Start runs
public static class WhetherToPauseAtStart
{
	private const string menuItem = "At Start/Pause %#L";

	public static bool state => Menu.GetChecked(menuItem);

	[MenuItem(menuItem)]
	public static void toggleWhetherToPauseAtStart()
		=> Menu.SetChecked(menuItem, !state);
}