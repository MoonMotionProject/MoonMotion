﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Valve.VR.InteractionSystem;

// Controller
// • provides connections to the left and right instances of Controller
// • enumerates controller handednesses, inputs, inputtednesses
// • tracks the handedness of this controller (whether this controller is for the left hand (versus the right))
// • provides methods for determining input status of this controller, to:
//   · determine status for given inputs andor inputtednesses andor beingnesses (altogether, an "operation" as defined by Controller Operation)
//   · track touchpad touch positions and motion, including methods for determining touchpad touch motions and controlling their tracking
//   · determine whether a given array of inputs has any actual (non-none) inputs set
// • input detection is only accurate while playing (since controller input isn't processed in editor edit mode)
// • provides methods for vibrating this controller
// • provides methods for determining whether given operations are currently operated and those controllers operated
[RequireComponent(typeof(Hand))]
public class Controller : EnabledsBehaviour<Controller>
{
	#region enumerations


	// controller handednesses //
	public enum Handedness
	{
		neither,
		either,
		one,
		left,
		right,
		each,
		both,
		infinite
	}

	// controller inputs //
	public enum Input
	{
		noInput,
		trigger,
		touchpad,
		menuButton,
		grip
	}

	// controller inputtednesses //
	public enum Inputtedness
	{
		touch,
		shallow,
		deep,
		press
	}
	#endregion enumerations







	
	#region variables and properties


	#region button masks
	
	public static ulong triggerButtonMask => SteamVR_Controller.ButtonMask.Trigger;
	public static ulong touchpadButtonMask => SteamVR_Controller.ButtonMask.Touchpad;
	public static ulong menuButtonButtonMask => SteamVR_Controller.ButtonMask.ApplicationMenu;
	public static ulong gripButtonMask => SteamVR_Controller.ButtonMask.Grip;
	#endregion button masks


	#region the other controller
	
	[HideInInspector] public Controller otherController => hand.otherHand.first<Controller>();
	#endregion the other controller


	#region instancing

	// this controller's handedness //
	public bool leftInstance => hand.startingHandType == Hand.HandType.Left;

	// the left controller instance //
	public static Controller left => enableds.firstWhere(enabled => enabled.leftInstance);

	// the right controller instance //
	public static Controller right => enableds.firstWhere(enabled => !enabled.leftInstance);
	#endregion instancing


	#region touchpad input handling tracking

	// the time of last touchdown for the touchpad //
	private float touchpadTouchdownTime = -1f;
	// the coordinates (x and y, respectively) of the last touchdown for the touchpad //
	private float touchpadTouchdownX = 0f, touchpadTouchdownY = 0f;
	// the touchpad's previously touched x and y coordinates //
	private float previousTouchpadX = 0f, previousTouchpadY = 0f;
	// the touchpad's change in touched coordinate (for x and y, respectively) from the last frame //
	private float touchpadXDerivative = 0f, touchpadYDerivative = 0f;
	// the previous derivative for each coordinate (x or y, respectively) – used to determine the derivative derivative (which in turn implies a change in touchpad movement direction) //
	private float previousTouchpadXDerivative = 0f, previousTouchpadYDerivative = 0f;
	// whether the touchpad's change in change in touched coordinate (for x and y, respectively) from the last frame is nonzero (implying a change in touchpad touch movement direction) versus zero //
	private bool touchpadXDerivativeDerivativeNonzero = false, touchpadYDerivativeDerivativeNonzero = false;
	#endregion touchpad input handling tracking
	#endregion variables and properties







	
	#region properties and methods



	
	#region detecting of particular inputs, inputtedness, and beingness


	#region detection - trigger

	public bool triggerTouching => false;
	public bool triggerTouched => false;
	public bool triggerUntouching => false;

	public bool triggerShallowing => triggerPressed && (triggerPressing || triggerUndeeping);
	public bool triggerShallowed => triggerPressed && !triggerDeeped;
	public bool triggerUnshallowing => triggerUnpressing || triggerDeeping;

	public bool triggerDeeping => hand.controller.isYull() && hand.controller.GetPressDown(triggerButtonMask);
	public bool triggerDeeped => hand.controller.isYull() && hand.controller.GetPress(triggerButtonMask);
	public bool triggerUndeeping => hand.controller.isYull() && hand.controller.GetPressUp(triggerButtonMask);

	public bool triggerPressing => hand.controller.isYull() && hand.controller.GetTouchDown(triggerButtonMask);
	public bool triggerPressed => hand.controller.isYull() && hand.controller.GetTouch(triggerButtonMask);
	public bool triggerUnpressing => hand.controller.isYull() && hand.controller.GetTouchUp(triggerButtonMask);
	#endregion detection - trigger


	#region detection - touchpad

