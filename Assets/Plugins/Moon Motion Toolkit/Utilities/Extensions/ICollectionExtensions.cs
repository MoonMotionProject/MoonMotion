using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ICollection Extensions: provides extension methods for handling collections //
// note: where the 'class' extension constraint is specified, the method is not provided for arrays
// #enumerables
public static class ICollectionExtensions
{
	#region removing

	// method: (according to the given boolean:) clear this given collection, then return this given collection //
	public static ICollectionT clear<ICollectionT, TItem>(this ICollectionT collection, bool boolean = true) where ICollectionT : class, ICollection<TItem>
		=> collection.after(()=>
			collection.Clear(),
			boolean);
	#endregion removing
}