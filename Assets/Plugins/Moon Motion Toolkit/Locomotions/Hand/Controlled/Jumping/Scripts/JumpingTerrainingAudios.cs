using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Jumping Terraining Audios:
// • adjusts the attached jumping unterraining\terraining audios' audio source via extension of Locomotion Movement Audio Single
//   · however, is based on the player's speed on the y axis only (instead of overall speed)
// • provides a singleton instance of this class
// • plays jumping unterraining and jumping terraining audios according to Terrain Response's unterraining and terraining events, respectively
//   · also tracks the respective times of the last attempted unterraining and terraining audio playings, by which audios playing spamming is reduced using the min playing interval setting
public class JumpingTerrainingAudios : LocomotionMovementAudioSingle
{
	// variables //

	
	// variables for: instancing //
	[HideInInspector] public JumpingTerrainingAudios singleton;     // connection - auto: the singleton instance of this class
	
	// variables for: playing jumping unterraining and terraining audios //
	[Header("Audios")]
	public AudioClip jumpingUnterrainingAudio;		// connection - manual: the audio for jumping unterraining
	public AudioClip jumpingTerrainingAudio;		// connection - manual: the audio for jumping terraining
	[Header("Playing Interval")]
	[Tooltip("the min duration allowed between attempted playings of unterraining or terraining audio (of the same type (unterraining\\terraining)), to reduce spamming")]
	public float minPlayingInterval = .5f;		// setting: the min duration allowed between attempted playings of terraining or unterraining audio (of the same type (terraining\\unterraining)), to reduce spamming
	private float timeOfLastAttemptedUnterrainingAudioPlaying = -1f;		// tracking: the time of the last attempted unterraining audio playing (to reduce audio playing spamming)
	private float timeOfLastAttemptedTerrainingAudioPlaying = -1f;		// tracking: the time of the last attempted terraining audio playing (to reduce audio playing spamming)
	private float timeOfLastSuccessfulUnterrainingAudioPlaying = 0f;		// tracking: the time of the last successful unterraining audio playing (by which to enforce the min required time to elapse since the last successful unterraining audio playing until terraining audio may play)
	private float timeOfLastSuccessfulTerrainingAudioPlaying = 0f;		// tracking: the time of the last successful terraining audio playing (to force the volume to max, since the player's speed would always be 0 upon terraining anyway)
	public float minElapseSinceUnterrainingUntilTerraining = .5f;		// setting: the min required time to elapse since the last successful unterraining audio playing until terraining audio may play
	
	
	
	
	// methods //

	
	// methods for: adjusting volume //
	
	// method: calculate the current player speed (but adjust it to affect the volume accordingly if playing terraining audio) //
	protected override float currentPlayerSpeed()
	{
		if ((Time.time - timeOfLastSuccessfulTerrainingAudioPlaying) <= jumpingTerrainingAudio.length)
		{
			return speedMax;
		}
		else
		{
			return PlayerVelocityReader.speedY();
		}
	}
	
	
	// methods for: playing jumping audios //

	// method: as applicable, play the jumping unterraining audio and track as much //
	public void playUnterrainingAudio()
	{
		// if: the audio source actually exists and is enabled, the min interval has passed since the last attempted unterraining audio playing: //
		if ((audioSource && audioSource.enabled) && ((Time.time - timeOfLastAttemptedUnterrainingAudioPlaying) >= minPlayingInterval))
		{
			// play the jumping unterraining audio //
			audioSource.PlayOneShot(jumpingUnterrainingAudio);

			// track the current time as the last successful unterraining audio playing //
			timeOfLastSuccessfulUnterrainingAudioPlaying = Time.time;
		}

		// track the current time as the last time that the jumping unterraining audio was attempted to be played //
		timeOfLastAttemptedUnterrainingAudioPlaying = Time.time;
	}
	
	// method: as applicable, play the jumping terraining audio and track as much //
	public void playTerrainingAudio()
	{
		// if: the audio source actually exists and is enabled, the min interval has passed since the last attempted terraining audio playing, the min elapse has passed since the last successful unterraining audio playing: //
		if ((audioSource && audioSource.enabled) && ((Time.time - timeOfLastAttemptedTerrainingAudioPlaying) >= minPlayingInterval) && ((Time.time - timeOfLastSuccessfulUnterrainingAudioPlaying) >= minElapseSinceUnterrainingUntilTerraining))
		{
			// play jumping terraining audio //
			audioSource.PlayOneShot(jumpingTerrainingAudio);

			// track the current time as the last successful terraining audio playing //
			timeOfLastSuccessfulTerrainingAudioPlaying = Time.time;
		}

		// track the current time as the last time that the jumping terraining audio was attempted to be played //
		timeOfLastAttemptedTerrainingAudioPlaying = Time.time;
	}




	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to the singleton instance of this class //
		singleton = this;
	}

	// at the start: //
	private void Start()
	{
		// hookup the jumping unterraining and terraining playing methods to the Terrain Response class's unterraining and terraining events, respectively //
		TerrainResponse.unterrainingEvent += playUnterrainingAudio;
		TerrainResponse.terrainingEvent += playTerrainingAudio;
	}
}