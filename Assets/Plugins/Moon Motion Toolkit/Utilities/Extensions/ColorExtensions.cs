using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Color Extensions: provides extension methods for handling colors //
public static class ColorExtensions
{
	#region setting

	// method: set the color of this given material to the given target color, then return this given material //
	public static Material setColorTo(this Material material, Color targetColor)
		=> material.after(()=>
			material.color = targetColor);
	// method: set the color of this given renderer's material to the given target color, then return this given renderer //
	public static Renderer setColorTo(this Renderer renderer, Color targetColor)
		=> renderer.after(()=>
			renderer.material.setColorTo(targetColor));
	// method: set the color of these given renderers' materials to the given target color, then return an enumerable of these given renderers //
	public static IEnumerable<Renderer> setColorsTo(this IEnumerable<Renderer> renderers, Color targetColor)
		=> renderers.forEach(renderer => renderer.setColorTo(targetColor));
	// method: set the color of this given component's renderer's material to the given target color, then return this given component //
	public static Component setColorTo(this Component component, Color targetColor)
		=> component.after(()=>
			component.first<Renderer>().setColorTo(targetColor));
	// method: set the color of this given game object's renderer's material to the given target color, then return this given game object //
	public static GameObject setColorTo(this GameObject gameObject, Color targetColor)
		=> gameObject.after(()=>
			gameObject.transform.setColorTo(targetColor));
	#endregion setting


	#region setting child colors

	// method: set the color of this given game object's child renderers' to the given target color, then return this given game object //
	public static GameObject setChildColorsTo(this GameObject gameObject, Color targetColor)
		=> gameObject.after(()=>
			gameObject.children<Renderer>().setColorsTo(targetColor));
	#endregion setting child colors



	#region alpha

	// method: return the alpha ratio (from 0 to 1) corresponding to the alpha value of this given 32-bit color //
	public static float alphaRatio(this Color32 color)
		=> (color.a / 255f);

	// method: return this given color with the given alpha ratio //
	public static Color withAlpha(this Color color, float alphaRatio)
	{
		color.a = alphaRatio;
		return color;
	}
	#endregion alpha


	#region blending

	// method: return this given color blended (evenly) with the other given color //
	public static Color blendedWith(this Color color, Color otherColor)
		=> (color + otherColor) / 2f;
	#endregion blending


	#region interpolation

	// method: return this given ratio "lerped" (linearly interpolated) along the range from the given start color to the given end color - without clamping //
	public static Color lerpedUnclampingly(this float ratio, Color start, Color end)
		=> Color.LerpUnclamped(start, end, ratio);

	// method: return this given ratio "lerped" (linearly interpolated) along the range from the given start color to the given end color - with clamping //
	public static Color lerpedClampingly(this float ratio, Color start, Color end)
		=> Color.Lerp(start, end, ratio);

	// method: return this given ratio "lerped" (linearly interpolated) along the range from the given start color to the given end color - with clamping according to the given 'clamp' boolean //
	public static Color lerped(this float ratio, Color start, Color end, bool clamp)
		=> clamp ? ratio.lerpedClampingly(start, end) : ratio.lerpedUnclampingly(start, end);
	#endregion interpolation


	#region conversion

	// method: return the 32-bit color corresponding to this given color //
	public static Color32 as32Bit(this Color color)
		=> color;
	#endregion conversion
}