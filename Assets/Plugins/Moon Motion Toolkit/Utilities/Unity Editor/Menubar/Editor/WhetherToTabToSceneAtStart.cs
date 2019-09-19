using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Whether To Tab To Scene At Start:
// • determines whether Tab To Scene At Start runs
public static class WhetherToTabToSceneAtStart
{
	private const string menuItem = "At Start/Tab To Scene %#T";

	public static bool state => Menu.GetChecked(menuItem);

	[MenuItem(menuItem)]
	public static void toggleWhetherToTabToSceneAtStart()
		=> Menu.SetChecked(menuItem, !state);
}