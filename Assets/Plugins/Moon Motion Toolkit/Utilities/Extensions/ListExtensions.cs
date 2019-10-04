using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// List Extensions: provides extension methods for handling lists //
// #enumerables
public static class ListExtensions
{
	#region adding

	// method: add the given item to this given list, then return this given list //
	public static List<TItem> add<TItem>(this List<TItem> list, TItem item)
		=> list.after(()=>
			list.Add(item));
	// method: add the given items to this given list, then return this given list //
	public static List<TItem> add<TItem>(this List<TItem> list, IEnumerable<TItem> items)
		=> list.after(()=>
			list.AddRange(items));
	// method: add the given items to this given list, then return this given list //
	public static List<TItem> add<TItem>(this List<TItem> list, params TItem[] items)
		=> list.add(items.asEnumerable());

	// method: add the given item to this given list, then return the given item //
	public static TItem addGet<TItem>(this List<TItem> list, TItem item)
		=> item.after(()=>
			list.add(item));
	// method: add the given items to this given list, then return a list of these given items //
	public static List<TItem> addGet<TItem>(this List<TItem> list, IEnumerable<TItem> items)
		=> items.manifested().after(()=>
			list.add(items));
	// method: add the given items to this given list, then return a list of these given items //
	public static List<TItem> addGet<TItem>(this List<TItem> list, params TItem[] items)
		=> list.addGet(items.asEnumerable());

	// method: add this given item to the given list, then return the given list //
	public static List<TItem> addToGet<TItem>(this TItem item, List<TItem> list, bool boolean = true)
		=> list.add(item);
	// method: add these given items to the given list, then return the given list //
	public static List<TItem> addToGet<TItem>(this IEnumerable<TItem> items, List<TItem> list)
		=> list.add(items);

	// method: add this given item to the given list, then return this given item //
	public static TItem addTo<TItem>(this TItem item, List<TItem> list)
		=> list.addGet<TItem>(item);
	// method: add these given items to the given list, then return a list of these given items //
	public static List<TItem> addTo<TItem>(this IEnumerable<TItem> items, List<TItem> list)
		=> list.addGet(items);
	#endregion adding


	#region removing

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
		=> list.remove(items.asEnumerable());
	// method: remove the items in this given list for which the given function returns from this given list, then return this given list //
	public static List<TItem> removeWhere<TItem>(this List<TItem> list, Func<TItem, bool> function)
		=> list.after(()=>
			list.RemoveAll(function.asPredicate()));

	// method: remove the first occurrence of the given item from this given list (assuming the given item is actually contained in this given list), then return the given item //
	public static TItem extract<TItem>(this List<TItem> list, TItem item)
		=> item.after(()=>
			list.remove(item));
	// method: remove the first occurrence of each of these given items from this given list (assuming every given item is actually contained in this given list), then return these given items //
	public static List<TItem> extract<TItem>(this List<TItem> list, IEnumerable<TItem> items)
		=> items.manifested().after(()=>
			list.remove(items));
	// method: remove the first occurrence of each of these given items from this given list (assuming every given item is actually contained in this given list), then return these given items //
	public static List<TItem> extract<TItem>(this List<TItem> list, params TItem[] items)
		=> list.extract(items.asEnumerable());
	#endregion removing


	#region acting upon all items

	// method: (according to the given boolean:) invoke the given action on each item in this given list, then return this given list //
	public static List<TItem> forEach<TItem>(this List<TItem> list, Action<TItem> action, bool boolean = true)
		=> list.forEach_EnumerableSpecializedViaCasting(action, boolean);
	#endregion acting upon all items


	#region conversion
	
	// method: return a new list containing only this given item //
	public static List<TItem> startList<TItem>(this TItem item)
		=> new List<TItem>() {item};
	#endregion conversion
}