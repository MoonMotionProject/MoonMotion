using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using NaughtyAttributes;

// Hand Locomotion Controlled
// • provides input functionality to this hand locomotion
//   · a toggle setting determines whether this hand locomotion's input is currently enabled
//     - methods are provided to toggle this enablement
public abstract class HandLocomotionControlled : HandLocomotion
{
	// variables //
	
	
	// variables for: input //
	[Header("Locomotion Input")]
	[ReorderableList]
	public Controller.Input[] inputsLocomotion = new Controller.Input[] {Controller.Input.touchpad};		// setting: array of controller inputs to use – defaulted to touchpad because it is the most versatile
	public bool locomotionInputEnabled = true;		// setting: whether this locomotion's input is currently enabled




	// methods //

	
	// method: toggle whether this module's input is currently enabled based on the given toggling //
	public void toggleLocomotionInputEnablement(Toggling toggling)
		=> locomotionInputEnabled = locomotionInputEnabled.toggledBy(toggling);
	// method: toggle whether this module's input is currently enabled using an inversion toggling //
	public void toggleLocomotionInputEnablement()
		=> toggleLocomotionInputEnablement(Toggling.invertToggle);

	// method: determine whether this hand locomotion's input is currently enabled and currently allowed //
	public virtual bool locomotionInputEnabledAndAllowed()
		=> (locomotionInputEnabled && locomotionDependencies.areMet());
}