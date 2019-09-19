using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enableds Behaviour Layer Component:
// #auto
// • provides this enableds behaviour with static access for each of its enableds to its auto behaviour's component layer
public abstract class	EnabledsBehaviourLayerComponent<EnabledsBehaviourT> :
					EnabledsBehaviourLayerEnableds<EnabledsBehaviourT>
						where EnabledsBehaviourT : EnabledsBehaviour<EnabledsBehaviourT>
{
	#region destruction

	// method: (according to the given boolean:) destroy this component //
	public static void destroyEnableds(bool boolean = true)
		=>	forEachCopiedEnabled
			(
				enabled =>
				enabled.destroy()
			);

	// method: destroy all objects of enableds of this behaviour for which the given function returns true, then return this behaviour's enableds //
	public static HashSet<EnabledsBehaviourT> destroyObjectsOfEnabledsWhere(Func<EnabledsBehaviourT, bool> function)
		=> enabledsCopy.destroyObjectsWhere(function);
	#endregion destruction
}