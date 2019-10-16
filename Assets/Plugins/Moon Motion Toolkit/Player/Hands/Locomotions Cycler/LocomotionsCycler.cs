using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using System.Linq;
using NaughtyAttributes;

// Locomotions Cycler
// • A Locomotions Cycler is a module intended for both hands of the player.
// • Upon input, it cycles through set combinations of the parent hand's provided locomotion options, to have them be enabled (and have the others be disabled).
//   · a toggle setting restricts whether this input is currently enabled
//   · an input dependencies setting further restricts whether this input is allowed
//   · based on an option, this will or will not play the attached cycling audio
//   · here a locomotion is an object with a script component that implements ILocomotion
//   · here a locomotion combination is defined as an array of multiple locomotions to enable simultaneously – this could contain just one locomotion, two, more... or none
//     - for example, the locomotion combinations could be setup to cycle between using, say: Booster, Teleporter, both Booster and Teleporter, no locomotions
//     - note that this does not imply full support for or a need to provide more than one hand locomotion object of the same kind for the same hand
//       – having the same locomotion object be reused in multiple combinations should be done by setting each combination's particular connection to that singular locomotion object, as opposed to unnecessarily creating a clone of it and connecting to that
//       – the only locomotion for which there may be a practical desire for having multiple simultaneous instances of for one hand is the boosting locomotion... this functions fine, but only the last-created booster's respective left\right instances (including its modules) will be able to be accessed statically, as statically accessing settings for multiple active boosters for the same hand is not yet supported
//     - note that while the Locomotions Cycler for each hand does cycle through that hand's specified locomotion combinations, not all locomotions specified need be hand locomotions
//   · note that this only enables\disables locomotions to the extent of their main hierarchies; it is not designed to enable modules external to the main hierarchy of each respective locomotion, such as locomotion movement audio (for example: treading movement audio plays even when treading input isn't enabled)
// • also provides methods for setting locomotions based on a given combination of locomotion, optionally playing audio and optionally locking (disallowing locomotion cycling) afterward
public class LocomotionsCycler : MonoBehaviour
{
	// definitions //

	
	// definition of a locomotion combination
	// (this is done for the combinations variable below instead of an object double array as a workaround because the latter isn't editable in the inspector)
	[System.Serializable]
	public class LocomotionCombination
	{
		public GameObject[] array = new GameObject[] {};
	}




	// variables //

	
	// variables for: tracking instances //
	protected Hand hand;		// connection - auto: the parent hand
	[HideInInspector] public bool leftInstance;     // tracking: this Locomotions Cycler's handedness (whether this Locomotions Cycler is for the left hand (versus the right))
	private static LocomotionsCycler left, right;		// tracking: Locomotions Cycler instances
	private LocomotionsCycler other;		// tracking: the other Locomotions Cycler instance

	// variables for: input //
	private Controller controller;		// connection - auto: the hand's controller
	[Header("Input")]
	[ReorderableList]
	public Controller.Input[] inputs = new Controller.Input[] {Controller.Input.none};		// setting: array of controller inputs to use
	public bool inputEnabled = true;		// setting: whether this Locomotions Cycler's input is currently enabled
	[Tooltip("the dependencies by which to restrict whether input is allowed")]
	[ReorderableList]
	public Dependency[] inputDependencies;		// setting: the dependencies by which to restrict whether input is allowed
	public bool globallyCycle = true;		// setting: whether, when registering input, to cycle through the locomotion combinations for both Locomotions Cyclers or just this one
	public bool inputPlaysAudio = true;		// setting: whether to play the cycling audio upon input
	
	// variables for: locomotion cycling //
	[Header("Locomotion Combinations")]
	public LocomotionCombination[] combinations = new LocomotionCombination[] {new LocomotionCombination()};        // connection - manual: array of locomotion combinations (each combination being one set of multiple locomotions to enable at a time) to cycle through
	private LocomotionCombination[] rememberedCombinations;		// tracking: a backup of the locomotion combinations (made before the start), to effectively lock the combinations to what it was set to before the start
	[Header("Locomotion Combination Index")]
	public int index = 0;		// setting: current locomotion combination index (at which those locomotions are currently loaded)
	public static bool cyclingAllowed = true;		// tracking: whether locomotion cycling is currently allowed
	private int indexAtPreviousCyclingUpdate;		// tracking: the value of the index at the previous update when cycling was allowed (to be compared to the current index to determine if the locomotions need to be refreshed)
	private static HashSet<GameObject> managedLocomotions = new HashSet<GameObject>();     // tracking: array of locomotions that are managed by this Locomotions Cycler (tracked as those locomotions which are descendants of either Locomotions Cycler or the player)
	private AudioSource audioComponent;		// connection - auto: the attached locomotion cycling audio




