using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TrackLocalPositionYAtAwake : TrackingBehaviour<TrackLocalPositionYAtAwake>
{
	// variables //

	
	// trackings //

	[ReadOnly]
	public new float localPositionYAwake;




	// updating //


	// upon validation (defined here so that the OnValidate derived from CommonBehaviour can be found using reflection): //
	public override void OnValidate()
		=> base.OnValidate();

	// before the start: //
	private void Awake()
		=> localPositionYAwake = localPositionY;
}