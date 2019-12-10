#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ping:
// • provides methods for pinging (in the editor)
public static class Ping
{
	public static GameObject selectedGameObject()
		=> Selected.gameObject.ping_IfInEditor();
	public static HashSet<GameObject> selectedGameObjects()
		=> Selected.gameObjects.pingUniques_IfInEditor();

	// method: ping the selected game object, have it log the given string, then return the selected game object //
	public static GameObject selectedGameObjectLogging(string string_)
		=> selectedGameObject().log(string_);
	// method: ping the selected game objects, have each selected game object log the given string, then return the set of selected game objects //
	public static HashSet<GameObject> selectedGameObjectsEachLogging(string string_)
		=> selectedGameObjects().uniquesAfterAsEachObjectLogging(string_);
}
#endif