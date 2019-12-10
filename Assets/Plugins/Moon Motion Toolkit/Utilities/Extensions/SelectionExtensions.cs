using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Selection Extensions:
// • provides extension methods for handling selection (in the editor)
// #selection
public static class SelectionExtensions
{
	#region determining selection
	
	#if UNITY_EDITOR
	// method: return whether this given game object is currently selected in the hierarchy //
	public static bool isSelected(this GameObject gameObject)
		=> UnityEditor.Selection.gameObjects.contains(gameObject);
	#endif
	
	#if UNITY_EDITOR
	// method: return whether this given game object is not currently selected in the hierarchy //
	public static bool isNotSelected(this GameObject gameObject)
		=> !gameObject.isSelected();
	#endif
	#endregion determining selection
	

	#region setting selection

	// method: (if in the editor:) select this given game object, then return this given game object //
	public static GameObject select_IfInEditor(this GameObject gameObject)
	{
		#if UNITY_EDITOR
		if (UnityIs.inEditor)
		{
			return UnityEditor.Selection.activeGameObject = gameObject;
		}
		#endif

		return gameObject;
	}
	// method: (if in the editor:) select this given component's game object (if this given component and its game object are both yull), then return this given component //
	public static ComponentT select_IfInEditor<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.select_IfInEditor(),
				component.isYull() && component.gameObject.isYull());
	// method: (if in the editor:) select the uniques of these given game objects, then return the set of these given game objects //
	public static HashSet<GameObject> selectUniques_IfInEditor(this IEnumerable<GameObject> gameObjects)
	{
		HashSet<GameObject> uniqueGameObjects = gameObjects.uniques();

		#if UNITY_EDITOR
		if (UnityIs.inEditor)
		{
			Select.only(uniqueGameObjects);
		}
		#endif

		return uniqueGameObjects;
	}
	#endregion setting selection
}