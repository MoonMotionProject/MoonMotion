#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

// Build:
// • provides properties related to the build
// #build #defines
public static class Build
{
	#region target

	public static BuildTarget target => EditorUserBuildSettings.activeBuildTarget;
	public static BuildTargetGroup targetGroup => EditorUserBuildSettings.selectedBuildTargetGroup;
	#endregion target


	#region paths

	public static string executablePath => EditorUserBuildSettings.GetBuildLocation(target);		// comes with forwardslashes delimiting folders until delimiting the build executable, in which case a backslash is delimiting
	public static string folderPath => executablePath.withoutCharactersFromFirstBackslash();
	#endregion paths


	#region defines

	public static List<string> defines => PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup).splitByEachSemicolon();

	public static bool includesDefine(string define)
		=> defines.contains(define);
	
	public static HashSet<string> setDefinesTo(IEnumerable<string> defines)
		=> defines.uniques().after(()=>
			PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, defines.joinBySemicolons()));

	/* disabled in favor Odin Inspector's implementation (which has been added instead below)
	// method: ensure that the build defines include the given define string, then return whether it was included before //
	public static bool ensureDefine(string define)
		=>	defines.contains(define) ?
				true :
				false.returnAnd(()=> setDefinesTo(defines.add(define)));*/
	public static void ensureDefine(string define)
    {
		var currentTarget = EditorUserBuildSettings.selectedBuildTargetGroup;

		if (currentTarget == BuildTargetGroup.Unknown)
		{
			return;
		}

		var definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(currentTarget).Trim();
		var defines = definesString.Split(';');

		if (defines.Contains(define) == false)
		{
			if (definesString.EndsWith(";", StringComparison.InvariantCulture) == false)
			{
				definesString += ";";
			}

			definesString += define;

			PlayerSettings.SetScriptingDefineSymbolsForGroup(currentTarget, definesString);
		}
    }

	// method: ensure that the build defines don't include the given define string, then return whether it was included before //
	public static bool ensureNoDefine(string define)
		=>	defines.contains(define) ?
				true.returnAnd(()=> setDefinesTo(defines.whereNot(define_ => define_.matches(define)))) :
				false;
	#endregion defines
}
#endif