using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.EditorApplication;

// Callback Function Extensions: provides extension methods for handling callback functions //
public static class CallbackFunctionExtensions
{
	// methods for: editor events //


	// method: plan to execute this given callback function next time all inspectors have updated, then return this given callback function //
	public static CallbackFunction executeAfterAllInspectorsHaveNextUpdated(this CallbackFunction callbackFunction)
		=> EditorEvents.afterAllInspectorsHaveNextUpdatedExecute(callbackFunction);
}