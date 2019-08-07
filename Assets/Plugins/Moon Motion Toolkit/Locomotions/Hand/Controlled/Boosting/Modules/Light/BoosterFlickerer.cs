using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Flickerer
// • flickers the child lights based on the intensity and increment settings, as well as the module dependencies
//   · this overrides Booster Light functionality to toggle the attached light according to the module dependencies; the attached light may still flicker when the module dependencies are not met, just to a lower intensity (by default)
public class BoosterFlickerer : BoosterLight
{
	// variables //

	
	// variables for: flickering //
	[Header("Intensity Range")]
	public float intensityMin = 0f;		// setting: the min light intensity
	public float intensityMax = 1.3f;		// setting: the max light intensity
	[Header("Intensity Increment Range")]
	public float incrementMin = 0.15f;		// setting: the min increment for the light intensity
	public float incrementMax = 0.5f;      // setting: the max increment for the light intensity




	// updating //

	
	// at each update: //
	protected override void Update()
	{
		// flicker each child light //
		foreach (Light light in lights)
		{
			// setting lighting intensity - for when the dependencies are met //
			if (dependencies.areMet())
			{
				light.intensity = Mathf.Min(light.intensity + Random.Range(incrementMin, incrementMax), intensityMax - Random.Range(incrementMin, incrementMax));
			}
			// setting lighting intensity - for when the dependencies are not met //
			else
			{
				light.intensity = Mathf.Max(light.intensity - Random.Range(incrementMin, incrementMax), intensityMin);
			}
		}
	}
}