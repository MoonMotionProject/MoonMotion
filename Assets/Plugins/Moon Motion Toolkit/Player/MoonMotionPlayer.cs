using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Moon Motion Player:
// • singleton for the Moon Motion Player
// • requires the Moon Motion Player to track collideds
// • provides methods for the Moon Motion Player
[RequireComponent(typeof(TrackCollideds))]
public class MoonMotionPlayer : SingletonBehaviour<MoonMotionPlayer>
{
	// methods //

	
	public static Vector3 displacementForSettingBodyPositionTo(Vector3 targetPosition)
		=> MoonMotionBody.displacementTo(targetPosition);

	public static Vector3 positionForSettingBodyPositionTo(object targetPosition_PositionProvider)
		=> position + displacementForSettingBodyPositionTo(targetPosition_PositionProvider.providePosition());

	public static void setPositionForSettingBodyPositionTo(object targetPosition_PositionProvider)
		=> displacePositionBy(displacementForSettingBodyPositionTo(targetPosition_PositionProvider.providePosition()));
}