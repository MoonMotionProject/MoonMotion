using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Hierarchy Extensions: provides extension methods for handling the hierarchy //
public static class HierarchyExtensions
{
	// method: (if in the editor:) select this given game object in the hierarchy, then return this given game object //
	public static GameObject selectInHierarchy_IfInEditor(this GameObject gameObject)
	{
		#if UNITY_EDITOR
		if (UnityIs.inEditor)
		{
			return Selection.activeGameObject = gameObject;
		}
		#endif

		return gameObject;
	}
	// method: (if in the editor:) select this given component's game object in the hierarchy, then return this given component //
	public static ComponentT selectInHierarchy_IfInEditor<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.selectInHierarchy_IfInEditor());

	// method: (if in the editor:) ping this given game object in the hierarchy, then return this given game object //
	public static GameObject pingInHierarchy_IfInEditor(this GameObject gameObject)
		=> gameObject.after(gameObject_ => EditorGUIUtility.PingObject(gameObject_));
	// method: (if in the editor:) ping this given component's game object in the hierarchy, then return this given component //
	public static ComponentT pingInHierarchy_IfInEditor<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.pingInHierarchy_IfInEditor());

	// method: (if in the editor:) select and ping this given game object in the hierarchy, then return this given game object //
	public static GameObject selectAndPingInHierarchy_IfInEditor(this GameObject gameObject)
		=> gameObject.selectInHierarchy_IfInEditor().pingInHierarchy_IfInEditor();
	// method: (if in the editor:) select and ping this given component's game object in the hierarchy, then return this given component //
	public static ComponentT selectAndPingInHierarchy_IfInEditor<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.selectAndPingInHierarchy_IfInEditor());

	// method: make this given game object temporary, then return this given game object //
	public static GameObject makeTemporary(this GameObject gameObject)
		=> gameObject.after(()=>
			gameObject.hideFlags = HideFlags.HideAndDontSave);
	// method: make this given component's game object temporary, then return this given component //
	public static ComponentT makeObjectTemporary<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.after(()=>
			component.gameObject.makeTemporary());
}