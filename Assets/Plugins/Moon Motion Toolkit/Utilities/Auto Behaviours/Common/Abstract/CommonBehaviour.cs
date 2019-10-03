using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Common Behaviour
// • intended to provide functionality that is "common" to this game object / this game object's auto behaviours; functionality that is both:
//   · general to this game object
//   · shared among other auto behaviours on this game object, such that they don't each have to duplicate this functionality
// • in the editor:
//   · removes itself if not required
//   · is hidden in the inspector
// • note that other behaviours are responsible for enforcing the requirement of this behaviour (via RequireComponent or other mechanisms of forcing this behaviour to always exist on this game object when required)
// • note that this behaviour is not automatically cleaned up on game objects any more often than OnValidate is called (notably only called in editor), as doing so (for instance, checking if still required by checking if components have been removed each frame) seems it would require too much performance
/* nonabstract derived classes must override OnValidate if it is to be found using reflection */
[HideComponentInInspector]
public abstract class	CommonBehaviour<CommonBehaviourT> :
					AutoBehaviour<CommonBehaviourT>
						where CommonBehaviourT : CommonBehaviour<CommonBehaviourT>
{
	// variables //

	// trackings //

	private bool validatedYet = false;




	// properties //

	
	// whether this behaviour is currently required //
	public virtual bool behaviourRequired => required_ViaReflection();




	// updating //


	// upon validation: //
	public override void OnValidate()
	{
		base.OnValidate();

		if (validatedYet)
		{
			if (!behaviourRequired)
			{
				destroyThisBehaviour();
			}
		}
		else
		{
			validatedYet = true;
		}
	}
}