using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Hierarchy:
// • provides functionality for handling the hierarchy
// #hierarchy
public static class Hierarchy
{
	#region state


	public static IEnumerable<Scene> selectScenes => Select.forCount(SceneManager.sceneCount, sceneIndex =>
																	SceneManager.GetSceneAt(sceneIndex));

	public static IEnumerable<GameObject> selectPrimogenitorObjects => selectScenes.selectNested(scene => scene.GetRootGameObjects());
	public static List<GameObject> primogenitorObjects => selectPrimogenitorObjects.manifested();

	public static IEnumerable<Transform> selectPrimogenitorTransforms => selectPrimogenitorObjects.selectTransforms();

	public static int primogenitorCount => selectPrimogenitorObjects.count();

	public static int lastPrimogenitorIndex => primogenitorCount - 1;

	#if UNITY_EDITOR
	// the (first) currently selected game object //
	public static GameObject selectedGameObject => Selection.activeGameObject;
	// the set of currently selected game objects //
	public static HashSet<GameObject> selectedGameObjects => Selection.gameObjects.toSet();
	#endif
	#endregion state




	#region methods


	// method: return the set of all yull, enabled, and unique behaviours of the specified type that are currently in the hierarchy //
	public static HashSet<BehaviourT> allYullAndEnabledAndUnique<BehaviourT>() where BehaviourT : Behaviour
		=> Resources.FindObjectsOfTypeAll<BehaviourT>().onlyYull().onlyEnabled().toSet();

	// method: return the first yull, enabled, and unique behaviour of the specified type that is currently in the hierarchy //
	public static BehaviourT firstYullAndEnabledAndUnique<BehaviourT>() where BehaviourT : Behaviour
		=> allYullAndEnabledAndUnique<BehaviourT>().firstOtherwiseDefault();

	// method: return the set of all of the specified interface implemented on mono behaviours that are yull, enabled, and unique instances currently in the hierarchy //
	public static HashSet<MonoBehaviourI> allYullAndEnabledAndUniqueI<MonoBehaviourI>() where MonoBehaviourI : class
	{
		if (!typeof(MonoBehaviourI).IsInterface)
		{
			return default(HashSet<MonoBehaviourI>).returnWithError(typeof(MonoBehaviourI).simpleClassName()+" is not an interface");
		}

		return allYullAndEnabledAndUnique<MonoBehaviour>().only<MonoBehaviourI>().toSet();
	}
	
	// method: return the first of the specified interface implemented on mono behaviours that are yull, enabled, and unique instances currently in the hierarchy //
	public static MonoBehaviourI firstYullAndEnabledAndUniqueI<MonoBehaviourI>() where MonoBehaviourI : class
	{
		if (!typeof(MonoBehaviourI).IsInterface)
		{
			return default(MonoBehaviourI).returnWithError(typeof(MonoBehaviourI).simpleClassName()+" is not an interface");
		}

		return allYullAndEnabledAndUniqueI<MonoBehaviourI>().firstOtherwiseDefault();
	}

	// method: create and return a universal game object (create a fresh game object with the default name, make it universal, then return the created game object) //
	public static GameObject createUniversalObject()
		=> new GameObject()
			.makeUniversal();

	// method: create and return a temporary game object (create a fresh game object with the default name, make it temporary, then return the created game object) //
	public static GameObject createTemporaryObject()
		=> new GameObject()
			.makeTemporary();

	// method: create and return a universal and temporary game object (create a fresh game object with the default name, make it universal and temporary, then return the created game object) //
	public static GameObject createUniversalAndTemporaryObject()
		=> new GameObject()
			.makeUniversalAndTemporary();

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
	// method: ping the set of game objects currently selected in the hierarchy, then return the set //
	public static HashSet<GameObject> pingSelectedGameObjects()
		=> selectedGameObjects.pingSetInHierarchy_IfInEditor();

	// method: ping the game object currently selected in the hierarchy, then return it after having it log the given string //
	public static GameObject pingSelectedGameObjectLogging(string string_)
		=> pingSelectedGameObject().asThisObjectLog(string_);
	// method: ping the set of game objects currently selected in the hierarchy, then return the set after logging the given string as each game object //
	public static HashSet<GameObject> pingSelectedGameObjectsEachLogging(string string_)
		=> pingSelectedGameObjects().setAfterAsEachObjectLogging(string_);

	// method: deselect all current hierarchy selections //
	public static void deselect()
		=> Selection.objects = new UnityEngine.Object[0];
	#endif
	#endregion methods
}