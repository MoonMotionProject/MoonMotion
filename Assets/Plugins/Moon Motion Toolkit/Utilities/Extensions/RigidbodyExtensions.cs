using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody Extensions: provides extension methods for handling rigidbodies //
public static class RigidbodyExtensions
{
	#region kinematicity

	// method: return the kinematicity of this given rigidbody //
	public static bool kinematicity(this Rigidbody rigidbody)
		=> rigidbody.isKinematic;

	// method: (according to the given boolean:) set the kinematicity of this given rigidbody to the given kinematicity boolean, then return this given rigidbody //
	public static Rigidbody setKinematicityTo(this Rigidbody rigidbody, bool kinematicity, bool boolean = true)
	{
		if (boolean)
		{
			rigidbody.isKinematic = kinematicity;
		}

		return rigidbody;
	}

	// method: (according to the given boolean:) make this given rigidbody kinematic, then return this given rigidbody //
	public static Rigidbody kinematize(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setKinematicityTo(true, boolean);

	// method: (according to the given boolean:) make this given rigidbody nonkinematic, then return this given rigidbody //
	public static Rigidbody nonkinematize(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setKinematicityTo(false, boolean);
	#endregion kinematicity


	#region gravitization

	// method: return the gravitization of this given rigidbody //
	public static bool gravitization(this Rigidbody rigidbody)
		=> rigidbody.useGravity;

	// method: (according to the given boolean:) set the gravitization of this given rigidbody to the given gravitization boolean, then return this given rigidbody //
	public static Rigidbody setGravitizationTo(this Rigidbody rigidbody, bool gravitization, bool boolean = true)
	{
		if (boolean)
		{
			rigidbody.useGravity = gravitization;
		}

		return rigidbody;
	}

	// method: (according to the given boolean:) make this given rigidbody use gravity, then return this given rigidbody //
	public static Rigidbody gravitize(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setGravitizationTo(true, boolean);

	// method: (according to the given boolean:) make this given rigidbody not use gravity, then return this given rigidbody //
	public static Rigidbody nongravitize(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setGravitizationTo(false, boolean);
	#endregion gravitization


	#region velocity vectrals (direction, for rotational velocity; angling, for angular velocity)

	// method: return the (directional) speed of this given rigidbody //
	public static Vector3 velocityDirection(this Rigidbody rigidbody)
		=> rigidbody.velocity.vectral();

	// method: (according to the given boolean:) set the (directional) velocity direction of this given rigidbody to the given direction, then return this given rigidbody //
	public static Rigidbody setVelocityDirectionTo(this Rigidbody rigidbody, Vector3 direction, bool boolean = true)
		=> rigidbody.setVelocityTo((rigidbody.speed() * direction.vectral()), boolean);

	// method: return the angular speed of this given rigidbody //
	public static Vector3 angularVelocityAngling(this Rigidbody rigidbody)
		=> rigidbody.angularVelocity.vectral();

	// method: (according to the given boolean:) set the (angular velocity) angling of this given rigidbody to the given (angular velocity) angling, then return this given rigidbody //
	public static Rigidbody setAngularVelocityAnglingTo(this Rigidbody rigidbody, Vector3 angling, bool boolean = true)
		=> rigidbody.setAngularVelocityTo((rigidbody.angularSpeed() * angling.vectral()), boolean);
	#endregion velocity vectrals (direction, for rotational velocity; angling, for angular velocity)


	#region speeds

	// method: return the (directional velocity) speed of this given rigidbody //
	public static float speed(this Rigidbody rigidbody)
		=> rigidbody.velocity.magnitude;

	// method: (according to the given boolean:) set the (directional velocity) speed of this given rigidbody to the given speed, then return this given rigidbody //
	public static Rigidbody setSpeedTo(this Rigidbody rigidbody, float speed, bool boolean = true)
		=> rigidbody.setVelocityTo((speed * rigidbody.velocityDirection()), boolean);

	// method: (according to the given boolean:) hone the (directional velocity) speed of this given rigidbody by the given honing amount toward the given honing target amount, then return this given rigidbody //
	public static Rigidbody honeSpeed(this Rigidbody rigidbody, float honingTarget, float honingAmount, bool boolean = true)
		=> rigidbody.setSpeedTo(rigidbody.speed().honed(honingTarget, honingAmount), boolean);

	// method: (according to the given boolean:) reduce the (directional velocity) speed of this given rigidbody by the given speed, then return this given rigidbody // //
	public static Rigidbody slowSpeedBy(this Rigidbody rigidbody, float speedReduction, bool boolean = true)
		=> rigidbody.honeSpeed(0f, speedReduction, boolean);

	// method: return the angular (velocity) speed of this given rigidbody //
	public static float angularSpeed(this Rigidbody rigidbody)
		=> rigidbody.angularVelocity.magnitude;

	// method: (according to the given boolean:) set the angular (velocity) speed of this given rigidbody to the given speed, then return this given rigidbody //
	public static Rigidbody setAngularSpeedTo(this Rigidbody rigidbody, float angularSpeed, bool boolean = true)
		=> rigidbody.setAngularVelocityTo((angularSpeed * rigidbody.angularVelocityAngling()), boolean);
	#endregion speeds


	#region velocities

	// method: (according to the given boolean:) set this given rigidbody's (directional) velocity to the given (directional) velocity, then return this given rigidbody //
	public static Rigidbody setVelocityTo(this Rigidbody rigidbody, Vector3 velocity, bool boolean = true)
	{
		if (boolean)
		{
			rigidbody.velocity = velocity;
		}

		return rigidbody;
	}

	// method: (according to the given boolean:) set this given rigidbody's angular velocity to the given angular velocity, then return this given rigidbody //
	public static Rigidbody setAngularVelocityTo(this Rigidbody rigidbody, Vector3 angularVelocity, bool boolean = true)
	{
		if (boolean)
		{
			rigidbody.angularVelocity = angularVelocity;
		}

		return rigidbody;
	}

	// method: (according to the given boolean:) set this given rigidbody's directional and angular velocities to the given directional and angular velocities, then return this given rigidbody //
	public static Rigidbody setVelocitiesTo(this Rigidbody rigidbody, Vector3 directionalVelocity, Vector3 angularVelocity, bool boolean = true)
		=> rigidbody.setVelocityTo(directionalVelocity, boolean).setAngularVelocityTo(angularVelocity, boolean);

	// method: (according to the given boolean:) set this given rigidbody's directional and angular velocities to the given (generic) velocity, then return this given rigidbody //
	public static Rigidbody setVelocitiesTo(this Rigidbody rigidbody, Vector3 velocity, bool boolean = true)
		=> rigidbody.setVelocitiesTo(velocity, velocity, boolean);

	// method: (according to the given boolean:) zero the (directional) velocity of this given rigidbody, then return this given rigidbody //
	public static Rigidbody zeroVelocity(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setVelocityTo(FloatsVector.zeroes, boolean);

	// method: (according to the given boolean:) zero the angulary velocity of this given rigidbody, then return this given rigidbody //
	public static Rigidbody zeroAngularVelocity(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setAngularVelocityTo(FloatsVector.zeroes, boolean);

	// method: (according to the given boolean:) zero the (directional and angular) velocities of this given rigidbody, then return this given rigidbody //
	public static Rigidbody zeroVelocities(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setVelocitiesTo(FloatsVector.zeroes, boolean);
	// method: (according to the given boolean:) zero the (directional and angular) velocities of this given game object's attached rigidbody, then return this given game object //
	public static GameObject zeroVelocities(this GameObject gameObject, bool boolean = true)
		=> gameObject.after(()=>
			gameObject.rigidbody().zeroVelocities(boolean));
	// method: (according to the given boolean:) zero the (directional and angular) velocities of this given component's attached rigidbody, then return this given component //
	public static ComponentT zeroVelocities<ComponentT>(this ComponentT component, bool boolean = true) where ComponentT : Component
		=> component.after(()=>
			component.rigidbody().zeroVelocities(boolean));
	#endregion velocities


	#region accelerating
	// methods: (should be called during FixedUpdate:) (according to the given boolean:) accelerate this given rigidbody by the given acceleration (which should not be a product from multiplication with an update interval), then return this given rigidbody //

	public static Rigidbody accelerateBy(this Rigidbody rigidbody, Vector3 acceleration, bool boolean = true)
	{
		if (boolean)
		{
			rigidbody.AddForce(acceleration, ForceMode.Acceleration);
		}

		return rigidbody;
	}
	public static Rigidbody accelerateBy(this Rigidbody rigidbody, float accelerationX, float accelerationY, float accelerationZ, bool boolean = true)
		=> rigidbody.accelerateBy(new Vector3(accelerationX, accelerationY, accelerationZ), boolean);
	#endregion accelerating
}