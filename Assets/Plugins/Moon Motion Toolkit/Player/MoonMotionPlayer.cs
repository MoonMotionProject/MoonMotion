using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[RequireComponent(typeof(TrackCollideds))]

// Moon Motion Player:
// • singleton for the Moon Motion Player
// • requires the Moon Motion Player to track collideds
// • provides properties and methods for the Moon Motion Player
// #moonmotion
[ExpandIfSelected]
public class MoonMotionPlayer : SingletonBehaviour<MoonMotionPlayer>
{
	public static Vector3 displacementForSettingBodyPositionTo(object targetPosition_PositionProvider)
		=> MoonMotionBody.displacementTo(targetPosition_PositionProvider.providePosition());

	public static Vector3 positionForSettingBodyPositionTo(object targetPosition_PositionProvider)
		=> position + displacementForSettingBodyPositionTo(targetPosition_PositionProvider);

	public static void setPositionForSettingBodyPositionTo(object targetPosition_PositionProvider)
		=> displacePositionBy(displacementForSettingBodyPositionTo(targetPosition_PositionProvider));

	public static Vector3 displacementToBody => displacementTo<MoonMotionBody>();
	public static Vector3 displacementFromBody => displacementFrom<MoonMotionBody>();
}