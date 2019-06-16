using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Disable Behaviours If Editor At Start:
// • 
public class DisableBehavioursIfEditorAtStart : AutomaticBehaviour<DisableBehavioursIfEditorAtStart>
{
	// variables //

	
	// settings //

	
	[Tooltip("the behaviours to disable at the start if running in the editor")]
	public MonoBehaviour[] behaviours;




	// updating //

	
	// at the start: //
	private void Start()
	{
		if (Application.isEditor)
		{
			behaviours.setEnablementTo(false);
		}
	}
}