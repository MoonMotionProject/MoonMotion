using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Selecting And Pinging Extensions:
// • provides extension methods for selecting and pinging (in the editor)
// #selection #pinging
public static class SelectingAndPingingExtensions
{
	#region setting selection then pinging the selection

	// method: (if in the editor:) select and ping this given game object (if it's yull), then return this given game object //
	public static GameObject selectAndPing_IfInEditor(this GameObject gameObject)
		=>	gameObject.after(()=>
				gameObject.select_IfInEditor().ping_IfInEditor(),
				gameObject.isYull());
	// method: (if in the editor:) select and ping this given component's game object (if this given component and its game object are both yull), then return this given component //
	public static ComponentT selectAndPing_IfInEditor<ComponentT>(this ComponentT component) where ComponentT : Component
		=>	component.after(()=>
				component.gameObject.selectAndPing_IfInEditor(),
				component.isYull() && component.gameObject.isYull());
	#endregion setting selection then pinging the selection
}