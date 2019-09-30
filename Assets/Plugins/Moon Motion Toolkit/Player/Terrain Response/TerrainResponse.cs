using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using NaughtyAttributes;

// Terrain Response
// • enumerates recognized terrain types
// • specifies recognized terrain layers (including both ground terrain layers and nonground terrain layers such as for walls) for this player
// • detects landing and liftoff based on this body/player's collision with one of the specified recognized layers
//   · plays feedback for either scenario:
//     - plays audio for either scenario
//     - plays vibration (for both controllers) upon landing
//     - this feedback is only played when the feedback dependencies are met
//     - spam reduction settings prevent feedback attempts too recent with each other
//     - this feedback is only played when the player's speed is past a set threshold
//   · broadcasts landing and liftoff events for additional effects externally
//     - also broadcasts terraining\unterraining and grounding\ungrounding events (which are more particular with the added requirement of the raycasting result changing such that the terrain must be in the player's down direction (and for grounding, also a ground terrain layer in particular is also required), instead of merely a change in collision)
// • tracks terrains currently collided with
// • provides determination of whether this body/player is currently: collided (colliding with any recognized terrain), grounded (colliding with a recognized ground terrain)
//   · limits this determination based on not only whether such collision is tracked, but also based on a raycast down from the player's body at the time of determination, such that only terrain directly down relative to the player's body is considered (so that it doesn't count if the player is touching walls with the side of their body, etc.)
//     - the collision raycasting range can be set
//     - "down" is relative to the player so as to be compatible with player rotation such as with the flipping locomotion
//   · via Dependencies, this determines\allows such things as Booster Diminisher's booster diminishing, other booster modules' toggles, etc.
// • provides tracking for whether the player was just:
//   · terrained
//   · grounded
// • provides methods for playing a random landing\liftoff audio, respectively
// • provides methods for determining whether the player is within a given distance to terrain below, as well as for the player being within air nonrushing distance to terrain below (a condition for Air Rushing Audio, hooked up via Dependencies)
public class TerrainResponse : SingletonBehaviour<TerrainResponse>
{
	#region enumerations


	// enumeration of: recognized terrain types //
	public enum RecognizedTerrainType
	{
		any,
		groundOnly,
		nongroundOnly
	}
	#endregion enumerations




	#region variables


	#region settings for: recognized layers handling

	[BoxGroup("Recognized Layers (for feedback, booster diminishing, ...)")]
	[Header("Ground Terrain")]
	[Tooltip("array of text specifications for recognized ground terrain layer names")]
	[ReorderableList]
	public string[] recognizedGroundTerrainLayerNames = new string[] {"Terrain - Ground", "Booster Antidiminishor"};

	[BoxGroup("Recognized Layers (for feedback, booster diminishing, ...)")]
	[Header("Nonground Terrain")]
	[Tooltip("array of text specifications for recognized nonground terrain layer names")]
	[ReorderableList]
	public string[] recognizedNongroundTerrainLayerNames = new string[] {"Terrain - Nonground"};
	#endregion settings for: recognized layers handling


	#region variables for: raycasting in general

	[BoxGroup("Raycasting")]
	[Header("Source")]
	[Tooltip("the body transform from which to raycast")]
	public Transform bodyTransform;

	[Tooltip("the collision raycasting raise (height above the player body's position from which to start raycasting from (don't worry – player layer objects will not block detection of terrain)) by which to ensure that any object immediately below the player is beneath the starting point of raycasts")]
	private static float raycastingRaise = .01f;
	#endregion variables for: raycasting in general


	#region trackings for: collided terrains tracking and groundedness determination

	[Tooltip("all collided terrains (including both: all collided ground terrains, all collided nonground terrains)")]
	[HideInInspector] public static HashSet<GameObject> collidedTerrains = new HashSet<GameObject>();

	[Tooltip("all collided ground terrains")]
	[HideInInspector] public static HashSet<GameObject> collidedGroundTerrains = new HashSet<GameObject>();

