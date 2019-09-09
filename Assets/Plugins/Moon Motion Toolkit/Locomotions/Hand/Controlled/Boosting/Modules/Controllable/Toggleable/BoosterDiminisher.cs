using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Diminisher
// • provides toggleable diminishing for the parent booster
//   · diminishing will reduce the booster force applied when more distant from terrain
//     · the recognized terrain type can be set, and its recognition is handled by Terrain Response
//       - a method is provided to cycle this setting
//         – this can optionally play the attached toggling audio
//     · this can optionally also recognize trigger colliders (versus only nontrigger colliders)
//     · this terrain distancing is determined in two possible ways:
//       - if this diminisher's hand is currently trigger collided with any nontrigger collider objects (according to Hand Insideness Tracking):
//         – if any of those objects is of a recognized terrain layer, then the diminisher is considered to be at 0 distance to a recognized terrain layer
//         – otherwise, the diminisher is considered to not be at distance to a recognized terrain layer (at distance '-1')... in this way, diminishing can be used even solely for preventing boosting from within objects
//         /* diminishers are expected to be able to be collision-determined based on the parent hand's collision; more precise "cheating" determination than that of Hand Insideness Tracking, for the precise point of diminishing raycasting, is not yet implemented */
//       - otherwise, terrain distancing is determined via raycasting
//         – if a recognized terrain is found within range, the distance of the nearest recognized terrain found within range is the determined distance (∗)
//         – otherwise, the diminisher is considered to not be at distance to a recognized terrain layer (at distance '-1')
//     · this can optionally affect only certain axes
//     · the max distance to diminish to can be set
//     · the curve to diminish by can be set
//     · a toggle setting is provided to always diminish due to obstruction (when the hand is inside of a nontrigger collider not of a recognized terrain layer for diminishing), regardless of whether any applicable axes should currently be diminished
//   · upon input, the diminisher's diminishing is toggled
//     - this can optionally be toggled globally (affecting both diminishers upon the input of this controller)
//     - this can optionally play the attached toggling audio
public class BoosterDiminisher : BoosterModuleControllableToggleable
{
	// variables //
	
	
	// variables for: instancing //
	public static BoosterDiminisher left, right;		// trackings: diminisher instances

	// variables for: diminishing //
	[Header("Diminishing (by terrain distancing)")]
	[Tooltip("whether to diminish (reduce the booster force applied when more distant from terrain, as recognized by Terrain Response)")]
	public bool diminishing = true;
	[Tooltip("whether the raycasting should recognize versus pass through trigger colliders")]
	public static bool hitTriggerColliders = false;
	[Tooltip("the recognized terrain type (defined by Terrain Response) to diminish boosting from (such that any other terrain types will not be treated as recognized terrain, resulting in inability to boost off of those types) – by default, ground only, because diminishing is an effect of gravity seems more implicit to ground surfaces; however, for purposes where diminishing isn't inspired by gravity, nonground terrain (such as walls in some zero gravity tunnel) may very well be suitable for diminishing")]
	public TerrainResponse.RecognizedTerrainType recognizedTerrainType = TerrainResponse.RecognizedTerrainType.groundOnly;
	[Tooltip("dependencies for whether this diminisher diminishes on the respective coordinate axis in particular")]
	[ReorderableList]
	public Dependency[] dependenciesX, dependenciesY, dependenciesZ;
	[Tooltip("the max distance to diminish to (such that at max distance, the booster force is totally diminished)")]
	public float diminishingDistanceMax = 10f;
	[Tooltip("the curve used for diminishing interpolation")]
	public InterpolationCurve diminishingCurve = InterpolationCurve.smoother;
	[Tooltip("whether to always prevent boosting inside obstructions (when the hand is inside a nontrigger collider that isn't a recognized terrain layer for diminishing); the alternative is to only prevent boosting inside obstructions according to whether to diminish any applicable axes")]
	public bool alwaysPreventBoostingInsideObstructions = true;
	[Tooltip("whether an (unrecognized) obstruction was found the last time distance to recognized terrain was calculated")]
	private bool terrainDistancingLastFoundObstruction = false;




	// methods //
	
	
	// methods for: toggling diminishing //
	
