using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Automator
// • provides an additional layer of boosting:
//   · automatic (on by default, instead of off by default)
//   · shallow force only (not depth modulated)
//   · can be set to not use fuel
//   · upon input, the automator's automated boosting is toggled
//     - this can optionally be toggled globally (affecting both automators upon the input of this controller)
//     - this can optionally play the attached toggling audio
public class BoosterAutomator : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	private static BoosterAutomator left, right;		// trackings: automator instances

	// variables for: automatic boosting //
	[Header("Automatic Boosting")]
	public bool automaticBoosting = false;		// tracking: whether automatic boosting is on currently
	public bool usesFuel = false;		// setting: whether the automatic boosting uses fuel




	// methods //
	
	
	// method: toggle this automator //
	protected override void toggle(bool playAudio)
	{
		automaticBoosting = !automaticBoosting;

		base.toggle(playAudio);
	}
	// method: toggle both automators, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both automators, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	// method: determine whether this booster is currently automating //
	public bool automatingBooster()
	{
		return (automaticBoosting && dependencies.areMet());
	}
	// method: determine whether the given booster is currently automating //
	public static bool automating(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.automatingBooster();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.automatingBooster();
			}
		}
		return false;
	}
	// method: determine whether the given booster's automator uses fuel for automated boosting //
	public static bool usingFuel(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.usesFuel;
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.usesFuel;
			}
		}
		return false;
	}
	
	
	
	
	// updating //

	
	// at the start: connect to automator instances //
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
			// toggle this automator //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other automator as well //
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