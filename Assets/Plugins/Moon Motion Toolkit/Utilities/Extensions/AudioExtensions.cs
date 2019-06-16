using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// AudioExtensions: provides extension methods for handling audio //
public static class AudioExtensions
{
	// method: return the longest length (in seconds) of audio out of all these given audios (returning -1 if the set is empty) //
	public static float longestLength(this AudioClip[] audios)
		=> audios.Max(audio => audio.length);
}