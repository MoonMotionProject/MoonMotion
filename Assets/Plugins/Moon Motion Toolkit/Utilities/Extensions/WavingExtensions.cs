using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Waving Extensions: provides extension methods for waving //
public static class WavingExtensions
{
	public static float sined(this float float_, float duration = Wave.durationDefault)
		=> Mathf.Sin((float_ / duration).doubled().timesPi());

	public static float wavedRatio(this float float_, float duration = Wave.durationDefault, float durationalOffset = Wave.durationalOffsetDefault)
		=> (float_ + (durationalOffset * duration)).sined(duration).progressionWithin(Wave.troughSine, Wave.crestSine);

	public static float waved(this float float_, float trough = Wave.troughDefault, float crest = Wave.crestDefault, float duration = Wave.durationDefault, float durationalOffset = Wave.durationalOffsetDefault)
		=> float_.wavedRatio(duration, Wave.durationalOffsetDefault).lerpedClampingly(trough, crest);
	
	public static float waved(this float float_, Vector2 range, float duration = Wave.durationDefault, float durationalOffset = Wave.durationalOffsetDefault)
		=> float_.waved(range.x, range.y, duration, durationalOffset);

	public static float waved(this float float_, Wave wave)
		=> wave.at(float_);

	public static float cosined(this float float_, float duration = Wave.durationDefault)
		=> float_.waved(durationalOffset: .25f);
}