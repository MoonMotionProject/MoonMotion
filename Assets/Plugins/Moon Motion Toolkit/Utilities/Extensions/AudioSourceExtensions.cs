using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AudioSource Extensions: provides extension methods for handling AudioSources //
public static class AudioSourceExtensions
{
	#region audio

	// method: return the current audio of this given audio source //
	public static AudioClip audio(this AudioSource audioSource)
		=> audioSource.clip;

	// method: (according to the given boolean:) set this given audio source's current audio to the given target audio, then return this given audio source //
	public static AudioSource setAudioTo(this AudioSource audioSource, AudioClip targetAudio, bool boolean = true)
		=> audioSource.after(()=>
			audioSource.clip = targetAudio,
			boolean);

	// method: return the duration of the current audio of this given audio source //
	public static float duration(this AudioSource audioSource)
		=> audioSource.audio().length;
	#endregion audio


	#region volume

	public static List<float> volumes(this IEnumerable<AudioSource> audioSources)
		=> audioSources.pick(audioSource => audioSource.volume);
	public static List<float> childAudioVolumes(this GameObject gameObject)
		=> gameObject.children<AudioSource>().pick(audioSource => audioSource.volume);
	
	public static AudioSource setVolumeTo(this AudioSource audioSource, float targetVolume, bool boolean = true)
		=> audioSource.after(()=>
			audioSource.volume = targetVolume,
			boolean);
	public static IEnumerable<AudioSource> setVolumesTo(this IEnumerable<AudioSource> audioSources, IEnumerable<float> targetVolumes)
		=> audioSources.forEachByLooping(
			targetVolumes,
			(audioSource, targetVolume) => audioSource.setVolumeTo(targetVolume));
	public static GameObject setChildAudioVolumesTo(this GameObject gameObject, IEnumerable<float> targetVolumes)
		=> gameObject.actUponChildAudioSources(childAudioSources =>
			   childAudioSources.setVolumesTo(targetVolumes));
	#endregion volume


	#region playing

	// method: return whether this given audio source is currently playing //
	public static bool playing(this AudioSource audioSource)
		=> audioSource.isPlaying;
	
	// method: (according to the given boolean:) have this given audio source play, then return this given audio source //
	public static AudioSource play(this AudioSource audioSource, bool boolean = true)
		=> audioSource.after(()=>
			audioSource.Play(),
			boolean);
	// method: (according to the given boolean:) have these given audio sources play, then return an enumerable of these given audio sources //
	public static IEnumerable<AudioSource> play(this IEnumerable<AudioSource> audioSources, bool boolean = true)
		=> audioSources.forEach(audioSource => audioSource.play());
	public static GameObject playChildAudios(this GameObject gameObject)
		=> gameObject.actUponChildAudioSources(childAudioSources =>
				childAudioSources.play());

	// method: (according to the given boolean:) have this given audio source stop, then return this given audio source //
	public static AudioSource stop(this AudioSource audioSource, bool boolean = true)
		=> audioSource.after(()=>
			audioSource.Stop(),
			boolean);
	// method: (according to the given boolean:) have these given audio sources stop, then return an enumerable of these given audio sources //
	public static IEnumerable<AudioSource> stop(this IEnumerable<AudioSource> audioSources, bool boolean = true)
		=> audioSources.forEach(audioSource => audioSource.stop());
	public static GameObject stopChildAudios(this GameObject gameObject)
		=> gameObject.actUponChildAudioSources(childAudioSources =>
				childAudioSources.stop());

	// method: (according to the given boolean:) set this given audio source's time to the given target time, then return this given audio source //
	public static AudioSource setTimeTo(this AudioSource audioSource, float targetTime, bool boolean = true)
		=> audioSource.after(()=>
			audioSource.time = targetTime,
			boolean);
	#endregion playing


	#region acting upon child audio

	public static GameObject actUponChildAudioSources(this GameObject gameObject, Action<List<AudioSource>> action)
		=> gameObject.after(()=>
			  action(gameObject.children<AudioSource>()));
	#endregion acting upon child audio
}