using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// Game Object Extensions: provides extension methods for handling game objects //
// #auto #gameobject #execution
public static class GameObjectExtensions
{
	#region accessing

	// method: return a selection of the game objects for these given components //
	public static IEnumerable<GameObject> selectObjects(this IList<Component> components)
		=> components.select(component => component.gameObject);
	#endregion accessing


	#region determining prefabness

	public static bool isPartOfPrefabAsset(this GameObject gameObject)
		=> gameObject.scene.rootCount == 0;
	public static bool isNotPartOfPrefabAsset(this GameObject gameObject)
		=> !gameObject.isPartOfPrefabAsset();
	#endregion determining prefabness


	#region determining whether this game object could be awake right now

	public static bool couldBeAwakeRightNow(this GameObject gameObject)
		=> UnityIs.playing && gameObject.isNotPartOfPrefabAsset();
	public static bool couldNotBeAwakeRightNow(this GameObject gameObject)
		=> !gameObject.couldBeAwakeRightNow();
	#endregion determining whether this game object could be awake right now


	#region existence

	// note: refer here for how to handle exceptions related to game object existence: https://stackoverflow.com/a/53195170/3900755 //

	// method: return whether this given game object is destroyed //
	public static bool destroyed(this GameObject gameObject)
		=> gameObject == null;		// based on https://answers.unity.com/questions/13840/how-to-detect-if-a-gameobject-has-been-destroyed.html; checking whether a game object is equal to null (but not when checking that game object cast to 'object') will return true even if its reference is not null but it has been destroyed (note that a game object's reference cannot be set to null unless by Unity destroying the game object)

	// method: return whether this given game object exists //
	public static bool exists(this GameObject gameObject)
		=> gameObject.isYull().and(!gameObject.destroyed());

	// method: in this given dictionary, remove all (game object) keys which are destroyed, then return this given dictionary //
	public static Dictionary<GameObject, ObjectT> clean<ObjectT>(this Dictionary<GameObject, ObjectT> dictionary)
		=> dictionary.removeWhere(gameObjectKey => gameObjectKey.destroyed());
	#endregion existence


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

	public static GameObject createDuplicateWithOnly<ComponentT>(this GameObject gameObject, string name = "") where ComponentT : Component
		=> gameObject.createDuplicate(name).destroyAllComponentsThatAreNot<ComponentT>();

	public static GameObject createDuplicateWithout<ComponentT>(this GameObject gameObject, string name = "") where ComponentT : Component
		=> gameObject.createDuplicate(name).destroyEach<ComponentT>();
	#endregion duplicating game objects


	#region determining hierarchy selection
	#if UNITY_EDITOR

	// method: return whether this given game object is currently selected //
	public static bool isSelected(this GameObject gameObject)
		=> Selection.gameObjects.contains(gameObject);

	// method: return whether this given game object is not currently selected //
	public static bool isNotSelected(this GameObject gameObject)
		=> !gameObject.isSelected();
	#endif
	#endregion determining hierarchy selection


	#region setting hierarchy selection
	#if UNITY_EDITOR

	public static GameObject select(this GameObject gameObject)
		=>	gameObject.after(()=>
				Selection.activeObject = gameObject);
	#endif
	#endregion setting hierarchy selection


	#region setting hierarchy expansion
	#if UNITY_EDITOR
	
