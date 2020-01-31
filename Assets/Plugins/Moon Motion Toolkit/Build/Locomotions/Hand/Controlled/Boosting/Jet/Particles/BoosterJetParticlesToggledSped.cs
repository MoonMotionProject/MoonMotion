using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Jet Particles Toggled Sped
// • toggles playing of these particles' looping emission depending on whether the dependencies setting is met
// • adjusts these particles' speed to the setting corresponding to the current boosting depth
public class BoosterJetParticlesToggledSped : BoosterJetParticlesToggled
{
	// variables //

	
	// variables for: adjusting speed //
	private ParticleSystem.MainModule emitterSpeedModule;		// connection - auto: the emitter's module that handles speed
	[Header("Speeds")]
	public float speedShallow = .6f;		// setting: the speed - for shallow force
	public float speedDeep = 1.1f;		// setting: the speed - for deep force




	// methods //

	
	// method: play emission (have the emitter play looping emission, and adjust speed) //
	protected override void playEmission()
	{
		base.playEmission();

		// adjusting speed //
		if (!booster.boostingDeeply)
		{
			emitterSpeedModule.startSpeed = speedShallow;
		}
		else
		{
			emitterSpeedModule.startSpeed = speedDeep;
		}
	}




	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();
		
		emitterSpeedModule = emitter.main;
	}
}