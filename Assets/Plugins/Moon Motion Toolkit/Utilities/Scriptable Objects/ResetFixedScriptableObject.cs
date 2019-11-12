using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

// Reset Fixed Scriptable Object
// • upon resetting this scriptable object, reimports this asset if needed
//   · (to resolve the bug where the scriptable object name becomes empty in the inspector (but not for the file), that is a faulty side effect of resetting)
public abstract class	ResetFixedScriptableObject :
							#if ODIN_INSPECTOR
							SerializedScriptableObject
							#else
							ScriptableObject
							#endif
{
	#if UNITY_EDITOR
	public virtual void Reset()
		=> Reimport.assetIfImported(this);
	#endif
}