	// method: toggle this diminisher //
	protected override void toggle(bool playAudio)
	{
		diminishing = !diminishing;

		base.toggle(playAudio);
	}
	// method: toggle both diminishers, optionally playing their toggling audios //
	public static void toggleBoth(bool playAudios)
	{
		left.toggle(playAudios);
		right.toggle(playAudios);
	}
	// method: toggle both diminishers, optionally playing their toggling audios //
	public override void toggleBoth_(bool playAudios)
	{
		toggleBoth(playAudios);
	}
	

	// methods for: cycling the recognized terrain type //

	// method: cycle the recognized terrain type for this diminisher, optionally playing the module toggling audio //
	public void cycleRecognizedTerrainType(bool playAudio)
	{
		if (recognizedTerrainType == TerrainResponse.RecognizedTerrainType.any)
		{
			recognizedTerrainType = TerrainResponse.RecognizedTerrainType.groundOnly;
		}
		else if (recognizedTerrainType == TerrainResponse.RecognizedTerrainType.groundOnly)
		{
			recognizedTerrainType = TerrainResponse.RecognizedTerrainType.nongroundOnly;
		}
		else
		{
			recognizedTerrainType = TerrainResponse.RecognizedTerrainType.any;
		}

		if (playAudio)
		{
			playTogglingAudio();
		}
	}
	// method: cycle the recognized terrain type for the given diminisher, optionally playing the module toggling audio //
	public static void cycleRecognizedTerrainType(BoosterDiminisher diminisher, bool playAudio)
	{
		diminisher.cycleRecognizedTerrainType(playAudio);
	}
	// method: cycle the recognized terrain type for the given diminisher, optionally playing the module toggling audio //
	public void cycleRecognizedTerrainType_(BoosterDiminisher diminisher, bool playAudio)
	{
		cycleRecognizedTerrainType(diminisher, playAudio);
	}
	// method: cycle the recognized terrain type for the left diminisher, optionally playing the module toggling audio //
	public static void cycleRecognizedTerrainTypeLeft(bool playAudio)
	{
		left.cycleRecognizedTerrainType(playAudio);
	}
	// method: cycle the recognized terrain type for the left diminisher, optionally playing the module toggling audio //
	public void cycleRecognizedTerrainTypeLeft_(bool playAudio)
	{
		cycleRecognizedTerrainTypeLeft(playAudio);
	}
	// method: cycle the recognized terrain type for the right diminisher, optionally playing the module toggling audio //
	public static void cycleRecognizedTerrainTypeRight(bool playAudio)
	{
		right.cycleRecognizedTerrainType(playAudio);
	}
	// method: cycle the recognized terrain type for the right diminisher, optionally playing the module toggling audio //
	public void cycleRecognizedTerrainTypeRight_(bool playAudio)
	{
		cycleRecognizedTerrainTypeRight(playAudio);
	}
	// method: cycle the recognized terrain type for both diminishers, optionally playing the module toggling audio //
	public static void cycleRecognizedTerrainTypeBoth(bool playAudio)
	{
		left.cycleRecognizedTerrainType(playAudio);
		right.cycleRecognizedTerrainType(playAudio);
	}
	// method: cycle the recognized terrain type for both diminishers, optionally playing the module toggling audio //
	public void cycleRecognizedTerrainTypeBoth_(bool playAudio)
	{
		cycleRecognizedTerrainTypeBoth(playAudio);
	}
	
	
	// methods for: diminishing //

