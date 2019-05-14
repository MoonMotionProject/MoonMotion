using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Aesthetics Set Cycler: provides functionality for changing (especially by cycling) the parent booster's currently enabled set of aesthetics (lighting, particles, audio, etc. – but models are handled by the locomotion-general Hand Models Cycler) (often useful for cycling in accordance with Hand Models Cycler andor Locomotions Cycler)
// • general cycling functionality is provided by the parent class, Booster Module Controllable Cycleable
// • a setting for a set of sets of aesthetics determines the set to cycle through, to have each only one set of aesthetics active at a time
//   · a set of aesthetics is defined as being an array of booster aesthetic objects
//   · before the start, all unique aesthetics in the set of sets of aesthetics will be tracked as being managed, so they can be disabled before enabling any particular set of aesthetics to be active currently
//   · the cycle will be applied at the start (resulting in only those aesthetics in the current cycle index set being enabled, out of all the managed aesthetics)
//   · aesthetics sets cycling: upon input, cycles the parent booster through the whole set of sets of aesthetics; options are included to, respectively:
//     - enable\disable the cycling input
//     - cycle globally (for both hands at once)
//     - play the attached cycling audio
//   · the set of sets of aesthetics may have duplicate sets and may be ordered to have the whole set cycle alongside Locomotions Cycler or another cycler, as desired, perhaps by using the same input setting as that other cycler
//   · methods are provided (as an alternative to input) to cycle the booster's set of aesthetics, either globally or individually, optionally playing cycling audio
// • set of aesthetics adjusting:
//   · methods are provided to change the index and update the booster's set of aesthetics accordingly, either globally or individually, optionally playing cycling audio
//   · methods are provided to change the booster's set of aesthetics directly, ignoring the cycle index, either globally or individually, optionally playing cycling audio
// • set of aesthetics changing in general: methods are provided to, respectively:
//   · adjust the set of aesthetics of the parent booster to a given set of aesthetics
//   · apply the set of aesthetics for the current cycle index
public class BoosterAestheticsSetCycler : BoosterModuleControllableCycleable
{
	// definitions //

	
	// definition of a set of aesthetics
	// (this is done for the set of sets variable below instead of an object double array as a workaround because the latter isn't editable in the inspector)
	[System.Serializable]
	public class SetOfAesthetics
	{
		public GameObject[] array = new GameObject[] {};
	}




	// variables //

	
	// variables for: instancing //
	public static BoosterAestheticsSetCycler left, right;		// trackings: left and right instances of this class, respectively
	
	// variables for: set of aesthetics changing //
	[Header("Set of Sets of Aesthetics")]
	[Tooltip("the set of sets of aesthetics, by which only the current index (starting at 0) will ever be enabled out of all aesthetics included; updating this set midgame is not supported")]
	public SetOfAesthetics[] setOfSetsOfAesthetics = new SetOfAesthetics[0];		// setting: the set of sets of aesthetics, by which only the current index (starting at 0) will ever be enabled out of all aesthetics included; updating this set midgame is not supported
	private List<GameObject> managedAesthetics = new List<GameObject>();		// tracking: a set of each of the unique aesthetics in the set of sets of aesthetics, so as to track all aesthetics being managed and disable these such managed aesthetics as needed when having only a particular set be enabled
	
	
	
	
	// methods //

	
	// methods for: cycle indexing //
	
	// method: determine the count of the set to cycle through //
	public override int setCount()
	{
		return setOfSetsOfAesthetics.Length;
	}
	
	
	// methods for: set of aesthetics changing in general //
	
