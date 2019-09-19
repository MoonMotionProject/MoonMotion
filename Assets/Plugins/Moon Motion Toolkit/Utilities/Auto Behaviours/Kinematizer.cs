using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Kinematizer:
// • controls the kinematicity of the attached rigidbody according to the dependencies setting
//   · a toggle setting controls whether this kinematizing is enabled
[RequireComponent(typeof(Rigidbody))]
public class Kinematizer : AutoBehaviour<Kinematizer>
{
	// variables //

	
	// settings //

	[Tooltip("whether kinematizing is currently enabled")]
	public bool kinematizingEnabled = true;

	#if MOON_MOTION_TOOLKIT
	[Tooltip("the dependencies by which to determine whether the attached rigidbody is kinematic")]
	[ReorderableList]
	public Dependency[] kinematizingDependencies;
	#endif




	// updating //

	
	// at each update: //
	private void Update()
		// kinematize the attached rigidbody according to the dependencies – if kinematizing is currently enabled //
		=>	setKinematicityTo
			(
				#if MOON_MOTION_TOOLKIT
				kinematizingDependencies.areMet(),
				#endif
				kinematizingEnabled
			);
}