using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity Object Extensions:
// • provides extension methods for handling Unity objects
// #gameobject #component #destruction
public static class UnityObjectExtensions
{
	#region destruction


	#region private

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
				Execute.atNextCheck_IfInEditor
				(
					()=> unityObject.destroy_Unconditionally_WithoutWaitingForInspectors()
				);
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
	#endregion private


	#region public

	// method: (according to the given boolean:) destroy this given game object – if it is in a scene (otherwise print an error) //
	public static void destroy(this GameObject gameObject, bool boolean = true)
	{
		if (boolean)
		{
			if (gameObject.scene.isYull())
			{
				gameObject.destroy_Unconditionally();
			}
			else
			{
				("UnityObjectExtensions.destroy given game object ("+gameObject+") which is not in a scene; not destroying to avoid destroying what may be part of a prefab.").printAsError();
			}
		}
	}

	// method: (according to the given boolean:) destroy this given component – if it is in a scene (otherwise print an error) //
	public static void destroy(this Component component, bool boolean = true)
	{
		if (boolean)
		{
			if (component.scene().isYull())
			{
				component.destroy_Unconditionally();
			}
			else
			{
				("UnityObjectExtensions.destroy given component ("+component+") which is not in a scene; not destroying to avoid destroying what may be part of a prefab.").printAsError();
			}
		}
	}
	#endregion public
	#endregion destruction
}