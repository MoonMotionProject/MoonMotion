﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Module
// • classifies this booster child object as a booster module: a component of the booster in charge of handling a particular functionality
// • provides:
//   · a connection to the corresponding parent booster's transform
//   · a connection to the booster
//   · a tracking for the booster's handedness
//   · a dependencies combination setting to require such conditions for the module to be active
public abstract class BoosterModule : MonoBehaviour
{
	// variables //

	
	// variables for: booster connections and handedness tracking //
	protected Transform boosterTransform;		// connection - automatic: the booster's transform
	protected Booster booster;		// connection - automatic: the booster this module is for
	protected bool leftHand;		// tracking: the booster's handedness (whether the booster is for the left hand versus the right)

	// variables for: dependencies //
	[Header("Dependencies")]
	[Tooltip("the dependencies combination by which to determine whether this booster module may be enabled")]
	public Dependencies.DependenciesCombination dependenciesCombination;		// setting: the dependencies combination by which to determine whether this booster module may be enabled




	// updating //

	
	// before the start: connect to the booster //
	protected virtual void Awake()
	{
		boosterTransform = transform.parent;
		booster = boosterTransform.GetComponent<Booster>();
	}

	// at the start: track the booster's handedness //
	protected virtual void Start()
	{
		leftHand = (booster.leftHand);
	}
}