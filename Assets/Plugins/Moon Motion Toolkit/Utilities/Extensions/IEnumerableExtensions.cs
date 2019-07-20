using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// IEnumerable Extensions: provides extension methods for handling enumerables //
// #enumerable-e
public static class IEnumerableExtensions
{
	// constants //


	// constants for: listing //

	public const string listingSeparatorDefault = ", ";


	/*// methods for: copying //

	// method: return a copy of this given enumerable //
	public static IEnumerableCustomT copy<IEnumerableCustomT, TItem>(this IEnumerableCustomT enumerable) where IEnumerableCustomT : IEnumerableCustom<TItem>, new()
		=> new IEnumerableT(enumerable);*/


	// methods for: printing //

	// method: print the string listing of this given enumerable, using the given separator string (comma by default), then return the string listing //
	public static string printListing<TItem>(this IEnumerable<TItem> enumerable, string separator = listingSeparatorDefault)
		=> enumerable.asListing(separator).print();


	// methods for: listing //

	// method: return the string listing of this given enumerable, using the given separator string (comma by default) //
	public static string asListing<TItem>(this IEnumerable<TItem> enumerable, string separator = listingSeparatorDefault)
		=> string.Join(separator, enumerable);


	// methods for: determining content //

	// method: return the number of items in this given enumerable //
	public static int count<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.Count();

