using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Doubles: provides methods for handling doubles //
public static class Doubles
{
	#region extremes

	// method: return the max value of these two given doubles //
	public static double maxOf(double firstDouble, double secondDouble)
		=> Math.Max(firstDouble, secondDouble);

	// method: return the min value of these two given doubles //
	public static double minOf(double firstDouble, double secondDouble)
		=> Math.Min(firstDouble, secondDouble);
	#endregion extremes
}