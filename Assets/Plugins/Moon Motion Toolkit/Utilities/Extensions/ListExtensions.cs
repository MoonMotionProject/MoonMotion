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

	// method: add the given item to this given list, then return this given list //
	public static List<TItem> add<TItem>(this List<TItem> list, TItem item)
		=> list.after(()=>
			list.Add(item));
	// method: add these given items to this given list, then return this given list //
	public static List<TItem> add<TItem>(this List<TItem> list, IEnumerable<TItem> items)
		=> list.after(()=>
			items.forEach(item => list.add(item)));
	// method: add these given items to this given list, then return this given list //
	public static List<TItem> add<TItem>(this List<TItem> list, params TItem[] items)
		=> list.add(items);

	// method: add the given item to this given list, then return the given item //
	public static TItem addGet<TItem>(this List<TItem> list, TItem item)
		=> item.after(()=>
			list.add(item));
	// method: add these given items to this given list, then return these given items //
	public static IEnumerableT addGet<TItem, IEnumerableT>(this List<TItem> list, IEnumerableT items) where IEnumerableT : IEnumerable<TItem>
		=> items.after(()=>
			list.add(items));
	// method: add these given items to this given list, then return these given items //
	public static TItem[] addGet<TItem>(this List<TItem> list, params TItem[] items)
		=> list.addGet<TItem, TItem[]>(items);


	// methods for: removing //

	// method: remove the first occurrence of the given item from this given list (assuming the given item is actually contained in this given list), then return this given list //
	public static List<TItem> remove<TItem>(this List<TItem> list, TItem item)
		=> list.after(()=>
			list.Remove(item));
	// method: remove the first occurrence of each of these given items from this given list (assuming every given item is actually contained in this given list), then return this given list //
	public static List<TItem> remove<TItem>(this List<TItem> list, IEnumerable<TItem> items)
		=> list.after(()=>
			items.forEach(item => list.remove(item)));
	// method: remove the first occurrence of each of these given items from this given list (assuming every given item is actually contained in this given list), then return this given list //
	public static List<TItem> remove<TItem>(this List<TItem> list, params TItem[] items)
		=> list.remove(items);
	// method: remove the items in this given list for which the given function returns from this given list, then return this given list //
	public static List<TItem> removeWhere<TItem>(this List<TItem> list, Func<TItem, bool> function)
		=> list.after(()=>
			list.RemoveAll(function.asPredicate()));

	// method: remove the first occurrence of the given item from this given list (assuming the given item is actually contained in this given list), then return the given item //
	public static TItem extract<TItem>(this List<TItem> list, TItem item)
		=> item.after(()=>
			list.remove(item));
	// method: remove the first occurrence of each of these given items from this given list (assuming every given item is actually contained in this given list), then return these given items //
	public static IEnumerableT extract<TItem, IEnumerableT>(this List<TItem> list, IEnumerableT items) where IEnumerableT : IEnumerable<TItem>
		=> items.after(()=>
			list.remove(items));
	// method: remove the first occurrence of each of these given items from this given list (assuming every given item is actually contained in this given list), then return these given items //
	public static TItem[] extract<TItem>(this List<TItem> list, params TItem[] items)
		=> list.extract<TItem, TItem[]>(items);


	// methods for: iteration //

	// method: (according to the given boolean:) invoke the given action on each item in this given list, then return this given list //
	public static List<TItem> forEach<TItem>(this List<TItem> list, Action<TItem> action, bool boolean = true)
		=> list.forEach_CollectionSpecializedViaCasting(action, boolean);
}