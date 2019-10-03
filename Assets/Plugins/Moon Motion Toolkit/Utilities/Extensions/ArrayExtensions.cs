using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Array Extensions: provides extension methods for handling arrays //
// #enumerables
public static class ArrayExtensions
{
	#region reversing

	// method: return this given array reversed //
	public static TItem[] reversed<TItem>(this TItem[] array)
	{
		Array.Reverse(array);
		return array;
	}
	#endregion reversing


	#region acting upon all items

	// method: (according to the given boolean:) invoke the given action on each item in this given array, then return this given array //
	public static TItem[] forEach<TItem>(this TItem[] array, Action<TItem> action, bool boolean = true)
		=> array.forEach_EnumerableSpecializedViaCasting(action, boolean);

	// method: (according to the given boolean:) invoke the given action for each item in this given array as a 2D array using the given width and height upon the respective x and y, then return this given array //
	public static TItem[] forEachAs2D<TItem>(this TItem[] array, int width, int height, Action<int, int> action, bool boolean = true)
		=>	!boolean ?
				array :
				array.after(()=>
					ForEach.inCount(width, x =>
						ForEach.inCount(height, y =>
							action(x, y))));

	// method: (according to the given boolean:) set each item in this given array as a 2D array using the given width and height using the given function respectively upon the current x and y //
	public static TItem[] as2DWithEachSetTo<TItem>(this TItem[] array, Func<int, int, TItem> function, int width, int height, bool boolean = true)
		=> !boolean ?
				array :
				array.after(()=>
					ForEach.inCount(width, x =>
						ForEach.inCount(height, y =>
							array[Dimensionality.encode2DTo1D(x, y, width)] = function(x, y))));
	#endregion acting upon all items


	#region casting

	// method: return this given array of objects cast to the specified class of array (however, there is no guarantee that the given array of objects can be cast to the specified class of array) //
	public static TCast[] castTo<TCast>(this object[] array)
		=> Array.ConvertAll(array, object_ => object_.castTo<TCast>());
	#endregion casting
}