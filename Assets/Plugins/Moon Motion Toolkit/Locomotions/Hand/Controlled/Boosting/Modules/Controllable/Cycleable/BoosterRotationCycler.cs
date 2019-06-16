using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Rotation Cycler: provides functionality for changing (especially by cycling) the parent booster's rotation (probably best used in conjunction with Booster Position Cycler)
// • general cycling functionality is provided by the parent class, Booster Module Controllable Cycleable
// • rotation cycling: upon input, cycles the parent booster through the whole set of rotations
//   · the whole set of rotations to cycle through is determined by appending the set additional rotations set to the booster's starting rotation
//     - the sets of rotations may have duplicates and may be ordered to have the whole set cycle alongside Locomotions Cycler or another cycler, as desired, perhaps by using the same input setting as that other cycler
//   · options are included to, respectively:
//     - enable\disable the cycling input
//     - cycle globally (for both hands at once)
//     - play the attached cycling audio
//   · methods are provided (as an alternative to input) to cycle the booster's rotation, either globally or individually, optionally playing cycling audio
// • rotation adjusting:
//   · methods are provided to change the index and update the booster's rotation accordingly, either globally or individually, optionally playing cycling audio
//   · methods are provided to change the booster's rotation directly, ignoring the cycle index, either globally or individually, optionally playing cycling audio
// • rotation changing in general: methods are provided to, respectively:
//   · adjust the rotation of the parent booster to a given rotation
//   · apply the rotation for the current cycle index
public class BoosterRotationCycler : BoosterModuleControllableCycleable
{
	// variables //

	
	// variables for: instancing //
	public static BoosterRotationCycler left, right;		// trackings: left and right instances of this class, respectively
	
	// variables for: rotation changing //
	[Header("Rotations Set")]
	[Tooltip("at the start, the whole set of rotations to cycle through is determined by appending this set of additional rotations to the booster's starting rotation")]
	[ReorderableList]
	public Vector3[] additionalRotations = new Vector3[0];		// setting: the set of additional rotations
	private List<Vector3> rotationsSet = new List<Vector3>();		// tracking: the whole set of rotations
	
	
	
	
	// methods //

	
	// methods for: cycle indexing //
	
	// method: determine the count of the set to cycle through //
	public override int setCount()
	{
		return rotationsSet.Count;
	}
	
	
	// methods for: rotation changing in general //
	
	// method: adjust the booster's rotation to the given rotation //
	public void adjustRotation(Vector3 rotation)
	{
		boosterTransform.localRotation = Quaternion.Euler(rotation);
	}
	// method: apply the cycle based on the current cycle index (set the booster's rotation to the rotation at the current cycle index) //
	public override void applyCycle()
	{
		// apply the rotation for the current cycle index //
		adjustRotation(rotationsSet[cycleIndex]);
	}
	
	
	// methods for: rotation cycling //
	
	// method: advance rotation globally (by both the left and right instances of this class), optionally playing cycling audio //
	public static void advanceCycleGlobally(bool playAudio)
	{
		// advance the cycle for the left instance //
		left.advanceCycle(playAudio);
		// advance the cycle for the right instance //
		right.advanceCycle(playAudio);
	}
	// method: advance rotation globally (by both the left and right instances of this class), optionally playing cycling audio //
	public override void advanceCycleGlobally_(bool playAudio)
	{
		advanceCycleGlobally(playAudio);
	}


	// methods for: rotation adjusting //

	// method: adjust rotation globally (by both the left and right instances of this class) by the given index, optionally playing cycling audio //
	public static void adjustRotationGlobally(int index, bool playAudio)
	{
		// adjust rotation for the left instance //
		left.adjustCycle(index, playAudio);
		// adjust rotation for the right instance //
		right.adjustCycle(index, playAudio);
	}
	// method: adjust rotation globally (by both the left and right instances of this class) by the given index, optionally playing cycling audio //
	public void adjustRotationGlobally_(int index, bool playAudio)
	{
		adjustRotationGlobally(index, playAudio);
	}
	// method: adjust rotation and play cycling audio //
	public void adjustRotationAndPlayAudio(Vector3 rotation)
	{
		// adjust rotation //
		adjustRotation(rotation);
		// play cycling audio //
		playCyclingAudio();
	}
	// method: adjust rotation globally (by both the left and right instances of this class) to the given rotation, optionally playing cycling audio //
	public static void adjustRotationGlobally(Vector3 rotation, bool playAudio)
	{
		// adjust rotation for the left instance //
		left.adjustRotation(rotation);
		// adjust rotation for the right instance //
		right.adjustRotation(rotation);
		// optionally have both hands play cycling audio //
		if (playAudio)
		{
			left.playCyclingAudio();
			right.playCyclingAudio();
		}
	}
	// method: adjust rotation globally (by both the left and right instances of this class) to the given rotation, optionally playing cycling audio //
	public void adjustRotationGlobally_(Vector3 rotation, bool playAudio)
	{
		adjustRotationGlobally(rotation, playAudio);
	}
	
	
	
	
	// updating //

	
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

		// determine the whole set of rotations (to cycle through) //
		rotationsSet.Add(boosterTransform.eulerAngles);
		foreach (Vector3 additionalRotation in additionalRotations)
		{
			rotationsSet.Add(additionalRotation);
		}
	}
}