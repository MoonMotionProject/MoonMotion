using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Color Extensions: provides extension methods for handling colors //
public static class ColorExtensions
{
	#region setting color

	// method: set the color of this given material to the given target color, then return this given material //
	public static Material setColorTo(this Material material, Color targetColor)
		=> material.after(()=>
			material.color = targetColor);
	// method: set the color of this given renderer's material to the given target color, then return this given renderer //
	public static Renderer setColorTo(this Renderer renderer, Color targetColor)
		=> renderer.after(()=>
			renderer.material.setColorTo(targetColor));
	// method: set the color of this given component's renderer's material to the given target color, then return this given component //
	public static Component setColorTo(this Component component, Color targetColor)
		=> component.after(()=>
			component.first<Renderer>().setColorTo(targetColor));
	// method: set the color of this given game object's renderer's material to the given target color, then return this given game object //
	public static GameObject setColorTo(this GameObject gameObject, Color targetColor)
		=> gameObject.after(()=>
			gameObject.transform.setColorTo(targetColor));

	// method: set the color of these given renderers' materials to the given target color, then return an enumerable of these given renderers //
	public static IEnumerable<Renderer> setColorTo(this IEnumerable<Renderer> renderers, Color targetColor)
		=> renderers.forEach(renderer => renderer.setColorTo(targetColor));

	// method: set the color of this given game object's child renderers' to the given target color, then return this given game object //
	public static GameObject setChildrenColorTo(this GameObject gameObject, Color targetColor)
		=> gameObject.after(()=>
			gameObject.children<Renderer>().setColorTo(targetColor));
	#endregion setting color
	

	#region randomizing color

	// method: set the color of this given material to a random color, then return this given material //
	public static Material randomizeColor(this Material material)
		=> material.setColorTo(SomeRandom.color);
	#endregion randomizing color


	#region setting a given color variable by name
	// method: set the color variable for the given name of this given material to the given target color, then return this given material //
	public static Material setColor(this Material material, string colorName, Color targetColor)
		=> material.after(()=>
			material.SetColor(colorName, targetColor));
	// method: set the color variable for the given name of this given renderer's material to the given target color, then return this given renderer //
	public static Renderer setColor(this Renderer renderer, string colorName, Color targetColor)
		=> renderer.after(()=>
			renderer.material.setColor(colorName, targetColor));
	// method: set the color variable for the given name of these given renderers' materials to the given target color, then return an enumerable of these given renderers //
	public static IEnumerable<Renderer> setColors(this IEnumerable<Renderer> renderers, string colorName, Color targetColor)
		=> renderers.forEach(renderer => renderer.setColor(colorName, targetColor));
	// method: set the color variable for the given name of this given component's renderer's material to the given target color, then return this given component //
	public static Component setColor(this Component component, string colorName, Color targetColor)
		=> component.after(()=>
			component.first<Renderer>().setColor(colorName, targetColor));
	// method: set the color variable for the given name of this given game object's renderer's material to the given target color, then return this given game object //
	public static GameObject setColor(this GameObject gameObject, string colorName, Color targetColor)
		=> gameObject.after(()=>
			gameObject.transform.setColor(colorName, targetColor));
	#endregion setting a given color variable by name


	#region setting emission color
	// method: set the emission color of this given material to the given target color, then return this given material //
	public static Material setEmissionColorTo(this Material material, Color targetColor)
		=> material.setColor("_EmissionColor", targetColor);
	// method: set the emission color of this given renderer's material to the given target color, then return this given renderer //
	public static Renderer setEmissionColorTo(this Renderer renderer, Color targetColor)
		=> renderer.after(()=>
			renderer.material.setEmissionColorTo(targetColor));
	// method: set the emission color of these given renderers' materials to the given target color, then return an enumerable of these given renderers //
	public static IEnumerable<Renderer> setEmissionColorTo(this IEnumerable<Renderer> renderers, Color targetColor)
		=> renderers.forEach(renderer => renderer.setEmissionColorTo(targetColor));
	// method: set the emission color of this given component's renderer's material to the given target color, then return this given component //
	public static Component setEmissionColorTo(this Component component, Color targetColor)
		=> component.after(()=>
			component.first<Renderer>().setEmissionColorTo(targetColor));
	// method: set the emission color of this given game object's renderer's material to the given target color, then return this given game object //
	public static GameObject setEmissionColorTo(this GameObject gameObject, Color targetColor)
		=> gameObject.after(()=>
			gameObject.transform.setEmissionColorTo(targetColor));
	// method: (according to the given boolean:) set the emission color of this given game object's child renderers' to the given target color, then return this given game object //
	public static GameObject setChildrenEmissionColorTo(this GameObject gameObject, Color targetColor, bool boolean = true)
		=> gameObject.after(()=>
			gameObject.children<Renderer>().setEmissionColorTo(targetColor),
			boolean);
	#endregion setting emission color



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