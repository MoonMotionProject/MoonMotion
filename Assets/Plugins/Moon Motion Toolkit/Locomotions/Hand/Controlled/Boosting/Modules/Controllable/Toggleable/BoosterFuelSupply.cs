using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Fuel Supply
// • initially sets and tracks the fuel force supply currently held for the parent booster to use for boosting; this fuel force supply is, respectively:
//   · defueled by Booster Defueler
//   · applied by Booster Force Applier
//   · refueled by Booster Refueler
//   · managed by Booster
// • sets the max fuel force supply amount, by which the current fuel force is limited
// • provides fuel clamping functionality by which Booster has this supply clamp its current fuel force amount to be within the max fuel force amount
// • upon input, toggles whether the parent booster's supply is enabled (determining whether the booster is able to use the fuel force of the supply)
//   - this can optionally be toggled globally (affecting both supplies upon the input of this controller)
//   - this can optionally play the attached toggling audio
// • provides methods to adjust the current fuel supply
public class BoosterFuelSupply : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	private static BoosterFuelSupply left, right;		// trackings: supply instances

	// variables for: fuel force supply availability //
	[Header("Fuel Force Supply")]
	public bool supplyEnabled = true;		// tracking: whether the parent booster's supply is enabled (determining whether the booster is able to use the fuel force of the supply)

	// variables for: fuel force supply handling //
	[Tooltip("current fuel force amount (a fuel force is a fuel amount unit corresponding directly to the unit for force applied by boosting (such that if, for example, 100 fuel is expelled, 100 force will be applied))")]
	public float fuelForce = 90000f;	  // setting: current fuel force amount (a fuel force is a fuel amount unit corresponding directly to the unit for force applied by boosting (such that if, for example, 100 fuel is expelled, 100 force will be applied))
	[Tooltip("max fuel force amount by which the current fuel force is limited")]
	public float fuelForceMax = 90000f;	   // setting: max fuel force amount by which the current fuel force is limited




	// methods //

	
	// methods for: fuel force supply availability //
	
	// method: toggle this supply //
	protected override void toggle(bool playAudio)
	{
		supplyEnabled = !supplyEnabled;

		base.toggle(playAudio);
	}
	// method: toggle both supplies, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both supplies, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	// method: determine whether this booster's supply is currently enabled //
	public bool enabledSupply()
	{
		return (supplyEnabled && dependencies.areMet());
	}
	// method: determine whether the given booster's supply is currently enabled //
	public static bool enabledSupply(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left.enabledSupply();
		}
		else
		{
			return right.enabledSupply();
		}
	}


	// methods for: fuel force supply handling //

	// method: add the given fuel force addition amount to the supply of this booster //
	public void addFuelForce(float addition)
	{
		fuelForce += addition;
		clamp();
	}
	// method: add the given fuel force addition amount to the supply of the given booster //
	public static void addFuelForce(Booster booster, float addition)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				left.addFuelForce(addition);
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				right.addFuelForce(addition);
			}
		}
	}
	// method: add the given fuel force addition amount to the supply of the given booster //
	public void addFuelForce_(Booster booster, float addition)
	{
		addFuelForce(booster, addition);
	}
	// method: add the given fuel force addition amount to the supply of both boosters //
	public static void addFuelForceToBoth(float addition)
	{
		left.addFuelForce(addition);
		right.addFuelForce(addition);
	}
	// method: add the given fuel force addition amount to the supply of both boosters //
	public void addFuelForceToBoth_(float addition)
	{
		addFuelForceToBoth(addition);
	}
	// method: determine the amount of currently accessible fuel force for this booster //
	public float accessibleFuelForce()
	{
		return (enabledSupply() ? fuelForce : 0f);
	}
	// method: determine the amount of currently accessible fuel force for the given booster //
	public static float accessibleFuelForce(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.accessibleFuelForce();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.accessibleFuelForce();
			}
		}
		return 90000f;
	}
	// method: determine the max amount of fuel of the supply for the given booster //
	public static float maxFuelForce(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left.fuelForceMax;
		}
		else
		{
			return right.fuelForceMax;
		}
	}
	// method: clamp the fuel force supply for this booster //
	public void clamp()
	{
		if (fuelForce > fuelForceMax)
		{
			fuelForce = fuelForceMax;
		}
	}
	// method: clamp the fuel force supply for the given booster //
	public static void clamp(Booster booster)
	{
		if (booster.leftInstance)
		{
			left.clamp();
		}
		else
		{
			right.clamp();
		}
	}
	// method: clamp the fuel force supply of both boosters //
	public static void clampBoth()
	{
		left.clamp();
		right.clamp();
	}
	// method: clamp the fuel force supply of both boosters //
	public void clampBoth_()
	{
		clampBoth();
	}
	// method: remove the given fuel force reduction amount from the supply of this booster – but not to go below 0 //
	public void removeFuelForce(float reduction)
	{
		fuelForce -= reduction;
		if (fuelForce < 0f)
		{
			fuelForce = 0f;
		}
	}
	// method: remove the given fuel force reduction amount from the supply of the given booster – but not to go below 0 //
	public static void removeFuelForce(Booster booster, float reduction)
	{
		if (booster.leftInstance)
		{
			left.removeFuelForce(reduction);
		}
		else
		{
			right.removeFuelForce(reduction);
		}
	}
	// method: remove the given fuel force reduction amount from the supply of the given booster – but not to go below 0 //
	public static void removeFuelForce_(Booster booster, float reduction)
	{
		removeFuelForce(booster, reduction);
	}
	// method: remove the given fuel force reduction amount from the supply of both boosters – but not to go below 0 //
	public static void removeFuelForceFromBoth(float reduction)
	{
		left.removeFuelForce(reduction);
		right.removeFuelForce(reduction);
	}
	// method: remove the given fuel force reduction amount from the supply of both boosters – but not to go below 0 //
	public void removeFuelForceFromBoth_(float reduction)
	{
		removeFuelForceFromBoth(reduction);
	}
	// method: completely fill the fuel supply of this booster //
	public void fillSupply()
	{
		fuelForce = fuelForceMax;
	}
	// method: completely fill the fuel supply of the given booster //
	public static void fillSupply(Booster booster)
	{
		if (booster.leftInstance)
		{
			left.fillSupply();
		}
		else
		{
			right.fillSupply();
		}
	}
	// method: completely fill the fuel supply of the given booster //
	public void fillSupply_(Booster booster)
	{
		fillSupply(booster);
	}
	// method: completely fill the fuel supply of both boosters //
	public static void fillSupplyOfBoth()
	{
		left.fillSupply();
		right.fillSupply();
	}
	// method: completely fill the fuel supply of both boosters //
	public void fillSupplyOfBoth_()
	{
		fillSupplyOfBoth();
	}
	// method: completely empty the fuel supply of this booster //
	public void emptySupply()
	{
		fuelForce = 0f;
	}
	// method: completely empty the fuel supply of the given booster //
	public static void emptySupply(Booster booster)
	{
		if (booster.leftInstance)
		{
			left.emptySupply();
		}
		else
		{
			right.emptySupply();
		}
	}
	// method: completely empty the fuel supply of the given booster //
	public void emptySupply_(Booster booster)
	{
		emptySupply(booster);
	}
	// method: completely empty the fuel supply of both boosters //
	public static void emptySupplyOfBoth()
	{
		left.emptySupply();
		right.emptySupply();
	}
	// method: completely empty the fuel supply of both boosters //
	public void emptySupplyOfBoth_()
	{
		emptySupplyOfBoth();
	}
	// method: set the fuel supply to half for this booster //
	public void setSupplyToHalf()
	{
		fuelForce = (fuelForceMax / 2f);
	}
	// method: set the fuel supply to half for the given booster //
	public static void setSupplyToHalf(Booster booster)
	{
		if (booster.leftInstance)
		{
			left.setSupplyToHalf();
		}
		else
		{
			right.setSupplyToHalf();
		}
	}
	// method: set the fuel supply to half for the given booster //
	public void setSupplyToHalf_(Booster booster)
	{
		setSupplyToHalf(booster);
	}
	// method: set the fuel supply to half for both boosters //
	public static void setSupplyToHalfForBoth()
	{
		left.setSupplyToHalf();
		right.setSupplyToHalf();
	}
	// method: set the fuel supply to half for both boosters //
	public void setSupplyToHalfForBoth_()
	{
		setSupplyToHalf();
	}
	// method: set the fuel supply to the given amount for this booster //
	public void setSupplyToAmount(float amount)
	{
		fuelForce = amount;
		clamp();
	}
	// method: set the fuel supply to the given amount for the given booster //
	public static void setSupplyToAmount(Booster booster, float amount)
	{
		if (booster.leftInstance)
		{
			left.setSupplyToAmount(amount);
		}
		else
		{
			right.setSupplyToAmount(amount);
		}
	}
	// method: set the fuel supply to the given amount for the given booster //
	public void setSupplyToAmount_(Booster booster, float amount)
	{
		setSupplyToAmount(booster, amount);
	}
	// method: set the fuel supply to the given amount for both boosters //
	public static void setSupplyToAmountForBoth(float amount)
	{
		left.setSupplyToAmount(amount);
		right.setSupplyToAmount(amount);
	}
	// method: set the fuel supply to the given amount for both boosters //
	public void setSupplyToAmountForBoth_(float amount)
	{
		setSupplyToAmountForBoth(amount);
	}
	// method: set the fuel supply to the given percentage for this booster //
	public void setSupplyToPercentage(float percentage)
	{
		percentage = Mathf.Max(0f, Mathf.Min(1f, percentage));

		fuelForce = (fuelForceMax * percentage);
	}
	// method: set the fuel supply to the given percentage for the given booster //
	public static void setSupplyToPercentage(Booster booster, float percentage)
	{
		if (booster.leftInstance)
		{
			left.setSupplyToPercentage(percentage);
		}
		else
		{
			right.setSupplyToPercentage(percentage);
		}
	}
	// method: set the fuel supply to the given percentage for the given booster //
	public void setSupplyToPercentage_(Booster booster, float percentage)
	{
		setSupplyToPercentage(booster, percentage);
	}
	// method: set the fuel supply to the given percentage for both boosters //
	public static void setSupplyToPercentageForBoth(float percentage)
	{
		left.setSupplyToPercentage(percentage);
		right.setSupplyToPercentage(percentage);
	}
	// method: set the fuel supply to the given percentage for both boosters //
	public void setSupplyToPercentageForBoth_(float percentage)
	{
		setSupplyToPercentageForBoth(percentage);
	}
	
	
	
	
	// updating //

	
	// at the start: connect to supply instances //
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
			// toggle this supply //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other supply as well //
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