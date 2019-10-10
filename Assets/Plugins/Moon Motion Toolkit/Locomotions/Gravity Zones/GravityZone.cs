using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Gravity Zone: applies gravity-like force upon rigidbodies and particles in this zone
// • classifies this locomotion as the "gravity zone" locomotion; classifies this object as a "gravity zone"
// • a setting and methods are provided for toggling whether this gravity zone \ all gravity zones are gravitizing (actively applying force)
// • gravitizing rigidbodies:
//   · applies force upon objects of rigidbodies in this zone according to the gravitation force setting
//   · a toggle setting determines whether this gravity zone is currently gravitizing rigidbodies in particular (regardless of whether it is gravitizing particles)
//   · gravitizes only those rigidbodies that are set to "useGravity"
//   · when gravitizing the player, the force applied is multiplied by the player's current gravity modifier, as determined by any active Gravity Multipliers
//   /* performance of this feature can become noticeably poorer when using more than a few gravity zones (although the performance loss isn't close to as significant as that when gravitizing particles via multiple gravity zones) */
// • gravitizing particles:
//   · determines which particles are in this zone by means of the extending class of gravity zone shape (box or sphere)
//     /* gravitizing particles does not adjust to rotation of the gravity zone for box gravity zones */
//   · applies force upon particles in this zone according to the gravitation force setting
//   · a toggle setting determines whether this gravity zone is currently gravitizing particles in particular (regardless of whether it is gravitizing rigidbodies)
//   · force amount applied uses the particle system's "gravity modifier" value as a factor
//   /* performance of this feature is currently very poor for more than one gravity zone */
// • player zonage tracking and toggling:
//   · tracks whether the player is within a gravity zone, and whether they are currently within a gravity zone that is affecting them (for which a method is provided)
//   · tracks all gravity zones the player is currently colliding with; Gravity Zone Exiting updates this tracking
//   · when tracking entry, staying, and exit of rigidbodies to gravitize, tracks the zonage of the player rigidbody in particular
//     - toggles via the corresponding toggling setting
//     - this assumes that the player has only one rigidbody
//     - optionally has Terrain Response play its liftoff audio as gravity zone entry audio upon player entry into this Gravity Zones
//       – another setting toggles whether this Gravity Zone must be gravitizing currently for this audio to play
//   · player zonage toggling for player exit from all Gravity Zones is handled by Gravity Zone Exiting
//   · disabling then enabling this script or object while the player is inside results in player zonage tracking getting out of sync until reentering
//     - to toggle this gravity zone's functionality, toggle the provided setting for whether its gravitizing is enabled, instead
// • tracking is provided for all Gravity Zone instances
// • methods are provided to:
//   · toggle gravitizing for a particular gravity zone \ all gravity zones
//   · change a particular gravity zone's \ all gravity zones' gravitation force
//   · flip (invert the sign of on the y axis) a particular gravity zone's \ all gravity zones' gravitation force
public abstract class GravityZone : MonoBehaviour, ILocomotion
{
	// variables //

	
	// variables for: gravitizing rigidbodies and particles in general //
	[HideInInspector] public static List<GravityZone> instances = new List<GravityZone>();		// tracking: all gravity zone instances
	[Header("Gravitizing")]
	[Tooltip("whether gravitizing (of either rigidbodies or particles) by this Gravity Zone is allowed at all")]
	public bool gravitizingEnabled = true;		// setting: whether gravitizing (of either rigidbodies or particles) by this Gravity Zone is allowed at all
	[Tooltip("the force vector to apply to rigidbodies in this zone")]
	public Vector3 gravitationForce = new Vector3(0f, -4f, 0f);		// setting: the force vector to apply to rigidbodies in this zone
	
