using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Colors: provides color properties //
public static class Colors
{
	#region basic

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
	public static Color silver => new Color32(211, 211, 211, 255);
	public static Color khaki => new Color32(240, 230, 140, 255);
	public static Color brown => new Color32(165, 42, 42, 255);
	public static Color purple => new Color32(143, 0, 254, 255);
	public static Color forestGreen => new Color32(34, 139, 34, 255);
	public static Color lycan => new Color32(79, 244, 162, 255);
	#endregion provided here
	#endregion basic
	
	#region Unitology
	#if UNITOLOGY
	public static readonly Color healthbarLow = red;
	public static readonly Color healthbarHigh = green;
	public static readonly Color healthbarTrop = lycan;
	public static readonly Color healthbarShielding = silver;
	#endif
	#endregion Unitology
}