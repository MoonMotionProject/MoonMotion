using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hash Set Extensions: provides extension methods for handling hash sets //
public static class HashSetExtensions
{
	// methods for: determining content //

	// method: return whether this given array is empty //
	public static bool empty<TItem>(this HashSet<TItem> set)
		=> ((ISet<TItem>) set).empty();

	// method: return whether this given array has any elements //
	public static bool any<TItem>(this HashSet<TItem> set)
		=> ((ISet<TItem>) set).any();

	// method: return whether this given array has more than one element //
	public static bool plural<TItem>(this HashSet<TItem> set)
		=> ((ISet<TItem>) set).plural();
}