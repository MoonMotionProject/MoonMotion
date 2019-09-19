using System.Reflection;
using UnityEditor;
using UnityEngine;

// Create New Object:
// • provides a menubar command to create a new object at the origin, select it, and ping it
public static class CreateNewObject
{
	[MenuItem("Create/New Object (at origin) %e")]
	public static void createNewObject()
		=> "New Object".createAsObject().resetPosition().selectAndPingInHierarchy_IfInEditor();
}