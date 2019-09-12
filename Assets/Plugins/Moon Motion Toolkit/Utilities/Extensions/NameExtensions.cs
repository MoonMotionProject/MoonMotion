using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Name Extensions: provides extension methods for handling (game object) names //
public static class NameExtensions
{
	#region listing

	// method: return the string that is the listing of the names corresponding to these given game objects //
	public static string namesListing(this GameObject[] gameObjects)
		=> gameObjects.selectNames().asListing();
	#endregion listing


	#region accessing

	// method: return this given game object's name quoted //
	public static string nameQuoted(this GameObject gameObject)
		=> gameObject.name.quoted();

	// method: return the selection of names corresponding to these given game objects //
	public static IEnumerable<string> selectNames(this GameObject[] gameObjects)
		=> gameObjects.select(gameObject => gameObject.name);
	#endregion accessing


	#region setting

	// method: (according to the given boolean:) set this given game object's name to the given name, then return this given game object //
	public static GameObject setNameTo(this GameObject gameObject, string name, bool boolean = true)
	{
		if (boolean)
		{
			gameObject.name = name;
		}

		return gameObject;
	}
	// method: (according to the given boolean:) append the given suffix to this given game object's name, then return this given game object //
	public static GameObject toNameAppend(this GameObject gameObject, string suffix, bool boolean = true)
	{
		if (boolean)
		{
			gameObject.setNameTo(gameObject.name+suffix);
		}

		return gameObject;
	}
	#endregion setting


	#region comparison

	// method: return whether the name of this given game object matches the given name //
	public static bool nameMatches(this GameObject gameObject, string name)
		=> gameObject.name.Equals(name);
	// method: return whether the name of the game object for this given component matches the given name //
	public static bool nameMatches(this Component component, string name)
		=> component.gameObject.nameMatches(name);

	// method: return whether the name of this given game object contains the given string //
	public static bool nameContains(this GameObject gameObject, string string_)
		=> gameObject.name.Contains(string_);
	// method: return whether the name of the game object of this given component contains the given string //
	public static bool nameContains(this Component component, string string_)
		=> component.gameObject.nameContains(string_);

	// method: return whether the name of this given game object matches or contains (based on the given boolean) the given name //
	public static bool nameMatchesOrContains(this GameObject gameObject, string name, bool matchesVersusContains)
		=>	(
				matchesVersusContains ?
					gameObject.nameMatches(name) :
					gameObject.nameContains(name)
			);
	// method: return whether the name of the game object for this given component matches or contains (based on the given boolean) the given name //
	public static bool nameMatchesOrContains(this Component component, string name, bool matchesVersusContains)
		=> component.gameObject.nameMatchesOrContains(name, matchesVersusContains);
	#endregion comparison


	#region searching for self or parent based on comparison 

	// method: return the first game object out of this given game object and its parent game objects (searching upward) to have the given name (null if none found) //
	public static GameObject selfOrParentWithName(this GameObject gameObject, string name)
		=> gameObject.selfOrParentWithLabelThatMatchesOrContains(name, LabelType.name, true);
	// method: return the first game object out of the game object for this component and that game object's parent game objects (searching upward) to have the given name (null if none found) //
	public static GameObject selfOrParentWithName(this Component component, string name)
		=> component.gameObject.selfOrParentWithName(name);

	// method: return the first game object out of this given game object and its parent game objects (searching upward) to have a name containing the given string (null if none found) //
	public static GameObject selfOrParentWithNameContaining(this GameObject gameObject, string string_)
		=> gameObject.selfOrParentWithLabelThatMatchesOrContains(string_, LabelType.name, false);
	// method: return the first game object out of the game object for this component and that game object's parent game objects (searching upward) to have a name containing the given string (null if none found) //
	public static GameObject selfOrParentWithNameContaining(this Component component, string string_)
		=> component.gameObject.selfOrParentWithNameContaining(string_);
	#endregion searching for self or parent based on comparison 
}