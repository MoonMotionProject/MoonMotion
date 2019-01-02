﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Fuel Sputterer
// • provides fuel sputtering particles and audio for the parent booster (for when trying to boost but out of fuel)
//   · only plays particles when the particles dependencies setting is met
//   · only plays audio when the audio dependencies setting is met
public class BoosterFuelSputterer : BoosterModule
{
	// variables //

	
	// variables for: instancing //
	private static BoosterFuelSputterer left, right;		// tracking: fuel sputterer instances
	
	// variables for: particles //
	private ParticleSystem[] particlesSystems;		// connections - automatic: the particles systems for this fuel sputterer (determined by the children particles systems active before the start)

	// variables for: audio //
	private AudioSource audioSource;		// connection - automatic: the audio source on this fuel sputterer for playing fuel sputtering audio
	private AudioClip audioClip;        // connection - automatic: the fuel sputtering audio on this booster's audio source

	// variables for: dependencies //
	[Tooltip("the dependencies combination by which to condition whether the fuel sputtering particles play")]
	public Dependencies.DependenciesCombination particlesDependencies;		// setting: the dependencies combination by which to condition whether the fuel sputtering particles play
	[Tooltip("the dependencies combination by which to condition whether the fuel sputtering audio plays")]
	public Dependencies.DependenciesCombination audioDependencies;		// setting: the dependencies combination by which to condition whether the fuel sputtering audio plays
	
	
	
	
	// updating //

	
	// before the start: connect to this fuel sputterer's: particles system, audio source, audio //
	protected override void Awake()
	{
		base.Awake();

		particlesSystems = GetComponentsInChildren<ParticleSystem>();
		
		audioSource = GetComponent<AudioSource>();
		audioClip = audioSource.clip;
	}

	// at the start: connect to fuel sputterer instances //
	protected override void Start()
	{
		base.Start();
		
		if (leftHand)
		{
			left = this;
		}
		else
		{
			right = this;
		}
	}




	// methods //

	
	// method: sputter this fuel sputterer (play the particles and audio) //
	private void sputterThisSputterer()
	{
		// if the module dependencies are met: //
		if (Dependencies.metFor(dependenciesCombination))
		{
			// if the particles dependencies are met: play the particles //
			if (Dependencies.metFor(particlesDependencies))
			{
				foreach (ParticleSystem particlesSystem in particlesSystems)
				{
					if (particlesSystem && particlesSystem.gameObject && particlesSystem.gameObject.activeSelf)		// so long as the particles system and its object are even active
					{
						particlesSystem.Play();
					}
				}
			}

			// if the audio dependencies are met: play the audio //
			if (Dependencies.metFor(audioDependencies))
			{
				audioSource.PlayOneShot(audioClip);
			}
		}
	}
	
	// method: sputter the fuel sputterer corresponding to the given booster //
	public static void sputter(Booster booster)
	{
		if (booster.leftHand)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				left.sputterThisSputterer();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				right.sputterThisSputterer();
			}
		}
	}
}