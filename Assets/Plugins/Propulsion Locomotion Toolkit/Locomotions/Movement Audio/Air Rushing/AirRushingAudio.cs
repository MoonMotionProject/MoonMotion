﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Air Rushing Audio
// • adjusts the attached air rushing audio via extension of Locomotion Movement Audio Single
//   · however, is based on the player's speed on the y axis averaged with the overall speed, so as to emphasize the y axis speed more
// • provides a connection to the singleton instance of this class
// • a Dependency that is used by default for whether the player is within air nonrushing distance is provided by Dependencies which checks the state of the dependency according to Terrain Response, on which the air nonrushing distance is defined as a setting
public class AirRushingAudio : LocomotionMovementAudioSingle
{
	// variables //

	
	// variables for: instancing //
	public static AirRushingAudio singleton;		// connection - automatic: the singleton instance of this class
	
	
	
	
	// methods //

	
	// methods for: adjusting volume //
	
	// method: calculate the current player speed //
	protected override float currentPlayerSpeed()
	{
		return ((PlayerVelocityReader.speed() + PlayerVelocityReader.speedY()) / 2f);
	}




	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to the singleton instance of this class //
		singleton = this;
	}
}