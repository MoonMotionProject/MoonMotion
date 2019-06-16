using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skiing Settings
// • provides a toggle which, when enabled, enables skiing at the start
// • provides a skiing friction setting for the Skiers to set the body's friction to when skiing
//   · also provides an alternate skiing friction setting
//     - this is used instead according to an alternated skiing friction toggle setting
//     - methods are provided to change the alternation to a given boolean or to toggle it
//   · methods are provided for the Skiers to use to determine which skiing friction setting (the main/default one, or the alternate one) to use
//     - these optionally play the attached skiing settings toggling audio
// • provides the Skiers with a setting for the skiing input style (whether skiing input must be held versus having skiing be toggled upon input)
//   · methods are provided to toggle this setting
//     - these optionally play the attached skiing settings toggling audio
public class SkiingSettings : SingletonBehaviour<SkiingSettings>
{
	// variables //

	
	// settings for: enabling skiing at the start //

	[BoxGroup("Enabling Skiing at the Start")]
	[Tooltip("whether to enable skiing at the start")]
	public bool enableSkiingAtStart = false;


	// variables for: skiing friction //

	[BoxGroup("Skiing Friction")]
	[Tooltip("the (main, not alternate) friction for the player's body collider to use when skiing")]
	public PhysicMaterial frictionSkiing;

	[BoxGroup("Skiing Friction")]
	[Tooltip("whether to use the alternate skiing friction instead of the main one")]
	public bool skiingFrictionAlternated = false;

	[BoxGroup("Skiing Friction")]
	[Tooltip("the alternate (not main) friction for the player's body collider to use when skiing (while the friction to use when skiing is alternated according to the toggle setting)")]
	public PhysicMaterial frictionSkiingAlternate;


	// settings for: locomotion input //

	[BoxGroup("Locomotion Input")]
	[Tooltip("whether skiing input must be held versus having skiing be toggled upon input")]
	public bool heldVersusToggled = true;




	// methods //

	
	// methods for: skiing settings toggling audio //

	// method: optionally play the skiing settings toggling audio //
	private void optionallyPlayTogglingAudio(bool playAudio)
	{
		if (playAudio)
		{
			audioSource.PlayOneShot(audio);
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

	
	// at the start: //
	private void Start()
	{
		if (enableSkiingAtStart)
		{
			Skier.enableSkiing();
		}
	}
}