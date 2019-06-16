using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Set Extensions: provides extension methods for handling sets //
public static class SetExtensions
{
	// methods for: determining content //

	// method: return whether this given array is empty //
	public static bool empty<TItem>(this ISet<TItem> set)
		=> (set.Count == 0);

	// method: return whether this given array has any elements //
	public static bool any<TItem>(this ISet<TItem> set)
		=> (set.Count > 0);

	// method: return whether this given array has more than one element //
	public static bool plural<TItem>(this ISet<TItem> set)
		=> (set.Count > 1);


	// methods for: adding //

	// method: (according to the given boolean:) add the given item to this given set //
	public static void add<TItem>(this ISet<TItem> set, TItem item, bool boolean = true)
	{
		if (boolean)
		{
			set.Add(item);
		}
	}

	// method: (according to the given boolean:) add the given item to this given set, then return this given set //
	public static ISet<TItem> with<TItem>(this ISet<TItem> set, TItem item, bool boolean = true)
	{
		set.add(item, boolean);

		return set;
	}

	// method: (according to the given boolean:) add this given item to the given set, then return this given item //
	public static TItem addedTo<TItem>(this TItem item, ISet<TItem> set, bool boolean = true)
	{
		set.add(item, boolean);

		return item;
	}
}