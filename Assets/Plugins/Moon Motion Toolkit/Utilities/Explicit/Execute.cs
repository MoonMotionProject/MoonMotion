using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Execute:
// • provides methods for handling execution
// #coroutines #execution
public static class Execute
{
	#region planning to execute functions after a delay

	// methods: (have the ether) plan to execute the given function with the given parameters after the given delay, then return the new coroutine that will do so //
	public static Coroutine after(float delay, Delegate function, params object[] parameters)
		=> Ether.executeAfter(delay, function, parameters);
	public static Coroutine after(float delay, Action action, params object[] parameters)
		=> Ether.executeAfter(delay, action, parameters);
	#endregion planning to execute functions after a delay
	

	#region planning to execute functions\actions at next check

	// methods: (have the ether) plan to execute the given function with the given parameters at the next coroutine check, then return the new coroutine that will do so //
	public static Coroutine atNextCheck(Delegate function, params object[] parameters)
		=> Ether.atNextCheckExecute(function, parameters);
	public static Coroutine atNextCheck(Action action, params object[] parameters)
		=> Ether.atNextCheckExecute(action, parameters);
	#endregion planning to execute functions\actions at next check


	#region planning to execute functions\actions at next check in editor

	// method: plan to execute the given action upon the given component at the next editor check (if the given component is still yull) //
	public static void atNextCheckFor_IfInEditor<ComponentT>(ComponentT component, Action<ComponentT> action, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullComponentError = Default.errorSilencing) where ComponentT : Component
	{
		#if UNITY_EDITOR
		if (UnityIs.inEditor)
		{
			bool inEditorEditModeUponPlanning = UnityIs.inEditorEditMode;

			EditorApplication.delayCall += ()=>
			{
				if (executeIfPlaymodeHasChanged || (inEditorEditModeUponPlanning == UnityIs.inEditorEditMode))
				{
					if (component.isYull())
					{
						action(component);
					}
					else if (!silenceNullComponentError)
					{
						Log.newExceptionAsError("Execute.atNextCheckFor_IfInEditor given null component");
					}
				}
			};
		}
		#endif
	}
	#endregion planning to execute functions\actions at next check in editor


	#region planning to execute functions\actions now and at every check

	// methods: (have the ether) plan to execute the given function with the given parameters at every coroutine check, then return the new coroutine that will do so //
	public static Coroutine nowAndAtEveryCheck(Delegate function, params object[] parameters)
		=> Ether.nowAndAtEveryCheckExecute(function, parameters);
	public static Coroutine nowAndAtEveryCheck(Action action, params object[] parameters)
		=> Ether.nowAndAtEveryCheckExecute(action, parameters);
	#endregion planning to execute functions\actions now and at every check


	#region planning to execute functions\actions at next check and every check after

	// methods: (have the ether) plan to execute the given function with the given parameters at every coroutine check, then return the new coroutine that will do so //
	public static Coroutine atNextCheckAndEveryCheckAfter(Delegate function, params object[] parameters)
		=> Ether.atNextCheckAndEveryCheckAfterExecute(function, parameters);
	public static Coroutine atNextCheckAndEveryCheckAfter(Action action, params object[] parameters)
		=> Ether.atNextCheckAndEveryCheckAfterExecute(action, parameters);
	#endregion planning to execute functions\actions at next check and every check after


	#region planning to execute functions\actions at the end of the current frame

	// methods: (have the ether) plan to execute the given function with the given parameters at the end of the current frame, then return the new coroutine that will do so //
	public static Coroutine atEndOfFrame(Delegate function, params object[] parameters)
		=> Ether.atEndOfFrameExecute(function, parameters);
	public static Coroutine atEndOfFrame(Action action, params object[] parameters)
		=> Ether.atEndOfFrameExecute(action, parameters);
	#endregion planning to execute functions\actions at the end of the current frame
}