using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// AudioExtensions: provides extension methods for handling audio //
public static class AudioExtensions
{
	// method: return the longest length (in seconds) of audio out of all these given audios (returning -1 if the enumerable is empty) //
	public static float longestLength(this IEnumerable<AudioClip> audios)
		=> audios.max(audio =>
			audio.length);
}