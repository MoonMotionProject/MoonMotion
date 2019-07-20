using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Audio:
// • abstract singleton behaviour that specifically provides audio functionality
//   · other than providing singleton variants of automatic behaviour audio functionality, also:
//     - maintains a calculation of smoothed audio time (that updates every frame instead of only whenever the audio time (in general, 'AudioSettings.dspTime', and also in particular this behaviour's 'audioTime') updates)
public abstract class SingletonAudio<SingletonAudioT> :
					SingletonBehaviour<SingletonAudioT>
						where SingletonAudioT : SingletonAudio<SingletonAudioT>
{
	// properties/methods //

	// properties/methods for: audio shortcuts //
	public static float duration => audioDuration;
	public static float volume => audioVolume;
	public static AudioSource setVolumeTo(float targetVolume, bool boolean = true)
		=> setAudioVolumeTo(targetVolume, boolean);
	public static bool playing => automaticBehaviour.audioPlaying;
	public static AudioSource setTimeTo(float targetTime, bool boolean = true)
		=> automaticBehaviour.setAudioTimeTo(targetTime, boolean);

	// properties/methods for: smoothing audio time //
	private static float previousAudioTime_ = -1f;		// used by 'previousAudioTime' property to handle uninitialized case (via -1 flag)
	private static float previousAudioTime => (previousAudioTime_ == -1f) ? (previousAudioTime_ = audioTime) : previousAudioTime_;		// only previous before Late Update, in which it is made current for "previous" usage in the next Update or other event before the next Late Update
	private static float setPreviousAudioTime(float targetPreviousAudioTime)
		=> previousAudioTime_ = targetPreviousAudioTime;
	private static bool audioTimeIsNew => audioTime != previousAudioTime;		// only accurate before Late Update (due to how 'previousAudioTime' is updated)
	private static float lastTimeOfNewAudioTime_ = -1f;		// used by 'lastTimeOfNewAudioTime' property to handle uninitialized case (via -1 flag)
	private static float lastTimeOfNewAudioTime => (lastTimeOfNewAudioTime_ == -1f) ? (lastTimeOfNewAudioTime_ = time) : lastTimeOfNewAudioTime_;
	private static float setLastTimeOfNewAudioTime(float targetLastTimeOfNewAudioTime)
		=> lastTimeOfNewAudioTime_ = targetLastTimeOfNewAudioTime;
	public static float smoothedAudioTime => audioTimeIsNew ? audioTime : (audioTime + timeSince(lastTimeOfNewAudioTime));		// only accurate before Late Update (due to how 'previousAudioTime' is updated)




	// methods //

	
	// methods for: playing //

	public static AudioSource play()
		=> audioPlay();

	public static AudioSource stop()
		=> audioStop();




	// updating //

	
	// at each late update: //
	public virtual void LateUpdate()
	{
		// updating for: smoothing audio time //
		if (audioTimeIsNew)
		{
			setLastTimeOfNewAudioTime(time);
		}
		if (playing)
		{
			setPreviousAudioTime(audioTime);
		}
	}
}