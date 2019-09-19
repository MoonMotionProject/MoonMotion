using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Jet Particles Briefed
// • toggles playing of these particles' looping emission briefly after starting to boost deeply
//   · can optionally play only when boosting deeply
public class BoosterJetParticlesBriefed : BoosterJetParticles
{
	// variables //
	

	// variables for: the booster that is providing the jet that is providing these particles //
	private Booster booster;		// connection - auto: the booster
	private Controller controller;		// connection - auto: the controller of the booster
	
	// variables for: controlling particle emission //
	private ParticleSystem emitter;	  // connection - auto: the emitter
	public bool requiresDeepBoosting = true;		// setting: whether to allow the particles to play only when boosting deeply
	public float duration = .2f;		// setting: the brief duration to play the particles (the amount of time until playing their emission should be stopped)
	private float remainder = 0f;		// tracking: the remaining time to play the particles (set to the duration whenever playing is started)




	// updating //

	
	// before the start: connect to: the booster, the emitter //
	private void Awake()
	{
		booster = transform.parent.parent.GetComponent<Booster>();
		controller = transform.parent.parent.parent.GetComponent<Controller>();
		emitter = GetComponent<ParticleSystem>();
	}

	// toggling playing emission briefly //
	private void Update()
	{
		// reduce the remainder by the duration of this update, but not to put it below 0 //
		remainder = Mathf.Max(remainder - Time.deltaTime, 0f);
		// if the emitter is not already emitting and this is an enabled aesthetic and the dependencies are met: //
		if (!emitter.isEmitting && (aestheticEnabled && dependencies.areMet()))
		{
			// if the booster is boosting as necessary and the controller is beginning the corresponding input: //
			bool deepConditionsCase = (requiresDeepBoosting && booster.boostingDeeply && controller.inputDeeping(booster.inputsLocomotion));
			bool anyConditionsCase = (!requiresDeepBoosting && booster.boosting && controller.inputPressing(booster.inputsLocomotion));
			if (deepConditionsCase || anyConditionsCase)
			{
				emitter.Play();		// have it play looping emission
				remainder = duration;		// set the remainder to the duration
			}
		}
		// if this is not an enabled aesthetic for which the dependencies met, or there is no longer any remaining time to play the particles: stop them //
		if (!(aestheticEnabled && dependencies.areMet()) || (remainder == 0f))
		{
			emitter.Stop();
		}
	}
}