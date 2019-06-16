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
}