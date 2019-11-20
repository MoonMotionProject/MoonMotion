using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game Object Creation Extensions:
// • provides extension methods for creating game objects
// #creation #gameobject
public static class GameObjectCreationExtensions
{
	#region creating fresh game objects

	// method: create a fresh game object with this given name (and no parent), then return the created game object //
	public static GameObject createAsObject(this string name)
		=> new GameObject(name);

	// method: create a fresh game object with this given name, as a child object of the given parent transform, with position and rotation transformations matching the parent, matching the labels to the parent according to the given 'matchLabelsToParent' boolean, then return the created game object //
	public static GameObject createAsChildObjectOf
	(
		this string name,
		object parentTransform_TransformProvider,
		bool matchRotationToParent = Default.matchingOfRotationToParentForFreshGameObjectCreation,
		bool matchLayersToParent = Default.matchingOfLabelsToParentForFreshGameObjectCreation
	)
		=>	new GameObject(name)
				.setParentTo(parentTransform_TransformProvider)
				.resetLocalPosition()
				.resetLocalRotation(matchRotationToParent)
				.setLabelsTo(parentTransform_TransformProvider,
					matchLayersToParent);
	
	public static GameObject createChildObject
	(
		this GameObject parentObject,
		string name = Default.newGameObjectName,
		bool matchRotationToParent = Default.matchingOfRotationToParentForFreshGameObjectCreation,
		bool matchLayersToParent = Default.matchingOfLabelsToParentForFreshGameObjectCreation
	)
		=> name.createAsChildObjectOf(parentObject, matchRotationToParent, matchLayersToParent);
	public static GameObject createChildObject
	(
		this Component parentComponent,
		string name = Default.newGameObjectName,
		bool matchRotationToParent = Default.matchingOfRotationToParentForFreshGameObjectCreation,
		bool matchLayersToParent = Default.matchingOfLabelsToParentForFreshGameObjectCreation
	)
		=> parentComponent.gameObject.createChildObject(name, matchRotationToParent, matchLayersToParent);
	
	public static GameObject createChildObjectForNew_ViaReflection<ComponentT>
	(
		this GameObject parentObject,
		string name = "",
		bool matchRotationToParent = Default.matchingOfRotationToParentForFreshGameObjectCreation,
		bool matchLayersToParent = Default.matchingOfLabelsToParentForFreshGameObjectCreation
	) where ComponentT : Component
		=>	parentObject.createChildObject
			(
				name.ifEmptyThen(typeof(ComponentT).spacedSimpleClassName_ViaReflection()),
				matchRotationToParent,
				matchLayersToParent
			).add<ComponentT>();
	public static GameObject createChildObjectForNew<ComponentT>
	(
		this Component parentComponent,
		string name = "",
		bool matchRotationToParent = Default.matchingOfRotationToParentForFreshGameObjectCreation,
		bool matchLayersToParent = Default.matchingOfLabelsToParentForFreshGameObjectCreation
	) where ComponentT : Component
		=> parentComponent.gameObject.createChildObjectForNew_ViaReflection<ComponentT>(name, matchRotationToParent, matchLayersToParent);
	
	public static ComponentT createChildObjectForNewGet_ViaReflection<ComponentT>
	(
		this GameObject parentObject,
		string name = "",
		bool matchRotationToParent = Default.matchingOfRotationToParentForFreshGameObjectCreation,
		bool matchLayersToParent = Default.matchingOfLabelsToParentForFreshGameObjectCreation
	) where ComponentT : Component
		=>	parentObject.createChildObject
			(
				name.ifEmptyThen(typeof(ComponentT).spacedSimpleClassName_ViaReflection()),
				matchRotationToParent,
				matchLayersToParent
			).addGet<ComponentT>();
	public static ComponentT createChildObjectForNewGet_ViaReflection<ComponentT>
	(
		this Component parentComponent,
		string name = "",
		bool matchRotationToParent = Default.matchingOfRotationToParentForFreshGameObjectCreation,
		bool matchLayersToParent = Default.matchingOfLabelsToParentForFreshGameObjectCreation
	) where ComponentT : Component
		=> parentComponent.gameObject.createChildObjectForNewGet_ViaReflection<ComponentT>(name, matchRotationToParent, matchLayersToParent);
	#endregion creating fresh game objects


