using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Vibrator
// • provides vibration to the parent booster
// • upon input, toggles vibration
//   - this can optionally be toggled globally (affecting both vibrators upon the input of this controller)
//   - this can optionally play the attached toggling audio
public class BoosterVibrator : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	private static BoosterVibrator left, right;		// trackings: vibrator instances

	// variables for: vibrating //
	[Header("Vibrating")]
	public bool vibrating = true;		// tracking: whether vibrating is enabled currently
	public ushort vibrationShallow = 450;		// setting: the intensity of the vibration for shallow force boosting
	public ushort vibrationDeep = 1250;		// setting: the intensity of the vibration for deep force boosting




	// methods //
	
	
	// method: toggle this vibrator //
	protected override void toggle(bool playAudio)
	{
		vibrating = !vibrating;

		base.toggle(playAudio);
	}
	// method: toggle both vibrators, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both vibrators, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	
	// method: determine whether this booster's vibrating is currently enabled //
	public bool vibratingEnabled()
	{
		return (vibrating && dependencies.areMet());
	}
	// method: determine whether the given booster's boosting is currently enabled //
	public static bool vibratingEnabled(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left.vibratingEnabled();
		}
		else
		{
			return right.vibratingEnabled();
		}
	}
	
	// method: determine this booster's current shallow vibration intensity (none if vibrating is currently disabled) //
	public ushort intensityShallow()
	{
		return (vibratingEnabled() ? vibrationShallow : ((ushort) 0));
	}
	// method: determine this booster's current deep vibration intensity (none if vibrating is currently disabled) //
	public ushort intensityDeep()
	{
		return (vibratingEnabled() ? vibrationDeep : ((ushort) 0));
	}

	// method: determine the given booster's current shallow vibration intensity //
	public static ushort intensityShallow(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.intensityShallow();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.intensityShallow();
			}
		}
		return ((ushort) 450);
	}
	// method: determine the given booster's current deep vibration intensity //
	public static ushort intensityDeep(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.intensityDeep();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.intensityDeep();
			}
		}
		return ((ushort) 1250);
	}
	
	
	
	
	// updating //

	
	// at the start: connect to vibrator instances //
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
			// toggle this vibrator //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other vibrator as well //
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