using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TrackLocalScaleAtAwake : TrackingBehaviour<TrackLocalScaleAtAwake>
{
	// variables //


	// trackings //

	[ReadOnly]
	public new Vector3 localScaleAwake;




	// updating //


	// upon validation (defined here so that the OnValidate derived from CommonBehaviour can be found using reflection): //
	public override void OnValidate()
		=> base.OnValidate();

	// before the start: //
	private void Awake()
		=> localScaleAwake = localScale;
}