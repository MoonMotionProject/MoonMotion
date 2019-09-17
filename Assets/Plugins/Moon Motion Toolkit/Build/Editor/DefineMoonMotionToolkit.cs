using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class DefineMoonMotionToolkit
{
	static DefineMoonMotionToolkit()
	{
		Build.ensureDefine("MOON_MOTION_TOOLKIT");
	}
}