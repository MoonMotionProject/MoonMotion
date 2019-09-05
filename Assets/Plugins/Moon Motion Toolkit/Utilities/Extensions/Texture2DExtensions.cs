using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Texture 2D Extensions: provides extension methods for handling 2D textures //
public static class Texture2DExtensions
{
	// method: set the name of this given 2D texture to the given name, then return this given 2D texture //
	public static Texture2D setNameTo(this Texture2D texture2D, string name)
		=> texture2D.after(()=>
			texture2D.name = name);

	// method: make this given 2D texture temporary (set it to be hidden and to not save), then return this given 2D texture //
	public static Texture2D makeTemporary(this Texture2D texture2D)
		=> texture2D.after(()=>
			texture2D.hideFlags = HideFlags.HideAndDontSave);

	// method: apply the given colors as pixels to this given 2D texture, using the given texture wrapping mode, then return this given 2D texture //
	public static Texture2D applyPixels(this Texture2D texture2D, Color[] colors, TextureWrapMode textureWrapMode = TextureWrapMode.Clamp)
		=>	texture2D.after(()=>
			{
				texture2D.SetPixels(colors);
				texture2D.wrapMode = textureWrapMode;
				texture2D.Apply();
			});

	// method: return a temporary 2D texture for these given colors as pixels, for the given width and height, using the given texture wrapping mode //
	public static Texture2D as2DTextureTemporary(this Color[] colors, int width, int height, TextureWrapMode textureWrapMode = TextureWrapMode.Clamp)
	{
		return new Texture2D(width, height, TextureFormat.ARGB32, false)
			.setNameTo("temporary texture")
			.makeTemporary()
			.applyPixels(colors, textureWrapMode);
	}
}