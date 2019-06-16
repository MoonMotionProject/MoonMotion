using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Array Extensions: provides extension methods for handling arrays //
public static class ArrayExtensions
{
	// methods for: determining content //
	
	// method: return whether this given array is empty //
	public static bool empty(this Array array)
		=> (array.Length == 0);

	// method: return whether this given array has any elements //
	public static bool any(this Array array)
		=> (array.Length > 0);

	// method: return whether this given array has more than one element //
	public static bool plural(this Array array)
		=> (array.Length > 1);


	// methods for: listing //

	// method: return the string listing of this given array, using the given separator string (comma by default) //
	public static string asListing<TArrayElement>(this Array array, string separator = ",")
		=> (new List<TArrayElement>((TArrayElement[]) array)).asListing<TArrayElement>();

	// method: return the string listing of these given strings, using the given separator string (comma by default) //
	public static string asListing(this string[] strings, string separator = ",")
		=> strings.asListing<string>();

	// method: return the string listing of these given booleans, using the given separator string (comma by default) //
	public static string asListing(this bool[] booleans, string separator = ",")
		=> booleans.asListing<bool>();

	// method: return the string listing of these given floats, using the given separator string (comma by default) //
	public static string asListing(this float[] floats, string separator = ",")
		=> floats.asListing<float>();

	// method: return the string listing of these given integers, using the given separator string (comma by default) //
	public static string asListing(this int[] integers, string separator = ",")
		=> integers.asListing<int>();

	// method: return the string listing of these given doubles, using the given separator string (comma by default) //
	public static string asListing(this double[] doubles, string separator = ",")
		=> doubles.asListing<double>();
}