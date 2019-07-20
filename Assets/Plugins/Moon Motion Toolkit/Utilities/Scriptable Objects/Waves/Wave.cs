using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Wave:
// • represents a wave (the generic abstract mathematical waveform concept) as a scriptable object
[CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
	// constants //

	
	// constants for: sine //
	
	public const float troughSine = -1f;
	public const float crestSine = 1f;
	public const float durationSine = 1f;
	public const float durationalOffsetSine = 0f;


	// constants for: default //

	public const float troughDefault = troughSine;
	public const float crestDefault = crestSine;
	public const float durationDefault = durationSine;
	public const float durationalOffsetDefault = durationalOffsetSine;




	// variables //


	// settings //

	public float trough = troughDefault;
	public float crest = crestDefault;
	public float duration = durationDefault;
	public float durationalOffset = durationalOffsetDefault;




	// methods //


	public float at(float progression)
		=> progression.waved(trough, crest, duration, durationalOffset);
}