	// variables for: gravitizing rigidbodies //
	[Header("Gravitizing Rigidbodies")]
	[Tooltip("whether to gravitize rigidbodies in this gravity zone /* performance of this feature can become noticeably poorer when using more than a few gravity zones (although the performance loss isn't close to as significant as that when gravitizing particles via multiple gravity zones) */")]
	public bool gravitizeRigidbodies = true;		// setting: whether to gravitize rigidbodies in this gravity zone /* performance of this feature can become noticeably poorer when using more than a few gravity zones (although the performance loss isn't close to as significant as that when gravitizing particles via multiple gravity zones) */
	protected HashSet<Rigidbody> rigidbodiesToGravitize = new HashSet<Rigidbody>();		// tracking: rigidbodies of objects triggering collision in this zone

	// variables for: gravitizing particles //
	protected static ParticleSystem[] allParticlesSystems = new ParticleSystem[] {};		// tracking: all particles systems (tracked by just one gravity zone at a time, the first one – if any – that is set to gravitize particles, out of all the tracked Gravity Zone instances)
	[HideInInspector] public new Collider collider;		// connection - auto: the collider of this gravity zone
	[Header("Gravitizing Particles")]
	[Tooltip("whether or not to gravitize particles in this gravity zone /* performance of this feature is currently very poor for more than one gravity zone */ /* gravitizing particles does not adjust to rotation of the gravity zone for box gravity zones */")]
	public bool gravitizeParticles = true;		// setting: whether or not to gravitize particles in this gravity zone /* performance of this feature is currently very poor for more than one gravity zone */ /* gravitizing particles does not adjust to rotation of the gravity zone for box gravity zones */

	// variables for: player zonage tracking and toggling //
	[Header("Player Entry Audio")]
	[Tooltip("whether to have Terrain Response play its liftoff audio as gravity zone entry audio upon player entry into this gravity zone")]
	public bool playLiftoffAudioUponPlayerEntry = true;		// setting: whether to have Terrain Response play its liftoff audio as gravity zone entry audio upon player entry into this gravity zone
	[Tooltip("whether the audio for entry into this Gravity Zone should only play if this Gravity Zone is currently gravitizing")]
	public bool audioRequiresGravitizing = true;		// setting: whether the audio for entry into this Gravity Zone should only play if this Gravity Zone is currently gravitizing
	private Toggling playerEntryZonageToggling = Toggling.toggleOn;		// setting: the toggling by which to toggle player zonage upon entry
	private Toggling playerStayingZonageToggling = Toggling.toggleOn;		// setting: the toggling by which to toggle player zonage upon staying
	private Toggling playerExitZonageToggling = Toggling.noToggling;		// setting: the toggling by which to toggle player zonage upon exit
	public static HashSet<Collider> playerCollidingGravityZoneColliders = new HashSet<Collider>();		// tracking: Gravity Zone colliders that are currently colliding with the player
	private static bool playerWithinZonage = false;		// tracking: whether the player is currently within gravity zonage




	// methods //

	
	// methods for: gravitizing rigidbodies and particles in general //

	// method: toggle gravitizing for this gravity zone //
	public void toggleGravitizing()
	{
		gravitizingEnabled = !gravitizingEnabled;
	}
	// method: toggle gravitizing for the given gravity zone //
	public static void toggleGravitizing(GravityZone gravityZone)
	{
		gravityZone.toggleGravitizing();
	}
	// method: toggle gravitizing for all gravity zones //
	public static void toggleGravitizingForAll()
	{
		foreach (GravityZone gravityZone in instances)
		{
			gravityZone.toggleGravitizing();
		}
	}
	// method: toggle gravitizing for all gravity zones //
	public void toggleGravitizingForAll_()
	{
		toggleGravitizingForAll();
	}
	// method: change the gravitation force to the given force for this gravity zone //
	public void changeForce(Vector3 force)
	{
		gravitationForce = force;
	}
	// method: change the gravitation force to the given force for the given gravity zone //
	public static void changeForce(GravityZone gravityZone, Vector3 force)
	{
		gravityZone.changeForce(force);
	}
	// method: change the gravitation force to the given force for all gravity zones //
	public static void changeForceForAll(Vector3 force)
	{
		foreach (GravityZone instance in instances)
		{
			if (instance && instance.gameObject)
			{
				instance.changeForce(force);
			}
		}
	}
	// method: change the gravitation force to the given force for all gravity zones //
	public void changeForceForAll_(Vector3 force)
	{
		changeForceForAll(force);
	}
	// method: flip the gravitation force for this gravity zone //
	public void flipForce()
	{
		changeForce(new Vector3(gravitationForce.x, -gravitationForce.y, gravitationForce.z));
	}
	// method: flip the gravitation force for the given gravity zone //
	public static void flipForce(GravityZone gravityZone)
	{
		gravityZone.flipForce();
	}
	// method: flip the gravitation force for all gravity zones //
	public static void flipForceForAll()
	{
		foreach (GravityZone instance in instances)
		{
			if (instance && instance.gameObject)
			{
				instance.flipForce();
			}
		}
	}
	// method: flip the gravitation force for all gravity zones //
	public void flipForceForAll_(Vector3 force)
	{
		flipForceForAll();
	}


