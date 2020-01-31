using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Inertia Dampener:
// • provides toggleable inertia dampening for the parent booster
//   · this determines the factor by which Booster dampens velocity in the direction opposite that of the current boosting direction
//   · upon input, the inertia dampener's inertia dampening is toggled
//     - this can optionally be toggled globally (affecting both inertia dampeners upon the input of this controller)
//     - this can optionally play the attached toggling audio
public class BoosterInertiaDampener : BoosterModuleControllableToggleable
{
	// variables //
	

	// variables for: instancing //
	private static BoosterInertiaDampener left, right;		// tracking: inertia dampener instances

	// variables for: dampening inertia //
	[Header("Dampening Inertia")]
	public bool dampenInertia = true;		  // setting: whether to dampen inertia
	public float factor = 1f;		// setting: the inertia dampening factor (such that at 1, inertia dampening would be instantaneous; at 0, no inertia dampening would be applied)




	// methods //

	
	// method: toggle this inertia dampener //
	protected override void toggle(bool playAudio)
	{
		dampenInertia = !dampenInertia;

		base.toggle(playAudio);
	}
	// method: toggle both inertia dampeners, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both inertia dampeners, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	// method: determine whether this booster's inertia is dampened //
	public bool inertiaDampenedBooster()
	{
		return (dampenInertia && dependencies.areMet());
	}
	// method: determine whether the given booster is currently inertia dampened //
	public static bool inertiaDampened(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.inertiaDampenedBooster();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.inertiaDampenedBooster();
			}
		}
		return false;
	}
	// method: determine the inertia dampening factor for the given booster //
	public static float dampeningFactor(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.factor;
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.factor;
			}
		}
		return 1f;
	}
	
	
	
	
	// updating //

	
	// at the start: connect to inertia dampener instances //
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
			// toggle this inertia dampener //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other inertia dampener as well //
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