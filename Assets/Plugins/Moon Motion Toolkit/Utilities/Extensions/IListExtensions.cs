using System;
using System.Collections.Generic;
using UnityEngine;

// IListExtensions: provides extension methods for handling ILists //
public static class IListExtensions
{
	#region conversion

	// method: return the list of doubles for these given floats //
	public static List<double> asDoubles(this IList<float> floats)
		=> floats.pick(float_ => float_.asDouble());

	// method: return the list of floats nearest to these given doubles //
	public static List<float> toFloats(this IList<double> doubles)
		=> doubles.pick(double_ => double_.toFloat());
	#endregion conversion
}