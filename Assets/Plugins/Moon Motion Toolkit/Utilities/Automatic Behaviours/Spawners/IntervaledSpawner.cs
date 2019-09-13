using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Intervaled Spawner:
// • spawns the set template as a child and plans to do so again after the set interval
public class IntervaledSpawner : EnabledsBehaviour<IntervaledSpawner>
{
	// variables //

	
	// settings //

	[Tooltip("the template object to spawn instances of")]
	[ShowAssetPreview]
	public GameObject template;
	
	[Tooltip("the delay to wait between spawnings")]
	public float interval = Default.interval;
	
	[Tooltip("whether to wait the interval before the first spawn (at the start)")]
	public bool intervalBeforeFirstSpawn = false;




	// methods //

	
	// method: spawn the set template, then return the spawned object //
	[ContextMenu("Spawn")]
	public virtual GameObject spawn()
		=> createChildObject(template);

	// method: plan to call 'spawnAndPlanToRepeat' after the interval //
	[ContextMenu("Plan")]
	public void plan()
		=>	planToExecuteAfter
			(
				interval,
				()=> spawnAndPlanToRepeat()
			);

	// method: spawn the set template and plan to repeat this method after the interval //
	[ContextMenu("Spawn And Plan To Repeat")]
	public void spawnAndPlanToRepeat()
	{
		spawn();
		plan();
	}




	// updating //

	
	// at the start: //
	private void Start()
	{
		if (intervalBeforeFirstSpawn)
		{
			plan();
		}
		else
		{
			spawnAndPlanToRepeat();
		}
	}
}