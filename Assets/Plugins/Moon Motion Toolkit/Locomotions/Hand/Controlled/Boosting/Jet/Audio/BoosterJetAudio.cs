using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Jet Audio
// • adjusts this booster jet audio's volume and pitch according to boosting depth
//   · only plays audio when a dependencies setting is met
// • offsets the time for the first of (in theory) up to 2 booster jet audios (so that they aren't playing in sync)
public class BoosterJetAudio : MonoBehaviour
{
	// variables //
	
	
	// variables for: the booster that is providing the jet that is providing this audio //
	private Booster booster;		// connection - auto: the booster
	
	// variables for: this booster jet audio //
	private AudioSource audioComponent;		// connection - auto: the audio
	private static bool offsetYet = false;		// setting: whether the audio has been offset for one of the booster jets yet
	[Header("Pitch")]
	public float pitchShallow = 1f;		// setting: the pitch - for shallow force
	public float pitchDeep = 1.6f;		// setting: the pitch - for deep force
	[Header("Volume")]
	public float volumeShallow = 0.4f;		// setting: the volume - for shallow force
	public float volumeDeep = 1f;		// setting: the volume - for deep force
	public float volumeIncrement = 0.03f;		// setting: the increment for volume
	[Header("Dependencies")]
	[Tooltip("the dependencies by which to condition whether this booster jet audio plays")]
	[ReorderableList]
	public Dependency[] audioDependencies;




	// updating //

	
	// before the start: connect to: the booster, this booster jet audio //
	private void Awake()
	{
		booster = transform.parent.parent.GetComponent<Booster>();
		audioComponent = GetComponent<AudioSource>();
	}

	// at the start: offsetting this booster jet audio's time if there isn't another one that has been offset already //
	private void Start()
	{
		if (!offsetYet)
		{
			audioComponent.time = 1f;

			offsetYet = true;
		}
	}

	// at each physics update: adjusting pitch (alongside each physics update because that's how frequently this needs to be updated) //
	private void FixedUpdate()
	{
		if (booster.boosting)
		{
			if (!booster.boostingDeeply)
			{
				audioComponent.pitch = pitchShallow;
			}
			else
			{
				audioComponent.pitch = pitchDeep;
			}
		}
	}

	// at each update: adjusting volume (happening each update because the volume is changing over time, not just with the potentially changing frequency of physics updates) //
	private void Update()
	{
		// adjusting volume - for boosting and dependencies met //
		if (booster.boosting && audioDependencies.areMet())
		{
			// initializing volume //
			float targetVolume = audioComponent.volume;

			// determining volume //
			if (!booster.boostingDeeply)
			{
				targetVolume = volumeShallow;
			}
			else
			{
				targetVolume = volumeDeep;
			}

			// setting volume //
			if (targetVolume != audioComponent.volume)
			{
				audioComponent.volume = ((audioComponent.volume < targetVolume) ? Mathf.Min((audioComponent.volume + volumeIncrement), targetVolume) : Mathf.Max((audioComponent.volume - volumeIncrement), targetVolume));
			}
		}
		// adjusting volume - for not having both boosting occurring and dependencies met //
		else
		{
			// setting volume //
			audioComponent.volume = Mathf.Max((audioComponent.volume - volumeIncrement), 0f);
		}
	}
}