using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Honing Extensions: provides extension methods for calculating given original values honed to given target values by given honing amounts //
public static class HoningExtensions
{
	// method: return this given original float honed to the given target value by the given honing amount //
	public static float honedTo(this float float_, float target, float honingAmount)
	{
		if (honingAmount.isZero())
		{
			return float_;
		}
		else
		{
			honingAmount = honingAmount.atMost(target.distanceWith(float_));

			if (honingAmount.isZero())
			{
				return float_;
			}

			honingAmount = honingAmount.timesSign(target > float_);

			return float_ + honingAmount;
		}
	}
	
	// method: return this given vector honed to the given target vector by the given honing vector //
	public static Vector3 honedTo(this Vector3 vector, Vector3 targetVector, Vector3 honingVector)
		=> new Vector3
		(
			vector.x.honedTo(targetVector.x, honingVector.x),
			vector.y.honedTo(targetVector.y, honingVector.y),
			vector.z.honedTo(targetVector.z, honingVector.z)
		);
	// method: return this given vector honed to the given target vector by the given honing vectral and honing magnitude //
	public static Vector3 honedTo(this Vector3 vector, Vector3 targetVector, Vector3 honingVectral, float honingMagnitude)
		=> vector.honedTo(targetVector, honingVectral * honingMagnitude);
	// method: return this given vector honed to the given target vector by the given honing magnitude //
	public static Vector3 honedTo(this Vector3 vector, Vector3 targetVector, float honingMagnitude)
		=> vector.honedTo(targetVector, vector.directudeWith(targetVector), honingMagnitude);
}