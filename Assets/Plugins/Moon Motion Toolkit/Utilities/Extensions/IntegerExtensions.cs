using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Integer Extensions: provides extension methods for handling integers
// #numbers
public static class IntegerExtensions
{
	#region comparison

	public static bool equals(this int integer, float float_)
		=> (integer == float_);

	public static bool lesserThan(this int integer, float float_)
		=> (integer < float_);

	public static bool lesserThanOrEqualTo(this int integer, float float_)
		=> (integer <= float_);

	public static bool greaterThan(this int integer, float float_)
		=> (integer > float_);

	public static bool greaterThanOrEqualTo(this int integer, float float_)
		=> (integer >= float_);
	#endregion comparison


	#region parity determination

	// method: return whether this given integer is even //
	public static bool even(this int integer)
		=> ((integer % 2) == 0);

	// method: return whether this given integer is odd //
	public static bool odd(this int integer)
		=> ((integer % 2) == 1);
	#endregion parity determination


	#region range determination

	// method: return whether this given integer is within (in inclusive range of) the given lower and upper bound values //
	public static bool within(this int integer, float lower, float upper)
		=> (lower <= integer) && (integer <= upper);

	// method: return whether this given integer is between (in exclusive range of) the given lower and upper bound values //
	public static bool between(this int integer, float lower, float upper)
		=> (lower < integer) && (integer < upper);
	#endregion range determination


	#region finitude determination
	
	public static bool isFinite(this int integer)
		=> integer.within(int.MinValue, int.MaxValue);
	#endregion finitude determination


	#region sign determination

	// method: return whether this given integer is zero (unsigned) //
	public static bool isZero(this int integer)
		=> (integer == 0);

	// method: return whether this given integer is signed //
	public static bool isSigned(this int integer)
		=> (integer != 0);

	// method: return whether this given integer is positive //
	public static bool isPositive(this int integer)
		=> (integer > 0);

	// method: return whether this given integer is nonpositive //
	public static bool isNonnegative(this int integer)
		=> (integer >= 0);

	// method: return whether this given integer is positive //
	public static bool isNegative(this int integer)
		=> (integer < 0);

	// method: return whether this given integer is nonpositive //
	public static bool isNonpositive(this int integer)
		=> (integer <= 0);
	#endregion sign determination


	#region clamping

	public static int least(this int integer, int otherInteger)
		=> Mathf.Max(integer, otherInteger);

	public static int most(this int integer, int otherInteger)
		=> Mathf.Min(integer, otherInteger);

	public static int clampedFinite(this int integer)
		=> integer.least(int.MinValue).most(int.MaxValue);

	public static int clampedFiniteAndNonnegative(this int integer)
		=> integer.least(0).most(int.MaxValue);

	public static int clampedNonnegative(this int integer)
		=> integer.least(0);

	public static int clampedNonpositive(this int integer)
		=> integer.most(0);
	#endregion clamping


	#region sign manipulation

	public static int magnitude(this int integer)
		=> Mathf.Abs(integer);

	public static int withSign(this int integer, bool booleanForSign)
		=> (integer.magnitude() * booleanForSign.asSign());

	public static int timesSign(this int integer, bool booleanForSign)
		=> (integer * booleanForSign.asSign());
	
	public static int signChanged(this int integer)
		=> integer * -1;
	#endregion sign manipulation


	#region distance

	public static int distanceFrom(this int integer, int otherInteger)
		=> (integer - otherInteger).magnitude();

	public static float distanceFrom(this int integer, float someFloat_)
		=> (integer - someFloat_).magnitude();
	#endregion distance


	#region math operations

	public static int ifNonnegativeThenPlus(this int integer, int addendInteger)
		=>	integer.isNonnegative() ?
				(integer + addendInteger) :
				integer;

	public static float halved(this int integer)
		=> (integer / 2f);

	public static int doubled(this int integer)
		=> (integer * 2);

	public static float toThePowerOf(this int integer, float power)
		=> Mathf.Pow(integer, power);

	public static int squared(this int integer)
		=> ((int)integer.toThePowerOf(2));
	#endregion math operations


	#region conversion

	// method: return the bytes corresponding to this given integer //
	public static byte[] bytes(this int integer)
		=> BitConverter.GetBytes(integer);

	// method: return the boolean for this given integer //
	public static bool asBoolean(this int integer)
		=> integer == 1;

	// method: return the sign integer of this given integer //
	public static int sign(this int integer)
		=>	integer.isPositive() ?
				1 :
				integer.isNegative() ?
					-1 :
					0;

	// method: return the float for this given integer //
	public static float asFloat(this int integer)
		=> integer;

	// method: return the random color corresponding to this string as a seed //
	public static Color seedRandomColor(this int integer)
		=> integer.hashedString().asHashedStringToColor();
	#endregion conversion
}