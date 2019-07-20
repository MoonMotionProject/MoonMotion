using UnityEngine;
using System.Collections;
using System;

// Interpolation Curved
// • provides methods for interpolating using a given interpolation curve
//   · includes methods for interpolating floats and vectors
//     - includes options to clamp or not
public static class InterpolationCurved
{
	// methods //


	#region private methods - double

	// method: return this given linear ratio double modified for the given interpolation curve and the given clamping boolean //
	private static double asRatioforCurveAndClamping(this double ratio, InterpolationCurve curve, bool clamp)
	{
		switch (curve)
		{
			case InterpolationCurve.linear:
			{
				return ratio;
			}
			case InterpolationCurve.quadratic:
			{
				return ratio.squared();
			}
			case InterpolationCurve.sine:
			{
				return Math.Sin(ratio.clampedToRatio(clamp).timesPi().halved());
			}
			case InterpolationCurve.cosine:
			{
				return Math.Cos(ratio.clampedToRatio(clamp).timesPi().halved());
			}
			case InterpolationCurve.smooth:
			{
				return (ratio.squared() * (3d - (ratio.doubled())));
			}
			case InterpolationCurve.smoother:
			{
				return (ratio.toThePowerOf(3d) * (ratio * ((6d * ratio) - 15d) + 10d));
			}
		}
		return ratio.returnWithError("error in InterpolationCurved.asRatioforCurveAndClamping(...)");
	}

	// method: interpolate a double using this given curve and the given clamping boolean and start & end & ratio values //
	private static double interpolation(this InterpolationCurve curve, bool clamp, double start, double end, double ratio)
	{
		if (curve != InterpolationCurve.smootherPalindrome)
		{
			return ratio.asRatioforCurveAndClamping(curve, clamp).lerped(start, end, clamp);
		}
		else
		{
			return (
						clamp ?
							InterpolationCurve.smootherPalindrome.interpolation(false, start, end, ratio).atLeast(start).atMost(end) :
							(
								(ratio < .5d) ?
									InterpolationCurve.smoother.interpolation(false, start, end, ratio.halved()) :
									InterpolationCurve.smoother.interpolation(false, end, start, (ratio - .5d).halved())
							)
					);
		}
	}

	// method: interpolate a doubles vector using this given curve and the given clamping boolean and start & end & ratio values //
	private static Vector interpolation(this InterpolationCurve curve, bool clamp, Vector start, Vector end, double ratio)
		=> new Vector
		(
			curve.interpolation(clamp, start.x, end.x, ratio),
			curve.interpolation(clamp, start.y, end.y, ratio),
			curve.interpolation(clamp, start.z, end.z, ratio)
		);
	#endregion private methods - double


	#region private methods - float

	// method: return this given linear ratio float modified for the given interpolation curve and the given clamping boolean //
	private static float asRatioforCurveAndClamping(this float ratio, InterpolationCurve curve, bool clamp)
	{
		switch (curve)
		{
			case InterpolationCurve.linear:
			{
				return ratio;
			}
			case InterpolationCurve.quadratic:
			{
				return ratio.squared();
			}
			case InterpolationCurve.sine:
			{
				return Mathf.Sin(ratio.clampedToRatio(clamp).timesPi().halved());
			}
			case InterpolationCurve.cosine:
			{
				return Mathf.Cos(ratio.clampedToRatio(clamp).timesPi().halved());
			}
			case InterpolationCurve.smooth:
			{
				return (ratio.squared() * (3f - (ratio.doubled())));
			}
			case InterpolationCurve.smoother:
			{
				return (ratio.toThePowerOf(3f) * (ratio * ((6f * ratio) - 15f) + 10f));
			}
		}
		return ratio.returnWithError("error in InterpolationCurved.asRatioforCurveAndClamping(...)");
	}

	// method: interpolate a float using this given curve and the given clamping boolean and start & end & ratio values //
	private static float interpolation(this InterpolationCurve curve, bool clamp, float start, float end, float ratio)
	{
		if (curve != InterpolationCurve.smootherPalindrome)
		{
			return ratio.asRatioforCurveAndClamping(curve, clamp).lerped(start, end, clamp);
		}
		else
		{
			return (
						clamp ?
							InterpolationCurve.smootherPalindrome.interpolation(false, start, end, ratio).atLeast(start).atMost(end) :
							(
								(ratio < .5f) ?
									InterpolationCurve.smoother.interpolation(false, start, end, ratio.halved()) :
									InterpolationCurve.smoother.interpolation(false, end, start, (ratio - .5f).halved())
							)
					);
		}
	}

	// method: interpolate a floats vector using this given curve and the given clamping boolean and start & end & ratio values //
	private static Vector3 interpolation(this InterpolationCurve curve, bool clamp, Vector3 start, Vector3 end, float ratio)
		=> new Vector3
		(
			curve.interpolation(clamp, start.x, end.x, ratio),
			curve.interpolation(clamp, start.y, end.y, ratio),
			curve.interpolation(clamp, start.z, end.z, ratio)
		);

