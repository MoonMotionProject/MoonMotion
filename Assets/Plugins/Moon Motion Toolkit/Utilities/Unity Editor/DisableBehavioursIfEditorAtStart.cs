using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Disable Behaviours If Editor At Start:
// • at the start, if running in the editor, disables the set behaviours
public class DisableBehavioursIfEditorAtStart : AutoBehaviour<DisableBehavioursIfEditorAtStart>
{
	// variables //

	
	// settings //

	
	[Tooltip("the behaviours to disable at the start if running in the editor")]
	public Behaviour[] behaviours;




	// updating //


	#if UNITY_EDITOR
	// at the start: //
	private void Start()
		=> behaviours.disableEach();
	#endif
}