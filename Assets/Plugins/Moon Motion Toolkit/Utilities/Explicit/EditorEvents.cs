using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using static UnityEditor.EditorApplication;
#endif


// Editor Events: provides methods for handling editor events //
public static class EditorEvents
{
	#if UNITY_EDITOR
	#region inspector
	
	// method: plan to execute the given callback function next time all inspectors have updated, then return the given callback function //
	private static CallbackFunction afterAllInspectorsHaveNextUpdatedExecute_WithoutPreventingExecutionIfEditorModeChangesFirst(CallbackFunction callbackFunction)
		=> callbackFunction.after(()=>
			delayCall += callbackFunction);

	// method: plan to execute the given callback function next time all inspectors have updated, preventing execution if the editor mode changes before then, then return the given callback function //
	private static CallbackFunction afterAllInspectorsHaveNextUpdatedExecute_PreventingExecutionIfEditorModeChangesFirst(CallbackFunction callbackFunction)
	{
		bool inEditorEditModeUponPlanning = UnityIs.inEditorEditMode;

		afterAllInspectorsHaveNextUpdatedExecute_WithoutPreventingExecutionIfEditorModeChangesFirst(()=>
		{
			if (inEditorEditModeUponPlanning == UnityIs.inEditorEditMode)
			{
				callbackFunction();
			}
		});

		return callbackFunction;
	}

	// method: plan to execute the given callback function next time all inspectors have updated, optionally preventing execution if the editor mode changes before then (according to the given boolean), then return the given callback function //
	public static CallbackFunction afterAllInspectorsHaveNextUpdatedExecute(CallbackFunction callbackFunction, bool preventExecutionIfEditorModeChangesFirst = false)
		=>	preventExecutionIfEditorModeChangesFirst ?
				afterAllInspectorsHaveNextUpdatedExecute_PreventingExecutionIfEditorModeChangesFirst(callbackFunction) :
				afterAllInspectorsHaveNextUpdatedExecute_WithoutPreventingExecutionIfEditorModeChangesFirst(callbackFunction);
	#endregion inspector
	#endif
}