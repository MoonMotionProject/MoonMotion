using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gravity Multiplier
// • provides a method to determine the player's current gravity modifier (based on both Gravity Multipliers), as well as the current gravity modifier according to just this Gravity Multiplier
//   · the force that Gravity Zones affect the player by is multiplied by the player's current gravity modifier, as determined by both Gravity Multipliers
//   · each hand's Gravity Multiplier has settings for its primary and alternated gravity modifier values
//     - a toggle setting determines whether to currently use the primary or alternated gravity modifier value
//       – methods are provided to change this alternation
//     - the player's current gravity modifier is calculated as the average of the current gravity modifier of both hands' Gravity Multipliers, for as many as are currently enabled, calculating a modifier of 1 if neither hand's Gravity Multiplier is enabled
// • alternation is directly controlled by this Gravity Multiplier differently based on whether any locomotion inputs are set:
//   · if any locomotion inputs are set: upon such input, if the locomotion dependencies are met, alternation is toggled, and the attached gravity multiplier alternating audio is played
//   · otherwise (if no locomotion inputs are set):
//     - if any dependencies are set: alternation is determined by whether the dependencies are met
//     - otherwise (if no dependencies are set): alternation is not changed by this Gravity Multiplier
public class GravityMultiplier : HandLocomotionControlled
{
	// variables //
	
	
	// variables for: instancing //
	public static GravityMultiplier left, right;		// connections - auto: left and right Gravity Multiplier instances
	
	// variables for: input //
	[Tooltip("whether this Gravity Multiplier's input toggles alternation globally (for both hands' Gravity Multipliers) instead of just this one")]
	public bool inputAlternatesGlobally = true;		// setting: whether this Gravity Multiplier's input toggles alternation globally (for both hands' Gravity Multipliers) instead of just this one
	
	// variables for: playing the attached gravity multiplier alternating audio (upon input alternation changing only) //
	private AudioSource alternatingAudioSource;		// connection - auto: the attached gravity multiplier alternating audio source (for input alternation changing only)
	private AudioClip alternatingAudio;		// connection - auto: the attached gravity multiplier alternating audio (for input alternation changing only)
	
	// variables for: gravity modifiers //
	[Header("Modifiers")]
	[Tooltip("the primary gravity modifier, to use when not alternated (in average with the currently used gravity modifier of the other hand's Gravity Multiplier, if it is enabled)")]
	public float modifierPrimary = 1f;		// setting: the primary gravity modifier, to use when not alternated (in average with the currently used gravity modifier of the other hand's Gravity Multiplier, if it is enabled)
	[Tooltip("the alternate gravity modifier, to use when alternated (in average with the currently used gravity modifier of the other hand's Gravity Multiplier, if it is enabled)")]
	public float modifierAlternate = .5f;		// setting: the alternate gravity modifier, to use when alternated (in average with the currently used gravity modifier of the other hand's Gravity Multiplier, if it is enabled)

	// variables for: alternating //
	[Tooltip("whether this Gravity Multiplier is alternated currently (set to use the alternate gravity modifier instead of the primary one)")]
	public bool alternated = false;		// setting: whether this Gravity Multiplier is alternated currently (set to use the alternate gravity modifier instead of the primary one)




	// methods //

	
	// methods for: playing the attached gravity multiplier alternating audio (upon input alternation changing only) //

	// method: play the attached gravity multiplier alternating audio //
	public void playAlternatingAudio()
	{
		alternatingAudioSource.PlayOneShot(alternatingAudio);
	}

	
	// methods for: adjusting the gravity modifier settings //

