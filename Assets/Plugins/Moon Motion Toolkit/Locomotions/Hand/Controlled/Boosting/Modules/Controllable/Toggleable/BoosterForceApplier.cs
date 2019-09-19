using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Force Applier
// • provides the parent booster with force qualities:
//   · amounts for both:
//     - shallow boosting
//     - deep boosting
//   · the force direction
// • applies forces for the parent booster, to the player rigidbody
//   · the force unit used is also the unit of fuel, as defined by Booster Fuel Supply
//   · this does not include any forces accounted for by booster modules; only the main boosting force is applied by this module
// • upon input, toggles whether this force applier actually applies force
//   · this can optionally be toggled globally (affecting both force appliers upon the input of this controller)
//   · this can optionally play the attached toggling audio
// • provides a fuel threshold setting for deep force to threshold the min amount of fuel required before starting to apply the deep force (a restriction used for preventing the sputtering of deep force just as enough fuel becomes available to use; this is rather different than the fuel cost set by the force amount); upon application of the deep force (necessarily when at or above the threshold), the threshold will be "swung open" (like a floodgate) until the deep force ceases (due to either ending of input or lack of fuel) – this is handled in Booster
public class BoosterForceApplier : BoosterModuleControllableToggleable
{
	// variables //

	
	// variables for: instancing //
	public static BoosterForceApplier left, right;		// tracking: force applier instances

	// variables for: force qualities //
	[Header("Force Qualities")]
	[Tooltip("the amount of force applied for shallow boosting of the booster's main boosting force")]
	public float forceShallow = 300f;	   // setting: the amount of force applied for shallow boosting of the booster's main boosting force
	[Tooltip("the amount of force applied for deep boosting of the booster's main boosting force")]
	public float forceDeep = 800f;	  // setting: the amount of force applied for deep boosting of the booster's main boosting force
	public BasicDirection forceDirection = BasicDirection.up;	   // setting: the direction of force applied for boosting (aimed for by rotating the booster) (opposite of the boosting direction (which is the direction that the jet goes out in))
	
	// variables for: applying force //
	private Rigidbody playerRigidbody;		// connection - auto: the player rigidbody (to apply boosting force to)
	[Header("Applying Force")]
	[Tooltip("whether the parent booster should apply its main boosting force (disregarding any boosting forces from other modules)")]
	public bool applyingForce = true;		// setting: whether this force applier is applying force (whether the parent booster should apply its main boosting force (disregarding any boosting forces from other modules))
	[Tooltip("a threshold for the min amount of fuel required before starting to apply the deep force (a restriction used for preventing the sputtering of force just as enough fuel becomes available to use; this is rather different than the fuel cost set by the force amount)")]
	public float fuelThreshold = 45000f;		// setting: a threshold for the min amount of fuel required before starting to apply the deep force (a restriction used for preventing the sputtering of deep force just as enough fuel becomes available to use; this is rather different than the fuel cost set by the force amount)




	// methods //

	
	// methods for: toggling //
	
	// method: toggle this force applier, optionally playing its toggling audio //
	protected override void toggle(bool playAudio)
	{
		applyingForce = !applyingForce;

		base.toggle(playAudio);
	}
	// method: toggle both force appliers, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both force appliers, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	

	// methods for: force qualities //

	// method: determine the shallow force amount for the given booster //
	public static float amountShallow(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.forceShallow;
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.forceShallow;
			}
		}
		return 300f;
	}
	// method: determine the deep force amount for the given booster //
	public static float amountDeep(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.forceDeep;
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.forceDeep;
			}
		}
		return 800f;
	}
	// method: determine the force direction for the given booster //
	public static BasicDirection direction(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.forceDirection;
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.forceDirection;
			}
		}
		return BasicDirection.up;
	}
	
	
	// methods for: applying force //

	// method: determine whether this booster is applying force //
	public bool boosterApplyingForce()
	{
		return (applyingForce && dependencies.areMet());
	}
	// method: have this force applier apply the given force to the player's rigidbody, if it is set to apply force currently //
	private void applyForceIfEnabled(Vector3 forceToApply)
	{
		if (boosterApplyingForce())
		{
			playerRigidbody.AddForce(forceToApply);
		}
	}
	// method: have the force applier corresponding to the given booster apply the given force to the player's rigidbody if the applier's force application is enabled //
	public static void applyForce(Booster booster, Vector3 forceToApply)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				left.applyForceIfEnabled(forceToApply);
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				right.applyForceIfEnabled(forceToApply);
			}
		}
	}
	// method: determine the fuel threshold for deep force for this booster //
	public float boosterFuelThreshold()
	{
		return fuelThreshold;
	}
	// method: determine the fuel threshold for deep force for the given booster //
	public static float fuelThresholdForBooster(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.boosterFuelThreshold();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.boosterFuelThreshold();
			}
		}
		return 45000f;
	}




	// updating //

	
	// at the start: connect to force applier instances, connect to the player's rigidbody (via the booster) //
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

		playerRigidbody = booster.playerRigidbody;
	}

	// at each update: //
	private void Update()
	{
		// if input is enabled and input is pressing: //
		if (inputEnabled && controller.inputPressing(inputs))
		{
			// toggle this force applier //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other force applier as well //
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