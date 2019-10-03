using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hovering
// • oscillates this object's local position vertically
//   · does this by constantly setting the object's local position y coordinate to its starting local position y coordinate modified by a sine calculation using the current time, and based on the oscillation settings
//     - the object's starting position y coordinate is tracked at the start
//   · settings are provided for:
//     - the oscillation radius
//     - the frequency factor
//     - an amount by which to offset the current time used in the oscillation calculation (so as to allow for multiple instances of Hovering not necessarily being in sync)
// #transform #transformations
[CacheTransform] [RequireComponent(typeof(TrackLocalPositionYAtAwake))]
public class Hovering : AutoBehaviour<Hovering>
{
	// variables //

	
	// variables for: oscillation waveform //
	[Header("Oscillation Waveform")]
	[Tooltip("the distance radius by which to oscillate the object vertically")]
	public float radius = .05f;		// setting: the distance radius by which to oscillate the object vertically
	[Tooltip("the frequency factor by which to oscillate the object vertically")]
	public float frequencyFactor = 1f;		// setting: the frequency factor by which to oscillate the object vertically
	[Tooltip("an amount by which to offset the current time used in the oscillation calculation (so as to allow for multiple instances of Hovering not necessarily being in sync); changing this has no effect after the start")]

	// variables for: oscillation time offsetting //
	[Header("Oscillation Time Offsetting")]
	public float timeOffset = 0f;		// setting: an amount by which to offset the current time used in the oscillation calculation (so as to allow for multiple instances of Hovering not necessarily being in sync); changing this has no effect after the start
	[Tooltip("the min amount by which to offset the current time (as used in the oscillation calculation, so as to allow for multiple instances of Hovering not necessarily being in sync); changing this has no effect after the start")]
	public float randomTimeOffsetMin = 0f;		// setting: the min amount by which to offset the current time (as used in the oscillation calculation, so as to allow for multiple instances of Hovering not necessarily being in sync); changing this has no effect after the start
	[Tooltip("the max amount by which to offset the current time (as used in the oscillation calculation, so as to allow for multiple instances of Hovering not necessarily being in sync); changing this has no effect after the start")]
	public float randomTimeOffsetMax = 0f;		// setting: the max amount by which to offset the current time (as used in the oscillation calculation, so as to allow for multiple instances of Hovering not necessarily being in sync); changing this has no effect after the start
	private float totalTimeOffset = 0f;		// tracking: the total time offset calculated by summing the time offset setting with the randomized time offset (that in turn is based on the random time offset settings)




	// updating //

	
	// at the start: //
	private void Start()
	{
		// calculate the total time offset //
		totalTimeOffset = timeOffset + RandomlyGenerate.within(randomTimeOffsetMin, randomTimeOffsetMax);
	}

	// at each update: //
	private void Update()
	{
		// set the object's local position y coordinate to its starting local position y coordinate modified by a sine calculation using the current time offset by the total time offset, all based on the oscillation settings //
		setLocalPositionYTo(localPositionYAwake + (radius * Mathf.Sin((Time.time + totalTimeOffset) * frequencyFactor)));
	}
}