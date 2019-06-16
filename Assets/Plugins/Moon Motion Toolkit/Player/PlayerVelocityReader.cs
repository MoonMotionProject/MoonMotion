using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Velocity Reader
// • provides methods for determining the player's current velocity, speed, or whether they are moving significantly slowly, or whether for any of that it is true for any axis in particular
//   · a slow speed threshold setting determines the max speed threshold at which the speed of the player is considered to be significantly slow
public class PlayerVelocityReader : SingletonBehaviour<PlayerVelocityReader>
{
	// variables //

	
	// settings //

	[Tooltip("the max speed threshold at which the speed of the player is considered to be significantly slow (for the purpose of Boosting Drifting Tracker, etc.)")]
	public float slowSpeedThreshold = .1f;




	// methods //

	
	// methods for: velocity determination //
	
	// method: determine the current velocity of the player //
	public Vector3 velocity_()
		=> rigidbody.velocity;

	// method: determine the current velocity of the player //
	public new static Vector3 velocity()
		=> singleton.velocity_();

	// method: determine the current x axis of velocity of the player //
	public float velocityX_()
		=> rigidbody.velocity.x;

	// method: determine the current x axis of velocity of the player //
	public static float velocityX()
		=> singleton.velocityX_();

	// method: determine the current y axis of velocity of the player //
	public float velocityY_()
		=> rigidbody.velocity.y;

	// method: determine the current y axis of velocity of the player //
	public static float velocityY()
		=> singleton.velocityY_();

	// method: determine the current z axis of velocity of the player //
	public float velocityZ_()
		=> rigidbody.velocity.z;

	// method: determine the current z axis of velocity of the player //
	public static float velocityZ()
		=> singleton.velocityZ_();

	// method: determine the current speed of the player //
	public float speed_()
		=> velocity_().magnitude;

	// method: determine the current speed of the player //
	public new static float speed()
		=> singleton.speed_();

	// method: determine the current x axis of speed of the player //
	public float speedX_()
		=> Mathf.Abs(velocityX_());

	// method: determine the current x axis of speed of the player //
	public static float speedX()
		=> singleton.speedX_();

	// method: determine the current y axis of speed of the player //
	public float speedY_()
		=> Mathf.Abs(velocityY_());

	// method: determine the current y axis of speed of the player //
	public static float speedY()
		=> singleton.speedY_();

	// method: determine the current z axis of speed of the player //
	public float speedZ_()
		=> Mathf.Abs(velocityZ_());

	// method: determine the current z axis of speed of the player //
	public static float speedZ()
		=> singleton.speedZ_();

	// method: determine whether the player is moving significantly slowly //
	public bool speedIsSlow_()
		=> (speed_() <= slowSpeedThreshold);

	// method: determine whether the player is moving significantly slowly //
	public static bool speedIsSlow()
		=> singleton.speedIsSlow_();

	// method: determine whether the player is moving significantly slowly on the x axis //
	public bool speedIsSlowOnX_()
		=> (speedX_() <= slowSpeedThreshold);

	// method: determine whether the player is moving significantly slowly on the x axis //
	public static bool speedIsSlowOnX()
		=> singleton.speedIsSlowOnX_();

	// method: determine whether the player is moving significantly slowly on the y axis //
	public bool speedIsSlowOnY_()
		=> (speedY_() <= slowSpeedThreshold);

	// method: determine whether the player is moving significantly slowly on the y axis //
	public static bool speedIsSlowOnY()
		=> singleton.speedIsSlowOnY_();

	// method: determine whether the player is moving significantly slowly on the z axis //
	public bool speedIsSlowOnZ_()
		=> (speedZ_() <= slowSpeedThreshold);

	// method: determine whether the player is moving significantly slowly on the z axis //
	public static bool speedIsSlowOnZ()
		=> singleton.speedIsSlowOnZ_();
}