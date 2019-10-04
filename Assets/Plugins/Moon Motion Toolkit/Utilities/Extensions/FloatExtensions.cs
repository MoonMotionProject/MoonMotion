using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Float Extensions: provides extension methods for handling floats
// #numbers
public static class FloatExtensions
{
	#region comparison

	public static bool equals(this float float_, float otherFloat)
		=> (float_ == otherFloat);

	public static bool lesserThan(this float float_, float otherFloat)
		=> (float_ < otherFloat);

	public static bool lesserThanOrEqualTo(this float float_, float otherFloat)
		=> (float_ <= otherFloat);

	public static bool greaterThan(this float float_, float otherFloat)
		=> (float_ > otherFloat);

	public static bool greaterThanOrEqualTo(this float float_, float otherFloat)
		=> (float_ >= otherFloat);
	#endregion comparison


	#region parity determination

	// method: return whether this given float is even //
	public static bool even(this float float_)
		=> ((float_ % 2f) == 0f);

	// method: return whether this given float is odd //
	public static bool odd(this float float_)
		=> ((float_ % 2f) == 1f);
	#endregion parity determination


	#region range determination

	// method: return whether this given float is within (in inclusive range of) the given lower and upper bound values //
	public static bool within(this float float_, float lower, float upper)
		=> (lower <= float_) && (float_ <= upper);

	// method: return whether this given float is within (in inclusive range of) the given range //
	public static bool within(this float float_, Vector2 range)
		=> float_.within(range.x, range.y);

	// method: return whether this given float is within (in inclusive range of) any of the given ranges //
	public static bool withinAnyOf(this float float_, Vector2[] ranges)
		=> ranges.Any(range => float_.within(range));

	// method: return whether this given float is within (in inclusive range of) all of the given ranges //
	public static bool withinAllOf(this float float_, Vector2[] ranges)
		=> ranges.All(range => float_.within(range));

	// method: return whether this given float is between (in exclusive range of) the given lower and upper bound values //
	public static bool between(this float float_, float lower, float upper)
		=> (lower < float_) && (float_ < upper);

	// method: return whether this given float is between (in exclusive range of) the given range //
	public static bool between(this float float_, Vector2 range)
		=> float_.between(range.x, range.y);

	// method: return whether this given float is between (in exclusive range of) any of the given ranges //
	public static bool betweenAnyOf(this float float_, Vector2[] ranges)
		=> ranges.Any(range => float_.between(range));

	// method: return whether this given float is between (in exclusive range of) all of the given ranges //
	public static bool betweenAllOf(this float float_, Vector2[] ranges)
		=> ranges.All(range => float_.between(range));
	#endregion range determination


	#region finitude determination
	
	public static bool isFinite(this float float_)
		=> float_.within(float.MinValue, float.MaxValue);
	
	public static bool isInfinity(this float float_)
		=> float_ == Infinity.asAFloat;
	
	public static bool isNegativeInfinity(this float float_)
		=> float_ == NegativeInfinity.asAFloat;
	
	public static bool isInfinite(this float float_)
		=> float_.isInfinity() || float_.isNegativeInfinity();
	#endregion finitude determination


	#region finitude logic
	
	public static float ifFiniteOtherwise(this float float_, Func<float> function)
		=> float_.isFinite() ? float_ : function();
	#endregion finitude logic


	#region validity determination
	
	public static bool isValid(this float float_)
		=> float_.isFinite() || float_.isInfinite();
	#endregion validity determination


	#region sign determination

	// method: return whether this given float is zero (unsigned) //
	public static bool isZero(this float float_)
		=> (float_ == 0f);

	// method: return whether this given float is signed //
	public static bool isSigned(this float float_)
		=> (float_ != 0f);

	// method: return whether this given float is positive //
	public static bool isPositive(this float float_)
		=> (float_ > 0f);

	// method: return whether this given float is nonpositive //
	public static bool isNonnegative(this float float_)
		=> (float_ >= 0f);

	// method: return whether this given float is positive //
	public static bool isNegative(this float float_)
		=> (float_ < 0f);

	// method: return whether this given float is nonpositive //
	public static bool nonpositive(this float float_)
		=> (float_ <= 0f);
	#endregion sign determination


	#region clamping

	public static float atLeast(this float float_, float otherFloat, bool boolean = true)
	{
		if (boolean)
		{
			return Mathf.Max(float_, otherFloat);
		}
		return float_;
	}

	public static float atMost(this float float_, float otherFloat, bool boolean = true)
	{
		if (boolean)
		{
			return Mathf.Min(float_, otherFloat);
		}
		return float_;
	}

	public static float atMostOne(this float float_, bool boolean = true)
		=> float_.atMost(1f, boolean);

	public static float clampedToRatio(this float float_, bool boolean = true)
		=> float_.atLeast(0f, boolean).atMost(1f, boolean);

	public static float clampedFinite(this float float_)
		=> float_.atLeast(float.MinValue).atMost(float.MaxValue);

	public static float clampedFiniteAndNonnegative(this float float_)
		=> float_.atLeast(0f).atMost(float.MaxValue);

