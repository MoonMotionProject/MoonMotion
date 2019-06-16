using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Vector Extensions: provides extension methods for handling vectors //
public static class VectorExtensions
{
	// methods for: vectrals //

	// method: return the vectral (normalized form) of this given vector //
	public static Vector3 vectral(this Vector3 vector)
		=> vector.normalized;


	// methods for: clamping //

	public static Vector3 atLeast(this Vector3 vector, Vector3 otherVector, bool boolean = true)
	{
		if (boolean)
		{
			return Vector3.Max(vector, otherVector);
		}
		return vector;
	}

	public static Vector3 atMost(this Vector3 vector, Vector3 otherVector, bool boolean = true)
	{
		if (boolean)
		{
			return Vector3.Min(vector, otherVector);
		}
		return vector;
	}

	public static Vector3 clampedValidAndNonnegative(this Vector3 vector)
		=> new Vector3(vector.x.clampedValidAndNonnegative(), vector.y.clampedValidAndNonnegative(), vector.z.clampedValidAndNonnegative());


	// methods for: validity determination //

	// method: return whether this given vector is valid //
	public static bool valid(this Vector3 vector)
		=> (vector.x.valid() && vector.y.valid() && vector.z.valid());


	// methods for: distance //

	// method: return the distance with this given vector and the other given vector //
	public static float distanceWith(this Vector3 vector, Vector3 otherVector)
		=> Vector3.Distance(vector, otherVector);

	// method: return the closest vector of the given vectors to this given vector //
	public static Vector3 closestOf(this Vector3 vector, IEnumerable<Vector3> vectors)
		=> vectors.itemWithMin(otherVector => Vector3.Distance(vector, otherVector));

	// method: return the farthest vector of the given vectors to this given vector //
	public static Vector3 farthestOf(this Vector3 vector, IEnumerable<Vector3> vectors)
		=> vectors.itemWithMax(otherVector => Vector3.Distance(vector, otherVector));


	// method for: sign determination //

	// method: return whether this given vector is nonnegative //
	public static bool nonnegative(this Vector3 vector)
		=> (vector.x.nonnegative() && vector.y.nonnegative() && vector.z.nonnegative());


	// methods for: directionality //

	// method: return the directionality ratio of this given vector with the other given vector //
	public static float directionalityWith(this Vector3 vector, Vector3 otherVector)
		=> Vector3.Dot(vector, otherVector);

	// method: return the sign of the directionality ratio of this given vector with the other given vector //
	public static float directionalitySignWith(this Vector3 vector, Vector3 otherVector)
		=> vector.directionalityWith(otherVector).asSign();


	// methods for: value replacement //

	// method: (according to the given boolean:) return this given vector but with its x value set to the given x value //
	public static Vector3 withX(this Vector3 vector, float x, bool boolean = true)
		=> (boolean ? new Vector3(x, vector.y, vector.z) : vector);

	// method: (according to the given boolean:) return this given vector but with its y value set to the given y value //
	public static Vector3 withY(this Vector3 vector, float y, bool boolean = true)
		=> (boolean ? new Vector3(vector.x, y, vector.z) : vector);

	// method: (according to the given boolean:) return this given vector but with its z value set to the given z value //
	public static Vector3 withZ(this Vector3 vector, float z, bool boolean = true)
		=> (boolean ? new Vector3(vector.x, vector.y, z) : vector);

	// method: (according to the given boolean:) return this given vector but with its x value set to zero //
	public static Vector3 withXZero(this Vector3 vector, bool boolean = true)
		=> vector.withX(0f, boolean);

	// method: (according to the given boolean:) return this given vector but with its y value set to zero //
	public static Vector3 withYZero(this Vector3 vector, bool boolean = true)
		=> vector.withY(0f, boolean);

	// method: (according to the given boolean:) return this given vector but with its z value set to zero //
	public static Vector3 withZZero(this Vector3 vector, bool boolean = true)
		=> vector.withZ(0f, boolean);


	// methods for: math operations //

	// method: return the average (value) of this given vector //
	public static float average(this Vector3 vector)
		=> vector.asArray().Average();

	// method: return the average x coordinate value of these given vectors //
	public static float averageX(this Vector3[] vectors)
		=> vectors.Select(vector => vector.x).Average();

	// method: return the average y coordinate value of these given vectors //
	public static float averageY(this Vector3[] vectors)
		=> vectors.Select(vector => vector.y).Average();

	// method: return the average z coordinate value of these given vectors //
	public static float averageZ(this Vector3[] vectors)
		=> vectors.Select(vector => vector.z).Average();

	// method: return an array of averages (average values) corresponding to these given vectors //
	public static float[] averages(this Vector3[] vectors)
		=> vectors.Select(vector => vector.x).ToArray();

	// method: determine the average value of these given vectors //
	public static float averageValue(this Vector3[] vectors)
		=> vectors.averages().Average();

	// method: determine the average (vector) of these given vectors //
	public static Vector3 average(this Vector3[] vectors)
		=> new Vector3
		(
			vectors.averageX(),
			vectors.averageY(),
			vectors.averageZ()
		);


	// methods for: conversion //

	// method: return a float array corresponding to this given vector //
	public static float[] asArray(this Vector3 vector)
		=> new float[] {vector.x, vector.y, vector.z};

	// method: return a float set corresponding to this given vector //
	public static HashSet<float> asSet(this Vector3 vector)
		=> new HashSet<float>() {vector.x, vector.y, vector.z};

	// method: return the doubles vector corresponding to this given floats vector //
	public static Vector asDoublesVector(this Vector3 floatsVector)
		=> new Vector(floatsVector.x, floatsVector.y, floatsVector.z);

	// method: return the floats vector corresponding to this given doubles vector //
	public static Vector3 asFloatsVector(this Vector doublesVector)
		=> new Vector3(doublesVector.x.asFloat(), doublesVector.y.asFloat(), doublesVector.z.asFloat());
}