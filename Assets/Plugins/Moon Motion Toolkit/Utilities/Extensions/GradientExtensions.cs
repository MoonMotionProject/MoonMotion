using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gradient Extensions: provides extension methods for creating gradients //
public static class GradientExtensions
{
	// method: return the horizontal gradient from this given color to the other given color as a temporary 2D texture, with the given width and height (integers) //
	public static Texture2D asHorizontalGradientTo(this Color color, Color otherColor, int width, int height)
		=> new Color[width * height]
			.as2DWithEachSetTo((x, y) =>
				x.progressionUntil(width).lerpedClampingly(color, otherColor),
				width, height)
			.as2DTextureTemporary(width, height);

	// method: return the horizontal gradient from this given color to the other given color as a temporary 2D texture, with the given width and height floats cast to integers //
	public static Texture2D asHorizontalGradientTo(this Color color, Color otherColor, float width, float height)
		=> color.asHorizontalGradientTo(otherColor, (int) width, (int) height);
}