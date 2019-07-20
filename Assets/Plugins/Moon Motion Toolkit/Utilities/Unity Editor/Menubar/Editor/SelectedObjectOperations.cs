using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Selected Object Operations:
// • provides menubar operations for the current selected object in the hierarchy
public static class SelectedObjectOperations
{
	#region operating selections

	// method: return the currently selected game object //
	public static GameObject selectedGameObject => Selection.activeGameObject;
	
	// method: ping the current selected game object, then return it //
	public static GameObject pingSelectedGameObject()
	{
		GameObject selectedGameObject_ = selectedGameObject;

		EditorGUIUtility.PingObject(selectedGameObject_);

		return selectedGameObject_;
	}

	// method: ping the current selected game object, have it print namely the given string, then return the current selected game object //
	public static GameObject pingSelectedGameObjectAndPrintNamely(string string_)
		=> pingSelectedGameObject().printNamely(string_);
	#endregion operating selections


	#region operation methods for: child lights

	[MenuItem("Selected Object/Render Child Lights By Pixel")]
	public static void renderChildLightsByPixel()
		=> pingSelectedGameObjectAndPrintNamely("rendering child lights by pixel").renderChildLightsByPixel();
	[MenuItem("Selected Object/Render Child Lights By Pixel", true)]
	public static bool renderChildLightsByPixel_Validator()
		=> selectedGameObject;

	[MenuItem("Selected Object/Render Child Lights By Vertex")]
	public static void renderChildLightsByVertex()
		=> pingSelectedGameObjectAndPrintNamely("rendering child lights by vertex").renderChildLightsByVertex();
	[MenuItem("Selected Object/Render Child Lights By Vertex", true)]
	public static bool renderChildLightsByVertex_Validator()
		=> selectedGameObject;
	#endregion operation methods for: child lights
}