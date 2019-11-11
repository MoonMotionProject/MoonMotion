using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Implementation:
// • derives from mono behaviour
// • implements the auto behaviour interface in order to:
//   · provide this behaviour with auto behaviour classification
//   · has 'AutoBehaviours' statically track this auto behaviour while it is enabled
//   · provide update and physics update updating methods for the Ether to call via 'AutoBehaviours', improving performance by avoiding more expensive Unity's 'Update' and 'FixedUpdate' calling process
//     - reference: https://www.reddit.com/r/Unity3D/comments/7hi40o/i_just_realized_destroy_had_a_time_delay/dqtlkra/?context=8&depth=9
// #auto #updating
public class AutoBehaviourLayerImplementation :
	MonoBehaviour,
	IAutoBehaviour
{
	// upon enablement: //
	public virtual void OnEnable()
		=> AutoBehaviours.enabled_IfPlaying.include(this);

	// upon disablement: //
	public virtual void OnDisable()
		=> AutoBehaviours.enabled_IfPlaying.remove(this);

	// at each physics update: //
	public virtual void physicsUpdate() {}

	// at each update: //
	public virtual void update() {}

	// at each late update: //
	public virtual void lateUpdate() {}
}