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
	{
		if (enumerable.isNull())
		{
			return "[null listing]";
		}
		if (enumerable.isEmpty())
		{
			return "[empty listing]";
		}
		string listing = string.Join(separator, enumerable);
		if (listing.isNull())
		{
			return "[listing error]".returnWithError("asListing encountered an unexpected error in creating listing string");
		}
		return listing;
	}
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
		=> enumerable.isNull() || enumerable.isEmpty();

	// method: return whether this given enumerable is yull and not empty //
	public static bool isYullAndNotEmpty<TItem>(this IEnumerable<TItem> enumerable)
		=> !isEmptyOrNull(enumerable);

	// method: return whether this given enumerable has any items //
	public static bool hasAny<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.Any();

	// method: return whether this given enumerable has any items for which the given function returns true //
	public static bool hasAny<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function)
		=> enumerable.Any(function);

	// method: return whether this given enumerable of booleans any booleans that are true //
	public static bool hasAnyTrue(this IEnumerable<bool> enumerable)
		=> enumerable.hasAny(boolean => boolean);

	// method: return whether this given enumerable has any items for which the given function returns true after picking (after ensuring that the function has run on all items) //
	public static bool hasAnyAfterPicking<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function)
		=> enumerable.pick(function).hasAnyTrue();

	// method: return whether this given enumerable has any items of the specified target type //
	public static bool hasAny<TTarget>(this IEnumerable enumerable)
		=> enumerable.only<TTarget>().hasAny();

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

	// method: return this given enumerable manifested (return a list for this given enumerable with its yieldings manifested) //
	public static List<TItem> manifested<TItem>(this IEnumerable<TItem> enumerable)
		=> New.listOf(enumerable);

	// method: return this given enumerable manifested after executing the given action if the given boolean is true //
	public static List<TItem> manifestedAfter<TItem>(this IEnumerable<TItem> enumerable, Action action, bool boolean = true)
		=>	enumerable.after(action, boolean).manifested();
	// method: return this given enumerable manifested after executing the given action on this given enumerable if the given boolean is true //
	public static List<TItem> manifestedAfter<TItem>(this IEnumerable<TItem> enumerable, Action<IEnumerable<TItem>> action, bool boolean = true)
		=>	enumerable.after(action, boolean).manifested();
	#endregion manifestation


	#region accessing items by index

	// method: return the item at the given index in this given enumerable (assuming an item is there), otherwise returning the default of the specified item type and silencing the argument out of range exception according to the given boolean //
	public static TItem item<TItem>(this IEnumerable<TItem> enumerable, int index, bool silenceArgumentOutOfRangeException = Default.errorSilencing)
	{
		try
		{
			return enumerable.ElementAt(index);
		}
		catch (ArgumentOutOfRangeException)
		{
			if (!silenceArgumentOutOfRangeException)
			{
				"IEnumerableExtensions.item given index outside of the range of the given this enumerable".printAsErrorAndReturnDefault<TItem>();
			}
			return default(TItem);
		}
	}

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


	#region accessing nonfirst items

	// method: return an accessor for the nonfirst items in this given enumerable (assuming a first item is there) //
	public static IEnumerable<TItem> accessNonfirsts<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.except(enumerable.first());
	// method: return the list of the nonfirst items in this given enumerable (assuming a first item is there) //
	public static List<TItem> nonfirsts<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.accessNonfirsts().manifested();
	// method: return the set of the unique nonfirst items in this given enumerable (assuming a first item is there) //
	public static HashSet<TItem> uniqueNonfirsts<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.accessNonfirsts().uniques();
	#endregion accessing nonfirst items


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


	#region accessing first item of type

	// method: return the first item in this given enumerable that has the specified target type (assuming such an item is there) //
	public static TTarget first<TTarget>(this IEnumerable enumerable)
		=> enumerable.only<TTarget>().first();

	// method: return the first item in this given enumerable that has the specified target type, otherwise (if such an item is not there) returning the given fallback item //
	public static TTarget firstOtherwise<TTarget>(this IEnumerable enumerable, TTarget fallbackItem)
		=> enumerable.hasAny<TTarget>() ? enumerable.first<TTarget>() : fallbackItem;

	// method: return the first item in this given enumerable that has the specified target type, otherwise (if such an item is not there) returning the default value of the specified target type //
	public static TTarget firstOtherwiseDefault<TTarget>(this IEnumerable enumerable)
		=> enumerable.only<TTarget>().FirstOrDefault();
	#endregion accessing first item of type


	#region randomization

	// method: return a random item in this given enumerable if it has any items; otherwise, return the default value of the given item type //
	public static TItem randomItem<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.hasAny() ? enumerable.item(RandomlyGenerate.fromZeroUntil(enumerable.count())) : default(TItem);

	// method: return a random item in this given enumerable except any of the given items, otherwise (if none remain) a random item in this given enumerable //
	public static TItem randomItemExceptGivenOtherwiseRandomItem<TItem>(this IEnumerable<TItem> enumerable, params TItem[] exceptedItems)
	{
		IEnumerable<TItem> enumerableWhereNotExcepted = enumerable.whereNotIn(exceptedItems);

		return	(enumerableWhereNotExcepted.hasAny() ?
					enumerableWhereNotExcepted.randomItem() :
					enumerable.randomItem()
				);
	}
	#endregion randomization


	#region extremes

	public static TItem min<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.Min();

	public static TItem max<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.Max();

	public static TResult min<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.Min(function);

	public static TResult max<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.Max(function);

	public static TItem minProviderOtherwiseDefault<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.implyAscendingBy(function).firstOtherwiseDefault();

	public static TItem maxProviderOtherwiseDefault<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.implyDescendingBy(function).firstOtherwiseDefault();
	#endregion extremes


	#region averaging

	public static float average(this IEnumerable<float> enumerable)
		=> enumerable.Average();
	#endregion averaging


	#region retrieval

	public static IEnumerable<TResult> access<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.Select(function);
	public static List<TResult> pick<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.access(function).manifested();
	
	public static IEnumerable<TTargetItem> access<TTargetItem>(this IEnumerable enumerable)
	{
		foreach (object item in enumerable)
		{
			if (item is TTargetItem)
			{
				yield return item.castTo<TTargetItem>();
			}
		}
	}
	public static List<TTargetItem> pick<TTargetItem>(this IEnumerable enumerable)
		=> enumerable.access<TTargetItem>().manifested();
	
	public static HashSet<TResult> pickUnique<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.access(function).uniques();
	
	public static IEnumerable<TResult> accessOnlyYull<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.access(function).onlyYull();

	public static IEnumerable<TResult> accessByLooping<TItemThis, TItemLooped, TResult>(this IEnumerable<TItemThis> enumerable, IEnumerable<TItemLooped> enumerableToLoop, Func<TItemThis, TItemLooped, TResult> function)
		 =>	Access.forCount(enumerable.count(), index =>
				function(enumerable.item(index), enumerableToLoop.item(index % enumerableToLoop.count())));
	public static List<TResult> pickByLooping<TItemThis, TItemLooped, TResult>(this IEnumerable<TItemThis> enumerable, IEnumerable<TItemLooped> enumerableToLoop, Func<TItemThis, TItemLooped, TResult> function)
		 => enumerable.accessByLooping(enumerableToLoop, function).manifested();

	public static IEnumerable<TResult> accessFromOnly<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, bool> functionOnly, Func<TItem, TResult> functionSelect)
		=> enumerable.only(functionOnly).access(functionSelect);

	public static IEnumerable<TResult> accessFromYull<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.accessFromOnly(
				item => item.isYull(),
				function);

	public static IEnumerable<TResult> accessFromNull<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.accessFromOnly(
				item => item.isNull(),
				function);

	public static List<TResult> pickFromOnly<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, bool> onlyFunction, Func<TItem, TResult> pickFunction)
		=> enumerable.only(onlyFunction).pick(pickFunction);
	
	public static IEnumerable<TItem> yullsFromOnly<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function)
		=> enumerable.only(function).onlyYull();
	public static List<TItem> yullsWhere<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function)
		=> enumerable.yullsFromOnly(function).manifested();
	
	public static IEnumerable<TResult> accessYullsFrom<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.access(function).onlyYull();
	public static List<TResult> pickYullsFrom<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function)
		=> enumerable.accessYullsFrom(function).manifested();
	
	public static TResult pickUponFirstIfAny<TTarget, TResult>(this IEnumerable enumerable, Func<TTarget, TResult> function, Func<TResult> fallbackFunction)
	{
		if (fallbackFunction.isNull())
		{
			return default(TResult).returnWithError("given null fallback function");
		}

		if (enumerable.hasAny<TTarget>())
		{
			return function(enumerable.first<TTarget>());
		}
		else
		{
			return fallbackFunction();
		}
	}

	public static IEnumerable<TResult> accessNested<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, IEnumerable<TResult>> function)
		=> enumerable.SelectMany(function);
	public static List<TResult> pickNested<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, IEnumerable<TResult>> function)
		=> enumerable.accessNested(function).manifested();
	public static HashSet<TResult> pickUniqueNested<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, IEnumerable<TResult>> function)
		=> enumerable.accessNested(function).uniques();
	
	private static List<TItem> recursivelyPick_NonlastRecursion<TItem>(this IEnumerable<TItem> enumerable, Func<IEnumerable<TItem>, IEnumerable<TItem>> function)
		=> function(enumerable).recursivelyPick_NonlastRecursion(function);
	public static List<TItem> recursivelyPick<TItem>(this IEnumerable<TItem> enumerable, Func<IEnumerable<TItem>, IEnumerable<TItem>> function)
		=> function(enumerable).recursivelyPick_NonlastRecursion(function).manifested();
	#endregion retrieval


	#region summing

	// method: return the sum for adding the result of the given function upon each item in this given enumerable //
	public static float sumByPicking<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, float> function)
	{
		float sum = 0f;
		enumerable.forEach(item => sum += function(item));
		return sum;
	}
	#endregion summing


	#region acting upon all items

	#region acting upon all items - without indexing
	// method: return an accessor for the items in this given enumerable for which invocation of the given action is yielded //
	private static IEnumerable<TItem> implyForEach<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action)
	{
		foreach (TItem item in enumerable)
		{
			action(item);
			yield return item;
		}
	}
	// method: (according to the given boolean:) instead of returning this given enumerable, return an accessor for the items in this given enumerable for which invocation of the given action is yielded //
	public static IEnumerable<TItem> implyForEach<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action, bool boolean = true)
		=> boolean ? enumerable.implyForEach(action) : enumerable;
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
	// method: (according to the given boolean:) invoke the given action on each item in this given enumerable, then return the manifestation of this given enumerable //
	public static List<TItem> forEachManifested<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action, bool boolean = true)
		=> enumerable.forEach(action, boolean).manifested();
	// method: (according to the given boolean:) invoke the given action on each item in this given enumerable, then return the set of (unique) items in this given enumerable //
	public static HashSet<TItem> uniquesAfterForEach<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action, bool boolean = true)
		=> enumerable.forEach(action, boolean).uniques();
	// method: (according to the given boolean:) invoke the given action on each unique item in this given enumerable, then return the set of (unique) items in this given enumerable //
	public static HashSet<TItem> forEachUnique<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action, bool boolean = true)
		=> enumerable.uniques().uniquesAfterForEach(action, boolean);
	// method: (according to the given boolean:) invoke the given action on each item in this given enumerable, then return this given enumerable //
	public static IEnumerableT forEach_EnumerableSpecializedViaCasting<IEnumerableT, TItem>(this IEnumerableT enumerable, Action<TItem> action, bool boolean = true) where IEnumerableT : IEnumerable<TItem>
		=>	enumerable.returnAnd(()=>
				enumerable.castTo<IEnumerable<TItem>>().forEach(action),
				boolean);
	#endregion acting upon all items - without indexing

	#region acting upon all items - with indexing
	// method: return an accessor for the items in this given enumerable for which invocation of the given indexed action is yielded //
	private static IEnumerable<TItem> implyForEach<TItem>(this IEnumerable<TItem> enumerable, Action<int, TItem> indexedAction)
	{
		for (int index = 0; index < enumerable.count(); index++)
		{
			TItem item = enumerable.item(index);

			indexedAction(index, item);
			yield return item;
		}
	}
	// method: (according to the given boolean:) instead of returning this given enumerable, return an accessor for the items in this given enumerable for which invocation of the given indexed action is yielded //
	public static IEnumerable<TItem> implyForEach<TItem>(this IEnumerable<TItem> enumerable, Action<int, TItem> indexedAction, bool boolean = true)
		=> boolean ? enumerable.implyForEach(indexedAction) : enumerable;
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
		=>	enumerable.returnAnd(()=>
				enumerable.castTo<IEnumerable<TItem>>().forEach(indexedAction),
				boolean);
	#endregion acting upon all items - with indexing

	#region acting upon all items - by looping
	public static IEnumerable<TItemThis> implyForEachByLooping<TItemThis, TItemLooped>(this IEnumerable<TItemThis> enumerable, IEnumerable<TItemLooped> enumerableToLoop, Action<TItemThis, TItemLooped> action, bool boolean = true)
		 => enumerable.implyForEach(
			 (index, item) => action(item, enumerableToLoop.item(index % enumerableToLoop.count())),
			 boolean);
	public static IEnumerable<TItemThis> forEachByLooping<TItemThis, TItemLooped>(this IEnumerable<TItemThis> enumerable, IEnumerable<TItemLooped> enumerableToLoop, Action<TItemThis, TItemLooped> action, bool boolean = true)
		 => enumerable.forEach(
			 (index, item) => action(item, enumerableToLoop.item(index % enumerableToLoop.count())),
			 boolean);
	public static IEnumerableT forEachByLooping_EnumerableSpecializedViaCasting<IEnumerableT, TItemThis, TItemLooped>(this IEnumerableT enumerable, IEnumerable<TItemLooped> enumerableToLoop, Action<TItemThis, TItemLooped> action, bool boolean = true) where IEnumerableT : IEnumerable<TItemThis>
		=>	enumerable.returnAnd(()=>
				enumerable.castTo<IEnumerable<TItemThis>>()
					.forEachByLooping(enumerableToLoop, action),
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


	#region acting upon first item of type

	// method: invoke the given action on the first item in this given enumerable that has the specified target type – if it has any such items; otherwise, execute the given fallback action if it is not given as the default of null //
	public static void forFirstIfAny<TTarget>(this IEnumerable enumerable, Action<TTarget> action, Action fallbackAction = null)
	{
		if (enumerable.hasAny<TTarget>())
		{
			action(enumerable.first<TTarget>());
		}
		else if (fallbackAction.isYull())
		{
			fallbackAction();
		}
	}
	#endregion acting upon first item of type


	#region acting upon first item where

	public static List<TItem> actUponFirstIfAnyWhere<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, Action<TItem> action, Action fallbackAction = null)
	{
		if (enumerable.hasAny(function))
		{
			action(enumerable.firstWhere(function));
		}
		else if (fallbackAction.isYull())
		{
			fallbackAction();
		}
		return enumerable.manifested();
	}
	#endregion acting upon first item where


	#region ordering

	public static IEnumerable<TItem> implyAscendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
	{
		try
		{
			return enumerable.OrderBy(function);
		}
		catch (Exception exception)
		{
			return exception.logAsErrorAndReturn(enumerable, "implyAscendingBy encountered an exception, probably when using the function parameter is was given (so check if the given function parameter is causing the exception)");
		}
	}
	public static List<TItem> ascendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.implyAscendingBy(function).manifested();

	public static IEnumerable<TItem> implyAscending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyAscendingBy(item => item);
	public static List<TItem> ascending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyAscending().manifested();

	public static IEnumerable<TItem> implyDescendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
	{
		try
		{
			return enumerable.OrderByDescending(function);
		}
		catch (Exception exception)
		{
			return exception.logAsErrorAndReturn(enumerable, "implyDescendingBy encountered an exception, probably when using the function parameter is was given (so check if the given function parameter is causing the exception)");
		}
	}
	public static List<TItem> descendingBy<TItem, TResult>(this IEnumerable<TItem> enumerable, Func<TItem, TResult> function) where TResult : IComparable
		=> enumerable.implyDescendingBy(function).manifested();

	public static IEnumerable<TItem> implyDescending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyDescendingBy(item => item);
	public static List<TItem> descending<TItem>(this IEnumerable<TItem> enumerable) where TItem : IComparable
		=> enumerable.implyDescending().manifested();

	public static IEnumerable<TItem> implyReversed<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.Reverse();
	public static List<TItem> reversed<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.implyReversed().manifested();
	#endregion ordering


	#region union

	// method: (according to the given boolean:) return an accessor for the unique items across this given enumerable and the other given enumerable //
	public static IEnumerable<TItem> onlyUniquesInUnionWith<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable, bool boolean = true)
		=> boolean ? enumerable.Union(otherEnumerable) : enumerable;

	// method: (according to the given boolean:) return the set of (unique) items across this given enumerable and the other given enumerable //
	public static HashSet<TItem> pickUniquesInUnionWith<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable, bool boolean = true)
		=> enumerable.onlyUniquesInUnionWith(otherEnumerable).uniques();

	// method: (according to the given boolean:) return the list of (unique) items across this given enumerable and the other given enumerable //
	public static List<TItem> pickUniquesAsListInUnionWith<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable, bool boolean = true)
		=> enumerable.onlyUniquesInUnionWith(otherEnumerable).manifested();
	// method: return the list of (unique) items across this given enumerable and each of the other given enumerables //
	public static List<TItem> pickUniquesAsListInUnionWith<TItem>(this IEnumerable<TItem> enumerable, params IEnumerable<TItem>[] otherEnumerables)
	{
		List<TItem> list = enumerable.manifested();

		otherEnumerables.forEach(otherEnumerable =>
			list = list.pickUniquesAsListInUnionWith(otherEnumerable));

		return list;
	}
	#endregion including


	#region adding
	
	// method: return the concatenation of the other given enumerable onto this given enumerable, where null is treated as empty according to the given 'nullsAsEmpty' boolean //
	public static IEnumerable<TItem> with<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable, bool nullsAsEmpty = Default.nullsAsEmpty)
		=>	nullsAsEmpty ?
				(enumerable ?? Enumerable.Empty<TItem>()).Concat(otherEnumerable ?? Enumerable.Empty<TItem>()) :
				enumerable.Concat(otherEnumerable);
	// method: return the manifestation (list form) of the concatenation of the other given enumerable onto this given enumerable, where null is treated as empty according to the given 'nullsAsEmpty' boolean //
	public static List<TItem> manifestedWith<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable, bool nullsAsEmpty = Default.nullsAsEmpty)
		=> enumerable.with(otherEnumerable, nullsAsEmpty).manifested();
	// method: return the set of (uniques in) the concatenation of the other given enumerable onto this given enumerable, where null is treated as empty according to the given 'nullsAsEmpty' boolean //
	public static HashSet<TItem> setWith<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable, bool nullsAsEmpty = Default.nullsAsEmpty)
		=> enumerable.with(otherEnumerable, nullsAsEmpty).uniques();
	public static IEnumerable<TItem> with<TItem>(this IEnumerable<TItem> enumerable, TItem item, bool nullsAsEmpty = Default.nullsAsEmpty)
		=> enumerable.with(new TItem[] {item}, nullsAsEmpty);
	public static List<TItem> manifestedWith<TItem>(this IEnumerable<TItem> enumerable, TItem otherItem, bool nullsAsEmpty = Default.nullsAsEmpty)
		=> enumerable.with(otherItem, nullsAsEmpty).manifested();
	public static HashSet<TItem> setWith<TItem>(this IEnumerable<TItem> enumerable, TItem otherItem, bool nullsAsEmpty = Default.nullsAsEmpty)
		=> enumerable.with(otherItem, nullsAsEmpty).uniques();
	public static IEnumerable<TItem> with<TItem>(this TItem item, IEnumerable<TItem> enumerable, bool nullsAsEmpty = Default.nullsAsEmpty)
		=> enumerable.with(item, nullsAsEmpty);
	
	// method: return the concatenation of the other given enumerables onto this given enumerable, where null is treated as empty according to the given 'nullsAsEmpty' boolean //
	public static IEnumerable<TItem> with<TItem>(this IEnumerable<TItem> enumerable, bool nullsAsEmpty = Default.nullsAsEmpty, params IEnumerable<TItem>[] otherEnumerables)
	{
		IEnumerable<TItem> concatenation = enumerable;
		otherEnumerables.forEach(otherEnumerable =>
			concatenation = concatenation.with(otherEnumerable));
		return concatenation;
	}
	// method: return the manifestation (list form) of the concatenation of the other given enumerables onto this given enumerable, where null is treated as empty according to the given 'nullsAsEmpty' boolean //
	public static List<TItem> manifestedWith<TItem>(this IEnumerable<TItem> enumerable, bool nullsAsEmpty = Default.nullsAsEmpty, params IEnumerable<TItem>[] otherEnumerables)
		=> enumerable.with(nullsAsEmpty, otherEnumerables).manifested();
	// method: return the set of (uniques in) the concatenation of the other given enumerables onto this given enumerable, where null is treated as empty according to the given 'nullsAsEmpty' boolean //
	public static HashSet<TItem> setWith<TItem>(this IEnumerable<TItem> enumerable, bool nullsAsEmpty = Default.nullsAsEmpty, params IEnumerable<TItem>[] otherEnumerables)
		=> enumerable.with(nullsAsEmpty, otherEnumerables).uniques();
	#endregion adding


	#region removing

	// method: (according to the given boolean:) instead of returning this given enumerable, return an accessor for the items in this given enumerable for which the given function returns true //
	public static IEnumerable<TItem> only<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=> boolean ? enumerable.Where(function) : enumerable;
	// method: (according to the given boolean:) instead of returning a list for this given enumerable, return a list of the items in this given enumerable for which the given function returns true //
	public static List<TItem> where<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=> enumerable.only(function, boolean).manifested();
	public static HashSet<TItem> uniquesWhere<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=> enumerable.only(function, boolean).uniques();

	// method: (according to the given boolean:) instead of returning this given enumerable, return an accessor for the items in this given enumerable for which the given function returns false //
	public static IEnumerable<TItem> except<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=>	enumerable.only(
				function.negated(),
				boolean);
	// method: (according to the given boolean:) instead of returning a list for this given enumerable, return a list of the items in this given enumerable for which the given function returns false //
	public static List<TItem> whereNot<TItem>(this IEnumerable<TItem> enumerable, Func<TItem, bool> function, bool boolean = true)
		=> enumerable.except(function, boolean).manifested();

	// method: (according to the given boolean:) instead of returning this given enumerable, return an accessor for the items in this given enumerable which are yull //
	public static IEnumerable<TItem> onlyYull<TItem>(this IEnumerable<TItem> enumerable, bool boolean = true)
		=> enumerable.only(
			item => item.isYull(),
			boolean);

	// method: (according to the given boolean:) instead of returning this given enumerable, return a list of the items in this given enumerable which are yull //
	public static List<TItem> whereYull<TItem>(this IEnumerable<TItem> enumerable, bool boolean = true)
		=> enumerable.onlyYull().manifested();

	// method: (according to the given boolean:) instead of returning this given enumerable, return the set of the items in this given enumerable which are yull //
	public static HashSet<TItem> uniqueYulls<TItem>(this IEnumerable<TItem> enumerable, bool boolean = true)
		=> enumerable.onlyYull().manifested().uniques();

	// method: (according to the given boolean:) instead of returning this given enumerable, return an accessor for the items in this given enumerable which are equal to the given item //
	public static IEnumerable<TItem> only<TItem>(this IEnumerable<TItem> enumerable, TItem item, bool boolean = true)
		=> enumerable.only(
			item_ => item_.baselineEquals(item),
			boolean);

	// method: (according to the given boolean:) instead of returning this given enumerable, return an accessor for the items in this given enumerable which are not equal to the given item //
	public static IEnumerable<TItem> except<TItem>(this IEnumerable<TItem> enumerable, TItem item, bool boolean = true)
		=> enumerable.except(
			item_ => item_.baselineEquals(item),
			boolean);

	// method: (according to the given boolean:) instead of returning this given enumerable, return an accessor for the items in this given enumerable which are not equal to any of the items in the other given enumerable //
	public static IEnumerable<TItem> except<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable, bool boolean = true)
		=> enumerable.except(
			item_ => otherEnumerable.hasAny(otherItem => item_.baselineEquals(otherItem)),
			boolean);
	// method: (according to the given boolean:) instead of returning a list for this given enumerable, return a list of the items in this given enumerable which are not equal to any of the items in the other given enumerable //
	public static List<TItem> whereNotIn<TItem>(this IEnumerable<TItem> enumerable, IEnumerable<TItem> otherEnumerable, bool boolean = true)
		=> enumerable.except(otherEnumerable, boolean).manifested();
	// method: instead of returning this given enumerable, return an accessor for the items in this given enumerable which are not equal to any of the given items //
	public static IEnumerable<TItem> except<TItem>(this IEnumerable<TItem> enumerable, params TItem[] items)
		=> enumerable.except(
			item_ => items.hasAny(otherItem => item_.baselineEquals(otherItem)));
	// method: instead of returning a list for this given enumerable, return a list of the items in this given enumerable which are not equal to any of the given items //
	public static List<TItem> whereNotIn<TItem>(this IEnumerable<TItem> enumerable, params TItem[] items)
		=> enumerable.except(items).manifested();

	// method: instead of returning this given enumerable, return an accessor for the items in this given enumerable which are of the specified target type //
	public static IEnumerable<TTarget> only<TTarget>(this IEnumerable enumerable)
		=> enumerable.OfType<TTarget>();
	// method: instead of returning this given enumerable, return a list of the items in this given enumerable which are of the specified target type //
	public static List<TTarget> where<TTarget>(this IEnumerable enumerable)
		=> enumerable.only<TTarget>().manifested();
	#endregion removing


	#region conversion

	// method: return a new enumerable containing only this given item //
	public static IEnumerable<TItem> startEnumerable<TItem>(this TItem item)
		=> new TItem[] {item};

	// method: return this given enumerable as an enumerable of its type of item (effectively generalizing it to an enumerable of those items if it was passed as something more specific, such as a list of those items) //
	public static IEnumerable<TItem> asEnumerable<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable;

	// method: return this given enumerable converted to a set (maintaining only unique items) //
	public static HashSet<TItem> uniques<TItem>(this IEnumerable<TItem> enumerable)
		=> New.setOf(enumerable);
	// method: return a list of the unique items in this given enumerable //
	public static List<TItem> manifestedUniques<TItem>(this IEnumerable<TItem> enumerable)
		=> enumerable.uniques().manifested();

	// method: return an accessor for those structs in this given enumerable as nullable structs //
	public static IEnumerable<TItem?> implyEachAsNullable<TItem>(this IEnumerable<TItem> enumerable) where TItem : struct
		=> enumerable.access(item => item.toNullable());
	// method: return a list of those structs in this given enumerable as nullable structs //
	public static List<TItem?> eachAsNullable<TItem>(this IEnumerable<TItem> enumerable) where TItem : struct
		=> enumerable.implyEachAsNullable().manifested();
	// method: return the set of those structs in this given enumerable as nullable structs //
	public static HashSet<TItem?> toSetOfNullables<TItem>(this IEnumerable<TItem> enumerable) where TItem : struct
		=> enumerable.eachAsNullable().uniques();

	// method: return this given enumerable converted to an array //
	public static TItem[] toArray<TItem>(this IEnumerable<TItem> enumerable)
		=> New.arrayOf(enumerable);
	#endregion conversion
}