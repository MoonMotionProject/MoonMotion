using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Printing Extensions:
// • provides extension methods for printing
// #console
public static class PrintingExtensions
{
	#region printing what is given

	// method: print this given string, optionally with the given game object as the context, then return it //
	public static string print(this string string_, GameObject contextGameObject = null)
	{
		string stringToPrint = string_.substituteIfContainsOnlySpaces("{printed an empty string or string of only spaces}");
		if (contextGameObject.isYull())
		{
			Debug.Log
			(
				stringToPrint,
				contextGameObject
			);
		}
		else
		{
			Debug.Log(stringToPrint);
		}
		return string_;
	}   

	// method: print this given object, optionally with the given game object as the context, then return it //
	public static ObjectT print<ObjectT>(this ObjectT object_, GameObject contextGameObject = null)
		=>	object_.returnAnd(()=>
				object_.ToString().print(contextGameObject));
	// method: print this given game object with itself as the context, then return it //
	public static GameObject print(this GameObject gameObject)
		=> gameObject.print(gameObject);

	// method: print this given object, optionally with the given game object as the context, logged as following the given prefix and using the given logging separator, then return this given object //
	public static ObjectT logAs<ObjectT>(this ObjectT object_, string prefix, GameObject contextGameObject = null, string loggingSeparator = Default.loggingSeparator)
		=>	object_.returnAnd(()=>
				(prefix+loggingSeparator+object_.ToString()).print(contextGameObject));
	// method: print this given game object with itself as the context, logged as following the given prefix and using the given logging separator, then return this given game object //
	public static GameObject logAs(this GameObject gameObject, string prefix, string loggingSeparator = Default.loggingSeparator)
		=> gameObject.logAs(prefix, gameObject, loggingSeparator);
	#endregion printing what is given


	#region printing counts

	// method: print the count of this given enumerable, optionally with the given game object as the context, then return this given enumerable //
	public static IEnumerable<TItem> printCount<TItem>(this IEnumerable<TItem> enumerable, GameObject contextGameObject = null)
		=> enumerable.after(()=>
			   enumerable.count().print(contextGameObject));
	#endregion printing counts


	#region printing listings

	// method: print the string listing of this given enumerable, optionally with the given game object as the context, using the given separator string (comma by default), then return this given enumerable //
	public static IEnumerable<TItem> printListing<TItem>(this IEnumerable<TItem> enumerable, string separator = Default.listingSeparator, GameObject contextGameObject = null)
		=>	enumerable.after(()=>
			   enumerable.asListing(separator).print(contextGameObject));

	// method: print the string listing of the uniques in this given enumerable, optionally with the given game object as the context, using the given separator string (comma by default), then return the set of items in this given enumerable //
	public static HashSet<TItem> printUniquesListing<TItem>(this IEnumerable<TItem> enumerable, string separator = Default.listingSeparator, GameObject contextGameObject = null)
		=> enumerable.uniques().printListing(separator, contextGameObject).uniques();
	#endregion printing listings


	#if UNITY_EDITOR
	#region printing project paths
	
	// method: (via reflection:) print the project path of the script asset with this given script asset type (class of a script asset), optionally with the given game object as the context, then return this given script asset type //
	public static Type printProjectPath_ViaReflection(this Type scriptAssetType, GameObject contextGameObject = null)
		=> scriptAssetType.after(()=>
				scriptAssetType.projectPath_ViaReflection().print(contextGameObject));

	// method: print the project path of this given mono behaviour, optionally with the given game object as the context, then return this given mono behaviour //
	public static MonoBehaviour printProjectPath(this MonoBehaviour monoBehaviour, GameObject contextGameObject = null)
		=> monoBehaviour.after(()=>
				monoBehaviour.projectPath().print(contextGameObject));
	#endregion printing project paths
	#endif


	#region printing class names

	// method: (via reflection:) print this given object's class name, optionally with the given game object as the context, then return this given object //
	public static ObjectT printClassName_ViaReflection<ObjectT>(this ObjectT object_, GameObject contextGameObject = null)
		=> object_.returnAnd(()=>
			   object_.className_ViaReflection().print(contextGameObject));

	// method: (via reflection:) print this given object's simple class name, optionally with the given game object as the context, then return this given object //
	public static ObjectT printSimpleClassName_ViaReflection<ObjectT>(this ObjectT object_, GameObject contextGameObject = null)
		=> object_.returnAnd(()=>
			   object_.simpleClassName_ViaReflection().print(contextGameObject));
	#endregion printing class names


	#region printing (game object) names

	// method: print this given game object's name with itself as the context, then return this given game object //
	public static GameObject printName(this GameObject gameObject)
		=>	gameObject.after(()=>
				gameObject.name.print(gameObject));
	#endregion printing (game object) names
}