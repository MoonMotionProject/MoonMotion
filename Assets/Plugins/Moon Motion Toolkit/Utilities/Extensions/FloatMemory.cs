using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Float Memory: provides extension method functionality for remembering floats via string keys, using a dictionary //
public static class FloatMemory
{
	// variables //

	
	private static Dictionary<string, float> memory = new Dictionary<string, float>();




	// methods //

	
	// method: store in memory the current value of this given float using the given key, then return this given float //
	public static float memStore(this float float_, string key)
		=> memory[key] = float_;

	// method: store in memory the current value of the given float using the key of this given string, then return this given string //
	public static string memStore(this string string_, float value)
	{
		memory.Add(string_, value);

		return string_;
	}

	// method: return the remembered value for this given string as the key //
	public static float memRecall(this string key)
		=>	(
				memory.ContainsKey(key) ?
					memory[key] :
					0.returnWithError("memRecall: "+key+": not found")
			);

	// method: forget the remembered value for this given string as the key, then return this given string //
	public static string memForget(this string string_)
	{
		memory.Remove(string_);

		return string_;
	}

	// method: forget all float memory //
	public static void forgetAll()
		=> memory.Clear();
}