	// method: change the primary gravity modifier to the given modifier for this Gravity Multiplier //
	public void changeModifierPrimary(float modifier)
	{
		modifierPrimary = modifier;
	}
	// method: change the primary gravity modifier to the given modifier for the given Gravity Multiplier //
	public static void changeModifierPrimary(GravityMultiplier gravityMultiplier, float modifier)
	{
		gravityMultiplier.changeModifierPrimary(modifier);
	}
	// method: change the primary gravity modifier to the given modifier for the given Gravity Multiplier //
	public void changeModifierPrimary_(GravityMultiplier gravityMultiplier, float modifier)
	{
		changeModifierPrimary(gravityMultiplier, modifier);
	}
	// method: change the primary gravity modifier to the given modifier for the left Gravity Multiplier //
	public static void changeModifierPrimaryLeft(float modifier)
	{
		left.changeModifierPrimary(modifier);
	}
	// method: change the primary gravity modifier to the given modifier for the left Gravity Multiplier //
	public void changeModifierPrimaryLeft_(float modifier)
	{
		changeModifierPrimaryLeft(modifier);
	}
	// method: change the primary gravity modifier to the given modifier for the right Gravity Multiplier //
	public static void changeModifierPrimaryRight(float modifier)
	{
		right.changeModifierPrimary(modifier);
	}
	// method: change the primary gravity modifier to the given modifier for the right Gravity Multiplier //
	public void changeModifierPrimaryRight_(float modifier)
	{
		changeModifierPrimaryRight(modifier);
	}
	// method: change the primary gravity modifier to the given modifier for both Gravity Multipliers //
	public static void changeModifierPrimaryBoth(float modifier)
	{
		changeModifierPrimaryLeft(modifier);
		changeModifierPrimaryRight(modifier);
	}
	// method: change the primary gravity modifier to the given modifier for both Gravity Multipliers //
	public void changeModifierPrimaryBoth_(float modifier)
	{
		changeModifierPrimaryBoth(modifier);
	}
	// method: change the alternate gravity modifier to the given modifier for this Gravity Multiplier //
	public void changeModifierAlternate(float modifier)
	{
		modifierAlternate = modifier;
	}
	// method: change the alternate gravity modifier to the given modifier for the given Gravity Multiplier //
	public static void changeModifierAlternate(GravityMultiplier gravityMultiplier, float modifier)
	{
		gravityMultiplier.changeModifierAlternate(modifier);
	}
	// method: change the alternate gravity modifier to the given modifier for the given Gravity Multiplier //
	public void changeModifierAlternate_(GravityMultiplier gravityMultiplier, float modifier)
	{
		changeModifierAlternate(gravityMultiplier, modifier);
	}
	// method: change the alternate gravity modifier to the given modifier for the left Gravity Multiplier //
	public static void changeModifierAlternateLeft(float modifier)
	{
		left.changeModifierAlternate(modifier);
	}
	// method: change the alternate gravity modifier to the given modifier for the left Gravity Multiplier //
	public void changeModifierAlternateLeft_(float modifier)
	{
		changeModifierAlternateLeft(modifier);
	}
	// method: change the alternate gravity modifier to the given modifier for the right Gravity Multiplier //
	public static void changeModifierAlternateRight(float modifier)
	{
		right.changeModifierAlternate(modifier);
	}
	// method: change the alternate gravity modifier to the given modifier for the right Gravity Multiplier //
	public void changeModifierAlternateRight_(float modifier)
	{
		changeModifierAlternateRight(modifier);
	}
	// method: change the alternate gravity modifier to the given modifier for both Gravity Multipliers //
	public static void changeModifierAlternateBoth(float modifier)
	{
		changeModifierAlternateLeft(modifier);
		changeModifierAlternateRight(modifier);
	}
	// method: change the alternate gravity modifier to the given modifier for both Gravity Multipliers //
	public void changeModifierAlternateBoth_(float modifier)
	{
		changeModifierAlternateBoth(modifier);
	}
	
	
	// methods for: changing alternation //

