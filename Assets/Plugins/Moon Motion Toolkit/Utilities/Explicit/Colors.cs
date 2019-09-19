using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Colors: provides color properties //
public static class Colors
{
	#region provided by Unity's Color class
	public static Color cyan => Color.cyan;
	public static Color green => Color.green;
	public static Color red => Color.red;
	public static Color black => Color.black;
	public static Color yellow => Color.yellow;
	public static Color blue => Color.blue;
	public static Color magenta => Color.magenta;
	public static Color gray => Color.gray;
	public static Color white => Color.white;
	public static Color clear => Color.clear;
	public static Color grey => Color.grey;
	#endregion provided by Unity's Color class

	#region provided here
	public static Color purple => new Color(143f, 0f, 254f);
	#endregion provided here
}