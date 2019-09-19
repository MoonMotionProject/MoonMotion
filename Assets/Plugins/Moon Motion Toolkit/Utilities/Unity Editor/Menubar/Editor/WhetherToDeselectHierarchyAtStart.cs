using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Whether To Deselect Hierarchy At Start:
// • determines whether Deselect Hierarchy At Start runs
[InitializeOnLoad]
public static class WhetherToDeselectHierarchyAtStart
{
	private const string menuItem = "At Start/Deselect Hierarchy &%#T";

	public static bool state => Menu.GetChecked(menuItem);

	[MenuItem(menuItem)]
	public static void toggleWhetherToDeselectHierarchyAtStart()
		=> Menu.SetChecked(menuItem, !state);
}