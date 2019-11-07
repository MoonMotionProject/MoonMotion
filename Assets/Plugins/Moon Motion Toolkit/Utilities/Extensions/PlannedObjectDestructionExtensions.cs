using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Planned Object Destruction Extensions:
// • provides extension methods for handling Planned Object Destructions
// #destruction #PlannedObjectDestruction
public static class PlannedObjectDestructionExtensions
{
	// method: (according to the given boolean:) plan to destroy this given game object after the given delay, then return this given game object //
	public static GameObject destroyObjectAfter(this GameObject gameObject, float delay, bool boolean = true)
	{
		if (boolean)
		{
			gameObject.addGet<PlannedObjectDestruction>().setDelayTo(delay);
		}

		return gameObject;
	}

	// method: (according to the given boolean:) plan to destroy this given component's game object after the given delay, then return this given component //
	public static Component destroyObjectAfter(this Component component, float delay, bool boolean = true)
	{
		if (boolean)
		{
			component.addGet<PlannedObjectDestruction>().setDelayTo(delay);
		}

		return component;
	}
}