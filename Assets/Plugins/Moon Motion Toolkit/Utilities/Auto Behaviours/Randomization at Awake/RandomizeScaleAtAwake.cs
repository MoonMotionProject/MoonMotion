using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Randomize Scale At Awake
public class RandomizeScaleAtAwake : AutoBehaviour<RandomizeScaleAtAwake>
{
	// variables //

	
	// settings //
	
	public float scaleAxesMin = 1f;
	public float scaleAxesMax = 10f;




	// updating //

	
	// before the start: //
	private void Awake()
		=> setLocalScaleTo(RandomlyGenerate.vectorWithin(scaleAxesMin, scaleAxesMax));
}