using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lighting: provides functionality for handling lighting //
public static class Lighting
{
	public static Material skybox => RenderSettings.skybox;
	public static void setSkyboxTo(Material targetMaterial)
		=> RenderSettings.skybox = targetMaterial;

	public static float exposure => skybox.GetFloat("_Exposure");
	public static void setExposureTo(float targetExposure)
		=> skybox.SetFloat("_Exposure", targetExposure);
}