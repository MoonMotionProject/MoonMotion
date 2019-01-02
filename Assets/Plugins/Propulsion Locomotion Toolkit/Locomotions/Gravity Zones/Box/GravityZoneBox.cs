using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gravity Zone Box
// • classifies this gravity zone as a box-shaped gravity zone
// • handles the detection of particles in this gravity zone according to its box shape, by which a method is provided to the parent class to gravitize all particles in this gravity zone
//   /* does not adjust to rotation of the gravity zone */
public class GravityZoneBox : GravityZone
{
	// methods //

	
	// methods for: gravitizing particles //

	// method: gravitize all particles inside this gravity zone //		/* does not adjust to rotation of the gravity zone */
	protected override void gravitizeParticlesInside()
	{
		foreach (ParticleSystem particlesSystem in allParticlesSystems)		// iterate through each of all the existing particles systems
		{
			// determine this particles system's gravity modifier //
			float gravityModifier = particlesSystem.main.gravityModifierMultiplier;

			// if this particles system's gravity modifier is nonzero: //
			if (gravityModifier != 0f)
			{
				// get a connection to this system's particles and determine its particles count //
				ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particlesSystem.main.maxParticles];
				int particlesCount = particlesSystem.GetParticles(particles);
				
				// for each particle in this system that is inside this zone's collider, adjust its velocity by the gravitation force (factored by the particle system's "gravity modifier" value) //
				/* does not adjust to rotation of the gravity zone */
				for (int particleIndex = 0; particleIndex < particlesCount; particleIndex++)
				{
					// determine relevant positions //
					float particlePositionX = particles[particleIndex].position.x;
					float particlePositionY = particles[particleIndex].position.y;
					float particlePositionZ = particles[particleIndex].position.z;
					Vector3 colliderBoundsMin = collider.bounds.min;
					Vector3 colliderBoundsMax = collider.bounds.max;

					// if the particle is within the collider's bounds: adjust its velocity by the gravitation force (factored by the particle system's "gravity modifier" value) //
					/* does not adjust to rotation of the gravity zone */
					bool particleWithinColliderBoundsX = ((particlePositionX >= colliderBoundsMin.x) && (particlePositionX <= colliderBoundsMax.x));
					bool particleWithinColliderBoundsY = ((particlePositionY >= colliderBoundsMin.y) && (particlePositionY <= colliderBoundsMax.y));
					bool particleWithinColliderBoundsZ = ((particlePositionZ >= colliderBoundsMin.z) && (particlePositionZ <= colliderBoundsMax.z));
					if (particleWithinColliderBoundsX && particleWithinColliderBoundsY && particleWithinColliderBoundsZ)
					{
						particles[particleIndex].velocity += (gravitationForce * gravityModifier * Time.fixedDeltaTime);
					}
				}
				particlesSystem.SetParticles(particles, particlesCount);		// set the particles system's particles to the changed version of its particles
			}
		}
	}
}