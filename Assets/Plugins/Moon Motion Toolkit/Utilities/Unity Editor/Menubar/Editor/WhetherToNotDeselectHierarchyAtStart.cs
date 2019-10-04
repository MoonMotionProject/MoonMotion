using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Whether To Not Deselect Hierarchy At Start:
// • determines whether Deselect Hierarchy At Start does not run
[InitializeOnLoad]
public static class WhetherToNotDeselectHierarchyAtStart
{
	private const string menuItem = "At Start/Do Not Deselect Hierarchy &%#T";

	public static bool state => Menu.GetChecked(menuItem);

	[MenuItem(menuItem)]
	public static void toggleWhetherToNotDeselectHierarchyAtStart()
		=> Menu.SetChecked(menuItem, !state);
}