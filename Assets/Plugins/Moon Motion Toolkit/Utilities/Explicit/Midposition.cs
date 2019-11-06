using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Midposition:
// • provides methods for handling midpositions
// #midpositions
public static class Midposition
{
	// method: return the midposition (middle position between) the two given provided positions //
	public static Vector3 between(object position_PositionProvider, object otherPosition_PositionProvider)
	{
		Vector3 position = position_PositionProvider.providePosition();
		Vector3 otherPosition = otherPosition_PositionProvider.providePosition();

		return position.withDisplacement(position.displacementTo(otherPosition).halved());
	}
}