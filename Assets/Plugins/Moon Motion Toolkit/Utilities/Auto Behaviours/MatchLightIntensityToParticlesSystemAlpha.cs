using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Match Light Intensity To Particles System Alpha:
// • updates the intensity of the attached light to be the alpha value of the current color of the first particle of the attached particle system, multiplied by the specified factor
public class MatchLightIntensityToParticlesSystemAlpha : AutoBehaviour<MatchLightIntensityToParticlesSystemAlpha>
{
	// variables //

	
	// manual connections //
	[Tooltip("the particles system whose first particle's color's alpha value to base the light's intensity on")]
	public ParticleSystem particlesSystemOfAlpha;
	[Tooltip("the factor by which to multiply the alpha value to determine the intensity value")]
	public float factor = 1f;
	



	// at each update: //
	private void Update()
		=> setLightIntensityTo(particlesSystemOfAlpha.alphaOfFirstParticle() * factor);
}