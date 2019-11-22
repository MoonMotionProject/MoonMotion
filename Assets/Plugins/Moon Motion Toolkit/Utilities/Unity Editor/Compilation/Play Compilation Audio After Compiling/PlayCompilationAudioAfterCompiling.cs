#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// #compilation
[InitializeOnLoad]
public static class PlayCompilationAudioAfterCompiling
{
	static PlayCompilationAudioAfterCompiling()
	{
		Play.audio_IfInEditor("Plugins\\Moon Motion Toolkit\\Utilities\\Unity Editor\\Compilation\\Play Compilation Audio After Compiling\\Compilation Audio.wav");
	}
}
#endif