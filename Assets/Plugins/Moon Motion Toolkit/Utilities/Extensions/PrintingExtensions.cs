using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Printing Extensions: provides extension methods for printing //
public static class PrintingExtensions
{
	#region printing what is given

	// method: print this given string, then return it //
	public static string print(this string string_)
		=> string_.after(()=>
			   MonoBehaviour.print(string_.substituteIfContainsOnlySpaces("{printed an empty string or string of only spaces}")));

	// method: print this given object, then return it //
	public static ObjectT print<ObjectT>(this ObjectT object_)
		=> object_.after(()=>
			object_.ToString().print());

	// method: print this given object, logged as following the given prefix and using the given logging separator, then return this given object //
	public static ObjectT logAs<ObjectT>(this ObjectT object_, string prefix, string loggingSeparator = Default.loggingSeparator)
		=> object_.after(()=>
			(prefix+loggingSeparator+object_.ToString()).print());
	#endregion printing what is given


	#region printing counts

	// method: print the count of this given enumerable, then return this given enumerable //
	public static IEnumerable<TItem> printCount<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.after(()=>
			   enumerable.count().print());
	#endregion printing counts


	#region printing listings

	// method: print the string listing of this given enumerable, using the given separator string (comma by default), then return this given enumerable //
	public static IEnumerable<TItem> printListing<TItem>(this IEnumerable<TItem> enumerable, string separator = Default.listingSeparator)
		=> enumerable.after(()=>
			   enumerable.asListing(separator).print());
	#endregion printing listings


	#if UNITY_EDITOR
	#region printing asset paths
	
	// method: print the asset path of the script asset with this given script asset type (class of a script asset), then return this given script asset type //
	public static Type printAssetPath(this Type scriptAssetType)
		=> scriptAssetType.after(()=>
				print(scriptAssetType.assetPath()));

	// method: print the asset path of this given mono behaviour, then return this given mono behaviour //
	public static MonoBehaviour printAssetPath(this MonoBehaviour monoBehaviour)
		=> monoBehaviour.after(()=>
				print(monoBehaviour.assetPath()));
	#endregion printing asset paths
	#endif


	#region printing class names

	// method: print this given object's class name, then return this given object //
	public static ObjectT printClassName<ObjectT>(this ObjectT object_)
		=> object_.after(()=>
			   object_.className().print());

	// method: print this given object's simple class name, then return this given object //
	public static ObjectT printSimpleClassName<ObjectT>(this ObjectT object_)
		=> object_.after(()=>
			   object_.simpleClassName().print());
	#endregion printing class names


	#region printing (game object) names

	// method: print this given game object's name, then return this given game object //
	public static GameObject printName(this GameObject gameObject)
		=>	gameObject.after(()=>
				gameObject.name.print());
	#endregion printing (game object) names
}