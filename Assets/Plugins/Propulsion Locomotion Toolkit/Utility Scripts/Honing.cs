using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Honing
// • provides methods for calculating a given original value honed to a given target value by a given honing amount, for:
//   · decimals
//   · vectors
public static class Honing
{
	// methods //

	
	// method: hone the given original decimal to the given target decimal by the given honing amount //
	public static float hone(float originalDecimal, float targetDecimal, float honingAmount)
	{
		if (honingAmount == 0f)
		{
			return originalDecimal;
		}
		else
		{
			float targetDistance = Mathf.Abs(targetDecimal - originalDecimal);
			if (targetDistance < honingAmount)
			{
				honingAmount *= (targetDistance / Mathf.Abs(honingAmount));
			}

			if (honingAmount == 0f)
			{
				return originalDecimal;
			}
		
			bool honingDirectionPositive = (targetDecimal > originalDecimal);
			float honingDirectionSign = (honingDirectionPositive ? 1f : -1f);

			honingAmount = honingAmount * honingDirectionSign;

			return (originalDecimal + honingAmount);
		}
	}
	
	// method: hone the given original vector to the given target vector by the given honing amounts //
	public static Vector3 hone(Vector3 originalVector, Vector3 targetVector, Vector3 honingAmounts)
	{
		float newX = hone(originalVector.x, targetVector.x, honingAmounts.x);
		float newY = hone(originalVector.y, targetVector.y, honingAmounts.y);
		float newZ = hone(originalVector.z, targetVector.z, honingAmounts.z);

		return new Vector3(newX, newY, newZ);
	}
	// method: hone the given original vector to the given target vector by the given honing amount //
	public static Vector3 hone(Vector3 originalVector, Vector3 targetVector, float honingAmount)
	{
		return hone(originalVector, targetVector, new Vector3(honingAmount, honingAmount, honingAmount));
	}
}