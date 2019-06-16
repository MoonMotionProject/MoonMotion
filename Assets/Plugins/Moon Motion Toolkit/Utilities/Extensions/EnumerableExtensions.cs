using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Enumerable Extensions: provides extension methods for handling enumerables //
public static class EnumerableExtensions
{
	// methods for: iteration //

	
	// method: invoke the given action on each item in this given enumeration, then return this given enumeration //
	public static IEnumerable<TItem> forEach<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> action)
	{
		foreach (TItem item in enumerable)
		{
			action(item);
		}

		return enumerable;
	}

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