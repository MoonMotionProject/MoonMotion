using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// List Extensions: provides extension methods for handling lists //
public static class ListExtensions
{
	// methods for: adding //

	// method: add the given item to this given list, then return this given list //
	public static List<TListItem> add<TListItem>(this List<TListItem> list, TListItem item)
	{
		list.Add(item);

		return list;
	}


	// methods for: removing //

	// method: remove the given item from this given list, then return this given list //
	public static List<TListItem> remove<TListItem>(this List<TListItem> list, TListItem item)
	{
		list.Remove(item);

		return list;
	}

	// method: clear this given list, then return this given list //
	public static List<TListItem> clear<TListItem>(this List<TListItem> list)
	{
		list.Clear();

		return list;
	}


	// methods for: listing //

	// method: return the string listing of this given list, using the given separator string (comma by default) //
	public static string asListing<TListItem>(this List<TListItem> list, string separator = ",")
		=> string.Join(separator, list);
}