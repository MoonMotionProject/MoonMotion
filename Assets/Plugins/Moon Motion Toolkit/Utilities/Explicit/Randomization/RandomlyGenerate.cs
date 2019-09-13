using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Randomly Generate: provides methods for random generation //
public static class RandomlyGenerate
{
	#region randomly generating within a given range

	// method: generate a random float in the range within the two given floats //
	public static float within(float floatFirst, float floatSecond)
		=> Random.Range(floatFirst, floatSecond);

	// method: generate a random float in the range within the two respective floats in the given pair //
	public static float within(Vector2 pair)
		=> within(pair.x, pair.y);

	// method: generate a random integer in the range within the two given integers //
	public static int within(int integerFirst, int integerSecond)
		=> Random.Range(integerFirst, integerSecond + 1);

	// method: generate a random integer in the range between the two given integers //
	public static int between(int integerFirst, int integerSecond)
		=> Random.Range(integerFirst + 1, integerSecond);

	// method: generate a random integer in the range from the first integer until the second integer //
	public static int fromUntil(int integerFirst, int integerSecond)
		=> Random.Range(integerFirst, integerSecond);
	// method: generate a random integer in the range from 0 until the second integer //
	public static int fromZeroUntil(int integerSecond)
		=> fromUntil(0, integerSecond);

	// method: generate a random integer in the range after the first integer to the second integer //
	public static int afterTo(int integerFirst, int integerSecond)
		=> Random.Range(integerFirst + 1, integerSecond + 1);

	// method: generate a random vector in the range within the two given vectors //
	public static Vector3 within(Vector3 vectorFirst, Vector3 vectorSecond)
		=> new Vector3
		(
			within(vectorFirst.x, vectorSecond.x),
			within(vectorFirst.y, vectorSecond.y),
			within(vectorFirst.z, vectorSecond.z)
		);

	// method: generate a random vector in the range within the two vectors given by the two given axes values //
	public static Vector3 vectorWithin(float vectorAxesValueFirst, float vectorAxesValueSecond)
		=> within(vectorAxesValueFirst, vectorAxesValueSecond).asVector();
	#endregion randomly generating within a given range
}