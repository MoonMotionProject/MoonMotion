using NaughtyAttributes;
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
//   · a dependencies setting for which cycling should occur upon the changing of whether they are met
//     - a toggle setting for whether this is enabled
//     - a dependencies for whether this is allowed
//     - a toggle setting for whether this cycles globally
//     - a toggle setting for whether this plays the cycling audio
public abstract class BoosterModuleControllableCycleable : BoosterModuleControllable
{
	// variables //


	// settings for: input //

	[BoxGroup("Input")]
	[Tooltip("whether or not input should cycle globally (for both hands at once)")]
	public bool globallyCycle = true;

	[BoxGroup("Input")]
	[Tooltip("whether input should play the attached cycling audio")]
	public bool inputPlaysAudio = true;
	

	// trackings for: cycling //
	
	[Tooltip("the current cycling index (by which to cycle through the set to cycle through)")]
	protected int cycleIndex = 0;
	

	// variables for: playing cycling audio //
	private AudioSource cyclingAudioSource;		// connection - auto: the attached audio source (for playing its cycling audio)
	private AudioClip cyclingAudio;		// connection - auto: the attached cycling audio


	// variables for: dependencies meeting changing cycling //

	[BoxGroup("Dependencies Meeting Changing Cycling")]
	[Tooltip("whether cycling via the dependencies for cycling is currently enabled")]
	public bool dependenciesCyclingEnabled = true;

	[BoxGroup("Dependencies Meeting Changing Cycling")]
	[Tooltip("the dependencies by which to allow cycling via the dependencies for cycling")]
	[ReorderableList]
	public Dependency[] dependenciesForDependenciesCycling;

	[BoxGroup("Dependencies Meeting Changing Cycling")]
	[Tooltip("the dependencies for cycling (the dependencies for which cycling should occur upon the changing of whether they are met... note that the dependency requisition shouldn't matter)")]
	[ReorderableList]
	public Dependency[] dependenciesForCycling;

	[Tooltip("whether the dependencies for cycling was met last time")]
	private bool dependenciesForCyclingMetLastTime = false;

	[BoxGroup("Dependencies Meeting Changing Cycling")]
	[Tooltip("whether to cycle globally when cycling via the dependencies for cycling")]
	public bool dependenciesForCyclingCyclesGlobally = false;

	[BoxGroup("Dependencies Meeting Changing Cycling")]
	[Tooltip("whether to play audio for cycling via the dependencies for cycling")]
	public bool dependenciesForCyclingPlaysAudio = false;




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


	// methods for: cycling by the dependencies for which cycling should occur upon the changing of whether they are met //

	// method: track the dependencies for cycling for last time //
	private void trackDependenciesForCycling()
	{
		// track whether the dependencies for which cycling should occur upon the changing of whether they are met was met last time, for next time, based on this time //
		dependenciesForCyclingMetLastTime = dependenciesForCycling.areMet();
	}
	// method: potentially cycle via the dependencies for cycling //
	private void potentiallyCycleViaDependenciesForCycling()
	{
		// if: cycling via the dependencies for cycling is enabled, the dependencies by which to allow cycling via dependencies is met: //
		if (dependenciesCyclingEnabled && dependenciesForDependenciesCycling.areMet())
		{
			// if the dependencies for cycling was different last time than it is now: //
			if (dependenciesForCyclingMetLastTime != dependenciesForCycling.areMet())
			{
				// advance the cycle, playing cycling audio if set to – cycle globally if set to //
				if (dependenciesForCyclingCyclesGlobally)
				{
					advanceCycleGlobally_(dependenciesForCyclingPlaysAudio);
				}
				else
				{
					advanceCycle(dependenciesForCyclingPlaysAudio);
				}
			}
		}

		// track the dependencies for cycling for last time //
		trackDependenciesForCycling();
	}
	// method: toggle whether cycling via the dependencies for cycling is currently enabled for this module //
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

		// track the dependencies for cycling for last time //
		trackDependenciesForCycling();
	}

	// at each update: //
	private void Update()
	{
		// if: the module dependencies are met, input is enabled, input is pressing: //
		if (dependencies.areMet() && inputEnabled && controller.inputPressing(inputs))
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

		// potentially cycle for the dependencies for cycling //
		potentiallyCycleViaDependenciesForCycling();
	}
}