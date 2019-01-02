﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skiing Settings
// • provides a skiing friction setting for the Skiers to set the body's friction to when skiing
//   · also provides an alternate skiing friction setting
//     - this is used instead according to an alternated skiing friction toggle setting
//     - methods are provided to change the alternation to a given boolean or to toggle it
//   · methods are provided for the Skiers to use to determine which skiing friction setting (the main/default one, or the alternate one) to use
//     - these optionally play the attached skiing settings toggling audio
// • provides the Skiers with a setting for the skiing input style (whether skiing input must be held versus having skiing be toggled upon input)
//   · methods are provided to toggle this setting
//     - these optionally play the attached skiing settings toggling audio
public class SkiingSettings : MonoBehaviour
{
	// variables //

	
	// variables for: instancing //
	public static SkiingSettings singleton;		// connection - automatic: the singleton instance of this class

	// variables for: skiing settings toggling audio //
	private AudioSource togglingAudioSource;		// connection - automatic: the skiing settings toggling audio source
	private AudioClip togglingAudio;		// connection - automatic: the skiing settings toggling audio
	
	// variables for: skiing friction //
	[Header("Skiing Friction")]
	[Tooltip("the (main, not alternate) friction for the player's body collider to use when skiing")]
	public PhysicMaterial frictionSkiing;		// setting: the (main, not alternate) friction for the player's body collider to use when skiing
	[Tooltip("whether to use the alternate skiing friction instead of the main one")]
	public bool skiingFrictionAlternated = false;		// setting: whether to use the alternate skiing friction instead of the main one
	[Tooltip("the alternate (not main) friction for the player's body collider to use when skiing (while the friction to use when skiing is alternated according to the toggle setting)")]
	public PhysicMaterial frictionSkiingAlternate;		// setting: the alternate (not main) friction for the player's body collider to use when skiing (while the friction to use when skiing is alternated according to the toggle setting)

	// setting: skiing input style (whether skiing input must be held versus having skiing be toggled upon input) //
	[Header("Locomotion Input")]
	public bool heldVersusToggled = true;




	// methods //

	
	// methods for: skiing settings toggling audio //

	// method: optionally play the skiing settings toggling audio //
	private void optionallyPlayTogglingAudio(bool playAudio)
	{
		if (playAudio)
		{
			togglingAudioSource.PlayOneShot(togglingAudio);
		}
	}
	
	
	// methods for: skiing friction //

	// method: change whether the skiing friction is alternated to the given boolean, updating the body friction if necessary, and optionally playing the skiing settings toggling audio //
	public void changeSkiingFrictionAlternation_(bool boolean, bool playAudio)
	{
		bool bodyFrictionUpdateNeeded = ((boolean != skiingFrictionAlternated) && Skier.skiing);

		skiingFrictionAlternated = boolean;
		optionallyPlayTogglingAudio(playAudio);

		if (bodyFrictionUpdateNeeded)
		{
			Skier.updateBodyFriction();
		}
	}
	// method: change whether the skiing friction is alternated to the given boolean, optionally playing the skiing settings toggling audio //
	public static void changeSkiingFrictionAlternation(bool boolean, bool playAudio)
	{
		singleton.changeSkiingFrictionAlternation_(boolean, playAudio);
	}
	
	// method: toggle whether the skiing friction is alternated, optionally playing the skiing settings toggling audio //
	public void toggleSkiingFrictionAlternation_(bool playAudio)
	{
		changeSkiingFrictionAlternation_(!skiingFrictionAlternated, playAudio);
	}
	// method: toggle whether the skiing friction is alternated, optionally playing the skiing settings toggling audio //
	public static void toggleSkiingFrictionAlternation(bool playAudio)
	{
		singleton.toggleSkiingFrictionAlternation_(playAudio);
	}

	// method: determine the skiing friction to use (based on whether the skiing friction to use is alternated currently) //
	public PhysicMaterial skiingFrictionToUse()
	{
		if (skiingFrictionAlternated)
		{
			return frictionSkiingAlternate;
		}
		else
		{
			return frictionSkiing;
		}
	}
	
	
	// methods for: toggling input style //
	
	// method: toggle the skiing input style (toggle whether skiing input must be held versus having skiing be toggled upon input), optionally playing the skiing settings toggling audio //
	public void toggleSkiingInputStyle_(bool playAudio)
	{
		heldVersusToggled = !heldVersusToggled;
		
		optionallyPlayTogglingAudio(playAudio);
	}
	// method: toggle the skiing input style (toggle whether skiing input must be held versus having skiing be toggled upon input), optionally playing the skiing settings toggling audio //
	public static void toggleSkiingInputStyle(bool playAudio)
	{
		singleton.toggleSkiingInputStyle_(playAudio);
	}
	
	
	
	
	// updating //

	
	// before the start: //
	private void Awake()
	{
		// connect to the singleton instance of this class //
		singleton = this;

		// connect to the skiing skiing settings toggling audio source and audio //
		togglingAudioSource = GetComponent<AudioSource>();
		togglingAudio = togglingAudioSource.clip;
	}
}