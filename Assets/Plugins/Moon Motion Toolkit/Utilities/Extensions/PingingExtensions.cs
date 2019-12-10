using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Pinging Extensions:
// • provides extension methods for pinging (in the editor)
// #pinging
public static class PingingExtensions
{
	// method: (if in the editor:) ping this given game object (if it's yull), then return this given game object //
	public static GameObject ping_IfInEditor(this GameObject gameObject)
		=>	gameObject.after(gameObject_ =>
			{
				#if UNITY_EDITOR
				EditorGUIUtility.PingObject(gameObject_);
				#endif
			}, gameObject.isYull() && UnityIs.inEditor);
	// method: (if in the editor:) ping this given component's game object (if this given component and its game object are both yull), then return this given component //
	public static ComponentT ping_IfInEditor<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				ping_IfInEditor(component.gameObject),
				component.isYull() && component.gameObject.isYull());

	// method: (if in the editor:) ping these given game objects (only each one that is yull), then return the set of these given game objects //
	public static HashSet<GameObject> pingUniques_IfInEditor(this IEnumerable<GameObject> gameObjects)
		=>	gameObjects.forEachUnique(gameObject =>
			{
				if (gameObject.isYull())
				{
					gameObject.ping_IfInEditor();
				}
			});
	// method: (if in the editor:) ping these given components' game objects (only each component that is yull (and whose game object is yull)), then return the set of these given components //
	public static HashSet<ComponentT> pingUniques_IfInEditor<ComponentT>(this IEnumerable<ComponentT> components) where ComponentT : Component
		=>	components.forEachUnique(component =>
			{
				if (component.isYull())
				{
					component.ping_IfInEditor();
				}
			});
}