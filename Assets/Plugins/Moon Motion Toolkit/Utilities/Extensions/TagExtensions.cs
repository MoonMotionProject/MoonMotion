using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TagExtensions: provides extension methods for handling Tags //
public static class TagExtensions
{
	#region comparison

	// method: return whether the tag of this given game object matches the given tag //
	public static bool tagMatches(this GameObject gameObject, string tag)
		=> gameObject.CompareTag(tag);

	// method: return whether the tag of the game object of this given component matches the given tag //
	public static bool tagMatches(this Component component, string tag)
		=> component.gameObject.tagMatches(tag);

	// method: return whether the tag of this given game object contains the given string //
	public static bool tagContains(this GameObject gameObject, string string_)
		=> gameObject.tag.Contains(string_);

	// method: return whether the tag of the game object of this given component contains the given string //
	public static bool tagContains(this Component component, string string_)
		=> component.gameObject.tagContains(string_);

	// method: return whether the tag of this given game object matches or contains (based on the given boolean) the given tag //
	public static bool tagMatchesOrContains(this GameObject gameObject, string tag, bool matchesVersusContains)
		=>	 (
				matchesVersusContains ?
					gameObject.tagMatches(tag) :
					gameObject.tagContains(tag)
			);

	// method: return whether the tag of the game object for this given component matches or contains (based on the given boolean) the given tag //
	public static bool tagMatchesOrContains(this Component component, string tag, bool matchesVersusContains)
		=> component.gameObject.tagMatchesOrContains(tag, matchesVersusContains);
	#endregion comparison


	#region searching for self or ancestor based on comparison

	// method: return the first game object out of this given game object and its parent game objects (searching upward) to have the given tag (null if none found) //
	public static GameObject selfOrParentWithTag(this GameObject gameObject, string tag)
		=> gameObject.selfOrParentWithLabelThatMatchesOrContains(tag, LabelType.tag, true);

	// method: return the first game object out of the game object for this component and that game object's parent game objects (searching upward) to have the given tag (null if none found) //
	public static GameObject selfOrParentWithTag(this Component component, string tag)
		=> component.gameObject.selfOrParentWithTag(tag);

	// method: return the first game object out of this given game object and its parent game objects (searching upward) to have a tag containing the given string (null if none found) //
	public static GameObject selfOrParentWithTagContaining(this GameObject gameObject, string string_)
		=> gameObject.selfOrParentWithLabelThatMatchesOrContains(string_, LabelType.tag, false);

	// method: return the first game object out of the game object for this component and that game object's parent game objects (searching upward) to have a tag containing the given string (null if none found) //
	public static GameObject selfOrParentWithTagContaining(this Component component, string string_)
		=> component.gameObject.selfOrParentWithTagContaining(string_);
	#endregion searching for self or ancestor based on comparison


	#region setting

	// method: (according to the given boolean:) set the tag of this given provided game object, then return this given provided game object //
	public static ObjectT setTagTo<ObjectT>(this ObjectT gameObject_GameObjectProvider, object tag_TagProvider, bool boolean = true)
		=>	gameObject_GameObjectProvider.after(()=>
				gameObject_GameObjectProvider.provideGameObject().tag = tag_TagProvider.provideTag(),
				boolean);
	
	// method: (according to the given boolean:) imply setting the tag of these given provided game objects to the given provided tag, then return the selection of these given provided game objects //
	public static IEnumerable<ObjectT> implySetTagOfEachTo<ObjectT>(this IEnumerable<ObjectT> gameObjects_GameObjectsProvider, object tag_TagProvider, bool boolean = true)
		=>	gameObjects_GameObjectsProvider.implyForEach(gameObject_GameObjectProvider =>
				gameObject_GameObjectProvider.setTagTo(tag_TagProvider),
				boolean);
	// method: (according to the given boolean:) set the tag of these given provided game objects to the given provided tag, then return a list of these given provided game objects //
	public static List<ObjectT> setTagOfEachTo<ObjectT>(this IEnumerable<ObjectT> gameObjects_GameObjectsProvider, object tag_TagProvider, bool boolean = true)
		=>	gameObjects_GameObjectsProvider.implySetTagOfEachTo(tag_TagProvider, boolean).manifested();
	#endregion setting
}