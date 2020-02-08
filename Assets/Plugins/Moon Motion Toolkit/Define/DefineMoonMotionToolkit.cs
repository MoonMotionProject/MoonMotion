#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// #defines
public static class DefineMoonMotionToolkit
{
    [InitializeOnLoadMethod]
	private static void ensureDefine()
		=> Build.ensureDefine("MOON_MOTION_TOOLKIT");
}
#endif