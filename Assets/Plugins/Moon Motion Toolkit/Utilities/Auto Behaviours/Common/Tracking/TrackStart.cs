using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TrackStart : TrackingBehaviour<TrackStart>
{
	// variables //


	// trackings //

	[ReadOnly]
	public new bool hasStarted;




	// updating //


	// upon validation (defined here so that the OnValidate derived from CommonBehaviour can be found using reflection): //
	public override void OnValidate()
		=> base.OnValidate();

	// at the start: //
	private void Start()
		=> hasStarted = true;
}