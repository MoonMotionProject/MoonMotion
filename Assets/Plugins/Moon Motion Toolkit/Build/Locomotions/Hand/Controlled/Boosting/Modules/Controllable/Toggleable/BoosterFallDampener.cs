using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Fall Dampener:
// • provides toggleable fall dampening for the parent booster
//   · this determines the force by which Booster dampens downward velocity of the player
//   · upon input, the fall dampener's fall dampening is toggled
//     - this can optionally be toggled globally (affecting both fall dampeners upon the input of this controller)
//     - this can optionally play the attached toggling audio
public class BoosterFallDampener : BoosterModuleControllableToggleable
{
	// variables //
	

	// variables for: instancing //
	private static BoosterFallDampener left, right;		// trackings: fall dampener instances

	// variables for: dampening falling //
	[Header("Dampening Falling")]
	public bool dampenFalling = true;		  // setting: whether to dampen falling
	public float force = 200f;	 // setting: the fall dampening force (amount of force by which to dampen falling)




	// methods //
	
	
	// method: toggle this fall dampener //
	protected override void toggle(bool playAudio)
	{
		dampenFalling = !dampenFalling;

		base.toggle(playAudio);
	}
	// method: toggle both fall dampeners, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both fall dampeners, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	// method: determine whether this booster is currently fall dampened //
	public bool fallDampenedBooster()
	{
		return (dampenFalling && dependencies.areMet());
	}
	// method: determine whether the given booster is currently fall dampened //
	public static bool fallDampened(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.fallDampenedBooster();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.fallDampenedBooster();
			}
		}
		return false;
	}
	// method: determine the fall dampening force for the given booster //
	public static float dampeningForce(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.force;
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.force;
			}
		}
		return 200f;
	}
	
	
	
	
	// updating //

	
	// at the start: connect to fall dampener instances //
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
			// toggle this fall dampener //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other fall dampener as well //
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