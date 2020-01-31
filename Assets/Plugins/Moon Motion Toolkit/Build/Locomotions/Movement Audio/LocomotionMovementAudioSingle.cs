using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Locomotion Movement Audio Single
// • adjusts locomotion audio via extension of Locomotion Movement Audio
//   · the locomotion audio source is singular and is expected to be attached to this object
[RequireComponent(typeof(AudioSource))]
public abstract class LocomotionMovementAudioSingle : LocomotionMovementAudio
{
	// variables //
	
	
	// variables for: adjusting volume //
	protected AudioSource audioSource;		// connection - auto: the locomotion audio source (of which to adjust the volume)

	


	// methods //

	
	// method: adjust the audio source's volume by the given amount //
	protected override void adjustVolume(float amount)
		=> adjustVolumeOfGivenAudioSource(audioSource, amount);



	// updating //


	// before the start: //
	protected virtual void Awake()
	{
		// connect to the locomotion audio source //
		audioSource = GetComponent<AudioSource>();
	}
}