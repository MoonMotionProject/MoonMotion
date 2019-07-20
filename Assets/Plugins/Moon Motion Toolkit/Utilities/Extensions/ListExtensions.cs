using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// List Extensions: provides extension methods for handling lists //
// #enumerable-e
public static class ListExtensions
{
	// methods for: adding //

	// method: add the given item to this given list, then return the given item //
	public static TItem add<TItem>(this List<TItem> list, TItem item)
		=> item.after(()=>
			list.Add(item));

	// method: add the given item to this given list, then return this given list //
	public static List<TItem> afterAdding<TItem>(this List<TItem> list, TItem item)
		=> list.after(()=>
			list.add(item));


	// methods for: removing //

	// method: remove the first of the given item from this given list (assuming it is contained in the list), then return the given item //
	public static TItem remove<TItem>(this List<TItem> list, TItem item)
		=> item.after(()=>
			list.Remove(item));

	// method: remove the given item from this given list, then return this given list //
	public static List<TItem> afterRemoving<TItem>(this List<TItem> list, TItem item)
		=> list.after(()=>
			list.remove(item));

	// method: remove the items in this given list for which the given function returns from this given list, then return this given list //
	public static List<TItem> afterRemovingWhere<TItem>(this List<TItem> list, Func<TItem, bool> function)
		=> list.after(()=>
			list.RemoveAll(function.asPredicate()));


	// methods for: iteration //

	// method: (according to the given boolean:) invoke the given action on each item in this given list, then return this given list //
	public static List<TItem> forEach<TItem>(this List<TItem> list, Action<TItem> action, bool boolean = true)
		=> list.forEach_CollectionSpecializedViaCasting(action, boolean);
}