using UnityEngine;
using System.Collections;

// Toggles
// • enumerates possible kinds of toggling
//   · toggling means to change a toggle
//     - a toggle is a boolean designed to change
// • provides a method for toggling a given toggle using the given toggling
public static class Toggles
{
	// enumerations //

	
	// enumeration of: possible kinds of toggling //
	public enum Toggling
	{
		invertToggle,		// this is the default kind/definition of toggling: inverting the boolean
		toggleOn,		// set the boolean to be true
		toggleOff,		// set the boolean to be false
		noToggling		// don't change the boolean
	}




	// methods //

	
	// method: determine the result of toggling the given toggle based on the given toggling //
	public static bool toggleToggle(bool toggle, Toggling toggling)
	{
		if (toggling == Toggling.invertToggle)
		{
			toggle = !toggle;
		}
		else if (toggling == Toggling.toggleOn)
		{
			toggle = true;
		}
		else if (toggling == Toggling.toggleOff)
		{
			toggle = false;
		}

		return toggle;
	}
}