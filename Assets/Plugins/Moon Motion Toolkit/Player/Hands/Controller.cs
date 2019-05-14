using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

// Controller
// • provides connections to the left and right instances of Controller
// • tracks the handedness of this controller (whether this controller is for the left hand (versus the right))
// • enumerates controller inputs
// • provides methods for determining input status of this controller, to:
//   · determine status for each particular input
//   · determine status for a given array of inputs
//   · determine whether a given array of inputs has any actual (non-none) inputs set
//   · track touchpad touch positions and motion, including methods for determining touchpad touch motions and controlling their tracking
// • provides methods for vibrating this controller
// ∗: example usage of touchpad travelling input to flip pages of a book
[RequireComponent(typeof(Hand))]
public class Controller : MonoBehaviour
{
	// enumerations //

	
	// enumeration of: controller inputs //
	public enum Input
	{
		none,
		trigger,
		touchpad,
		menuButton,
		grip
	}
	
	
	
	
	
	
	
	
	
	
	
	



	
	// variables //
	
	
	// variables for: connection with this hand and the other controller //
	[HideInInspector] public Hand hand;		// connection - automatic: this controller's hand
    [HideInInspector] public Controller otherController;		// connection - automatic: the other controller
	
	// variables for: instancing //
	public static Controller left, right;		// connections - automatic: the left and right controller instances, respectively
	[HideInInspector] public bool leftInstance = true;		// tracking: this controller's handedness

