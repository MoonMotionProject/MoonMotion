using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Velocity Reader
// • provides properties about the player's velocity
//   · a slow speed threshold setting determines the max speed threshold at which the speed of the player is considered to be significantly slow
public class PlayerVelocityReader : SingletonBehaviour<PlayerVelocityReader>
{
	#region variables
	
	[Tooltip("the max speed threshold at which the speed of the player is considered to be significantly slow (for the purpose of Boosting Drifting Tracker, etc.)")]
	public float slowSpeedThreshold = .1f;
	#endregion variables
	

	#region properties
	
	// whether the player is moving significantly slowly //
	public bool _speedIsSlow => speed <= slowSpeedThreshold;
	public static bool speedIsSlow => singleton._speedIsSlow;

	// whether the player is moving significantly slowly on the x axis //
	public bool _speedIsSlowOnX => speedX <= slowSpeedThreshold;
	public static bool speedIsSlowOnX => singleton._speedIsSlowOnX;

	// whether the player is moving significantly slowly on the y axis //
	public bool _speedIsSlowOnY => speedY <= slowSpeedThreshold;
	public static bool speedIsSlowOnY => singleton._speedIsSlowOnY;

	// whether the player is moving significantly slowly on the z axis //
	public bool _speedIsSlowOnZ => speedZ <= slowSpeedThreshold;
	public static bool speedIsSlowOnZ => singleton._speedIsSlowOnZ;
	#endregion properties
}