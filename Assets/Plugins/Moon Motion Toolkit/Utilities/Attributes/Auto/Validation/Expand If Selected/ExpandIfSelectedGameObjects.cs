#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Expand If Selected Game Objects:
// • stores recorded game objects for which to handle the Expand If Selected attribute
public static class ExpandIfSelectedGameObjects
{
	private static HashSet<GameObject> gameObjects_ = New.setOf<GameObject>();
	private static HashSet<GameObject> gameObjects => gameObjects_ = gameObjects_.uniqueYulls();
	public static void include(GameObject gameObject)
		=> gameObjects_.include(gameObject);

	static ExpandIfSelectedGameObjects()
	{
		Selection.selectionChanged += ()=>
		{
			if (UnityIs.inEditorEditMode)
			{
				gameObjects
					.only(gameObject => gameObject.isSelectedInHierarchy())
						.expandUniquesInHierarchy();
			}
		};
	}
}
#endif