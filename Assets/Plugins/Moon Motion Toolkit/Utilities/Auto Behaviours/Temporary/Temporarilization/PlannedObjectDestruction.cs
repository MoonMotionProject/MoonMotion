using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Planned Object Destruction:
// • destroys this object after the set delay since Start
public class PlannedObjectDestruction : AutoBehaviour<PlannedObjectDestruction>
{
	// variables //

	
	// settings //

	[Tooltip("the number of seconds to delay after Awake until destroying this object")]
	public float delay = Default.temporaryObjectDestructionDelay;




	// methods //

	
	// method: set the delay to the given delay //
	public PlannedObjectDestruction setDelayTo(float givenDelay)
		=> selfAfter(()=>
			delay = givenDelay);




	// updating //

	
	// at the start: //
	private void Start()
		=> planToExecuteAfter(delay, ()=> destroyThisObject());
}