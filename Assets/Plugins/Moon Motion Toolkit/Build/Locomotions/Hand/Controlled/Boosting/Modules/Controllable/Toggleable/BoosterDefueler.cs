using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Defueler
// • provides a method to Booster for reducing the corresponding Booster Fuel Supply's current fuel force amount (for when using up fuel when boosting)
//   · the fuel unit used is also the unit of force, as defined by Booster Fuel Supply
//   · a defueling factor is provided by which to multiply the amount of fuel removed
// • upon input, toggles whether defueling is enabled (whether the parent booster uses up fuel when boosting)
//   - this can optionally be toggled globally (affecting both defuelers upon the input of this controller)
//   - this can optionally play the attached toggling audio
public class BoosterDefueler : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	private static BoosterDefueler left, right;		// trackings: defueler instances

	// variables for: defueling //
	[Header("Defueling")]
	[Tooltip("whether the parent booster should use up fuel when boosting (only for its main boosting force, not any boosting forces of other modules)")]
	public bool defuelingEnabled = true;		// tracking: whether defueling is enabled currently (whether the parent booster should use up fuel when boosting (only for its main boosting force, not any boosting forces of other modules))
	public float defuelingFactor = 1f;		// setting: a factor by which to multiply the amount of fuel removed




	// methods //
	
	
	// method: toggle this defueler //
	protected override void toggle(bool playAudio)
	{
		defuelingEnabled = !defuelingEnabled;

		base.toggle(playAudio);
	}
	// method: toggle both defuelers, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both defuelers, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	// method: determine whether this booster's defueling is currently enabled //
	public bool enabledDefueling()
	{
		return (defuelingEnabled && dependencies.areMet());
	}
	// method: determine whether the given booster's defueling is currently enabled //
	public static bool enabledDefueling(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left.enabledDefueling();
		}
		else
		{
			return right.enabledDefueling();
		}
	}

	// method: if defueling is enabled: have Booster Fuel Supply remove the given fuel force reduction amount for this booster //
	public void defuel(float reduction)
	{
		if (enabledDefueling())
		{
			BoosterFuelSupply.removeFuelForce(booster, (reduction * defuelingFactor));
		}
	}
	// method: if defueling is enabled: remove the given fuel force reduction amount for the given booster //
	public static void defuel(Booster booster, float reduction)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				left.defuel(reduction);
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				right.defuel(reduction);
			}
		}
	}
	
	
	
	
	// updating //

	
	// at the start: connect to defueler instances //
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
			// toggle this defueler //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other defueler as well //
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