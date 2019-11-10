#if ODIN_INSPECTOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Upon Enable:
// • invokes the set Better Event upon being enabled
public class UponEnable : UpdatingEventBehaviour<UponEnable>
{
	// updating //

	
	// upon enablement: //
	public override void OnEnable()
	{
		base.OnEnable();

		invokeBetterEvent();
	}
}
#endif