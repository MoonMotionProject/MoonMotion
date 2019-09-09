using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Wave:
// • represents a wave (the generic abstract mathematical waveform concept) as a scriptable object
[CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
	#region constants
	
	#region sine
	public const float troughSine = -1f;
	public const float crestSine = 1f;
	public const float durationSine = 1f;
	public const float durationalOffsetSine = 0f;
	#endregion sine
	#endregion constants




	#region variables


	#region settings

	public float trough = Default.waveTrough;
	public float crest = Default.waveCrest;
	public float duration = Default.waveDuration;
	public float durationalOffset = Default.waveDurationalOffset;
	#endregion settings
	#endregion variables




	#region methods


	public float at(float progression)
		=> progression.waved(trough, crest, duration, durationalOffset);
	#endregion methods
}