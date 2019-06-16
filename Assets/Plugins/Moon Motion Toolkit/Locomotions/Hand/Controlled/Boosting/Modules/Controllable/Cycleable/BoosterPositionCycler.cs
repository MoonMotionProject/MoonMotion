using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Position Cycler: provides functionality for changing (especially by cycling) the parent booster's position (which is probably most useful for making positional adjustments when rotation cycling via Booster Rotation Cycler)
// • general cycling functionality is provided by the parent class, Booster Module Controllable Cycleable
// • position cycling: upon input, cycles the parent booster through the whole set of positions
//   · the whole set of positions to cycle through is determined by appending the set additional positions set to the booster's starting position
//     - the sets of positions may have duplicates and may be ordered to have the whole set cycle alongside Locomotions Cycler or another cycler, as desired, perhaps by using the same input setting as that other cycler
//   · options are included to, respectively:
//     - enable\disable the cycling input
//     - cycle globally (for both hands at once)
//     - play the attached cycling audio
//   · methods are provided (as an alternative to input) to cycle the booster's position, either globally or individually, optionally playing cycling audio
// • position adjusting:
//   · methods are provided to change the index and update the booster's position accordingly, either globally or individually, optionally playing cycling audio
//   · methods are provided to change the booster's position directly, ignoring the cycle index, either globally or individually, optionally playing cycling audio
// • position changing in general: methods are provided to, respectively:
//   · adjust the position of the parent booster to a given position
//   · apply the position for the current cycle index
public class BoosterPositionCycler : BoosterModuleControllableCycleable
{
	// variables //

	
	// variables for: instancing //
	public static BoosterPositionCycler left, right;		// trackings: left and right instances of this class, respectively
	
	// variables for: position changing //
	[Header("Positions Set")]
	[Tooltip("at the start, the whole set of positions to cycle through is determined by appending this set of additional positions to the booster's starting position")]
	[ReorderableList]
	public Vector3[] additionalPositions = new Vector3[0];		// setting: the set of additional positions
	private List<Vector3> positionsSet = new List<Vector3>();		// tracking: the whole set of positions
	
	
	
	
	// methods //

	
	// methods for: cycle indexing //
	
	// method: determine the count of the set to cycle through //
	public override int setCount()
	{
		return positionsSet.Count;
	}
	
	
	// methods for: position changing in general //
	
	// method: adjust the booster's position to the given position //
	public void adjustPosition(Vector3 position)
	{
		boosterTransform.localPosition = position;
	}
	// method: apply the cycle based on the current cycle index (set the booster's position to the position at the current cycle index) //
	public override void applyCycle()
	{
		// apply the position for the current cycle index //
		adjustPosition(positionsSet[cycleIndex]);
	}
	
	
	// methods for: position cycling //
	
	// method: advance position globally (by both the left and right instances of this class), optionally playing cycling audio //
	public static void advanceCycleGlobally(bool playAudio)
	{
		// advance the cycle for the left instance //
		left.advanceCycle(playAudio);
		// advance the cycle for the right instance //
		right.advanceCycle(playAudio);
	}
	// method: advance position globally (by both the left and right instances of this class), optionally playing cycling audio //
	public override void advanceCycleGlobally_(bool playAudio)
	{
		advanceCycleGlobally(playAudio);
	}


	// methods for: position adjusting //

	// method: adjust position globally (by both the left and right instances of this class) by the given index, optionally playing cycling audio //
	public static void adjustPositionGlobally(int index, bool playAudio)
	{
		// adjust position for the left instance //
		left.adjustCycle(index, playAudio);
		// adjust position for the right instance //
		right.adjustCycle(index, playAudio);
	}
	// method: adjust position globally (by both the left and right instances of this class) by the given index, optionally playing cycling audio //
	public void adjustPositionGlobally_(int index, bool playAudio)
	{
		adjustPositionGlobally(index, playAudio);
	}
	// method: adjust position and play cycling audio //
	public void adjustPositionAndPlayAudio(Vector3 position)
	{
		// adjust position //
		adjustPosition(position);
		// play cycling audio //
		playCyclingAudio();
	}
	// method: adjust position globally (by both the left and right instances of this class) to the given position, optionally playing cycling audio //
	public static void adjustPositionGlobally(Vector3 position, bool playAudio)
	{
		// adjust position for the left instance //
		left.adjustPosition(position);
		// adjust position for the right instance //
		right.adjustPosition(position);
		// optionally have both hands play cycling audio //
		if (playAudio)
		{
			left.playCyclingAudio();
			right.playCyclingAudio();
		}
	}
	// method: adjust position globally (by both the left and right instances of this class) to the given position, optionally playing cycling audio //
	public void adjustPositionGlobally_(Vector3 position, bool playAudio)
	{
		adjustPositionGlobally(position, playAudio);
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

		// determine the whole set of positions (to cycle through) //
		positionsSet.Add(boosterTransform.localPosition);
		foreach (Vector3 additionalPosition in additionalPositions)
		{
			positionsSet.Add(additionalPosition);
		}
	}
}