	#region creating templated game objects

	// method: create an instance of this given object template (object instance or prefab), with the given name (using the template's name if empty (which is the default)), then return the created game object //
	public static GameObject create(this GameObject template, string name = "")
		=>	UnityEngine.Object.Instantiate(template)
				.setNameTo(name.ifEmptyThen(template.name));

	// methods: create an instance of this given game object template (object instance or prefab), as a child of the given provided parent transform, with position and rotation transformations matching the parent, matching the labels to the parent according to the given 'matchLabelsToParent' boolean, then return the created game object //
	public static GameObject createAsChildObjectOf
	(
		this GameObject template,
		object parentTransform_TransformProvider,
		bool matchRotationToParent = Default.matchingOfRotationToParentForTemplatedGameObjectCreation,
		bool matchLabelsToParent = Default.matchingOfLabelsToParentForTemplatedGameObjectCreation
	)
		=>	template.create()
				.setParentTo(parentTransform_TransformProvider)
				.resetLocalPosition()
				.resetLocalRotation(matchRotationToParent)
				.setLabelsTo(parentTransform_TransformProvider,
					matchLabelsToParent);
	public static GameObject createAsChildObjectOf<SingletonBehaviourT>
	(
		this GameObject template,
		bool matchRotationToParent = Default.matchingOfRotationToParentForTemplatedGameObjectCreation,
		bool matchLabelsToParent = Default.matchingOfLabelsToParentForTemplatedGameObjectCreation
	) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> template.createAsChildObjectOf(SingletonBehaviour<SingletonBehaviourT>.transform, matchRotationToParent, matchLabelsToParent);
	
	public static GameObject createChildObject
	(
		this GameObject parentObject,
		GameObject template,
		string name = "",
		bool matchRotationToParent = Default.matchingOfRotationToParentForTemplatedGameObjectCreation,
		bool matchLabelsToParent = Default.matchingOfLabelsToParentForTemplatedGameObjectCreation
	)
		=> template.createAsChildObjectOf(parentObject, matchRotationToParent, matchLabelsToParent)
			.setNameTo(name.ifEmptyThen(template.name));
	public static GameObject createChildObject
	(
		this Component parentComponent,
		GameObject template,
		string name = "",
		bool matchRotationToParent = Default.matchingOfRotationToParentForTemplatedGameObjectCreation,
		bool matchLabelsToParent = Default.matchingOfLabelsToParentForTemplatedGameObjectCreation
	)
		=> parentComponent.gameObject.createChildObject(template, name, matchRotationToParent, matchLabelsToParent);
	#endregion creating templated game objects


	#region duplicating game objects
	
	// method: create a duplicate of this given game object, as a sibling of this given game object, with the given name (using this given game object's name if empty (which is the default)), then return the created game object //
	public static GameObject createDuplicate(this GameObject gameObject, string name = "")
		=>	UnityEngine.Object.Instantiate(gameObject, gameObject.parent())
				.setNameTo(name.ifEmptyThen(gameObject.name));
	
	public static GameObject createTemporaryDuplicate(this GameObject gameObject, string name = "")
		=> gameObject.createDuplicate(name).makeTemporary();

	public static GameObject createDuplicateMaintainingOnlyComponentsDerivedFrom_ViaReflection<ComponentT>(this GameObject gameObject, string name = "") where ComponentT : Component
		=> gameObject.createDuplicate(name).destroyAllComponentsNotDerivedFrom_ViaReflection<ComponentT>();

	public static GameObject createDuplicateWithout<ComponentT>(this GameObject gameObject, string name = "") where ComponentT : Component
		=> gameObject.createDuplicate(name).destroyEach<ComponentT>();
	#endregion duplicating game objects
}