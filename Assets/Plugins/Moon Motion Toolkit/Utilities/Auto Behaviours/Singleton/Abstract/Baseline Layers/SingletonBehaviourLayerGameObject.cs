﻿using System;
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

	public static new bool isPartOfPrefabAsset => autoBehaviour.isPartOfPrefabAsset;
	public static new bool isNotPartOfPrefabAsset => autoBehaviour.isNotPartOfPrefabAsset;
	#endregion determining prefabness


	#region determining whether this game object could be awake right now

	public static new bool couldBeAwakeRightNow => autoBehaviour.couldBeAwakeRightNow;
	public static new bool couldNotBeAwakeRightNow => autoBehaviour.couldNotBeAwakeRightNow;
	#endregion determining whether this game object could be awake right now
	

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

	public static new GameObject createChildObjectForNew_ViaReflection<ComponentT>
	(
		string name = "",
		bool matchRotationToParent = Default.matchingOfRotationToParentForFreshGameObjectCreation,
		bool matchLayersToParent = Default.matchingOfLabelsToParentForFreshGameObjectCreation
	) where ComponentT : Component
		=> autoBehaviour.createChildObjectForNew_ViaReflection<ComponentT>(name, matchRotationToParent, matchLayersToParent);
	
	public static new ComponentT createChildObjectForNewGet_ViaReflection<ComponentT>
	(
		string name = "",
		bool matchRotationToParent = Default.matchingOfRotationToParentForFreshGameObjectCreation,
		bool matchLayersToParent = Default.matchingOfLabelsToParentForFreshGameObjectCreation
	) where ComponentT : Component
		=> autoBehaviour.createChildObjectForNewGet_ViaReflection<ComponentT>(name, matchRotationToParent, matchLayersToParent);
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


	#region making objects universal andor temporary
	
	public static new AutoBehaviour<SingletonBehaviourT> makeUniversal()
		=> autoBehaviour.makeUniversal();
	
	public static new AutoBehaviour<SingletonBehaviourT> makeTemporary()
		=> autoBehaviour.makeTemporary();
	
	public static new AutoBehaviour<SingletonBehaviourT> makeUniversalAndTemporary()
		=> autoBehaviour.makeUniversalAndTemporary();
	#endregion making objects universal andor temporary


	#region determining selection
	#if UNITY_EDITOR

	public static new bool isSelected => autoBehaviour.isSelected;
	public static new bool isNotSelected => autoBehaviour.isNotSelected;
	#endif
	#endregion determining selection


	#region setting selection

	public static new AutoBehaviour<SingletonBehaviourT> select_IfInEditor()
		=> autoBehaviour.select_IfInEditor();
	#endregion setting selection


	#region pinging

	public static new AutoBehaviour<SingletonBehaviourT> ping_IfInEditor()
		=> autoBehaviour.ping_IfInEditor();
	#endregion pinging


	#region setting selection then pinging the selection
	
	public static new AutoBehaviour<SingletonBehaviourT> selectAndPing_IfInEditor()
		=> autoBehaviour.selectAndPing_IfInEditor();
	#endregion setting selection then pinging the selection
	

	#region setting hierarchy expansion
	#if UNITY_EDITOR
	
	public static new AutoBehaviour<SingletonBehaviourT> setHierarchyExpansionTo(bool expansion)
		=> autoBehaviour.setHierarchyExpansionTo(expansion);
	public static new AutoBehaviour<SingletonBehaviourT> expandInHierarchy()
		=> autoBehaviour.expandInHierarchy();
	public static new AutoBehaviour<SingletonBehaviourT> collapseInHierarchy()
		=> autoBehaviour.collapseInHierarchy();
	
	public static new AutoBehaviour<SingletonBehaviourT> setHierarchyExpansionForSelfAndChildrenTo(bool expansion)
		=> autoBehaviour.setHierarchyExpansionForSelfAndChildrenTo(expansion);
	public static new AutoBehaviour<SingletonBehaviourT> expandSelfAndChildrenInHierarchy()
		=> autoBehaviour.expandSelfAndChildrenInHierarchy();
	public static new AutoBehaviour<SingletonBehaviourT> collapseSelfAndChildrenInHierarchy()
		=> autoBehaviour.collapseSelfAndChildrenInHierarchy();

	public static new void setHierarchyExpansionForLodalsTo(bool expansion)
		=> autoBehaviour.setHierarchyExpansionForLodalsTo(expansion);
	public static new void expandLodalsInHierarchy()
		=> autoBehaviour.expandLodalsInHierarchy();
	public static new void collapseLodalsInHierarchy()
		=> autoBehaviour.collapseLodalsInHierarchy();
	#endif
	#endregion setting hierarchy expansion


	#region name

	public static new AutoBehaviour<SingletonBehaviourT> setNameTo(string name, bool boolean = true)
		=> autoBehaviour.setNameTo(name, boolean);
	public static new AutoBehaviour<SingletonBehaviourT> setNameToSimpleClassName_ViaReflection(bool boolean = true)
		=> autoBehaviour.setNameToSimpleClassName_ViaReflection(boolean);
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
	public static new bool isActiveLocally => autoBehaviour.isActiveLocally;
	// method: return whether this behaviour's game object is inactive locally //
	public static new bool isInactiveLocally => autoBehaviour.isInactiveLocally;

	// method: return whether this behaviour's game object is active globally //
	public static new bool isActiveGlobally => autoBehaviour.isActiveGlobally;
	// method: return whether this behaviour's game object is inactive globally //
	public static new bool isInactiveGlobally => autoBehaviour.isInactiveGlobally;

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