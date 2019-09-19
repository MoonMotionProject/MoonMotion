using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skiing Toggling Audio: provides a method for the Skiers to play the attached audio source's skiing toggle audio //
public class SkiingTogglingAudio : MonoBehaviour
{
	// variables //
	
	
	// variables for: instancing //
	private static SkiingTogglingAudio singleton;		// connection - auto: the singleton instance of this class
	
	// variables for: skiing toggling audio //
	private AudioSource audioSource;		// connection - auto: the attached audio source for playing its skiing toggling audio
	private AudioClip audioClip;		// connection - auto: the skiing toggling audio on the attached audio source




	// methods //

	
	// method: play the skiing toggling audio //
	public static void play()
	{
		singleton.audioSource.PlayOneShot(singleton.audioClip);
	}




	// updating //


	// before the start: connect to the singleton instance of this class, connect to the audio source and its audio //
	private void Awake()
	{
		singleton = this;

		audioSource = GetComponent<AudioSource>();
		audioClip = audioSource.clip;
	}
}