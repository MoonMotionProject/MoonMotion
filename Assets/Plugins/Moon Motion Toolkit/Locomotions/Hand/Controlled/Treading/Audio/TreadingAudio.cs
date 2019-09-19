using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Treading Audio:
// • plays random treading footstep audios consecutively (without adjacent randomization repetitions)
//   · the children treading footstep audio sources are each on a respective child object
//   · an interim duration is determined by a set curve interpolated between an interpolation from a set min speed to a set mid speed and an interpolation from the set mid speed to a set max speed, ranging from a set min interval duration to a set mid interval duration to a set max interval duration
//   · whenever a footstep audio plays, waits for a set prewait time, then plays an extended vibration at a given intensity with both controllers for a set vibration duration; this is for added vibrations that play in sync with footstep audio cues
// • adjusts any attached and children treading audio sources' volumes via extension of Locomotion Movement Audio Multiple
//   · the attached treading audio source is setup to play looping treading audio (none by default) from the start
//   · the children treading audio sources play according to the randomization (see above functionality)
// • provides a connection to the singleton instance of this class
public class TreadingAudio : LocomotionMovementAudioMultiple
{
	// variables //

	
	// variables for: instancing //
	public static TreadingAudio singleton;     // connection - auto: the singleton instance of this class
	
	// variables for: playing footsteps (audio and vibration) //
	private AudioSource[] footstepAudioSources;		// connections - auto: the children treading footstep audio sources to randomize playing of
	private AudioClip[] footstepAudios;		// connections - auto: the children treading footstep audios to randomize playing of by the corresponding source
	private int previousFootstepAudioIndex = -1;		// tracking: the previously played footstep audio's index (to prevent adjacent repeats in the consecutive randomization)
	[Header("Footstep Timing (min and max speed references reused from above)")]
	public float intervalMin = .25f;		// setting: the min footstep audio interval duration to interpolate to
	public float intervalMid = .4f;		// setting: the mid footstep audio interval duration to interpolate to
	public float intervalMax = .65f;		// setting: the max footstep audio interval duration to interpolate to
	public float speedMid = 2.5f;		// setting: the mid speed by which to interpolate an interval duration (where the min and max are reused from the settings for volume adjustment)
	public InterpolationCurve speedIntervalCurve = InterpolationCurve.smoother;		// setting: the curve by which to interpolate an interval duration
	private AudioSource treadingAudioSource;		// connection - auto: the attached treading audio source (by which to determine the volume ratio by which to interpolate the footstep vibration intensity)
	[Header("Footstep Vibration")]
	public bool vibrationEnabled = false;		// setting: whether footsteps should vibrate the controllers
	[Tooltip("the duration to wait at the start of playing each footstep audio, before vibrating for that footstep")]
	public float vibrationPrewait = 0f;		// setting: the duration to wait at the start of playing each footstep audio, before vibrating for that footstep
	[Tooltip("the duration to vibrate for during each footstep")]
	public float vibrationDuration = .04f;		// setting: the duration to vibrate for during each footstep
	[Tooltip("the max intensity by which to vibrate during each footstep (curved from 0 alongside footstep volume)")]
	public ushort vibrationIntensityMax = 100;		// setting: the max intensity by which to vibrate during each footstep (curved from 0 alongside footstep volume)
	public InterpolationCurve vibrationIntensityCurve = InterpolationCurve.sine;		// setting: the curve by which to interpolate the footstep vibration intensity (based on the treading audio volume out of the set max volume)
	
	
	
	
	// methods //

	
	// method: vibrate for a footstep //
	private void vibrateForFootstep()
	{
		// determine the vibration intensity based on the current volume of the treading audio out of the max volume //
		float volumeRatio = (treadingAudioSource.volume / volumeMax);
		ushort vibrationIntensity = (ushort) (vibrationIntensityCurve.clamped(0f, vibrationIntensityMax, volumeRatio));
		
		// if each controller is on, respectively: extendedly vibrate it for the set vibration duration by the determined vibration intensity //
		if (Controller.left)
			Controller.left.vibrateExtended(vibrationDuration, vibrationIntensity);
		if (Controller.right)
			Controller.right.vibrateExtended(vibrationDuration, vibrationIntensity);
	}
	// method: have the audio source play a random footstep audio, plan to vibrate for the footstep based on the vibration settings, and plan to do this again after the duration of that audio has passed //
	private void playRandomFootstepRecursively()
	{
		// determine the footstep audios not played previously (to prevent adjacent repeats in the consecutive randomization), as well as the corresponding sources and indeces //
		List<AudioClip> footstepAudiosNotPlayedPreviously = new List<AudioClip>();
		List<AudioSource> footstepAudiosNotPlayedPreviouslySources = new List<AudioSource>();
		List<int> footstepAudiosNotPlayedPreviouslyIndeces = new List<int>();
		for (int footstepAudioIndex = 0; footstepAudioIndex < footstepAudios.Length; footstepAudioIndex++)
		{
			if (footstepAudioIndex != previousFootstepAudioIndex)
			{
				footstepAudiosNotPlayedPreviously.Add(footstepAudios[footstepAudioIndex]);
				footstepAudiosNotPlayedPreviouslySources.Add(footstepAudioSources[footstepAudioIndex]);
				footstepAudiosNotPlayedPreviouslyIndeces.Add(footstepAudioIndex);
			}
		}
		
		// choose a random footstep audio (only out of the footstep audios not played previously); also track its index (out of the entire audios array) //
		int randomizationIndex = Random.Range(0, footstepAudiosNotPlayedPreviously.Count);		// determine the randomization index (out of the audios not played previously)
		AudioClip randomFootstepAudio = footstepAudiosNotPlayedPreviously[randomizationIndex];
		AudioSource randomFootstepAudioSource = footstepAudiosNotPlayedPreviouslySources[randomizationIndex];
		int randomFootstepAudioIndex = footstepAudiosNotPlayedPreviouslyIndeces[randomizationIndex];

		// track the index of the previously played footstep audio as this one (for next time) //
		previousFootstepAudioIndex = randomFootstepAudioIndex;

		// play the random footstep audio //
		randomFootstepAudioSource.PlayOneShot(randomFootstepAudio);

		// if vibration is enabled: plan to vibrate for the footstep after the set vibration prewait duration //
		if (vibrationEnabled)
		{
			Invoke("vibrateForFootstep", vibrationPrewait);
		}

		// determine the interval duration //
		float intervalDuration = randomFootstepAudio.length;		// initialize the interval duration to the played footstep audio's length as a default
		float playerSpeed = PlayerVelocityReader.speed();		// determine the player's current speed
		if (playerSpeed < speedMid)		// if the player's current speed below the mid speed reference: interpolate from min to mid
		{
			float playerSpeedRangeRatio = ((playerSpeed - speedMin) / (speedMid - speedMin));
			intervalDuration = speedIntervalCurve.clamped(intervalMax, intervalMid, playerSpeedRangeRatio);
		}
		else		// otherwise (if the player's current speed is at or above the mid speed reference): interpolate from mid to max
		{
			float playerSpeedRangeRatio = ((playerSpeed - speedMid) / (speedMax - speedMid));
			intervalDuration = speedIntervalCurve.clamped(intervalMid, intervalMin, playerSpeedRangeRatio);
		}
		
		// plan to do this again after the determined interval duration has passed //
		Invoke("playRandomFootstepRecursively", intervalDuration);
	}

