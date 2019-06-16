using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Integer Extensions: provides extension methods for handling integers //
public static class IntegerExtensions
{
	// methods for: comparison //

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


	// methods for: parity determination //

	// method: return whether this given integer is even //
	public static bool even(this int integer)
		=> ((integer % 2) == 0);

	// method: return whether this given integer is odd //
	public static bool odd(this int integer)
		=> ((integer % 2) == 1);


	// methods for: range determination //

	// method: return whether this given integer is within (in inclusive range of) the given lower and upper bound values //
	public static bool within(this int integer, float lower, float upper)
		=> (lower <= integer) && (integer <= upper);

	// method: return whether this given integer is between (in exclusive range of) the given lower and upper bound values //
	public static bool between(this int integer, float lower, float upper)
		=> (lower < integer) && (integer < upper);


	// methods for: validity determination //

	// method: return whether this given integer is valid //
	public static bool valid(this int integer)
		=> integer.within(int.MinValue, int.MaxValue);


	// methods for: sign determination //

	// method: return whether this given integer is unsigned //
	public static bool unsigned(this int integer)
		=> (integer == 0);

	// method: return whether this given integer is signed //
	public static bool signed(this int integer)
		=> (integer != 0);

	// method: return whether this given integer is positive //
	public static bool positive(this int integer)
		=> (integer > 0);

	// method: return whether this given integer is nonpositive //
	public static bool nonnegative(this int integer)
		=> (integer >= 0);

	// method: return whether this given integer is positive //
	public static bool negative(this int integer)
		=> (integer < 0);

	// method: return whether this given integer is nonpositive //
	public static bool nonpositive(this int integer)
		=> (integer <= 0);


	// methods for: clamping //

	public static int least(this int integer, int otherInteger)
		=> Mathf.Max(integer, otherInteger);

	public static int most(this int integer, int otherInteger)
		=> Mathf.Min(integer, otherInteger);

	public static int clampedValid(this int integer)
		=> integer.least(int.MinValue).most(int.MaxValue);

	public static int clampedValidAndNonnegative(this int integer)
		=> integer.least(0).most(int.MaxValue);

	public static int clampedNonnegative(this int integer)
		=> integer.least(0);

	public static int clampedNonpositive(this int integer)
		=> integer.most(0);


	// methods for: sign manipulation //

	public static int absoluteValue(this int integer)
		=> Mathf.Abs(integer);

	public static int withSign(this int integer, bool booleanForSign)
		=> (integer.absoluteValue() * booleanForSign.asSign());

	public static int timesSign(this int integer, bool booleanForSign)
		=> (integer * booleanForSign.asSign());


	// methods for: distance //

	public static int distanceFrom(this int integer, int otherInteger)
		=> (integer - otherInteger).absoluteValue();

	public static float distanceFrom(this int integer, float someFloat_)
		=> (integer - someFloat_).absoluteValue();


	// methods for: math operations //

	public static float halved(this int integer)
		=> (integer / 2f);

	public static int doubled(this int integer)
		=> (integer * 2);

	public static float toThePowerOf(this int integer, float power)
		=> Mathf.Pow(integer, power);

	public static int squared(this int integer)
		=> ((int)integer.toThePowerOf(2));


	// methods for: conversion //

	// method: return the sign integer for this given integer //
	public static int asSign(this int integer)
		=> (integer.positive() ? 1 : integer.negative() ? -1 : 0);
}