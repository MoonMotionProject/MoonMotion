using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Velocity Reader
// • provides methods for determining the player's current velocity, speed, or whether they are moving significantly slowly, or whether for any of that it is true for any axis in particular
//   · a slow speed threshold setting determines the max speed threshold at which the speed of the player is considered to be significantly slow
public class PlayerVelocityReader : MonoBehaviour
{
	// variables //

	
	// variables for: instancing //
	public static PlayerVelocityReader singleton;		// connection - automatic: the singleton instance of this class
	
	// variables for: velocity determination //
	private new Rigidbody rigidbody;		// connection - automatic: the player's rigidbody (attached)
	[Tooltip("the max speed threshold at which the speed of the player is considered to be significantly slow (for the purpose of Boosting Drifting Tracker, etc.)")]
	public float slowSpeedThreshold = .1f;		// setting: the max speed threshold at which the speed of the player is considered to be significantly slow (for the purpose of Boosting Drifting Tracker, etc.)




	// methods //

	
	// methods for: velocity determination //
	
	// method: determine the current velocity of the player //
	public Vector3 velocity_()
	{
		return rigidbody.velocity;
	}
	// method: determine the current velocity of the player //
	public static Vector3 velocity()
	{
		return singleton.velocity_();
	}
	// method: determine the current x axis of velocity of the player //
	public float velocityX_()
	{
		return rigidbody.velocity.x;
	}
	// method: determine the current x axis of velocity of the player //
	public static float velocityX()
	{
		return singleton.velocityX_();
	}
	// method: determine the current y axis of velocity of the player //
	public float velocityY_()
	{
		return rigidbody.velocity.y;
	}
	// method: determine the current y axis of velocity of the player //
	public static float velocityY()
	{
		return singleton.velocityY_();
	}
	// method: determine the current z axis of velocity of the player //
	public float velocityZ_()
	{
		return rigidbody.velocity.z;
	}
	// method: determine the current z axis of velocity of the player //
	public static float velocityZ()
	{
		return singleton.velocityZ_();
	}
	// method: determine the current speed of the player //
	public float speed_()
	{
		return velocity_().magnitude;
	}
	// method: determine the current speed of the player //
	public static float speed()
	{
		return singleton.speed_();
	}
	// method: determine the current x axis of speed of the player //
	public float speedX_()
	{
		return Mathf.Abs(velocityX_());
	}
	// method: determine the current x axis of speed of the player //
	public static float speedX()
	{
		return singleton.speedX_();
	}
	// method: determine the current y axis of speed of the player //
	public float speedY_()
	{
		return Mathf.Abs(velocityY_());
	}
	// method: determine the current y axis of speed of the player //
	public static float speedY()
	{
		return singleton.speedY_();
	}
	// method: determine the current z axis of speed of the player //
	public float speedZ_()
	{
		return Mathf.Abs(velocityZ_());
	}
	// method: determine the current z axis of speed of the player //
	public static float speedZ()
	{
		return singleton.speedZ_();
	}
	// method: determine whether the player is moving significantly slowly //
	public bool speedIsSlow_()
	{
		return (speed_() <= slowSpeedThreshold);
	}
	// method: determine whether the player is moving significantly slowly //
	public static bool speedIsSlow()
	{
		return singleton.speedIsSlow_();
	}
	// method: determine whether the player is moving significantly slowly on the x axis //
	public bool speedIsSlowOnX_()
	{
		return (speedX_() <= slowSpeedThreshold);
	}
	// method: determine whether the player is moving significantly slowly on the x axis //
	public static bool speedIsSlowOnX()
	{
		return singleton.speedIsSlowOnX_();
	}
	// method: determine whether the player is moving significantly slowly on the y axis //
	public bool speedIsSlowOnY_()
	{
		return (speedY_() <= slowSpeedThreshold);
	}
	// method: determine whether the player is moving significantly slowly on the y axis //
	public static bool speedIsSlowOnY()
	{
		return singleton.speedIsSlowOnY_();
	}
	// method: determine whether the player is moving significantly slowly on the z axis //
	public bool speedIsSlowOnZ_()
	{
		return (speedZ_() <= slowSpeedThreshold);
	}
	// method: determine whether the player is moving significantly slowly on the z axis //
	public static bool speedIsSlowOnZ()
	{
		return singleton.speedIsSlowOnZ_();
	}




	// updating //

	
	// before the start: //
	private void Awake()
	{
		// connect to the singleton instance of this class //
		singleton = this;

		// connect to the player's rigidbody //
		rigidbody = GetComponent<Rigidbody>();
	}
}