	// method: return the number of items in this given enumerable for which the given function returns true //
	public static int count<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function)
		=> enumerable.Count(function);

	// method: return whether this given enumerable is empty //
	public static bool empty<TItem>(this IEnumerable<TItem> enumerable)
		=> (enumerable.count() == 0);

	// method: return whether this given enumerable has any items //
	public static bool any<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.Any();

	// method: return whether this given enumerable has any items for which the given function returns true //
	public static bool any<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function)
		=> enumerable.Any(function);

	// method: return whether this given enumerable has more than one item //
	public static bool plural<TItem>(this IEnumerable<TItem> enumerable)
		=> (enumerable.count() > 1);

	// method: return whether this given enumerable contains the given item //
	public static bool contains<TItem>(this IEnumerable<TItem> enumerable, TItem item)
		=> enumerable.Contains(item);

	// method: return whether this given enumerable contains any item other than the given item //
	public static bool containsOtherThan<TItem>(this IEnumerable<TItem> enumerable, TItem item)
		=> enumerable.any(item_ => item_.isNotBaselineEqualTo(item));

	// method: return whether this given enumerable does not contain the given item //
	public static bool doesNotContain<TItem>(this IEnumerable<TItem> enumerable, TItem item)
		=> !enumerable.contains(item);

	// method: return whether this given item is in the given enumerable //
	public static bool isIn<TItem>(this TItem item, IEnumerable<TItem> enumerable)
		=> enumerable.contains(item);

	// method: return whether this given item is not in the given enumerable //
	public static bool isNotIn<TItem>(this TItem item, IEnumerable<TItem> enumerable)
		=> enumerable.doesNotContain(item);

	// method: return whether this given enumerable contains any item that the other given enumerable also contains //
	public static bool anyIn<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable)
		=> enumerable.any(item => item.isIn(otherEnumerable));

	// method: return whether this given enumerable contains any item that the other given enumerable does not contain //
	public static bool anyNotIn<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable)
		=> enumerable.any(item => item.isNotIn(otherEnumerable));

	// method: return whether this given enumerable contains no item that the other given enumerable also contains //
	public static bool noneIn<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable)
		=> !enumerable.anyIn(otherEnumerable);


	// methods for: accessing //

	// method: return the item at the given index in this given enumerable (assuming an item is there) //
	public static TItem item<TItem>(this IEnumerable<TItem> enumerable, int index)
		=> enumerable.ElementAt(index);

	// method: return the item at the given index in this given enumerable, otherwise (if an item is not there) returning the default value of the specified item type //
	public static TItem itemOtherwiseDefault<TItem>(this IEnumerable<TItem> enumerable, int index)
		=> enumerable.ElementAtOrDefault(index);

	// method: return the first item in this given enumerable (assuming an item is there) //
	public static TItem first<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.First();

	// method: return the first item in this given enumerable, otherwise (if an item is not there) returning the default value of the specified item type //
	public static TItem firstOtherwiseDefault<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.FirstOrDefault();


	// methods for: removing //

	// method: (according to the given boolean:) instead of returning this given enumerable, return an enumerable of the items in this given enumerable for which the given function returns true //
	public static IEnumerable<TItem> where<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=> boolean ? enumerable.Where(function) : enumerable;

	// method: (according to the given boolean:) instead of returning this given enumerable, return an enumerable of the items in this given enumerable for which the given function returns false //
	public static IEnumerable<TItem> whereNot<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=>	enumerable.where(
				function.negated(),
				boolean);

	// method: (according to the given boolean:) instead of returning this given enumerable, return an enumerable of the items in this given enumerable which are equal to the given item //
	public static IEnumerable<TItem> where<TItem>(this IEnumerable<TItem> enumerable, TItem item, bool boolean = true)
		=> enumerable.where(
			item_ => item_.baselineEquals(item),
			boolean);

	// method: (according to the given boolean:) instead of returning this given enumerable, return an enumerable of the items in this given enumerable which are not equal to the given item //
	public static IEnumerable<TItem> whereNot<TItem>(this IEnumerable<TItem> enumerable, TItem item, bool boolean = true)
		=> enumerable.where(
			item_ => item_.isNotBaselineEqualTo(item),
			boolean);


	// methods for: iteration //

	// method: (according to the given boolean:) invoke the given action on each item in this given enumeration, then return this given enumeration //
	public static IEnumerable<TItem> forEach<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action, bool boolean = true)
	{
		if (boolean)
		{
			foreach (TItem item in enumerable)
			{
				action(item);
			}
		}

		return enumerable;
	}

	// method: (according to the given boolean:) invoke the given action on each item in this given enumeration, then return this given enumeration //
	public static IEnumerableT forEach_EnumerableSpecializedViaCasting<IEnumerableT, TItem>(this IEnumerableT enumerable, Action<TItem> action, bool boolean = true) where IEnumerableT : IEnumerable<TItem>
		=> enumerable.after(()=>
			enumerable.castTo<IEnumerable<TItem>>().forEach(action),
			boolean);

	// method: (according to the given boolean:) invoke the given action on each item in this given enumeration where the given function returns true, then return this given enumeration //
	public static IEnumerable<TItem> forEachWhere<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, Action<TItem> action, bool boolean = true)
		=> enumerable.after(()=>
			enumerable.forEach(action.predicatedWith(function)),
			boolean);

	// method: invoke the given action on the first item in this given enumeration if it has any items, then return this given enumeration //
	public static IEnumerable<TItem> forFirstIfAny<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action)
	{
		if (enumerable.any())
		{
			action(enumerable.first());
		}

		return enumerable;
	}

	// method: return the first item in this given enumerable for which the given function returns true, returning the default value of the specified item class otherwise //
	public static TItem firstWhere<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function)
	{
		foreach (TItem item in enumerable)
		{
			if (function(item))
			{
				return item;
			}
		}

		return default(TItem);
	}

	public static IEnumerable<TResult> select<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.Select(function);

	public static IEnumerable<TResult> selectWhereYull<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.Select(function).where(item => item.isYull());

	public static IEnumerable<TResult> selectWhereNull<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.Select(function).where(item => item.isNull());

	public static IEnumerable<TResult> selectNested<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, IEnumerable<TResult>> function)
		=> enumerable.SelectMany(function);

	public static IEnumerable<TItem> orderByAscending<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.OrderBy(function);

	public static IEnumerable<TItem> orderByAscending<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.OrderBy(item => item);

	public static IEnumerable<TItem> orderByDescending<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.OrderByDescending(function);

	public static IEnumerable<TItem> orderByDescending<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.OrderByDescending(item => item);

	public static TItem itemWithMax<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.orderByDescending(function).Max();

	public static TItem itemWithMax<TItem, TResult>(this IEnumerable<TItem> enumerable)
		=> enumerable.itemWithMax(item => item);

	public static TItem itemWithMin<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.orderByDescending(function).Max();

	public static TItem itemWithMin<TItem, TResult>(this IEnumerable<TItem> enumerable)
		=> enumerable.itemWithMin(item => item);
}