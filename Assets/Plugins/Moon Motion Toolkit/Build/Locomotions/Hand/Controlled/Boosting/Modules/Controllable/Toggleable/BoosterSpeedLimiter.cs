using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Speed Limiter:
// • provides toggleable speed limiting (where boosting is not allowed past a certain speed) for the parent booster
//   · this can optionally be toggled globally (affecting both automators upon the input of this controller)
//   · toggling via input can optionally play the attached toggling audio
public class BoosterSpeedLimiter : BoosterModuleControllableToggleable
{
	// variables //
	

	// variables for: instancing //
	private static BoosterSpeedLimiter left, right;		// tracking: speed limiter instances

	// variables for: limiting speed //
	[Header("Limiting Speed")]
	public bool limitSpeed = true;		  // setting: whether to enforce a speed limit for whether boosting is allowed
	public float speedLimit = 7f;	 // setting: the max speed to limit the player to for allowing boosting




	// methods //

	
	// method: toggle this speed limiter //
	protected override void toggle(bool playAudio)
	{
		limitSpeed = !limitSpeed;

		base.toggle(playAudio);
	}
	// method: toggle both speed limiters, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both speed limiters, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	// method: determine whether this booster's speed is currently limited //
	public bool boosterSpeedLimited()
	{
		return (limitSpeed && dependencies.areMet());
	}
	// method: determine whether the given booster is currently speed limited //
	public static bool speedLimited(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.boosterSpeedLimited();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.boosterSpeedLimited();
			}
		}
		return false;
	}
	
	// method: determine the speed limit for the given booster //
	public static float boosterSpeedLimit(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.speedLimit;
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.speedLimit;
			}
		}
		return 7f;
	}
	
	
	
	
	// updating //

	
	// at the start: connect to speed limiter instances //
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
			// toggle this speed limiter //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other speed limiter as well //
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