using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Dictionary Extensions: provides extension methods for handling dictionaries //
// #enumerables
public static class DictionaryExtensions
{
	#region copying

	// method: return a copy of this given dictionary //
	public static Dictionary<TKey, TValue> copy<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
		=> new Dictionary<TKey, TValue>(dictionary);
	#endregion copying


	#region accessing

	// method: return the key value pair of this given dictionary for the given key (with the value being the default value of its type if this given dictionary doesn't contain the given key) //
	public static KeyValuePair<TKey, TValue> keyValuePairFor<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
		=> new KeyValuePair<TKey, TValue>(key, (dictionary.ContainsKey(key) ? dictionary[key] : default(TValue)));

	// method: return a selection of the keys in this given dictionary //
	public static IEnumerable<TKey> selectKeys<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
		=> dictionary.select(keyValuePair => keyValuePair.Key);
	// method: return a list for the keys in this given dictionary //
	public static List<TKey> keys<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
		=> dictionary.selectKeys().manifested();

	// method: return a selection of the values in this given dictionary //
	public static IEnumerable<TValue> selectValues<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
		=> dictionary.select(keyValuePair => keyValuePair.Value);
	// method: return a list for the values in this given dictionary //
	public static List<TValue> values<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
		=> dictionary.selectValues().manifested();

	// method: return a selection of the keys in this given dictionary for which the given function returns true //
	public static IEnumerable<TKey> selectKeysWhere<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Func<TKey, bool> function)
		=> dictionary.selectKeys().only(function);
	// method: return a list for the keys in this given dictionary for which the given function returns true //
	public static List<TKey> keysWhere<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Func<TKey, bool> function)
		=> dictionary.selectKeysWhere(function).manifested();

	// method: return a selection of the values in this given dictionary for which the given function returns true //
	public static IEnumerable<TValue> selectValuesWhere<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Func<TValue, bool> function)
		=> dictionary.selectValues().only(function);
	// method: return a list for the values in this given dictionary for which the given function returns true //
	public static List<TValue> valuesWhere<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Func<TValue, bool> function)
		=> dictionary.selectValuesWhere(function).manifested();
	#endregion accessing


	#region recording

	// method: (according to the given boolean:) set the given key of this given dictionary to the given value, then return this given dictionary //
	public static Dictionary<TKey, TValue> record<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value, bool boolean = true)
		=> dictionary.after(()=>
		{
			if (boolean)
			{
				dictionary[key] = value;
			}
		});
	// method: (according to the given boolean:) add the given key value pair to this given dictionary, then return this given dictionary //
	public static Dictionary<TKey, TValue> record<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> keyValuePair, bool boolean = true)
		=> dictionary.record(keyValuePair.Key,
			keyValuePair.Value,
			boolean);

	// method: (according to the given boolean:) record the given key and value as a pair to this given dictionary (if the dictionary doesn't contain it, add it; otherwise, overwrite it), then return the given key and value as a pair //
	public static KeyValuePair<TKey, TValue> recordGet<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value, bool boolean = true)
		=> new KeyValuePair<TKey, TValue>(key, value).after(()=>
			dictionary.record(key,
				value,
				boolean));
	// method: (according to the given boolean:) record the given key value pair to this given dictionary, then return the given key value pair //
	public static KeyValuePair<TKey, TValue> recordGet<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> keyValuePair, bool boolean = true)
		=>	dictionary.recordGet(
				keyValuePair.Key,
				keyValuePair.Value,
				boolean);

	// method: (according to the given boolean:) set the given key of the given dictionary to this given value, then return this given value //
	public static TValue recordIn<TKey, TValue>(this TValue value, Dictionary<TKey, TValue> dictionary, TKey key, bool boolean = true)
		=> value.after(()=>
			dictionary.record(key, value),
			boolean);
	// method: (according to the given boolean:) add this given key value pair to the given dictionary, then return this given key value pair //
	public static KeyValuePair<TKey, TValue> recordIn<TKey, TValue>(this KeyValuePair<TKey, TValue> keyValuePair, Dictionary<TKey, TValue> dictionary, bool boolean = true)
		=> keyValuePair.after(()=>
			dictionary.record(keyValuePair),
			boolean);

	// method: (according to the given boolean:) add this given key value pair to the given dictionary, then return the given dictionary //
	public static Dictionary<TKey, TValue> recordInGet<TKey, TValue>(this KeyValuePair<TKey, TValue> keyValuePair, Dictionary<TKey, TValue> dictionary, bool boolean = true)
		=> dictionary.record(
			keyValuePair,
			boolean);
	// method: (according to the given boolean:) set the given key of the given dictionary to this given value, then return this given value //
	public static Dictionary<TKey, TValue> recordInGet<TKey, TValue>(this TValue value, Dictionary<TKey, TValue> dictionary, TKey key, bool boolean = true)
		=> dictionary.record(
			key, value,
			boolean);
	#endregion recording


	#region caching

	// method: return the value of this given dictionary at the given key, or if that key isn't set, add the result of the given backup value function to this given dictionary then return that given backup value //
	public static TValue cache<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> backupValueFunction)
		=>	(
				dictionary.ContainsKey(key) ?
					dictionary[key] :
					backupValueFunction().recordIn(dictionary, key)
			);
	#endregion caching


	#region removing

	// method: (according to the given boolean:) remove the given key from this given dictionary if the key is contained in the dictionary, then return whether the key was actually removed from this given dictionary //
	public static bool tryToRemove<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, bool boolean = true)
		=> boolean && dictionary.Remove(key);

	// method: (according to the given boolean:) remove the given item from this given hash set (assuming the given item is actually contained in this given hash set), then return this given hash set //
	public static Dictionary<TKey, TValue> remove<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, bool boolean = true)
		=> dictionary.after(()=>
			dictionary.tryToRemove(key),
			boolean);

	// method: (according to the given boolean:) remove this given key from this given dictionary (assuming this given key is actually contained in the given dictionary), then return this given key //
	public static TKey removeFrom<TKey, TValue>(this TKey key, Dictionary<TKey, TValue> dictionary, bool boolean = true)
		=> key.after(()=>
			dictionary.tryToRemove(key),
			boolean);

	// method: remove all keys from this given dictionary for which the given function upon the dictionary's corresponding key returns true, then return this given dictionary //
	public static Dictionary<TKey, TValue> removeWhere<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Func<TKey, bool> function)
		=> dictionary.after(()=>
			dictionary
			.keysWhere(function)
			.forEach(key => key.removeFrom(dictionary)));

	// method: remove all keys from this given dictionary for which the given function returns false, then return this given dictionary //
	public static Dictionary<TKey, TValue> removeWhereNot<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Func<TKey, bool> function)
		=>	dictionary.removeWhere(
				function.negated());
	#endregion removing
}