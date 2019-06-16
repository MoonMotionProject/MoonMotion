using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Component Shortcuts:
// #auto
// • state: provides this behaviour with automatically-connected properties to its game object's components' commonly-used state and any commonly-used state of those states, recursively
// • methods: provides this behaviour with commonly-used methods for its components
public abstract class AutomaticBehaviourLayerComponentShortcuts<AutomaticBehaviourT> :
					AutomaticBehaviourLayerComponents<AutomaticBehaviourT>
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	// properties/methods //

	
	// properties/methods for: audio //
	
	public new AudioClip audio
	{
		get {return audioSource.clip;}
		set {audioSource.clip = value;}
	}
	public bool audioPlaying
	{
		get {return audioSource.isPlaying;}
	}
	public float audioTime
	{
		get {return audioSource.time;}
		set {audioSource.time = value.clampedNonnegative();}
	}
	public float audioDuration
	{
		get {return audio.length;}
	}
	public AudioSource audioPlay()
	{
		audioSource.Play();

		return audioSource;
	}
	public AudioSource audioStop()
	{
		audioSource.Stop();

		return audioSource;
	}


	// properties/methods for: light //

	public float lightIntensity
	{
		get {return light.intensity;}
	}
	public Light setLightIntensityTo(float targetIntensity)
		=> light.setIntensityTo(targetIntensity);


	// properties for: rigidbody kinematicity //

	public bool kinematicity {get {return rigidbody.isKinematic;}}
	
	
	// methods for: rigidbody kinematizing //

	// method: (according to the given boolean:) set the kinematicity of this behaviour's rigidbody to the given kinematicity boolean, then return this behaviour's rigidbody //
	public Rigidbody setKinematicityTo(bool kinematicity, bool boolean = true)
		=> rigidbody.setKinematicityTo(kinematicity, boolean);

	// method: (according to the given boolean:) make this behaviour's rigidbody kinematic, then return this behaviour's rigidbody //
	public Rigidbody kinematize(bool boolean = true)
		=> rigidbody.kinematize(boolean);

	// method: (according to the given boolean:) make this behaviour's rigidbody nonkinematic, then return this behaviour's rigidbody //
	public Rigidbody nonkinematize(bool boolean = true)
		=> rigidbody.nonkinematize(boolean);


	// properties for: rigidbody movement //

	public Vector3 velocityDirection {get {return rigidbody.velocityDirection();}}

	public Vector3 angularVelocityAngling {get {return rigidbody.angularVelocityAngling();}}

	public float speed {get {return rigidbody.speed();} }

	public float angularSpeed {get {return rigidbody.angularSpeed();}}

	public Vector3 velocity {get {return rigidbody.velocity;}}

	public Vector3 angularVelocity {get {return rigidbody.angularVelocity;} }


	// methods for: rigidbody vectrals setting //

	// method: (according to the given boolean:) set the (directional) velocity direction of this given rigidbody to the given direction, then return this given rigidbody //
	public Rigidbody setVelocityDirectionTo(Vector3 direction, bool boolean = true)
		=> rigidbody.setVelocityTo(rigidbody.speed() * direction.vectral(), boolean);

	// method: (according to the given boolean:) set the (angular velocity) angling of this given rigidbody to the given (angular velocity) angling, then return this given rigidbody //
	public Rigidbody setAngularVelocityAnglingTo(Vector3 angling, bool boolean = true)
		=> rigidbody.setAngularVelocityTo(rigidbody.angularSpeed() * angling.vectral(), boolean);


	// methods for: rigidbody speeds setting //

	// method: (according to the given boolean:) set the (directional velocity) speed of this given rigidbody to the given speed, then return this given rigidbody //
	public Rigidbody setSpeedTo(float speed, bool boolean = true)
		=> rigidbody.setVelocityTo(speed * rigidbody.velocityDirection(), boolean);

	// method: (according to the given boolean:) hone the (directional velocity) speed of this given rigidbody by the given honing amount toward the given honing target amount, then return this given rigidbody //
	public Rigidbody honeSpeed(float honingTarget, float honingAmount, bool boolean = true)
		=> rigidbody.honeSpeed(honingTarget, honingAmount, boolean);

	// method: (according to the given boolean:) reduce the (directional velocity) speed of this given rigidbody by the given speed, then return this given rigidbody // //
	public Rigidbody slowSpeedBy(float speedReduction, bool boolean = true)
		=> rigidbody.slowSpeedBy(speedReduction, boolean);

	// method: (according to the given boolean:) set the angular (velocity) speed of this given rigidbody to the given speed, then return this given rigidbody //
	public Rigidbody setAngularSpeedTo(float angularSpeed, bool boolean = true)
		=> rigidbody.setAngularVelocityTo(angularSpeed * rigidbody.angularVelocityAngling(), boolean);


	// methods for: rigidbody velocities setting //

	// method: (according to the given boolean:) set this behaviour's rigidbody's (directional) velocity to the given (directional) velocity, then return this behaviour's rigidbody //
	public Rigidbody setVelocityTo(Vector3 velocity, bool boolean = true)
		=> rigidbody.setVelocityTo(velocity, boolean);

	// method: (according to the given boolean:) set this behaviour's rigidbody's angular velocity to the given angular velocity, then return this behaviour's rigidbody //
	public Rigidbody setAngularVelocityTo(Vector3 angularVelocity, bool boolean = true)
		=> rigidbody.setAngularVelocityTo(angularVelocity, boolean);

	// method: (according to the given boolean:) set this behaviour's rigidbody's directional and angular velocities to the given directional and angular velocities, then return this behaviour's rigidbody //
	public Rigidbody setVelocitiesTo(Vector3 directionalVelocity, Vector3 angularVelocity, bool boolean = true)
		=> rigidbody.setVelocitiesTo(directionalVelocity, angularVelocity, boolean);

	// method: (according to the given boolean:) set this behaviour's rigidbody's directional and angular velocities to the given (generic) velocity, then return this behaviour's rigidbody //
	public Rigidbody setVelocitiesTo(Vector3 velocity, bool boolean = true)
		=> rigidbody.setVelocitiesTo(velocity, boolean);


	// methods for: rigidbody velocities zeroing //

	// method: (according to the given boolean:) zero the (directional) velocity of this behaviour's rigidbody, then return this behaviour's rigidbody //
	public Rigidbody zeroVelocity(bool boolean = true)
		=> rigidbody.zeroVelocity(boolean);

	// method: (according to the given boolean:) zero the angulary velocity of this behaviour's rigidbody, then return this behaviour's rigidbody //
	public Rigidbody zeroAngularVelocity(bool boolean = true)
		=> rigidbody.zeroAngularVelocity(boolean);

	// method: (according to the given boolean:) zero the (directional and angular) velocities of this behaviour's rigidbody, then return this behaviour's rigidbody //
	public Rigidbody zeroVelocities(bool boolean = true)
		=> rigidbody.zeroVelocities(boolean);
}