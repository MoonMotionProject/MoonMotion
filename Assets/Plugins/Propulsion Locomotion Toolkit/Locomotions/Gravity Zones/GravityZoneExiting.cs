using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gravity Zone Exiting
// • toggles player zonage (whether the player is within a gravity zone) upon exiting the all of the Gravity Zones (not necessarily exiting every one simultaneously, just becoming out of all of them)
//   · player zonage tracking and toggling here is achieved via the functionality for the same purpose in Gravity Zone
//     - the toggling used by Gravity Zone's functionality is for this case set here
//   · player zonage toggling upon exiting an individual Gravity Zone is handled by Gravity Zone, as well as for entry to an individual Gravity Zone
//   · provides a method for Gravity Zone by which to remove a gravity zone from the tracking here (upon a gravity zone being disabled on its end), as well as to toggle off the player zonage tracking if the player is no longer in a gravity zone
// • tracks the last time that the player was within nonzeroly affecting gravity zonage
// • optionally has Terrain Response play its liftoff audio as gravity zone exiting audio upon exiting the all of the Gravity Zones
//   · this optionally only plays if the player was just affected by gravity zonage right before exiting the all of the Gravity Zones
public class GravityZoneExiting : MonoBehaviour
{
	// variables //

	
	// variables for: instancing //
	public static GravityZoneExiting singleton;		// connection - automatic: the singleton instance of this class
	
	// variables for: player zonage tracking and toggling //
	private static Toggles.Toggling zonageToggling = Toggles.Toggling.toggleOff;		// setting: the toggling by which to toggle player zonage
	public static float lastTimeWithinNonzerolyAffectingGravityZonage = -Mathf.Infinity;		// tracking: the last time that the player was within nonzeroly affecting gravity zonage – initialized to negative infinity as a flag that the player has never been within affecting gravity zonage

	// variables for: playing audio for exiting the all of the Gravity Zones //
	[Header("Audio")]
	[Tooltip("whether to have Terrain Response play its liftoff audio as Gravity Zone exiting audio upon exiting the all of the Gravity Zones")]
	public bool playLiftoffAudioUponAllExit = true;		// setting: whether to have Terrain Response play its liftoff audio as Gravity Zone exiting audio upon exiting the all of the Gravity Zones
	[Tooltip("whether the audio for exiting the all of the Gravity Zones should only play if the player was nonzeroly (by at least some gravitizing force) affected right before exiting the all of the Gravity Zones")]
	public bool audioRequiresAffectation = true;		// setting: whether the audio for exiting the all of the Gravity Zones should only play if the player was nonzeroly (by at least some gravitizing force) affected right before exiting the all of the Gravity Zones
	private static float timeOfLastLiftoffAudioPlaying = 0f;		// tracking: the last time that the liftoff audio was played for exiting the all of the Gravity Zones (by which to determine if enough time has passed that such playing may happen again)
	
	
	
	
	// methods //

	
	// method: play audio for player exiting from the all of the Gravity Zones if applicable (and update tracking for the time of last playing accordingly) //
	private static void applicablyPlayAudioForExitFromTheAll()
	{
		if (singleton.playLiftoffAudioUponAllExit && (((Time.time - lastTimeWithinNonzerolyAffectingGravityZonage) <= 1f) || !singleton.audioRequiresAffectation))
		{
			if ((Time.time - timeOfLastLiftoffAudioPlaying) >= Audio.longestLengthInSet(TerrainResponse.singleton.liftoffAudioSet))
			{
				TerrainResponse.playRandomLiftoffAudio();

				timeOfLastLiftoffAudioPlaying = Time.time;
			}
		}
	}
	// method: toggle player zonage according to the toggling setting for player exiting from the all of the Gravity Zones (and first, track whether the player was affected right before last exiting the all; and after, play audio for player exiting from the all of the Gravity Zones if applicable) //
	private static void toggleZonageForPlayerExitFromTheAll()
	{
		GravityZone.toggleZonage(zonageToggling);
		
		applicablyPlayAudioForExitFromTheAll();
	}

	// method: remove the given disabled Gravity Zone's collider from the tracking, then if the player is no longer in a Gravity Zone: toggle off the player zonage tracking //
	public static void updateForDisabledZone(GravityZone gravityZone)
	{
		Collider gravityZoneCollider = gravityZone.collider;		// connect to the gravity zone's collider

		if (GravityZone.playerCollidingGravityZoneColliders.Contains(gravityZoneCollider))
		{
			GravityZone.playerCollidingGravityZoneColliders.Remove(gravityZoneCollider);
		}
		
		bool playerStillInAGravityZone = false;
		foreach (Collider collidingGravityZoneCollider in GravityZone.playerCollidingGravityZoneColliders)
		{
			if (collidingGravityZoneCollider && collidingGravityZoneCollider.gameObject)
			{
				playerStillInAGravityZone = true;
				break;
			}
		}
		if (!playerStillInAGravityZone)
		{
			toggleZonageForPlayerExitFromTheAll();
		}
	}




	// updating //


	// before the start: //
	private void Awake()
	{
		// connect to the singleton instance of this class //
		singleton = this;
	}

	// at each update: //
	private void Update()
	{
		// track the last time that the player was within nonzeroly affecting gravity zonage //
		if (GravityZone.playerWithinNonzerolyAffectingZonage())
		{
			lastTimeWithinNonzerolyAffectingGravityZonage = Time.time;
		}
	}

	// upon trigger entry: //
	private void OnTriggerEnter(Collider collider)
	{
		if (Hierarchy.selfOrAnyLevelParentWithLayer(collider, "Gravity Zone"))		// if the collider is owned by a Gravity Zone transform
		{
			GravityZone.playerCollidingGravityZoneColliders.Add(collider);		// track the Gravity Zone's collider as colliding with the player
		}
	}

	// upon trigger staying: //
	private void OnTriggerStay(Collider collider)
	{
		if (Hierarchy.selfOrAnyLevelParentWithLayer(collider, "Gravity Zone"))		// if the collider is owned by a Gravity Zone transform
		{
			// if this collider is not tracked as one of the Gravity Zones colliding with they player: //
			if (!GravityZone.playerCollidingGravityZoneColliders.Contains(collider))
			{
				GravityZone.playerCollidingGravityZoneColliders.Add(collider);		// track the Gravity Zone's collider as colliding with the player
			}
		}
	}

	// upon trigger exit: //
	private void OnTriggerExit(Collider collider)
	{
		if (Hierarchy.selfOrAnyLevelParentWithLayer(collider, "Gravity Zone"))		// if the collider is owned by a Gravity Zone transform
		{
			GravityZone.playerCollidingGravityZoneColliders.Remove(collider);		// untrack the Gravity Zone's collider as colliding with the player

			// if no Gravity Zones are tracked as colliding anymore: toggle player zonage //
			if (GravityZone.playerCollidingGravityZoneColliders.Count == 0)
			{
				toggleZonageForPlayerExitFromTheAll();
			}
		}
	}
}