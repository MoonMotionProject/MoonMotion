using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Module Controllable Cycleable
// • provides this controllable booster module with general cycling functionality:
//   · an option to enable\disable cycling input
//   · an option to have input cycle globally (for both hands at once)
//   · upon input, this module's attached cycling audio will optionally be played
//   · methods for cycle indexing, to respectively:
//     - determine the count of the set to cycle through
//     - determine the current cycle index
//     - increment the cycle index
//     - adjust the cycle index
//   · a method for applying the cycle
//   · a method for playing this module's attached cycling audio
//   · methods for cycling, to respectively:
//     - advance the cycle, optionally playing cycling audio
//     - advance the cycle globally, optionally playing cycling audio
//   · a method to adjust the cycle, optionally playing cycling audio
//   · a dependencies combination setting for which cycling should occur upon the changing of whether they are met
//     - a toggle setting for whether this is enabled
//     - a dependencies combination for whether this is allowed
//     - a toggle setting for whether this cycles globally
//     - a toggle setting for whether this plays the cycling audio
public abstract class BoosterModuleControllableCycleable : BoosterModuleControllable
{
	// variables //

	
	// variables for: cycling input //
	[Tooltip("whether or not input should cycle globally (for both hands at once)")]
	public bool globallyCycle = true;		// setting: whether or not input should cycle globally (for both hands at once)
	public bool inputPlaysAudio = true;		// setting: whether input should play the attached cycling audio
	
	// variables for: cycling //
	[Header("Cycle Index")]
	[Tooltip("the current cycling index (by which to cycle through the set to cycle through)")]
	protected int cycleIndex = 0;      // tracking: the current cycling index (by which to cycle through the set to cycle through)
	
	// variables for: playing cycling audio //
	private AudioSource cyclingAudioSource;		// connection - automatic: the attached audio source (for playing its cycling audio)
	private AudioClip cyclingAudio;		// connection - automatic: the attached cycling audio

	// variables for: dependencies meeting changing cycling //
	[Header("Dependencies Meeting Changing Cycling")]
	[Tooltip("whether cycling via the dependencies combination for cycling is currently enabled")]
	public bool dependenciesCyclingEnabled = true;		// setting: whether cycling via the dependencies combination for cycling is currently enabled
	[Tooltip("the dependencies combination by which to allow cycling via the dependencies combination for cycling")]
	public Dependencies.DependenciesCombination dependenciesForDependenciesCycling;		// setting: the dependencies combination by which to allow cycling via the dependencies combination for cycling
	[Tooltip("the dependencies combination for cycling (the dependencies combination for which cycling should occur upon the changing of whether they are met... note that the dependency requisition shouldn't matter)")]
	public Dependencies.DependenciesCombination dependenciesCombinationForCycling;		// setting: the dependencies combination for cycling (the dependencies combination for which cycling should occur upon the changing of whether they are met... note that the dependency requisition shouldn't matter)
	private bool dependenciesCombinationForCyclingMetLastTime = false;		// tracking: whether the dependencies combination for cycling was met last time
	[Tooltip("whether to cycle globally when cycling via the dependencies combination for cycling")]
	public bool dependenciesCombinationForCyclingCyclesGlobally = true;		// setting: whether to cycle globally when cycling via the dependencies combination for cycling
	[Tooltip("whether to play audio for cycling via the dependencies combination for cycling")]
	public bool dependenciesCombinationForCyclingPlaysAudio = false;		// setting: whether to play audio for cycling via the dependencies combination for cycling




	// methods //

	
	// methods for: cycle indexing //

	// method: determine the count of the set to cycle through //
	public abstract int setCount();
	
	// method: determine the current cycle index //
	public int currentCycleIndex()
	{
		return cycleIndex;
	}

	// method: increment the cycle index through the cycle //
	public void incrementCycleIndex()
	{
		cycleIndex++;
		if (cycleIndex >= setCount())
		{
			cycleIndex = 0;
		}
	}
	