	public bool touchpadTouching => hand.controller.isYull() && hand.controller.GetTouchDown(touchpadButtonMask);
	public bool touchpadTouched => hand.controller.isYull() && hand.controller.GetTouch(touchpadButtonMask);
	public bool touchpadUntouching => hand.controller.isYull() && hand.controller.GetTouchUp(touchpadButtonMask);

	public bool touchpadShallowing => touchpadPressing;
	public bool touchpadShallowed => touchpadPressed;
	public bool touchpadUnshallowing => touchpadUnpressing;

	public bool touchpadDeeping => touchpadPressing;
	public bool touchpadDeeped => touchpadPressed;
	public bool touchpadUndeeping => touchpadUnpressing;

	public bool touchpadPressing => hand.controller.isYull() && hand.controller.GetPressDown(touchpadButtonMask);
	public bool touchpadPressed => hand.controller.isYull() && hand.controller.GetPress(touchpadButtonMask);
	public bool touchpadUnpressing => hand.controller.isYull() && hand.controller.GetPressUp(touchpadButtonMask);

	public float touchpadX => hand.controller.isNull() ? 0f : hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x;
	public int touchpadXSign => touchpadX.sign();
	public int touchpadXSignWhereZeroIsPositive => touchpadX.signWhereZeroIsPositive();
	public float touchpadY => hand.controller.isNull() ? 0f : hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y;
	public int touchpadYSign => touchpadY.sign();
	public int touchpadYSignWhereZeroIsPositive => touchpadY.signWhereZeroIsPositive();
	public Vector3 relativeTouchpadYDirectionAsZ => forward * touchpadY;
	public Vector3 relativeTouchpadXDirection => rightward * touchpadX;
	public Vector3 relativeTouchpadDirection => relativeTouchpadYDirectionAsZ + relativeTouchpadXDirection;
	public Vector3 relativeTouchpadDirectionWhereZeroesIsForward => relativeTouchpadDirection.ifOnlyZeroesThen(()=> forward);
	public float touchpadDistance
		=>	hand.controller.isNull() ?
				-1f :
				hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0)
					.distanceWith(FloatsPairs.zeroes);
	public void resetTouchpadTouchdown()
	{
		if (touchpadTouched)
		{
			touchpadTouchdownTime = Time.time;
			touchpadTouchdownX = touchpadX;
			touchpadTouchdownY = touchpadY;
		}
	}
	public void trackTouchpadTouching()
	{
		if (touchpadTouching)
		{
			resetTouchpadTouchdown();
		}
		else if (touchpadTouched)
		{
			previousTouchpadXDerivative = touchpadXDerivative;
			previousTouchpadYDerivative = touchpadYDerivative;

			touchpadXDerivative = touchpadX - previousTouchpadX;
			touchpadYDerivative = touchpadY - previousTouchpadY;

			touchpadXDerivativeDerivativeNonzero = (touchpadXDerivative > 0f) != (previousTouchpadXDerivative > 0f);
			touchpadYDerivativeDerivativeNonzero = (touchpadYDerivative > 0f) != (previousTouchpadYDerivative > 0f);
		}
	}
	private float touchpadXTravel(bool derivativeChangeResets)
	{
		if ((hand.controller == null) || (touchpadTouchdownTime == -1f) || !touchpadTouched)
		{
			return 0f;
		}
		else
		{
			if (derivativeChangeResets && touchpadXDerivativeDerivativeNonzero)
			{
				resetTouchpadTouchdown();
			}
			return (touchpadX - touchpadTouchdownX);
		}
	}
	public float touchpadXTravelDirectional => touchpadXTravel(true);
	public float touchpadXTravelDirectionless => touchpadXTravel(false);
	private float touchpadYTravel(bool derivativeChangeResets)
	{
		if ((hand.controller == null) || (touchpadTouchdownTime == -1f) || !touchpadTouched)
		{
			return 0f;
		}
		else
		{
			if (derivativeChangeResets && touchpadYDerivativeDerivativeNonzero)
			{
				resetTouchpadTouchdown();
			}
			return (touchpadY - touchpadTouchdownY);
		}
	}
	public float touchpadYTravelDirectional => touchpadYTravel(true);
	public float touchpadYTravelDirectionless => touchpadYTravel(false);
	#endregion detection - touchpad


	#region detection - menu button

	public bool menuButtonTouching => false;
	public bool menuButtonTouched => false;
	public bool menuButtonUntouching => false;

	public bool menuButtonShallowing => menuButtonPressing;
	public bool menuButtonShallowed => menuButtonPressed;
	public bool menuButtonUnshallowing => menuButtonUnpressing;

	public bool menuButtonDeeping => menuButtonPressing;
	public bool menuButtonDeeped => menuButtonPressed;
	public bool menuButtonUndeeping => menuButtonUnpressing;

	public bool menuButtonPressing => hand.controller.isYull() && hand.controller.GetPressDown(menuButtonButtonMask);
	public bool menuButtonPressed => hand.controller.isYull() && hand.controller.GetPress(menuButtonButtonMask);
	public bool menuButtonUnpressing => hand.controller.isYull() && hand.controller.GetPressUp(menuButtonButtonMask);
	#endregion detection - menu button


	#region detection - grip

	public bool gripTouching => false;
	public bool gripTouched => false;
	public bool gripUntouching => false;

	public bool gripShallowing => gripPressing;
	public bool gripShallowed => gripPressed;
	public bool gripUnshallowing => gripUnpressing;

	public bool gripDeeping => gripPressing;
	public bool gripDeeped => gripPressed;
	public bool gripUndeeping => gripUnpressing;

	public bool gripPressing => hand.controller.isYull() && hand.controller.GetPressDown(gripButtonMask);
	public bool gripPressed => hand.controller.isYull() && hand.controller.GetPress(gripButtonMask);
	public bool gripUnpressing => hand.controller.isYull() && hand.controller.GetPressUp(gripButtonMask);
	#endregion detection - grip
	#endregion detecting of particular inputs, inputtedness, and beingness




	#region generic handling of inputs with particular inputtedness and beingness


	public bool inputTouching(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerTouching;
		}
		else if (input == Input.touchpad)
		{
			return touchpadTouching;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonTouching;
		}
		else if (input == Input.grip)
		{
			return gripTouching;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputTouching(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputTouching(input))
			{
				return true;
			}
		}

		return false;
	}

	public bool inputTouched(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerTouched;
		}
		else if (input == Input.touchpad)
		{
			return touchpadTouched;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonTouched;
		}
		else if (input == Input.grip)
		{
			return gripTouched;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputTouched(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputTouched(input))
			{
				return true;
			}
		}

		return false;
	}

	public bool inputUntouching(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerUntouching;
		}
		else if (input == Input.touchpad)
		{
			return touchpadUntouching;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonUntouching;
		}
		else if (input == Input.grip)
		{
			return gripUntouching;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputUntouching(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputUntouching(input))
			{
				return true;
			}
		}

		return false;
	}

	public bool inputShallowing(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerShallowing;
		}
		else if (input == Input.touchpad)
		{
			return touchpadShallowing;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonShallowing;
		}
		else if (input == Input.grip)
		{
			return gripShallowing;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputShallowing(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputShallowing(input))
			{
				return true;
			}
		}

		return false;
	}

	public bool inputShallowed(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerShallowed;
		}
		else if (input == Input.touchpad)
		{
			return touchpadShallowed;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonShallowed;
		}
		else if (input == Input.grip)
		{
			return gripShallowed;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputShallowed(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputShallowed(input))
			{
				return true;
			}
		}

		return false;
	}

	public bool inputUnshallowing(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerUnshallowing;
		}
		else if (input == Input.touchpad)
		{
			return touchpadUnshallowing;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonUnshallowing;
		}
		else if (input == Input.grip)
		{
			return gripUnshallowing;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputUnshallowing(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputUnshallowing(input))
			{
				return true;
			}
		}

		return false;
	}

	public bool inputDeeping(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerDeeping;
		}
		else if (input == Input.touchpad)
		{
			return touchpadDeeping;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonDeeping;
		}
		else if (input == Input.grip)
		{
			return gripDeeping;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputDeeping(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputDeeping(input))
			{
				return true;
			}
		}

		return false;
	}

	public bool inputDeeped(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerDeeped;
		}
		else if (input == Input.touchpad)
		{
			return touchpadDeeped;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonDeeped;
		}
		else if (input == Input.grip)
		{
			return gripDeeped;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputDeeped(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputDeeped(input))
			{
				return true;
			}
		}

		return false;
	}

	public bool inputUndeeping(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerUndeeping;
		}
		else if (input == Input.touchpad)
		{
			return touchpadUndeeping;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonUndeeping;
		}
		else if (input == Input.grip)
		{
			return gripUndeeping;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputUndeeping(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputUndeeping(input))
			{
				return true;
			}
		}

		return false;
	}

	public bool inputPressing(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerPressing;
		}
		else if (input == Input.touchpad)
		{
			return touchpadPressing;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonPressing;
		}
		else if (input == Input.grip)
		{
			return gripPressing;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputPressing(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputPressing(input))
			{
				return true;
			}
		}

		return false;
	}

	public bool inputPressed(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerPressed;
		}
		else if (input == Input.touchpad)
		{
			return touchpadPressed;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonPressed;
		}
		else if (input == Input.grip)
		{
			return gripPressed;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputPressed(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputPressed(input))
			{
				return true;
			}
		}

		return false;
	}

	public bool inputUnpressing(Input input)
	{
		if (input == Input.noInput)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerUnpressing;
		}
		else if (input == Input.touchpad)
		{
			return touchpadUnpressing;
		}
		else if (input == Input.menuButton)
		{
			return menuButtonUnpressing;
		}
		else if (input == Input.grip)
		{
			return gripUnpressing;
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputUnpressing(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (inputUnpressing(input))
			{
				return true;
			}
		}

		return false;
	}
	#endregion generic handling of inputs with particular inputtedness and beingness




	#region generic handling of inputs and inputtedness with particular beingness


	public bool inputInputting(Input input, Inputtedness inputtedness)
	{
		if (inputtedness == Inputtedness.touch)
		{
			return inputTouching(input);
		}
		else if (inputtedness == Inputtedness.shallow)
		{
			return inputShallowing(input);
		}
		else if (inputtedness == Inputtedness.deep)
		{
			return inputDeeping(input);
		}
		else if (inputtedness == Inputtedness.press)
		{
			return inputPressing(input);
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputInputting(Input[] inputs, Inputtedness inputtedness)
	{
		foreach (Input input in inputs)
		{
			if (inputInputting(input, inputtedness))
			{
				return true;
			}
		}

		return false;
	}
	public bool inputInputting(Input input, Inputtedness[] inputtednesses)
	{
		foreach (Inputtedness inputtedness in inputtednesses)
		{
			if (inputInputting(input, inputtedness))
			{
				return true;
			}
		}

		return false;
	}
	public bool inputInputting(Input[] inputs, Inputtedness[] inputtednesses)
	{
		foreach (Input input in inputs)
		{
			foreach (Inputtedness inputtedness in inputtednesses)
			{
				if (inputInputting(input, inputtedness))
				{
					return true;
				}
			}
		}

		return false;
	}

	public bool inputInputted(Input input, Inputtedness inputtedness)
	{
		if (inputtedness == Inputtedness.touch)
		{
			return inputTouched(input);
		}
		else if (inputtedness == Inputtedness.shallow)
		{
			return inputShallowed(input);
		}
		else if (inputtedness == Inputtedness.deep)
		{
			return inputDeeped(input);
		}
		else if (inputtedness == Inputtedness.press)
		{
			return inputPressed(input);
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputInputted(Input[] inputs, Inputtedness inputtedness)
	{
		foreach (Input input in inputs)
		{
			if (inputInputted(input, inputtedness))
			{
				return true;
			}
		}

		return false;
	}
	public bool inputInputted(Input input, Inputtedness[] inputtednesses)
	{
		foreach (Inputtedness inputtedness in inputtednesses)
		{
			if (inputInputted(input, inputtedness))
			{
				return true;
			}
		}

		return false;
	}
	public bool inputInputted(Input[] inputs, Inputtedness[] inputtednesses)
	{
		foreach (Input input in inputs)
		{
			foreach (Inputtedness inputtedness in inputtednesses)
			{
				if (inputInputted(input, inputtedness))
				{
					return true;
				}
			}
		}

		return false;
	}

	public bool inputUninputting(Input input, Inputtedness inputtedness)
	{
		if (inputtedness == Inputtedness.touch)
		{
			return inputUntouching(input);
		}
		else if (inputtedness == Inputtedness.shallow)
		{
			return inputUnshallowing(input);
		}
		else if (inputtedness == Inputtedness.deep)
		{
			return inputUndeeping(input);
		}
		else if (inputtedness == Inputtedness.press)
		{
			return inputUnpressing(input);
		}
		else        // (default case)
		{
			return false;
		}
	}
	public bool inputUninputting(Input[] inputs, Inputtedness inputtedness)
	{
		foreach (Input input in inputs)
		{
			if (inputUninputting(input, inputtedness))
			{
				return true;
			}
		}

		return false;
	}
	public bool inputUninputting(Input input, Inputtedness[] inputtednesses)
	{
		foreach (Inputtedness inputtedness in inputtednesses)
		{
			if (inputUninputting(input, inputtedness))
			{
				return true;
			}
		}

		return false;
	}
	public bool inputUninputting(Input[] inputs, Inputtedness[] inputtednesses)
	{
		foreach (Input input in inputs)
		{
			foreach (Inputtedness inputtedness in inputtednesses)
			{
				if (inputUninputting(input, inputtedness))
				{
					return true;
				}
			}
		}

		return false;
	}
	#endregion generic handling of inputs and inputtedness with particular beingness




	#region generic handling of inputs, inputtedness, and beingness


	// method: determine whether this controller is being operated according to the given permuting of inputs and inputtednesses, the given state of being, and the given necessity for that state of being to be total (the case for each permutation in the permuting individually, versus the permuting as a whole) //
	public bool inputInputtednessBeingnessOperation(Input[] inputs, Inputtedness[] inputtednesses, Beingness beingness, bool totalBeingness)
	{
		if (beingness == Beingness.becoming)
		{
			if (totalBeingness)
			{
				return inputInputting(inputs, inputtednesses);
			}
			else
			{
				// when a permuting of a set of inputs and a set of inputtednesses becomes operated, it must be the case that no permutation in that permuting is unbecoming operated, and at least one permutation in that permuting is becoming operated, such that the remaining permutations are (either becoming operated or already) being operated //
				bool atLeastOnePermutationIsBecoming = false;
				foreach (Input input in inputs)
				{
					foreach (Inputtedness inputtedness in inputtednesses)
					{
						if (inputUninputting(input, inputtedness))
						{
							return false;
						}
						if (!inputInputted(input, inputtedness))
						{
							return false;
						}
						if (!atLeastOnePermutationIsBecoming && inputInputting(input, inputtedness))
						{
							atLeastOnePermutationIsBecoming = true;
						}
					}
				}
				return atLeastOnePermutationIsBecoming;
			}
		}
		else if (beingness == Beingness.being)
		{
			if (totalBeingness)
			{
				return inputInputted(inputs, inputtednesses);
			}
			else
			{
				// when a permuting of a set of inputs and a set of inputtednesses is being operated, it must be the case that no permutation in that permuting is unbecoming operated, such that the remaining permutations are (either becoming operated or already) being operated //
				foreach (Input input in inputs)
				{
					foreach (Inputtedness inputtedness in inputtednesses)
					{
						if (inputUninputting(input, inputtedness))
						{
							return false;
						}
						if (!inputInputted(input, inputtedness))
						{
							return false;
						}
					}
				}
				return true;
			}
		}
		else if (beingness == Beingness.unbecoming)
		{
			if (totalBeingness)
			{
				return inputUninputting(inputs, inputtednesses);
			}
			else
			{
				// when a permuting of a set of inputs and a set of inputtednesses unbecomes operated, it must be the case that no permutation in that permuting is becoming operated, and at least one permutation in that permuting is unbecoming operated, such that the remaining permutations are either being operated or unbecoming operated //
				bool atLeastOnePermutationIsUnbecoming = false;
				foreach (Input input in inputs)
				{
					foreach (Inputtedness inputtedness in inputtednesses)
					{
						if (inputInputting(input, inputtedness))
						{
							return false;
						}
						bool inputUninputting_ = inputUninputting(input, inputtedness);
						if (!inputInputted(input, inputtedness) && !inputUninputting_)
						{
							return false;
						}
						else if (!atLeastOnePermutationIsUnbecoming && inputUninputting_)
						{
							atLeastOnePermutationIsUnbecoming = true;
						}
					}
				}
				return atLeastOnePermutationIsUnbecoming;
			}
		}
		else        // (default case)
		{
			return false;
		}
	}
	// method: determine whether this controller is being operated according to the given permuting of inputs and inputtednesses, the given states of being, and the given necessity for each state of being (to be operated in) in totality (where that state of being is the case for each permutation in the permuting individually, versus the permuting as a whole) //
	public bool inputInputtednessBeingnessOperation(Input[] inputs, Inputtedness[] inputtednesses, Beingness[] beingnesses, bool totalBeingness)
	{
		foreach (Beingness beingness in beingnesses)
		{
			if (inputInputtednessBeingnessOperation(inputs, inputtednesses, beingness, totalBeingness))
			{
				return true;
			}
		}

		return false;
	}
	
	// method: determine whether the given array of inputs has any actual (non-none) inputs //
	public static bool anyActualInputs(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (input != Input.noInput)
			{
				return true;
			}
		}
		return false;
	}
	#endregion generic handling of inputs, inputtedness, and beingness




	#region control for delayed prevention of any vibration at the start; method: vibrate during this frame with the given intensity value; control and methods for extended (multiple frame) vibrating toggling


	private float vibrationPreventionDelay = .01f, vibrationPreventionTimer = 0;
	private bool vibrationAllowed = false;

    public void vibrate(ushort intensity)
    {
		if (hand.controller == null)
		{
			return;
		}
		if (vibrationAllowed)
		{
			hand.controller.TriggerHapticPulse(intensity);
		}
    }

	private bool vibratingToggled = false;
	private float toggledVibrationDuration = .1f;
	private ushort toggledVibrationIntensity = 3000;
	private void toggleVibrationOff()
	{
		vibratingToggled = false;
	}
	public void vibrateExtended()
	{
		vibratingToggled = true;
		Invoke("toggleVibrationOff", toggledVibrationDuration);
	}
	public void vibrateExtended(float duration)
	{
		toggledVibrationDuration = duration;
		vibrateExtended();
	}
	public void vibrateExtended(ushort intensity)
	{
		toggledVibrationIntensity = intensity;
		vibrateExtended();
	}
	public void vibrateExtended(float duration, ushort intensity)
	{
		toggledVibrationDuration = duration;
		toggledVibrationIntensity = intensity;
		vibrateExtended();
	}
	#endregion control for delayed prevention of any vibration at the start; method: vibrate during this frame with the given intensity value; control and methods for extended (multiple frame) vibrating toggling




	#region handling controller operations


	// method: determine whether the given operation is currently operated by the left-handed controller at any of the given states of being, ignoring the operation's handedness, states of being, and dependencies //
	private static bool operatedLeft(ControllerOperation operation, Beingness[] beingnesses)
	{
		return left.inputInputtednessBeingnessOperation(operation.inputs, operation.inputtednesses, beingnesses, false);
	}
	// method: determine whether the given operation is currently operated by the left-handed controller at the given state of being, ignoring the operation's handedness, states of being, and dependencies //
	private static bool operatedLeft(ControllerOperation operation, Beingness beingness)
	{
		return operatedLeft(operation, new Beingness[] {beingness});
	}
	// method: determine whether the given operation is currently operated by the left-handed controller, ignoring the operation's handedness and dependencies //
	private static bool operatedLeft(ControllerOperation operation)
	{
		return operatedLeft(operation, operation.beingnesses);
	}
	// method: determine whether the given operation is currently operated by the right-handed controller at any of the given states of being, ignoring the operation's handedness, states of being, and dependencies //
	private static bool operatedRight(ControllerOperation operation, Beingness[] beingnesses)
	{
		return right.inputInputtednessBeingnessOperation(operation.inputs, operation.inputtednesses, beingnesses, false);
	}
	// method: determine whether the given operation is currently operated by the right-handed controller at the given state of being, ignoring the operation's handedness, states of being, and dependencies //
	private static bool operatedRight(ControllerOperation operation, Beingness beingness)
	{
		return operatedRight(operation, new Beingness[] {beingness});
	}
	// method: determine whether the given operation is currently operated by the right-handed controller, ignoring the operation's handedness and dependencies //
	private static bool operatedRight(ControllerOperation operation)
	{
		return operatedRight(operation, operation.beingnesses);
	}
	// method: determine whether the given operation is currently operated at any of the given states of being, ignoring its states of being and dependencies //
	private static bool operatedIgnoringDependencies(ControllerOperation operation, Beingness[] beingnesses)
	{
		if (operation.handedness == Handedness.neither)
		{
			return false;
		}
		else if (operation.handedness == Handedness.either)
		{
			return operatedLeft(operation, beingnesses) || operatedRight(operation, beingnesses);
		}
		else if (operation.handedness == Handedness.one)
		{
			return operatedLeft(operation, beingnesses) ^ operatedRight(operation, beingnesses);
		}
		else if (operation.handedness == Handedness.left)
		{
			return operatedLeft(operation, beingnesses);
		}
		else if (operation.handedness == Handedness.right)
		{
			return operatedRight(operation, beingnesses);
		}
		else if (operation.handedness == Handedness.each)
		{
			return operatedLeft(operation, beingnesses) && operatedRight(operation, beingnesses);
		}
		else if (operation.handedness == Handedness.both)
		{
			foreach (Beingness beingness in beingnesses)
			{
				if (beingness == Beingness.becoming)
				{
					// when both controllers become operated, it must be the case that neither controller is unbecoming operated, and at least one controller is becoming operated, such that the other controller is (either becoming operated or already) being operated //
					if (operatedLeft(operation, Beingness.unbecoming) || operatedRight(operation, Beingness.unbecoming))
					{
						continue;
					}
					if (!(operatedLeft(operation, Beingness.becoming) || operatedRight(operation, Beingness.becoming)))
					{
						continue;
					}
					if (operatedLeft(operation, Beingness.being) && operatedRight(operation, Beingness.being))
					{
						return true;
					}
					else
					{
						continue;
					}
				}
				else if (beingness == Beingness.being)
				{
					// when both controllers are being operated, it must be the case that neither controller is unbecoming operated, such that both controllers are (either becoming operated or already) being operated //
					if (operatedLeft(operation, Beingness.unbecoming) || operatedRight(operation, Beingness.unbecoming))
					{
						continue;
					}
					if (operatedLeft(operation, Beingness.being) && operatedRight(operation, Beingness.being))
					{
						return true;
					}
					else
					{
						continue;
					}
				}
				else if (beingness == Beingness.unbecoming)
				{
					// when both controllers unbecome operated, it must be the case that neither controller is becoming operated, and at least one controller is unbecoming operated, such that the other controller is either being operated or unbecoming operated //
					if (operatedLeft(operation, Beingness.becoming) || operatedRight(operation, Beingness.becoming))
					{
						continue;
					}
					if ((operatedLeft(operation, Beingness.unbecoming) && operatedRight(operation, Beingness.unbecoming)) || (operatedLeft(operation, Beingness.unbecoming) && operatedRight(operation, Beingness.being)) || (operatedLeft(operation, Beingness.being) && operatedRight(operation, Beingness.unbecoming)))
					{
						return true;
					}
					else
					{
						continue;
					}
				}
				else        // (default case)
				{
					continue;
				}
			}
			return false;
		}
		else if (operation.handedness == Handedness.infinite)
		{
			return true;
		}
		else        // (default case)
		{
			return false;
		}
	}
	// method: determine whether the given operation is currently operated at the given state of being, ignoring its states of being and dependencies //
	private static bool operatedIgnoringDependencies(ControllerOperation operation, Beingness beingness)
	{
		return operatedIgnoringDependencies(operation, new Beingness[] {beingness});
	}
	// method: determine whether the given operation is currently operated, ignoring its dependencies //
	private static bool operatedIgnoringDependencies(ControllerOperation operation)
	{
		return operatedIgnoringDependencies(operation, operation.beingnesses);
	}
	// method: determine whether the given operation is currently operated //
	public static bool operated(ControllerOperation operation)
	{
		if (!operation.dependenciesMet())
		{
			return false;
		}
		return operatedIgnoringDependencies(operation);
	}
	// method: determine whether the given operation is currently operated at the given state of being (first requires the operation to accept either the given state of being, or no state of beings) //
	public static bool operated(ControllerOperation operation, Beingness beingness)
	{
		if (!(operation.beingnesses.Contains(beingness) || operation.beingnesses.isEmpty()))
		{
			return false;
		}
		if (!operation.dependenciesMet())
		{
			return false;
		}
		return operatedIgnoringDependencies(operation, beingness);
	}
	// method: determine whether any of the given operations are currently operated //
	public static bool operated(ControllerOperation[] operations)
	{
		foreach (ControllerOperation operation in operations)
		{
			if (operated(operation))
			{
				return true;
			}
		}
		return false;
	}
	// method: determine whether any of the given operations are currently operated at the given state of being (first requiring such an operation to accept either the given state of being, or no state of beings) //
	public static bool operated(ControllerOperation[] operations, Beingness beingness)
	{
		foreach (ControllerOperation operation in operations)
		{
			if (operated(operation, beingness))
			{
				return true;
			}
		}
		return false;
	}
	// method: determine the set of controllers for which the given operation is currently operated at any of the given states of being, ignoring its states of being and dependencies //
	private static HashSet<Controller> operatedControllersIgnoringDependencies(ControllerOperation operation, Beingness[] beingnesses)
	{
		if (operation.handedness == Handedness.neither)
		{
			return New.setOf<Controller>();
		}
		else if (operation.handedness == Handedness.one)
		{
			if (operatedLeft(operation, beingnesses) && !operatedRight(operation, beingnesses))
			{
				return left.startSet();
			}
			else if (!operatedLeft(operation, beingnesses) && operatedRight(operation, beingnesses))
			{
				return right.startSet();
			}
			return New.setOf<Controller>();
		}
		else if (operation.handedness == Handedness.left)
		{
			if (operatedLeft(operation, beingnesses))
			{
				return left.startSet();
			}
			return new HashSet<Controller>();
		}
		else if (operation.handedness == Handedness.right)
		{
			if (operatedRight(operation, beingnesses))
			{
				return right.startSet();
			}
			return New.setOf<Controller>();
		}
		else if (operation.handedness == Handedness.each)
		{
			if (operatedLeft(operation, beingnesses) && operatedRight(operation, beingnesses))
			{
				return New.setOf(left, right);
			}
			return New.setOf<Controller>();
		}
		else if (operation.handedness == Handedness.both)
		{
			foreach (Beingness beingness in beingnesses)
			{
				if (beingness == Beingness.becoming)
				{
					// when both controllers become operated, it must be the case that neither controller is unbecoming operated, and at least one controller is becoming operated, such that the other controller is (either becoming operated or already) being operated //
					if (operatedLeft(operation, Beingness.unbecoming) || operatedRight(operation, Beingness.unbecoming))
					{
						continue;
					}
					if (!(operatedLeft(operation, Beingness.becoming) || operatedRight(operation, Beingness.becoming)))
					{
						continue;
					}
					if (operatedLeft(operation, Beingness.being) && operatedRight(operation, Beingness.being))
					{
						return New.setOf(left, right);
					}
					else
					{
						continue;
					}
				}
				else if (beingness == Beingness.being)
				{
					// when both controllers are being operated, it must be the case that neither controller is unbecoming operated, such that both controllers are (either becoming operated or already) being operated //
					if (operatedLeft(operation, Beingness.unbecoming) || operatedRight(operation, Beingness.unbecoming))
					{
						continue;
					}
					if (operatedLeft(operation, Beingness.being) && operatedRight(operation, Beingness.being))
					{
						return New.setOf(left, right);
					}
					else
					{
						continue;
					}
				}
				else if (beingness == Beingness.unbecoming)
				{
					// when both controllers unbecome operated, it must be the case that neither controller is becoming operated, and at least one controller is unbecoming operated, such that the other controller is either being operated or unbecoming operated //
					if (operatedLeft(operation, Beingness.becoming) || operatedRight(operation, Beingness.becoming))
					{
						continue;
					}
					if ((operatedLeft(operation, Beingness.unbecoming) && operatedRight(operation, Beingness.unbecoming)) || (operatedLeft(operation, Beingness.unbecoming) && operatedRight(operation, Beingness.being)) || (operatedLeft(operation, Beingness.being) && operatedRight(operation, Beingness.unbecoming)))
					{
						return New.setOf(left, right);
					}
					else
					{
						continue;
					}
				}
				else        // (default case)
				{
					continue;
				}
			}
			return New.setOf<Controller>();
		}
		else if ((operation.handedness == Handedness.either) || (operation.handedness == Handedness.infinite))
		{
			HashSet<Controller> setOfOperatedControllers = New.setOf<Controller>();
			if (operatedLeft(operation, beingnesses))
			{
				setOfOperatedControllers.Add(left);
			}
			if (operatedRight(operation, beingnesses))
			{
				setOfOperatedControllers.Add(right);
			}
			return setOfOperatedControllers;
		}
		else        // (default case)
		{
			return New.setOf<Controller>();
		}
	}
	// method: determine the set of controllers for which the given operation is currently operated at the given state of being, ignoring its states of being and dependencies //
	private static HashSet<Controller> operatedControllersIgnoringDependencies(ControllerOperation operation, Beingness beingness)
	{
		return operatedControllersIgnoringDependencies(operation, new Beingness[] {beingness});
	}
	// method: determine the set of controllers for which the given operation is currently operated, ignoring its dependencies //
	private static HashSet<Controller> operatedControllersIgnoringDependencies(ControllerOperation operation)
	{
		return operatedControllersIgnoringDependencies(operation, operation.beingnesses);
	}
	// method: determine the set of controllers for which the given operation is currently operated //
	public static HashSet<Controller> operatedControllers(ControllerOperation operation)
	{
		if (!operation.dependenciesMet())
		{
			return New.setOf<Controller>();
		}
		return operatedControllersIgnoringDependencies(operation);
	}
	// method: determine the set of controllers for which the given operation is currently operated at the given state of being (first requires the operation to accept either the given state of being, or no state of beings) //
	public static HashSet<Controller> operatedControllers(ControllerOperation operation, Beingness beingness)
	{
		if (!(operation.beingnesses.Contains(beingness) || operation.beingnesses.isEmpty()))
		{
			return New.setOf<Controller>();
		}
		if (!operation.dependenciesMet())
		{
			return New.setOf<Controller>();
		}
		return operatedControllersIgnoringDependencies(operation, beingness);
	}
	// method: determine the set of controllers for which any of the given operations are currently operated //
	public static HashSet<Controller> operatedControllers(ControllerOperation[] operations)
	{
		HashSet<Controller> setOfOperatedControllers = New.setOf<Controller>();
		foreach (ControllerOperation operation in operations)
		{
			HashSet<Controller> setOfOperatedControllersForOperation = operatedControllers(operation);
			foreach (Controller operatedController in setOfOperatedControllersForOperation)
			{
				setOfOperatedControllers.Add(operatedController);
			}
		}
		return setOfOperatedControllers;
	}
	// method: determine the set of controllers for which any of the given operations are currently operated at the given state of being (first requiring such an operation to accept either the given state of being, or no state of beings) //
	public static HashSet<Controller> operatedControllers(ControllerOperation[] operations, Beingness beingness)
	{
		HashSet<Controller> setOfOperatedControllers = New.setOf<Controller>();
		foreach (ControllerOperation operation in operations)
		{
			HashSet<Controller> setOfOperatedControllersForOperation = operatedControllers(operation, beingness);
			foreach (Controller operatedController in setOfOperatedControllersForOperation)
			{
				setOfOperatedControllers.Add(operatedController);
			}
		}
		return setOfOperatedControllers;
	}
	#endregion handling controller operations
	#endregion properties and methods







	
	#region updating


	// at each update: //
	public override void update()
	{
		// touchpad touching tracking //
		trackTouchpadTouching();

		// delayed prevention of any vibrating at the start //
		if (!vibrationAllowed)
		{
			if (vibrationPreventionTimer < vibrationPreventionDelay)
			{
				vibrationPreventionTimer += Time.deltaTime;
				if (vibrationPreventionTimer > vibrationPreventionDelay)
					vibrationPreventionTimer = vibrationPreventionDelay;
				if (vibrationPreventionTimer == vibrationPreventionDelay)
					vibrationAllowed = true;
			}
		}

		// extended (multiple frame) vibrating //
		if (vibratingToggled)
		{
			vibrate(toggledVibrationIntensity);
		}
	}
	#endregion updating
}