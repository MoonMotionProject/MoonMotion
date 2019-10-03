using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Honing Extensions: provides extension methods for calculating given original values honed to given target values by given honing amounts //
public static class HoningExtensions
{
	// method: return this given original float honed to the given target value by the given honing amount //
	public static float honed(this float float_, float target, float honingAmount)
	{
		if (honingAmount.isZero())
		{
			return float_;
		}
		else
		{
			float targetDistance = target.distanceWith(float_);
			if (targetDistance < honingAmount)
			{
				honingAmount *= (targetDistance / honingAmount.magnitude());
			}

			if (honingAmount.isZero())
			{
				return float_;
			}

			honingAmount = honingAmount.timesSign(target > float_);

			return (float_ + honingAmount);
		}
	}
	
	// method: return this given vector honed to the given target vector by the respective given honing amounts //
	public static Vector3 honed(this Vector3 vector, Vector3 targetVector, Vector3 honingAmounts)
		=> new Vector3
		(
			vector.x.honed(targetVector.x, honingAmounts.x),
			vector.y.honed(targetVector.y, honingAmounts.y),
			vector.z.honed(targetVector.z, honingAmounts.z)
		);
	// method: return this given vector honed to the given target vector by the given honing amount //
	public static Vector3 honed(this Vector3 vector, Vector3 targetVector, float honingAmount)
		=> vector.honed(targetVector, honingAmount.asVector());
}