using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Upon Enable:
// • invokes the set Unity event upon being enabled
public class UponEnable : UpdatingEventBehaviour<UponEnable>
{
	// updating //

	
	// upon being enabled: //
	private void OnEnable()
		=> invokeUnityEvent();
}