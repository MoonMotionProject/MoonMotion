using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// IEnumerable Extensions: provides extension methods and related constants for handling enumerables //
// #enumerable-e
public static class IEnumerableExtensions
{
	#region constants


	#region listing

	public const string listingSeparatorDefault = ", ";
	#endregion listing
	#endregion constants




	#region methods


	/*// methods for: copying //

	// method: return a copy of this given enumerable //
	public static IEnumerableCustomT copy<IEnumerableCustomT, TItem>(this IEnumerableCustomT enumerable) where IEnumerableCustomT : IEnumerableCustom<TItem>, new()
		=> new IEnumerableT(enumerable);*/


	#region printing

	// method: print the string listing of this given enumerable, using the given separator string (comma by default), then return the string listing //
	public static string printListing<TItem>(this IEnumerable<TItem> enumerable, string separator = listingSeparatorDefault)
		=> enumerable.asListing(separator).print();
	#endregion printing


	#region listing

	// method: return the string listing of this given enumerable, using the given separator string (comma by default) //
	public static string asListing<TItem>(this IEnumerable<TItem> enumerable, string separator = listingSeparatorDefault)
		=> string.Join(separator, enumerable);
	#endregion listing


	#region determining content

	// method: return the number of items in this given enumerable //
	public static int count<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.Count();

