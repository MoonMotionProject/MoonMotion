using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

// Scene Fader
// • classifies this hand locomotion as the "scene fading" locomotion
// • during certain pressed controller input by the parent hand, fades the player into a certain scene
//   · while fading, two effects optionally occur:
//     - fading the player's vision to blackness
//     - fading out the player's audio listening volume
//   · a setting specifies the scene to load
//     - if the scene isn't recognized by name, then nothing will happen upon input
//     - at the start, if this setting is set to '' (empty), then it is changed to the current scene
//   · settings determine the prefade (time before starting to fade) and fading durations
//   · if the input is ceased while prefading or fading, the progression will reverse back through those durations, until input is reengaged
// • provides methods to:
//   · change the player's fadedness to the given progression ratio
//   · change the player's fadedness based on the furthest scene fading time progression between either Scene Fader
//   · load a given scene
// • provides tracking for the last time of scene fading interaction and the time of the last scene fading completion
public class SceneFader : HandLocomotionControlled
{
	// variables //

	
	// variables for: instancing //
	public static SceneFader left, right;		// connections - auto: the left and right instances of this class
	private SceneFader other;		// connection - auto: the other instance of this class
	
	// variables for: scene loading //
	[Header("Scene to Load")]
	[Tooltip("the scene to load upon fading to total blackness")]
	public string sceneToLoad = "";		// setting: the scene to load upon fading to total blackness

	// variables for: fading //
	[Header("Scene Fading")]
	[Tooltip("whether to fade the player's listening volume when scene fading")]
	public bool fadeVisionToBlackness = true;		// setting: whether to fade the player's listening volume when scene fading
	[Tooltip("whether to fade the player's listening volume when scene fading")]
	public bool fadeListeningVolume = true;		// setting: whether to fade the player's listening volume when scene fading
	[Tooltip("(upon input) the duration by which to wait before starting to fade")]
	public float durationPrefade = 0f;		// setting: (upon input) the duration by which to wait before starting to fade
	[Tooltip("the duration by which to fade (up to the moment of loading the scene to load)")]
	public float durationFading = 2f;		// setting: the duration by which to fade (up to the moment of loading the scene to load)
	private float timeProgression = 0f;		// tracking: the temporal progression into a scene fade, incrementing while input is pressed and decrementing otherwise – but not to go below 0
	public static float lastTimeOfSceneFadingInteraction = -Mathf.Infinity;		// tracking: the last time of scene fading interaction (including the start of this object as one such interaction) – if this was longer ago than the combined duration of prefading and fading for either Scene Fader, then progression of fadedness will not be allowed (so as to disallow the possibility of this class keeping player vision blackness and player listening volume at the totally unfaded amount)... initialized to negative infinity as a flag that no scene fading interaction has ever occurred
	public static float timeOflastSceneFadingCompletion = -Mathf.Infinity;		// tracking: the last time that a scene fading completed – initialized to negative infinity as a flag that scene fading has never completed




	// methods //

	
	// methods for: fading //
	
	// method: change the player's fadedness (blackness versus nonblackness, listening volume ratio) according the given progression ratio //
	public void changeFadedness(float progressionRatio)
	{
		if (fadeVisionToBlackness)      // only change the player's vision blackness if set to
		{
			SteamVR_Fade.Start(new Color(0f, 0f, 0f, progressionRatio), 0f);
		}

		if (fadeListeningVolume)      // only change the player's listening volume ratio if set to
		{
			AudioListener.volume = (1f - progressionRatio);
		}
	}
	// method: determine the progression ratio for this Scene Fader //
	private float progressionRatio()
	{
		float progressionRatio = 0f;
		if ((timeProgression > durationPrefade) && (timeProgression <= (durationPrefade + durationFading)))
		{
			progressionRatio = ((timeProgression - durationPrefade) / durationFading);
		}

		return progressionRatio;
	}
	// method: change the player's fadedness according to the current time progression – only if this Scene Fader's progression ratio takes precedence (is farther along, or is equivalent and of the left hand), and only all this if a scene fading interaction has occurred yet and the time since the last time of scene fading interaction was not longer ago than the combined duration of prefading and fading for either Scene Fader //
	public void progressFadedness()
	{
		if ((lastTimeOfSceneFadingInteraction >= 0f) && ((Time.time - lastTimeOfSceneFadingInteraction) <= (Mathf.Max(durationPrefade, other.durationPrefade) + Mathf.Max(durationFading, other.durationFading))))
		{
			float progressionRatioThisHand = progressionRatio();
			float progressionRatioOtherHand = other.progressionRatio();

			if ((progressionRatioThisHand > progressionRatioOtherHand) || ((progressionRatioThisHand == progressionRatioOtherHand) && (this == left)))
			{
				changeFadedness(progressionRatio());
			}
		}
	}


	// methods for: scene loading //

	// method: load the given scene //
	public static void loadScene(string scene)
	{
		GameObject[] allObjects = FindObjectsOfType<GameObject>();
		for (int objectIndex = (allObjects.Length - 1); objectIndex >= 0; objectIndex--)
		{
			if (allObjects[objectIndex].activeInHierarchy)
			{
				Destroy(allObjects[objectIndex]);
			}
		}

		SteamVR_LoadLevel.Begin(scene, false, 0f);
	}

	// method: load the given scene //
	public void loadScene_(string scene)
		=> loadScene(scene);

	// method: reload the current scene //
	public static void reloadScene()
		=> loadScene(SceneManager.GetActiveScene().name);

	// method: reload the current scene //
	public void reloadScene_()
		=> reloadScene();




	// updating //


	// at the start: //
	protected override void Start()
	{
		base.Start();

		// connect to the other instance of this class //
		other = (leftInstance ? right : left);

		// if the scene to load is set to '' (empty), then change it to the current scene //
		if (sceneToLoad.Equals(""))
		{
			sceneToLoad = SceneManager.GetActiveScene().name;
		}
	}
	
	// upon being enabled: //
	private void OnEnable()
	{
		// connect the corresponding instance of this class //
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
		// if: input is enabled, the input dependencies are met, input is pressed, the scene to load is recognized by name: //
		if (locomotionInputEnabled && locomotionDependencies.areMet() && controller.inputPressed(inputsLocomotion) && Application.CanStreamedLevelBeLoaded(sceneToLoad))
		{
			// track the last time of scene fading interaction as the current time //
			lastTimeOfSceneFadingInteraction = Time.time;

			// increment the time progression //
			timeProgression += Time.deltaTime;
			
			// change the player's fadedness according to the current time progression //
			progressFadedness();

			// if the time progression has reached the end of the fading duration: //
			if ((timeProgression >= (durationPrefade + durationFading)))
			{
				// track the current time as the time of the last scene fading completion //
				timeOflastSceneFadingCompletion = Time.time;

				// load the scene to load //
				loadScene(sceneToLoad);
			}
		}
		// otherwise: //
		else
		{
			// if the scene to load is not recognized by name and is not an empty string: //
			if (!Application.CanStreamedLevelBeLoaded(sceneToLoad) && !sceneToLoad.Equals(""))
			{
				// log that there was an error in recognizing the scene to load by name //
				Debug.Log("error in SceneFader.Update(); scene to load not recognized by name of '"+sceneToLoad+"'");
			}

			// decrement the time progression, but not to go below 0 //
			timeProgression = Mathf.Max(0f, (timeProgression - Time.deltaTime));

			// change the player's fadedness according to the current time progression //
			progressFadedness();
		}
	}
}