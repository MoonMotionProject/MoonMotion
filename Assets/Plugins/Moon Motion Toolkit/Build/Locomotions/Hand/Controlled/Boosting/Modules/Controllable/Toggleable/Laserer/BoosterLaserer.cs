using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Laserer
// • upon input, toggles whether this booster laserer is lasering (enabled to render its laser)
//   - this can optionally be toggled globally (affecting both laserers upon the input of this controller)
//   - this can optionally play the attached toggling audio
public class BoosterLaserer : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	private static BoosterLaserer left, right;		// trackings: laserer instances

	// variables for: toggling rendering //
	[Header("Toggling Lasering")]
	public bool lasering = false;		// tracking: whether this laserer is lasering (enabled to render its laser) currently

	// variables for: rendering //
	private Renderer[] renderers;		// connections - auto: this laserer's renderers




	// methods //
	
	
	// method: toggle this laserer //
	protected override void toggle(bool playAudio)
	{
		lasering = !lasering;

		base.toggle(playAudio);
	}
	// method: toggle both laserers, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both laserers, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	// method: determine whether this booster's laserer is currently lasering //
	public bool boosterLasering()
	{
		return (lasering && dependencies.areMet());
	}
	// method: determine whether the given booster's laserer is currently lasering //
	public static bool laseringBooster(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left.boosterLasering();
		}
		else
		{
			return right.boosterLasering();
		}
	}




	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to this laserer's renderer //
		renderers = GetComponentsInChildren<Renderer>();
	}

	// at the start: connect to laserer instances //
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
			// toggle this laserer //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other laserer as well //
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

		// update whether this laserer's laser renderers are rendering //
		foreach (Renderer renderer in renderers)
		{
			if (renderer && renderer.gameObject)
			{
				renderer.setEnablementTo(boosterLasering());
			}
		}
	}
}