	[Tooltip("all collided nonground terrains")]
	[HideInInspector] public static HashSet<GameObject> collidedNongroundTerrains = new HashSet<GameObject>();
	#endregion trackings for: collided terrains tracking and groundedness determination


	#region settings for: collision determination

	[BoxGroup("Raycasting")]
	[Header("Terrain Collision Determination")]
	[Tooltip("the max range of the raycasting from the bottom of the player's body within which to allow the player to be considered collided with a certain terrain")]
	public float raycastingRange = .01f;

	public static bool playerWasJustTerrained, playerWasJustGrounded;		// tracking: whether the player was just terrrarined\grounded (respectively) last frame

	private static bool playerIsTerrained, playerIsGrounded;        // tracking: whether the player is currently terrained\grounded (respectively) – used to set the corresponding trackings for whether the player was just terrained\grounded, and may be inaccurate for the current frame depending on whether the Terrain Response singleton has updated for the current frame yet
	#endregion settings for: collision determination


	#region variables for: feedback

	[BoxGroup("Feedback")]
	[Header("Interval")]
	[Tooltip("the min duration allowed between attempted playings of landing or liftoff feedback (of the same type (landing\\liftoff)), to reduce spamming")]
	public float minFeedbackInterval = .3f;

	[BoxGroup("Feedback")]
	[Header("Audio")]
	[Tooltip("array of landing audios (to randomly play one of upon landing)")]
	[ReorderableList]
	public AudioClip[] landingAudioSet;

	[BoxGroup("Feedback")]
	[Tooltip("array of liftoff audios (to randomly play one of upon liftoff)")]
	[ReorderableList]
	public AudioClip[] liftoffAudioSet;

	[BoxGroup("Feedback")]
	[Header("Vibration")]
	[Tooltip("the duration to use for landing vibration feedback")]
	public float vibrationDuration = .07f;

	[BoxGroup("Feedback")]
	[Tooltip("the intensity to use for landing vibration feedback")]
	public ushort vibrationIntensity = 1500;

	[BoxGroup("Feedback")]
	[Header("Conditions")]
	[Tooltip("the dependencies by which to allow landing and liftoff feedback")]
	[ReorderableList]
	public Dependency[] dependenciesFeedback;

	[BoxGroup("Feedback")]
	[Tooltip("the min speed of the player that is required for landing and liftoff feedback to play when the player is not boosting (to reduce feedback spamming when merely treading, skiing, etc. instead of boosting)")]
	public float feedbackNonboostingSpeedThreshold = 6f;

	[BoxGroup("Feedback")]
	[Tooltip("the dependencies by which to ignore the nonboosting speed threshold for playing feedback")]
	[ReorderableList]
	public Dependency[] dependenciesFeedbackNonboostingSpeedThresholdIgnorance;

	[BoxGroup("Feedback")]
	[Header("Nonground")]
	[Tooltip("whether to play landing and liftoff feedback for nonground terrain collision")]
	public bool feedbackForNongroundTerrainCollision = true;
	#endregion variables for: feedback


	#region landing and liftoff events

	[Tooltip("the time of the last attempted landing feedback (to reduce feedback spamming)")]
	private float timeOfLastAttemptedLandingFeedback = -1f;

	[Tooltip("the time of the last attempted liftoff feedback (to reduce feedback spamming)")]
	private float timeOfLastAttemptedLiftoffFeedback = -1f;
	#endregion landing and liftoff events
	#endregion variables




	#region methods


	#region methods for: recognized layers handling

	// method: check if the given layer index matches to a recognized ground terrain layer //
	public static bool recognizedGroundTerrainLayerIndex(int layerIndex)
		=> layerIndex.matchesAnyLayerNameIn(singleton.recognizedGroundTerrainLayerNames);

	// method: check if the given layer index matches to a recognized nonground terrain layer //
	public static bool recognizedNongroundTerrainLayerIndex(int layerIndex)
		=> layerIndex.matchesAnyLayerNameIn(singleton.recognizedNongroundTerrainLayerNames);

