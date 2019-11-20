using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Family:
// #auto #family
// • provides this behaviour with direct access to its family extension methods
public abstract class	AutoBehaviourLayerFamily<AutoBehaviourT> :
					AutoBehaviourLayerComponent<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region sibling indexing

	public int siblingIndex => transform.siblingIndex();
	#endregion sibling indexing


	#region accessing siblings

	public IEnumerable<Transform> accessSiblingAndSelfTransforms => transform.accessSiblingAndSelfTransforms();
	public Transform[] siblingAndSelfTransforms => transform.siblingAndSelfTransforms();

	public IEnumerable<GameObject> accessSiblingAndSelfObjects => transform.accessSiblingAndSelfObjects();
	public GameObject[] siblingAndSelfObjects => transform.siblingAndSelfObjects();

	public IEnumerable<Transform> accessSiblingTransforms => transform.accessSiblingTransforms();
	public IEnumerable<Transform> siblingTransforms => transform.siblingTransforms();

	public IEnumerable<GameObject> accessSiblingObjects => transform.accessSiblingObjects();
	public IEnumerable<GameObject> siblingObjects => transform.siblingObjects();
	#endregion siblings


	#region determining parents
	
	public bool hasAnyParent => transform.hasAnyParent();
	public bool isParentless => transform.isParentless();
	public bool parentIs(object potentialParentTransform_TransformProvider)
		=> transform.parentIs(potentialParentTransform_TransformProvider);
	public bool parentIs<SingletonBehaviourT>()
		where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> transform.parentIs<SingletonBehaviourT>();
	public bool parentIsNot(object potentialParentTransform_TransformProvider)
		=> transform.parentIsNot(potentialParentTransform_TransformProvider);
	public bool parentIsNot<SingletonBehaviourT>()
		where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> transform.parentIsNot<SingletonBehaviourT>();
	#endregion determining parents


	#region accessing parents

	public Transform parent => transform.parent;
	public GameObject parentObject => transform.parentObject();
	
	public ComponentT firstParent<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstParent<ComponentT>(includeInactiveComponents);
	
	public List<ComponentT> parental<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.parental<ComponentT>(includeInactiveComponents);
	#endregion accessing parents


	#region setting parents

	public Transform setParentTo(object parentTransform_TransformProvider, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing)
		=> transform.setParentTo(parentTransform_TransformProvider, boolean, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor);
	public Transform setParentTo<ParentSingletonBehaviourT>(bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> transform.setParentTo<ParentSingletonBehaviourT>(boolean, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor);
	public Transform unparent(bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing)
		=> transform.unparent(boolean, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor);
	#endregion setting parents


	#region pibling indexing
	
	public int piblingIndex => transform.piblingIndex();
	#endregion pibling indexing


	#region accessing piblings

	public Transform piblingTransform(int piblingIndex)
		=> transform.piblingTransform(piblingIndex);

	public Transform correspondingPiblingTransform => transform.correspondingPiblingTransform();

	public GameObject piblingObject(int piblingIndex)
		=> transform.piblingObject(piblingIndex);

	public Transform firstPiblingTransform => transform.firstPiblingTransform();

	public GameObject firstPiblingObject => transform.firstPiblingObject();

	public Transform lastPiblingTransform => transform.lastPiblingTransform();

	public GameObject lastPiblingObject => transform.lastPiblingObject();

	public IEnumerable<Transform> accessPiblingTransforms => transform.accessPiblingTransforms();
	public Transform[] piblingTransforms => transform.piblingTransforms();

	public IEnumerable<GameObject> accessPiblingObjects => transform.accessPiblingObjects();
	public GameObject[] piblingObjects => transform.piblingObjects();
	
	public IEnumerable<AutoBehaviourT> accessEachFirstPibling => self.accessEachFirstPibling();
	
	public List<AutoBehaviourT> eachFirstPibling => self.eachFirstPibling();
	#endregion accessing piblings


	#region determining ancestrals
	
	public bool hasAnyAncestral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAnyAncestral<ComponentT>(includeInactiveComponents);
	#endregion determining ancestrals


	#region accessing ancestrals
	
	public ComponentT firstAncestor<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstAncestor<ComponentT>(includeInactiveComponents);
	
	public ComponentT[] ancestral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.ancestral<ComponentT>(includeInactiveComponents);
	#endregion accessing ancestrals


	#region determining corality

	public bool hasAnyCoral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		where ComponentT : Component
		=> gameObject.hasAnyCoral<ComponentT>(includeInactiveComponents);
	public bool hasAnyCoral_ViaReflection(Type type, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.hasAnyCoral_ViaReflection(type, includeInactiveComponents);
	public bool hasNoCoral_ViaReflection(Type type, bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		=> gameObject.hasNoCoral_ViaReflection(type, includeInactiveComponents);
	#endregion determining corality


	#region accessing corals
	
	public ComponentT firstCoral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstCoral<ComponentT>(includeInactiveComponents);
	
	public Component corresponding_ViaReflection(Type type)
		=> gameObject.corresponding_ViaReflection(type);
	
	public ComponentT[] coral<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.coral<ComponentT>(includeInactiveComponents);
	
	public GameObject firstCoralObjectWith<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstCoralObjectWith<ComponentT>(includeInactiveComponents);
	
	public Transform firstCoralTransformWith<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstCoralTransformWith<ComponentT>(includeInactiveComponents);
	#endregion accessing corals


	#region counting children

	public bool isChildless => component.isChildless();

	public bool anyChildren()
		=> component.hasAnyChildren();

	public bool pluralChildren => component.pluralChildren();
	#endregion counting children


	#region accessing children

	public Transform childTransform(int childIndex)
		=> transform.childTransform(childIndex);

	public GameObject childObject(int childIndex)
		=> transform.childObject(childIndex);

	public Transform firstChildTransform => transform.firstChildTransform();

	public GameObject firstChildObject => transform.firstChildObject();

	public Transform lastChildTransform => transform.lastChildTransform();

	public GameObject lastChildObject => transform.lastChildObject();

	public IEnumerable<Transform> accessChildTransforms => transform.accessChildTransforms();
	public Transform[] childTransforms => transform.childTransforms();

	public IEnumerable<GameObject> accessChildObjects => transform.accessChildObjects();
	public GameObject[] childObjects => transform.childObjects();
	#endregion accessing children


	#region child iteration
	public AutoBehaviourT forEachChildTransform(Action<Transform> action)
		=> selfAfter(()=> transform.forEachChildTransform(action));
	public AutoBehaviourT setActivityOfChildrenTo(bool boolean)
		=> selfAfter(()=> transform.setActivityOfChildrenTo(boolean));
	public AutoBehaviourT activateChildren()
		=> selfAfter(()=> transform.activateChildren());
	public AutoBehaviourT deactivateChildren()
		=> selfAfter(()=> transform.deactivateChildren());
	#endregion child iteration


	#region destroying children

	public AutoBehaviourT destroyChild(int childIndex)
		=> selfAfter(()=> transform.destroyChild(childIndex));
	
	public AutoBehaviourT destroyChildIfItExists(int childIndex)
		=> selfAfter(()=> transform.destroyChildIfItExists(childIndex));
	
	public AutoBehaviourT destroyFirstChild()
		=> selfAfter(()=> transform.destroyFirstChild());
	
	public AutoBehaviourT destroyFirstChildIfItExists()
		=> selfAfter(()=> transform.destroyFirstChildIfItExists());
	
	public AutoBehaviourT destroyLastChild()
		=> selfAfter(()=> transform.destroyLastChild());
	
	public AutoBehaviourT destroyLastChildIfItExists()
		=> selfAfter(()=> transform.destroyLastChildIfItExists());

	public AutoBehaviourT destroyChildren()
		=> selfAfter(()=> transform.destroyChildren());
	#endregion destroying children


	#region determining descendants
	
	public bool hasAnyDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAnyDescendant<ComponentT>(includeInactiveComponents);
	#endregion determining descendants


	#region accessing descendants
	
	public List<Transform> descendantTransforms => gameObject.descendantTransforms();
	
	public List<GameObject> descendantObjects => gameObject.descendantObjects();
	
	public ComponentT firstDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstDescendant<ComponentT>(includeInactiveComponents);
	
	public ComponentT lastDescendant<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.lastDescendant<ComponentT>(includeInactiveComponents);
	
	public List<ComponentT> descendants<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.descendants<ComponentT>(includeInactiveComponents);
	#endregion accessing descendants


	#region destroying descendants

	public AutoBehaviourT destroyLastDescendantObjectWithComponentIfItExists<ComponentT>() where ComponentT : Component
		=> selfAfter(()=> gameObject.destroyLastDescendantObjectWithComponentIfItExists<ComponentT>());
	#endregion destroying descendants


	#region determining lodality

	public bool isLodalTo(Transform otherTransform)
		=> transform.isLodalTo(otherTransform);
	
	public bool isLodalTo(GameObject otherGameObject)
		=> transform.isLodalTo(otherGameObject);
	
	public bool isLodalTo(Component otherComponent)
		=> transform.isLodalTo(otherComponent);
	
	public bool isLodalTo<SingletonBehaviourT>() where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> transform.isLodalTo<SingletonBehaviourT>();
	
	public bool hasAnyLodal<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		where ComponentT : Component
		=> gameObject.hasAnyLodal<ComponentT>(includeInactiveComponents);
	public bool hasNoLodal<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents)
		where ComponentT : Component
		=> gameObject.hasNoLodal<ComponentT>(includeInactiveComponents);
	public bool hasAnyLodalSolid<ColliderT>(bool includeInactiveColliders = Default.inclusionOfInactiveComponents)
		where ColliderT : Collider
		=> gameObject.hasAnyLodalSolid<ColliderT>(includeInactiveColliders);
	public bool hasAnyLodal<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasAnyLodal(function, includeInactiveComponents);
	public bool hasNoLodal<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.hasNoLodal(function, includeInactiveComponents);
	#endregion determining lodality


	#region accessing lodals
	
	public ComponentT firstLodal<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstLodal<ComponentT>(includeInactiveComponents);
	public ComponentT firstLodalWhere<ComponentT>(Func<ComponentT, bool> function, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.firstLodalWhere(function, includeInactiveComponents);
	public ColliderT firstLodalSolid<ColliderT>(bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> gameObject.firstLodalSolid<ColliderT>(includeInactiveColliders);
	
	public ComponentT[] lodal<ComponentT>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.lodal<ComponentT>(includeInactiveComponents);
	
	public ComponentI[] lodalI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> gameObject.lodalI<ComponentI>(includeInactiveComponents);

	public HashSet<GameObject> lodalObjectsWithI<ComponentI>(bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentI : class
		=> gameObject.lodalObjectsWithI<ComponentI>(includeInactiveComponents);
	#endregion accessing lodals
}