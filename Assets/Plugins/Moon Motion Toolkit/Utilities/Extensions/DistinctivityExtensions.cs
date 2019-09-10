using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Distinctivity Extensions: provides extension methods for handling distinctivity //
public static class DistinctivityExtensions
{
	#region determination
	
	// method: return whether this given distinctivity is absolute //
	public static bool isAbsolute(this Distinctivity distinctivity)
		=> distinctivity == Distinctivity.absolute;

	// method: return whether this given distinctivity is relative //
	public static bool isRelative(this Distinctivity distinctivity)
		=> distinctivity == Distinctivity.relative;
	#endregion determination
}