	// method: check if the given layer index matches to a recognized terrain layer //
	public static bool recognizedTerrainLayerIndex(int layerIndex)
		=> layerIndex.matchesAnyLayerNameIn(
			singleton.recognizedGroundTerrainLayerNames,
			singleton.recognizedNongroundTerrainLayerNames);

	// method: check if the given layer index matches to a recognized terrain layer of the given recognized terrain type //
	public static bool recognizedTypedTerrainLayerIndex(RecognizedTerrainType recognizedTerrainType, int layerIndex)
	{
		if (recognizedTerrainType == RecognizedTerrainType.any)
		{
			return recognizedTerrainLayerIndex(layerIndex);
		}
		else if (recognizedTerrainType == RecognizedTerrainType.groundOnly)
		{
			return recognizedGroundTerrainLayerIndex(layerIndex);
		}
		else		// (if (recognizedTerrainType == RecognizedTerrain.nongroundOnly))
		{
			return recognizedNongroundTerrainLayerIndex(layerIndex);
		}
	}
	#endregion methods for: recognized layers handling


	#region methods for: collided terrains tracking and groundedness determination

	// method: determine whether this body player is currently collided with terrain //
	public static bool collidedWithTerrain()
		=> Any.itemsIn(collidedTerrains);
	// method: determine whether this body player is currently collided with terrain //
	public bool collidedWithTerrain_()
		=> collidedWithTerrain();

	// method: determine whether this body player is currently collided with ground //
	public static bool collidedWithGround()
		=> Any.itemsIn(collidedGroundTerrains);
	// method: determine whether this body player is currently collided with ground //
	public bool collidedWithGround_()
		=> collidedWithGround();

	// method: determine the layer of the object first found by raycasting down relative to the player body's position on the floor by the set range and from the set raise relative to the player body's position on the floor – if no objects are hit, then '-1' is returned (which will not pass layer recognition checking) //
	private int firstRaycastedLayer()
	{
		// determine the position to raycast from to be the player body's position on x and z but the player's (floor) position on y, adjusted on y by the raise //
		Vector3 raycastingPosition = (new Vector3(bodyTransform.position.x, transform.position.y, bodyTransform.position.z) + (transform.up * raycastingRaise));

		RaycastHit[] raycastHitsFound = Physics.RaycastAll(raycastingPosition, bodyTransform.down(), Mathf.Infinity, Physics.DefaultRaycastLayers);		// get all raycast hits for raycasting from the player's body relatively downward
		if (Any.itemsIn(raycastHitsFound))
		{
			// determine the nearest raycast hit found's: hit distance, hit //
			float nearestRaycastHitDistance = Mathf.Infinity;		// initialize the nearest raycast hit's distance
			RaycastHit nearestRaycastHit = raycastHitsFound[0];		// initialize the nearest raycast hit to the first raycast hit found, by default (since it can't be null)
			foreach (RaycastHit raycastHitFound in raycastHitsFound)
			{
				if (!raycastHitFound.collider.isTrigger && !(raycastHitFound.transform.gameObject.layerMatches("Player")))		// if this raycast did not hit a trigger collider nor a player object
				{
					float raycastHitFoundDistance = Vector3.Distance(raycastingPosition, raycastHitFound.point);		// determine this raycast's hit distance
					// if this raycast's hit distance is less than the smallest distance found thus far, update the tracked nearest raycast hit and its distance to this raycast's //
					if (raycastHitFoundDistance < nearestRaycastHitDistance)
					{
						nearestRaycastHitDistance = raycastHitFoundDistance;
						nearestRaycastHit = raycastHitFound;
					}
				}
			}
			
			// if the nearest raycast hit found was not against a trigger collider and was within the raycasting range: //
			if (!nearestRaycastHit.collider.isTrigger && (nearestRaycastHitDistance <= (raycastingRange + raycastingRaise)))
			{
				// return the layer of the nearest raycast hit found //
				return nearestRaycastHit.transform.gameObject.layer;
			}
		}
		// otherwise (if no applicable raycast hits were found): determine the first layer found to be '-1' as a flag of no layer found (which will not pass layer recognition checking) //
		return -1;
	}

