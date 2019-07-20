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


	#if UNITY_EDITOR
	// at the start: //
	private void Start()
		=> behaviours.setEnablementTo(false);
	#endif
}