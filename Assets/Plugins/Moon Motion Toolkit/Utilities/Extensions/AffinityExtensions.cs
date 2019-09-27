using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Affinity Extensions: provides extension methods for handling affinities //
public static class AffinityExtensions
{
	#region conversion
	
	// method: return the sign for this given affinity //
	public static int asSign(this Affinity affinity)
		=> affinity.castTo<int>().asBoolean().asSign();

	// method: return the opposite sign for this given affinity //
	public static int asOppositeSign(this Affinity affinity)
		=> affinity.asSign().signChanged();
	#endregion conversion
}