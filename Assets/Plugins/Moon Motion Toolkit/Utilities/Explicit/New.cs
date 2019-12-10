using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

// New:
// • provides members for that allow for fluent creation of certain objects
// #new #enumerables #reflection
public static class New
{
	#region miscellaneous

	public static object genericObject => new object();

	public static Action Action(this Action action)
		=> action;

	public static Exception exception => new Exception();
	
	public static Vector3 floatsVectorOf(float x, float y, float z)
		=> new Vector3(x, y, z);
	public static Vector3 floatZeroesVectorWithX(float x)
		=> FloatsVector.zeroes.withX(x);
	public static Vector3 floatZeroesVectorWithY(float y)
		=> FloatsVector.zeroes.withY(y);
	public static Vector3 floatZeroesVectorWithZ(float z)
		=> FloatsVector.zeroes.withZ(z);

	public static GameObject gameObject => "New Object".createAsObject();

	#if UNITY_EDITOR
	// reference: https://forum.unity.com/threads/tutorial-how-to-to-show-specific-folder-content-in-the-project-window-via-editor-scripting.508247/ //
	public static EditorWindow assetsWindow_ViaReflection
	{
		get
		{
			Type assetsWindowType = Assets.windowType_ViaReflection;
			return	EditorWindow.GetWindow(assetsWindowType)
						.show()
						.invoke(assetsWindowType.publicInstanceMethodNamed("Init"));
		}
	}
	#endif
	#endregion miscellaneous




	#region enumerables


	public static TItem[] arrayForCount<TItem>(int count)
		=> new TItem[count];
	public static TItem[] arrayOf<TItem>()
		=> arrayForCount<TItem>(0);
	public static TItem[] arrayOf<TItem>(IEnumerable<TItem> items)
		=> items.ToArray();
	public static TItem[] arrayOf<TItem>(params TItem[] items)
		=> arrayOf(items.asEnumerable());


	public static List<TItem> listOf<TItem>()
		=> new List<TItem>();
	public static List<TItem> listOf<TItem>(IEnumerable<TItem> items)
		=> items.ToList();
	public static List<TItem> listOf<TItem>(params TItem[] items)
		=> listOf(items.asEnumerable());
	

	public static HashSet<TItem> setOf<TItem>()
		=> new HashSet<TItem>();
	public static HashSet<TItem> setOf<TItem>(IEnumerable<TItem> items)
		=> new HashSet<TItem>(items);
	public static HashSet<TItem> setOf<TItem>(params TItem[] items)
		=> setOf(items.asEnumerable());


	#region dictionaries

	public static KeyValuePair<TKey, TValue> keyValuePairFor<TKey, TValue>(TKey key, TValue value)
		=> new KeyValuePair<TKey, TValue>(key, value);

	public static Dictionary<TKey, TValue> dictionaryOf<TKey, TValue>()
		=> new Dictionary<TKey, TValue>();
	public static Dictionary<TKey, TValue> dictionaryOf<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> keyValuePairs)
		=> keyValuePairs.ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value);
	public static Dictionary<TKey, TValue> dictionaryOf<TKey, TValue>(params KeyValuePair<TKey, TValue>[] keyValuePairs)
		=> dictionaryOf(keyValuePairs.asEnumerable());
	#endregion dictionaries
	#endregion enumerables




	#region Moon Motion Toolkit
	#if MOON_MOTION_TOOLKIT
	
	#endif
	#endregion Moon Motion Toolkit
}