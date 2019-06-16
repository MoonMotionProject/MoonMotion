using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Particle Extensions: provides extension methods for handling particles //
public static class ParticleExtensions
{
	// method: determine the color of this given particle as part of the given particles system //
	public static Color colorAsPartOf(this ParticleSystem.Particle particle, ParticleSystem particlesSystem)
		=> particle.GetCurrentColor(particlesSystem);

	// method: determine the alpha (from 0 to 1) of this given particle as part of the given particles system //
	public static float alphaAsPartOf(this ParticleSystem.Particle particle, ParticleSystem particlesSystem)
		=> particle.colorAsPartOf(particlesSystem).as32Bit().alphaRatio();
}