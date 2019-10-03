using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Double Extensions: provides extension methods for handling doubles
// #numbers
public static class DoubleExtensions
{
	#region comparison

	public static bool equals(this double double_, double otherDouble)
		=> (double_ == otherDouble);

	public static bool lesserThan(this double double_, double otherDouble)
		=> (double_ < otherDouble);

	public static bool lesserThanOrEqualTo(this double double_, double otherDouble)
		=> (double_ <= otherDouble);

	public static bool greaterThan(this double double_, double otherDouble)
		=> (double_ > otherDouble);

	public static bool greaterThanOrEqualTo(this double double_, double otherDouble)
		=> (double_ >= otherDouble);
	#endregion comparison


	#region parity determination

	// method: return whether this given double is even //
	public static bool even(this double double_)
		=> ((double_ % 2d) == 0d);

	// method: return whether this given double is odd //
	public static bool odd(this double double_)
		=> ((double_ % 2d) == 1d);
	#endregion parity determination


	#region range determination

	// method: return whether this given double is within (in inclusive range of) the given lower and upper bound values //
	public static bool within(this double double_, double lower, double upper)
		=> (lower <= double_) && (double_ <= upper);

	// method: return whether this given double is within (in inclusive range of) the given range //
	public static bool within(this double double_, Vector2 range)
		=> double_.within(range.x, range.y);

	// method: return whether this given double is within (in inclusive range of) any of the given ranges //
	public static bool withinAnyOf(this double double_, Vector2[] ranges)
		=> ranges.Any(range => double_.within(range));

	// method: return whether this given double is within (in inclusive range of) all of the given ranges //
	public static bool withinAllOf(this double double_, Vector2[] ranges)
		=> ranges.All(range => double_.within(range));

	// method: return whether this given double is between (in exclusive range of) the given lower and upper bound values //
	public static bool between(this double double_, double lower, double upper)
		=> (lower < double_) && (double_ < upper);

	// method: return whether this given double is between (in exclusive range of) the given range //
	public static bool between(this double double_, Vector2 range)
		=> double_.between(range.x, range.y);

	// method: return whether this given double is between (in exclusive range of) any of the given ranges //
	public static bool betweenAnyOf(this double double_, Vector2[] ranges)
		=> ranges.Any(range => double_.between(range));

	// method: return whether this given double is between (in exclusive range of) all of the given ranges //
	public static bool betweenAllOf(this double double_, Vector2[] ranges)
		=> ranges.All(range => double_.between(range));
	#endregion range determination


	#region finitude determination
	
	public static bool isFinite(this double double_)
		=> double_.within(double.MinValue, double.MaxValue);
	#endregion finitude determination


	#region sign determination

	// method: return whether this given double is zero (unsigned) //
	public static bool isZero(this double double_)
		=> (double_ == 0d);

	// method: return whether this given double is signed //
	public static bool isSigned(this double double_)
		=> (double_ != 0d);

	// method: return whether this given double is positive //
	public static bool isPositive(this double double_)
		=> (double_ > 0d);

	// method: return whether this given double is nonpositive //
	public static bool isNonnegative(this double double_)
		=> (double_ >= 0d);

	// method: return whether this given double is positive //
	public static bool isNegative(this double double_)
		=> (double_ < 0d);

	// method: return whether this given double is nonpositive //
	public static bool isNonpositive(this double double_)
		=> (double_ <= 0d);
	#endregion sign determination


	#region clamping

	public static double atLeast(this double double_, double otherDouble, bool boolean = true)
	{
		if (boolean)
		{
			return Doubles.maxOf(double_, otherDouble);
		}
		return double_;
	}

	public static double atMost(this double double_, double otherDouble, bool boolean = true)
	{
		if (boolean)
		{
			return Doubles.minOf(double_, otherDouble);
		}
		return double_;
	}

	public static double atMostOne(this double double_, bool boolean = true)
		=> double_.atMost(1d, boolean);

	public static double clampedToRatio(this double double_, bool boolean = true)
		=> double_.atLeast(0d, boolean).atMost(1d, boolean);

	public static double clampedFinite(this double double_)
		=> double_.atLeast(double.MinValue).atMost(double.MaxValue);

	public static double clampedFiniteAndNonnegative(this double double_)
		=> double_.atLeast(0d).atMost(double.MaxValue);

	public static double clampedNonnegative(this double double_)
		=> double_.atLeast(0d);

	public static double clampedNonpositive(this double double_)
		=> double_.atMost(0d);
	#endregion clamping


	#region distance

	public static double distanceFrom(this double double_, double otherDouble)
		=> (double_ - otherDouble).magnitude();
	#endregion distance


	#region sign manipulation

	public static double magnitude(this double double_)
		=> Math.Abs(double_);

	public static double withSign(this double double_, bool booleanForSign)
		=> (double_.magnitude() * booleanForSign.asSign());

	public static double timesSign(this double double_, bool booleanForSign)
		=> (double_ * booleanForSign.asSign());
	
	public static double signChanged(this double double_)
		=> double_ * -1d;
	#endregion sign manipulation


	#region math operations

	public static double halved(this double double_)
		=> (double_ / 2d);

	public static double doubled(this double double_)
		=> (double_ * 2d);

	public static double toThePowerOf(this double double_, double power)
		=> Math.Pow(double_, power);

	public static double squared(this double double_)
		=> double_.toThePowerOf(2d);

	public static double timesPi(this double double_)
		=> (double_ * Math.PI);

	public static double restOfWhole(this double double_)
		=> (1d - double_);

	public static double ratioQuadraticPalindrome(this double double_)
		=> (double_ * double_.restOfWhole());

	public static double ratioDequadratic(this double double_)
		=> double_.halved().ratioQuadraticPalindrome() * 4f;
	#endregion math operations


	#region interpolation

	// method: return this given ratio double "lerped" (linearly interpolated) along the range from the given start double to the given end double - without clamping //
	public static double lerpedUnclampingly(this double ratio, double start, double end)
		=> start + ((end - start) * ratio);

	// method: return this given ratio double "lerped" (linearly interpolated) along the range from the given start double to the given end double - with clamping //
	public static double lerpedClampingly(this double ratio, double start, double end)
		=> ratio.clampedToRatio().lerpedUnclampingly(start, end);

	// method: return this given ratio double "lerped" (linearly interpolated) along the range from the given start double to the given end double - with clamping according to the given 'clamp' boolean //
	public static double lerped(this double ratio, double start, double end, bool clamp)
		=> clamp ? ratio.lerpedClampingly(start, end) : ratio.lerpedUnclampingly(start, end);
	#endregion interpolation


	#region conversion

	// method: return the nearest integer to this given double //
	public static int toInteger(this double double_)
		=> (int) double_;
	// method: return the sign integer of this given double //
	public static int sign(this double double_)
		=> double_.toInteger().sign();

	// method: return the nearest float to this given double //
	public static float toFloat(this double double_)
		=> (float) double_;

	// method: return a vector for this given double (as each coordinate) //
	public static Vector asVector(this double double_)
		=> new Vector(double_, double_, double_);
	#endregion conversion
}