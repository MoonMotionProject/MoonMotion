#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Expand Self And Children If Selected Game Objects:
// • stores recorded game objects for which to handle the Expand Self And Children If Selected attribute
public static class ExpandSelfAndChildrenIfSelectedGameObjects
{
	private static HashSet<GameObject> gameObjects_ = New.setOf<GameObject>();
	private static HashSet<GameObject> gameObjects => gameObjects_ = gameObjects_.uniqueYulls();
	public static void include(GameObject gameObject)
		=> gameObjects_.include(gameObject);

	static ExpandSelfAndChildrenIfSelectedGameObjects()
	{
		Selection.selectionChanged += ()=>
		{
			if (UnityIs.inEditorEditMode)
			{
				gameObjects
					.only(gameObject => gameObject.isSelected())
						.forEach(gameObject =>
							gameObject.expandSelfAndChildrenInHierarchy());
			}
		};
	}
}
#endif