	// method: determine whether this booster is currently diminished //
	public bool diminishedBooster()
	{
		return (diminishing && dependencies.areMet());
	}
	// method: determine whether the given booster is currently diminished //
	public static bool diminished(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.diminishedBooster();
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.diminishedBooster();
			}
		}
		return false;
	}
	
	// method: determine the diminishing interpolation curve for the given booster //
	private static InterpolationCurve curve(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left.diminishingCurve;
		}
		else
		{
			return right.diminishingCurve;
		}
	}
	
	// method: calculate the distance of the booster to the nearest recognized (according to Terrain Response) terrain in the direction of the booster's boosting; this also tracks for Booster Antidiminisher whether the booster is at distance to an antidiminishor //
	public static float distanceToTerrain(Booster booster)
	{
		// connect to the diminisher for the given booster //
		BoosterDiminisher diminisher = diminisherFor(booster);

		// determine any nontrigger colliders that this diminisher's hand is currently inside of (according to Hand Insideness Tracking) //
		HashSet<GameObject> allCollidedObjects = (booster.leftInstance ? HandInsidenessTracking.allCollidedObjectsForLeftHand() : HandInsidenessTracking.allCollidedObjectsForRightHand());

		// if this diminisher's hand is currently inside of any nontrigger collider objects: //
		if (allCollidedObjects.Count > 0)
		{
			// if any of the objects this diminisher's hand is inside of is on a recognized terrain layer: calculate the distance to the nearest recognized terrain to be 0 //
			foreach (GameObject collidedObject in allCollidedObjects)
			{
				if (TerrainResponse.recognizedTypedTerrainLayerIndex(diminisher.recognizedTerrainType, collidedObject.layer))
				{
					diminisher.terrainDistancingLastFoundObstruction = false;		// track that obstruction was not found for this terrain distancing
					return 0f;
				}
			}
			// otherwise: track that an obstruction was found for this terrain distancing, and consider the distance to terrain to be -1, as a flag of no recognized terrain being found //
			diminisher.terrainDistancingLastFoundObstruction = true;
			return -1f;
		}
		// otherwise: determine the distance to the nearest recognized terrain via raycasting //
		else
		{
			// track that obstruction was not found for this terrain distancing //
			diminisher.terrainDistancingLastFoundObstruction = false;


			// determine the relativity transform that this booster's relativizer is using currently //
			Transform relativityTransform = BoosterRelativizer.relativityTransform(booster);

			
			// if there is a recognized terrain below, calculate distance based on that //

			RaycastHit[] raycastHitsFound = Physics.RaycastAll(relativityTransform.position, -BoosterForceApplier.direction(booster).asDirectionRelativeTo(relativityTransform), Mathf.Infinity, Physics.DefaultRaycastLayers);		// get all raycast hits for raycasting from the booster in the direction of the booster's force
			if (Any.itemsIn(raycastHitsFound))
			{
				// determine the nearest raycast hit found's: hit distance, hit //
				float nearestRaycastHitDistance = Mathf.Infinity;		// initialize the nearest raycast hit's distance
				RaycastHit nearestRaycastHit = raycastHitsFound[0];		// initialize the nearest raycast hit to the first raycast hit found, by default (since it can't be null)
				foreach (RaycastHit raycastHitFound in raycastHitsFound)
				{
					if (hitTriggerColliders || !raycastHitFound.collider.isTrigger)		// if trigger collider hits are allowed, or this raycast did not hit a trigger collider
					{
						float raycastHitFoundDistance = Vector3.Distance(relativityTransform.position, raycastHitFound.point);		// determine this raycast's hit distance
						// if this raycast's hit distance is less than the smallest distance found thus far, update the tracked nearest raycast hit and its distance to this raycast's //
						if (raycastHitFoundDistance < nearestRaycastHitDistance)
						{
							nearestRaycastHitDistance = raycastHitFoundDistance;
							nearestRaycastHit = raycastHitFound;
						}
					}
				}
			
				// if the nearest raycast hit found is legal (based on the following conditions): track whether this diminisher is at distance to an antidiminisher, return the nearest raycast's hit distance //
				if (hitTriggerColliders || !nearestRaycastHit.collider.isTrigger)		// if trigger collider hits are allowed, or the nearest raycast did not hit a trigger collider
				{
					if (TerrainResponse.recognizedTypedTerrainLayerIndex(diminisher.recognizedTerrainType, nearestRaycastHit.transform.gameObject.layer))		// if the nearest raycast hit recognized terrain
					{
						BoosterAntidiminisher.antidiminisherFor(booster).atDistanceToAntidiminishor = BoosterAntidiminisher.antidiminishorLayer(nearestRaycastHit.transform.gameObject.layer) && (nearestRaycastHitDistance >= 0f) && (nearestRaycastHitDistance <= BoosterAntidiminisher.boosterAntidiminishingDistanceMax(booster));		// track whether this booster is at distance to an antidiminisher
						return nearestRaycastHitDistance;		// return the nearest raycast's hit distance
					}
				}
				// otherwise (if the nearest raycast hit found is not legal): //
				else
				{
					// track that this booster is not at distance to an antidiminisher //
					BoosterAntidiminisher.antidiminisherFor(booster).atDistanceToAntidiminishor = false;
				}
			}
			// otherwise (if no raycast hits were found): //
			else
			{
				// track that this booster is not at distance to an antidiminisher //
				BoosterAntidiminisher.antidiminisherFor(booster).atDistanceToAntidiminishor = false;
			}

			// if nothing has been returned yet: consider the distance to terrain to be -1, as a flag of no recognized terrain being found (not 0, because returning 0 (as could have been returned above) would have indicated that recognized terrain was found at an immediate distance) //
				return -1f;
		}
	}
	
	// method: determine the max diminishing distance for the given booster //
	private static float boosterDiminishingDistanceMax(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left.diminishingDistanceMax;
		}
		else
		{
			return right.diminishingDistanceMax;
		}
	}

	// method: determine the diminisher for the given booster //
	public static BoosterDiminisher diminisherFor(Booster booster)
	{
		if (booster.leftInstance)
		{
			return left;
		}
		else
		{
			return right;
		}
	}

	// method: calculate the current diminishing factors for all coordinate axes for the given booster //
	public static Vector3 diminishingFactors(Booster booster)
	{
		// determine the diminisher for the given booster //
		BoosterDiminisher diminisher = diminisherFor(booster);

		// determine the max diminishing distance for this booster //
		float maxDiminishingDistance = boosterDiminishingDistanceMax(booster);

		// determine the diminishing factor for those axes which are to be diminished //
		float diminishingFactorForDiminishedAxes = 1f;		// initialize the diminishing factor to the default of 1
		if (diminished(booster))		// if this booster is actually being diminished
		{
			// determine: the distance to terrain – if there is any detected //
			float potentialDistanceToTerrain = distanceToTerrain(booster);
			// determine whether any distant terrain was detected //
			bool atDistanceToTerrain = (potentialDistanceToTerrain >= 0f);

			// calculate the diminishing factor //
			diminishingFactorForDiminishedAxes = (atDistanceToTerrain ? curve(booster).clamped(1f, 0f, (potentialDistanceToTerrain / maxDiminishingDistance)) : 0f);
		}
		
		// determine whether obstructed boosting must currently be prevented //
		bool mustPreventCurrentlyObstructedBoosting = (diminisher.alwaysPreventBoostingInsideObstructions && diminisher.terrainDistancingLastFoundObstruction);

		// determine the diminishing factor for each axis, where each axis is actually diminished only if it is set to be or if obstructed boosting must currently be prevented //
		float diminishingFactorX = (mustPreventCurrentlyObstructedBoosting || diminisher.dependenciesX.areMet()) ? diminishingFactorForDiminishedAxes : 1f;
		float diminishingFactorY = (mustPreventCurrentlyObstructedBoosting || diminisher.dependenciesY.areMet()) ? diminishingFactorForDiminishedAxes : 1f;
		float diminishingFactorZ = (mustPreventCurrentlyObstructedBoosting || diminisher.dependenciesZ.areMet()) ? diminishingFactorForDiminishedAxes : 1f;

		// return the diminishing factors for all coordinate axes //
		return new Vector3(diminishingFactorX, diminishingFactorY, diminishingFactorZ);
	}
	
	
	
	
	// updating //

	
	// at the start: connect to diminisher instances //
	protected override void Start()
	{
		base.Start();

		if (leftInstance)
		{
			left = this;
		}
		else
		{
			right = this;
		}
	}

	// at each update: //
	private void Update()
	{
		// if input is enabled and input is pressing: //
		if (inputEnabled && controller.inputPressing(inputs))
		{
			// toggle this diminisher //
			toggle(inputtingPlaysTogglingAudio);
			// if the toggling is set to be global: toggle the other diminisher as well //
			if (toggleIsGlobal)
			{
				if (leftInstance)
				{
					right.toggle(inputtingPlaysTogglingAudio);
				}
				else
				{
					left.toggle(inputtingPlaysTogglingAudio);
				}
			}
		}
	}
}