	// method: interpolate a floats pair using this given curve and the given clamping boolean and start & end & ratio values //
	private static Vector2 interpolation(this InterpolationCurve curve, bool clamp, Vector2 start, Vector2 end, float ratio)
		=> new Vector2
		(
			curve.interpolation(clamp, start.x, end.x, ratio),
			curve.interpolation(clamp, start.y, end.y, ratio)
		);
	#endregion private methods - float


	#region public methods - double

	// method: interpolate a double with clamping using this given curve and the given start & end & ratio values //
	public static double clamped(this InterpolationCurve curve, double start, double end, double ratio)
		=> curve.interpolation(true, start, end, ratio);
	// method: interpolate a float (using doubles interpolation) with clamping using this given curve and the given start & end & ratio values //
	public static float clamped(this InterpolationCurve curve, float start, float end, double ratio)
		=> curve.clamped(start.asDouble(), end.asDouble(), ratio).asFloat();

	// method: interpolate a doubles array with clamping using this given curve and the given start & ends & ratio values //
	public static double[] clamped(this InterpolationCurve curve, double start, double[] ends, double ratio)
	{
		double[] interpolations = new double[ends.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.clamped(start, ends[index], ratio);
		}
		return interpolations;
	}
	// method: interpolate a floats array (using doubles interpolation) with clamping using this given curve and the given start & ends & ratio values //
	public static float[] clamped(this InterpolationCurve curve, float start, float[] ends, double ratio)
		=> curve.clamped(start.asDouble(), ends.asDoublesArray(), ratio).asFloatsArray();

	// method: interpolate a doubles array with clamping using this given curve and the given starts & end & ratio values //
	public static double[] clamped(this InterpolationCurve curve, double[] starts, double end, double ratio)
	{
		double[] interpolations = new double[starts.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.clamped(starts[index], end, ratio);
		}
		return interpolations;
	}
	// method: interpolate a floats array (using doubles interpolation) with clamping using this given curve and the given starts & end & ratio values //
	public static float[] clamped(this InterpolationCurve curve, float[] starts, float end, double ratio)
		=> curve.clamped(starts.asDoublesArray(), end.asDouble(), ratio).asFloatsArray();

	// method: interpolate a doubles array with clamping using this given curve and the given starts & ends & ratio values //
	public static double[] clamped(this InterpolationCurve curve, double[] starts, double[] ends, double ratio)
	{
		double[] interpolations = new double[starts.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.clamped(starts[index], ends[index % ends.Length], ratio);
		}
		return interpolations;
	}
	// method: interpolate a floats array (using doubles interpolation) with clamping using this given curve and the given starts & ends & ratio values //
	public static float[] clamped(this InterpolationCurve curve, float[] starts, float[] ends, double ratio)
		=> curve.clamped(starts.asDoublesArray(), ends.asDoublesArray(), ratio).asFloatsArray();

	// method: interpolate a double without clamping using this given curve and the given start & end & ratio values //
	public static double unclamped(this InterpolationCurve curve, double start, double end, double ratio)
		=> curve.interpolation(false, start, end, ratio);
	// method: interpolate a float (using doubles interpolation) without clamping using this given curve and the given start & end & ratio values //
	public static float unclamped(this InterpolationCurve curve, float start, float end, double ratio)
		=> curve.unclamped(start.asDouble(), end.asDouble(), ratio).asFloat();

	// method: interpolate a doubles array without clamping using this given curve and the given start & ends & ratio values //
	public static double[] unclamped(this InterpolationCurve curve, double start, double[] ends, double ratio)
	{
		double[] interpolations = new double[ends.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.unclamped(start, ends[index], ratio);
		}
		return interpolations;
	}
	// method: interpolate a floats array (using doubles interpolation) without clamping using this given curve and the given start & ends & ratio values //
	public static float[] unclamped(this InterpolationCurve curve, float start, float[] ends, double ratio)
		=> curve.unclamped(start.asDouble(), ends.asDoublesArray(), ratio).asFloatsArray();

	// method: interpolate a doubles array without clamping using this given curve and the given starts & end & ratio values //
	public static double[] unclamped(this InterpolationCurve curve, double[] starts, double end, double ratio)
	{
		double[] interpolations = new double[starts.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.unclamped(starts[index], end, ratio);
		}
		return interpolations;
	}
	// method: interpolate a floats array (using doubles interpolation) without clamping using this given curve and the given starts & end & ratio values //
	public static float[] unclamped(this InterpolationCurve curve, float[] starts, float end, double ratio)
		=> curve.unclamped(starts.asDoublesArray(), end.asDouble(), ratio).asFloatsArray();

