using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Pause: provides methods for playing things related to the editor //
public static class Play
{
	#if UNITY_EDITOR
	// method: play the editor //
	public static void editor()
		=> EditorApplication.ExecuteMenuItem("Edit/Play");
	#endif

	// method: (if in the editor:) play the system's beep sound //
	public static void beep_IfInEditor()
	{
		#if UNITY_EDITOR
		EditorApplication.Beep();
		#endif
	}

	/* (via reflection) */
	// method: play the given audio
	// reference: https://forum.unity.com/threads/reflected-audioutil-class-for-making-audio-based-editor-extensions.308133/
	public static void audio_IfInEditor(AudioClip audio)
	{
		#if UNITY_EDITOR
		System.Reflection.Assembly audioImporterAssembly = typeof(AudioImporter).Assembly;
		System.Type audioUtilityType = audioImporterAssembly.GetType("UnityEditor.AudioUtil");
		System.Reflection.MethodInfo method = audioUtilityType.GetMethod
		(
			"PlayClip",
			System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public,
			null,
			new System.Type[]
			{
				typeof(AudioClip),
				typeof(int),
				typeof(bool)
			},
			null
		);
		method.Invoke
		(
			null,
			new object[]
			{
				audio,
				0,
				false
			}
		);
		#endif
	}
	// method: play the audio asset at the given asset path //
	public static void audio_IfInEditor(string assetPath)
		=>	audio_IfInEditor
			(
				Asset.atAssetPathOfType<AudioClip>(assetPath)
			);
}