	// methods for: gravitizing rigidbodies //

	// method: gravitize all rigidbodies inside this gravity zone //
	protected virtual void gravitizeRigidbodiesInside()
	{
		// gravitize each of the tracked rigidbodies to gravitize by the force vector setting – and for the player, multiply the force to apply by the player's current gravity modifier as determined by any active Gravity Multipliers //
		foreach (Rigidbody rigidbodyToGravitize in rigidbodiesToGravitize)
		{
			if (!rigidbodyToGravitize.handHolding())       // so long as the rigidbody to gravitize is not currently held by a hand of the player
			{
				Vector3 forceToApply = gravitationForce;
				if (rigidbodyToGravitize.GetComponentInParent<Player>())
				{
					forceToApply *= GravityMultiplier.currentGravityModifier();
				}

				rigidbodyToGravitize.velocity += (forceToApply * Time.fixedDeltaTime);
			}
		}
	}
	

	// methods for: gravitizing particles //

	// method: update the tracking for all particles systems //
	private void trackAllParticlesSystems()
	{
		foreach (GravityZone instance in instances)
		{
			if (instance && instance.gravitizeParticles)
			{
				if (instance == this)
				{
					allParticlesSystems = FindObjectsOfType<ParticleSystem>();

					break;
				}
				else
				{
					break;
				}
			}
		}
	}
	// method: gravitize all particles inside this gravity zone //
	protected abstract void gravitizeParticlesInside();
	
	
	// methods for: player zonage toggling //
	
	// method: toggle the tracking of whether the player is within zonage according to the given toggling //
	public static void toggleZonage(Toggling toggling)
	{
		playerWithinZonage = playerWithinZonage.toggledBy(toggling);
	}
	// method: toggle player zonage according to this zone's zonage toggling for entering //
	private void toggleZonageForPlayerEntry()
	{
		toggleZonage(playerEntryZonageToggling);
	}
	// method: toggle player zonage according to this zone's zonage toggling for staying //
	private void toggleZonageForPlayerStaying()
	{
		toggleZonage(playerStayingZonageToggling);
	}
	// method: toggle player zonage according to this zone's zonage toggling for exiting //
	private void toggleZonageForPlayerExit()
	{
		toggleZonage(playerExitZonageToggling);
	}


	// methods for: player zonage tracking //

