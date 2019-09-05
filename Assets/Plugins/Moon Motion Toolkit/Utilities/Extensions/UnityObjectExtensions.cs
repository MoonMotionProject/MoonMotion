using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity Object Extensions: provides extension methods for handling Unity objects //
public static class UnityObjectExtensions
{
	#region destruction

	#if UNITY_EDITOR
	// method: destroy this given Unity object (unconditionally and without waiting for inspectors) //
	private static void destroy_Unconditionally_WithoutWaitingForInspectors<UnityObjectT>(this UnityObjectT unityObject) where UnityObjectT : UnityEngine.Object
	{
		if (UnityIs.inEditorEditMode)
		{
			UnityEngine.Object.DestroyImmediate(unityObject);
		}
		else
		{
			UnityEngine.Object.Destroy(unityObject);
		}
	}
	#endif

	// method: destroy this given Unity object (unconditionally) //
	private static void destroy_Unconditionally<UnityObjectT>(this UnityObjectT unityObject) where UnityObjectT : UnityEngine.Object
	{
		#if UNITY_EDITOR
		if (UnityIs.inEditorEditMode)
		{
			if (Callstack.includesOnValidate || Callstack.includesContextMenu)
			{
				EditorEvents.afterAllInspectorsHaveNextUpdatedExecute(()=>
					unityObject.destroy_Unconditionally_WithoutWaitingForInspectors());
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(unityObject);
			}
		}
		else
		{
			UnityEngine.Object.Destroy(unityObject);
		}
		#else
		UnityEngine.Object.Destroy(unityObject);
		#endif
	}

	// method: destroy this given Unity object according to the given booleanic function upon this given Unity object //
	public static void destroy<UnityObjectT>(this UnityObjectT unityObject, Func<UnityObjectT, bool> function) where UnityObjectT : UnityEngine.Object
	{
		if (function(unityObject))
		{
			unityObject.destroy_Unconditionally();
		}
	}

	// method: (according to the given boolean:) destroy this given component //
	public static void destroy<UnityObjectT>(this UnityObjectT unityObject, bool boolean = true) where UnityObjectT : UnityEngine.Object
	{
		if (boolean)
		{
			unityObject.destroy_Unconditionally();
		}
	}
	#endregion destruction
}