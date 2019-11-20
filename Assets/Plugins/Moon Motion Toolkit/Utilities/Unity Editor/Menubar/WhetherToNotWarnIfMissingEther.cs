#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class WhetherToNotWarnIfMissingEther
{
	private const string menuItem = "Ether/Do Not Warn If Missing";

	public static bool state => Menu.GetChecked(menuItem);

	[MenuItem(menuItem)]
	public static void toggleWhetherToWarnIfMissing()
		=> Menu.SetChecked(menuItem, !state);
}
#endif