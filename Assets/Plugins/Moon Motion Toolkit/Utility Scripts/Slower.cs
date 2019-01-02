using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Slower:
// • slows the velocity of the attached rigidbody by the set speed, so long as the dependencies setting is met
//   · a toggle setting controls whether this slowing is enabled
[RequireComponent(typeof(Rigidbody))]
public class Slower : MonoBehaviour
{
	// variables //

	
	// variables for: slowing //
	private new Rigidbody rigidbody;		// connection - automatic: the attached rigidbody (to slow)
	public bool slowingEnabled = true;		// setting: whether slowing is currently enabled
	[Tooltip("the speed by which to reduce the attached rigidbody's velocity")]
	public float speedReduction = 666666f;		// setting: the speed by which to reduce the attached rigidbody's velocity
	[Tooltip("the dependencies combination by which to determine whether to slow the attached rigidbody")]
	public Dependencies.DependenciesCombination dependencies;		// setting: the dependencies combination by which to determine whether to slow the attached rigidbody




	// methods //

	
	// methods for: slowing //

	// method: determine the reduced speed amount for the given speed //
	private float reducedSpeedAmount(float previousSpeed)
	{
		return Mathf.Max(0f, (previousSpeed - speedReduction));
	}
	// method: determine the reduced velocity for the given velocity //
	private Vector3 reducedVelocityFor(Vector3 previousVelocity)
	{
		float newVelocityX = reducedSpeedAmount(previousVelocity.x);
		float newVelocityY = reducedSpeedAmount(previousVelocity.y);
		float newVelocityZ = reducedSpeedAmount(previousVelocity.z);

		return new Vector3(newVelocityX, newVelocityY, newVelocityZ);
	}
	// method: slow the attached rigidbody (reduce its speed by the set amount if the dependencies setting is met) //
	private void slow()
	{
		if (Dependencies.metFor(dependencies))
		{
			rigidbody.velocity = reducedVelocityFor(rigidbody.velocity);
		}
	}




	// updating //

	
	// before the start: //
	private void Awake()
	{
		// connect to the attached rigidbody //
		rigidbody = GetComponent<Rigidbody>();
	}

	// at each physics update: //
	private void FixedUpdate()
	{
		// if slowing is currently enabled: //
		if (slowingEnabled)
		{
			// slow the attached rigidbody //
			slow();
		}
	}
}