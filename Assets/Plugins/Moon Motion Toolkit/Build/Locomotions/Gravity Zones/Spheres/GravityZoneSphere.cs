using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Gravity Zone Sphere
// • classifies this gravity zone as a sphere-shaped gravity zone
// /* assumes the sphere is scaled evenly between all axes */
// • provides an additional, attractive (to the center of this spherical gravity zone) force
//   · provides a toggle for whether the attractive force is enabled
//   · provides settings for the max amount of the attractive force and the curve for the attractive force (curved from the center of this spherical gravity zone to its edge)
//   · this force does not affect determination of whether the player is currently within affecting gravity zonage
// • handles the detection of particles in this gravity zone according to its spherical shape, by which a method is provided to the parent class to gravitize all particles in this gravity zone
public class GravityZoneSphere : GravityZone
{
	// variables //
	
	
	// variables for: gravitizing rigidbodies and particles in general //
	[Header("Attractive Gravitizing")]
	[Tooltip("whether attraction is enabled currently; attraction is another force additional to the constant, directional 'gravitizing' force; the force of attraction is to the center of this spherical gravity zone, curved in amount to the edge of the zone")]
	public bool attractionEnabled = false;		// setting: whether attraction is enabled currently; attraction is another force additional to the constant, directional 'gravitizing' force; the force of attraction is to the center of this spherical gravity zone, curved in amount to the edge of the zone
	[Tooltip("the attractive force amount to apply, curved by the set attraction curve from the center of this spherical gravity zone to its edge")]
	public float attractiveForce = 0f;		// setting: the attractive force amount to apply, curved by the set attraction curve from the center of this spherical gravity zone to its edge
	[Tooltip("the attraction curve by which to curve the attractive force amount to apply, from the center of this spherical gravity zone to its edge")]
	public InterpolationCurve attractionCurve = InterpolationCurve.quadratic;		// setting: the attraction curve by which to curve the attractive force amount to apply, from the center of this spherical gravity zone to its edge
	
	
	// variables for: gravitizing particles //
	private SphereCollider sphereCollider;		// connection - auto: this gravity zone's sphere collider

	


	// methods //
	
	
	// methods for: gravitizing rigidbodies and particles in general //

	// method: determine the length of the radius of this spherical gravity zone //
	/* assumes the sphere is scaled evenly between all axes */
	private float radiusLength()
	{
		float averageScale = transform.lossyScale.average();
		return (averageScale * sphereCollider.radius);
	}
	// method: determine the curved attractive force to apply for the given object position //
	private Vector3 curvedAttractiveForceForPosition(Vector3 objectPosition)
		=> objectPosition.attractionTo(transform, attractiveForce, radiusLength(), attractionCurve);


	// methods for: gravitizing rigidbodies //

	// method: gravitize all rigidbodies inside this gravity zone //
	protected override void gravitizeRigidbodiesInside()
	{
		base.gravitizeRigidbodiesInside();

		// if attraction is currently enabled: //
		if (attractionEnabled)
		{
			// gravitize each of the tracked rigidbodies to gravitize by the calculation of the attractive force according to its position – and for the player, multiply the force to apply by the player's current gravity modifier as determined by any active Gravity Multipliers //
			foreach (Rigidbody rigidbodyToGravitize in rigidbodiesToGravitize)
			{
				if (!rigidbodyToGravitize.handHolding())		// so long as the rigidbody to gravitize is not currently held by a hand of the player
				{
					// determine the curved attractive force to apply //
					Vector3 forceToApply = curvedAttractiveForceForPosition(rigidbodyToGravitize.position);
					if (rigidbodyToGravitize.GetComponentInParent<Player>())
					{
						forceToApply *= GravityMultiplier.currentGravityModifier();
					}

					// apply the attractive force //
					rigidbodyToGravitize.velocity += (forceToApply * Time.fixedDeltaTime);
				}
			}
		}
	}

	
	// methods for: gravitizing particles //

	// method: gravitize all particles inside this gravity zone //
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
				for (int particleIndex = 0; particleIndex < particlesCount; particleIndex++)
				{
					// if the particle's distance from this gravity zone's center is within the sphere collider's radius: adjust its velocity by both the gravitation force and the attractive force (both factored by the particle system's "gravity modifier" value) //
					if (Vector3.Distance(particles[particleIndex].position, transform.position) <= radiusLength())
					{
						// apply the gravitation force //
						particles[particleIndex].velocity += (gravitationForce * gravityModifier * Time.fixedDeltaTime);
					
						// if attraction is currently enabled: //
						if (attractionEnabled)
						{
							// apply the attractive force //
							particles[particleIndex].velocity += (curvedAttractiveForceForPosition(particles[particleIndex].position) * gravityModifier * Time.fixedDeltaTime);
						}
					}
				}
				particlesSystem.SetParticles(particles, particlesCount);		// set the particles system's particles to the changed version of its particles
			}
		}
	}




	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to this gravity zone's sphere collider //
		sphereCollider = GetComponent<SphereCollider>();
	}
}