	// method: determine whether this body/player is currently terrained (both colliding with any recognized terrain and raycasting to any recognized terrain) //
	public bool terrained_()
		=> (collidedWithTerrain_() && recognizedTerrainLayerIndex(firstRaycastedLayer()));

	// method: determine whether this body/player is currently terrained (both colliding with any recognized terrain and raycasting to any recognized terrain) //
	public static bool terrained()
		=> (singleton && singleton.terrained_());

	// method: determine whether this body/player is currently grounded (both colliding with a recognized ground terrain and raycasting to a recognized ground terrain) //
	public bool grounded_()
		=> (collidedWithGround_() && recognizedGroundTerrainLayerIndex(firstRaycastedLayer()));

	// method: determine whether this body/player is currently grounded (both colliding with a recognized ground terrain and raycasting to a recognized ground terrain) //
	public static bool grounded()
		=> (singleton && singleton.grounded_());
	#endregion methods for: collided terrains tracking and groundedness determination


	#region methods for: determining the min feedback interval

	// method: determine the min feedback interval for lifting and landoff events //
	public float minEventFeedbackInterval_()
		=> minFeedbackInterval;

	// method: determine the min feedback interval for lifting and landoff events //
	public static float minEventFeedbackInterval()
		=> singleton.minEventFeedbackInterval_();


	// methods for: toggling nonground feedback //

	// method: invert nonground feedback //
	public void invertNongroundFeedback_()
		=> feedbackForNongroundTerrainCollision = !feedbackForNongroundTerrainCollision;

	// method: invert nonground feedback //
	public static void invertNongroundFeedback()
		=> singleton.invertNongroundFeedback_();

	// method: toggle nonground feedback to the given boolean //
	public void toggleNongroundFeedback_(bool boolean)
		=> feedbackForNongroundTerrainCollision = boolean;

	// method: toggle nonground feedback to the given boolean //
	public static void toggleNongroundFeedback(bool boolean)
		=> singleton.toggleNongroundFeedback_(boolean);
	#endregion methods for: determining the min feedback interval


	#region methods for: playing feedback audio

	// method: play a random landing audio //
	public void playRandomLandingAudio_()
		=> audioSource.PlayOneShot(landingAudioSet[Random.Range(0, landingAudioSet.Length)]);

	// method: play a random landing audio //
	public static void playRandomLandingAudio()
		=> singleton.playRandomLandingAudio_();

	// method: play a random liftoff audio //
	public void playRandomLiftoffAudio_()
	{
		if (audioSource && audioSource.enabled)		// only if the audio source actually exists and is enabled
		{
			audioSource.PlayOneShot(liftoffAudioSet[Random.Range(0, liftoffAudioSet.Length)]);
		}
	}

	// method: play a random liftoff audio //
	public static void playRandomLiftoffAudio()
		=> singleton.playRandomLiftoffAudio_();
	#endregion methods for: playing feedback audio


	#region methods for: determining whether the player is within a given distance to terrain below

