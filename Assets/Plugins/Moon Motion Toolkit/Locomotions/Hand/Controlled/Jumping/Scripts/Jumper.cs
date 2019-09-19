using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Jumper
// • classifies this hand locomotion as the "jumping" locomotion
// • when the player is terrained, behaves the parent hand as a jumper that applies an upward force to the player upon input
// • only one jumping force is applied upon simultaneous input from both controllers
// • plays audio for jumping
//   · Jumping Terraining Audio plays audio for jumping unterraining\terraining
// • Jumping Settings provides a setting and tracking for a jumping cooldown
// • Jumping Settings provides a setting and handles related tracking for the number of midair (while not terrained) jumps the player is allotted for until they are terrained again; when this is set to -1 (standing for ∞), the player may do as many midair jumps as they like
// • a setting is provided for whether this jumper's midair jumps should replace the player's y axis velocity when the latter is less than the former
// • the jumping force applied is vertically flipped according to whether the flipping locomotion has the player flipped currently
public class Jumper : HandLocomotionControlled
{
	// variables //

	
	// variables for: instancing //
	public static Jumper left, right;		// connections - auto: left and right jumper instances
	private Jumper other;		// connection - auto: the other jumper (for the other hand that this jumper doesn't belong to)

	// variables for: playing jumping audio //
	private AudioSource audioSource;		// connection - auto: the attached jumping audio source
	private new AudioClip audio;		// connection - auto: the attached jumping audio
	
	// variables for: jumping in general //
	private Rigidbody playerRigidbody;		// connection - auto: the player rigidbody
	[Header("Jumping")]
	public float forceAmount = 5f;		// setting: the amount of force to apply
	public static bool jumpedWithinLastSecond = false;		// tracking: whether the player has jumped within the last second

	// variables for: midair jumping //
	[Header("Midair Jumping Physics")]
	[Tooltip("whether this jumper's midair jumps' upward velocity should replace the player's y axis velocity when the latter is less than the former (by zeroing the player's y axis velocity before applying the jumping force)")]
	public bool midairJumpingReplacesVelocity = true;		// setting: whether this jumper's midair jumps' upward velocity should replace the player's y axis velocity when the latter is less than the former (by zeroing the player's y axis velocity before applying the jumping force)

	
	
	
	// methods //
	
	
	// methods for: playing jumping audio //

	// method: play the attached jumping audio //
	public void playJumpingAudio()
	{
		audioSource.PlayOneShot(audio);
	}
	
	
	// methods for: jumping in general //
	
	// method: determine whether this jumper's priority is overriden (and is thus not able to jump, since only the other should at this moment) //
	private bool priorityOverridden()
	{
		return (other && other.gameObject && other.gameObject.activeSelf && (other == left) && other.locomotionInputEnabledAndAllowed() && other.controller.inputPressing(other.inputsLocomotion));
	}
	
	
	
	
	// updating //
	

	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to the attached jumping audio source and audio //
		audioSource = GetComponent<AudioSource>();
		audio = audioSource.clip;

		// connect to the player rigidbody //
		playerRigidbody = Player.instance.GetComponent<Rigidbody>();
	}
	
	// upon being enabled: //
	private void OnEnable()
	{
		// connect to the corresponding instance of this class //
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

		// connect to the other instance of this class //
		other = (leftInstance ? right : left);
	}

	// at each update: //
	private void Update()
	{
		// if: the player is ready to jump, the player is terrained or midair jumping is available, locomotion input is enabled and allowed, locomotion input is pressing, this jumper's priority is not overridden: //
		if (JumpingSettings.jumpingReady() && (TerrainResponse.terrained() || JumpingSettings.midairJumpingAvailable()) && locomotionInputEnabledAndAllowed() && controller.inputPressing(inputsLocomotion) && !priorityOverridden())
		{
			// handle midair jumping //
			if (!TerrainResponse.terrained())
			{
				Vector3 playerVelocity = PlayerVelocityReader.velocity();

				if (midairJumpingReplacesVelocity && ((playerVelocity.y < forceAmount) || (Flipper.flipped && (playerVelocity.y > -forceAmount))))
				{
					playerRigidbody.velocity = new Vector3(playerVelocity.x, 0f, playerVelocity.z);
				}

				if (!JumpingSettings.midairJumpingInfinite())
				{
					JumpingSettings.decrementMidairJumpsCount();
				}
			}

			// play the attached jumping audio //
			playJumpingAudio();

			// change the player's velocity for this jumping //
			playerRigidbody.velocity += new Vector3(0f, (Flipper.flipped ? -forceAmount : forceAmount), 0f);

			// have Jumping Settings track the time of the last jump as right now //
			JumpingSettings.trackTimeOfLastJump();
		}
	}
}