	// variables for: touchpad input handling //
	private float touchpadTouchdownTime = -1f;		// tracking: the time of last touchdown for the touchpad
	private float touchpadTouchdownX = 0f, touchpadTouchdownY = 0f;		// tracking: the coordinates (x and y, respectively) of the last touchdown for the touchpad
	private float previousTouchpadX = 0f, previousTouchpadY = 0f;       // tracking: the touchpad's previously touched x and y coordinates
	private float touchpadXDerivative = 0f, touchpadYDerivative = 0f;		// tracking: the touchpad's change in touched coordinate (for x and y, respectively) from the last frame
	private float previousTouchpadXDerivative = 0f, previousTouchpadYDerivative = 0f;		// tracking: the previous derivative for each coordinate (x or y, respectively) – used to determine the derivative derivative (which in turn implies a change in touchpad movement direction)
	private bool touchpadXDerivativeDerivativeNonzero = false, touchpadYDerivativeDerivativeNonzero = false;		// tracking: whether the touchpad's change in change in touched coordinate (for x and y, respectively) from the last frame is nonzero (implying a change in touchpad touch movement direction) versus zero
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	// methods //

	
	
	
	
	
	
	
	// generic handling of inputs //
	
	
	public bool inputShallowing(Input input)
	{
		if (input == Input.none)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerShallowing();
		}
		else if (input == Input.touchpad)
		{
			return touchpadPressing();
		}
		else if (input == Input.menuButton)
		{
			return menuButtonPressing();
		}
		else		// (for grip input)
		{
			return gripPressing();
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
		if (input == Input.none)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerShallowed();
		}
		else if (input == Input.touchpad)
		{
			return touchpadPressed();
		}
		else if (input == Input.menuButton)
		{
			return menuButtonPressed();
		}
		else		// (for grip input)
		{
			return gripPressed();
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
		if (input == Input.none)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerUnshallowing();
		}
		else if (input == Input.touchpad)
		{
			return touchpadUnpressing();
		}
		else if (input == Input.menuButton)
		{
			return menuButtonUnpressing();
		}
		else		// (for grip input)
		{
			return gripUnpressing();
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
		if (input == Input.none)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerDeeping();
		}
		else if (input == Input.touchpad)
		{
			return touchpadPressing();
		}
		else if (input == Input.menuButton)
		{
			return menuButtonPressing();
		}
		else		// (for grip input)
		{
			return gripPressing();
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
		if (input == Input.none)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerDeeped();
		}
		else if (input == Input.touchpad)
		{
			return touchpadPressed();
		}
		else if (input == Input.menuButton)
		{
			return menuButtonPressed();
		}
		else		// (for grip input)
		{
			return gripPressed();
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
		if (input == Input.none)
		{
			return false;
		}
		else if (input == Input.trigger)
		{
			return triggerUndeeping();
		}
		else if (input == Input.touchpad)
		{
			return touchpadUnpressing();
		}
		else if (input == Input.menuButton)
		{
			return menuButtonUnpressing();
		}
		else		// (for grip input)
		{
			return gripUnpressing();
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

	public bool inputTouching(Input input)
	{
		if (input == Input.touchpad)
		{
			return touchpadTouching();
		}
		else		// (for any other input)
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
		if (input == Input.touchpad)
		{
			return touchpadTouched();
		}
		else		// (for any other input)
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
		if (input == Input.touchpad)
		{
			return touchpadUntouching();
		}
		else		// (for any other input)
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
	
	
	
	
	// methods handling particular inputs; vibration control //
	
	
    // detection - trigger //
	
    public bool triggerShallowing()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger);
    }
    public bool triggerShallowed()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetTouch(SteamVR_Controller.ButtonMask.Trigger);
    }
    public bool triggerUnshallowing()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger);
    }

    public bool triggerDeeping()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger);
    }
    public bool triggerDeeped()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetPress(SteamVR_Controller.ButtonMask.Trigger);
    }
    public bool triggerUndeeping()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger);
    }


    // detection - touchpad //
	
    public bool touchpadTouching()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad);
    }
    public bool touchpadTouched()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetTouch(SteamVR_Controller.ButtonMask.Touchpad);
    }
    public bool touchpadUntouching()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad);
    }

    public bool touchpadPressing()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad);
    }
    public bool touchpadPressed()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad);
    }
    public bool touchpadUnpressing()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad);
	}

	public float touchpadX()
	{
		if (hand.controller == null)
		{
			return 0f;
		}
		Vector2 coordinates = hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
		return coordinates.x;
	}
	public float touchpadY()
	{
		if (hand.controller == null)
		{
			return 0f;
		}
		Vector2 coordinates = hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
		return coordinates.y;
	}
	public float touchpadDistance()
	{
		if (hand.controller == null)
		{
			return -1f;
		}
		Vector2 coordinates = hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
		return Vector2.Distance(coordinates, (new Vector2(0f, 0f)));
	}
	public void resetTouchpadTouchdown()
	{
		if (touchpadTouched())
		{
			touchpadTouchdownTime = Time.time;
			touchpadTouchdownX = touchpadX();
			touchpadTouchdownY = touchpadY();
		}
	}
	public void trackTouchpadTouching()
	{
		if (touchpadTouching())
		{
			resetTouchpadTouchdown();
		}
		else if (touchpadTouched())
		{
			previousTouchpadXDerivative = touchpadXDerivative;
			previousTouchpadYDerivative = touchpadYDerivative;

			touchpadXDerivative = (touchpadX() - previousTouchpadX);
			touchpadYDerivative = (touchpadY() - previousTouchpadY);

			touchpadXDerivativeDerivativeNonzero = ((touchpadXDerivative > 0f) != (previousTouchpadXDerivative > 0f));
			touchpadYDerivativeDerivativeNonzero = ((touchpadYDerivative > 0f) != (previousTouchpadYDerivative > 0f));
		}
	}
	private float touchpadXTravel(bool derivativeChangeResets)
	{
		if ((hand.controller == null) || (touchpadTouchdownTime == -1f) || !touchpadTouched())
		{
			return 0f;
		}
		else
		{
			if (derivativeChangeResets && touchpadXDerivativeDerivativeNonzero)
			{
				resetTouchpadTouchdown();
			}
			return (touchpadX() - touchpadTouchdownX);
		}
	}
	public float touchpadXTravelDirectional()
	{
		return touchpadXTravel(true);
	}
	public float touchpadXTravelDirectionless()
	{
		return touchpadXTravel(false);
	}
	private float touchpadYTravel(bool derivativeChangeResets)
	{
		if ((hand.controller == null) || (touchpadTouchdownTime == -1f) || !touchpadTouched())
		{
			return 0f;
		}
		else
		{
			if (derivativeChangeResets && touchpadYDerivativeDerivativeNonzero)
			{
				resetTouchpadTouchdown();
			}
			return (touchpadY() - touchpadTouchdownY);
		}
	}
	public float touchpadYTravelDirectional()
	{
		return touchpadYTravel(true);
	}
	public float touchpadYTravelDirectionless()
	{
		return touchpadYTravel(false);
	}


	// detection - menu button //
	
	public bool menuButtonPressing()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu);
    }
    public bool menuButtonPressed()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu);
    }
    public bool menuButtonUnpressing()
    {
		if (hand.controller == null)
		{
			return false;
		}
        return hand.controller.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu);
	}


	// detection - grip //
	
	public bool gripPressing()
	{
		if (hand.controller == null)
		{
			return false;
		}
		return hand.controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip);
	}
	public bool gripPressed()
	{
		if (hand.controller == null)
		{
			return false;
		}
		return hand.controller.GetPress(SteamVR_Controller.ButtonMask.Grip);
	}
	public bool gripUnpressing()
	{
		if (hand.controller == null)
		{
			return false;
		}
		return hand.controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip);
	}
	
	
	
	
	// method: determine whether the given array of inputs has any actual (non-none) inputs //
	public static bool anyActualInputs(Input[] inputs)
	{
		foreach (Input input in inputs)
		{
			if (input != Input.none)
			{
				return true;
			}
		}
		return false;
	}
	
	
	
	
	// control for delayed prevention of any vibration at the start; method: vibrate during this frame with the given intensity value; control and methods for extended (multiple frame) vibrating toggling //

	
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
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	// updating //
	

	// before the start: //
    private void Awake()
    {
		// connect to: this controller's hand, the other controller //
		hand = GetComponent<Hand>();
		otherController = hand.otherHand.GetComponent<Controller>();
		
		// track whether this controller is for the left hand //
		leftInstance = (hand.startingHandType == Hand.HandType.Left);
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

	// at each update: //
	private void Update()
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
}

// ∗: example usage of touchpad travelling input to flip pages of a book
/*
private void Update()
{
	// interaction: page flipping //
	float touchpadXTravelDistance = controller.touchpadXTravelDirectional();
	if (Mathf.Abs(touchpadXTravelDistance) > pageFlippingTravelDistanceThreshold)
	{
		controller.resetTouchpadTouchdown();
		if ((touchpadXTravelDistance > 0f))
		{
			controller.vibrate(1000);
			PageFlipper.flipToNextPage();
		}
		else if ((touchpadXTravelDistance < 0f))
		{
			controller.vibrate(1000);
			PageFlipper.flipToPreviousPage();
		}
	}
}
*/