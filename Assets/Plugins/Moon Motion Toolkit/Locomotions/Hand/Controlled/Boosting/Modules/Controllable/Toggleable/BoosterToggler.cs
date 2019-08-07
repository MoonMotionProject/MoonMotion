using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Toggler
// • upon input, toggles whether the parent booster's boosting is enabled (able to occur via input)
//   - this can optionally be toggled globally (affecting both togglers upon the input of this controller)
//   - this can optionally play the attached toggling audio
//   - this currently serves as a more sophisticated/featured way of doing the same thing as toggling the booster locomotion input; furthermore, by having this equivalent but separate condition to toggling the locomotion input, there are effectively two separate places where this toggling can be toggled, allowing for two separate togglings acting as logical gates, potentially by two respectively separate external conditioners (things trying to control whether boosting is enabled), allowing for easier control of whether boosting is enabled instead of having the state clash under the control of two conditioners where in that case when one turns it on, the other may not want it turned on, the conflict manifesting into a problem
public class BoosterToggler : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	private static BoosterToggler left, right;		// trackings: toggler instances

	// variables for: toggling boosting //
	[Header("Toggling Boosting")]
	public bool boostingEnabled = true;		// tracking: whether boosting is enabled currently (whether boosting should occur upon input)




	// methods //
	
	
	// method: toggle this toggler //
	protected override void toggle(bool playAudio)
	{
		boostingEnabled = !boostingEnabled;

		base.toggle(playAudio);
	}
	// method: toggle both togglers, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both togglers, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	// method: determine whether this booster's boosting is currently enabled //
	public bool enabledBoosting()
	{
		return (boostingEnabled && dependencies.areMet());
	}
	// method: determine whether the given booster's boosting is currently enabled //
	public static bool enabledBoosting(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.enabledBoosting();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.enabledBoosting();
			}
		}
		return true;
	}
	
	
	
	
	// updating //

	
	// at the start: connect to toggler instances //
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
			// toggle this toggler //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other toggler as well //
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