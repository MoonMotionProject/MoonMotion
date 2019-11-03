using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Colors:
// • provides color properties and methods
// #default
public static class Colors
{
	#region properties


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
	#region editor
	public static Color inspectorTextPlay => new Color32(133, 161, 135, 255);
	#endregion editor
	public static Color silver => new Color32(211, 211, 211, 255);
	public static Color khaki => new Color32(240, 230, 140, 255);
	public static Color orange => new Color32(255, 165, 0, 255);
	public static Color brown => new Color32(165, 42, 42, 255);
	public static Color purple => new Color32(143, 0, 254, 255);
	public static Color forestGreen => new Color32(34, 139, 34, 255);
	public static Color lycan => new Color32(79, 244, 162, 255);
	public static Color charm => new Color32(219, 112, 147, 255);
	public static Color goldenrod => new Color32(218, 165, 32, 255);
	public static Color dodgerBlue => new Color32(30, 144, 255, 255);
	public static Color bittersweetRed => new Color32(255, 102, 102, 255);
	public static Color mediumRed => new Color32(255, 51, 51, 255);
	#endregion provided here
	#endregion basic
	
	#region Unitology
	#if UNITOLOGY
	public static readonly Color healthbarLow = red;
	public static readonly Color healthbarHigh = green;
	public static readonly Color healthbarTrop = lycan;
	public static readonly Color healthbarShielding = silver;
	public static readonly Color statusSilence = purple;
	public static readonly Color abilityPending = orange;
	public static readonly Color abilityChanneling = dodgerBlue;
	public static readonly Color abilityCooling = charm;
	public static readonly Color abilityCastingSoUnready = goldenrod;
	public static readonly Color damage = mediumRed;
	#endif
	#endregion Unitology
	#endregion properties




	#region methods

	
	// method: return this given color if the given boolean is true; otherwise, return white – but if the given 'considerInspectorTextPlay' boolean is true, return the inspector text play color instead of white if playing in the editor //
	public static Color insteadOfWhiteIf(this Color color, bool boolean, bool considerInspectorTextPlay = true)
		=>	boolean ?
				color :
				considerInspectorTextPlay && UnityIs.inEditorPlayMode ?
					inspectorTextPlay :
					white;
	#endregion methods
}