	// method: determine whether the player is within the given distance to terrain below //
	public bool withinDistanceToTerrainBelow_(float maxDistanceBelow)
	{
		// determine the position to raycast from to be the player body's position on x and z but the player's (floor) position on y //
		Vector3 raycastingPosition = new Vector3(bodyTransform.position.x, transform.position.y, bodyTransform.position.z);

		RaycastHit[] raycastHitsFound = Physics.RaycastAll((raycastingPosition + new Vector3(0f, raycastingRaise, 0f)), bodyTransform.down(), Mathf.Infinity, Physics.DefaultRaycastLayers);		// get all raycast hits for raycasting from the player's body relatively downward
		if (Any.itemsIn(raycastHitsFound))
		{
			// determine the nearest raycast hit found's: hit distance, hit //
			float nearestRaycastHitDistance = Mathf.Infinity;		// initialize the nearest raycast hit's distance
			RaycastHit nearestRaycastHit = raycastHitsFound[0];		// initialize the nearest raycast hit to the first raycast hit found, by default (since it can't be null)
			foreach (RaycastHit raycastHitFound in raycastHitsFound)
			{
				if (!raycastHitFound.collider.isTrigger && !(raycastHitFound.transform.gameObject.layerMatches("Player")))		// if this raycast did not hit a trigger collider nor a player object
				{
					float raycastHitFoundDistance = Vector3.Distance((raycastingPosition + new Vector3(0f, raycastingRaise, 0f)), raycastHitFound.point);		// determine this raycast's hit distance
					// if this raycast's hit distance is less than the smallest distance found thus far, update the tracked nearest raycast hit and its distance to this raycast's //
					if (raycastHitFoundDistance < nearestRaycastHitDistance)
					{
						nearestRaycastHitDistance = raycastHitFoundDistance;
						nearestRaycastHit = raycastHitFound;
					}
				}
			}
			
			// determine whether the player is within the given distance to terrain below (based on whether the nearest raycast hit found was not against a trigger collider and was within the given distance and was against a recognized terrain layer) //
			return (!nearestRaycastHit.collider.isTrigger && (nearestRaycastHitDistance <= (maxDistanceBelow + raycastingRaise)) && recognizedTerrainLayerIndex(nearestRaycastHit.transform.gameObject.layer));
		}
		// otherwise (if no applicable raycast hits were found): determine that the player is not within the given distance to terrain below //
		return false;
	}

	// method: determine whether the player is within a given distance to terrain below //
	public static bool withinDistanceToTerrainBelow(float maxDistanceBelow)
		=> singleton.withinDistanceToTerrainBelow_(maxDistanceBelow);

	// method: determine whether the player is within the air nonrushing distance to terrain below //
	public static bool withinAirNonrushingDistanceToTerrainBelow()
		=> withinDistanceToTerrainBelow(AirRushingAudio.singleton.airNonrushingDistance);
	#endregion methods for: determining whether the player is within a given distance to terrain below
	#endregion methods




	#region events


	// event: landing //
	public delegate void landingDelegate();
	public static event landingDelegate landingEvent;
	// event: liftoff //
	public delegate void liftoffDelegate();
	public static event liftoffDelegate liftoffEvent;
	
	// event: terraining //
	public delegate void terrainingDelegate();
	public static event terrainingDelegate terrainingEvent;
	// event: unterraining //
	public delegate void unterrainingDelegate();
	public static event unterrainingDelegate unterrainingEvent;
	
	// event: grounding //
	public delegate void groundingDelegate();
	public static event groundingDelegate groundingEvent;
	// event: ungrounding //
	public delegate void ungroundingDelegate();
	public static event ungroundingDelegate ungroundingEvent;
	#endregion events




	#region updating


	// at each physics update: //
	private void FixedUpdate()
	{
		// update the tracking for whether the player was just terrained\grounded (respectively) //
		playerWasJustTerrained = playerIsTerrained;
		playerWasJustGrounded = playerIsGrounded;
		playerIsTerrained = terrained();
		playerIsGrounded = grounded();

		// broadcast a terraining\unterraining event if respectively applicable //
		if (!playerWasJustTerrained && playerIsTerrained && (terrainingEvent != null))
		{
			terrainingEvent();
		}
		else if (playerWasJustTerrained && !playerIsTerrained && (unterrainingEvent != null))
		{
			unterrainingEvent();
		}

		// broadcast a grounding\ungrounding event if respectively applicable //
		if (!playerWasJustGrounded && playerIsGrounded && (groundingEvent != null))
		{
			groundingEvent();
		}
		else if (playerWasJustGrounded && !playerIsGrounded && (ungroundingEvent != null))
		{
			ungroundingEvent();
		}
	}

