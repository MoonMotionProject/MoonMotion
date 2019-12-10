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

	
	public static Type windowType_ViaReflection => EditorAssembly.classNamed("UnityEditor.SceneHierarchyWindow");

	public static UnityEngine.Object window_ViaReflection
		=> Resources.FindObjectsOfTypeAll(windowType_ViaReflection).first();

	public static object treeViewControllerFor_ViaReflection(UnityEngine.Object hierarchyWindow)
		=> hierarchyWindow.valueOf(windowType_ViaReflection.nonpublicInstanceFieldNamed("m_TreeView"));
	public static object windowTreeViewController_ViaReflection
		=> treeViewControllerFor_ViaReflection(window_ViaReflection);

	public static IEnumerable<Scene> accessScenes
		=>	Access.forCount(SceneManager.sceneCount, sceneIndex =>
				SceneManager.GetSceneAt(sceneIndex));

	public static IEnumerable<GameObject> accessPrimogenitorObjects => accessScenes.accessNested(scene => scene.GetRootGameObjects());
	public static List<GameObject> primogenitorObjects => accessPrimogenitorObjects.manifested();

	public static IEnumerable<Transform> accessPrimogenitorTransforms => accessPrimogenitorObjects.accessTransforms();

	public static int primogenitorCount => accessPrimogenitorObjects.count();

	public static int lastPrimogenitorIndex => primogenitorCount - 1;
	#endregion state




	#region methods


	#region accessing components in the hierarchy

	// method: return the set of all yull and unique behaviours of the specified type that are currently in the hierarchy //
	public static HashSet<BehaviourT> allYullAndUnique<BehaviourT>() where BehaviourT : Behaviour
		=>	Resources.FindObjectsOfTypeAll<BehaviourT>()
				.onlyYull()
				.only(behaviour => behaviour.gameObject.isNotPartOfPrefabAsset())
				.uniques();

	// method: return the first yull and unique behaviour of the specified type that is currently in the hierarchy //
	public static BehaviourT firstYullAndUnique<BehaviourT>() where BehaviourT : Behaviour
		=> allYullAndUnique<BehaviourT>().firstOtherwiseDefault();

	/* (via reflection) */
	// method: return the set of all of the specified interface implemented on mono behaviours that are yull and unique instances currently in the hierarchy //
	public static HashSet<MonoBehaviourI> allYullAndUniqueI<MonoBehaviourI>() where MonoBehaviourI : class
	{
		if (Interfaces.doesNotInclude<MonoBehaviourI>())
		{
			return default(HashSet<MonoBehaviourI>).returnWithError(typeof(MonoBehaviourI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return allYullAndUnique<MonoBehaviour>().only<MonoBehaviourI>().uniques();
	}
	
	/* (via reflection) */
	// method: return the first of the specified interface implemented on mono behaviours that are yull and unique instances currently in the hierarchy //
	public static MonoBehaviourI firstYullAndUniqueI<MonoBehaviourI>() where MonoBehaviourI : class
	{
		if (Interfaces.doesNotInclude<MonoBehaviourI>())
		{
			return default(MonoBehaviourI).returnWithError(typeof(MonoBehaviourI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return allYullAndUniqueI<MonoBehaviourI>().firstOtherwiseDefault();
	}

	// method: return the set of all yull, enabled, and unique behaviours of the specified type that are currently in the hierarchy //
	public static HashSet<BehaviourT> allYullAndEnabledAndUnique<BehaviourT>() where BehaviourT : Behaviour
		=>	Resources.FindObjectsOfTypeAll<BehaviourT>()
				.onlyYull()
				.onlyEnabled()
				.only(behaviour => behaviour.gameObject.isNotPartOfPrefabAsset())
				.uniques();

	// method: return the first yull, enabled, and unique behaviour of the specified type that is currently in the hierarchy //
	public static BehaviourT firstYullAndEnabledAndUnique<BehaviourT>() where BehaviourT : Behaviour
		=> allYullAndEnabledAndUnique<BehaviourT>().firstOtherwiseDefault();

	/* (via reflection) */
	// method: return the set of all of the specified interface implemented on mono behaviours that are yull, enabled, and unique instances currently in the hierarchy //
	public static HashSet<MonoBehaviourI> allYullAndEnabledAndUniqueI<MonoBehaviourI>() where MonoBehaviourI : class
	{
		if (Interfaces.doesNotInclude<MonoBehaviourI>())
		{
			return default(HashSet<MonoBehaviourI>).returnWithError(typeof(MonoBehaviourI).simpleClassName_ViaReflection()+" is not an interface");
		}

		return allYullAndEnabledAndUnique<MonoBehaviour>().only<MonoBehaviourI>().uniques();
	}
	
	/* (via reflection) */
	// method: return the first of the specified interface implemented on mono behaviours that are yull, enabled, and unique instances currently in the hierarchy //
	public static MonoBehaviourI firstYullAndEnabledAndUniqueI<MonoBehaviourI>() where MonoBehaviourI : class
	{
		if (Interfaces.doesNotInclude<MonoBehaviourI>())
		{
			return default(MonoBehaviourI).returnWithError(typeof(MonoBehaviourI).simpleClassName_ViaReflection()+" is not an interface");
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


	#region setting hierarchy expansion
	
	public static void collapseAllObjects()
		=> accessPrimogenitorObjects.collapseLodalsInHierarchy();
	#endregion setting hierarchy expansion
	#endregion methods
}