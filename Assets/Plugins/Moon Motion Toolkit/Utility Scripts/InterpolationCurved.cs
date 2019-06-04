using UnityEngine;
using System.Collections;

// Interpolation Curved
// • enumerates possible curves to use for interpolation
// • provides methods for interpolating using a given curve
//   · includes methods for interpolating floats and vectors
//     - includes options to clamp or not
public static class InterpolationCurved
{
	// enumerations //
	
	
	// enumeration of: curve possibilities //
	public enum Curve
	{
		linear,
		quadratic,
		sine,
		cosine,
		smooth,
		smoother,
		smootherPalindrome
	}








	// methods //

	
	
	
	// method: interpolate a float using the given clamping boolean, curve, and min & max & ratio values) //
	private static float interpolationFloat(bool clamp, Curve curve, float min, float max, float ratio)
	{
		switch (curve)
		{
			case Curve.linear:
			{
				if (clamp)
				{
					return Mathf.Lerp(min, max, ratio);
				}
				else
				{
					return Mathf.LerpUnclamped(min, max, ratio);
				}
			}
			case Curve.quadratic:
			{
				if (clamp)
				{
					return Mathf.Lerp(min, max, (ratio * ratio));
				}
				else
				{
					return Mathf.LerpUnclamped(min, max, (ratio * ratio));
				}
			}
			case Curve.sine:
			{
				if (clamp)
				{
					if (ratio < 0f)
					{
						ratio = 0f;
					}
					else if (ratio > 1f)
					{
						ratio = 1f;
					}
					return Mathf.Lerp(min, max, Mathf.Sin(ratio * Mathf.PI * .5f));
				}
				else
				{
					return Mathf.LerpUnclamped(min, max, Mathf.Sin(ratio * Mathf.PI * .5f));
				}
			}
			case Curve.cosine:
			{
				if (clamp)
				{
					if (ratio < 0f)
					{
						ratio = 0f;
					}
					else if (ratio > 1f)
					{
						ratio = 1f;
					}
					return Mathf.Lerp(min, max, Mathf.Cos(ratio * Mathf.PI * .5f));
				}
				else
				{
					return Mathf.LerpUnclamped(min, max, Mathf.Cos(ratio * Mathf.PI * .5f));
				}
			}
			case Curve.smooth:
			{
				if (clamp)
				{
					return Mathf.Lerp(min, max, (ratio * ratio * (3f - (2f * ratio))));
				}
				else
				{
					return Mathf.LerpUnclamped(min, max, (ratio * ratio * (3f - (2f * ratio))));
				}
			}
			case Curve.smoother:
			{
				if (clamp)
				{
					return Mathf.Lerp(min, max, (ratio * ratio * ratio * (ratio * ((6f * ratio) - 15f) + 10f)));
				}
				else
				{
					return Mathf.LerpUnclamped(min, max, (ratio * ratio * ratio * (ratio * ((6f * ratio) - 15f) + 10f)));
				}
			}
			case Curve.smootherPalindrome:
			{
				if (clamp)
				{
					return Mathf.Max(min, Mathf.Min(max, interpolationFloat(false, Curve.smootherPalindrome, min, max, ratio)));
				}
				else
				{
					return ((ratio < .5f) ? interpolationFloat(false, Curve.smoother, min, max, (ratio / .5f)) : interpolationFloat(false, Curve.smoother, max, min, ((ratio - .5f) / .5f)));
				}
			}
		}
		Debug.Log("error in InterpolationCurved.interpolationFloat(...); returning 0");
		return 0f;
	}

	// method: interpolate a vector using the given clamping boolean, curve, and min & max & ratio values) //
	private static Vector3 interpolationVector(bool clamp, Curve curve, Vector3 min, Vector3 max, float ratio)
	{
		return new Vector3(interpolationFloat(clamp, curve, min.x, max.x, ratio), interpolationFloat(clamp, curve, min.y, max.y, ratio), interpolationFloat(clamp, curve, min.z, max.z, ratio));
	}
	

	// method: interpolate a float with clamping using the given curve and min & max & ratio values //
	public static float floatClamped(Curve curve, float min, float max, float ratio)
	{
		return interpolationFloat(true, curve, min, max, ratio);
	}
	// method: interpolate a float array with clamping using the given curve and min & maxes & ratio values //
	public static float[] floatClamped(Curve curve, float min, float[] maxes, float ratio)
	{
		float[] interpolations = new float[maxes.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = floatClamped(curve, min, maxes[index], ratio);
		}
		return interpolations;
	}
	// method: interpolate a float array with clamping using the given curve and mins & max & ratio values //
	public static float[] floatClamped(Curve curve, float[] mins, float max, float ratio)
	{
		float[] interpolations = new float[mins.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = floatClamped(curve, mins[index], max, ratio);
		}
		return interpolations;
	}
	// method: interpolate a float array with clamping using the given curve and mins & maxes & ratio values //
	public static float[] floatClamped(Curve curve, float[] mins, float[] maxes, float ratio)
	{
		float[] interpolations = new float[mins.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = floatClamped(curve, mins[index], maxes[(index < maxes.Length) ? index : (index % maxes.Length)], ratio);
		}
		return interpolations;
	}
	// method: interpolate a float without clamping using the given curve and min & max & ratio values //
	public static float floatUnclamped(Curve curve, float min, float max, float ratio)
	{
		return interpolationFloat(false, curve, min, max, ratio);
	}
	// method: interpolate a float array without clamping using the given curve and min & maxes & ratio values //
	public static float[] floatUnclamped(Curve curve, float min, float[] maxes, float ratio)
	{
		float[] interpolations = new float[maxes.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = floatUnclamped(curve, min, maxes[index], ratio);
		}
		return interpolations;
	}
	// method: interpolate a float array without clamping using the given curve and mins & max & ratio values //
	public static float[] floatUnclamped(Curve curve, float[] mins, float max, float ratio)
	{
		float[] interpolations = new float[mins.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = floatUnclamped(curve, mins[index], max, ratio);
		}
		return interpolations;
	}
	// method: interpolate a float array without clamping using the given curve and mins & maxes & ratio values //
	public static float[] floatUnclamped(Curve curve, float[] mins, float[] maxes, float ratio)
	{
		float[] interpolations = new float[mins.Length];
		for (int index = 0; index < interpolations.Length; index++)
		{
			interpolations[index] = floatUnclamped(curve, mins[index], maxes[(index < maxes.Length) ? index : (index % maxes.Length)], ratio);
		}
		return interpolations;
	}

	// method: interpolate a vector with clamping using the given curve and min & max & ratio values //
	public static Vector3 vectorClamped(Curve curve, Vector3 min, Vector3 max, float ratio)
	{
		return interpolationVector(true, curve, min, max, ratio);
	}
	// method: interpolate a vector without clamping using the given curve and min & max & ratio values //
	public static Vector3 vectorUnclamped(Curve curve, Vector3 min, Vector3 max, float ratio)
	{
		return interpolationVector(false, curve, min, max, ratio);
	}
}