	// methods //

	
	// method: change whether input is enabled for both cyclers based on the given boolean //
	private static void changeWhetherInputEnabledForBothCyclers(bool boolean)
	{
		left.inputEnabled = boolean;
		right.inputEnabled = boolean;
	}
	// method: disable input for both cyclers //
	public static void disableInputForBothCyclers()
	{
		changeWhetherInputEnabledForBothCyclers(false);
	}
	// method: enable input for both cyclers //
	public static void enableInputForBothCyclers()
	{
		changeWhetherInputEnabledForBothCyclers(true);
	}
	// method: toggle whether input is enabled for both cyclers //
	public static void toggleWhetherInputEnabledForBothCyclers()
	{
		left.inputEnabled = !left.inputEnabled;
		right.inputEnabled = !right.inputEnabled;
	}
	// method: toggle whether input is enabled for both cyclers //
	public void toggleWhetherInputEnabledForBothCyclers_()
	{
		toggleWhetherInputEnabledForBothCyclers();
	}


	// method: enable or disable the given locomotion, based on the given boolean //
	private static void setLocomotion(GameObject locomotion, bool setting)
	{
		locomotion.SetActive(setting);
	}
	
	
	// method: refresh the managed locomotions (ensure that all managed locomotions other than those in the current combination of either Locomotions Cycler are disabled, and that the others (those in the current combination of either Locomotions Cycler) are enabled)
	private static void refreshLocomotions()
	{
		foreach (GameObject locomotion in managedLocomotions)
		{
			if (locomotion)
			{
				bool leftCyclerWantsThisLocomotionEnabled = left.combinations[left.index].array.Contains(locomotion);
				bool rightCyclerWantsThisLocomotionEnabled = right.combinations[right.index].array.Contains(locomotion);

				bool thisLocomotionShouldBeEnabled = leftCyclerWantsThisLocomotionEnabled || rightCyclerWantsThisLocomotionEnabled;

				setLocomotion(locomotion, thisLocomotionShouldBeEnabled);
			}
		}
	}


	// method: set locomotions based on the given locomotion combination, optionally playing cycling audio //
	public static void setLocomotions(LocomotionCombination locomotionCombination, bool playAudio)
	{
		// first, disable all of the managed locomotions //
		foreach (GameObject locomotion in managedLocomotions)
		{
			if (locomotion)
			{
				locomotion.SetActive(false);
			}
		}
		// next, enable all of the locomotions in the given locomotion combination //
		foreach (GameObject locomotion in locomotionCombination.array)
		{
			if (locomotion)
			{
				locomotion.SetActive(true);
			}
		}

		// optionally play the locomotion cycling audio (on both hands, since this method is not hand specific) //
		if (playAudio)
		{
			left.audioComponent.PlayOneShot(left.audioComponent.clip);
			right.audioComponent.PlayOneShot(right.audioComponent.clip);
		}
	}
	// method: set locomotions based on the given locomotion combination – optionally playing cycling audio – then disallow locomotion cycling //
	public static void setLocomotionsThenLock(LocomotionCombination locomotionCombination, bool playAudio)
	{
		// set locomotions //
		setLocomotions(locomotionCombination, playAudio);

		// disallow locomotion cycling //
		cyclingAllowed = false;
	}

	// method: cycle locomotions globally (regardless of whether cycling is currently allowed), optionally playing the toggling audio //
	public void cycleLocomotionsGlobally_(bool playAudio)
	{
		// for both hands: cycle the locomotion combination index through the locomotion combinations //
		index++;
		if (index > (combinations.Length - 1))
		{
			index = 0;
		}
		other.index++;
		if (other.index > (other.combinations.Length - 1))
		{
			other.index = 0;
		}
		// for both hands: optionally play the locomotion cycling audio //
		if (inputPlaysAudio && playAudio)
		{
			audioComponent.PlayOneShot(audioComponent.clip);
			other.audioComponent.PlayOneShot(other.audioComponent.clip);
		}
	}
	// method: cycle locomotions globally (regardless of whether cycling is currently allowed), optionally playing the toggling audio //
	public static void cycleLocomotionsGlobally(bool playAudio)
	{
		// have the left hand's (it doesn't matter which one) Locomotions Cycler cycle locomotions globally, optionally playing the toggling audio //
		left.cycleLocomotionsGlobally_(playAudio);
	}
	
	
	
