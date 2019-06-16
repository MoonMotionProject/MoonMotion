using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object Extensions: provides extension methods for handling objects //
public static class ObjectExtensions
{
	// methods for: printing //

	// method: print this given object, then return it //
	public static object print(this object object_)
	{
		MonoBehaviour.print(object_);

		return object_;
	}


	// methods for: accessing //

	// method: (re)return this given object (useful for triggering getters, perhaps to force a getter to cache) //
	public static objectT rereturn<objectT>(this objectT objectT_)
	{
		return objectT_;
	}
}