	// upon colliding: //
	private void OnCollisionEnter(Collision collision)
	{
		GameObject collidedObject = collision.gameObject;		// connect to the collided object
		// landing event triggering (based on colliding with a recognized terrain) //
		if (recognizedTerrainLayerIndex(collidedObject.layer))
		{
			// determine whether the collided terrain is ground or not //
			bool ground = recognizedGroundTerrainLayerIndex(collidedObject.layer);
			// if applicable: play landing feedback (vibration and audio) //
			if ((ground || feedbackForNongroundTerrainCollision) && dependenciesFeedback.areMet() && (dependenciesFeedbackNonboostingSpeedThresholdIgnorance.areMet() || Booster.eitherHandIsBoosting() || PlayerVelocityReader.speed() >= feedbackNonboostingSpeedThreshold))
			{
				// if the duration of the min interval for time between feedback attempts for the same (either liftoff\landing) event has passed since the last attempt: //
				if (timeSince(timeOfLastAttemptedLandingFeedback) >= minFeedbackInterval)		
				{
					// if each controller is on, respectively: extendedly vibrate it (with default duration and intensity) //
					if (Controller.left)
						Controller.left.vibrateExtended(vibrationDuration, vibrationIntensity);
					if (Controller.right)
						Controller.right.vibrateExtended(vibrationDuration, vibrationIntensity);
					// play a random landing audio //
					playRandomLandingAudio();
				}

				// track the time of the last attempted landing feedback as now //
				timeOfLastAttemptedLandingFeedback = time;
			}
			// track this terrain as a collided terrain //
			collidedTerrains.Add(collidedObject);
			if (ground)
			{
				collidedGroundTerrains.Add(collidedObject);
			}
			else
			{
				collidedNongroundTerrains.Add(collidedObject);
			}
			// broadcast landing event – this is ordered to happen after tracking being collided with terrain so that any methods pending a landing event can check whether the player is terrained (versus merely collided with terrain)... although after testing, the event timing doesn't seem to be guaranteed so a terraining event was implemented //
			if (landingEvent != null)
			{
				landingEvent();
			}
		}
	}

	// upon uncolliding: //
	private void OnCollisionExit(Collision collision)
	{
		GameObject collidedObject = collision.gameObject;		// connect to the collided object
		// liftoff event triggering (based on collision exit from a recognized terrain) //
		if (recognizedTerrainLayerIndex(collidedObject.layer))
		{
			// broadcast liftoff event – this is ordered to happen before untracking being collided with terrain so that any methods pending a liftoff event can check whether the player is terrained (versus merely collided with terrain)... although after testing, the event timing doesn't seem to be guaranteed so an unterraining event was implemented //
			if (liftoffEvent != null)
			{
				liftoffEvent();
			}
			// determine whether the collided terrain is ground or not //
			bool ground = recognizedGroundTerrainLayerIndex(collidedObject.layer);
			// if applicable: play liftoff feedback (audio) //
			if ((ground || feedbackForNongroundTerrainCollision) && dependenciesFeedback.areMet() && (dependenciesFeedbackNonboostingSpeedThresholdIgnorance.areMet() || Booster.eitherHandIsBoosting() || PlayerVelocityReader.speed() >= feedbackNonboostingSpeedThreshold))
			{
				// if the duration of the min interval for time between feedback attempts for the same (either liftoff\landing) event has passed since the last attempt: //
				if (timeSince(timeOfLastAttemptedLiftoffFeedback) >= minFeedbackInterval)		
				{
					// play a random liftoff audio //
					playRandomLiftoffAudio();
				}

				// track the time of the last attempted liftoff feedback as now //
				timeOfLastAttemptedLiftoffFeedback = time;
			}
			// track this terrain as not a collided terrain //
			collidedTerrains.Remove(collidedObject);
			if (ground)
			{
				collidedGroundTerrains.Remove(collidedObject);
			}
			else
			{
				collidedNongroundTerrains.Remove(collidedObject);
			}
		}
	}
	#endregion updating
}