	// method: restart footsteps (audio and vibration) playing //
	private void restartFootstepsPlaying()
	{
		if (this && gameObject)		// only if this script and the object it is attached to even still exist
		{
			CancelInvoke("playRandomFootstepRecursively");
			CancelInvoke("vibrateForFootstep");
			playRandomFootstepRecursively();
		}
	}




	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to the singleton instance of this class //
		singleton = this;

		// connect to the treading audio source //
		treadingAudioSource = GetComponent<AudioSource>();
	}

	// at the start: //
	private void Start()
	{
		// connect to the footstep audios //
		List<AudioSource> listedFootstepAudioSources = new List<AudioSource>();
		List<AudioClip> listedFootstepAudios = new List<AudioClip>();
		foreach (AudioSource audioSource in audioSources)
		{
			if (audioSource.transform != transform)
			{
				listedFootstepAudioSources.Add(audioSource);
				listedFootstepAudios.Add(audioSource.clip);
			}
		}
		footstepAudioSources = listedFootstepAudioSources.ToArray();
		footstepAudios = listedFootstepAudios.ToArray();

		// begin playing random footsteps (audio and vibration) recursively //
		playRandomFootstepRecursively();

		// hookup the footsteps playing restarting method to the Treader class's treading gauge beginning event //
		Treader.treadingGaugeBeginningEvent += restartFootstepsPlaying;
	}
}