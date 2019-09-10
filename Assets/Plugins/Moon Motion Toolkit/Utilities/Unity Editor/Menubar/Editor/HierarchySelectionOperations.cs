using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Hierarchy Selection Operations:
// • provides menubar operations for the current hierarchy selection
public static class HierarchySelectionOperations
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


	#region operation methods for: hierarchy selection

	[MenuItem("Selection/Deselect %#D")]
	public static void deselect()
		=> Hierarchy.deselect();
	[MenuItem("Selection/Deselect %#D", true)]
	public static bool deselect_Validator()
		=> selectedGameObject;
	#endregion operation methods for: hierarchy selection


	#region operation methods for: game object activity

	[MenuItem("Selection/Toggle Activity %t")]
	public static void toggleActivity()
		=> pingSelectedGameObject().toggleActivity();
	[MenuItem("Selection/Toggle Activity %t", true)]
	public static bool toggleActivity_Validator()
		=> selectedGameObject;
	#endregion operation methods for: game object activity


	#region operation methods for: transformations

	[MenuItem("Selection/Reset Transformations %#r")]
	public static void resetTransformations()
		=> pingSelectedGameObject().resetLocals();
	[MenuItem("Selection/Reset Transformations %#r", true)]
	public static bool resetTransformations_Validator()
		=> selectedGameObject;
	#endregion operation methods for: transformations


	#region operation methods for: child lights

	[MenuItem("Selection/Render Child Lights By Pixel")]
	public static void renderChildLightsByPixel()
		=> pingSelectedGameObjectAndPrintNamely("rendering child lights by pixel").renderChildLightsByPixel();
	[MenuItem("Selection/Render Child Lights By Pixel", true)]
	public static bool renderChildLightsByPixel_Validator()
		=> selectedGameObject;

	[MenuItem("Selection/Render Child Lights By Vertex")]
	public static void renderChildLightsByVertex()
		=> pingSelectedGameObjectAndPrintNamely("rendering child lights by vertex").renderChildLightsByVertex();
	[MenuItem("Selection/Render Child Lights By Vertex", true)]
	public static bool renderChildLightsByVertex_Validator()
		=> selectedGameObject;
	#endregion operation methods for: child lights
}