using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatic Behaviour Layer Static Shortcuts:
// #auto
// • provides this behaviour with easier access to commonly-used static state and methods
public abstract class	AutomaticBehaviourLayerStaticShortcuts<AutomaticBehaviourT> :
					MonoBehaviour
						where AutomaticBehaviourT : AutomaticBehaviour<AutomaticBehaviourT>
{
	// properties/methods for: time //

	public static float time
	{
		get {return Time.time;}
	}
	public static float timeSince(float previousTime)
		=> time.since(previousTime);

	public static float timeSinceLastUpdate
	{
		get {return Time.deltaTime;}
	}

	public static float timeSinceLastFixedUpdate
	{
		get {return Time.fixedDeltaTime;}
	}
}