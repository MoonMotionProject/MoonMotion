using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Booster Halter
// • provides booster halting control: held input prevents boosting from occurring
//   · can optionally halt globally (one controller's input has both halters halt)
public class BoosterHalter : BoosterModuleControllable
{
	// variables //
	

	// variables for: instancing //
	private static BoosterHalter left, right;		// trackings: halter instances
	private BoosterHalter other;		// tracking: other halter instance
	
	// variables for: input //
	[Header("Halting")]
	public bool haltsGlobally = false;		// setting: whether input should affect both halters instead of just this one

	// variables for: halting //
	[HideInInspector] public bool halting = false;		// tracking: whether this halter is currently halting
	
	
	
	
	// updating //

	
	// at the start: connect to halter instances //
	protected override void Start()
	{
		base.Start();

		if (leftInstance)
		{
			left = this;
		}
		else
		{
			right = this;
		}
		other = controller.otherController.GetComponentInChildren<BoosterHalter>();
	}

	private void Update()
	{
		// if: the dependencies are met, input is enabled, input is pressed: //
		if (other.dependencies.areMet() && inputEnabled && controller.inputPressed(inputs))
		{
			// halt //
			halting = true;
			// if the halting is set to be global: have the other halter halt as well //
			if (haltsGlobally)
			{
				if (leftInstance)
				{
					right.halting = true;
				}
				else
				{
					left.halting = true;
				}
			}
		}
		// otherwise (if input is not pressed) and if the other halter is not halting globally: //
		else if (!(other && other.haltsGlobally && other.dependencies.areMet() && other.inputEnabled && other.controller && other.controller.inputPressed(other.inputs)))
		{
			// don't halt //
			halting = false;
		}
	}




	// methods //
	
	
	// method: determine whether the given booster is currently halted //
	public static bool halted(Booster booster)
	{
		if (booster.leftInstance)
		{
			if (left && left.gameObject && left.gameObject.activeInHierarchy)
			{
				return left.halting;
			}
		}
		else
		{
			if (right && right.gameObject && right.gameObject.activeInHierarchy)
			{
				return right.halting;
			}
		}
		return false;
	}
}