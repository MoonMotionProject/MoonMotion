using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Intervaled Spawner Forceful:
// • classifies this intervaled spawner as one which:
//   · when spawning objects, applies the set force to each in the set basic direction relative to this spawner
public class IntervaledSpawnerForceful : IntervaledSpawner
{
	// variables //
	
	
	// settings //
	
	[Tooltip("the magnitude with which to apply force to spawned objects")]
	public float forceMagnitude = Default.forceMagnitude;

	[Tooltip("the basic direction in which to apply force to spawned objects")]
	public BasicDirection forceDirection = Default.basicDirection;




	// methods //


	// method: spawn the set template //
	[ContextMenu("Spawn")]
	public override GameObject spawn()
		=> base.spawn().applyForceAlong(relativeDirectionFor(forceDirection), forceMagnitude);
}