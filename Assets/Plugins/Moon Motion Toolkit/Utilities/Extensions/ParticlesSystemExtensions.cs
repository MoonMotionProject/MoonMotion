using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Particles System Extensions: provides extension methods for handling particles systems //
public static class ParticlesSystemExtensions
{
	#region particles

	// method: get the current first particle of this given particles system //
	public static ParticleSystem.Particle firstParticle(this ParticleSystem particlesSystem)
	{
		ParticleSystem.Particle[] arrayOfOneParticle = New.arrayForCount<ParticleSystem.Particle>(1);
		particlesSystem.GetParticles(arrayOfOneParticle);
		return arrayOfOneParticle[0];
	}

	// method: get the color of the current first particle of this given particles system //
	public static Color colorOfFirstParticle(this ParticleSystem particlesSystem)
		=> particlesSystem.firstParticle().colorAsPartOf(particlesSystem);

	// method: get the alpha (from 0 to 1) of the current first particle of this given particles system //
	public static float alphaOfFirstParticle(this ParticleSystem particlesSystem)
		=> particlesSystem.firstParticle().alphaAsPartOf(particlesSystem);
	#endregion particles


	#region playing
	// method: have this given particles system play or stop according to the given boolean, then return this given particles system //
	public static ParticleSystem togglePlaying(this ParticleSystem particlesSystem, bool boolean)
	{
		if (boolean)
		{
			particlesSystem.play();
		}
		else
		{
			particlesSystem.stop();
		}

		return particlesSystem;
	}
	// method: have all of these given particles systems play or stop according to the given boolean, then return an enumerable of these given particles systems //
	public static IEnumerable<ParticleSystem> togglePlaying(this IEnumerable<ParticleSystem> particlesSystems, bool boolean)
		=> particlesSystems.forEach(particlesSystem =>
			particlesSystem.togglePlaying(boolean));
	public static GameObject togglePlayingDescendantParticlesSystems(this GameObject gameObject, bool boolean)
		=> gameObject.actUponDescendantParticlesSystems(descendantParticlesSystems =>
			descendantParticlesSystems.togglePlaying(boolean));

	// method: (according to the given boolean:) have this given particles system play, then return this given particles system //
	public static ParticleSystem play(this ParticleSystem particlesSystem, bool boolean = true)
	{
		if (boolean)
		{
			if (!particlesSystem.isPlaying)
			{
				particlesSystem.Play();
			}
		}

		return particlesSystem;
	}
	// method: (according to the given boolean:) have all of these given particles systems play, then return these given particles systems //
	public static IEnumerable<ParticleSystem> play(this IEnumerable<ParticleSystem> particlesSystems, bool boolean = true)
		=> particlesSystems.forEach(particlesSystem =>
			particlesSystem.play());
	public static GameObject playDescendantParticlesSystems(this GameObject gameObject, bool boolean = true)
		=> gameObject.actUponDescendantParticlesSystems(descendantParticlesSystems =>
			descendantParticlesSystems.play(boolean));

	// method: (according to the given boolean:) have this given particles system restart, then return this given particles system //
	public static ParticleSystem restart(this ParticleSystem particlesSystem, bool boolean = true)
	{
		if (boolean)
		{
			particlesSystem.Play();
		}

		return particlesSystem;
	}
	// method: (according to the given boolean:) have all of these given particles systems restart, then return these given particles systems //
	public static IEnumerable<ParticleSystem> restart(this IEnumerable<ParticleSystem> particlesSystems, bool boolean = true)
		=> particlesSystems.forEach(particlesSystem =>
			particlesSystem.restart());

	// method: (according to the given boolean:) have this given particles system stop, then return this given particles system //
	public static ParticleSystem stop(this ParticleSystem particlesSystem, bool boolean = true)
	{
		if (boolean)
		{
			particlesSystem.Stop();
		}

		return particlesSystem;
	}
	// method: (according to the given boolean:) have all of these given particles systems stop, then return these given particles systems //
	public static IEnumerable<ParticleSystem> stop(this IEnumerable<ParticleSystem> particlesSystems, bool boolean = true)
		=> particlesSystems.forEach(particlesSystem =>
			particlesSystem.stop());
	public static GameObject stopDescendantParticlesSystems(this GameObject gameObject, bool boolean = true)
		=> gameObject.actUponDescendantParticlesSystems(descendantParticlesSystems =>
			descendantParticlesSystems.stop(boolean));
	#endregion playing


	#region acting upon descendant particles systems

	public static GameObject actUponDescendantParticlesSystems(this GameObject gameObject, Action<List<ParticleSystem>> action)
		=> gameObject.after(()=>
			  action(gameObject.descendants<ParticleSystem>()));
	#endregion acting upon descendant particles systems
}