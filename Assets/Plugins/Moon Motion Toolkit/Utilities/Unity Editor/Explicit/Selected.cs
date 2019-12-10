using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Selected:
// • provides functionality for handling that which is selected (in the editor)
// #selection
public static class Selected
{
	#region accessing selection

	// the (first) (currently) selected game object //
	public static GameObject gameObject => UnityEditor.Selection.activeGameObject;
	// the set of (currently) selected game objects //
	public static HashSet<GameObject> gameObjects => UnityEditor.Selection.gameObjects.uniques();
	#endregion accessing selection
}