using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using NaughtyAttributes;

// Hand Models Cycler: provides functionality for changing (especially by cycling) the parent hand's set of hand models (/ trigger colliders)
// (probably best used in conjunction with Locomotions Cycler)
// • has a setting for a set of sets of hand models, by which different combinations of hand models to cycle through sequentially or adjust to directly are defined
//   · a set of hand models is defined as being an array of hand model objects, paired with a boolean for whether to include the default controller model (since those cannot be connected via the inspector as they don't exist until after the game starts)
//   · the first set of hand models is applied at the start, setup with a 1 second delay to try again if the Interaction System's default controller model has not been created yet
//   · whenever a set of hand models is applied, all hand models in the set are enabled, and based on whether the set is set to include the default controller model, it is also enabled\disabled accordingly, and any hand models that are in other sets but not the one being applied are disabled
//   · cycling input allows the index to be incremented through the cycle upon input, applying the cycle's new current index after incrementing and also playing the attached cycling audio; options are provided to, respectively:
//     - enable\disable input
//     - have input depend on certain dependencies
//     - have input cycle globally (for both hands at once)
//     - have input play cycling audio
//   · connections made to compose the set of sets of hand models need not be children of this object, although it may be convenient to keep all connected model objects there
//   · the set of sets of hand models may have duplicate sets and may be ordered to have the whole set cycle alongside Locomotions Cycler or another cycler, as desired, perhaps by using the same input setting as that other cycler
//   · methods are provided to:
//     - determine the current cycle index
//     - increment the cycle index
//     - adjust the cycle index
//     - play the attached cycling audio
//     - adjust the set of hand models to a given set of hand models
//     - apply the cycle
//     - advance the cycle, optionally playing cycling audio
//     - advance the cycle globally, optionally playing cycling audio
//     - adjust the cycle, optionally playing cycling audio
//     - adjust the cycle globally, optionally playing cycling audio
//     - adjust the set of hand models globally, optionally playing cycling audio
//     - adjust the set of hand models and play cycling audio
public class HandModelsCycler : MonoBehaviour
{
	// definitions //

	
	// definition of a set of hand models
	// · this allows the unconnectable default Interaction System controller model to be effectively included in each array by manner of boolean
	// · this also allows the set of sets variable below to be used instead of an object double array as a workaround because the latter isn't inspector-editable
	[System.Serializable]
	public class SetOfHandModels
	{
		public bool includesControllerModel = true;
		public GameObject[] array = new GameObject[] {};
	}




	// variables //
	
	
	// variables for: hand connection and instancing //
	private Hand hand;		// connection - auto: this cycler's hand
	private bool leftInstance;		// tracking: this hand models cycler's handedness (whether its hand is the left hand (versus the right))
	public static HandModelsCycler left, right;		// trackings: left and right instances of this class, respectively
	
	// variables for: input //
	private Controller controller;		// connection - auto: this cycler's hand's controller
	[Header("Input")]
	[ReorderableList]
	public Controller.Input[] inputs = new Controller.Input[] {Controller.Input.none};		// setting: array of controller inputs to use for controlling this cycler
	public bool inputEnabled = true;		// setting: whether this cycler's input is currently enabled
	[Tooltip("the dependencies by which to restrict whether input is allowed")]
	[ReorderableList]
	public Dependency[] inputDependencies;		// setting: the dependencies by which to restrict whether input is allowed
	[Tooltip("whether or not input should cycle globally (for both hands at once)")]
	public bool globallyCycle = true;		// setting: whether or not input should cycle globally (for both hands at once)
	public bool inputPlaysAudio = false;		// setting: whether input should play the attached cycling audio
	
	// variables for: cycling //
	[Header("Cycle Index")]
	[Tooltip("the current cycling index (by which to cycle through the set to cycle through)")]
	private int cycleIndex = 0;      // tracking: the current cycling index (by which to cycle through the set to cycle through)
	
	// variables for: playing cycling audio //
	private AudioSource cyclingAudioSource;		// connection - auto: the attached audio source (for playing its cycling audio)
	private AudioClip cyclingAudio;		// connection - auto: the attached cycling audio
	
