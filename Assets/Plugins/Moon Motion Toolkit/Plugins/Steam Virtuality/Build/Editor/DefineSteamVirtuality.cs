using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class DefineSteamVirtuality
{
	static DefineSteamVirtuality()
	{
		Build.ensureDefine("STEAM_VIRTUALITY");
	}
}