	// method: return the number of items in this given enumerable for which the given function returns true //
	public static int count<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function)
		=> enumerable.Count(function);

	// method: return whether this given enumerable is empty //
	public static bool isEmpty<TItem>(this IEnumerable<TItem> enumerable)
		=> (enumerable.count() == 0);

	// method: return whether this given enumerable has any items //
	public static bool hasAny<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.Any();

	// method: return whether this given enumerable has any items for which the given function returns true //
	public static bool hasAny<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function)
		=> enumerable.Any(function);

	// method: return whether this given enumerable has more than one item //
	public static bool isPlural<TItem>(this IEnumerable<TItem> enumerable)
		=> (enumerable.count() > 1);

	// method: return whether this given enumerable contains the given item //
	public static bool contains<TItem>(this IEnumerable<TItem> enumerable, TItem item)
		=> enumerable.Contains(item);

	// method: return whether this given enumerable contains any item other than the given item //
	public static bool containsOtherThan<TItem>(this IEnumerable<TItem> enumerable, TItem item)
		=> enumerable.hasAny(item_ => item_.isNotBaselineEqualTo(item));

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
	public static bool hasAnyIn<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable)
		=> enumerable.hasAny(item => item.isIn(otherEnumerable));

	// method: return whether this given enumerable contains any item that the other given enumerable does not contain //
	public static bool hasAnyNotIn<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable)
		=> enumerable.hasAny(item => item.isNotIn(otherEnumerable));

	// method: return whether this given enumerable contains no item that the other given enumerable also contains //
	public static bool hasNoneIn<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable)
		=> !enumerable.hasAnyIn(otherEnumerable);
	#endregion determining content


	#region manifestation

	// method: return a list for this given enumerable with its yieldings manifested //
	public static List<TItem> manifest<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.ToList();
	#endregion manifestation


	#region accessing items by index

	// method: return the item at the given index in this given enumerable (assuming an item is there) //
	public static TItem item<TItem>(this IEnumerable<TItem> enumerable, int index)
		=> enumerable.ElementAt(index);

	// method: return the item at the given index in this given enumerable, otherwise (if an item is not there) returning the default value of the specified item type //
	public static TItem itemOtherwiseDefault<TItem>(this IEnumerable<TItem> enumerable, int index)
		=> enumerable.ElementAtOrDefault(index);
	#endregion accessing items by index


	#region accessing first items

	// method: return the first item in this given enumerable (assuming an item is there) //
	public static TItem first<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.First();

	// method: return the first item in this given enumerable, otherwise (if an item is not there) returning the default value of the specified item type //
	public static TItem firstOtherwiseDefault<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.FirstOrDefault();
	#endregion accessing first items


	#region retrieval (accessing particulars via functions)

	public static IEnumerable<TResult> select<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.Select(function);
	public static List<TResult> pick<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.select(function).manifest();

	public static IEnumerable<TResult> selectByLooping<TItemThis, TItemLooped, TResult>(this IEnumerable<TItemThis> enumerable, IEnumerable<TItemLooped> enumerableToLoop, Func<TItemThis, TItemLooped, TResult> function)
		 =>	Select.forCount(enumerable.count(), index =>
				function(enumerable.item(index), enumerableToLoop.item(index % enumerableToLoop.count())));
	public static List<TResult> pickByLooping<TItemThis, TItemLooped, TResult>(this IEnumerable<TItemThis> enumerable, IEnumerable<TItemLooped> enumerableToLoop, Func<TItemThis, TItemLooped, TResult> function)
		 => enumerable.selectByLooping(enumerableToLoop, function).manifest();

	public static IEnumerable<TResult> selectFromOnly<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, bool> functionOnly, Func<TItem, TResult> functionSelect)
		=> enumerable.only(functionOnly).select(functionSelect);

	public static IEnumerable<TResult> selectFromYull<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.selectFromOnly(
				item => item.isYull(),
				function);

	public static IEnumerable<TResult> selectFromNull<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.selectFromOnly(
				item => item.isNull(),
				function);

	public static IEnumerable<TResult> selectNested<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, IEnumerable<TResult>> function)
		=> enumerable.SelectMany(function);
	#endregion retrieval (accessing particulars via functions)


	#region removing

	// method: (according to the given boolean:) instead of returning this given enumerable, return a selection of the items in this given enumerable for which the given function returns true //
	public static IEnumerable<TItem> only<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=> boolean ? enumerable.Where(function) : enumerable;
	// method: (according to the given boolean:) instead of returning a list for this given enumerable, return a list of the items in this given enumerable for which the given function returns true //
	public static List<TItem> where<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=> enumerable.only(function, boolean).manifest();

	// method: (according to the given boolean:) instead of returning this given enumerable, return a selection of the items in this given enumerable for which the given function returns false //
	public static IEnumerable<TItem> except<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=>	enumerable.only(
				function.negated(),
				boolean);
	// method: (according to the given boolean:) instead of returning a list for this given enumerable, return a list of the items in this given enumerable for which the given function returns false //
	public static IEnumerable<TItem> whereNot<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=> enumerable.except(function, boolean).manifest();

	// method: (according to the given boolean:) instead of returning this given enumerable, return a selection of the items in this given enumerable which are equal to the given item //
	public static IEnumerable<TItem> only<TItem>(this IEnumerable<TItem> enumerable, TItem item, bool boolean = true)
		=> enumerable.only(
			item_ => item_.baselineEquals(item),
			boolean);

	// method: (according to the given boolean:) instead of returning this given enumerable, return a selection of the items in this given enumerable which are not equal to the given item //
	public static IEnumerable<TItem> except<TItem>(this IEnumerable<TItem> enumerable, TItem item, bool boolean = true)
		=> enumerable.except(
			item_ => item_.baselineEquals(item),
			boolean);

	// method: (according to the given boolean:) instead of returning this given enumerable, return a selection of the items in this given enumerable which are not equal to any of the items in the other given enumerable //
	public static IEnumerable<TItem> except<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable, bool boolean = true)
		=> enumerable.except(
			item_ => otherEnumerable.hasAny(otherItem => item_.baselineEquals(otherItem)),
			boolean);
	// method: (according to the given boolean:) instead of returning a list for this given enumerable, return a list of the items in this given enumerable which are not equal to any of the items in the other given enumerable //
	public static IEnumerable<TItem> whereNot<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable, bool boolean = true)
		=> enumerable.except(otherEnumerable, boolean).manifest();
	// method: instead of returning this given enumerable, return a selection of the items in this given enumerable which are not equal to any of the given items //
	public static IEnumerable<TItem> except<TItem>(this IEnumerable<TItem> enumerable, params TItem[] items)
		=> enumerable.except(
			item_ => items.hasAny(otherItem => item_.baselineEquals(otherItem)));
	// method: instead of returning a list for this given enumerable, return a list of the items in this given enumerable which are not equal to any of the given items //
	public static IEnumerable<TItem> whereNot<TItem>(this IEnumerable<TItem> enumerable, params TItem[] items)
		=> enumerable.except(items).manifest();
	#endregion removing


	#region acting upon all items

	#region acting upon all items - without indexing
	// method: return a selection of the items in this given enumerable for which invocation of the given action is yielded //
	private static IEnumerable<TItem> imply<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action)
	{
		foreach (TItem item in enumerable)
		{
			action(item);
			yield return item;
		}
	}
	// method: (according to the given boolean:) instead of returning this given enumerable, return a selection of the items in this given enumerable for which invocation of the given action is yielded //
	public static IEnumerable<TItem> imply<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action, bool boolean = true)
		=> boolean ? enumerable.imply(action) : enumerable;
	// method: (according to the given boolean:) invoke the given action on each item in this given enumerable, then return this given enumerable //
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
	// method: (according to the given boolean:) invoke the given action on each item in this given enumerable, then return this given enumerable //
	public static IEnumerableT forEach_EnumerableSpecializedViaCasting<IEnumerableT, TItem>(this IEnumerableT enumerable, Action<TItem> action, bool boolean = true) where IEnumerableT : IEnumerable<TItem>
		=> enumerable.after(()=>
			enumerable.castTo<IEnumerable<TItem>>().forEach(action),
			boolean);
	#endregion acting upon all items - without indexing

	#region acting upon all items - with indexing
	// method: return a selection of the items in this given enumerable for which invocation of the given indexed action is yielded //
	private static IEnumerable<TItem> imply<TItem>(this IEnumerable<TItem> enumerable, Action<int, TItem> indexedAction)
	{
		for (int index = 0; index < enumerable.count(); index++)
		{
			TItem item = enumerable.item(index);

			indexedAction(index, item);
			yield return item;
		}
	}
	// method: (according to the given boolean:) instead of returning this given enumerable, return a selection of the items in this given enumerable for which invocation of the given indexed action is yielded //
	public static IEnumerable<TItem> imply<TItem>(this IEnumerable<TItem> enumerable, Action<int, TItem> indexedAction, bool boolean = true)
		=> boolean ? enumerable.imply(indexedAction) : enumerable;
	// method: (according to the given boolean:) invoke the given indexed action on each item in this given enumerable, then return this given enumerable //
	public static IEnumerable<TItem> forEach<TItem>(this IEnumerable<TItem> enumerable, Action<int, TItem> indexedAction, bool boolean = true)
	{
		if (boolean)
		{
			for (int index = 0; index < enumerable.count(); index++)
			{
				indexedAction(index, enumerable.item(index));
			}
		}

		return enumerable;
	}
	// method: (according to the given boolean:) invoke the given indexed action on each item in this given enumerable, then return this given enumerable //
	public static IEnumerableT forEach_EnumerableSpecializedViaCasting<IEnumerableT, TItem>(this IEnumerableT enumerable, Action<int, TItem> indexedAction, bool boolean = true) where IEnumerableT : IEnumerable<TItem>
		=> enumerable.after(()=>
			enumerable.castTo<IEnumerable<TItem>>().forEach(indexedAction),
			boolean);
	#endregion acting upon all items - with indexing

	#region acting upon all items - by looping
	public static IEnumerable<TItemThis> implyByLooping<TItemThis, TItemLooped>(this IEnumerable<TItemThis> enumerable, IEnumerable<TItemLooped> enumerableToLoop, Action<TItemThis, TItemLooped> action, bool boolean = true)
		 => enumerable.imply(
			 (index, item) => action(item, enumerableToLoop.item(index % enumerableToLoop.count())),
			 boolean);
	public static IEnumerable<TItemThis> forEachByLooping<TItemThis, TItemLooped>(this IEnumerable<TItemThis> enumerable, IEnumerable<TItemLooped> enumerableToLoop, Action<TItemThis, TItemLooped> action, bool boolean = true)
		 => enumerable.forEach(
			 (index, item) => action(item, enumerableToLoop.item(index % enumerableToLoop.count())),
			 boolean);
	public static IEnumerableT forEachByLooping_EnumerableSpecializedViaCasting<IEnumerableT, TItemThis, TItemLooped>(this IEnumerableT enumerable, IEnumerable<TItemLooped> enumerableToLoop, Action<TItemThis, TItemLooped> action, bool boolean = true) where IEnumerableT : IEnumerable<TItemThis>
		=> enumerable.after(()=>
			enumerable.castTo<IEnumerable<TItemThis>>().forEachByLooping(enumerableToLoop, action),
			boolean);
	#endregion acting upon all items - by looping

	#region acting upon all items - only for which the given function returns true
	// method: (according to the given boolean:) invoke the given action on each item in this given enumerable where the given function returns true, then return this given enumerable //
	public static IEnumerable<TItem> forEachWhere<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, Action<TItem> action, bool boolean = true)
		=> enumerable.after(()=>
			enumerable.forEach(action.predicatedWith(function)),
			boolean);
	#endregion acting upon all items - only for which the given function returns true
	#endregion acting upon all items


	#region acting upon first items

	// method: invoke the given action on the first item in this given enumerable if it has any items, then return this given enumerable //
	public static IEnumerable<TItem> forFirstIfAny<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action)
	{
		if (enumerable.hasAny())
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
	#endregion acting upon first items


	#region randomization

	// method: return a random item in this given enumerable //
	public static TItem randomItem<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.item(RandomlyGenerate.fromZeroUntil(enumerable.count()));

	// method: return a random item in this given enumerable except any of the given items, otherwise (if none remain) a random item in this given enumerable //
	public static TItem randomItemExceptGivenOtherwiseRandomItem<TItem>(this IEnumerable<TItem> enumerable, params TItem[] exceptedItems)
	{
		IEnumerable<TItem> enumerableWhereNotExcepted = enumerable.whereNot(exceptedItems);
		if (enumerableWhereNotExcepted.hasAny())
		{
			return enumerableWhereNotExcepted.randomItem();
		}
		return enumerable.randomItem();
	}
	#endregion randomization


	#region ordering

	public static IEnumerable<TItem> implyAscendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.OrderBy(function);
	public static List<TItem> ascendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.implyAscendingBy(function).manifest();

	public static IEnumerable<TItem> implyAscending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyAscendingBy(item => item);
	public static List<TItem> ascending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyAscending().manifest();

	public static IEnumerable<TItem> implyDescendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.OrderByDescending(function);
	public static List<TItem> descendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.implyDescendingBy(function).manifest();

	public static IEnumerable<TItem> implyDescending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyDescendingBy(item => item);
	public static List<TItem> descending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyDescending().manifest();
	#endregion ordering


	#region extremes

	public static TResult min<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.Min(function);

	public static TResult max<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.Max(function);

	public static TItem minBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.implyAscendingBy(function).first();

	public static TItem maxBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.implyDescendingBy(function).first();
	#endregion extremes


	#region averaging

	public static float average(this IEnumerable<float> enumerable)
		=> enumerable.Average();
	#endregion averaging


	#region casting

	// method: return this given enumerable cast to an IEnumerable of the specified type of item //
	public static IEnumerable<TItem> castToIEnumerable<TItem>(this IEnumerable enumerable)
		=> enumerable.Cast<TItem>();
	#endregion casting
	#endregion methods
}