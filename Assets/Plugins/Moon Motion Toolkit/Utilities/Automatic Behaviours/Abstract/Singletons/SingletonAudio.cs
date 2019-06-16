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
	// properties //
	
	
	public new static AudioSource audioSource
	{
		get {return ((AutomaticBehaviour<SingletonAudioT>) singleton).audioSource;}
	}
	public new static AudioClip audio
	{
		get {return ((AutomaticBehaviour<SingletonAudioT>) singleton).audio;}
		set {((AutomaticBehaviour<SingletonAudioT>) singleton).audio = value;}
	}
	public static bool playing
	{
		get {return singleton.audioPlaying;}
	}
	public new static float audioTime
	{
		get {return ((AutomaticBehaviour<SingletonAudioT>) singleton).audioTime;}
		set {((AutomaticBehaviour<SingletonAudioT>) singleton).audioTime = value;}
	}
	private static float previousAudioTime_ = -1f;		// used by 'previousAudioTime' property to handle uninitialized case (via -1 flag)
	private static float previousAudioTime      // only previous before Late Update, in which it is made current for "previous" usage in the next Update or other event before the next Late Update
	{
		get {return (previousAudioTime_ == -1f) ? (previousAudioTime_ = audioTime) : previousAudioTime_;}
		set {previousAudioTime_ = value;}
	}
	private static bool audioTimeIsNew      // only accurate before Late Update (due to how 'previousAudioTime' is updated)
	{
		get {return (audioTime != previousAudioTime);}
	}
	private static float lastTimeOfNewAudioTime_ = -1f;     // used by 'lastTimeOfNewAudioTime' property to handle uninitialized case (via -1 flag)
	private static float lastTimeOfNewAudioTime
	{
		get {return (lastTimeOfNewAudioTime_ == -1f) ? (lastTimeOfNewAudioTime_ = time) : lastTimeOfNewAudioTime_; }
		set {lastTimeOfNewAudioTime_ = value;}
	}
	public static float smoothedAudioTime      // only accurate before Late Update (due to how 'previousAudioTime' is updated)
	{
		get {return audioTimeIsNew ? audioTime : (audioTime + timeSince(lastTimeOfNewAudioTime));}
	}
	public static float duration
	{
		get {return singleton.audioDuration;}
	}




	// methods //

	
	public static AudioSource play()
		=> singleton.audioPlay();

	public static AudioSource stop()
		=> singleton.audioStop();




	// updating //

	
	// at each late update: //
	protected virtual void LateUpdate()
	{
		if (audioTimeIsNew)
		{
			lastTimeOfNewAudioTime = time;
		}

		if (playing)
		{
			previousAudioTime = audioTime;
		}
	}
}