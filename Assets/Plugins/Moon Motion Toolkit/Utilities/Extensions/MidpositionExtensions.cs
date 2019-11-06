using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Midposition Extensions:
// • provides extension methods for handling midpositions
// #midpositions
public static class MidpositionExtensions
{
	// method: return the midposition (middle position between) the two given provided positions //
	public static Vector3 midpositionWith(this object position_PositionProvider, object otherPosition_PositionProvider)
		=> Midposition.between(position_PositionProvider, otherPosition_PositionProvider);
}