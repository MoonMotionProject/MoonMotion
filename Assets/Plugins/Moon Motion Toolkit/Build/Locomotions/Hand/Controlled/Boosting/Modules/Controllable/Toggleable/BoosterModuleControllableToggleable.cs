using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Module Controllable Toggleable
// • provides this controllable booster module with:
//   · a method to play the attached module toggling audio
//   · a base toggling method that just plays the module toggling audio
//   · a setting for whether this module should play its attached toggling audio when toggled via input
//     - this is not used in this class, but rather by its extending classes (since they handle the updating)
public abstract class BoosterModuleControllableToggleable : BoosterModuleControllable
{
	// variables //
	
	
	// variables for: playing toggling audio //
	private AudioSource togglingAudioSource;		// connection - auto: the audio source for playing its audio for toggling this module
	private AudioClip togglingAudio;		// connection - auto: the audio for toggling this module, set in the audio source

	// variables for: toggling via input //
	public bool inputtingPlaysTogglingAudio = true;		// setting: whether to play the attached toggling audio when toggling via input (this is just used by extending classes)
	
	// variables for: toggling //
	[Header("Toggling")]
	[Tooltip("whether the toggle should affect both hand instances of this module instead of just this one")]
	public bool toggleIsGlobal = true;		// setting: whether the toggle should affect both hand instances of this module instead of just this one
	
	
	
	
	// methods //

	
	// methods for: playing toggling audio //

	// method: play the toggling audio //
	protected virtual void playTogglingAudio()
	{
		togglingAudioSource.PlayOneShot(togglingAudio);
	}
	
	
	// methods for: toggling //
	
	// method: basely toggle this booster module by optionally playing its toggling audio //
	protected virtual void toggle(bool playAudio)
	{
		if (playAudio)
		{
			playTogglingAudio();
		}
	}
	// method: toggle both automators, optionally playing their toggling audios //
	public abstract void toggleBoth_(bool playAudios);




	// updating //

	// before the start: connect to the audio source and its audio //
	protected override void Awake()
	{
		base.Awake();
		
		togglingAudioSource = GetComponent<AudioSource>();
		togglingAudio = togglingAudioSource.clip;
	}
}