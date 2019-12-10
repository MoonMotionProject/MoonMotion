#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Selection Operations:
// • provides menubar operations for the (current) selection
// #hierarchy
public static class SelectionOperations
{
	#region operation methods for: selection

	[MenuItem("Selection/Deselect %#D")]
	public static void deselect()
		=> Deselect.all();
	#endregion operation methods for: selection


	#region operation methods for: game object activity

	[MenuItem("Selection/Toggle Activity %t")]
	public static void toggleActivity()
		=> Ping.selectedGameObjects().toggleActivity();
	[MenuItem("Selection/Toggle Activity %t", true)]
	public static bool toggleActivity_Validator()
		=> Selected.gameObject;
	#endregion operation methods for: game object activity


	#region operation methods for: transformations

	[MenuItem("Selection/Reset Transformations %#r")]
	public static void resetTransformations()
		=> Ping.selectedGameObjects().resetLocalsForEach();
	[MenuItem("Selection/Reset Transformations %#r", true)]
	public static bool resetTransformations_Validator()
		=> Selected.gameObject;
	#endregion operation methods for: transformations


	#region operation methods for: velocities

	[MenuItem("Selection/Zero Velocities &%#r")]
	public static void zeroVelocities()
		=> Ping.selectedGameObjects().zeroVelocitiesOfEach();
	[MenuItem("Selection/Zero Velocities &%#r", true)]
	public static bool zeroVelocities_Validator()
		=> Selected.gameObject;
	#endregion operation methods for: velocities


	#region operation methods for: descendant lights

	[MenuItem("Selection/Render Descendant Lights By Pixel")]
	public static void renderDescendantLightsByPixel()
		=> Ping.selectedGameObjectsEachLogging("rendering descendant lights by pixel").forEachRenderDescendantLightsByPixel();
	[MenuItem("Selection/Render Descendant Lights By Pixel", true)]
	public static bool renderDescendantLightsByPixel_Validator()
		=> Selected.gameObject;

	[MenuItem("Selection/Render Descendant Lights By Vertex")]
	public static void renderDescendantLightsByVertex()
		=> Ping.selectedGameObjectsEachLogging("rendering descendant lights by vertex").forEachRenderDescendantLightsByVertex();
	[MenuItem("Selection/Render Descendant Lights By Vertex", true)]
	public static bool renderDescendantLightsByVertex_Validator()
		=> Selected.gameObject;
	#endregion operation methods for: descendant lights
}
#endif