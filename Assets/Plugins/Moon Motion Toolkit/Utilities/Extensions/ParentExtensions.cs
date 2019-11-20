using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent Extensions:
// • provides extension methods for handling parents
// #parent #family #transform #component
public static class ParentExtensions
{
	#region determining parents

	// method: return whether this given transform has any parent //
	public static bool hasAnyParent(this Transform transform)
		=> transform.parent.isYull();
	// method: return whether this given game object has no parent //
	public static bool hasAnyParent(this GameObject gameObject)
		=> gameObject.transform.hasAnyParent();
	// method: return whether this given component has no parent //
	public static bool hasAnyParent(this Component component)
		=> component.transform.hasAnyParent();

	// method: return whether this given transform has no parent //
	public static bool isParentless(this Transform transform)
		=> !transform.hasAnyParent();
	// method: return whether this given game object has no parent //
	public static bool isParentless(this GameObject gameObject)
		=> gameObject.transform.isParentless();
	// method: return whether this given component has no parent //
	public static bool isParentless(this Component component)
		=> component.transform.isParentless();

	// methods: return whether this given provided\specified (respectively) transform's parent is the given provided transform //
	public static bool parentIs(this Transform transform, object potentialParentTransform_TransformProvider)
		=> transform.parent == potentialParentTransform_TransformProvider.provideTransform();
	public static bool parentIs(this GameObject gameObject, object potentialParentTransform_TransformProvider)
		=> gameObject.transform.parentIs(potentialParentTransform_TransformProvider);
	public static bool parentIs(this Component component, object potentialParentTransform_TransformProvider)
		=> component.transform.parentIs(potentialParentTransform_TransformProvider);
	public static bool parentIs<SingletonBehaviourT>(this Transform transform)
		where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> transform.parentIs(SingletonBehaviour<SingletonBehaviourT>.transform);
	public static bool parentIs<SingletonBehaviourT>(this GameObject gameObject)
		where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> gameObject.parentIs(SingletonBehaviour<SingletonBehaviourT>.transform);
	public static bool parentIs<SingletonBehaviourT>(this Component component)
		where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> component.parentIs(SingletonBehaviour<SingletonBehaviourT>.transform);

	// methods: return whether this given provided\specified (respectively) transform's parent is not the given provided transform //
	public static bool parentIsNot(this Transform transform, object potentialParentTransform_TransformProvider)
		=> !transform.parentIs(potentialParentTransform_TransformProvider);
	public static bool parentIsNot(this GameObject gameObject, object potentialParentTransform_TransformProvider)
		=> !gameObject.parentIs(potentialParentTransform_TransformProvider);
	public static bool parentIsNot(this Component component, object potentialParentTransform_TransformProvider)
		=> !component.parentIs(potentialParentTransform_TransformProvider);
	public static bool parentIsNot<SingletonBehaviourT>(this Transform transform)
		where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> !transform.parentIs<SingletonBehaviourT>();
	public static bool parentIsNot<SingletonBehaviourT>(this GameObject gameObject)
		where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> !gameObject.parentIs<SingletonBehaviourT>();
	public static bool parentIsNot<SingletonBehaviourT>(this Component component)
		where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> !component.parentIs<SingletonBehaviourT>();
	#endregion determining parents


	#region accessing parents

	// method: return this given game object's parent //
	public static Transform parent(this GameObject gameObject)
		=> gameObject.transform.parent;
	// method: return the parent of the transform of this given component //
	public static Transform parent<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.parent;

	// method: return the parent object of this given transform //
	public static GameObject parentObject(this Transform transform)
		=> transform.parent.gameObject;
	// method: return this given game object's parent object //
	public static GameObject parentObject(this GameObject gameObject)
		=> gameObject.parent().gameObject;
	// method: return the parent object of the transform of this given component //
	public static GameObject parentObject<ComponentT>(this ComponentT component) where ComponentT : Component
		=> component.transform.parentObject();

	// method: return this given game object's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstParent<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.parent().first<ComponentT>(includeInactiveComponents);

	// method: return this given transform's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstParent<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.firstParent<ComponentT>(includeInactiveComponents);

	// method: return this given component's parent's first component of the specified class (null if none found), optionally including inactive components according to the given boolean //
	public static ComponentT firstParent<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.firstParent<ComponentT>(includeInactiveComponents);

	// method: return a list of this given game object's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> parental<ComponentT>(this GameObject gameObject, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> gameObject.parent().pick<ComponentT>(includeInactiveComponents);

	// method: return a list of this given transform's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> parental<ComponentT>(this Transform transform, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> transform.gameObject.parental<ComponentT>(includeInactiveComponents);

	// method: return a list of this given component's parent's components of the specified class, optionally including inactive components according to the given boolean //
	public static List<ComponentT> parental<ComponentT>(this Component component, bool includeInactiveComponents = Default.inclusionOfInactiveComponents) where ComponentT : Component
		=> component.gameObject.parental<ComponentT>(includeInactiveComponents);
	#endregion accessing parents


	#region setting parents

