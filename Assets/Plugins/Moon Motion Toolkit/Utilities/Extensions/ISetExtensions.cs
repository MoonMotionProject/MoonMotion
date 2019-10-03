using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ISet Extensions: provides extension methods for handling ISets //
// #enumerables
public static class ISetExtensions
{
	#region adding

	// method: (according to the given boolean:) add the given item to this given set, then return this given set //
	public static ISet<TItem> add<TItem>(this ISet<TItem> set, TItem item, bool boolean = true)
		=> set.after(()=>
			set.Add(item),
			boolean);

	// method: (according to the given boolean:) add the given item to this given set, then return the given item //
	public static TItem addGet<TItem>(this ISet<TItem> set, TItem item, bool boolean = true)
		=> item.after(()=>
			set.add(item, boolean));

	// method: (according to the given boolean:) add this given item to the given set, then return the given set //
	public static ISet<TItem> addToGet<TItem>(this TItem item, ISet<TItem> set, bool boolean = true)
		=> set.add(item, boolean);

	// method: (according to the given boolean:) add this given item to the given set, then return this given item //
	public static TItem addTo<TItem>(this TItem item, ISet<TItem> set, bool boolean = true)
		=> set.addGet(item, boolean);
	#endregion adding


	#region acting upon all items

	// method: (according to the given boolean:) invoke the given action on each item in this given set, then return this given set //
	public static ISet<TItem> forEach<TItem>(this ISet<TItem> set, Action<TItem> action, bool boolean = true)
		=> set.forEach_EnumerableSpecializedViaCasting(action, boolean);
	#endregion acting upon all items
}