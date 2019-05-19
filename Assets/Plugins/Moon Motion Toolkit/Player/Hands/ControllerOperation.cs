using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller Operation:
// • a controller operation is used to determine controller operational status based on:
//   · a specified controller handedness
//   · a set array of inputs
//   · a set array of inputtednesses
//   · a set array of states of being
//   · a set dependencies combination
// • represents a Controller Operation as a scriptable object, with the aforementioned settings
// • provides a definition for a set of controller operations
// • provides methods for determining:
//   · whether this operation's dependencies are met
//   · whether this operation is currently operated
//   · the set of controllers for which this controller operation is currently operated
[CreateAssetMenu(fileName = "ControllerOperation", menuName = "Moon Motion/Controller Operation")]
public class ControllerOperation : ScriptableObject
{
	// definitions //

	
	// definition of a set of controller operations
	// (this is done as a workaround for Controller Operation double arrays because those aren't editable in the inspector)
	[System.Serializable]
	public class SetOfControllerOperations
	{
		public ControllerOperation[] array = new ControllerOperation[] { };

		// method: determine whether this set of controller operations is currently operated //
		public bool operated()
		{
			return Controller.operated(this);
		}
	}




	// variables //


	public Controller.Handedness handedness;		// setting: the controller handedness (determining which controllers to check operation of)
	public Controller.Input[] inputs;      // setting: the controller inputs (to check operation upon)
	public Controller.Inputtedness[] inputtednesses;        // setting: the controller inputtednesses (to check operation by)
	public StatesOfBeing.Beingness[] beingnesses;       // setting: the states of being (to check operation at)
	public Dependencies.DependenciesCombination dependenciesThorough;     // setting: the combination of dependencies to check thoroughly (by which to condition this operation where each dependency is necessary)
	public Dependencies.DependenciesCombination dependenciesPartial;     // setting: the combination of dependencies to check partially (by which to condition this operation where any of the dependencies is necessary)




	// methods //

	
	// method: determine whether this operation's dependencies are met //
	public bool dependenciesMet()
	{
		return (Dependencies.metFor(dependenciesThorough) && Dependencies.partiallyMetForWhereEmptyIsTrue(dependenciesPartial));
	}
	
	// method: determine whether this operation is currently operated //
	public bool operated()
	{
		return Controller.operated(this);
	}

	// method: determine the set of controllers for which this operation is currently operated //
	public HashSet<Controller> operatedControllers()
	{
		return Controller.operatedControllers(this);
	}
}