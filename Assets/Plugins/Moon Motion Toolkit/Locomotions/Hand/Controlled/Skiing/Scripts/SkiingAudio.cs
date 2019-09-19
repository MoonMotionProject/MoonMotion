using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skiing Audio
// • adjusts the attached skiing audio via extension of Locomotion Movement Audio Single
// • provides a singleton instance of this class
public class SkiingAudio : LocomotionMovementAudioSingle
{
	// variables //

	
	// variables for: instancing //
	[HideInInspector] public SkiingAudio singleton;     // connection - auto: the singleton instance of this class




	// updating //


	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to the singleton instance of this class //
		singleton = this;
	}
}