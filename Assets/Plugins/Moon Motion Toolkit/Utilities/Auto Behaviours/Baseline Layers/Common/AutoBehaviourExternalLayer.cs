using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour External Layer:
// #auto
// • an auto behaviour layer that is external (a separate component, instead of being inherited by each auto behaviour), so as to be shared among all auto behaviours on this game object
//   · ensured to be present on this game object whenever an auto behaviour is on this game object, by way of a RequireComponent attribute on all auto behaviours
// • in either the editor or the build, uncache's this game object's components upon being destroyed (so also when this game object is destroyed)
// • upon validation (so in the editor only), will bother to destroy itself if no longer required (by any auto behaviour) to keep this game object clean; checking for this uses reflection which makes it not worth it when in the build
// • is hidden, so as to reduce clutter and since it is not able/needed to be removed except when automatically removed (in the editor, upon validation) if no longer required, anyway
[ExecuteInEditMode]     // this is to allow OnDestroy to be executed in the editor
public class AutoBehaviourExternalLayer : MonoBehaviour
{
	// variables //

	// trackings //

	private bool validatedYet = false;




	// properties //

	
	// whether this behaviour is currently required //
	public virtual bool behaviourRequired => this.required_ViaReflection();




	// updating //

	
	// upon validation: //
	[ContextMenu("OnValidate")]
	public void OnValidate()
	{
		this.hideInInspector();

		if (validatedYet)
		{
			if (!behaviourRequired)
			{
				this.destroy();
			}
		}
		else
		{
			validatedYet = true;
		}
	}

	// upon being destroyed: //
	private void OnDestroy()
		=> gameObject.tryToUncache();
}