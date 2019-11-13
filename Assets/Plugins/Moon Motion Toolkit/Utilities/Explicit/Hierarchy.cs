﻿using System;
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


	public static IEnumerable<Scene> accessScenes
		=>	Access.forCount(SceneManager.sceneCount, sceneIndex =>
				SceneManager.GetSceneAt(sceneIndex));

	public static IEnumerable<GameObject> accessPrimogenitorObjects => accessScenes.accessNested(scene => scene.GetRootGameObjects());
	public static List<GameObject> primogenitorObjects => accessPrimogenitorObjects.manifested();

	public static IEnumerable<Transform> accessPrimogenitorTransforms => accessPrimogenitorObjects.accessTransforms();

	public static int primogenitorCount => accessPrimogenitorObjects.count();

	public static int lastPrimogenitorIndex => primogenitorCount - 1;

	#if UNITY_EDITOR
	// the (first) currently selected game object //
	public static GameObject selectedGameObject => Selection.activeGameObject;
	// the set of currently selected game objects //
	public static HashSet<GameObject> selectedGameObjects => Selection.gameObjects.uniques();
#endif
	#endregion state




	#region methods


	#region accessing components in the hierarchy

	// method: return the set of all yull, enabled, and unique behaviours of the specified type that are currently in the hierarchy //
	public static HashSet<BehaviourT> allYullAndEnabledAndUnique<BehaviourT>() where BehaviourT : Behaviour
		=> Resources.FindObjectsOfTypeAll<BehaviourT>().onlyYull().onlyEnabled().uniques();

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

		return allYullAndEnabledAndUnique<MonoBehaviour>().only<MonoBehaviourI>().uniques();
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
	#endregion accessing components in the hierarchy


	#region creating universal andor temporary objects

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

	// method: create a temporary game object, then return the result of the given function on the temporary game object //
	public static TResult createTemporaryObjectAndDestroyAfterPicking<TResult>(Func<GameObject, TResult> function)
	{
		GameObject temporaryObject = createTemporaryObject();
		TResult result = function(temporaryObject);
		temporaryObject.destroy();
		return result;
	}
	#endregion creating universal andor temporary objects


	#region setting hierarchy objects selection
	#if UNITY_EDITOR

	// method: deselect in the hierarchy all current hierarchy selection objects //
	public static void deselect()
		=> Selection.objects = New.arrayOf<UnityEngine.Object>();
	#endif
	#endregion setting hierarchy objects selection
	
	
	#region pinging hierarchy selection objects

	#if UNITY_EDITOR
	// method: ping the game object currently selected in the hierarchy, then return it //
	public static GameObject pingSelectedGameObject()
		=> selectedGameObject.pingInHierarchy_IfInEditor();
	// method: ping the set of game objects currently selected in the hierarchy, then return the set //
	public static HashSet<GameObject> pingSelectedGameObjects()
		=> selectedGameObjects.pingUniquesInHierarchy_IfInEditor();

	// method: ping the game object currently selected in the hierarchy, then return it after having it log the given string //
	public static GameObject pingSelectedGameObjectLogging(string string_)
		=> pingSelectedGameObject().asThisObjectLog(string_);
	// method: ping the set of game objects currently selected in the hierarchy, then return the set after logging the given string as each game object //
	public static HashSet<GameObject> pingSelectedGameObjectsEachLogging(string string_)
		=> pingSelectedGameObjects().uniquesAfterAsEachObjectLogging(string_);
	#endif
	#endregion pinging hierarchy selection objects
	#endregion methods
}