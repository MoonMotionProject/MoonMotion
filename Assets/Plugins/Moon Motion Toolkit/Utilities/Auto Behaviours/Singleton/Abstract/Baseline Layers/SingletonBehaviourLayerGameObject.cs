using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Singleton Behaviour Layer Game Object:
// #auto #gameobject #name
// • provides this singleton behaviour with static access to its auto behaviour's game object layer
public abstract class	SingletonBehaviourLayerGameObject<SingletonBehaviourT> :
					SingletonBehaviourLayerComponentsNonUnity<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region determining prefabness

	public static new bool isPrefabAsset => autoBehaviour.isPrefabAsset;
	public static new bool isNotPrefabAsset => autoBehaviour.isNotPrefabAsset;
	#endregion determining prefabness
	

	#region existence

	public static new bool destroyed => autoBehaviour.destroyed;

	public static new bool exists => autoBehaviour.exists;
	#endregion existence


	#region creating fresh game objects

	public static new GameObject createChildObject
	(
		string name = Default.newGameObjectName,
		bool matchRotationToParent = Default.matchingOfRotationToParentForFreshGameObjectCreation,
		bool matchLayersToParent = Default.matchingOfLabelsToParentForFreshGameObjectCreation
	)
		=> autoBehaviour.createChildObject(name, matchRotationToParent, matchLayersToParent);
	#endregion creating fresh game objects


	#region creating templated game objects

	public static new GameObject createChildObject
	(
		GameObject template,
		string name = "",
		bool matchRotationToParent = Default.matchingOfRotationToParentForTemplatedGameObjectCreation,
		bool matchLabelsToParent = Default.matchingOfLabelsToParentForTemplatedGameObjectCreation
	)
		=> autoBehaviour.createChildObject(template, name, matchRotationToParent, matchLabelsToParent);
	#endregion creating templated game objects


	#region destruction

	#region of this object
	public static new void destroyThisObject(bool boolean = true)
		=> autoBehaviour.destroyThisObject(boolean);
	#endregion of this object
	
	#region of the other given object
	public static new void destroy(GameObject otherGameObject, bool boolean = true)
		=> autoBehaviour.destroy(otherGameObject, boolean);
	#endregion of the other given object
	#endregion destruction


	#region determining hierarchy selection
	#if UNITY_EDITOR

	public static new bool isSelected => autoBehaviour.isSelected;
	public static new bool isNotSelected => autoBehaviour.isNotSelected;
	#endif
	#endregion determining hierarchy selection


	#region setting hierarchy selection
	#if UNITY_EDITOR

	public static new GameObject select()
		=> autoBehaviour.select();
	#endif
	#endregion setting hierarchy selection


	#region setting hierarchy expansion
	#if UNITY_EDITOR

	public static new void setExpansionTo(bool expansion)
		=> autoBehaviour.setExpansionTo(expansion);
	public static new void expand()
		=> autoBehaviour.expand();
	public static new void collapse()
		=> autoBehaviour.collapse();

	public static new void setExpansionForSelfAndDescendantsTo(bool expansion)
		=> autoBehaviour.setExpansionForSelfAndDescendantsTo(expansion);
	public static new void expandSelfAndDescendants()
		=> autoBehaviour.expandSelfAndDescendants();
	public static new void collapseSelfAndDescendants()
		=> autoBehaviour.collapseSelfAndDescendants();
	#endif
	#endregion setting hierarchy expansion


	#region name

	public static new AutoBehaviour<SingletonBehaviourT> setNameTo(string name, bool boolean = true)
		=> autoBehaviour.setNameTo(name, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setNameToSimpleClassName(bool boolean = true)
		=> autoBehaviour.setNameToSimpleClassName(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> toNameAppend(string suffix, bool boolean = true)
		=> autoBehaviour.toNameAppend(suffix, boolean);
	#endregion name


	#region name comparison

	public static new bool nameMatches(string name)
		=> autoBehaviour.nameMatches(name);
	public static new bool nameContains(string string_)
		=> autoBehaviour.nameContains(string_);
	#endregion name comparison


	#region activity

	// method: return whether this behaviour's game object is active locally //
	public static new bool activeLocally => autoBehaviour.activeLocally;

	// method: return whether this behaviour's game object is active globally //
	public static new bool activeGlobally => autoBehaviour.activeGlobally;

	// method: set the activity of this behaviour's game object to the given boolean, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> setActivityTo(bool boolean)
		=> autoBehaviour.setActivityTo(boolean);

	// method: activate this behaviour's game object, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> activate()
		=> autoBehaviour.activate();

	// method: deactivate this behaviour's game object, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> deactivate()
		=> autoBehaviour.deactivate();

	// method: toggle the activity of this behaviour's game object using the given toggling, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> toggleActivityBy(Toggling toggling)
		=> autoBehaviour.toggleActivityBy(toggling);

	// method: toggle the activity of this behaviour's game object, then return this behaviour //
	public static new AutoBehaviour<SingletonBehaviourT> toggleActivity()
		=> autoBehaviour.toggleActivity();
	#endregion activity


	#region tag setting

	public static new AutoBehaviour<SingletonBehaviourT> setTagTo(object tag_TagProvider, bool boolean = true)
		=> autoBehaviour.setTagTo(tag_TagProvider, boolean);
	#endregion tag setting


	#region layer identification

	public static new string layerName => autoBehaviour.layerName;

	public static new int layerIndex => autoBehaviour.layerIndex;

	public static new bool layerIsDefault => autoBehaviour.layerIsDefault;

	public static new bool layerIsNotDefault => autoBehaviour.layerIsNotDefault;
	#endregion layer identification


	#region layer matching

	public static new bool layerMatches(object layerIndex_ProvidedLayerIndex)
		=> autoBehaviour.layerMatches(layerIndex_ProvidedLayerIndex);
	#endregion layer matching


	#region layer determination

	public static new bool isPlayerLayer => autoBehaviour.isPlayerLayer;
	public static new bool isNotPlayerLayer => autoBehaviour.isNotPlayerLayer;
	
	#if UNITOLOGY
	public static new bool isPlayerNeutralLayer => autoBehaviour.isPlayerNeutralLayer;

	public static new bool isPlayerEnemyLayer => autoBehaviour.isPlayerEnemyLayer;

	public static new bool isPlayerAllyLayer => autoBehaviour.isPlayerAllyLayer;
	
	public static new bool isPlayerAllegianceLayer => autoBehaviour.isPlayerAllegianceLayer;
	#endif
	#endregion layer determination


	#region layer setting

	public static new AutoBehaviour<SingletonBehaviourT> setLayerTo(object layerIndex_LayerIndexProvider, bool boolean = true)
		=> autoBehaviour.setLayerTo(layerIndex_LayerIndexProvider, boolean);

	public static new AutoBehaviour<SingletonBehaviourT> setLayerAndMatchingDescendantLayersTo
	(
		object layerIndex_LayerIndexProvider,
		bool boolean = true
	)
		=>	autoBehaviour.setLayerAndMatchingDescendantLayersTo(layerIndex_LayerIndexProvider,
				boolean);
	#endregion layer setting


	#region labels setting
	
	public static new AutoBehaviour<SingletonBehaviourT> setLabelsTo(object otherGameObject_GameObjectProvider, bool boolean = true)
		=> autoBehaviour.setLabelsTo(otherGameObject_GameObjectProvider, boolean);
	#endregion labels setting


	#region calling local methods

	public static new AutoBehaviour<SingletonBehaviourT> executeAllLocal(string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true)
		=> autoBehaviour.executeAllLocal(methodName, sendMessageOptions, boolean);

	public static new AutoBehaviour<SingletonBehaviourT> validate_IfInEditor()
		=> autoBehaviour.validate_IfInEditor();
	#endregion calling local methods


	#region validation pending
	#if UNITY_EDITOR

	public static new AutoBehaviour<SingletonBehaviourT> unpendValidation_IfInEditor()
		=> autoBehaviour.unpendValidation_IfInEditor();

	public static new AutoBehaviour<SingletonBehaviourT> pendValidation_IfInEditor()
		=> autoBehaviour.pendValidation_IfInEditor();
	#endif
	#endregion validation pending


	#region scene determination

	public static new Scene scene => autoBehaviour.scene;
	#endregion scene determination
}