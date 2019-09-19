using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Turner
// • classifies this hand locomotion as the "turning" locomotion
// • behaves the parent hand as a turner:
//   · allows the player to rotate around their y axis in either direction using touchpad input, or by having the direction based on a set direction for this hand (all three of these possibilities are enumerated into one setting); the touchpad input works as follows:
//     - pressing the left half of the touchpad rotates the player to the left
//     - pressing the right half of the touchpad rotates the player to the right
//   · a setting determines the amount of degrees by which to rotate the player upon pressing
//   · rotates around the set object of rotation (in most cases, the player's headset/camera)
// • provides methods for changing the turning degrees setting
// • the turning direction is reversed according to whether the flipping locomotion has the player flipped currently
public class Turner : HandLocomotionControlled
{
	// enumerations //
	
	
	// enumeration of: ways by which to determine the turning direction //
	public enum TurningDirection
	{
		touchpad,
		left,
		right
	}
	



	// variables //

	
	// variables for: instancing //
	public static Turner left, right;		// connections - auto: left and right Turner instances, respectively
	
	// variables for: turning //
	private Transform playerTransform;		// connection - auto: the player transform (to turn)
	[Header("Transform to Rotate Around")]
	[Tooltip("the transform of the object to rotate the player around (in most cases, the player's headset/camera)")]
	public Transform objectOfRotationTransform;		// connection - manual: the transform of the object to rotate the player around (in most cases, the player's headset/camera)
	[Header("Turning")]
	public float degreesAmount = 30f;		// setting: the amount of degrees by which to rotate the player (to turn)
	public TurningDirection turningDirection = TurningDirection.touchpad;		// setting: the way by which to determine the turning direction

	
	
	
	// methods //
	
	
	// methods for: determining turning direction //
	
	// method: determine the sign factor for the given turning direction //
	public float signFactorForTurningDirection(TurningDirection turningDirection)
	{
		if (turningDirection == TurningDirection.touchpad)
		{
			return ((controller.touchpadX() >= 0f) ? 1f : -1f);
		}
		else if (turningDirection == TurningDirection.left)
		{
			return -1f;
		}
		else		// (if the turning direction is right)
		{
			return 1f;
		}
	}
	// method: determine the sign factor for whether the player is flipped currently //
	public float signFactorForFlippage()
	{
		if (Flipper.flipped)
		{
			return -1f;
		}
		else
		{
			return 1f;
		}
	}
	
	
	// methods for: changing the turning degrees amount //
	
	// method: change the turning degrees to the given amount //
	public void changeDegreesAmount(float amount)
		=> degreesAmount = amount;
	// method: change the turning degrees to the given amount globally (for both hands) //
	public void changeDegreesAmountGlobally_(float amount)
	{
		left.changeDegreesAmount(amount);
		right.changeDegreesAmount(amount);
	}
	// method: change the turning degrees to the given amount globally (for both hands) //
	public static void changeDegreesAmountGlobally(float amount)
		=> left.changeDegreesAmountGlobally_(amount);




	// updating //


	// before the start: //
	protected override void Awake()
	{
		base.Awake();
		
		playerTransform = transform.parent.parent.parent;
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
		if (locomotionInputEnabledAndAllowed() && controller.inputPressing(inputsLocomotion))
		{
			float signFactoring = signFactorForTurningDirection(turningDirection) * signFactorForFlippage();
			float degrees = (signFactoring * degreesAmount);
			playerTransform.RotateAround(objectOfRotationTransform.position, Vector3.up, degrees);
		}
	}
}