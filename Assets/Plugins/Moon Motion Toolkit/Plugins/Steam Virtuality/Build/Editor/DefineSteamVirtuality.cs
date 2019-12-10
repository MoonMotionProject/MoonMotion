using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// #defines
public static class DefineSteamVirtuality
{
	[InitializeOnLoadMethod]
	private static void ensureDefine()
		=> Build.ensureDefine("STEAM_VIRTUALITY");
}