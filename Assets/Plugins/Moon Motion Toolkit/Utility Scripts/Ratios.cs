using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ratios: provides methods for calculating ratios (mostly for use with Interpolation Curved) //
public static class Ratios
{
	// methods //
	
	
	// method: determine the progression of the given progressor (changing value) from the given start progression to the given end progression //
	public static float progressionOfFrom(float progressor, float start, float end)
	{
		return ((progressor - start) / (end - start));
	}

	// method: determine the progression of time from the given start progression to the given end progression //
	public static float progressionFrom(float start, float end)
	{
		return progressionOfFrom(Time.time, start, end);
	}
}