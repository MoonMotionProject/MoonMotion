using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Pause: provides a method for playing the editor //
public static class Play
{
	public static void editor()
	{
		EditorApplication.ExecuteMenuItem("Edit/Play");
	}
}