	// variables for: set of hand models changing //
	[Header("Set of Sets of Hand Models")]
	[Tooltip("the set of sets of hand models, by which only the current index (starting at 0) will ever be enabled out of all hand models included; updating this set midgame is not supported")]
	public SetOfHandModels[] setOfSetsOfHandModels = new SetOfHandModels[0];		// setting: the set of sets of hand models, by which only the current index (starting at 0) will ever be enabled out of all hand models included; updating this set midgame is not supported
	private List<GameObject> managedHandModels = new List<GameObject>();		// tracking: a set of each of the unique hand models in the set of sets of hand models, so as to track all hand models being managed and disable these such managed hand models as needed when having only a particular set be enabled (also according with the inclusions of default controller models within the set of sets)




	// methods //

	
	// methods for: cycle indexing //

	// method: determine the current cycle index //
	public int currentCycleIndex()
	{
		return cycleIndex;
	}

	// method: increment the cycle index through the cycle //
	public void incrementCycleIndex()
	{
		cycleIndex++;
		if (cycleIndex >= setOfSetsOfHandModels.Length)
		{
			cycleIndex = 0;
		}
	}
	
	// method: adjust the cycle index (change it to the given index) – zeroing it if it is not within range of the set to cycle through, as a fallback //
	public void adjustCycleIndex(int index)
	{
		if ((cycleIndex >= 0) && (cycleIndex < setOfSetsOfHandModels.Length))
		{
			cycleIndex = index;
		}
		else
		{
			cycleIndex = 0;
		}
	}
	
	
	// methods for: playing cycling audio //
	
	// method: play the attached cycling audio //
	public void playCyclingAudio()
	{
		cyclingAudioSource.PlayOneShot(cyclingAudio);
	}
	

	// methods for: set of hand models changing in general //
	
	// method: adjust the hand's set of hand models to be just the given set of hand models out of all the managed hand models, as well as according to the inclusions of default controller models within the set of sets //
	public void adjustSetOfHandModels(SetOfHandModels setOfHandModels)
	{
		foreach (GameObject handModelToDisable in managedHandModels)
		{
			handModelToDisable.SetActive(false);
		}
		foreach (GameObject handModelToEnable in setOfHandModels.array)
		{
			handModelToEnable.SetActive(true);
		}
		if (hand.GetComponentInChildren<SpawnRenderModel>())
		{
			if (setOfHandModels.includesControllerModel)
			{
				foreach (Transform childTransform in hand.GetComponentInChildren<SpawnRenderModel>().transform)
				{
					childTransform.gameObject.SetActive(true);
				}
			}
			else
			{
				foreach (Transform childTransform in hand.GetComponentInChildren<SpawnRenderModel>().transform)
				{
					childTransform.gameObject.SetActive(false);
				}
			}
		}
	}
	// method: apply the cycle based on the current cycle index – if the Interaction System's default controller model is not made yet, try again in 1 second //
	public void applyCycle()
	{
		// adjust the hand's set of hand models enabled to be based on the set of hand models at the current cycle index //
		adjustSetOfHandModels(setOfSetsOfHandModels[cycleIndex]);

		// if the Interaction System's default controller model is not made yet, try again in 1 second //
		if (!hand.GetComponentInChildren<SpawnRenderModel>())
		{
			Invoke("applyCycle", 1f);
		}
	}


	// methods for: set of hand models cycling //
	
	// method: advance the cycle, optionally playing cycling audio //
	public void advanceCycle(bool playAudio)
	{
		if (setOfSetsOfHandModels.Length > 1)		// if there are even any more than one set element to actually do any cycling through
		{
			// increment the cycle index //
			incrementCycleIndex();

			// apply the cycle based on the current cycle index //
			applyCycle();

			// optionally play cycling audio //
			if (playAudio)
			{
				playCyclingAudio();
			}
		}
	}
	// method: advance set of hand models globally (by both the left and right instances of this class), optionally playing cycling audio //
	public static void advanceCycleGlobally(bool playAudio)
	{
		// advance the cycle for the left instance //
		left.advanceCycle(playAudio);
		// advance the cycle for the right instance //
		right.advanceCycle(playAudio);
	}
	// method: advance set of hand models globally (by both the left and right instances of this class), optionally playing cycling audio //
	public void advanceCycleGlobally_(bool playAudio)
	{
		advanceCycleGlobally(playAudio);
	}