	// method: determine whether the player is within gravity zonage that is actually enabled to gravitize the player //
	public static bool playerWithinAffectingZonage()
	{
		if (!playerWithinZonage || (GravityMultiplier.currentGravityModifier() == 0f))
		{
			return false;
		}
		else
		{
			foreach (Collider playerCollidingGravityZoneCollider in playerCollidingGravityZoneColliders)
			{
				GravityZone playerCollidingGravityZone = playerCollidingGravityZoneCollider.GetComponent<GravityZone>();
				if (playerCollidingGravityZone.gravitizingEnabled && playerCollidingGravityZone.gravitizeRigidbodies)
				{
					return true;
				}
			}
			return false;
		}
	}
	// method: determine whether the player is within gravity zonage that is actually enabled to gravitize the player with a nonzero force, or the scene has a nonzero gravitation force /* the scene gravity possibility is inconsistent to consider here, but convenient for now */ //
	public static bool playerWithinNonzerolyAffectingZonage()
	{
		if (Physics.gravity != FloatsVector.zeroes)
		{
			return true;
		}
		if (!playerWithinZonage || (GravityMultiplier.currentGravityModifier() == 0f))
		{
			return false;
		}
		else
		{
			foreach (Collider playerCollidingGravityZoneCollider in playerCollidingGravityZoneColliders)
			{
				GravityZone playerCollidingGravityZone = playerCollidingGravityZoneCollider.GetComponent<GravityZone>();
				if (playerCollidingGravityZone.gravitizingEnabled && playerCollidingGravityZone.gravitizeRigidbodies && (playerCollidingGravityZone.gravitationForce != FloatsVector.zeroes))
				{
					return true;
				}
			}
			return false;
		}
	}
	// method: determine whether the player is within box gravity zonage that is actually enabled to gravitize the player //
	public static bool playerWithinAffectingZonageBox()
	{
		if (!playerWithinZonage || (GravityMultiplier.currentGravityModifier() == 0f))
		{
			return false;
		}
		else
		{
			foreach (Collider playerCollidingGravityZoneCollider in playerCollidingGravityZoneColliders)
			{
				GravityZone playerCollidingGravityZone = playerCollidingGravityZoneCollider.GetComponent<GravityZone>();
				if (playerCollidingGravityZone.gravitizingEnabled && playerCollidingGravityZone.gravitizeRigidbodies && playerCollidingGravityZoneCollider.GetComponent<GravityZoneBox>())
				{
					return true;
				}
			}
			return false;
		}
	}
	// method: determine whether the player is within box gravity zonage that is actually enabled to gravitize the player with a nonzero force, or the scene has a nonzero gravitation force /* the scene gravity possibility is inconsistent to consider here, but convenient for now */ //
	public static bool playerWithinNonzerolyAffectingZonageBox()
	{
		if (Physics.gravity != FloatsVector.zeroes)
		{
			return true;
		}
		if (!playerWithinZonage || (GravityMultiplier.currentGravityModifier() == 0f))
		{
			return false;
		}
		else
		{
			foreach (Collider playerCollidingGravityZoneCollider in playerCollidingGravityZoneColliders)
			{
				GravityZone playerCollidingGravityZone = playerCollidingGravityZoneCollider.GetComponent<GravityZone>();
				if (playerCollidingGravityZone.gravitizingEnabled && playerCollidingGravityZone.gravitizeRigidbodies && (playerCollidingGravityZone.gravitationForce != FloatsVector.zeroes) && playerCollidingGravityZoneCollider.GetComponent<GravityZoneBox>())
				{
					return true;
				}
			}
			return false;
		}
	}
	// method: determine whether the player is within spherical gravity zonage that is actually enabled to gravitize the player //
	public static bool playerWithinAffectingZonageSphere()
	{
		if (!playerWithinZonage || (GravityMultiplier.currentGravityModifier() == 0f))
		{
			return false;
		}
		else
		{
			foreach (Collider playerCollidingGravityZoneCollider in playerCollidingGravityZoneColliders)
			{
				GravityZone playerCollidingGravityZone = playerCollidingGravityZoneCollider.GetComponent<GravityZone>();
				if (playerCollidingGravityZone.gravitizingEnabled && playerCollidingGravityZone.gravitizeRigidbodies && playerCollidingGravityZoneCollider.GetComponent<GravityZoneSphere>())
				{
					return true;
				}
			}
			return false;
		}
	}
	// method: determine whether the player is within spherical gravity zonage that is actually enabled to gravitize the player with a nonzero force //
	public static bool playerWithinNonzerolyAffectingZonageSphere()
	{
		if (!playerWithinZonage || (GravityMultiplier.currentGravityModifier() == 0f))
		{
			return false;
		}
		else
		{
			foreach (Collider playerCollidingGravityZoneCollider in playerCollidingGravityZoneColliders)
			{
				GravityZone playerCollidingGravityZone = playerCollidingGravityZoneCollider.GetComponent<GravityZone>();
				if (playerCollidingGravityZone.gravitizingEnabled && playerCollidingGravityZone.gravitizeRigidbodies && (playerCollidingGravityZone.gravitationForce != FloatsVector.zeroes) && playerCollidingGravityZoneCollider.GetComponent<GravityZoneSphere>())
				{
					return true;
				}
			}
			return false;
		}
	}
	
	
	
	
	// updating //


