using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Motivator
// • plays a rave, mainly by playing boosting motivating audio, according to whether both an enabled toggle and a dependencies setting are met
// • also provides settings for:
//   · adjusting audio volume 
//   · whether to restart time upon increasing volume from zero
//   · aesthetics cycling
//   · vision coloring
// • a method is provided for toggling this booster motivator's enablement
public class BoosterMotivator : SingletonBehaviour<BoosterMotivator>
{
	// variables //
	
	
	// settings for: enablement //

	[BoxGroup("Enablement")]
	[Tooltip("whether this motivator is currently enabled")]
	public bool motivating = false;

	[BoxGroup("Enablement")]
	[Tooltip("the dependencies by which to condition whether this booster motivator plays")]
	[ReorderableList]
	public Dependency[] dependencies;


	// settings for: audio //

	[BoxGroup("Audio")]
	[Tooltip("whether the audio volume is allowed to be increased")]
	public bool audioIncreasingEnabled = true;

	[BoxGroup("Audio")]
	[Range(0f, 1f)]
	public float volumeMin = 0f;

	[BoxGroup("Audio")]
	[Range(0f, 1f)]
	public float volumeMax = .4f;

	[BoxGroup("Audio")]
	[Range(0f, 1f)]
	public float volumeIncrement = .002f;

	[BoxGroup("Audio")]
	[Tooltip("whether to restart the audio when its volume is increased from 0")]
	public bool audioRestartsUponNonzeroing = true;


	// variables for: aesthetics cycling //

	[BoxGroup("Aesthetics Cycling")]
	[Tooltip("whether to cycle both boosters' aesthetics while playing the audio")]
	public bool aestheticsCycling = true;

	[BoxGroup("Aesthetics Cycling")]
	[Tooltip("the time interval to wait between each aesthetics cycling")]
	public float aestheticsCyclingInterval = .1f;

	[Tooltip("the time of the last aesthetics cycling – initialized to negative infinity as a flag that the aesthetics have never been cycled")]
	private float timeOfLastAestheticsCycling = -Mathf.Infinity;


	// variables for: vision coloring //

	[BoxGroup("Vision Coloring")]
	[Tooltip("whether to fade the color of the player's vision while playing the audio")]
	public bool visionColoring = true;

	[BoxGroup("Vision Coloring")]
	[Tooltip("the array of colors to color the player's vision from (either randomly or sequentially, depending on the that setting) – if empty, the colors used will be randomized in general")]
	[ReorderableList]
	public Color[] colors = new Color[] {};

	[BoxGroup("Vision Coloring")]
	[Tooltip("whether the colors to color the player's vision by should be used in order (versus randomly) /* going in order currently only somewhat works, for reasons unknown */")]
	public bool colorsGoInOrder = false;

	[BoxGroup("Vision Coloring")]
	[Tooltip("the current index to use of the colors array (if it is even being used)")]
	private int colorIndex = 0;

	[BoxGroup("Vision Coloring")]
	[Tooltip("the opacity by which to color the player's vision when randomizing a color instead of drawing from the array setting")]
	[Range(0f, 1f)]
	public float randomVisionColoringOpacity = .01f;

	[BoxGroup("Vision Coloring")]
	[Tooltip("the time interval to wait between each color fading of the player's vision")]
	public float fadingInterval = .1f;

	[Tooltip("the time of the last color fading – initialized to negative infinity as a flag that it has never faded")]
	private float timeOfLastFade = -Mathf.Infinity;

	[BoxGroup("Vision Coloring")]
	[Tooltip("the duration by which to fade the color of the player's vision (each time it fades to a different color)")]
	public float fadingDuration = .2f;




	// updating //

	
	// method: toggle whether this booster motivator is enabled (but it will still depend on the set dependencies) //
	public void toggleEnablement_()
		=> motivating = motivating.toggled();
	// method: toggle whether the booster motivator is enabled (but it will still depend on the set dependencies) //
	public static void toggleEnablement()
		=> singleton.toggleEnablement_();




	// updating //


	// at each update: //
	private void Update()
	{
		// for being enabled: adjusting volume and time, aesthetics cycling, vision coloring //
		if (motivating && dependencies.areMet())
		{
			float maxVolumeToUse = (audioIncreasingEnabled ? volumeMax : volumeMin);

			if (maxVolumeToUse >= 0f)
			{
				if (audioRestartsUponNonzeroing && (audioSource.volume == 0f))
				{
					setAudioTimeTo(0f);
				}

				audioSource.volume = Mathf.Max(volumeMin, audioSource.volume.honed(maxVolumeToUse, volumeIncrement));

				if (aestheticsCycling)
				{
					if ((Time.time - timeOfLastAestheticsCycling) > aestheticsCyclingInterval)
					{
						BoosterAestheticsSetCycler.advanceCycleGlobally(false);

						timeOfLastAestheticsCycling = Time.time;
					}
				}

				if (visionColoring)
				{
					Color colorToFadeTo = ((Any.itemsIn(colors)) ? (colorsGoInOrder ? colors[colorIndex] : colors[Random.Range(0, colors.Length)]) : Random.ColorHSV(0f, 1f, 1f, 1f, 0f, 1f, randomVisionColoringOpacity, randomVisionColoringOpacity));

					if ((Time.time - timeOfLastFade) > fadingInterval)
					{
						SteamVR_Fade.Start(colorToFadeTo, fadingDuration);

						timeOfLastFade = Time.time;
					}

					if (Any.itemsIn(colors) && colorsGoInOrder)
					{
						colorIndex++;
						if (colorIndex >= colors.Length)
						{
							colorIndex = 0;
						}
					}
				}
			}
		}
		// for not being enabled: adjusting volume, vision coloring //
		else
		{
			audioSource.volume = Mathf.Min(volumeMax, audioSource.volume.honed(volumeMin, volumeIncrement));
			
			SteamVR_Fade.Start(new Color(0f, 0f, 0f, 0f), fadingDuration);
		}
	}
}