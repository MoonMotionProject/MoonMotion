using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Build: provides constants related to the build //
public static class Build
{
	public static BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
	public static BuildTargetGroup targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;

	public static string executablePath => EditorUserBuildSettings.GetBuildLocation(target);		// comes with forwardslashes delimiting folders until delimiting the build executable, in which case a backslash is delimiting
	public static string folderPath => executablePath.withoutCharactersFromFirstBackslash();
}