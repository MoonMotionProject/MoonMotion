using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Moon Motion Player:
// • singleton for the Moon Motion Player
// • provides methods for the Moon Motion Player
public class MoonMotionPlayer : SingletonBehaviour<MoonMotionPlayer>
{
	// methods //

	
	public static void setPositionForMovingBodyPositionTo(Vector3 targetPosition)
		=> displacePositionBy(MoonMotionBody.displacementForMovingPositionTo(targetPosition));
	public static void setPositionForMovingBodyPositionTo(RaycastHit raycastHit)
		=> setPositionForMovingBodyPositionTo(raycastHit.position());
}