using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Kinematizer:
// • controls the kinematicity of the attached rigidbody according to the dependencies setting
//   · a toggle setting controls whether this kinematizing is enabled
[RequireComponent(typeof(Rigidbody))]
public class Kinematizer : MonoBehaviour
{
	// variables //

	
	// variables for: kinematizing //
	private new Rigidbody rigidbody;		// connection - automatic: the attached rigidbody (to kinematize)
	public bool kinematizingEnabled = true;		// setting: whether kinematizing is currently enabled
	[Tooltip("the dependencies combination by which to determine whether the attached rigidbody is kinematic")]
	public Dependencies.DependenciesCombination dependencies;		// setting: the dependencies combination by which to determine whether the attached rigidbody is kinematic




	// methods //

	
	// methods for: kinematizing //

	// method: kinematize the attached rigidbody (set the kinematicity of the attached rigidbody to whether the dependencies setting is met) //
	private void kinematize()
	{
		rigidbody.isKinematic = Dependencies.metFor(dependencies);
	}




	// updating //

	
	// before the start: //
	private void Awake()
	{
		// connect to the attached rigidbody //
		rigidbody = GetComponent<Rigidbody>();
	}

	// at each update: //
	private void Update()
	{
		// if kinematizing is currently enabled: //
		if (kinematizingEnabled)
		{
			// kinematize the attached rigidbody //
			kinematize();
		}
	}
}