	// method: change alternation to the given boolean for this Gravity Multiplier, optionally playing the alternating audio //
	public void changeAlternation(bool boolean, bool playAudio)
	{
		alternated = boolean;

		// optionally play the alternating audio //
		if (playAudio)
		{
			playAlternatingAudio();
		}
	}
	// method: change alternation to the given boolean for the given Gravity Multiplier, optionally playing the alternating audio //
	public static void changeAlternation(GravityMultiplier gravityMultiplier, bool boolean, bool playAudio)
	{
		gravityMultiplier.changeAlternation(boolean, playAudio);
	}
	// method: change alternation to the given boolean for the given Gravity Multiplier, optionally playing the alternating audio //
	public void changeAlternation_(GravityMultiplier gravityMultiplier, bool boolean, bool playAudio)
	{
		changeAlternation(gravityMultiplier, boolean, playAudio);
	}
	// method: change alternation to the given boolean for the left Gravity Multiplier, optionally playing the alternating audio //
	public static void changeAlternationLeft(bool boolean, bool playAudio)
	{
		changeAlternation(left, boolean, playAudio);
	}
	// method: change alternation to the given boolean for the left Gravity Multiplier, optionally playing the alternating audio //
	public void changeAlternationLeft_(bool boolean, bool playAudio)
	{
		changeAlternationLeft(boolean, playAudio);
	}
	// method: change alternation to the given boolean for the right Gravity Multiplier, optionally playing the alternating audio //
	public static void changeAlternationRight(bool boolean, bool playAudio)
	{
		changeAlternation(right, boolean, playAudio);
	}
	// method: change alternation to the given boolean for the left Gravity Multiplier, optionally playing the alternating audio //
	public void changeAlternationRight_(bool boolean, bool playAudio)
	{
		changeAlternationRight(boolean, playAudio);
	}
	// method: change alternation to the given boolean for both Gravity Multipliers, optionally playing the alternating audio //
	public static void changeAlternationBoth(bool boolean, bool playAudio)
	{
		changeAlternationLeft(boolean, playAudio);
		changeAlternationRight(boolean, playAudio);
	}
	// method: change alternation to the given boolean for both Gravity Multipliers, optionally playing the alternating audio //
	public void changeAlternationBoth_(bool boolean, bool playAudio)
	{
		changeAlternationBoth(boolean, playAudio);
	}
	// method: toggle alternation for this Gravity Multiplier, optionally playing the alternating audio //
	public void toggleAlternation(bool playAudio)
	{
		changeAlternation(!alternated, playAudio);
	}
	// method: toggle alternation for the given Gravity Multiplier, optionally playing the alternating audio //
	public static void toggleAlternation(GravityMultiplier gravityMultiplier, bool playAudio)
	{
		gravityMultiplier.toggleAlternation(playAudio);
	}
	// method: toggle alternation for the given Gravity Multiplier, optionally playing the alternating audio //
	public void toggleAlternation_(GravityMultiplier gravityMultiplier, bool playAudio)
	{
		toggleAlternation(gravityMultiplier, playAudio);
	}
	// method: toggle alternation for the left Gravity Multiplier, optionally playing the alternating audio //
	public static void toggleAlternationLeft(bool playAudio)
	{
		toggleAlternation(left, playAudio);
	}
	// method: toggle alternation for the left Gravity Multiplier, optionally playing the alternating audio //
	public void toggleAlternationLeft_(bool playAudio)
	{
		toggleAlternationLeft(playAudio);
	}
	// method: toggle alternation for the right Gravity Multiplier, optionally playing the alternating audio //
	public static void toggleAlternationRight(bool playAudio)
	{
		toggleAlternation(right, playAudio);
	}
	// method: toggle alternation for the left Gravity Multiplier, optionally playing the alternating audio //
	public void toggleAlternationRight_(bool playAudio)
	{
		toggleAlternationRight(playAudio);
	}
	// method: toggle alternation for both Gravity Multipliers, optionally playing the alternating audio //
	public static void toggleAlternationBoth(bool playAudio)
	{
		toggleAlternationLeft(playAudio);
		toggleAlternationRight(playAudio);
	}
	// method: toggle alternation for both Gravity Multipliers, optionally playing the alternating audio //
	public void toggleAlternationBoth_(bool playAudio)
	{
		toggleAlternationBoth(playAudio);
	}
	// method: toggle alternation for input (possibly globally, depending on the setting for whether input alternates globally; playing the alternating audio) //
	public void toggleAlternationForInput()
	{
		if (inputAlternatesGlobally)
		{
			toggleAlternationBoth(true);
		}
		else
		{
			toggleAlternation(true);
		}
	}


	// methods for: determining the player's current gravity modifier //

	// method: determine the current gravity modifier just as provided by this Gravity Multiplier (not the global average that is to be used by Gravity Zones) //
	public float currentGravityModifierThisHandOnly()
	{
		if (alternated)
		{
			return modifierAlternate;
		}
		else
		{
			return modifierPrimary;
		}
	}
	// method: determine the player's current gravity modifier (calculated as the average of the current gravity modifier of both hands, for as many as are currently enabled, calculating a modifier of 1 if neither hand's Gravity Multiplier is enabled) //
	public static float currentGravityModifier()
	{
		bool leftMultiplierActive = (left && left.gameObject);
		bool rightMultiplierActive = (right && right.gameObject);

		if (leftMultiplierActive && rightMultiplierActive)
		{
			return ((left.currentGravityModifierThisHandOnly() + right.currentGravityModifierThisHandOnly()) / 2f);
		}
		else if (leftMultiplierActive)
		{
			return left.currentGravityModifierThisHandOnly();
		}
		else if (rightMultiplierActive)
		{
			return right.currentGravityModifierThisHandOnly();
		}
		else
		{
			return 1f;
		}
	}
	// method: determine the player's current gravity modifier //
	public float currentGravityModifier_()
	{
		return currentGravityModifier();
	}
	
	
	
	
	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to the gravity multiplier alternating audio source and audio //
		alternatingAudioSource = GetComponent<AudioSource>();
		alternatingAudio = alternatingAudioSource.clip;
	}
	
	// upon being enabled: //
	private void OnEnable()
	{
		// connect to the corresponding instance of this class //
		if (leftInstance)
		{
			left = this;
		}
		else
		{
			right = this;
		}
	}

	// at each update: //
	private void Update()
	{
		// if: locomotion input is enabled and allowed, locomotion input is pressing: //
		if (locomotionInputEnabledAndAllowed() && controller.inputPressing(inputsLocomotion))
		{
			// toggle alternation for input //
			toggleAlternationForInput();
		}
		// otherwise: if no actual locomotion inputs are set //
		else if (!Controller.anyActualInputs(inputsLocomotion))
		{
			// if any locomotion dependencies are set: //
			if (Any.itemsIn(locomotionDependencies))
			{
				// set the alternation of this gravity multiplier to whether the locomotion dependencies are met //
				alternated = locomotionDependencies.areMet();
			}
		}
	}
}