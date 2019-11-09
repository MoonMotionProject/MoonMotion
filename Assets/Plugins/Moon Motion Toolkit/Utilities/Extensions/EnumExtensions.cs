using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enum Extensions: provides extension methods for handling enums //
public static class EnumExtensions
{
	#region determining flags
	
	// method: return whether this given enum has the given flag //
	public static bool has(this Enum enum_, Enum flag)
		=> enum_.HasFlag(flag);

	// method: return whether this given enum does not have the given flag //
	public static bool doesNotHave(this Enum enum_, Enum flag)
		=> !enum_.has(flag);
	#endregion determining flags
}