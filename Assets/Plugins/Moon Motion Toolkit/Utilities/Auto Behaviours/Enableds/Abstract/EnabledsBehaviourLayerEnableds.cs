using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enableds Behaviour Layer Enableds:
// #auto
// • provides this enableds behaviour with enableds features
public abstract class	EnabledsBehaviourLayerEnableds<EnabledsBehaviourT> :
					AutoBehaviour<EnabledsBehaviourT>
						where EnabledsBehaviourT : EnabledsBehaviour<EnabledsBehaviourT>
{
	// variables //

	
	// trackings //

	// the set of all enabled instances (of this particular specialization of EnabledsBehaviour) //
	private static HashSet<EnabledsBehaviourT> enableds_ = new HashSet<EnabledsBehaviourT>();
	public static HashSet<EnabledsBehaviourT> enableds
	{
		get
		{
			return	UnityIs.inEditorEditMode ?
						Hierarchy.allYullAndEnabledAndUnique<EnabledsBehaviourT>() :
						enableds_.uniqueYulls();
		}
	}




	// properties //


	// returns a new copy of the set of all enabled instances //
	public static HashSet<EnabledsBehaviourT> enabledsCopy => enableds.copy();

	// this instance as an instance of a particular class specializing EnabledsBehaviour //
	public EnabledsBehaviourT enabledsBehaviour => this.castTo<EnabledsBehaviourT>();




	// methods //


	// method: (according to the given boolean:) invoke the given action on each item in this class's enableds, then return this class's enableds //
	public static HashSet<EnabledsBehaviourT> forEachEnabled(Action<EnabledsBehaviourT> action, bool boolean = true)
		=> enableds.forEach(action, boolean);

	// method: (according to the given boolean:) invoke the given action on each item in a copy of (references to) this class's enableds, then return the copy //
	public static HashSet<EnabledsBehaviourT> forEachCopiedEnabled(Action<EnabledsBehaviourT> action, bool boolean = true)
		=> enabledsCopy.forEach(action, boolean);




	// updating //

	
	// upon being enabled: //
	public virtual void OnEnable()
		=> enableds_.include(enabledsBehaviour);

	// upon being disabled: //
	public virtual void OnDisable()
		=> enableds_.remove(enabledsBehaviour);
}