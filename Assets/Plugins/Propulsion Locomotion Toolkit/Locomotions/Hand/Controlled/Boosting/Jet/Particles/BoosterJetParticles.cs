using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Jet Particles: provides base functionality for booster jet particles systems
// • provides tracking for whether this particles system should be enabled according to Booster Aesthetics Set Cycler
// • provides a dependencies setting by which to condition whether this booster jet particles can play
public class BoosterJetParticles : MonoBehaviour
{
	// variables //

	
	// variables for: aesthetics cycling //
	[HideInInspector] public bool aestheticEnabled = true;		// tracking: whether this particles system should be enabled according to Booster Aesthetics Set Cycler

	// variables for: dependencies //
	[Header("Dependencies")]
	[Tooltip("the dependencies combination by which to condition whether this booster jet particles plays")]
	public Dependencies.DependenciesCombination dependencies;		// setting: the dependencies combination by which to condition whether this booster jet particles plays
}