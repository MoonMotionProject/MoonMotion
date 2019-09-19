using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TrackEulerAnglesAtAwake : TrackingBehaviour<TrackEulerAnglesAtAwake>
{
	// variables //


	// trackings //

	[ReadOnly]
	public new Vector3 eulerAnglesAwake;




	// updating //


	// upon validation (defined here so that the OnValidate derived from CommonBehaviour can be found using reflection): //
	public override void OnValidate()
		=> base.OnValidate();

	// before the start: //
	private void Awake()
		=> eulerAnglesAwake = eulerAngles;
}