using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lighting: provides functionality for handling lighting //
public static class Lighting
{
	// properties //

	public static Material skybox => RenderSettings.skybox;
	public static float exposure => skybox.GetFloat("_Exposure");




	// methods //

	
	// method: set the exposure of the lighting's skybox to the given target exposure //
	public static void setExposureTo(float targetExposure)
		=> skybox.SetFloat("_Exposure", targetExposure);
}