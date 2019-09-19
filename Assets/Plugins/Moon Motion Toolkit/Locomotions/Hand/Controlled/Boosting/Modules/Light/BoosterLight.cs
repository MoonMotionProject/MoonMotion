using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Light:
// • connects this booster module to any children lights
// • toggles enablement of the lights' objects according to the module input and the module dependencies
public class BoosterLight : BoosterModule
{
	// variables //

	
	// variables for: light //
	protected HashSet<Light> lights = new HashSet<Light>();	   // connections - auto: children lights




	// updating //

	
	// before the start: connect to the children lights //
	protected override void Awake()
	{
		base.Awake();
		
		Light[] lightsAttachedOrChildren = GetComponentsInChildren<Light>();
		foreach (Light lightAttachedOrChild in lightsAttachedOrChildren)
		{
			if (lightAttachedOrChild.transform != transform)
			{
				lights.Add(lightAttachedOrChild);
			}
		}
	}

	// at each update: //
	protected virtual void Update()
	{
		// toggle enablement of the lights' objects according to the module dependencies //
		bool targetEnablement = dependencies.areMet();
		foreach (Light light in lights)
		{
			light.gameObject.SetActive(targetEnablement);
		}
	}
}