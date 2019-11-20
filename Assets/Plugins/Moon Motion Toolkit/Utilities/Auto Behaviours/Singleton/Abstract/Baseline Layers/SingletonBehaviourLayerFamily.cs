using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Family:
// #auto #family
// • provides this singleton behaviour with static access to its auto behaviour's family layer
public abstract class	SingletonBehaviourLayerFamily<SingletonBehaviourT> :
					SingletonBehaviourLayerComponent<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region sibling indexing

	public static new int siblingIndex => autoBehaviour.siblingIndex;
	#endregion sibling indexing


	#region accessing siblings

	public static new IEnumerable<Transform> accessSiblingAndSelfTransforms => autoBehaviour.accessSiblingAndSelfTransforms;
	public static new Transform[] siblingAndSelfTransforms => autoBehaviour.siblingAndSelfTransforms;

	public static new IEnumerable<GameObject> accessSiblingAndSelfObjects => autoBehaviour.accessSiblingAndSelfObjects;
	public static new GameObject[] siblingAndSelfObjects => autoBehaviour.siblingAndSelfObjects;

	public static new IEnumerable<Transform> accessSiblingTransforms => autoBehaviour.accessSiblingTransforms;
	public static new IEnumerable<Transform> siblingTransforms => autoBehaviour.siblingTransforms;

	public static new IEnumerable<GameObject> accessSiblingObjects => autoBehaviour.accessSiblingObjects;
	public static new IEnumerable<GameObject> siblingObjects => autoBehaviour.siblingObjects;
	#endregion siblings


	#region determining parents
	
	public static new bool hasAnyParent => autoBehaviour.hasAnyParent;
	public static new bool isParentless => autoBehaviour.isParentless;
	public static new bool parentIs(object potentialParentTransform_TransformProvider)
		=> autoBehaviour.parentIs(potentialParentTransform_TransformProvider);
	public static new bool parentIs<OtherSingletonBehaviourT>()
		where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.parentIs<OtherSingletonBehaviourT>();
	public static new bool parentIsNot(object potentialParentTransform_TransformProvider)
		=> autoBehaviour.parentIsNot(potentialParentTransform_TransformProvider);
	public static new bool parentIsNot<OtherSingletonBehaviourT>()
		where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.parentIsNot<OtherSingletonBehaviourT>();
	#endregion determining parents


	#region accessing parents

	public static new Transform parent => autoBehaviour.parent;
	public static new GameObject parentObject => autoBehaviour.parentObject;
	
	public static new ComponentT firstParent<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstParent<ComponentT>(includeInactiveComponents);
	
	public static new List<ComponentT> parental<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.parental<ComponentT>(includeInactiveComponents);
	#endregion accessing parents


	#region setting parents

	public static new Transform setParentTo(object parentTransform_TransformProvider, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing)
		=> autoBehaviour.setParentTo(parentTransform_TransformProvider, boolean, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor);
	public static new Transform setParentTo<ParentSingletonBehaviourT>(bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> autoBehaviour.setParentTo<ParentSingletonBehaviourT>(boolean, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor);
	public static new Transform unparent(bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing)
		=> autoBehaviour.unparent(boolean, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor);
	#endregion setting parents


	#region pibling indexing

	public static new int piblingIndex => autoBehaviour.piblingIndex;
	#endregion pibling indexing


	#region accessing piblings

	public static new Transform piblingTransform(int piblingIndex)
		=> autoBehaviour.piblingTransform(piblingIndex);

	public static new Transform correspondingPiblingTransform => autoBehaviour.correspondingPiblingTransform;

	public static new GameObject piblingObject(int piblingIndex)
		=> autoBehaviour.piblingObject(piblingIndex);

	public static new Transform firstPiblingTransform => autoBehaviour.firstPiblingTransform;

	public static new GameObject firstPiblingObject => autoBehaviour.firstPiblingObject;

	public static new Transform lastPiblingTransform => autoBehaviour.lastPiblingTransform;

	public static new GameObject lastPiblingObject => autoBehaviour.lastPiblingObject;

	public static new IEnumerable<Transform> accessPiblingTransforms => autoBehaviour.accessPiblingTransforms;
	public static new Transform[] piblingTransforms => autoBehaviour.piblingTransforms;

	public static new IEnumerable<GameObject> accessPiblingObjects => autoBehaviour.accessPiblingObjects;
	public static new GameObject[] piblingObjects => autoBehaviour.piblingObjects;
	#endregion accessing piblings


	#region determining ancestrals

	public static new bool hasAnyAncestral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.hasAnyAncestral<ComponentT>(includeInactiveComponents);
	#endregion determining ancestrals


	#region accessing ancestrals
	
	public static new ComponentT firstAncestor<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstAncestor<ComponentT>(includeInactiveComponents);
	
	public static new ComponentT[] ancestral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.ancestral<ComponentT>(includeInactiveComponents);
	#endregion accessing ancestrals


	#region determining corality
	
	public static new bool hasAnyCoral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		where ComponentT : Component
		=> autoBehaviour.hasAnyCoral<ComponentT>(includeInactiveComponents);
	public static new bool hasAnyCoral_ViaReflection(Type type, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.hasAnyCoral_ViaReflection(type, includeInactiveComponents);
	public static new bool hasNoCoral_ViaReflection(Type type, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> autoBehaviour.hasNoCoral_ViaReflection(type, includeInactiveComponents);
	#endregion determining corality


	#region accessing corals
	
	public static new ComponentT firstCoral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstCoral<ComponentT>(includeInactiveComponents);
	
	public static new Component corresponding_ViaReflection(Type type)
		=> autoBehaviour.corresponding_ViaReflection(type);
	
	public static new ComponentT[] coral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.coral<ComponentT>(includeInactiveComponents);
	
	public static new GameObject firstCoralObjectWith<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstCoralObjectWith<ComponentT>(includeInactiveComponents);
	
	public static new Transform firstCoralTransformWith<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstCoralTransformWith<ComponentT>(includeInactiveComponents);
	#endregion accessing corals


	#region counting children

	public static new bool isChildless => autoBehaviour.isChildless;

	public static new bool anyChildren()
		=> autoBehaviour.anyChildren();

	public static new bool pluralChildren => autoBehaviour.pluralChildren;
	#endregion counting children


	#region accessing children

	public static new Transform childTransform(int childIndex)
		=> autoBehaviour.childTransform(childIndex);

	public static new GameObject childObject(int childIndex)
		=> autoBehaviour.childObject(childIndex);

	public static new Transform firstChildTransform => autoBehaviour.firstChildTransform;

	public static new GameObject firstChildObject => autoBehaviour.firstChildObject;

	public static new Transform lastChildTransform => autoBehaviour.lastChildTransform;

	public static new GameObject lastChildObject => autoBehaviour.lastChildObject;

	public static new IEnumerable<Transform> accessChildTransforms => autoBehaviour.accessChildTransforms();
	public static new Transform[] childTransforms => autoBehaviour.childTransforms;

	public static new IEnumerable<GameObject> accessChildObjects => autoBehaviour.accessChildObjects();
	public static new GameObject[] childObjects => autoBehaviour.childObjects;
	#endregion accessing children


	#region child iteration
	public static new AutoBehaviour<SingletonBehaviourT> forEachChildTransform(Action<Transform> action)
		=> autoBehaviour.forEachChildTransform(action);
	public static new AutoBehaviour<SingletonBehaviourT> setActivityOfChildrenTo(bool boolean)
		=> autoBehaviour.setActivityOfChildrenTo(boolean);
	public static new AutoBehaviour<SingletonBehaviourT> activateChildren()
		=> autoBehaviour.activateChildren();
	public static new AutoBehaviour<SingletonBehaviourT> deactivateChildren()
		=> autoBehaviour.deactivateChildren();
	#endregion child iteration


	#region destroying children

	public static new AutoBehaviour<SingletonBehaviourT> destroyChild(int childIndex)
		=> autoBehaviour.destroyChild(childIndex);
	
	public static new AutoBehaviour<SingletonBehaviourT> destroyChildIfItExists(int childIndex)
		=> autoBehaviour.destroyChildIfItExists(childIndex);

	public static new AutoBehaviour<SingletonBehaviourT> destroyFirstChild()
		=> autoBehaviour.destroyFirstChild();

	public static new AutoBehaviour<SingletonBehaviourT> destroyFirstChildIfItExists()
		=> autoBehaviour.destroyFirstChildIfItExists();

	public static new AutoBehaviour<SingletonBehaviourT> destroyLastChild()
		=> autoBehaviour.destroyLastChild();

	public static new AutoBehaviour<SingletonBehaviourT> destroyLastChildIfItExists()
		=> autoBehaviour.destroyLastChildIfItExists();

	public static new AutoBehaviour<SingletonBehaviourT> destroyChildren()
		=> autoBehaviour.destroyChildren();
	#endregion destroying children
	
	
	#region determining descendants
	
	public static new bool hasAnyDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.hasAnyDescendant<ComponentT>(includeInactiveComponents);
	#endregion determining descendants


	#region accessing descendants
	
	public static new List<Transform> descendantTransforms => autoBehaviour.descendantTransforms;
	
	public static new List<GameObject> descendantObjects => autoBehaviour.descendantObjects;
	
	public static new ComponentT firstDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstDescendant<ComponentT>(includeInactiveComponents);
	
	public static new ComponentT lastDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.lastDescendant<ComponentT>(includeInactiveComponents);
	
	public static new IEnumerable<ComponentT> descendants<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.descendants<ComponentT>(includeInactiveComponents);
	#endregion accessing descendants


	#region destroying descendants

	public static new AutoBehaviour<SingletonBehaviourT> destroyLastDescendantObjectWithComponentIfItExists<ComponentT>() where ComponentT : Component
		=> autoBehaviour.destroyLastDescendantObjectWithComponentIfItExists<ComponentT>();
	#endregion destroying descendants


	#region determining lodality

	public static new bool isLodalTo(Transform otherTransform)
		=> autoBehaviour.isLodalTo(otherTransform);

	public static new bool isLodalTo(GameObject otherGameObject)
		=> autoBehaviour.isLodalTo(otherGameObject);

	public static new bool isLodalTo(Component otherComponent)
		=> autoBehaviour.isLodalTo(otherComponent);

	public static new bool isLodalTo<OtherSingletonBehaviourT>() where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.isLodalTo<OtherSingletonBehaviourT>();
	
	public static new bool hasAnyLodal<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		where ComponentT : Component
		=> autoBehaviour.hasAnyLodal<ComponentT>(includeInactiveComponents);
	public static new bool hasAnyLodalSolid<ColliderT>(bool includeInactiveColliders = Default.inclusionOfInactiveComponents)
		where ColliderT : Collider
		=> autoBehaviour.hasAnyLodalSolid<ColliderT>(includeInactiveColliders);
	public static new bool hasNoLodal<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		where ComponentT : Component
		=> autoBehaviour.hasNoLodal<ComponentT>(includeInactiveComponents);
	public static new bool hasAnyLodal<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.hasAnyLodal(function, includeInactiveComponents);
	public static new bool hasNoLodal<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.hasNoLodal(function, includeInactiveComponents);
	#endregion determining lodality


	#region accessing lodals
	
	public static new ComponentT firstLodal<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstLodal<ComponentT>(includeInactiveComponents);
	public static new ComponentT firstLodalWhere<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.firstLodalWhere(function, includeInactiveComponents);
	public static new ColliderT firstLodalSolid<ColliderT>(bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> autoBehaviour.firstLodalSolid<ColliderT>(includeInactiveColliders);
	
	public static new ComponentT[] lodal<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> autoBehaviour.lodal<ComponentT>(includeInactiveComponents);
	
	public static new ComponentI[] lodalI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> autoBehaviour.lodalI<ComponentI>(includeInactiveComponents);

	public static new HashSet<GameObject> lodalObjectsWithI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> autoBehaviour.lodalObjectsWithI<ComponentI>(includeInactiveComponents);
	#endregion accessing lodals
}