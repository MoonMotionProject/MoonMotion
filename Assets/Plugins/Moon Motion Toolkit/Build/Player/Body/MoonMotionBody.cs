using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moon Motion Body:
// • singleton for the Moon Motion Body
// • provides properties for the Moon Motion Body
// #moonmotion
public class MoonMotionBody : SingletonBehaviour<MoonMotionBody>
{
	public static Vector3 displacementToPlayer => displacementTo<MoonMotionPlayer>();
	public static Vector3 displacementFromPlayer => displacementFrom<MoonMotionPlayer>();
}