	public static float clampedValidAndNonnegative(this float float_)
		=>	float_.isValid() && float_.isNonnegative() ?
				float_ : 
				float_.isInfinity() ?
					float_ :
					float_.clampedFiniteAndNonnegative();

	public static float clampedNonnegative(this float float_)
		=> float_.atLeast(0f);

	public static float clampedNonpositive(this float float_)
		=> float_.atMost(0f);
	#endregion clamping


	#region distance

	public static float distanceWith(this float float_, float otherFloat)
		=> (float_ - otherFloat).magnitude();
	#endregion distance


	#region sign manipulation

	public static float magnitude(this float float_)
		=> Mathf.Abs(float_);

	public static float withSign(this float float_, bool booleanForSign)
		=> (float_.magnitude() * booleanForSign.asSign());

	public static float timesSign(this float float_, bool booleanForSign)
		=> (float_ * booleanForSign.asSign());
	
	public static float signChanged(this float float_)
		=> float_ * -1f;
	#endregion sign manipulation


	#region math operations

	public static float halved(this float float_)
		=> (float_ / 2f);

	public static float doubled(this float float_)
		=> (float_ * 2f);

	public static float toThePowerOf(this float float_, float power)
		=> Mathf.Pow(float_, power);

	public static float squared(this float float_)
		=> float_.toThePowerOf(2f);

	public static float timesPi(this float float_)
		=> (float_ * Mathf.PI);

	public static float restOfWhole(this float float_)
		=> (1f - float_);

	public static float ratioQuadraticPalindrome(this float float_)
		=> (float_ * float_.restOfWhole());

	public static float ratioDequadratic(this float float_)
		=> float_.halved().ratioQuadraticPalindrome() * 4f;
	#endregion math operations


	#region interpolation

	// method: return this given ratio float "lerped" (linearly interpolated) along the range from the given start float to the given end float - without clamping //
	public static float lerpedUnclampingly(this float ratio, float start, float end)
		=> start + ((end - start) * ratio);
	// method: return this given ratio float "lerped" (linearly interpolated) along the given range - without clamping //
	public static float lerpedUnclampingly(this float ratio, Vector2 range)
		=> ratio.lerpedUnclampingly(range.x, range.y);
	// method: return this given ratio float "lerped" (linearly interpolated) along the range from the given start floats pair to the given end floats pair - without clamping //
	public static Vector2 lerpedUnclampingly(this float ratio, Vector2 starts, Vector2 ends)
		=> new Vector2
			(
				ratio.lerpedUnclampingly(starts.x, ends.x),
				ratio.lerpedUnclampingly(starts.y, ends.y)
			);

	// method: return this given ratio float "lerped" (linearly interpolated) along the range from the given start float to the given end float - with clamping //
	public static float lerpedClampingly(this float ratio, float start, float end)
		=> ratio.clampedToRatio().lerpedUnclampingly(start, end);
	// method: return this given ratio float "lerped" (linearly interpolated) along the given range - with clamping //
	public static float lerpedClampingly(this float ratio, Vector2 range)
		=> ratio.lerpedClampingly(range.x, range.y);
	// method: return this given ratio float "lerped" (linearly interpolated) along the range from the given start floats pair to the given end floats pair - with clamping //
	public static Vector2 lerpedClampingly(this float ratio, Vector2 starts, Vector2 ends)
		=> new Vector2
			(
				ratio.lerpedClampingly(starts.x, ends.x),
				ratio.lerpedClampingly(starts.y, ends.y)
			);

	// method: return this given ratio float "lerped" (linearly interpolated) along the range from the given start float to the given end float - with clamping according to the given 'clamp' boolean //
	public static float lerped(this float ratio, float start, float end, bool clamp)
		=> clamp ? ratio.lerpedClampingly(start, end) : ratio.lerpedUnclampingly(start, end);
	// method: return this given ratio float "lerped" (linearly interpolated) along the given range - with clamping according to the given 'clamp' boolean //
	public static float lerped(this float ratio, Vector2 range, bool clamp)
		=> ratio.lerped(range.x, range.y, clamp);
	// method: return this given ratio float "lerped" (linearly interpolated) along the range from the given start floats pair to the given end floats pair - with clamping according to the given 'clamp' boolean //
	public static Vector2 lerpedClampingly(this float ratio, Vector2 starts, Vector2 ends, bool clamp)
		=> new Vector2
			(
				ratio.lerped(starts.x, ends.x, clamp),
				ratio.lerped(starts.y, ends.y, clamp)
			);
	#endregion interpolation


	#region conversion

	// method: return the nearest integer to this given float //
	public static int toInteger(this float float_)
		=> (int) float_;
	// method: return the sign integer of this given float //
	public static int sign(this float float_)
		=> float_.toInteger().sign();

	// method: return the double for this given float //
	public static double asDouble(this float float_)
		=> float_;

	// method: return a vector for this given float (as each coordinate) //
	public static Vector3 asVector(this float float_)
		=> new Vector3(float_, float_, float_);
	#endregion conversion
}