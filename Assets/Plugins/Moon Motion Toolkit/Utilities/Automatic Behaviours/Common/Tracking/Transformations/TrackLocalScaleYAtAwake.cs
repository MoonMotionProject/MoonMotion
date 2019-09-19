using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TrackLocalScaleYAtAwake : TrackingBehaviour<TrackLocalScaleYAtAwake>
{
	// variables //


	// trackings //

	[ReadOnly]
	public new float localScaleYAwake;




	// updating //


	// upon validation (defined here so that the OnValidate derived from CommonBehaviour can be found using reflection): //
	public override void OnValidate()
		=> base.OnValidate();

	// before the start: //
	private void Awake()
		=> localScaleYAwake = localScaleY;
}