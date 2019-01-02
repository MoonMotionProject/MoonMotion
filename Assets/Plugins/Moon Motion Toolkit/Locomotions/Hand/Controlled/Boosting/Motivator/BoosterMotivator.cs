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
public class BoosterMotivator : MonoBehaviour
{
	// variables //
	
	
	// variables for: instancing //
	public static BoosterMotivator singleton;		// connection - automatic: the singleton instance of this class
	
	// variables for: booster motivating //
	[Header("Enablement")]
	public bool motivating = false;		// setting: whether this motivator is currently enabled
	[Tooltip("the dependencies combination by which to condition whether this booster motivator plays")]
	public Dependencies.DependenciesCombination dependencies;		// setting: the dependencies combination by which to condition whether this booster motivator plays
	private AudioSource audioComponent;		// connection - automatic: the attached booster motivating audio source
	[Header("Audio")]
	[Tooltip("whether the audio volume is allowed to be increased")]
	public bool audioIncreasingEnabled = true;		// setting: whether the audio volume is allowed to be increased
	public float volumeMin = 0f;		// setting: the min volume
	public float volumeMax = .4f;		// setting: the max volume
	public float volumeIncrement = .002f;		// setting: the volume increment
	[Tooltip("whether to restart the audio when its volume is increased from 0")]
	public bool audioRestartsUponNonzeroing = true;		// setting: whether to restart the audio when its volume is increased from 0
	[Header("Aesthetics Cycling")]
	[Tooltip("whether to cycle both boosters' aesthetics while playing the audio")]
	public bool aestheticsCycling = true;		// setting: whether to cycle both boosters' aesthetics while playing the audio
	[Tooltip("the time interval to wait between each aesthetics cycling")]
	public float aestheticsCyclingInterval = .1f;		// setting: the time interval to wait between each aesthetics cycling
	private float timeOfLastAestheticsCycling = -Mathf.Infinity;		// tracking: the time of the last aesthetics cycling – initialized to negative infinity as a flag that the aesthetics have never been cycled
	[Header("Vision Coloring")]
	[Tooltip("whether to fade the color of the player's vision while playing the audio")]
	public bool visionColoring = true;		// setting: whether to fade the color of the player's vision while playing the audio
	[Tooltip("the array of colors to color the player's vision from (either randomly or sequentially, depending on the that setting) – if empty, the colors used will be randomized in general")]
	public Color[] colors = new Color[] {};		// setting: the array of colors to color the player's vision from (either randomly or sequentially, depending on the that setting) – if empty, the colors used will be randomized in general
	[Tooltip("whether the colors to color the player's vision by should be used in order (versus randomly) /* going in order currently only somewhat works, for reasons unknown */")]
	public bool colorsGoInOrder = false;		// setting: whether the colors to color the player's vision by should be used in order (versus randomly) /* going in order currently only somewhat works, for reasons unknown */
	private int colorIndex = 0;		// tracking: the current index to use of the colors array (if it is even being used)
	[Tooltip("the opacity by which to color the player's vision when randomizing a color instead of drawing from the array setting")]
	public float randomVisionColoringOpacity = .01f;		// setting: the opacity by which to color the player's vision when randomizing a color instead of drawing from the array setting
	[Tooltip("the time interval to wait between each color fading of the player's vision")]
	public float fadingInterval = .1f;		// setting: the time interval to wait between each color fading of the player's vision
	private float timeOfLastFade = -Mathf.Infinity;		// tracking: the time of the last color fading – initialized to negative infinity as a flag that it has never faded
	[Tooltip("the duration by which to fade the color of the player's vision (each time it fades to a different color)")]
	public float fadingDuration = .2f;		// setting: the duration by which to fade the color of the player's vision (each time it fades to a different color)




	// updating //

	
	// method: toggle whether this booster motivator is enabled (but it will still depend on the set dependencies) //
	public void toggleEnablement_()
	{
		motivating = !motivating;
	}
	// method: toggle whether the booster motivator is enabled (but it will still depend on the set dependencies) //
	public static void toggleEnablement()
	{
		singleton.toggleEnablement_();
	}
	
	
	
	
	// updating //

	
	// before the start: //
	private void Awake()
	{
		// connect to the singleton instance of this class //
		singleton = this;

		// connect to the attached booster motivating audio source //
		audioComponent = GetComponent<AudioSource>();
	}

	// at each update: //
	private void Update()
	{
		// for being enabled: adjusting volume and time, aesthetics cycling, vision coloring //
		if (motivating && Dependencies.metFor(dependencies))
		{
			float maxVolumeToUse = (audioIncreasingEnabled ? volumeMax : volumeMin);

			if (maxVolumeToUse >= 0f)
			{
				if (audioRestartsUponNonzeroing && (audioComponent.volume == 0f))
				{
					audioComponent.time = 0f;
				}

				audioComponent.volume = Mathf.Max(volumeMin, Honing.hone(audioComponent.volume, maxVolumeToUse, volumeIncrement));

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
					Color colorToFadeTo = ((colors.Length > 0) ? (colorsGoInOrder ? colors[colorIndex] : colors[Random.Range(0, colors.Length)]) : Random.ColorHSV(0f, 1f, 1f, 1f, 0f, 1f, randomVisionColoringOpacity, randomVisionColoringOpacity));

					if ((Time.time - timeOfLastFade) > fadingInterval)
					{
						SteamVR_Fade.Start(colorToFadeTo, fadingDuration);

						timeOfLastFade = Time.time;
					}

					if ((colors.Length > 0) && colorsGoInOrder)
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
			audioComponent.volume = Mathf.Min(volumeMax, Honing.hone(audioComponent.volume, volumeMin, volumeIncrement));
			
			SteamVR_Fade.Start(new Color(0f, 0f, 0f, 0f), fadingDuration);
		}
	}
}