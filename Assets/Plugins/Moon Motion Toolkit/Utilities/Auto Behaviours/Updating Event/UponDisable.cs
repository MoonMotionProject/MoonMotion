#if ODIN_INSPECTOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Upon Disable:
// • invokes the set Better Event upon being disabled
public class UponDisable : UpdatingEventBehaviour<UponDisable>
{
	// updating //

	
	// upon being disabled: //
	private void OnDisable()
		=> invokeBetterEvent();
}
#endif