using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ICollection Extensions: provides extension methods for handling collections //
// note: where the 'class' extension constraint is specified, the method is not provided for arrays
// #enumerable-e
public static class ICollectionExtensions
{
	// methods for: removing //

	// method: (according to the given boolean:) clear this given collection, then return this given collection //
	public static ICollectionT clear<ICollectionT, TItem>(this ICollectionT collection, bool boolean = true) where ICollectionT : class, ICollection<TItem>
		=> collection.after(()=>
			collection.Clear(),
			boolean);


	// methods for: iteration //

	// method: (according to the given boolean:) invoke the given action on each item in this given collection, then return this given collection //
	public static ICollectionT forEach_CollectionSpecializedViaCasting<ICollectionT, TItem>(this ICollectionT collection, Action<TItem> action, bool boolean = true) where ICollectionT : ICollection<TItem>
		=> collection.forEach_EnumerableSpecializedViaCasting(action, boolean);
}