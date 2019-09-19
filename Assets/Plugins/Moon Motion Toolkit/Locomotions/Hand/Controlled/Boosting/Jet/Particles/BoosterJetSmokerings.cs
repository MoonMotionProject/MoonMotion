using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Jet Smokerings
// • restarts playing of these smokerings' emission depending on whether the dependencies setting is met and the player just became unterrained with the appropriate terrain
//   · restarts (instead of toggling playing) because this way, when taking off (when being on the terrain ends) the emission will finally play out all the way, such that only when taking off does it really play (and in most cases this should properly appear as just one round of emission)
public class BoosterJetSmokerings : BoosterJetParticles
{
	// variables //
	
	
	// variables for: the booster that is providing the jet that is providing these smokerings //
	public Booster booster;		// connection - manual: the booster
	
	// variables for: controlling particle emission //
	private ParticleSystem emitter;	  // connection - auto: the emitter
	public bool smokeRingWhenNongrounded = false;		// setting: whether to allow the smokerings to play while terrained instead of just grounded
	public static bool appropriatelyTerrainedAtLastUpdate = false;      // tracking: whether the player was terrained with the appropriate terrain at the last update




	// updating //

	
	// before the start: connect to the emitter //
	private void Awake()
	{
		emitter = GetComponent<ParticleSystem>();
	}

	// at each update: playing emission accordingly //
	private void Update()
	{
		// if the booster is boosting as necessary: //
		if (dependencies.areMet())
		{
			// if the player is grounded or the smoke ring is allowed to play when nongrounded and the player is terrained: track that the player was terrained at the last update //
			if (TerrainResponse.grounded() || (smokeRingWhenNongrounded && TerrainResponse.terrained()))
			{
				appropriatelyTerrainedAtLastUpdate = true;
			}
			// otherwise: if the player was terrained at the last update: track that the player was not terrained at the last update, play one round of emission of the booster smoke ring emitter //
			else if (appropriatelyTerrainedAtLastUpdate)
			{
				appropriatelyTerrainedAtLastUpdate = false;
				emitter.Play();
			}
		}
	}
}