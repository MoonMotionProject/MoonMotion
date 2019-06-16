using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Dictionary Extensions: provides extension methods for handling dictionaries //
public static class DictionaryExtensions
{
	// methods for: "adding" (setting) //

	// method: (according to the given boolean:) set the given key of this given dictionary to the given value //
	public static void add<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value, bool boolean = true)
	{
		if (boolean)
		{
			dictionary.Add(key, value);
		}
	}

	// method: (according to the given boolean:) set the given key of this given dictionary to the given value, then return this given dictionary //
	public static Dictionary<TKey, TValue> with<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value, bool boolean = true)
	{
		dictionary.add(key, value, boolean);

		return dictionary;
	}
	
	// method: (according to the given boolean:) set the given key of the given dictionary to this given value, then return this given value //
	public static TValue addedTo<TKey, TValue>(this TValue value, Dictionary<TKey, TValue> dictionary, TKey key, bool boolean = true)
	{
		dictionary.add(key, value, boolean);

		return value;
	}


	// methods for: caching //

	// method: return the value of this given dictionary at the given key, or if that key isn't set, add the given backup value to this given dictionary then return that given backup value //
	public static TValue cache<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue backupValue)
		=>	(
				dictionary.ContainsKey(key) ?
					dictionary[key] :
					backupValue.addedTo(dictionary, key)
			);


	// methods for: iterating //

	// method: invoke the given action on each value in this given dictionary, then return this given dictionary //
	public static Dictionary<TKey, TValue> forEachValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Action<TValue> action)
	{
		dictionary.valuesAsEnumerable().forEach(value => action(value));

		return dictionary;
	}


	// methods for: conversion //

	// method: return an enumerable for the values in this given dictionary //
	public static IEnumerable<TValue> valuesAsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
		=> dictionary.Select(keyValuePair => keyValuePair.Value);
}