	public static GameObject setExpansionTo(this GameObject gameObject, bool expansion)
	{
		if (gameObject.hasAnyChildren())
		{
			GameObject[] childGameObjects = gameObject.childObjects();
				
			childGameObjects.unparentEach();

			GameObject temporaryChild = gameObject.createChildObject();

			gameObject.setExpansionForSelfAndDescendantsTo(expansion);
			
			childGameObjects.forEachSetParentTo(gameObject);

			temporaryChild.destroy();
		}
		return gameObject;
	}
	public static List<GameObject> forEachSetExpansionTo(this IEnumerable<GameObject> gameObjects, bool expansion)
		=> gameObjects.forEachManifested(gameObject => gameObject.setExpansionTo(expansion));
	public static GameObject expand(this GameObject gameObject)
		=> gameObject.setExpansionTo(true);
	public static List<GameObject> expandEach(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.forEachManifested(gameObject => gameObject.expand());
	public static GameObject collapse(this GameObject gameObject)
		=> gameObject.setExpansionTo(false);
	public static List<GameObject> collapseEach(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.forEachManifested(gameObject => gameObject.collapse());

	public static void setExpansionForSelfAndDescendantsTo(this GameObject gameObject, bool expansion)
	{
		if (gameObject.hasAnyChildren())
		{
			TabTo.hierarchy();
			
			typeof(EditorWindow).Assembly.GetType("UnityEditor.SceneHierarchyWindow")
				.GetMethod("SetExpandedRecursive")
					.Invoke(Focused.window, new object[] {gameObject.idee(), expansion});
		}
	}
	public static void expandSelfAndDescendants(this GameObject gameObject)
		=> gameObject.setExpansionForSelfAndDescendantsTo(true);
	public static void collapseSelfAndDescendants(this GameObject gameObject)
		=> gameObject.setExpansionForSelfAndDescendantsTo(false);
	#endif
	#endregion setting hierarchy expansion


	#region printing
	
	public static GameObject asThisObjectLog(this GameObject gameObject, string string_, string loggingSeparator = Default.loggingSeparator)
		=> gameObject.after(()=> string_.logAs(""+gameObject, gameObject, loggingSeparator));
	
	public static List<GameObject> asEachObjectLog(this IEnumerable<GameObject> gameObjects, string string_, string loggingSeparator = Default.loggingSeparator)
		=>	gameObjects.forEachManifested(gameObject =>
				gameObject.asThisObjectLog(string_, loggingSeparator));
	
	public static HashSet<GameObject> setAfterAsEachObjectLogging(this IEnumerable<GameObject> gameObjects, string string_, string loggingSeparator = Default.loggingSeparator)
		=>	gameObjects.uniquesAfterForEach(gameObject =>
				gameObject.asThisObjectLog(string_, loggingSeparator));
	#endregion printing


	#region activity

	// method: return whether this given game object is active locally //
	public static bool activeLocally(this GameObject gameObject)
		=> gameObject.activeSelf;

	// method: return whether this given game object is active globally //
	public static bool activeGlobally(this GameObject gameObject)
		=> gameObject.activeInHierarchy;

	// method: set the activity of this given game object to the given boolean, then return this given game object //
	public static GameObject setActivityTo(this GameObject gameObject, bool activity)
		=> gameObject.after(()=>
			gameObject.SetActive(activity));

	// method: activate this given game object, then return it //
	public static GameObject activate(this GameObject gameObject)
		=> gameObject.setActivityTo(true);

	// method: deactivate this given game object, then return it //
	public static GameObject deactivate(this GameObject gameObject)
		=> gameObject.setActivityTo(false);

	// method: toggle the activity of this given game object using the given toggling, then return this given game object //
	public static GameObject toggleActivityBy(this GameObject gameObject, Toggling toggling)
		=> gameObject.setActivityTo(gameObject.activeLocally().toggledBy(toggling));

	// method: toggle the activity of these given game objects using the given toggling, then return them //
	public static GameObject[] toggleActivityBy(this GameObject[] gameObjects, Toggling toggling)
		=> gameObjects.forEach(gameObject => gameObject.toggleActivityBy(toggling));

	// method: toggle the activity of this given game object, then return this given game object //
	public static GameObject toggleActivity(this GameObject gameObject)
		=> gameObject.toggleActivityBy(Toggling.invertToggle);
	// method: toggle the activity of these given game objects, then return the list of these given game objects //
	public static List<GameObject> toggleActivity(this IEnumerable<GameObject> gameObjects)
		=>	gameObjects.forEachManifested(gameObject =>
				gameObject.toggleActivity());

	// method: set the activity of these given game objects to the given boolean, then return them //
	public static GameObject[] setActivityTo(this GameObject[] gameObjects, bool activity)
		=> gameObjects.forEach(gameObject => gameObject.setActivityTo(activity));

	// method: activate these given game objects, then return them //
	public static GameObject[] activate(this GameObject[] gameObjects)
		=> gameObjects.setActivityTo(true);

	// method: deactivate these given game objects, then return them //
	public static GameObject[] deactivate(this GameObject[] gameObjects)
		=> gameObjects.setActivityTo(false);
	#endregion activity


	#region labels setting

	// method: (according to the given boolean:) set the labels (tag and layer) of this given provided game object to the labels (respectively) of the other given provided game object, then return this given provided game object //
	public static ObjectT setLabelsTo<ObjectT>(this ObjectT gameObject_GameObjectProvider, object otherGameObject_GameObjectProvider, bool boolean = true)
		=>	gameObject_GameObjectProvider
				.setTagTo(otherGameObject_GameObjectProvider, boolean)
				.setLayerTo(otherGameObject_GameObjectProvider, boolean);
	#endregion labels setting


	#region acting

	// method: if this given object exists, return this given object; otherwise, return null //
	public static GameObject ifExists(this GameObject gameObject)
		=> gameObject.exists() ? gameObject : null;

	// method: (according to the given boolean:) if this given object exists, execute the given action, then return this given object //
	public static GameObject ifExists(this GameObject gameObject, Action action, bool boolean = true)
		=> gameObject.after(
			action,
			gameObject.exists().and(boolean));

	// method: if this given object exists and the given boolean is true, execute the given action on this given object and return this given object //
	public static GameObject ifExists(this GameObject gameObject, Action<GameObject> action, bool boolean = true)
		=> gameObject.after(
			action,
			gameObject.exists().and(boolean));

	// method: if this given object exists, execute the given function upon it and return the function's result, otherwise returning the default value of the function's result type //
	public static TResult ifExists<TResult>(this GameObject object_, Func<GameObject, TResult> function)
		=> object_.exists() ?
			function(object_) :
			default(TResult);

	// method: if this given object is destroyed, return this given object; otherwise, return null //
	public static GameObject ifDestroyed(this GameObject gameObject)
		=> gameObject.destroyed() ? gameObject : null;

	// method: (according to the given boolean:) if this given object is destroyed, execute the given action, then return this given object //
	public static GameObject ifDestroyed(this GameObject gameObject, Action action, bool boolean = true)
		=> gameObject.after(
			action,
			gameObject.destroyed().and(boolean));

	// method: if this given object is destroyed and the given boolean is true, execute the given action on this given object and return this given object //
	public static GameObject ifDestroyed(this GameObject gameObject, Action<GameObject> action, bool boolean = true)
		=> gameObject.after(
			action,
			gameObject.destroyed().and(boolean));

	// method: if this given object is destroyed, execute the given function upon it and return the function's result, otherwise returning the default value of the function's result type //
	public static TResult ifDestroyed<TResult>(this GameObject gameObject, Func<GameObject, TResult> function)
		=> gameObject.destroyed() ?
			function(gameObject) :
			default(TResult);
	#endregion acting


	#region calling local methods

	// method: if this given game object exists and the given boolean is true: execute all of this given game object's mono behaviours' defined methods (ignoring inherited methods that haven't been overriden) with the given name, then return this given game object //
	public static GameObject executeAllLocal(this GameObject gameObject, string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver, bool boolean = true)
		=> gameObject.after(()=>
			gameObject.SendMessage(methodName, sendMessageOptions),
			boolean);

	// method: (if in the editor:) have all mono behaviours on this game object validate (if they have OnValidate defined), then return this given game object //
	public static GameObject validate_IfInEditor(this GameObject gameObject)
		=>	gameObject.executeAllLocal
			(
				"OnValidate", SendMessageOptions.DontRequireReceiver,
				UnityIs.inEditor
			);
	#endregion calling local methods


	#region conversion

	// method: return the game object idee for this given game object //
	public static int idee(this GameObject gameObject)
		=> gameObject.GetInstanceID();

	#if UNITY_EDITOR
	// method: if there is a game object corresponding to this given integer as a game object idee, return that game object; otherwise, return null //
	public static GameObject gameObject(this int gameObjectIdee)
		=> EditorUtility.InstanceIDToObject(gameObjectIdee) as GameObject;
	#endif
	#endregion conversion
}