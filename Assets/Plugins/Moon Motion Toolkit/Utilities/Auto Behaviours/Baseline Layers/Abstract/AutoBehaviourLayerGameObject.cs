using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Auto Behaviour Layer Game Object:
// #auto #gameobject
// • provides this behaviour with properties and methods for its game object
public abstract class	AutoBehaviourLayerGameObject<AutoBehaviourT> :
					AutoBehaviourLayerComponentsNonUnity<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region determining prefabness

	public bool isPrefabAsset => gameObject.isPrefabAsset();
	public bool isNotPrefabAsset => !isPrefabAsset;
	#endregion determining prefabness
	

	#region creating fresh game objects

	public GameObject createChildObject
	(
		string name = Default.newGameObjectName,
		bool matchRotationToParent = Default.matchingOfRotationToParentForFreshGameObjectCreation,
		bool matchLayersToParent = Default.matchingOfLabelsToParentForFreshGameObjectCreation
	)
		=> transform.createChildObject(name, matchRotationToParent, matchLayersToParent);
	#endregion creating fresh game objects


	#region creating templated game objects

	public GameObject createChildObject
	(
		GameObject template,
		string name = "",
		bool matchRotationToParent = Default.matchingOfRotationToParentForTemplatedGameObjectCreation,
		bool matchLabelsToParent = Default.matchingOfLabelsToParentForTemplatedGameObjectCreation
	)
		=> gameObject.createChildObject(template, name, matchRotationToParent, matchLabelsToParent);
	#endregion creating templated game objects


	#region destruction

	#region of this object
	public void destroyThisObject(bool boolean = true)
		=> gameObject.destroy(boolean);
	#endregion of this object
	
	#region of the other given object
	public void destroy(GameObject otherGameObject, bool boolean = true)
		=> otherGameObject.destroy(boolean);
	#endregion of the other given object
	#endregion destruction


	#region hierarchy selection
	#if UNITY_EDITOR

	public bool selected => gameObject.selected();
	public bool notSelected => gameObject.isNotSelected();
	#endif
	#endregion hierarchy selection


	#region name

	public AutoBehaviourT setNameTo(string name, bool boolean = true)
		=> selfAfter(()=> gameObject.setNameTo(name, boolean));
	public AutoBehaviourT setNameToSimpleClassName(bool boolean = true)
		=> selfAfter(()=> setNameTo(simpleClassName, boolean));
	public AutoBehaviourT toNameAppend(string suffix, bool boolean = true)
		=> selfAfter(()=> gameObject.toNameAppend(suffix, boolean));
	#endregion name


	#region activity

	// method: return whether this behaviour's game object is active locally //
	public bool activeLocally => gameObject.activeLocally();

	// method: return whether this behaviour's game object is active globally //
	public bool activeGlobally => gameObject.activeGlobally();

	// method: set the activity of this behaviour's game object to the given boolean, then return this behaviour //
	public AutoBehaviourT setActivityTo(bool enablement)
		=> selfAfter(()=> gameObject.setActivityTo(enablement));

	// method: activate this behaviour's game object, then return this behaviour //
	public AutoBehaviourT activate()
		=> selfAfter(()=> gameObject.activate());

	// method: deactivate this behaviour's game object, then return this behaviour //
	public AutoBehaviourT deactivate()
		=> selfAfter(()=> gameObject.deactivate());

	// method: toggle the activity of this behaviour's game object using the given toggling, then return this behaviour //
	public AutoBehaviourT toggleActivityBy(Toggling toggling)
		=> selfAfter(()=> gameObject.toggleActivityBy(toggling));

	// method: toggle the activity of this behaviour's game object, then return this behaviour //
	public AutoBehaviourT toggleActivity()
		=> selfAfter(()=> gameObject.toggleActivity());
	#endregion activity


	#region tag setting

	public AutoBehaviourT setTagTo(object tag_TagProvider, bool boolean = true)
		=> selfAfter(()=> gameObject.setTagTo(tag_TagProvider, boolean));
	#endregion tag setting


	#region layer identification

	public string layerName => gameObject.layerName();
	
	public int layerIndex => gameObject.layerIndex();
	
	public bool layerIsDefault => gameObject.isOnDefaultLayer();

	public bool layerIsNotDefault => gameObject.isNotOnDefaultLayer();
	#endregion layer identification


	#region layer matching

	public bool layerMatches(object layerIndex_ProvidedLayerIndex)
		=> gameObject.layerMatches(layerIndex_ProvidedLayerIndex);
	#endregion layer matching


	#region layer determination

	public bool isPlayerLayer => gameObject.isPlayerLayer();
	public bool isNotPlayerLayer => !isPlayerLayer;
	
	#if UNITOLOGY
	public bool isPlayerNeutralLayer => layerName.isPlayerNeutralLayer();
	
	public bool isPlayerEnemyLayer => layerName.isPlayerEnemyLayer();

	public bool isPlayerAllyLayer => layerName.isPlayerAllyLayer();

	public bool isPlayerAllegianceLayer => layerName.isPlayerAllegianceLayer();
	#endif
	#endregion layer determination


	#region layer setting

	public AutoBehaviourT setLayerTo(object layerIndex_LayerIndexProvider, bool boolean = true)
		=> selfAfter(()=> gameObject.setLayerTo(layerIndex_LayerIndexProvider, boolean));

	public AutoBehaviourT setLayerAndMatchingDescendantLayersTo
	(
		object layerIndex_LayerIndexProvider,
		bool boolean = true
	)
		=>	selfAfter(()=> gameObject.setLayerAndMatchingDescendantLayersTo(layerIndex_LayerIndexProvider),
				boolean);
	#endregion layer setting


	#region labels setting
	
	public AutoBehaviourT setLabelsTo(object otherGameObject_GameObjectProvider, bool boolean = true)
		=> selfAfter(()=> gameObject.setLabelsTo(otherGameObject_GameObjectProvider, boolean));
	#endregion labels setting


	#region calling local methods

	public AutoBehaviourT executeAllLocal(string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true)
		=> selfAfter(()=> gameObject.executeAllLocal(methodName, sendMessageOptions, boolean));

	public AutoBehaviourT validate_IfInEditor()
		=> selfAfter(()=> gameObject.validate_IfInEditor());
	#endregion calling local methods


	#region validation pending
	#if UNITY_EDITOR

	public AutoBehaviourT unpendValidation_IfInEditor()
		=> selfAfter(()=> gameObject.unpendValidation_IfInEditor());

	public AutoBehaviourT pendValidation_IfInEditor()
		=> selfAfter(()=> gameObject.pendValidation_IfInEditor());
#endif
	#endregion validation pending


	#region scene determination

	public Scene scene => gameObject.scene;
	#endregion scene determination
}