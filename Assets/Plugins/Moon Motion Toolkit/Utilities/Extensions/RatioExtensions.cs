using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ratio Extensions: provides extension methods for calculating ratios (mostly for use with Interpolation Curved) //
public static class RatioExtensions
{
	#region progression

	// method: determine the progression of this given progressor (changing value) from the given start progression to the given end progression //
	public static float progressionWithin(this float progressor, float start, float end)
		=> ((progressor - start) / (end - start));
	// method: determine the progression of this given progressor (changing value) from the given start progression to the given end progression //
	public static double progressionWithin(this double progressor, double start, double end)
		=> ((progressor - start) / (end - start));

	// method: determine the progression of this given progressor (changing value) within the given range //
	public static float progressionWithin(this float progressor, Vector2 range)
		=> progressor.progressionWithin(range.x, range.y);
	// method: determine the progression of this given progressor (changing value) within the given range //
	public static double progressionWithin(this double progressor, DoublesPair range)
		=> progressor.progressionWithin(range.first, range.second);

	// method: determine the progression of this given progressor (changing value) from the given start progression to the end progression (1) //
	public static float progressionFrom(this float progressor, float start)
		=> progressor.progressionWithin(start, 1f);
	// method: determine the progression of this given progressor (changing value) from the given start progression to the end progression (1) //
	public static double progressionFrom(this double progressor, double start)
		=> progressor.progressionWithin(start, 1d);

	// method: determine the progression of this given progressor (changing value) from the start progression (0) to the given end progression //
	public static float progressionTo(this float progressor, float end)
		=> progressor.progressionWithin(0f, end);
	// method: determine the progression of this given position from the given start position to the given distance //
	public static float distalProgressionTo(this Vector3 progressionPosition, float distance, Vector3 startPosition)
		=> startPosition.distanceWith(progressionPosition).progressionTo(distance);
	// method: determine the progression of this given progressor (changing value) from the start progression (0) to the given end progression //
	public static double progressionTo(this double progressor, double end)
		=> progressor.progressionWithin(0d, end);
	// method: determine the progression of this given progressor (changing value) from the start progression (0) to the given end progression //
	public static float progressionTo(this int progressor, float end)
		=> progressor.asFloat().progressionTo(end);

	// method: determine the progression of this given progressor (changing value) from the start progression (0) until the given end progression //
	public static float progressionUntil(this float progressor, int end)
		=> progressor.progressionTo(end - 1);
	// method: determine the progression of this given progressor (changing value) from the start progression (0) until the given end progression //
	public static double progressionUntil(this double progressor, int end)
		=> progressor.progressionTo(end - 1);
	// method: determine the progression of this given progressor (changing value) from the start progression (0) until the given end progression //
	public static float progressionUntil(this int progressor, int end)
		=> progressor.asFloat().progressionUntil(end);
	#endregion progression
}