using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Force Multiplier
// • provides a force factor setting for this booster, by which the booster's force is multiplied by default
//   · in particular, this factor is used by Booster when calculating the boosting force to apply
// • upon input, toggles whether this force multiplier is alternated
//   · when this force multiplier is alternated, the default factor is not used, and instead a set alternative factor is used
//   · this can optionally be toggled globally (one controller's input has both force multipliers toggle whether they are alternated, respectively)
//   · this can optionally play the attached toggling audio
public class BoosterForceMultiplier : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	private static BoosterForceMultiplier left, right;		// trackings: force multiplier instances

	// variables for: default force multiplying //
	[Header("Default Multiplying")]
	public float forceFactorDefault = 1f;		// setting: the force factor to use by default

	// variables for: alternating //
	[Header("Alternate Multiplying")]
	public bool alternated = false;		// tracking: whether this force multiplier is alternated currently
	public float forceFactorAlternate = 2f;		// setting: the force factor to use alternately (when this force multiplier is alternated)




	// methods //
	
	
	// method: toggle whether this force multiplier is alternated //
	protected override void toggle(bool playAudio)
	{
		alternated = !alternated;

		base.toggle(playAudio);
	}
	// method: toggle both force multipliers, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both force multipliers, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	// method: determine whether this booster's force multiplier is alternated //
	public bool alternatedBooster()
	{
		return (alternated && dependencies.areMet());
	}
	// method: determine the current force factor for the given booster //
	public static float forceFactor(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return (left.alternatedBooster() ? left.forceFactorAlternate : left.forceFactorDefault);
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return (right.alternatedBooster() ? right.forceFactorAlternate : right.forceFactorDefault);
			}
		}
		return 1f;
	}
	
	
	
	
	// updating //

	
	// at the start: connect to force multiplier instances //
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
			// toggle this force multiplier //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other force multiplier as well //
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