	// methods for: set of hand models adjusting //
	
	// method: adjust the cycle to the given index, optionally playing cycling audio //
	public void adjustCycle(int index, bool playAudio)
	{
		// adjust the cycle index //
		adjustCycleIndex(index);

		// apply the cycle //
		applyCycle();

		// optionally play cycling audio //
		if (playAudio)
		{
			playCyclingAudio();
		}
	}
	// method: adjust set of hand models globally (by both the left and right instances of this class) by the given index, optionally playing cycling audio //
	public static void adjustSetOfHandModelsGlobally(int index, bool playAudio)
	{
		// adjust set of hand models for the left instance //
		left.adjustCycle(index, playAudio);
		// adjust set of hand models for the right instance //
		right.adjustCycle(index, playAudio);
	}
	// method: adjust set of hand models globally (by both the left and right instances of this class) by the given index, optionally playing cycling audio //
	public void adjustSetOfHandModelsGlobally_(int index, bool playAudio)
	{
		adjustSetOfHandModelsGlobally(index, playAudio);
	}
	// method: adjust set of hand models and play cycling audio //
	public void adjustSetOfHandModelsAndPlayAudio(SetOfHandModels setOfHandModels)
	{
		// adjust set of hand models //
		adjustSetOfHandModels(setOfHandModels);
		// play cycling audio //
		playCyclingAudio();
	}
	// method: adjust set of hand models globally (by both the left and right instances of this class) to the given set of hand models, optionally playing cycling audio //
	public static void adjustSetOfHandModelsGlobally(SetOfHandModels setOfHandModels, bool playAudio)
	{
		// adjust set of hand models for the left instance //
		left.adjustSetOfHandModels(setOfHandModels);
		// adjust set of hand models for the right instance //
		right.adjustSetOfHandModels(setOfHandModels);
		// optionally have both hands play cycling audio //
		if (playAudio)
		{
			left.playCyclingAudio();
			right.playCyclingAudio();
		}
	}
	// method: adjust set of hand models globally (by both the left and right instances of this class) to the given set of hand models, optionally playing cycling audio //
	public void adjustSetOfHandModelsGlobally_(SetOfHandModels setOfHandModels, bool playAudio)
	{
		adjustSetOfHandModelsGlobally(setOfHandModels, playAudio);
	}


	

	// updating //

	
	// before the start: //
	private void Awake()
	{
		// connect to the hand //
		hand = transform.parent.GetComponent<Hand>();

		// connect to the controller //
		controller = hand.GetComponent<Controller>();

		// connect to the cycling audio source and audio //
		cyclingAudioSource = GetComponent<AudioSource>();
		cyclingAudio = cyclingAudioSource.clip;

		// track all unique hand models in the set of sets of hand models as being managed //
		foreach (SetOfHandModels setOfHandModels in setOfSetsOfHandModels)
		{
			foreach (GameObject handModel in setOfHandModels.array)
			{
				if (!managedHandModels.Contains(handModel))
				{
					managedHandModels.Add(handModel);
				}
			}
		}
	}

	// at the start: //
	private void Start()
	{
		// track this hand's handedness //
		leftInstance = (hand.startingHandType == Hand.HandType.Left);

		// track the left and right instances of this class //
		if (leftInstance)
		{
			left = this;
		}
		else
		{
			right = this;
		}

		// apply the cycle //
		applyCycle();
	}

	// at each update: //
	private void Update()
	{
		// if: input is enabled, the input dependencies are met, input is pressing: //
		if (inputEnabled && inputDependencies.areMet() && controller.inputPressing(inputs))
		{
			// advance the cycle – globally if set to do so //
			if (globallyCycle)
			{
				advanceCycleGlobally(inputPlaysAudio);
			}
			else
			{
				advanceCycle(inputPlaysAudio);
			}
		}
	}
}