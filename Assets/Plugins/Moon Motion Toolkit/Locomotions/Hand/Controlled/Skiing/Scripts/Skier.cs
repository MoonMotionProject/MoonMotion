using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Skier
// • classifies this hand locomotion as the "skiing" locomotion
// • behaves the parent hand as a skier (a locomotive tool which when the input for either hand is pressed, ensures the target body collider is using skiing friction, and is otherwise using its original friction)
//   · skiing friction is defined by Skiing Settings on the player body – this can be set to any friction intended for skiing, be it actually "ski-like" or not, for example bouncy; a setting for a main/default friction as well as an alternate friction are both provided, along with a toggle setting and method for changing whether to use the alternate friction or not
//   · nonskiing friction is tracked (at the start) as the friction the player body's collider has from before starting (as set in its collider)
//   · Skiing Settings provides a setting by which the Skiers determine their input style as either held or toggled
//   · a method is provided to update the body friction (used by Skiers when changing whether skiing, and by Skiing Settings for when toggling alternation of the skiing friction while skiing is enabled)
// • skiing audio for the player's body is adjusted by Skiing Audio
// • movement while skiing is handled by the treading locomotion
public class Skier : HandLocomotionControlled
{
	// variables //

	
	// variables for: instancing //
	public static Skier left, right;		// connections - auto: left and right Skier instances
	private Skier other;		// connection - auto: the other skier (for the other hand that this skier doesn't belong to)
	
	// variables for: skiing //
	private static Collider targetBodyCollider;		// connection - auto: the body collider targeted for having skiing friction toggled by this skier
	private static SkiingSettings skiingSettings;		// connection - auto: the Skiing Settings on the player body with the setting for the friction to use for skiing
	private static PhysicMaterial frictionNonskiing;        // tracking: the friction to use for nonskiing
	public static bool skiing = false;		// tracking: whether the player is currently skiing
	
	
	
	
	// methods //

	
	// method: update the player body collider's friction based on whether it is skiing //
	public static void updateBodyFriction()
	{
		if (skiing)
		{
			targetBodyCollider.material = skiingSettings.skiingFrictionToUse();
		}
		else
		{
			targetBodyCollider.material = frictionNonskiing;
		}
	}

	// method: change skiing: set the tracking for whether the player is skiing to the given boolean, update the player body collider's friction accordingly //
	public static void changeSkiing(bool boolean)
	{
		skiing = boolean;
		updateBodyFriction();
	}
	// method: toggle skiing (change skiing for it being the opposite of what it is tracked as currently) //
	public static void toggleSkiing()
	{
		changeSkiing(!skiing);

		SkiingTogglingAudio.play();
	}
	// method: enable skiing (change skiing for it being true) //
	public static void enableSkiing()
	{
		changeSkiing(true);
	}
	// method: enable skiing //
	public void enableSkiing_()
	{
		enableSkiing_();
	}
	// method: disable skiing (change skiing for it being false) //
	public static void disableSkiing()
	{
		changeSkiing(false);
	}
	// method: disable skiing //
	public void disableSkiing_()
	{
		disableSkiing();
	}




	// updating //


	// before the start: //
	protected override void Awake()
	{
		base.Awake();
		
		if (!leftInstance)
		{
			// have just the right hand set the following static variables since they need be set only once //
			targetBodyCollider = Player.instance.GetComponentInChildren<CapsuleCollider>();
			skiingSettings = targetBodyCollider.GetComponent<SkiingSettings>();
			frictionNonskiing = targetBodyCollider.material;
		}
	}
	
	// upon being enabled: //
	private void OnEnable()
	{
		// connect the corresponding instance of this class //
		if (leftInstance)
		{
			left = this;
		}
		else
		{
			right = this;
		}
	}

	// at the start: //
	protected override void Start()
	{
		base.Start();

		// connect to the other skier //
		other = (leftInstance ? right : left);
	}

	// at each update: //
	private void Update()
	{
		// determine whether both skiers are enabled (versus just this one being enabled) //
		bool bothSkiersEnabled = other && other.gameObject && other.gameObject.activeSelf;

		if (skiingSettings)     // if the Skiing Settings even exists
		{
			// if skiing input must be held: //
			if (skiingSettings.heldVersusToggled)
			{
				// (since the following block of code doesn't need to be run twice each update:) if either: this is the only skier that is enabled, this is the left skier: //
				if (!bothSkiersEnabled || leftInstance)
				{
					// if for either skier: input is enabled and input is pressed: //
					if ((locomotionInputEnabledAndAllowed() && controller.inputPressed(inputsLocomotion)) || (bothSkiersEnabled && other.locomotionInputEnabledAndAllowed() && otherController.inputPressed(other.inputsLocomotion)))
					{
						// enable skiing //
						enableSkiing();
					}
					// otherwise: //
					else
					{
						// disable skiing //
						disableSkiing();
					}
				}
			}
			// otherwise (if skiing is toggled upon input): //
			else
			{
				// if input is enabled and input is pressing: //
				if (locomotionInputEnabledAndAllowed() && controller.inputPressing(inputsLocomotion))
				{
					// toggle skiing //
					toggleSkiing();
				}
			}
		}
	}
}