	// updating //

	
	// before the start: //
	private void Awake()
	{
		// connect to the hand //
		hand = transform.parent.GetComponent<Hand>();

		// determine whether this Locomotions Cycler belongs to the left hand (versus the right) //
		leftInstance = (hand.startingHandType == Hand.HandType.Left);

		// track the Locomotions Cycler instances //
		if (leftInstance)
		{
			left = this;
		}
		else
		{
			right = this;
		}

		// connect to the controller //
		controller = hand.GetComponent<Controller>();

		// ensure that the combinations array is not empty of combinations, setting it to have one combination empty of locomotions if it is //
		if (combinations.isEmpty())
		{
			combinations = new LocomotionCombination[] {new LocomotionCombination()};
		}

		// track the remembered locomotion combinations as the locomotion combinations as they are before the start //
		rememberedCombinations = combinations;
		
		// track the index at the previous update (when cycling was allowed) as the current index since it must be initialized //
		indexAtPreviousCyclingUpdate = index;

		// connect to the attached locomotion cycling audio //
		audioComponent = GetComponent<AudioSource>();
	}

	// at the start: //
	private void Start()
	{
		// track the locomotions managed by the hand's Locomotions Cycler as being managed by both Locomotions Cyclers //
		foreach (LocomotionCombination locomotionCombination in combinations)
		{
			foreach (GameObject cyclerManagedLocomotion in locomotionCombination.array)
			{
				if (!managedLocomotions.Contains(cyclerManagedLocomotion))
				{
					managedLocomotions.Add(cyclerManagedLocomotion);
				}
			}
		}
		// track the locomotions that are descendants of the hand as being managed by both Locomotions Cyclers //
		foreach (GameObject handDescendantLocomotion in gameObject.localAndDescendantObjectsWithI<ILocomotion>())
		{
			if (managedLocomotions.doesNotContain(handDescendantLocomotion))
			{
				managedLocomotions.include(handDescendantLocomotion);
			}
		}
		// track the locomotions that are descendants of the player as being managed by both Locomotions Cyclers //
		foreach (GameObject playerDescendantLocomotion in MoonMotionPlayer.localAndDescendantObjectsWithI<ILocomotion>())
		{
			if (managedLocomotions.doesNotContain(playerDescendantLocomotion))
			{
				managedLocomotions.include(playerDescendantLocomotion);
			}
		}

		// track the other Locomotions Cycler instance //
		other = (leftInstance ? right : left);

		// refresh the locomotions //
		refreshLocomotions();
	}

	// each update: //
	private void Update()
	{
		// lock the locomotion combinations setting to what it was set to before the start (by setting it to the remembered locomotion combinations) //
		combinations = rememberedCombinations;

		// if cycling is currently allowed: //
		if (cyclingAllowed)
		{
			// if: input is enabled, the input dependencies are met, input is pressing: //
			if (inputEnabled && inputDependencies.areMet() && controller.inputPressing(inputs))
			{
				// cycle the locomotion combination index through the locomotion combinations //
				index++;
				if (index > (combinations.Length - 1))
				{
					index = 0;
				}
				// if the globally cycling toggle is on, then also: cycle the locomotion combination index for the other Locomotions Cycler //
				if (globallyCycle)
				{
					other.index++;
					if (other.index > (other.combinations.Length - 1))
					{
						other.index = 0;
					}
				}
				// optionally play the locomotion cycling audio //
				if (inputPlaysAudio)
				{
					audioComponent.PlayOneShot(audioComponent.clip);
				}
			}

			// if the index has changed to be different than the index at the previous update: //
			if (index != indexAtPreviousCyclingUpdate)
			{
				// refresh the locomotions (those managed (the managing of which is shared by both Locomotions Cyclers – so this is refreshing the locomotions managed by both Locomotions Cyclers)) //
				refreshLocomotions();
			}



			// track the index at the previous update (when cycling was allowed) as the current index (at this update right now) since the current update will become the previous update right after this //
			indexAtPreviousCyclingUpdate = index;
		}
	}
}