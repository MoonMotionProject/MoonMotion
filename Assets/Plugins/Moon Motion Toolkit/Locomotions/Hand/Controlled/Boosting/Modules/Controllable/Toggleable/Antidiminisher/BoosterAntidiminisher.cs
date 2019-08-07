using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Antidiminisher
// • provides toggleable antidiminishing for the parent booster, an opposite kind of diminishing with altered functionality
//   · antidiminishing, like the diminishing of Booster Diminisher, will reduce the booster force applied when more distant from a raycasted object of a certain layer
//   · the unique effect of antidiminishing in contrast to diminishing is that when it is occurring, the booster's (main) force to apply is reversed directionally, resulting in an attractive force instead of the usual repulsive force
//   · unlike diminishing, antidiminishing only recognizes the 'Booster Antidiminishor' layer of objects
//     - 'antidiminishor' here refers to the target objects that allow for the attracting to occur when aimed at, whereas 'antidiminisher' refers to this booster module responsible for controlling such attractive 'antidiminishing' force
//     - however, Booster Diminisher is responsible for tracking whether each booster is at distance to an antidiminishor (since it handles terrain raycasting, and terrain could be in the way of an antidiminishor)
//       – since Booster Diminisher is responsible for this raycasting to antidiminishors while determining terrain raycast distance, antidiminishors need to be considered a recognized kind of terrain via Terrain Response that is recognized by this booster's Booster Diminisher
// • includes the following same functionalities of Booster Diminisher:
//   · can optionally also hit trigger colliders (versus only nontrigger colliders)
//   · can optionally affect only certain axes
//   · the max distance to antidiminish within can be set
//   · the curve to antidiminish by can be set
//   · upon input, the antidiminisher's antidiminishing is toggled
//     - this can optionally be toggled globally (affecting both antidiminishers upon the input of this controller)
//     - this can optionally play the attached toggling audio
public class BoosterAntidiminisher : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	public static BoosterAntidiminisher left, right;		// trackings: antidiminisher instances

	// variables for: antidiminishing //
	[Header("Antidiminishing (by terrain distancing)")]
	[Tooltip("whether to antidiminish (reverse the booster force applied when pointing at 'Antidiminishor' layer objects, and reduce the booster force applied when more distant from such objects)")]
	public bool antidiminishing = true;		  // setting: whether to antidiminish (has precedence over the axis toggles below)
	[Tooltip("whether the raycasting should recognize versus pass through trigger colliders")]
	public static bool hitTriggerColliders = false;		// setting: whether the raycasting should recognize versus pass through trigger colliders
	[Tooltip("whether this antidiminisher antidiminishes on the respective coordinate axis in particular")]
	public bool antidiminishesX = true, antidiminishesY = true, antidiminishesZ = true;		// setting: whether this antidiminisher antidiminishes on the respective coordinate axis in particular
	[Tooltip("the max distance to antidiminish within (such that at max distance, but not past max distance, the booster force is totally antidiminished)")]
	public float antidiminishingDistanceMax = 30f;		// setting: the max distance to antidiminish within (such that at max distance, but not past max distance, the booster force is totally antidiminished)
	[Tooltip("the curve used for antidiminishing interpolation")]
	public InterpolationCurve antidiminishingCurve = InterpolationCurve.smoother;		// setting: the curve used for antidiminishing interpolation
	[HideInInspector] public float lastPotentialDistanceToAntidiminishor = 0f;		// tracking: the last recorded potential distance to this antidiminisher's booster's nearest raycast hit on terrain (there may have been no terrain detected), potentially of an 'Antidiminishor'; if 0, may either be no distance or even no antidiminishor hit at all – the functionality in either case is the same
	[HideInInspector] public bool atDistanceToAntidiminishor = false;		// tracking: whether the booster was at any distance to an 'Antidiminishor' last time it raycasted to determine distance to potential terrain




	// methods //
	
	
	// methods for: toggling antidiminishing //
	
	// method: toggle this antidiminisher //
	protected override void toggle(bool playAudio)
	{
		antidiminishing = !antidiminishing;

		base.toggle(playAudio);
	}
	// method: toggle both antidiminishers, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both automators, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	
	// methods for: antidiminishing //
	
	
	// method: determine whether the given layer index is for the booster antidiminishor layer //
	public static bool antidiminishorLayer(int layerIndex)
	{
		return (layerIndex == LayerMask.NameToLayer("Booster Antidiminishor"));
	}
	
	// method: determine whether this antidiminisher is currently antidiminishing... and while doing so track the potential distance to an antidiminishor and whether the booster is at distance to an antidiminishor //
	public bool boosterAntidiminishing()
	{
		// via Booster Diminisher, track the potential distance from the booster to the nearest terrain (if any) as the potential distance to an antidiminishor, and also track whether the booster is directed at any distance to the 'Antidiminishor' layer in particular //
		lastPotentialDistanceToAntidiminishor = BoosterDiminisher.distanceToTerrain(booster);

		return (antidiminishing && dependencies.areMet() && atDistanceToAntidiminishor);
	}
	// method: determine whether the given booster's antidiminisher is currently antidiminishing //
	public static bool antidiminishingBooster(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.boosterAntidiminishing();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.boosterAntidiminishing();
			}
		}
		return false;
	}
	
	// method: determine the antidiminishing interpolation curve for the given booster //
	private static InterpolationCurve curve(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left.antidiminishingCurve;
		}
		else
		{
			return right.antidiminishingCurve;
		}
	}
	
	// method: determine the max antidiminishing distance for the given booster //
	public static float boosterAntidiminishingDistanceMax(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left.antidiminishingDistanceMax;
		}
		else
		{
			return right.antidiminishingDistanceMax;
		}
	}

	// method: determine the antidiminisher for the given booster //
	public static BoosterAntidiminisher antidiminisherFor(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left;
		}
		else
		{
			return right;
		}
	}

	// method: calculate the current antidiminishing factors for all coordinate axes for the given booster //
	public static Vector3 antidiminishingFactors(Booster booster)
	{
		// determine the antidiminishing factor for those axes which are to be antidiminished //
		float antidiminishingFactorForAntidiminishedAxes = 1f;		// initialize the antidiminishing factor to the default of 1
		if (antidiminishingBooster(booster))		// if this booster is actually being antidiminished
		{
			// calculate the antidiminishing factor //
			antidiminishingFactorForAntidiminishedAxes = (antidiminishingBooster(booster) ? curve(booster).clamped(1f, 0f, (antidiminisherFor(booster).lastPotentialDistanceToAntidiminishor / boosterAntidiminishingDistanceMax(booster))) : 0f);
		}

		// determine the antidiminisher for the given booster //
		BoosterAntidiminisher antidiminisher = antidiminisherFor(booster);

		// determine the antidiminishing factor for each axis, where each axis is actually antidiminished only if it is set to be //
		float antidiminishingFactorX = antidiminisher.antidiminishesX ? antidiminishingFactorForAntidiminishedAxes : 1f;
		float antidiminishingFactorY = antidiminisher.antidiminishesY ? antidiminishingFactorForAntidiminishedAxes : 1f;
		float antidiminishingFactorZ = antidiminisher.antidiminishesZ ? antidiminishingFactorForAntidiminishedAxes : 1f;

		// return the antidiminishing factors for all coordinate axes //
		return new Vector3(antidiminishingFactorX, antidiminishingFactorY, antidiminishingFactorZ);
	}
	
	
	
	
	// updating //

	
	// at the start: connect to antidiminisher instances //
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
			// toggle this antidiminisher //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other antidiminisher as well //
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

		// if antidiminishing: based on Booster Diminisher raycasting, if antidiminishing is no longer the case, track as much //
		if (boosterAntidiminishing())
		{
			// via Booster Diminisher, track the potential distance from the booster to the nearest terrain (if any) as the potential distance to an antidiminishor, and also track whether the booster is directed at any distance to the 'Antidiminishor' layer in particular //
			lastPotentialDistanceToAntidiminishor = BoosterDiminisher.distanceToTerrain(booster);
		}
	}
}