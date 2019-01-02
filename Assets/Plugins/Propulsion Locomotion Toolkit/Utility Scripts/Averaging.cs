using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Averaging
// • provides methods for determining averages for the following givens:
//   · an array of decimals
//   · a vector
public static class Averaging
{
	// methods //

	
	// methods for: determining averages //

	// method: determine the average of the given array of decimals //
	public static float average(float[] decimals)
	{
		float sum = 0f;
		foreach (float decimalElement in decimals)
		{
			sum += decimalElement;
		}

		return (sum / decimals.Length);
	}
	// method: determine the average of the given vector //
	public static float average(Vector3 vector)
	{
		float sum = 0f;
		sum = (vector.x + vector.y + vector.z);

		return (sum / 3f);
	}
}