	// methods: (according to the given boolean:) set this given provided transform's parent to the given provided parent transform or specified singleton behaviour (respectively), then return this given provided transform (unless this given transform provider is a component and the parent is specified as a singleton behaviour) //
	public static ObjectT setParentTo<ObjectT>(this ObjectT transform_TransformProvider, object parentTransform_TransformProvider, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing)
	{
		if (boolean)
		{
			Transform transform = transform_TransformProvider.provideTransform();
			if (transform.isYull())
			{
				Transform parentTransform = parentTransform_TransformProvider.provideTransform();
				List<string> callstackMethodNames_for_setParentTo = Callstack.methodNames;
				#if UNITY_EDITOR
				if (Callstack.includesOnValidate)
				{
					Execute.atNextCheck_IfInEditor
					(
						()=>
						{
							try
							{
								if (parentTransform.isYull())
								{
									transform.SetParent(parentTransform);
								}
								else
								{
									transform.SetParent(null);
								}
							}
							catch (NullReferenceException nullReferenceException)
							{
								if (!silenceNullTransformErrorForDelayInEditor)
								{
									nullReferenceException.logAsError
									(
										"the this transform given to ParentExtensions.setParentTo has become null by now (when the action given by ParentExtensions.setParentTo to Execute.atNextCheck_IfInEditor is being executed); here is the listing of method names that were in the callstack upon calling ParentExtensions.setParentTo:".thenNewline()
										+callstackMethodNames_for_setParentTo.asListing()
									);
								}
							}
						},
						executeIfPlaymodeHasChanged,
						silenceNullTransformErrorForDelayInEditor
					);
				}
				else
				{
				#endif
					if (parentTransform.isYull())
					{
						transform.SetParent(parentTransform);
					}
					else
					{
						transform.SetParent(null);
					}
				#if UNITY_EDITOR
				}
				#endif
			}
			else
			{
				"ParentExtensions.setParentTo given null this transform".printAsErrorAndReturnDefault<ObjectT>();
			}
		}

		return transform_TransformProvider;
	}
	public static GameObject setParentTo<ParentSingletonBehaviourT>(this GameObject gameObject, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> gameObject.transform.setParentTo<ParentSingletonBehaviourT>(boolean, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor).gameObject;
	public static Transform setParentTo<ParentSingletonBehaviourT>(this Transform transform, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=> transform.setParentTo(SingletonBehaviour<ParentSingletonBehaviourT>.transform, boolean, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor);
	public static void setParentTo<ParentSingletonBehaviourT>(this Component component, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing) where ParentSingletonBehaviourT : SingletonBehaviour<ParentSingletonBehaviourT>
		=>	component.after(()=>
				component.transform.setParentTo<ParentSingletonBehaviourT>(true, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor),
				boolean);

	// method: (according to the given boolean:) set the parent of each of these given game objects to the given provided parent transform, then return the list of these given game objects //
	public static List<GameObject> forEachSetParentTo(this IEnumerable<GameObject> gameObjects, object parentTransform_TransformProvider, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing)
		=>	gameObjects.forEachManifested(gameObject =>
				gameObject.setParentTo(parentTransform_TransformProvider, true, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor),
				boolean);

	// method: (according to the given boolean:) unparent this given transform (set its parent to null), then return this given transform //
	public static Transform unparent(this Transform transform, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing)
		=>	transform.setParentTo
			(
				(Transform) null,
				boolean,
				executeIfPlaymodeHasChanged,
				silenceNullTransformErrorForDelayInEditor
			);
	// method: (according to the given boolean:) unparent this given game object (set its parent to null), then return this given game object //
	public static GameObject unparent(this GameObject gameObject, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing)
		=>	gameObject.transform.unparent
			(
				boolean,
				executeIfPlaymodeHasChanged,
				silenceNullTransformErrorForDelayInEditor
			).gameObject;
	// method: (according to the given boolean:) unparent the transform of this given component (set its parent to null), then return this given component //
	public static ComponentT unparent<ComponentT>(this ComponentT component, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing) where ComponentT : Component
		=> component.after(()=>
			component.transform.unparent(boolean, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor));

	// method: (according to the given boolean:) unparent each of these given game objects, then return the list of these given game objects //
	public static List<GameObject> unparentEach(this IEnumerable<GameObject> gameObjects, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing)
		=>	gameObjects.forEachManifested(gameObject =>
				gameObject.unparent(true, executeIfPlaymodeHasChanged, silenceNullTransformErrorForDelayInEditor),
				boolean);
	#endregion setting parents
	

	#region acting based upon parent

	// method: (according to the given boolean:) temporarily change this given transform's parent to the given other transform, during so invoking the given action on this given transform, then return this given transform //
	public static Transform actUponWithParentTemporarilySwappedTo(this Transform transform, Transform otherTransform, Action<Transform> action, bool boolean = true, bool executeIfPlaymodeHasChanged = Default.editorExecutionIfPlaymodeHasChanged, bool silenceNullTransformErrorForDelayInEditor = Default.errorSilencing)
	{
		if (boolean)
		{
			if (otherTransform.isYull())
			{
				Transform extervalParent = transform.parent;
				#if UNITY_EDITOR
				if (Callstack.includesOnValidate)
				{
					Execute.atNextCheck_IfInEditor
					(
						()=> action.asFunction()(transform.setParentTo(otherTransform)).setParentTo(extervalParent),
						executeIfPlaymodeHasChanged,
						silenceNullTransformErrorForDelayInEditor
					);
					return transform;
				}
				else
				{
				#endif
					return action.asFunction()(transform.setParentTo(otherTransform)).setParentTo(extervalParent);
				#if UNITY_EDITOR
				}
				#endif
			}
			else
			{
				return transform.returnWithError();
			}
		}

		return transform;
	}
	#endregion acting based upon parent
}