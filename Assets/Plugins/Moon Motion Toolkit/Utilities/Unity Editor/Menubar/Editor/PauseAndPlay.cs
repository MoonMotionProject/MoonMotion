using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Pause And Play:
// • provides a menubar command to pause the editor and then play the editor immediately afterward
public static class PauseAndPlay
{
	[MenuItem("Pause/And Play %L")]
	public static void pauseAndPlay()
	{
		Pause.editor();
		Play.editor();
	}
}