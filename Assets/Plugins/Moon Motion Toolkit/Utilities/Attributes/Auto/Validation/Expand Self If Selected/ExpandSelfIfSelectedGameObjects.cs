#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Expand Self If Selected Game Objects:
// • stores recorded game objects for which to handle the Expand Self If Selected attribute
public static class ExpandSelfIfSelectedGameObjects
{
	private static HashSet<GameObject> gameObjects_ = New.setOf<GameObject>();
	private static HashSet<GameObject> gameObjects => gameObjects_ = gameObjects_.uniqueYulls();
	public static void include(GameObject gameObject)
		=> gameObjects_.include(gameObject);

	static ExpandSelfIfSelectedGameObjects()
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