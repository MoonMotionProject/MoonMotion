using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IComparableExtensions: provides extension methods for handling IComparables //
public static class IComparableExtensions
{
	public static bool isWithin<IComparableT>(this IComparableT thisComparable, IComparableT lowerComparable, IComparableT upperComparable) where IComparableT : IComparable
		=> thisComparable.CompareTo(lowerComparable) >= 0 && thisComparable.CompareTo(upperComparable) <= 0;

	public static bool isFromUntil<IComparableT>(this IComparableT thisComparable, IComparableT lowerComparable, IComparableT upperComparable) where IComparableT : IComparable
		=> thisComparable.CompareTo(lowerComparable) >= 0 && thisComparable.CompareTo(upperComparable) < 0;

	public static bool isAfterTo<IComparableT>(this IComparableT thisComparable, IComparableT lowerComparable, IComparableT upperComparable) where IComparableT : IComparable
		=> thisComparable.CompareTo(lowerComparable) > 0 && thisComparable.CompareTo(upperComparable) <= 0;

	public static bool isBetween<IComparableT>(this IComparableT thisComparable, IComparableT lowerComparable, IComparableT upperComparable) where IComparableT : IComparable
		=> thisComparable.CompareTo(lowerComparable) > 0 && thisComparable.CompareTo(upperComparable) < 0;
}