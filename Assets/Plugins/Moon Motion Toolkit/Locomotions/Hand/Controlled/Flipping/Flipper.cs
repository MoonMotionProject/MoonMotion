using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

// Flipper
// • classifies this hand locomotion as the "flipping" locomotion
// • upon certain controller input pressing by the parent hand, "flips" the player:
//   · rotates the player by 180° on the z axis, then sets the player body's x and z positions to what they were before rotation
//   · inverts the sign of the y axis force of all gravity zones in the scene
//     - a setting is provided to make this optional
// • provides tracking for:
//   · whether the player is currently flipped
//   · the last time that a flip (by any flipper / either hand) occurred
// • provides methods for:
//   · flipping the player
//   · toggling whether flipping flips gravity zone forces
// • based on whether the player is currently flipped:
//   · Body Transformation inverts the y positioning of the player's body
//   · Jumper uses the inversion of the y force to apply when jumping
//   · Terrain Response naturally raycasts with a raise in the player's up direction
public class Flipper : HandLocomotionControlled
{
	// variables //

	
	// variables for: instancing //
	public static Flipper left, right;		// connections - auto: the left and right instances of this class

	// variables for: flipping //
	public static bool flipped = false;		// tracking: whether the player is currently flipped
	[Header("Flipping")]
	[Tooltip("whether to, upon flipping the player, flip the y axis of the gravitizing force of each gravity zone in the scene")]
	public bool flipGravityZoneForces = true;		// setting: whether to, upon flipping the player, flip the y axis of the gravitizing force of each gravity zone in the scene
	private BodyTransformation bodyTransformation;		// connection - auto: the body transformation of this flipper's player's body
	private Transform bodyTransform;		// connection - auto: the transform of this flipper's player's body
	private Transform playerTransform;		// connection - auto: the transform of this flipper's player
	private static float timeOfLastFlip = -Mathf.Infinity;		// tracking: the last time that a flip (by any flipper / either hand) occurred – initialized to negative infinity as a flag that a flip has never occurred




	// methods //


	// methods for: tracking flipping //
	
	// method: determine the last time that a flip (by any flipper / either hand) occurred //
	public static float lastFlippingTime()
	{
		return timeOfLastFlip;
	}


	// methods for: flipping //
	
	// method: flip the player //
	[ContextMenu("Flip")]
	public void flip()
	{
		// invert the tracking for whether the player is flipped currently //
		flipped = !flipped;

		// track the last time that a flip occurred as the current time //
		timeOfLastFlip = Time.time;

		// rotate the player by 180° on the z axis, then set the player body's x and z positions to what they were before rotation //
		Vector3 bodyPositionBeforeRotation = bodyTransform.position;		// track the the player's body position before rotation
		Player.instance.transform.Rotate(Vector3.forward * 180f);		// rotate the player by 180° on the z axis
		Vector3 bodyPositionAfterRotation = bodyTransform.position;		// track the the player's body position after rotation
		playerTransform.position -= ((new Vector3(bodyPositionAfterRotation.x, 0f, bodyPositionAfterRotation.z)) - (new Vector3(bodyPositionBeforeRotation.x, 0f, bodyPositionBeforeRotation.z)));		// unoffset the player's x and z positions such that the player body's x and z positions are back to what they were before rotation of the player
		
		// if gravity zones' forces are set to be flipped when flipping the player: //
		if (flipGravityZoneForces)
		{
			// flip the gravitation force for all gravity zones //
			GravityZone.flipForceForAll();
		}
	}

	// method: toggle whether flipping flips gravity zone forces //
	public static void toggleGravityFlipping()
	{
		left.flipGravityZoneForces = !left.flipGravityZoneForces;
		right.flipGravityZoneForces = !right.flipGravityZoneForces;
	}
	// method: toggle whether flipping flips gravity zone forces //
	public void toggleGravityFlipping_()
	{
		toggleGravityFlipping();
	}




	// updating //


	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to: the body transformation of this flipper's player, the transform of this flipper's player's body, the transform of this flipper's player //
		bodyTransformation = transform.parent.parent.GetComponentInChildren<BodyTransformation>();
		bodyTransform = bodyTransformation.transform;
		playerTransform = Player.instance.transform;
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
		// if: input is enabled, the input dependencies are met, input is pressing: //
		if (locomotionInputEnabled && locomotionDependencies.areMet() && controller.inputPressing(inputsLocomotion))
		{
			// flip the player //
			flip();
		}
	}
}