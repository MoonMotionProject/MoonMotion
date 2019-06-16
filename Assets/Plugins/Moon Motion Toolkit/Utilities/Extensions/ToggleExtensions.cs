using UnityEngine;
using System.Collections;

// Toggle Extensions
// • provides extension methods for handling toggles
//   · a "toggle" is a boolean designed to change in the way of a "toggling" (as defined by 'Toggling')
public static class ToggleExtensions
{
	// method: return this boolean toggled according to the given toggling //
	public static bool toggledBy(this bool toggle, Toggling toggling)
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

	// method: return this given boolean inverted //
	public static bool toggled(this bool toggle)
		=> toggle.toggledBy(Toggling.invertToggle);
}