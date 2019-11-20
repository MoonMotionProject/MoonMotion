#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEngine;

// Create New Object:
// • provides a menubar command to create a new object at the origin and select it
public static class CreateNewObject
{
	[MenuItem("Create/New Object (at origin) %e")]
	public static void createNewObject()
		=> "New Object".createAsObject().resetPosition().selectInHierarchy_IfInEditor();
}
#endif