	// before the start: //
	protected virtual void Awake()
	{
		// connect to the collider of this gravity zone //
		collider = GetComponent<Collider>();
	}

	// upon being enabled: ensure this gravity zone is tracked as one of the instances //
	private void OnEnable()
	{
		if (!instances.Contains(this))
		{
			instances.Add(this);
		}
	}
	// upon being disabled: ensure this gravity zone is not tracked as one of the instances, have Gravity Zone Exiting update as well //
	private void OnDisable()
	{
		if (instances.Contains(this))
		{
			instances.Remove(this);
		}
		GravityZoneExiting.updateForDisabledZone(this);
	}

	// at each physics update: //
	private void FixedUpdate()
	{
		// code for: gravitizing rigidbodies, gravitizing particles //
		if (gravitizingEnabled)
		{
			// code for: gravitizing rigidbodies //
			if (gravitizeRigidbodies)
			{
				// remove any tracked rigidbodies to gravitize that have become null or are no longer set to use gravity //
				/* this must be done the hard way, because of: https://issuetracker.unity3d.com/issues/hashset-dot-removewhere-does-not-correctly-evaluate-null-for-gameobjects-in-builds */
				bool continueCheckingToRemoveRigidbodies = true;
				while (continueCheckingToRemoveRigidbodies)
				{
					continueCheckingToRemoveRigidbodies = false;

					foreach (Rigidbody rigidbodyToGravitize in rigidbodiesToGravitize)
					{
						if (!rigidbodyToGravitize || !rigidbodyToGravitize.useGravity)
						{
							rigidbodiesToGravitize.Remove(rigidbodyToGravitize);
							continueCheckingToRemoveRigidbodies = true;
							break;
						}
					}
				}
				
				// gravitize all rigidbodies inside this gravity zone //
				gravitizeRigidbodiesInside();
			}

			// code for: gravitizing particles //
			if (gravitizeParticles)
			{
				// update the tracking for all particles systems //
				trackAllParticlesSystems();

				// gravitize all particles inside this gravity zone //
				gravitizeParticlesInside();
			}
		}
	}

	// upon trigger entry: //
	private void OnTriggerEnter(Collider collider)
	{
		// code for: gravitizing rigidbodies, player zonage toggling //
		
		// track any potential rigidbody (local or parent) of the given collider for being gravitized – if it has not been tracked yet //
		Transform rigidbodyTransform = collider.selfOrAncestorTransformWith<Rigidbody>();		// find the transform of this collider's rigidbody, if it has one locally or as a parent; otherwise, determine no transform (null) for this collider's rigidbody transform
		if (rigidbodyTransform)			// if this collider does have a rigidbody (by checking the determined rigidbody transform)
		{
			// determine the rigidbody of this collider (based on the determined rigidbody transform) //
			Rigidbody rigidbodyOfCollider = rigidbodyTransform.GetComponent<Rigidbody>();

			// if: this rigidbody is set to use gravity, this rigidbody has not yet been tracked as one of the rigidbodies to gravitize: // 
			if (rigidbodyOfCollider.useGravity && !rigidbodiesToGravitize.Contains(rigidbodyOfCollider))
			{
				// track this collider's rigidbody as one of the rigidbodies to gravitize //
				rigidbodiesToGravitize.Add(rigidbodyOfCollider);
				
				// if this collider belongs to the player: //
				if (collider.GetComponentInParent<Player>())
				{
					// toggle the player zonage according to this zone's entry toggling //
					toggleZonageForPlayerEntry();

					// if Terrain Response's liftoff audio is set to play upon player entry into this gravity zone: //
					if (playLiftoffAudioUponPlayerEntry && (gravitizingEnabled || !audioRequiresGravitizing))
					{
						// have Terrain Response play random liftoff audio //
						TerrainResponse.playRandomLiftoffAudio();
					}
				}
			}
		}
	}