	// method: adjust the booster's set of aesthetics enabled to be just the given set of aesthetics out of all the managed aesthetics – if a recognized particles script is attached, disable\enable that the way it provides, instead of the object, so that the already-emitted particles don't disappear
	// (note that this is not intended to support aesthetics shared between boosters, as each aesthetic in the given set is expected to be respective to this booster)
	public void adjustSetOfAesthetics(SetOfAesthetics setOfAesthetics)
	{
		foreach (GameObject aestheticToDisable in managedAesthetics)
		{
			if (aestheticToDisable.GetComponent<BoosterJetSmokerings>())
			{
				aestheticToDisable.GetComponent<BoosterJetSmokerings>().enabled = false;
				BoosterJetSmokerings.appropriatelyTerrainedAtLastUpdate = false;
			}
			else if (aestheticToDisable.GetComponent<BoosterJetParticlesToggled>())
			{
				aestheticToDisable.GetComponent<BoosterJetParticlesToggled>().aestheticEnabled = false;
			}
			else if (aestheticToDisable.GetComponent<BoosterJetParticlesBriefed>())
			{
				aestheticToDisable.GetComponent<BoosterJetParticlesBriefed>().aestheticEnabled = false;
			}
			else
			{
				aestheticToDisable.SetActive(false);
			}
		}
		foreach (GameObject aestheticToEnable in setOfAesthetics.array)
		{
			if (aestheticToEnable.GetComponent<BoosterJetSmokerings>())
			{
				aestheticToEnable.GetComponent<BoosterJetSmokerings>().enabled = true;
			}
			else if (aestheticToEnable.GetComponent<BoosterJetParticlesToggled>())
			{
				aestheticToEnable.GetComponent<BoosterJetParticlesToggled>().aestheticEnabled = true;
			}
			else if (aestheticToEnable.GetComponent<BoosterJetParticlesBriefed>())
			{
				aestheticToEnable.GetComponent<BoosterJetParticlesBriefed>().aestheticEnabled = true;
			}
			else
			{
				aestheticToEnable.SetActive(true);
			}
		}
	}
	// method: apply the cycle based on the current cycle index //
	public override void applyCycle()
	{
		// adjust the booster's set of aesthetics enabled to be just the set of aesthetics at the current cycle index out of all the managed aesthetics //
		adjustSetOfAesthetics(setOfSetsOfAesthetics[cycleIndex]);
	}
	
	
	// methods for: set of aesthetics cycling //
	
	// method: advance set of aesthetics globally (by both the left and right instances of this class), optionally playing cycling audio //
	public static void advanceCycleGlobally(bool playAudio)
	{
		// advance the cycle for the left instance //
		left.advanceCycle(playAudio);
		// advance the cycle for the right instance //
		right.advanceCycle(playAudio);
	}
	// method: advance set of aesthetics globally (by both the left and right instances of this class), optionally playing cycling audio //
	public override void advanceCycleGlobally_(bool playAudio)
	{
		advanceCycleGlobally(playAudio);
	}


	// methods for: set of aesthetics adjusting //

	// method: adjust set of aesthetics globally (by both the left and right instances of this class) by the given index, optionally playing cycling audio //
	public static void adjustSetOfAestheticsGlobally(int index, bool playAudio)
	{
		// adjust set of aesthetics for the left instance //
		left.adjustCycle(index, playAudio);
		// adjust set of aesthetics for the right instance //
		right.adjustCycle(index, playAudio);
	}
	// method: adjust set of aesthetics globally (by both the left and right instances of this class) by the given index, optionally playing cycling audio //
	public void adjustSetOfAestheticsGlobally_(int index, bool playAudio)
	{
		adjustSetOfAestheticsGlobally(index, playAudio);
	}
	// method: adjust set of aesthetics and play cycling audio //
	public void adjustSetOfAestheticsAndPlayAudio(SetOfAesthetics setOfAesthetics)
	{
		// adjust set of aesthetics //
		adjustSetOfAesthetics(setOfAesthetics);
		// play cycling audio //
		playCyclingAudio();
	}
	// method: adjust set of aesthetics globally (by both the left and right instances of this class) to the given set of aesthetics, optionally playing cycling audio //
	public static void adjustSetOfAestheticsGlobally(SetOfAesthetics setOfAesthetics, bool playAudio)
	{
		// adjust set of aesthetics for the left instance //
		left.adjustSetOfAesthetics(setOfAesthetics);
		// adjust set of aesthetics for the right instance //
		right.adjustSetOfAesthetics(setOfAesthetics);
		// optionally have both hands play cycling audio //
		if (playAudio)
		{
			left.playCyclingAudio();
			right.playCyclingAudio();
		}
	}
	// method: adjust set of aesthetics globally (by both the left and right instances of this class) to the given set of aesthetics, optionally playing cycling audio //
	public void adjustSetOfAestheticsGlobally_(SetOfAesthetics setOfAesthetics, bool playAudio)
	{
		adjustSetOfAestheticsGlobally(setOfAesthetics, playAudio);
	}




	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();
		
		// track all unique aesthetics in the set of sets of aesthetics as being managed //
		foreach (SetOfAesthetics setOfAesthetics in setOfSetsOfAesthetics)
		{
			foreach (GameObject aesthetic in setOfAesthetics.array)
			{
				if (!managedAesthetics.Contains(aesthetic))
				{
					managedAesthetics.Add(aesthetic);
				}
			}
		}
	}

	// at the start: //
	protected override void Start()
	{
		base.Start();

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
}