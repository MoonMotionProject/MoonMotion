using System;
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


	// method: return an array of all yull, enabled, and unique behaviours of the specified type that are currently in the hierarchy //
	public static HashSet<BehaviourT> allYullAndEnabledAndUnique<BehaviourT>() where BehaviourT : Behaviour
		=> Resources.FindObjectsOfTypeAll<BehaviourT>().onlyYull().onlyEnabled().toSet();

	// method: create and return a temporary game object (create a fresh game object with the default name, make it hidden, then return the created game object) //
	public static GameObject createTemporaryObject()
		=> new GameObject()
			.makeTemporary();

	// method: create a temporary game object, plan to destroy it after the given delay, then return the result of the given function on the temporary game object //
	public static TResult createTemporaryObjectAndDestroyAfterPicking<TResult>(Func<GameObject, TResult> function, float temporaryObjectDestructionDelay = Default.temporaryObjectDestructionDelay)
	{
		GameObject temporaryObject = createTemporaryObject();
		TResult result = function(temporaryObject);
		temporaryObject.destroy();
		return result;
	}

	#if UNITY_EDITOR
	// method: ping the game object currently selected in the hierarchy, then return it //
	public static GameObject pingSelectedGameObject()
		=> selectedGameObject.pingInHierarchy_IfInEditor();

	// method: ping the game object currently selected in the hierarchy, then return it after having it print namely the given string //
	public static GameObject pingSelectedGameObjectAndPrintNamely(string string_)
		=> pingSelectedGameObject().printNamely(string_);

	// method: deselect all current hierarchy selections //
	public static void deselect()
		=> Selection.objects = new UnityEngine.Object[0];
	#endif
	#endregion methods
}