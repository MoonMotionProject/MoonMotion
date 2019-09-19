using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TrackPositionXAtAwake : TrackingBehaviour<TrackPositionXAtAwake>
{
	// variables //


	// trackings //

	[ReadOnly]
	public new float positionXAwake;




	// updating //


	// upon validation (defined here so that the OnValidate derived from CommonBehaviour can be found using reflection): //
	public override void OnValidate()
		=> base.OnValidate();

	// before the start: //
	private void Awake()
		=> positionXAwake = positionX;
}