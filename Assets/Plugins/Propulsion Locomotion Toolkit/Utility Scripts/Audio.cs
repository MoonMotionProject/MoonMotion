using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Audio: provides methods for working with audio
// • provides a method for determining the longest length of audio out of all the audios in the given audio set
public class Audio : MonoBehaviour
{
	// methods: //


	// method: determine the longest length of audio out of all the audios in the given audio set (returning -1 if the set is empty) //
	public static float longestLengthInSet(AudioClip[] audioSet)
	{
		float longestLengthFoundYet = -1f;

		foreach (AudioClip audio in audioSet)
		{
			if (audio.length > longestLengthFoundYet)
			{
				longestLengthFoundYet = audio.length;
			}
		}

		return longestLengthFoundYet;
	}
}