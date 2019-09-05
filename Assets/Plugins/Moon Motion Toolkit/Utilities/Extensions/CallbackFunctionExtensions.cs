using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using static UnityEditor.EditorApplication;
#endif

// Callback Function Extensions: provides extension methods for handling callback functions //
public static class CallbackFunctionExtensions
{
	#if UNITY_EDITOR
	#region editor events

	// method: plan to execute this given callback function next time all inspectors have updated, then return this given callback function //
	public static CallbackFunction executeAfterAllInspectorsHaveNextUpdated(this CallbackFunction callbackFunction)
		=> EditorEvents.afterAllInspectorsHaveNextUpdatedExecute(callbackFunction);
	#endregion editor events
	#endif
}