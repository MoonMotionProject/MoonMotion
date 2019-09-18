using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mouse: provides properties about the mouse //
public static class Mouse
{
	#region cursor

	public static Vector2 cursorPosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);
	#endregion cursor


	#region buttons

	#region left
	public static bool leftClicking => Input.GetMouseButtonDown(0);
	public static bool leftClicked => Input.GetMouseButton(0);
	public static bool leftUnclicking => Input.GetMouseButtonUp(0);
	#endregion left

	#region middle
	public static bool middleClicking => Input.GetMouseButtonDown(1);
	public static bool middleClicked => Input.GetMouseButton(1);
	public static bool middleUnclicking => Input.GetMouseButtonUp(1);
	#endregion middle

	#region right
	public static bool rightClicking => Input.GetMouseButtonDown(2);
	public static bool rightClicked => Input.GetMouseButton(2);
	public static bool rightUnclicking => Input.GetMouseButtonUp(2);
	#endregion right
	#endregion buttons
}