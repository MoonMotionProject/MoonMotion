using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Set Extensions: provides extension methods for handling sets //
// #enumerable-e
public static class SetExtensions
{
	// methods for: adding //

	// method: (according to the given boolean:) add the given item to this given set, then return the given item //
	public static TItem add<TItem>(this ISet<TItem> set, TItem item, bool boolean = true)
	{
		if (boolean)
		{
			set.Add(item);
		}

		return item;
	}

	// method: (according to the given boolean:) add the given item to this given set, then return this given set //
	public static ISet<TItem> afterAdding<TItem>(this ISet<TItem> set, TItem item, bool boolean = true)
		=> set.after(()=>
			set.add(item),
			boolean);

	// method: (according to the given boolean:) add this given item to the given set, then return this given item //
	public static TItem addedTo<TItem>(this TItem item, ISet<TItem> set, bool boolean = true)
		=> set.add(item);

	// method: (according to the given boolean:) add this given item to the given set, then return the given set //
	public static ISet<TItem> addTo<TItem>(this TItem item, ISet<TItem> set, bool boolean = true)
		=> set.afterAdding(item);


	// methods for: iteration //

	// method: (according to the given boolean:) invoke the given action on each item in this given set, then return this given set //
	public static ISet<TItem> forEach<TItem>(this ISet<TItem> set, Action<TItem> action, bool boolean = true)
		=> set.forEach_CollectionSpecializedViaCasting(action, boolean);
}