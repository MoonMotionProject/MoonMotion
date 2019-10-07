using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hash Set Extensions: provides extension methods for handling hash sets //
// #enumerables
public static class HashSetExtensions
{
	#region copying

	// method: return a new copy of this given hash set //
	public static HashSet<TItem> copy<TItem>(this HashSet<TItem> set)
		=> new HashSet<TItem>(set);
	#endregion copying


	#region including

	// method: (according to the given boolean:) include the given item in this given hash set, then return this given hash set //
	public static HashSet<TItem> include<TItem>(this HashSet<TItem> set, TItem item, bool boolean = true)
		=> set.after(()=>
			set.Add(item),
			boolean);
	// method: (according to the given boolean:) include the given items in this given hash set, then return this given hash set //
	public static HashSet<TItem> include<TItem>(this HashSet<TItem> set, IEnumerable<TItem> items, bool boolean = true)
		=> set.after(()=>
			set.UnionWith(items),
			boolean);

	// method: (according to the given boolean:) include the given item in this given hash set, then return the given item //
	public static TItem includeGet<TItem>(this HashSet<TItem> set, TItem item, bool boolean = true)
		=> item.after(()=>
			set.include(item),
			boolean);
	// method: (according to the given boolean:) include the given items in this given hash set, then return the given items //
	public static IEnumerable<TItem> includeGet<TItem>(this HashSet<TItem> set, IEnumerable<TItem> items, bool boolean = true)
		=> items.after(()=>
			set.include(items),
			boolean);

	// method: (according to the given boolean:) include this given item in the given hash set, then return the given hash set //
	public static HashSet<TItem> includeInGet<TItem>(this TItem item, HashSet<TItem> set, bool boolean = true)
		=> set.include(item, boolean);
	// method: (according to the given boolean:) include these given item in the given hash set, then return the given hash set //
	public static HashSet<TItem> includeInGet<TItem>(this IEnumerable<TItem> items, HashSet<TItem> set, bool boolean = true)
		=> set.after(()=>
			items.forEach(item => set.include(item)),
			boolean);

	// method: (according to the given boolean:) include this given item in the given hash set, then return this given item //
	public static TItem includeIn<TItem>(this TItem item, HashSet<TItem> set, bool boolean = true)
		=> set.includeGet(item, boolean);
	// method: (according to the given boolean:) include these given items in the given hash set, then return these given items //
	public static IEnumerable<TItem> includeIn<TItem>(this IEnumerable<TItem> items, HashSet<TItem> set, bool boolean = true)
		=> set.includeGet(items, boolean);
	#endregion including


	#region removing

	// method: (according to the given boolean:) remove the given item from this given hash set if the given item is contained in this given hash set, then return whether the given item was actually removed from this given hash set //
	public static bool tryToRemove<TItem>(this HashSet<TItem> set, TItem item, bool boolean = true)
		=> boolean && set.Remove(item);

	// method: (according to the given boolean:) remove the given item from this given hash set (assuming the given item is actually contained in this given hash set), then return this given hash set //
	public static HashSet<TItem> remove<TItem>(this HashSet<TItem> set, TItem item, bool boolean = true)
		=> set.after(()=>
			set.tryToRemove(item),
			boolean);

	// method: (according to the given boolean:) remove the given item from this given hash set (assuming the given item is actually contained in this given hash set), then return the given item //
	public static TItem removeGet<TItem>(this HashSet<TItem> set, TItem item, bool boolean = true)
		=> item.after(()=>
			set.tryToRemove(item),
			boolean);

	// method: (according to the given boolean:) remove this given item from the given hash set (assuming the given item is actually contained in this given hash set), then return this given hash set //
	public static HashSet<TItem> removeFromGet<TItem>(this TItem item, HashSet<TItem> set, bool boolean = true)
		=> set.remove(item, boolean);

	// method: (according to the given boolean:) remove this given item from the given hash set (assuming the given item is actually contained in this given hash set), then return this given item //
	public static TItem removeFrom<TItem>(this TItem item, HashSet<TItem> set, bool boolean = true)
		=> set.removeGet(item, boolean);
	#endregion removing


	#region acting upon all items

	// method: (according to the given boolean:) invoke the given action on each item in this given set, then return this given set //
	public static HashSet<TItem> forEach<TItem>(this HashSet<TItem> set, Action<TItem> action, bool boolean = true)
		=> set.forEach_EnumerableSpecializedViaCasting(action, boolean);
	#endregion acting upon all items


	#region conversion

	// method: return this given hash set cast to the corresponding (interface) set //
	public static ISet<TItem> castToISet<TItem>(this HashSet<TItem> set)
		=> set;

	// method: return a new set containing only this given item //
	public static HashSet<TItem> startSet<TItem>(this TItem item)
		=> new HashSet<TItem>() {item};
	// method: return a new set containing only the struct for this given nullable struct – only if this given nullable struct is yull //
	public static HashSet<TItem> startedOtherwiseEmptyNonnullableSet<TItem>(this TItem? item) where TItem : struct
		=> item.isYull() ? item.GetValueOrDefault().startSet() : new HashSet<TItem>();
	#endregion conversion
}