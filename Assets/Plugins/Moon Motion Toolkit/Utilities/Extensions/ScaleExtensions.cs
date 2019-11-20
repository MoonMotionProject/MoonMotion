using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scale Extensions:
// • provides extension methods for handling scales
// #scale #vectors
public static class ScaleExtensions
{
	#region defaultness determination
	
	// method: return whether this given local scale is the default local scale //
	public static bool isDefaultLocalScale(this Vector3 vector)
		=> vector.matches(Default.localScale);
	#endregion defaultness determination
}