using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Powerup Instance Methods Caller
// • adds the following pickup functionality to this powerup:
//   · calls each of the the methods listed in the 'OnClick()' list of the attached Button
//     - this provides a way of calling each method of a list of methods setting, which is a very general-purpose approach for having a powerup pickup do things
[RequireComponent(typeof(Button))]
public class PowerupInstanceMethodsCaller : Powerup
{
	// variables //

	
	// variables for: calling methods //
	protected Button button;		// connection - auto: the button attached to this powerup




	// methods //

	
	// method: cast this powerup //
	public override void cast()
	{
		// by simulating a button click: call each of the the methods listed in the 'OnClick()' list of the attached Button //
		button.onClick.Invoke();
	}




	// updating //

	
	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to the button //
		button = GetComponent<Button>();
	}
}