	// method: adjust the cycle index (change it to the given index) – zeroing it if it is not within range of the set to cycle through, as a fallback //
	public void adjustCycleIndex(int index)
	{
		if ((cycleIndex >= 0) && (cycleIndex < setCount()))
		{
			cycleIndex = index;
		}
		else
		{
			cycleIndex = 0;
		}
	}


	// methods for: cycle application //
	
	// method: apply the cycle based on the current cycle index (affect whatever the cycle affects, based upon the current cycle index) //
	public abstract void applyCycle();
	
	
	// methods for: playing cycling audio //
	
	// method: play the attached cycling audio //
	public void playCyclingAudio()
	{
		cyclingAudioSource.PlayOneShot(cyclingAudio);
	}


	// methods for: cycling //
	
	// method: advance the cycle, optionally playing cycling audio //
	public void advanceCycle(bool playAudio)
	{
		if (setCount() > 1)		// if there are even any more than one set element to actually do any cycling through
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
	// method: advance the cycle globally (by both the left and right instances of the class), optionally playing cycling audio //
	public abstract void advanceCycleGlobally_(bool playAudio);


	// methods for: adjusting //
	
	// method: adjust the cycle to the given index, optionally playing cycling audio //
	public void adjustCycle(int index, bool playAudio)
	{
		// adjust the cycle index //
		adjustCycleIndex(index);

		// optionally play cycling audio //
		if (playAudio)
		{
			playCyclingAudio();
		}
	}


	// methods for: cycling by the dependencies combination for which cycling should occur upon the changing of whether they are met //

	// method: track the dependencies combination for cycling for last time //
	private void trackDependenciesCombinationForCycling()
	{
		// track whether the dependencies combination for which cycling should occur upon the changing of whether they are met was met last time, for next time, based on this time //
		dependenciesCombinationForCyclingMetLastTime = Dependencies.metFor(dependenciesCombinationForCycling);
	}
	// method: potentially cycle via the dependencies combination for cycling //
	private void potentiallyCycleViaDependenciesCombinationForCycling()
	{
		// if: cycling via the dependencies combination for cycling is enabled, the dependencies combination by which to allow cycling via dependencies is met: //
		if (dependenciesCyclingEnabled && Dependencies.metFor(dependenciesForDependenciesCycling))
		{
			// if the dependencies combination for cycling was different last time than it is now: //
			if (dependenciesCombinationForCyclingMetLastTime != Dependencies.metFor(dependenciesCombinationForCycling))
			{
				// advance the cycle, playing cycling audio if set to – cycle globally if set to //
				if (dependenciesCombinationForCyclingCyclesGlobally)
				{
					advanceCycleGlobally_(dependenciesCombinationForCyclingPlaysAudio);
				}
				else
				{
					advanceCycle(dependenciesCombinationForCyclingPlaysAudio);
				}
			}
		}

		// track the dependencies combination for cycling for last time //
		trackDependenciesCombinationForCycling();
	}
	// method: toggle whether cycling via the dependencies combination for cycling is currently enabled for this module //
	public void toggleCyclingViaDependencies()
	{
		dependenciesCyclingEnabled = !dependenciesCyclingEnabled;
	}
	
	
	
	
	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to the cycling audio source and audio //
		cyclingAudioSource = GetComponent<AudioSource>();
		cyclingAudio = cyclingAudioSource.clip;
	}

	// at the start: //
	protected override void Start()
	{
		base.Start();

		// track the dependencies combination for cycling for last time //
		trackDependenciesCombinationForCycling();
	}

	// at each update: //
	private void Update()
	{
		// if: the module dependencies are met, input is enabled, input is pressing: //
		if (Dependencies.metFor(dependenciesCombination) && inputEnabled && controller.inputPressing(inputs))
		{
			// advance the cycle – globally if set to do so //
			if (globallyCycle)
			{
				advanceCycleGlobally_(inputPlaysAudio);
			}
			else
			{
				advanceCycle(inputPlaysAudio);
			}
		}

		// potentially cycle for the dependencies combination for cycling //
		potentiallyCycleViaDependenciesCombinationForCycling();
	}
}