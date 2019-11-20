using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

// Ether:
// • singleton for the Ether, a universal game object intended to be loaded in all situations
// • provides access to #auto functionality generically without the need for a corresponding object, which is used to execute auto behaviour methods statically that would otherwise require an auto behaviour; notably, this includes:
//   · the updating and physics updating of all enabled auto behaviours
//   · static execution such as for coroutines
// #auto #updating #execution #coroutines
[UseClassNameForObjectUponValidation]
public class Ether : SingletonBehaviour<Ether>
{
	// updating //

	
	// before the start: //
	public override void Awake()
	{
		base.Awake();

		makeUniversal();
	}

	// at each update: //
	private void Update()
		=> AutoBehaviours.enabled_IfPlaying_Copy.forEach(autoBehaviour =>
		{
			if (autoBehaviour.isYull() && autoBehaviour.castTo<MonoBehaviour>().enabled)
			{
				autoBehaviour.update();
			}
		});

	// at each physics update: //
	private void FixedUpdate()
		=> AutoBehaviours.enabled_IfPlaying_Copy.forEach(autoBehaviour =>
		{
			if (autoBehaviour.isYull() && autoBehaviour.castTo<MonoBehaviour>().enabled)
			{
				autoBehaviour.physicsUpdate();
			}
		});

	// at each late update: //
	private void LateUpdate()
		=> AutoBehaviours.enabled_IfPlaying_Copy.forEach(autoBehaviour =>
		{
			if (autoBehaviour.isYull() && autoBehaviour.castTo<MonoBehaviour>().enabled)
			{
				autoBehaviour.lateUpdate();
			}
		});
}