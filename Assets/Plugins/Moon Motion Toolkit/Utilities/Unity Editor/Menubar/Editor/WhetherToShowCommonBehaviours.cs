using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Whether To Show Common Behaviours:
// • determines whether common behaviours are shown in the inspector
[InitializeOnLoad]
public static class WhetherToShowCommonBehaviours
{
	private const string menuItem = "Common Behaviours/Show";

	public static void setCheckednessTo(bool boolean)
		=> Menu.SetChecked(menuItem, boolean);

	static WhetherToShowCommonBehaviours()
	{
		EditorApplication.delayCall += ()=> setCheckednessTo(Build.includesDefine(define));
	}

	public static bool state => Menu.GetChecked(menuItem);

	private const string define = "MOON_MOTION_TOOLKIT_SHOW_COMMON_BEHAVIOURS";
	
	[MenuItem(menuItem)]
	public static void toggleWhetherToShowCommonBehaviours()
	{
		setCheckednessTo(!state);
		if (state)
		{
			Build.ensureDefine(define);
		}
		else
		{
			Build.ensureNoDefine(define);
		}
	}
}