using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ScalingExtensions: provides extension methods for handling scaling //
public static class ScalingExtensions
{
	// method: return whether this given scale is a valid scale //
	public static bool validScale(this Vector3 scale)
		=> scale.isFinite() && scale.isNonnegative();

	// method: return this given vector clamped to be a valid scale //
	public static Vector3 clampedToBeValidScale(this Vector3 scale)
		=> scale.clampedFiniteAndNonnegative();
}