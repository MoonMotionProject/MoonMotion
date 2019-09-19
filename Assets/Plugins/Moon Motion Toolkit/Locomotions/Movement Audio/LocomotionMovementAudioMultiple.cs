using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Locomotion Movement Audio Multiple
// • adjusts locomotion audio via extension of Locomotion Movement Audio
//   · the locomotion audio source is multiple and is expected to be all attached and children audio sources of this object
public abstract class LocomotionMovementAudioMultiple : LocomotionMovementAudio
{
	// variables //
	
	
	// variables for: adjusting volume //
	protected AudioSource[] audioSources;		// connections - auto: the locomotion audio sources (of which to adjust the volume)

	


	// methods //

	
	// method: adjust the audio source's volume by the given amount //
	protected override void adjustVolume(float amount)
	{
		foreach (AudioSource audioSource in audioSources)
		{
			adjustVolumeOfGivenAudioSource(audioSource, amount);
		}
	}



	// updating //

	
	// before the start: //
	protected virtual void Awake()
	{
		// connect to the locomotion audio source //
		audioSources = GetComponentsInChildren<AudioSource>();
	}
}