	// upon trigger staying: //
	private void OnTriggerStay(Collider collider)
	{
		// code for: gravitizing rigidbodies, player zonage toggling //
		
		// track any potential rigidbody (local or parent) of the given collider for being gravitized – if it has not been tracked yet //
		Transform rigidbodyTransform = collider.selfOrAncestorTransformWith<Rigidbody>();		// find the transform of this collider's rigidbody, if it has one locally or as a parent; otherwise, determine no transform (null) for this collider's rigidbody transform
		if (rigidbodyTransform)			// if this collider does have a rigidbody (by checking the determined rigidbody transform)
		{
			// determine the rigidbody of this collider (based on the determined rigidbody transform) //
			Rigidbody rigidbodyOfCollider = rigidbodyTransform.GetComponent<Rigidbody>();

			// if this rigidbody is set to use gravity: //
			if (rigidbodyOfCollider.useGravity)
			{
				// if this rigidbody has not yet been tracked as one of the rigidbodies to gravitize: //
				if (!rigidbodiesToGravitize.Contains(rigidbodyOfCollider))
				{
					// track this collider's rigidbody as one of the rigidbodies to gravitize //
					rigidbodiesToGravitize.Add(rigidbodyOfCollider);
				}
				
				// if this collider belongs to the player: //
				if (collider.GetComponentInParent<Player>())
				{
					// toggle the player zonage according to this zone's staying toggling //
					toggleZonageForPlayerStaying();
				}
			}
			// otherwise: if this rigidbody has been tracked as one of the rigidbodies to gravitize (but is no longer set to use gravity): //
			else if (rigidbodiesToGravitize.Contains(rigidbodyOfCollider))
			{
				// untrack this collider's rigidbody as one of the rigidbodies to gravitize //
				rigidbodiesToGravitize.Remove(rigidbodyOfCollider);

				// if this collider belongs to the player: //
				if (collider.GetComponentInParent<Player>())
				{
					// toggle the player zonage according to this zone's exit toggling //
					toggleZonageForPlayerExit();
				}
			}
		}
	}

	// upon trigger exit: //
	private void OnTriggerExit(Collider collider)
	{
		// code for: agravitizing rigidbodies, player zonage toggling //
		
		// untrack any potential rigidbody (local or parent) of the given collider for being gravitized – if it is currently tracked //
		Transform rigidbodyTransform = collider.selfOrAncestorTransformWith<Rigidbody>();		// find the transform of this collider's rigidbody, if it has one locally or as a parent; otherwise, determine no transform (null) for this collider's rigidbody transform
		if (rigidbodyTransform)		// if this collider does have a rigidbody (by checking the determined rigidbody transform)
		{
			// determine the rigidbody of this collider (based on the determined rigidbody transform) //
			Rigidbody rigidbodyOfCollider = rigidbodyTransform.GetComponent<Rigidbody>();

			// if this rigidbody is tracked as one of the rigidbodies to gravitize: //
			if (rigidbodiesToGravitize.Contains(rigidbodyOfCollider))
			{
				// untrack this rigidbody as one of the rigidbodies to gravitize //
				rigidbodiesToGravitize.Remove(rigidbodyOfCollider);

				// if this collider belongs to the player: toggle the player zonage according to this zone's exit toggling //
				if (collider.GetComponentInParent<Player>())
				{
					toggleZonageForPlayerExit();
				}
			}
		}
	}
}