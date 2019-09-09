using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Waving Extensions: provides extension methods for waving //
public static class WavingExtensions
{
	public static float sined(this float float_, float duration = Default.waveDuration)
		=> Mathf.Sin((float_ / duration).doubled().timesPi());

	public static float wavedRatio(this float float_, float duration = Default.waveDuration, float durationalOffset = Default.waveDurationalOffset)
		=> (float_ + (durationalOffset * duration)).sined(duration).progressionWithin(Wave.troughSine, Wave.crestSine);

	public static float waved(this float float_, float trough = Default.waveTrough, float crest = Default.waveCrest, float duration = Default.waveDuration, float durationalOffset = Default.waveDurationalOffset)
		=> float_.wavedRatio(duration, Default.waveDurationalOffset).lerpedClampingly(trough, crest);
	
	public static float waved(this float float_, Vector2 range, float duration = Default.waveDuration, float durationalOffset = Default.waveDurationalOffset)
		=> float_.waved(range.x, range.y, duration, durationalOffset);

	public static float waved(this float float_, Wave wave)
		=> wave.at(float_);

	public static float cosined(this float float_, float duration = Default.waveDuration)
		=> float_.waved(durationalOffset: .25f);
}