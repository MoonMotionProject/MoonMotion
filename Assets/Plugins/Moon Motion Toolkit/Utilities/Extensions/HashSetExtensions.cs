using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hash Set Extensions: provides extension methods for handling hash sets //
// #enumerable-e
public static class HashSetExtensions
{
	// methods for: copying //

	// method: return a new copy of this given hash set //
	public static HashSet<TItem> copy<TItem>(this HashSet<TItem> set)
		=> new HashSet<TItem>(set);


	// methods for: adding //

	// method: (according to the given boolean:) add the given item to this given hash set, then return the given item //
	public static TItem add<TItem>(this HashSet<TItem> set, TItem item, bool boolean = true)
		=> item.after(()=>
			set.Add(item),
			boolean);

	// method: (according to the given boolean:) add the given item to this given hash set, then return this given hash set //
	public static HashSet<TItem> afterAdding<TItem>(this HashSet<TItem> set, TItem item, bool boolean = true)
		=> set.after(()=>
			set.add(item),
			boolean);

	// method: (according to the given boolean:) add this given item to the given hash set, then return this given item //
	public static TItem addedTo<TItem>(this TItem item, HashSet<TItem> set, bool boolean = true)
		=> set.add(item);

	// method: (according to the given boolean:) add this given item to the given hash set, then return the given hash set //
	public static HashSet<TItem> addTo<TItem>(this TItem item, HashSet<TItem> set, bool boolean = true)
		=> set.afterAdding(item);


	// methods for: removing //

	// method: (according to the given boolean:) remove the given item from this given hash set, then return the given item //
	public static TItem remove<TItem>(this HashSet<TItem> set, TItem item, bool boolean = true)
		=> item.after(()=>
			set.Remove(item),
			boolean);

	// method: (according to the given boolean:) remove the given item from this given hash set, then return this given hash set //
	public static HashSet<TItem> afterRemoving<TItem>(this HashSet<TItem> set, TItem item, bool boolean = true)
		=> set.after(()=>
			set.remove(item),
			boolean);

	// method: (according to the given boolean:) remove this given item from the given hash set, then return this given item //
	public static TItem removedFrom<TItem>(this TItem item, HashSet<TItem> set, bool boolean = true)
		=> set.remove(item);

	// method: (according to the given boolean:) remove this given item from the given hash set, then return this given item //
	public static HashSet<TItem> removeFrom<TItem>(this TItem item, HashSet<TItem> set, bool boolean = true)
		=> set.afterRemoving(item);


	// methods for: iteration //

	// method: (according to the given boolean:) invoke the given action on each item in this given set, then return this given set //
	public static HashSet<TItem> forEach<TItem>(this HashSet<TItem> set, Action<TItem> action, bool boolean = true)
		=> set.forEach_CollectionSpecializedViaCasting(action, boolean);


	// methods for: casting //

	// method: return this given hash set cast to the corresponding (interface) set //
	public static ISet<TItem> castToISet<TItem>(this HashSet<TItem> set)
		=> set;
}