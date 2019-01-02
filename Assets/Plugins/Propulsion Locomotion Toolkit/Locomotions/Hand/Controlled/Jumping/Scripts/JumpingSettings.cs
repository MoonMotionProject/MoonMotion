using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Jumping Settings: provides settings and handles related trackings for the Jumpers to use for the jumping locomotion:
// • provides a setting and method for toggling whether midair jumping is allowed
// • provides a dependencies setting by which midair jumping is further restricted to being dependent upon those conditions
// • provides a setting and handles related tracking for the number of midair (while not terrained) jumps the player is allotted for until they are terrained again; when this is set to -1 (standing for ∞), the player may do as many midair jumps as they like
// • tracks jumping and also uses this tracking to enforce a jumping cooldown:
//   · tracks the time of the last jump
//   · provides a setting for a jumping cooldown
//   · provides a method for determining whether the player has jumped within a given amount of time from now
public class JumpingSettings : MonoBehaviour
{
	// variables //
	
	
	// variables for: instancing //
	private static JumpingSettings singleton;		// connection - automatic: the singleton instance of this class
	
	// variables for: midair jumping //
	[Header("Midair Jumping")]
	[Tooltip("whether midair jumping is currently allowed")]
	public bool midairJumpingAllowed = false;		// setting: whether midair jumping is currently allowed
	[Tooltip("the dependencies combination by which to condition whether the player can midair jump")]
	public Dependencies.DependenciesCombination midairJumpingDependencies;		// setting: the dependencies combination by which to condition whether the player can midair jump
	[Tooltip("the number of midair jumps the player is raised (but not lowered) to whenever they are terrained")]
	public int midairJumpsProvided = 1;		// setting: the number of midair jumps the player is raised (but not lowered) to whenever they are terrained
	[Tooltip("the number of midair jumps the player has remaining (which may be more than the number of jumps provided, if adjusted externally)")]
	public int midairJumpsCount = 1;     // tracking: the number of midair jumps the player has remaining (which may be more than the number of jumps provided, if adjusted externally)

	// variables for: tracking jumping and jumping cooldown //
	private static float timeOfLastJump = -666666f;		// tracking: the time of the last jump
	[Header("Jumping Cooldown")]
	public float jumpingCooldown = .3f;		// setting: the cooldown duration between jumps




	// methods //

	
	// methods for: midair jumping //
	
	// method: toggle whether midair jumping is allowed //
	public void toggleMidairJumping_()
	{
		midairJumpingAllowed = !midairJumpingAllowed;
	}
	// method: toggle whether midair jumping is allowed //
	public static void toggleMidairJumping()
	{
		singleton.toggleMidairJumping_();
	}
	// method: determine whether midair jumping is available (considering: whether it is allowed, whether the midair jumping dependencies are met, the tracked number of midair jumps the player has remaining) //
	public bool midairJumpingAvailable_()
	{
		return (midairJumpingAllowed && Dependencies.metFor(midairJumpingDependencies) && ((midairJumpsCount > 0) || (midairJumpsCount == -1)));
	}
	// method: determine whether midair jumping is available (considering: whether it is allowed, whether the midair jumping dependencies are met, the tracked number of midair jumps the player has remaining) //
	public static bool midairJumpingAvailable()
	{
		return singleton.midairJumpingAvailable_();
	}
	// method: determine whether midair jumping is infinite (versus discrete/limited) //
	public static bool midairJumpingInfinite()
	{
		return (singleton.midairJumpsCount == -1);
	}
	// method: set the midair jumps provision to the given amount //
	public void setMidairJumpsProvision_(int amount)
	{
		midairJumpsProvided = amount;
	}
	// method: set the midair jumps provision to the given amount //
	public static void setMidairJumpsProvision(int amount)
	{
		singleton.setMidairJumpsProvision_(amount);
	}
	// method: decrement the midair jumps count //
	public static void decrementMidairJumpsCount()
	{
		singleton.midairJumpsCount--;
	}
	// method: add the given amount to the midair jumps count //
	public void addMidairJumps_(int amount)
	{
		midairJumpsCount += amount;
	}
	// method: add the given amount to the midair jumps count //
	public static void addMidairJumps(int amount)
	{
		singleton.addMidairJumps_(amount);
	}
	// method: set the midair jumps count to the given amount //
	public void setMidairJumpsCount_(int amount)
	{
		midairJumpsCount = amount;
	}
	// method: set the midair jumps count to the given amount //
	public static void setMidairJumpsCount(int amount)
	{
		singleton.setMidairJumpsCount_(amount);
	}


	// methods for: tracking jumping and jumping cooldown //

	// method: track the time of the last jump as right now and return it //
	public static float trackTimeOfLastJump()
	{
		timeOfLastJump = Time.time;
		return timeOfLastJump;
	}
	// method: determine whether the time of the last jump was within the given amount of time from now //
	public static bool lastJumpedWithin(float timeThreshold)
	{
		return ((Time.time - timeOfLastJump) < timeThreshold);
	}
	// method: determine whether jumping is ready (based on its cooldown duration) //
	public static bool jumpingReady()
	{
		return (singleton && !lastJumpedWithin(singleton.jumpingCooldown));
	}
	
	
	
	
	// updating //


	// before the start: //
	private void Awake()
	{
		// connect to the singleton instance of this class //
		singleton = this;
	}


	// at each update: //
	private void Update()
	{
		// if the number of midair jumps provided is -1 (standing for infinity): set the midair jumps count to -1 (standing for infinity)
		if (midairJumpsProvided == -1)
		{
			midairJumpsCount = -1;
		}
		// if the player is terrained: //
		if (TerrainResponse.terrained())
		{
			// if the midair jumps count is lower than the number of jumps provided: raise the midair jumps count to the number of jumps provided //
			if (midairJumpsCount < midairJumpsProvided)
			{
				midairJumpsCount = midairJumpsProvided;
			}
		}
	}
}