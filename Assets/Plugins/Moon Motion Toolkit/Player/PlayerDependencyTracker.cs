using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Dependency Tracker
// • tracks the state of a Dependency Requisite for the player
//   · uses the set "true dependencies" by which to potentially track such as true, and if not tracking such as true, uses the set "otherwise false partial dependencies" for tracking such as false
public abstract class	PlayerDependencyTracker<PlayerDependencyTrackerT> :
					SingletonBehaviour<PlayerDependencyTrackerT>
						where PlayerDependencyTrackerT : PlayerDependencyTracker<PlayerDependencyTrackerT>
{
	// variables //
	
	
	[Tooltip("the state of the Dependency Requisite")]
	[ShowNonSerializedField]
	protected bool requisiteState = false;

	[Tooltip("the dependencies by which the state is tracked as true")]
	[ReorderableList]
	public Dependency[] dependenciesTrue;

	[Tooltip("the partial dependencies by which the state is tracked as false, only if the true dependencies were not met")]
	[ReorderableList]
	public Dependency[] partialDependenciesOtherwiseFalse;




	// methods //

	
	// method: track the state (of the Dependency Requisite) //
	private void trackState()
	{
		// update the tracking for the state of the Dependency Requisite //
		if (dependenciesTrue.areMet())
		{
			requisiteState = true;
		}
		else if (partialDependenciesOtherwiseFalse.arePartiallyMetWhereEmptyIsFalse())
		{
			requisiteState = false;
		}
	}




	// updating //

	
	// at each update: //
	protected virtual void Update()
	{
		// track the state //
		trackState();
	}
}