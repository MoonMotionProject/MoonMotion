using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Pulser
// • provides pulsing force calculating information for Booster to add to its boosting force calculation
// • upon input, toggles whether this pulser is pulsing
//   · when this pulser is not pulsing: the pulsing force is 0
//   · when this pulser is pulsing: the pulsing force is a set percentage of the main boosting force, multiplied by sine of time divided by a set frequency factor
//   · this can optionally be toggled globally (affecting both automators upon the input of this controller)
//   · this can optionally play the attached toggling audio
public class BoosterPulser : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	public static BoosterPulser left, right;		// trackings: pulser instances

	// variables for: pulsing //
	[Header("Pulsing")]
	[Tooltip("whether this pulser is pulsing currently")]
	public bool pulsing = false;        // tracking: whether this pulser is pulsing currently
	[Tooltip("the percentage of the main boosting force from which to calculate the pulsing force")]
	public float forcePercentage = .3f;		// setting: the percentage of the main boosting force from which to calculate the pulsing force
	[Tooltip("a value determining the frequency of the sine repetitions (by dividing the time passed to sine by this value)")]
	public float frequencyFactor = .7f;     // setting: a value determining the frequency of the sine repetitions (by dividing the time passed to sine by this value)
	[Tooltip("whether to pulse based on only the part of the main boosting force that is in the player's up direction (versus the whole main boosting force)")]
	public bool playerUpDirectionOnly = true;		// setting: whether to pulse based on only the part of the main boosting force that is in the player's up direction (versus the whole main boosting force)




	// methods //
	
	
	// method: toggle whether this pulser is pulsing //
	protected override void toggle(bool playAudio)
	{
		pulsing = !pulsing;

		base.toggle(playAudio);
	}
	// method: toggle both pulsers, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both pulsers, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}

	// method: change whether this pulser pulses in the player's up direction only to the given boolean //
	public void changePlayerUpDirectionOnly(bool boolean)
	{
		playerUpDirectionOnly = boolean;
	}
	// method: toggle whether this pulser pulses in the player's up direction only //
	public void togglePlayerUpDirectionOnly()
	{
		changePlayerUpDirectionOnly(!playerUpDirectionOnly);
	}
	
	// method: determine whether this booster is currently pulsed //
	public bool pulsedBooster()
	{
		return (pulsing && dependencies.areMet());
	}
	// method: determine the current pulsing force percentage (of the main boosting force) to use for the given booster //
	public static float pulsingForcePercentage(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return (left.pulsedBooster() ? left.forcePercentage : 0f);
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return (right.pulsedBooster() ? right.forcePercentage : 0f);
			}
		}
		return 0f;
	}
	// method: determine whether the given booster should pulse based on only the part of the main boosting force that is in the player's up direction //
	public static float pulsingForceFrequency(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.frequencyFactor;
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.frequencyFactor;
			}
		}
		return .7f;
	}
	// method: determine whether to pulse the player's up direction only for the given booster //
	public static bool pulsingPlayerUpDirectionOnly(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.playerUpDirectionOnly;
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.playerUpDirectionOnly;
			}
		}
		return true;
	}
	
	
	
	
	// updating //

	
	// at the start: connect to relativizer instances //
	protected override void Start()
	{
		base.Start();

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
		// if input is enabled and input is pressing: //
		if (inputEnabled && controller.inputPressing(inputs))
		{
			// toggle this pulser //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other pulser as well //
			if (toggleIsGlobal)
			{
				if (leftInstance)
				{
					right.toggle(inputtingPlaysTogglingAudio);
				}
				else
				{
					left.toggle(inputtingPlaysTogglingAudio);
				}
			}
		}
	}
}