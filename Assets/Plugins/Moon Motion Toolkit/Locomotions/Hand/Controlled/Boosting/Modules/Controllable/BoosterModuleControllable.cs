using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Booster Module Controllable
// • provides this booster module with:
//   · a corresponding controller connection
//   · an inputs setting
//   · a setting for whether this module's input is currently enabled
//     - methods for toggling whether this module's input is currently enabled
public abstract class BoosterModuleControllable : BoosterModule
{
	// variables //

	
	// variables for: controller connection and inputs setting //
	protected Controller controller;		// connection - auto: the controller of this module's booster
	[BoxGroup("Input")]
	[ReorderableList]
	public Controller.Input[] inputs = new Controller.Input[] {Controller.Input.none};		// setting: array of controller inputs to use for controlling this module
	[BoxGroup("Input")]
	public bool inputEnabled = true;		// setting: whether this module's input is currently enabled




	// methods //

	
	// method: toggle whether this module's input is currently enabled based on the given toggling //
	public void toggleInputEnablement(Toggling toggling)
	{
		inputEnabled = inputEnabled.toggledBy(toggling);
	}
	// method: toggle whether this module's input is currently enabled using an inversion toggling //
	public void toggleInputEnablement()
	{
		toggleInputEnablement(Toggling.invertToggle);
	}




	// updating //

	
	// before the start: connect to the controller //
	protected override void Awake()
	{
		base.Awake();
		
		controller = transform.parent.parent.GetComponent<Controller>();
	}
}