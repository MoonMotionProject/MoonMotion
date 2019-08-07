using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Audio Source Extensions: provides extension methods for handling audio sources //
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

	public static List<float> volumes<IListT>(this IListT audioSources) where IListT : IList<AudioSource>
		=> audioSources.pick(audioSource => audioSource.volume);

	// method: (according to the given boolean:) set the volume of this given audio source to the given target volume, then return this given audio source //
	public static AudioSource setVolumeTo(this AudioSource audioSource, float targetVolume, bool boolean = true)
		=> audioSource.after(()=>
			audioSource.volume = targetVolume,
			boolean);

	public static IListT setVolumesTo<IListT>(this IListT audioSources, IList<float> targetVolumes) where IListT : IList<AudioSource>
	{
		for (int audioSourceIndex = 0; audioSourceIndex < audioSources.Count; audioSourceIndex++)
		{
			audioSources[audioSourceIndex].setVolumeTo(targetVolumes[audioSourceIndex % targetVolumes.Count]);
		}

		return audioSources;
	}
	#endregion audio


	#region playing

	// method: return whether this given audio source is currently playing //
	public static bool playing(this AudioSource audioSource)
		=> audioSource.isPlaying;
	
	// method: (according to the given boolean:) have this given audio source play, then return this given audio source //
	public static AudioSource play(this AudioSource audioSource, bool boolean = true)
		=> audioSource.after(()=>
			audioSource.Play(),
			boolean);

	// method: (according to the given boolean:) have this given audio source stop, then return this given audio source //
	public static AudioSource stop(this AudioSource audioSource, bool boolean = true)
		=> audioSource.after(()=>
			audioSource.Stop(),
			boolean);

	// method: (according to the given boolean:) set this given audio source's time to the given target time, then return this given audio source //
	public static AudioSource setTimeTo(this AudioSource audioSource, float targetTime, bool boolean = true)
		=> audioSource.after(()=>
			audioSource.time = targetTime,
			boolean);
	#endregion playing


	#region child audio sources

	public static List<float> childAudioVolumes(this GameObject gameObject)
		=> gameObject.children<AudioSource>().pick(audioSource => audioSource.volume);

	public static GameObject setChildAudioVolumesTo(this GameObject gameObject, IList<float> targetVolumes)
		=>	gameObject.after(()=>
				gameObject.children<AudioSource>().setVolumesTo(targetVolumes));
	#endregion child audio sources
}