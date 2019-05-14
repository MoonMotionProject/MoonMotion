using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Dependency Tracker
// • tracks the state of a Dependency Requisite for the player
//   · uses the set "true dependencies" by which to potentially track such as true, and if not tracking such as true, uses the set "otherwise false partial dependencies" for tracking such as false
public class PlayerDependencyTracker : MonoBehaviour
{
	// variables //

	
	// variables for: tracking the state of the Dependency Requisite //
	protected bool requisiteState = false;		// tracking: the state of the Dependency Requisite
	[Tooltip("the dependencies by which the state is tracked as true")]
	public Dependencies.DependenciesCombination dependenciesTrue;		// setting: the dependencies by which the state is tracked as true
	[Tooltip("the partial dependencies by which the state is tracked as false, only if the true dependencies were not met")]
	public Dependencies.DependenciesCombination partialDependenciesOtherwiseFalse;		// setting: the partial dependencies by which the state is tracked as false, only if the true dependencies were not met




	// methods //

	
	// method: track the state (of the Dependency Requisite) //
	private void trackState()
	{
		// update the tracking for the state of the Dependency Requisite //
		if (Dependencies.metFor(dependenciesTrue))
		{
			requisiteState = true;
		}
		else if (Dependencies.partiallyMetForWhereEmptyIsFalse(partialDependenciesOtherwiseFalse))
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