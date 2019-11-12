using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Hierarchy Extensions:
// • provides extension methods for handling the hierarchy
// #hierarchy
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
	// method: (if in the editor:) select this given component's game object in the hierarchy (if this given component and its game object are both yull), then return this given component //
	public static ComponentT selectInHierarchy_IfInEditor<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.selectInHierarchy_IfInEditor(),
				component.isYull() && component.gameObject.isYull());

	// method: (if in the editor:) ping this given game object in the hierarchy (if it's yull), then return this given game object //
	public static GameObject pingInHierarchy_IfInEditor(this GameObject gameObject)
		=>	gameObject.after(gameObject_ =>
			{
				#if UNITY_EDITOR
				EditorGUIUtility.PingObject(gameObject_);
				#endif
			}, gameObject.isYull() && UnityIs.inEditor);
	// method: (if in the editor:) ping this given component's game object in the hierarchy (if this given component and its game object are both yull), then return this given component //
	public static ComponentT pingInHierarchy_IfInEditor<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.pingInHierarchy_IfInEditor(),
				component.isYull() && component.gameObject.isYull());
	// method: (if in the editor:) ping these given game objects in the hierarchy (only each one that is yull), then return the set of these given game objects //
	public static HashSet<GameObject> pingSetInHierarchy_IfInEditor(this IEnumerable<GameObject> gameObjects)
		=>	gameObjects.forEachUnique(gameObject =>
			{
				if (gameObject.isYull())
				{
					gameObject.pingInHierarchy_IfInEditor();
				}
			});
	// method: (if in the editor:) ping these given components' game objects in the hierarchy (only each component that is yull (and whose game object is yull)), then return the set of these given components //
	public static HashSet<ComponentT> pingSetInHierarchy_IfInEditor<ComponentT>(this IEnumerable<ComponentT> components) where ComponentT : Component
		=>	components.forEachUnique(component =>
			{
				if (component.isYull())
				{
					component.pingInHierarchy_IfInEditor();
				}
			});

	// method: (if in the editor:) select and ping this given game object in the hierarchy (if it's yull), then return this given game object //
	public static GameObject selectAndPingInHierarchy_IfInEditor(this GameObject gameObject)
		=>	gameObject.after(()=>
				gameObject.selectInHierarchy_IfInEditor().pingInHierarchy_IfInEditor(),
				gameObject.isYull());
	// method: (if in the editor:) select and ping this given component's game object in the hierarchy (if this given component and its game object are both yull), then return this given component //
	public static ComponentT selectAndPingInHierarchy_IfInEditor<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.selectAndPingInHierarchy_IfInEditor(),
				component.isYull() && component.gameObject.isYull());

	// method: make this given game object universal (not specific to any scene), then return this given game object //
	public static GameObject makeUniversal(this GameObject gameObject)
		=>	gameObject.after(()=>
				Object.DontDestroyOnLoad(gameObject));
	// method: make this given component's game object universal, then return this given component //
	public static ComponentT makeObjectUniversal<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.makeUniversal());

	// method: make this given game object temporary (hidden in the hierarchy and not saved with any scene – although not necessarily making this object universal (not specific to any scene)), then return this given game object //
	public static GameObject makeTemporary(this GameObject gameObject)
		=>	gameObject.after(()=>
				gameObject.hideFlags = HideFlags.HideAndDontSave);
	// method: make this given component's game object temporary, then return this given component //
	public static ComponentT makeObjectTemporary<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.makeTemporary());

	// method: make this given game object universal and temporary, then return this given game object //
	public static GameObject makeUniversalAndTemporary(this GameObject gameObject)
		=> gameObject.makeUniversal().makeTemporary();
	// method: make this given component's game object universal and temporary, then return this given component //
	public static ComponentT makeUniversalAndTemporary<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.makeUniversalAndTemporary());
}