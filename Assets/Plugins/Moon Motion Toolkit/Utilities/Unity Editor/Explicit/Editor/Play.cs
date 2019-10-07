using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Pause: provides methods for playing things related to the editor //
public static class Play
{
	// method: play the editor //
	public static void editor()
		=> EditorApplication.ExecuteMenuItem("Edit/Play");

	// method: play the system's beep sound //
	public static void beep()
		=> EditorApplication.Beep();
}