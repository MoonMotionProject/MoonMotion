using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviours: tracks all enabled auto behaviours //
public static class AutoBehaviours
{
	public static HashSet<IAutoBehaviour> enabled = new HashSet<IAutoBehaviour>();
	public static HashSet<IAutoBehaviour> enabledsCopy => enabled.copy();
}