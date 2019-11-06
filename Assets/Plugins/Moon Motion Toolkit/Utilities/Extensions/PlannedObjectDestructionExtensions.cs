using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Planned Object Destruction Extensions:
// • provides extension methods for handling Planned Object Destructions
// #destruction #PlannedObjectDestruction
public static class PlannedObjectDestructionExtensions
{
	// method: (according to the given boolean:) destroy this given game object after the given delay //
	public static void destroyObjectAfter(this GameObject gameObject, float delay, bool boolean = true)
	{
		if (boolean)
		{
			gameObject.addGet<PlannedObjectDestruction>().setDelayTo(delay);
		}
	}

	// method: (according to the given boolean:) destroy this given component's game object after the given delay //
	public static void destroyObjectAfter(this Component component, float delay, bool boolean = true)
	{
		if (boolean)
		{
			component.addGet<PlannedObjectDestruction>().setDelayTo(delay);
		}
	}
}