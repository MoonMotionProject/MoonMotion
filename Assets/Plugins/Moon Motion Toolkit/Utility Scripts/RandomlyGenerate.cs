using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Randomly Generate
// • provides a method for randomly generating a vector in a range
public static class RandomlyGenerate
{
	// methods //
	
	// method: generate a random vector in the range between the two given vectors //
	public static Vector3 vectorInRange(Vector3 vectorFirst, Vector3 vectorSecond)
	{
		float x = Random.Range(vectorFirst.x, vectorSecond.x);
		float y = Random.Range(vectorFirst.y, vectorSecond.y);
		float z = Random.Range(vectorFirst.z, vectorSecond.z);

		return new Vector3(x, y, z);
	}
}