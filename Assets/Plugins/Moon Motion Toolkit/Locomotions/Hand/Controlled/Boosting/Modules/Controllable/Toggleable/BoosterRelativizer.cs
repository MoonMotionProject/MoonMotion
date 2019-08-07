using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Relativizer
// • provides a setting for this booster's default relativity transform, by which the booster's force direction is determined by default
//   · in particular, this relativity transform is used by Booster and Booster Diminisher
// • upon input, toggles whether this relativizer is alternated
//   · when this relativizer is alternated, the default relativity transform is not used, and instead a set alternative relativity transform is used
//   · this can optionally be toggled globally (one controller's input has both relativizers toggle whether they are alternated, respectively)
//   · this can optionally play the attached toggling audio
public class BoosterRelativizer : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	private static BoosterRelativizer left, right;		// trackings: relativizer instances

	// variables for: default relativizing //
	[Header("Default Relativizing")]
	public Transform relativityTransformDefault;		// setting: the relativity transform to use by default

	// variables for: alternating //
	[Header("Alternate Relativizing")]
	public bool alternated = false;		// tracking: whether this relativizer is alternated currently
	public Transform relativityTransformAlternate;		// setting: the relativity transform to use alternately (when this relativizer is alternated)




	// methods //
	
	
	// method: toggle whether this relativizer is alternated //
	protected override void toggle(bool playAudio)
	{
		alternated = !alternated;

		base.toggle(playAudio);
	}
	// method: toggle both relativizers, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both relativizers, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	// method: determine whether this booster's relativity transform is currently alternated //
	public bool boosterRelativityTransformAlternated()
	{
		return (alternated && dependencies.areMet());
	}
	// method: determine the current relativity transform to use for the given booster //
	public static Transform relativityTransform(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return (left.boosterRelativityTransformAlternated() ? left.relativityTransformAlternate : left.relativityTransformDefault);
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return (right.boosterRelativityTransformAlternated() ? right.relativityTransformAlternate : right.relativityTransformDefault);
			}
		}
		return booster.transform;
	}
	
	
	
	
	// updating //

	
	// at the start: connect to relativizer instances //
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
			// toggle this relativizer //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other relativizer as well //
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