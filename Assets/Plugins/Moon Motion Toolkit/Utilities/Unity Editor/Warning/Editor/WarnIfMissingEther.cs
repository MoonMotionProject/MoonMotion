using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class WarnIfMissingEther
{
	static WarnIfMissingEther()
	{
		Execute.atNextCheck_IfInEditor(potentiallyWarn);
		Execute.atNextPlaymodeChange_IfInEditor(potentiallyWarn);
	}

	private static void potentiallyWarn()
	{
		if (!WhetherToNotWarnIfMissingEther.state && Hierarchy.allYullAndEnabledAndUnique<Ether>().isEmpty())
		{
			"There is no Ether in the hierarchy, so auto behaviour updating will not be called, and some methods will not work.\n(this warning can be disabled via the menubar)".print();
		}
	}
	private static void potentiallyWarn(PlayModeStateChange playModeStateChange)
		=> potentiallyWarn();
}