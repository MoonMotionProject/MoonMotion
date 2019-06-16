﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody Extensions: provides extension methods for handling rigidbodies //
public static class RigidbodyExtensions
{
	// methods for: kinematizing //

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


	// methods for: velocity vectrals (direction, for rotational velocity; angling, for angular velocity) //

	// method: return the (directional) speed of this given rigidbody //
	public static Vector3 velocityDirection(this Rigidbody rigidbody)
		=> rigidbody.velocity.vectral();

	// method: return the angular speed of this given rigidbody //
	public static Vector3 angularVelocityAngling(this Rigidbody rigidbody)
		=> rigidbody.angularVelocity.vectral();

	// method: (according to the given boolean:) set the (directional) velocity direction of this given rigidbody to the given direction, then return this given rigidbody //
	public static Rigidbody setVelocityDirectionTo(this Rigidbody rigidbody, Vector3 direction, bool boolean = true)
		=> rigidbody.setVelocityTo((rigidbody.speed() * direction.vectral()), boolean);

	// method: (according to the given boolean:) set the (angular velocity) angling of this given rigidbody to the given (angular velocity) angling, then return this given rigidbody //
	public static Rigidbody setAngularVelocityAnglingTo(this Rigidbody rigidbody, Vector3 angling, bool boolean = true)
		=> rigidbody.setAngularVelocityTo((rigidbody.angularSpeed() * angling.vectral()), boolean);


	// methods for: speed //

	// method: return the (directional velocity) speed of this given rigidbody //
	public static float speed(this Rigidbody rigidbody)
		=> rigidbody.velocity.magnitude;

	// method: return the angular (velocity) speed of this given rigidbody //
	public static float angularSpeed(this Rigidbody rigidbody)
		=> rigidbody.angularVelocity.magnitude;

	// method: (according to the given boolean:) set the (directional velocity) speed of this given rigidbody to the given speed, then return this given rigidbody //
	public static Rigidbody setSpeedTo(this Rigidbody rigidbody, float speed, bool boolean = true)
		=> rigidbody.setVelocityTo((speed * rigidbody.velocityDirection()), boolean);

	// method: (according to the given boolean:) hone the (directional velocity) speed of this given rigidbody by the given honing amount toward the given honing target amount, then return this given rigidbody //
	public static Rigidbody honeSpeed(this Rigidbody rigidbody, float honingTarget, float honingAmount, bool boolean = true)
		=> rigidbody.setSpeedTo(rigidbody.speed().honed(honingTarget, honingAmount), boolean);

	// method: (according to the given boolean:) reduce the (directional velocity) speed of this given rigidbody by the given speed, then return this given rigidbody // //
	public static Rigidbody slowSpeedBy(this Rigidbody rigidbody, float speedReduction, bool boolean = true)
		=> rigidbody.honeSpeed(0f, speedReduction, boolean);

	// method: (according to the given boolean:) set the angular (velocity) speed of this given rigidbody to the given speed, then return this given rigidbody //
	public static Rigidbody setAngularSpeedTo(this Rigidbody rigidbody, float angularSpeed, bool boolean = true)
		=> rigidbody.setAngularVelocityTo((angularSpeed * rigidbody.angularVelocityAngling()), boolean);


	// methods for: velocities setting //

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


	// methods for: velocities zeroing //

	// method: (according to the given boolean:) zero the (directional) velocity of this given rigidbody, then return this given rigidbody //
	public static Rigidbody zeroVelocity(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setVelocityTo(Vectors.zeroesVector, boolean);

	// method: (according to the given boolean:) zero the angulary velocity of this given rigidbody, then return this given rigidbody //
	public static Rigidbody zeroAngularVelocity(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setAngularVelocityTo(Vectors.zeroesVector, boolean);

	// method: (according to the given boolean:) zero the (directional and angular) velocities of this given rigidbody, then return this given rigidbody //
	public static Rigidbody zeroVelocities(this Rigidbody rigidbody, bool boolean = true)
		=> rigidbody.setVelocitiesTo(Vectors.zeroesVector, boolean);
}