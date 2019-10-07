using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// IEnumerable Extensions: provides extension methods for handling enumerables //
// #enumerables
public static class IEnumerableExtensions
{
	/*#region copying

	// method: return a copy of this given enumerable //
	public static IEnumerableCustomT copy<IEnumerableCustomT, TItem>(this IEnumerableCustomT enumerable) where IEnumerableCustomT : IEnumerableCustom<TItem>, new()
		=> new IEnumerableT(enumerable);
	#endregion copying*/
	
	
	#region listing

	// method: return the string listing of this given enumerable, using the given separator string (comma by default) //
	public static string asListing<TItem>(this IEnumerable<TItem> enumerable, string separator = Default.listingSeparator)
		=> string.Join(separator, enumerable);
	#endregion listing


	#region determining content

	// method: return the number of items in this given enumerable //
	public static int count<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.Count();

	// method: return the last index in this given enumerable //
	public static int lastIndex<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.hasAny() ? (enumerable.count() - 1) : 0;

	// method: return the number of items in this given enumerable for which the given function returns true //
	public static int count<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function)
		=> enumerable.Count(function);

	// method: return whether this given enumerable is empty //
	public static bool isEmpty<TItem>(this IEnumerable<TItem> enumerable)
		=> (enumerable.count() == 0);

	// method: return whether this given enumerable is empty or null //
	public static bool isEmptyOrNull<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.isEmpty() || enumerable.isNull();

	// method: return whether this given enumerable has any items //
	public static bool hasAny<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.Any();

	// method: return whether this given enumerable has any items for which the given function returns true //
	public static bool hasAny<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function)
		=> enumerable.Any(function);

	// method: return whether this given enumerable has exactly one item //
	public static bool hasExactlyOne<TItem>(this IEnumerable<TItem> enumerable)
		=> (enumerable.count() == 1);

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


	#region defaulting

	// method: if this given enumerable is null, return an empty enumerable of the same type; otherwise, return this given enumerable //
	public static IEnumerable<TItem> emptyIfNull<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.isNull() ? new TItem[] { } : enumerable;
	#endregion defaulting


	#region manifestation

	// method: return a list for this given enumerable with its yieldings manifested //
	public static List<TItem> manifested<TItem>(this IEnumerable<TItem> enumerable)
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

	// method: return the first item in this given enumerable, otherwise (if an item is not there) returning the given fallback item //
	public static TItem firstOtherwise<TItem>(this IEnumerable<TItem> enumerable, TItem fallbackItem)
		=> enumerable.hasAny() ? enumerable.first() : fallbackItem;

	// method: return the first item in this given enumerable, otherwise (if an item is not there) returning the default value of the specified item type //
	public static TItem firstOtherwiseDefault<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.FirstOrDefault();

	// method: return the first struct in this given enumerable as a nullable struct, otherwise (if a struct is not there) returning null //
	public static StructT? firstAsNullableOtherwiseNull<StructT>(this IEnumerable<StructT> enumerable) where StructT : struct
		=> enumerable.hasAny() ? enumerable.first() : default(StructT?);
	#endregion accessing first items


	#region accessing last items

	// method: return the last item in this given enumerable (assuming an item is there) //
	public static TItem last<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.Last();

	// method: return the last item in this given enumerable, otherwise (if an item is not there) returning the given fallback item //
	public static TItem lastOtherwise<TItem>(this IEnumerable<TItem> enumerable, TItem fallbackItem)
		=> enumerable.hasAny() ? enumerable.last() : fallbackItem;

	// method: return the last item in this given enumerable, otherwise (if an item is not there) returning the default value of the specified item type //
	public static TItem lastOtherwiseDefault<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.LastOrDefault();
	#endregion accessing last items


	#region retrieval

	public static IEnumerable<TResult> select<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.Select(function);
	public static List<TResult> pick<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.select(function).manifested();
	
	public static HashSet<TResult> pickUnique<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.select(function).toSet();

	public static IEnumerable<TResult> selectByLooping<TItemThis, TItemLooped, TResult>(this IEnumerable<TItemThis> enumerable, IEnumerable<TItemLooped> enumerableToLoop, Func<TItemThis, TItemLooped, TResult> function)
		 =>	Select.forCount(enumerable.count(), index =>
				function(enumerable.item(index), enumerableToLoop.item(index % enumerableToLoop.count())));
	public static List<TResult> pickByLooping<TItemThis, TItemLooped, TResult>(this IEnumerable<TItemThis> enumerable, IEnumerable<TItemLooped> enumerableToLoop, Func<TItemThis, TItemLooped, TResult> function)
		 => enumerable.selectByLooping(enumerableToLoop, function).manifested();

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
	#endregion retrieval


	#region removing

	// method: (according to the given boolean:) instead of returning this given enumerable, return a selection of the items in this given enumerable for which the given function returns true //
	public static IEnumerable<TItem> only<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=> boolean ? enumerable.Where(function) : enumerable;
	// method: (according to the given boolean:) instead of returning a list for this given enumerable, return a list of the items in this given enumerable for which the given function returns true //
	public static List<TItem> where<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=> enumerable.only(function, boolean).manifested();

	// method: (according to the given boolean:) instead of returning this given enumerable, return a selection of the items in this given enumerable for which the given function returns false //
	public static IEnumerable<TItem> except<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=>	enumerable.only(
				function.negated(),
				boolean);
	// method: (according to the given boolean:) instead of returning a list for this given enumerable, return a list of the items in this given enumerable for which the given function returns false //
	public static List<TItem> whereNot<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=> enumerable.except(function, boolean).manifested();

	// method: (according to the given boolean:) instead of returning this given enumerable, return a selection of the items in this given enumerable which are yull //
	public static IEnumerable<TItem> onlyYull<TItem>(this IEnumerable<TItem> enumerable, bool boolean = true)
		=> enumerable.only(
			item => item.isYull(),
			boolean);

	// method: (according to the given boolean:) instead of returning this given enumerable, return a list of the items in this given enumerable which are yull //
	public static List<TItem> whereYull<TItem>(this IEnumerable<TItem> enumerable, bool boolean = true)
		=> enumerable.onlyYull().manifested();

	// method: (according to the given boolean:) instead of returning this given enumerable, return the set of the items in this given enumerable which are yull //
	public static HashSet<TItem> uniqueYulls<TItem>(this IEnumerable<TItem> enumerable, bool boolean = true)
		=> enumerable.onlyYull().manifested().toSet();

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
	public static List<TItem> whereNot<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable, bool boolean = true)
		=> enumerable.except(otherEnumerable, boolean).manifested();
	// method: instead of returning this given enumerable, return a selection of the items in this given enumerable which are not equal to any of the given items //
	public static IEnumerable<TItem> except<TItem>(this IEnumerable<TItem> enumerable, params TItem[] items)
		=> enumerable.except(
			item_ => items.hasAny(otherItem => item_.baselineEquals(otherItem)));
	// method: instead of returning a list for this given enumerable, return a list of the items in this given enumerable which are not equal to any of the given items //
	public static List<TItem> whereNot<TItem>(this IEnumerable<TItem> enumerable, params TItem[] items)
		=> enumerable.except(items).manifested();
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
	// method: (according to the given boolean:) invoke the given action on each item in this given enumerable, then return th manifestation of this given enumerable //
	public static List<TItem> forEachManifested<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action, bool boolean = true)
		=> enumerable.forEach(action, boolean).manifested();
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

	// method: return a random item in this given enumerable if it has any items; otherwise, return the default value of the given item type //
	public static TItem randomItem<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.hasAny() ? enumerable.item(RandomlyGenerate.fromZeroUntil(enumerable.count())) : default(TItem);

	// method: return a random item in this given enumerable except any of the given items, otherwise (if none remain) a random item in this given enumerable //
	public static TItem randomItemExceptGivenOtherwiseRandomItem<TItem>(this IEnumerable<TItem> enumerable, params TItem[] exceptedItems)
	{
		IEnumerable<TItem> enumerableWhereNotExcepted = enumerable.whereNot(exceptedItems);

		return	(enumerableWhereNotExcepted.hasAny() ?
					enumerableWhereNotExcepted.randomItem() :
					enumerable.randomItem()
				);
	}
	#endregion randomization


	#region ordering

	public static IEnumerable<TItem> implyAscendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.OrderBy(function);
	public static List<TItem> ascendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.implyAscendingBy(function).manifested();

	public static IEnumerable<TItem> implyAscending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyAscendingBy(item => item);
	public static List<TItem> ascending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyAscending().manifested();

	public static IEnumerable<TItem> implyDescendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.OrderByDescending(function);
	public static List<TItem> descendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.implyDescendingBy(function).manifested();

	public static IEnumerable<TItem> implyDescending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyDescendingBy(item => item);
	public static List<TItem> descending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyDescending().manifested();
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


	#region conversion

	// method: return a new enumerable containing only this given item //
	public static IEnumerable<TItem> startEnumerable<TItem>(this TItem item)
		=> new TItem[] {item};

	// method: return this given enumerable as an enumerable of its type of item (effectively generalizing it to an enumerable of those items if it was passed as something more specific, such as a list of those items) //
	public static IEnumerable<TItem> asEnumerable<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable;

	// method: return this given enumerable converted to a set (maintaining only unique items) //
	public static HashSet<TItem> toSet<TItem>(this IEnumerable<TItem> enumerable)
		=> new HashSet<TItem>(enumerable);

	// method: return a selection of those structs in this given enumerable as nullable structs //
	public static IEnumerable<TItem?> implyEachAsNullable<TItem>(this IEnumerable<TItem> enumerable) where TItem : struct
		=> enumerable.select(item => item.toNullable());
	// method: return a list of those structs in this given enumerable as nullable structs //
	public static List<TItem?> eachAsNullable<TItem>(this IEnumerable<TItem> enumerable) where TItem : struct
		=> enumerable.implyEachAsNullable().manifested();
	// method: return the set of those structs in this given enumerable as nullable structs //
	public static HashSet<TItem?> toSetOfNullables<TItem>(this IEnumerable<TItem> enumerable) where TItem : struct
		=> enumerable.eachAsNullable().toSet();

	// method: return this given enumerable converted to an array //
	public static TItem[] toArray<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.ToArray();
	#endregion conversion
}