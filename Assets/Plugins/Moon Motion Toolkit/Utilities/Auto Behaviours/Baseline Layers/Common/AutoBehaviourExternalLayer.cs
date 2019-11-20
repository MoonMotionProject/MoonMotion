using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour External Layer:
// #auto #common
// • an auto behaviour layer that is external (a separate component, instead of being inherited by each auto behaviour), so as to be shared among all auto behaviours on this game object
//   · ensured to be present on this game object whenever an auto behaviour is on this game object, by way of a RequireComponent attribute on all auto behaviours
// • in either the editor or the build, uncache's this game object's components upon being destroyed (so also when this game object is destroyed)
// • upon validation (so in the editor only), will bother to destroy itself if no longer required (by any auto behaviour) to keep this game object clean; checking for this uses reflection which makes it not worth it when in the build
// • is hidden, so as to reduce clutter and since it is not able/needed to be removed except when automatically removed (in the editor, upon validation) if no longer required, anyway
[ExecuteInEditMode]     // this is to allow OnDestroy to be executed in the editor
public class AutoBehaviourExternalLayer : MonoBehaviour
{
	// variables //

	
	public const float playingHiddennessRefreshingInterval = 5f;
	
	private bool validatedYet = false;

	


	// methods //
	
	
	public void refreshHiddenness()
	{
		#if MOON_MOTION_TOOLKIT_SHOW_COMMON_BEHAVIOURS
		this.unhideInInspector();
		#else
		this.hideInInspector();
		#endif
	}
	
	
	
	
	// updating //

	
	#if UNITY_EDITOR
	// upon validation: //
	[ContextMenu("OnValidate")]
	public void OnValidate()
	{
		refreshHiddenness();

		if (validatedYet)
		{
			if (!this.isRequired_ViaAdditionalReflection())
			{
				this.unhideInInspector();

				if (gameObject.isNotPartOfPrefabAsset())
				{
					try
					{
						this.destroy();
					}
					catch (Exception unexpectedException)
					{
						unexpectedException.logAsError("an Auto Behaviour External Layer\nneeds to destroy itself\nsince it is no longer required,\nbut encountered this unexpected exception;\nit is located on "+gameObject+",\nand has unhidden itself...\nfigure out why it couldn't be destroyed,\nprevent that from being an issue in the future,\nand destroy it!");
					}
				}
				/* previously, an error was put out whenever an instance of this behaviour was no longer required but was on a prefab... this is disabled now because it doesn't really have a significant negative impact if it stays
				else
				{
					GameObject prefabThisIsOn
						=	Prefabs.withAnyLodalAutoBehaviourExternalLayer
								.firstWhere(prefab =>
									prefab.lodal<AutoBehaviourExternalLayer>().contains(this));

					New.exception.logAsError("an Auto Behaviour External Layer\nneeds to destroy itself\nsince it is no longer required,\nbut it is on a prefab\nso it cannot be destroyed;\nit is located on "+gameObject+"\nof prefab "+prefabThisIsOn+",\nand has unhidden itself... go destroy it!");
				}*/
			}
		}
		else
		{
			validatedYet = true;
		}
	}
	
	// at the start: //
	private void Start()
	{
		if (UnityIs.playing)
		{
			Begin.coroutineRepeatingEvery
			(
				playingHiddennessRefreshingInterval,
				()=>
				{
					if (this.isYull())
					{
						refreshHiddenness();
					}
				},
				false
			);
		}
	}
	#endif

	// upon destruction: //
	private void OnDestroy()
		=> gameObject.tryToUncache();
}