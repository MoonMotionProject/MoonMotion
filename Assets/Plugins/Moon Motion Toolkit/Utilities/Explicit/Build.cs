using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Build: provides properties related to the build //
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

	public static List<string> setDefinesTo(List<string> defines)
		=> defines.after(()=>
			PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, defines.joinBySemicolons()));

	// method: ensure that the build defines include the given define string, then return whether it was included before //
	public static bool ensureDefine(string define)
		=> defines.contains(define) ?
			true :
			false.after(()=> setDefinesTo(defines.add(define)));

	// method: ensure that the build defines don't include the given define string, then return whether it was included before //
	public static bool ensureNoDefine(string define)
		=> defines.contains(define) ?
			true.after(()=> setDefinesTo(defines.whereNot(define_ => define_.matches(define)))) :
			false;
	#endregion defines
}