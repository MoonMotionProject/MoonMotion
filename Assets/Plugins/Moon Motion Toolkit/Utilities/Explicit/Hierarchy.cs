using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Hierarchy: provides functionality for handling the hierarchy //
public static class Hierarchy
{
	#region state


	public static IEnumerable<Scene> selectScenes => Select.forCount(SceneManager.sceneCount, sceneIndex =>
																	SceneManager.GetSceneAt(sceneIndex));

	public static IEnumerable<GameObject> selectPrimogenitorObjects => selectScenes.selectNested(scene => scene.GetRootGameObjects());

	public static IEnumerable<Transform> selectPrimogenitorTransforms => selectPrimogenitorObjects.selectTransforms();

	public static int primogenitorCount => selectPrimogenitorObjects.count();

	public static int lastPrimogenitorIndex => primogenitorCount - 1;

	#if UNITY_EDITOR
	// the currently selected game object //
	public static GameObject selectedGameObject => Selection.activeGameObject;
	#endif
	#endregion state




	#region methods


	// method: create a fresh game object with the default name, make it hidden, then return the created game object //
	public static GameObject createTemporaryObject()
		=> new GameObject()
			.makeTemporary();

	#if UNITY_EDITOR
	// method: ping the game object currently selected in the hierarchy, then return it //
	public static GameObject pingSelectedGameObject()
		=> selectedGameObject.pingInHierarchy_IfInEditor();

	// method: ping the game object currently selected in the hierarchy, then return it after having it print namely the given string //
	public static GameObject pingSelectedGameObjectAndPrintNamely(string string_)
		=> pingSelectedGameObject().printNamely(string_);

	// method: deselect all current hierarchy selections //
	public static void deselect()
		=> Selection.objects = new Object[0];
	#endif
	#endregion methods
}