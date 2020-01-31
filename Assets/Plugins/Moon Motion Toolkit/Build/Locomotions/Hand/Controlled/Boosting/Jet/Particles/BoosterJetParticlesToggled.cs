using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Jet Particles Toggled
// • toggles playing of these particles' looping emission depending on whether the dependencies setting is met
public class BoosterJetParticlesToggled : BoosterJetParticles
{
	// variables //
	
	
	// variables for: the booster that is providing the jet that is providing these particles //
	protected Booster booster;		// connection - auto: the booster
	
	// variables for: controlling particle emission //
	protected ParticleSystem emitter;	  // connection - auto: the emitter




	// methods //

	
	// method: play emission (have the emitter play looping emission, and do anything else that is to be done when playing – this method can be extended) //
	protected virtual void playEmission()
	{
		// if the emitter is not already emitting: have it play looping emission //
		if (!emitter.isEmitting)
		{
			emitter.Play();
		}
	}
	
	
	
	
	// updating //

	
	// before the start: connect to: the booster, the emitter //
	protected virtual void Awake()
	{
		booster = transform.parent.parent.GetComponent<Booster>();
		emitter = GetComponent<ParticleSystem>();
	}

	// at each physics update: toggling playing emission (alongside each physics update because that's how frequently this needs to be updated) //
	protected virtual void FixedUpdate()
	{
		if (booster && emitter)        // (so long as the booster and the emitter actually exist)
		{
			// if: the booster is an enabled aesthetic, the dependencies are met, the booster is boosting as necessary: //
			if (aestheticEnabled && dependencies.areMet())
			{
				playEmission();
			}
			// otherwise (if the booster is not an enabled aesthetic or not boosting deeply): stop playing emission //
			else
			{
				emitter.Stop();
			}
		}
	}
}