using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Floats: provides methods for handling floats //
public static class Floats
{
	#region extremes

	// method: return the max value of these two given floats //
	public static float maxOf(float firstFloat, float secondFloat)
		=> Mathf.Max(firstFloat, secondFloat);

	// method: return the min value of these two given floats //
	public static float minOf(float firstFloat, float secondFloat)
		=> Mathf.Min(firstFloat, secondFloat);
	#endregion extremes
}