using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Hierarchy Selection Operations:
// • provides menubar operations for the current hierarchy selection
// #hierarchy
public static class HierarchySelectionOperations
{
	#region operation methods for: hierarchy selection

	[MenuItem("Selection/Deselect %#D")]
	public static void deselect()
		=> Hierarchy.deselect();
	[MenuItem("Selection/Deselect %#D", true)]
	public static bool deselect_Validator()
		=> Hierarchy.selectedGameObject;
	#endregion operation methods for: hierarchy selection


	#region operation methods for: game object activity

	[MenuItem("Selection/Toggle Activity %t")]
	public static void toggleActivity()
		=> Hierarchy.pingSelectedGameObjects().toggleActivity();
	[MenuItem("Selection/Toggle Activity %t", true)]
	public static bool toggleActivity_Validator()
		=> Hierarchy.selectedGameObject;
	#endregion operation methods for: game object activity


	#region operation methods for: transformations

	[MenuItem("Selection/Reset Transformations %#r")]
	public static void resetTransformations()
		=> Hierarchy.pingSelectedGameObjects().resetLocalsForEach();
	[MenuItem("Selection/Reset Transformations %#r", true)]
	public static bool resetTransformations_Validator()
		=> Hierarchy.selectedGameObject;
	#endregion operation methods for: transformations


	#region operation methods for: velocities

	[MenuItem("Selection/Zero Velocities &%#r")]
	public static void zeroVelocities()
		=> Hierarchy.pingSelectedGameObjects().zeroVelocitiesOfEach();
	[MenuItem("Selection/Zero Velocities &%#r", true)]
	public static bool zeroVelocities_Validator()
		=> Hierarchy.selectedGameObject;
	#endregion operation methods for: velocities


	#region operation methods for: descendant lights

	[MenuItem("Selection/Render Descendant Lights By Pixel")]
	public static void renderDescendantLightsByPixel()
		=> Hierarchy.pingSelectedGameObjectsEachLogging("rendering descendant lights by pixel").forEachRenderDescendantLightsByPixel();
	[MenuItem("Selection/Render Descendant Lights By Pixel", true)]
	public static bool renderDescendantLightsByPixel_Validator()
		=> Hierarchy.selectedGameObject;

	[MenuItem("Selection/Render Descendant Lights By Vertex")]
	public static void renderDescendantLightsByVertex()
		=> Hierarchy.pingSelectedGameObjectsEachLogging("rendering descendant lights by vertex").forEachRenderDescendantLightsByVertex();
	[MenuItem("Selection/Render Descendant Lights By Vertex", true)]
	public static bool renderDescendantLightsByVertex_Validator()
		=> Hierarchy.selectedGameObject;
	#endregion operation methods for: descendant lights
}