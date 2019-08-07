using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Refueler
// • provides the amount by which to refuel the parent booster (by adding to the parent booster's Booster Fuel Supply's fuel force)
//   · the fuel unit used is also the unit of force, as defined by Booster Fuel Supply
// • upon input, toggles whether this refueler is refueling
//   - this can optionally be toggled globally (affecting both refuelers upon the input of this controller)
//   - this can optionally play the attached toggling audio
public class BoosterRefueler : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	private static BoosterRefueler left, right;		// trackings: refueler instances

	// variables for: refueling //
	[Header("Refueling")]
	public bool refueling = true;		// tracking: whether this refueler is currently refueling the parent booster
	public float fuelForceProduction = 600f;		// setting: fuel force amount produced each time refueling occurs




	// methods //
	
	
	// method: toggle this refueler //
	protected override void toggle(bool playAudio)
	{
		refueling = !refueling;

		base.toggle(playAudio);
	}
	// method: toggle both refuelers, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both refuelers, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	// method: determine whether this booster's refueler is currently refueling //
	public bool boosterRefueling()
	{
		return (refueling && dependencies.areMet());
	}
	// method: determine whether the given booster's refueler is currently refueling //
	public static bool boosterRefueling(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left.boosterRefueling();
		}
		else
		{
			return right.boosterRefueling();
		}
	}
	
	// method: determine the fuel force production amount for this booster //
	public float productionAmount()
	{
		return (boosterRefueling() ? fuelForceProduction : 0f);
	}
	// method: determine the fuel force production amount for the given booster //
	public static float productionAmount(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.productionAmount();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.productionAmount();
			}
		}
		return 0f;
	}
	
	
	
	
	// updating //

	
	// at the start: connect to refueler instances //
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
			// toggle this refueler //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other refueler as well //
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