using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Locomotion Movement Audio
// • adjusts locomotion audio volume, using max volume and volume increment settings, and based on whether certain dependency settings are met
//   · the relevant locomotion audio source connection is passed to this script's volume adjusting method by its extending class
//     - the audio source's playing is not handled by this script
//   · max volume is used as modified by a set curve that depends on the player's moving speed within a set range
public abstract class LocomotionMovementAudio : MonoBehaviour
{
	// variables //
	
	
	// variables for: adjusting volume //
	[Header("Volume Adjustment")]
	public float volumeMax = .15f;		// setting: the max volume percentage (to interpolate to from 0)
	[Tooltip("a factor of the percentage by which to increment the volume in a single frame (the other factor being the time passed in that frame)")]
	public float volumeIncrementFactor = 2f;		// setting: a factor of the percentage by which to increment the volume in a single frame (the other factor being the time passed in that frame)
	[Tooltip("a factor of the percentage by which to decrement the volume in a single frame (the other factor being the time passed in that frame)")]
	public float volumeDecrementFactor = 2f;		// setting: a factor of the percentage by which to decrement the volume in a single frame (the other factor being the time passed in that frame)
	public float speedMin = 0f;		// setting: the min speed by which to interpolate a modification of the max volume from 0
	public float speedMax = 7f;		// setting: the max speed by which to interpolate a modification of the max volume from 0
	public InterpolationCurved.Curve speedVolumeCurve = InterpolationCurved.Curve.sine;		// setting: the curve by which to interpolate a modification of the max volume from 0
	[Tooltip("the dependencies combination by which to play this locomotion movement audio (the conditions by which to determine whether the audio volume may be incremented)")]
	public Dependencies.DependenciesCombination dependenciesCombination;		// setting: the dependencies combination by which to play this locomotion movement audio (the conditions by which to determine whether the audio volume may be incremented)

	


	// methods //

	
	// methods for: adjusting volume //
	
	// method: calculate the current player speed //
	protected virtual float currentPlayerSpeed()
	{
		return PlayerVelocityReader.speed();
	}
	// method: adjust the given audio source's volume by the given amount //
	protected virtual void adjustVolumeOfGivenAudioSource(AudioSource audioSource, float amount)
	{
		// calculate the modified max volume (to use only when the volume is increasing) //
		float playerSpeedRangeRatio = ((currentPlayerSpeed() - speedMin) / (speedMax - speedMin));
		float maxVolumeModified = InterpolationCurved.floatClamped(speedVolumeCurve, 0f, volumeMax, playerSpeedRangeRatio);
		
		// adjust the volume to be within the range of 0 to either: the modified max volume, if the amount is positive; the max volume, if the amount is not positive //
		float maxVolumeToUse = ((amount > 0f) ? maxVolumeModified : volumeMax);
		audioSource.volume = Mathf.Min(Mathf.Max(0f, (audioSource.volume + amount)), maxVolumeToUse);
	}
	// method: adjust any appropriate audio sources' volume by the given amount //
	protected abstract void adjustVolume(float amount);
	// method: determine the volume increment for this frame (by multiplying the volume increment factor by the time passed in this frame)
	protected virtual float volumeIncrementForFrame()
	{
		return (volumeIncrementFactor * Time.deltaTime);
	}
	// method: increment the audio source's volume (by the set amount) //
	protected virtual void incrementVolume()
	{
		adjustVolume(volumeIncrementForFrame());
	}
	// method: determine the volume decrement for this frame (by multiplying the volume decrement factor by the time passed in this frame)
	protected virtual float volumeDecrementForFrame()
	{
		return (volumeDecrementFactor * Time.deltaTime);
	}
	// method: decrement the audio source's volume (by the set amount) //
	protected virtual void decrementVolume()
	{
		adjustVolume(-volumeDecrementForFrame());
	}



	// updating //


	// at each update: //
	protected virtual void Update()
	{
		if (Dependencies.metFor(dependenciesCombination))
		{
			incrementVolume();
		}
		else
		{
			decrementVolume();
		}
	}
}