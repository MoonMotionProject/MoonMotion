using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Module
// • classifies this booster child object as a booster module: a component of the booster in charge of handling a particular functionality
// • provides:
//   · a connection to the corresponding parent booster's transform
//   · a connection to the booster
//   · a tracking for the booster's handedness (whether the booster is for the left hand versus the right)
//   · a dependencies setting to require such conditions for the module to be active
public abstract class BoosterModule : MonoBehaviour
{
	// variables //

	
	// variables for: booster connections and handedness tracking //
	protected Transform boosterTransform;		// connection - auto: the booster's transform
	protected Booster booster;		// connection - auto: the booster this module is for
	protected bool leftInstance;		// tracking: the booster's handedness

	// variables for: dependencies //
	[BoxGroup("Dependencies")]
	[Tooltip("the dependencies by which to determine whether this booster module may be enabled")]
	[ReorderableList]
	public Dependency[] dependencies;




	// updating //

	
	// before the start: connect to the booster //
	protected virtual void Awake()
	{
		boosterTransform = transform.parent;
		booster = boosterTransform.GetComponent<Booster>();
	}

	// at the start: track the booster's handedness //
	protected virtual void Start()
	{
		leftInstance = (booster.leftInstance);
	}
}