	// method: interpolate a doubles array without clamping using this given curve and the given starts & ends & ratio values //
	public static double[] unclamped(this InterpolationCurve curve, double[] starts, double[] ends, double ratio)
	{
		double[] interpolations = new double[starts.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.unclamped(starts[index], ends[index % ends.Length], ratio);
		}
		return interpolations;
	}
	// method: interpolate a floats array (using doubles interpolation) without clamping using this given curve and the given starts & ends & ratio values //
	public static float[] unclamped(this InterpolationCurve curve, float[] starts, float[] ends, double ratio)
		=> curve.unclamped(starts.asDoublesArray(), ends.asDoublesArray(), ratio).asFloatsArray();

	// method: interpolate a doubles vector with clamping using the given curve and start & end & ratio values //
	public static Vector clamped(this InterpolationCurve curve, Vector start, Vector end, double ratio)
		=> curve.interpolation(true, start, end, ratio);
	// method: interpolate a floats vector (using doubles interpolation) with clamping using the given curve and start & end & ratio values //
	public static Vector3 clamped(this InterpolationCurve curve, Vector3 start, Vector3 end, double ratio)
		=> curve.clamped(start.asDoublesVector(), end.asDoublesVector(), ratio).asFloatsVector();

	// method: interpolate a doubles vector without clamping using this given curve and the given start & end & ratio values //
	public static Vector unclamped(this InterpolationCurve curve, Vector start, Vector end, double ratio)
		=> curve.interpolation(false, start, end, ratio);
	// method: interpolate a floats vector (using doubles interpolation) without clamping using this given curve and the given start & end & ratio values //
	public static Vector3 unclamped(this InterpolationCurve curve, Vector3 start, Vector3 end, double ratio)
		=> curve.unclamped(start.asDoublesVector(), end.asDoublesVector(), ratio).asFloatsVector();
	#endregion public methods - double


	#region public methods - float

	// method: interpolate a float with clamping using this given curve and the given start & end & ratio values //
	public static float clamped(this InterpolationCurve curve, float start, float end, float ratio)
		=> curve.interpolation(true, start, end, ratio);

	// method: interpolate a floats array with clamping using this given curve and the given start & ends & ratio values //
	public static float[] clamped(this InterpolationCurve curve, float start, float[] ends, float ratio)
	{
		float[] interpolations = new float[ends.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.clamped(start, ends[index], ratio);
		}
		return interpolations;
	}

	// method: interpolate a floats array with clamping using this given curve and the given starts & end & ratio values //
	public static float[] clamped(this InterpolationCurve curve, float[] starts, float end, float ratio)
	{
		float[] interpolations = new float[starts.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.clamped(starts[index], end, ratio);
		}
		return interpolations;
	}

	// method: interpolate a floats array with clamping using this given curve and the given starts & ends & ratio values //
	public static float[] clamped(this InterpolationCurve curve, float[] starts, float[] ends, float ratio)
	{
		float[] interpolations = new float[starts.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.clamped(starts[index], ends[index % ends.Length], ratio);
		}
		return interpolations;
	}

	// method: interpolate a float without clamping using this given curve and the given start & end & ratio values //
	public static float unclamped(this InterpolationCurve curve, float start, float end, float ratio)
		=> curve.interpolation(false, start, end, ratio);

	// method: interpolate a floats array without clamping using this given curve and the given start & ends & ratio values //
	public static float[] unclamped(this InterpolationCurve curve, float start, float[] ends, float ratio)
	{
		float[] interpolations = new float[ends.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.unclamped(start, ends[index], ratio);
		}
		return interpolations;
	}

	// method: interpolate a floats array without clamping using this given curve and the given starts & end & ratio values //
	public static float[] unclamped(this InterpolationCurve curve, float[] starts, float end, float ratio)
	{
		float[] interpolations = new float[starts.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.unclamped(starts[index], end, ratio);
		}
		return interpolations;
	}

	// method: interpolate a floats array without clamping using this given curve and the given starts & ends & ratio values //
	public static float[] unclamped(this InterpolationCurve curve, float[] starts, float[] ends, float ratio)
	{
		float[] interpolations = new float[starts.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = curve.unclamped(starts[index], ends[index % ends.Length], ratio);
		}
		return interpolations;
	}

	// method: interpolate a floats vector with clamping using the given curve and start & end & ratio values //
	public static Vector3 clamped(this InterpolationCurve curve, Vector3 start, Vector3 end, float ratio)
		=> curve.interpolation(true, start, end, ratio);

	// method: interpolate a floats vector without clamping using this given curve and the given start & end & ratio values //
	public static Vector3 unclamped(this InterpolationCurve curve, Vector3 start, Vector3 end, float ratio)
		=> curve.interpolation(false, start, end, ratio);

	// method: interpolate a floats pair with clamping using the given curve and start & end & ratio values //
	public static Vector2 clamped(this InterpolationCurve curve, Vector2 start, Vector2 end, float ratio)
		=> curve.interpolation(true, start, end, ratio);

	// method: interpolate a floats pair without clamping using this given curve and the given start & end & ratio values //
	public static Vector2 unclamped(this InterpolationCurve curve, Vector2 start, Vector2 end, float ratio)
		=> curve.interpolation(false, start, end, ratio);
	#endregion public methods - float
}