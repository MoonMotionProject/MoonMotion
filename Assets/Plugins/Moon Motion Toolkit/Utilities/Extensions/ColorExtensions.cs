using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ColorExtensions: provides extension methods for handling colors //
public static class ColorExtensions
{
	// method: return the 32-bit color corresponding to this given color //
	public static Color32 as32Bit(this Color color)
		=> color;
	
	// method: return the alpha ratio (from 0 to 1) corresponding to the alpha value of this given 32-bit color //
	public static float alphaRatio(this Color32 color)
		=> (color.a / 255f);

	// method: return this given color with the given alpha ratio //
	public static Color withAlpha(this Color color, float alphaRatio)
	{
		color.a = alphaRatio;
		return color;
	}

	// method: return this given color blended (evenly) with the other given color //
	public static Color blendedWith(this Color color, Color otherColor)
		=> (color + otherColor) / 2f;


	// methods for: interpolation //

	// method: return this given ratio "lerped" (linearly interpolated) along the range from the given start color to the given end color - with clamping //
	public static Color lerpedClampingly(this float ratio, Color start, Color end)
		=> Color.Lerp(start, end, ratio);
}