using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviours: tracks all enabled auto behaviours //
public static class AutoBehaviours
{
	public static HashSet<IAutoBehaviour> enabled_IfPlaying = New.setOf<IAutoBehaviour>();
	public static HashSet<IAutoBehaviour> enabled_IfPlaying_Copy => enabled_IfPlaying.copy();
}