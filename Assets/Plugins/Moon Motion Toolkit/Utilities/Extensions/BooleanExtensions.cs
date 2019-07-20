using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BooleanExtensions: provides extension methods for handling booleans //
public static class BooleanExtensions
{
	// methods for: logic //
	
	public static bool and(this bool boolean, bool otherBoolean)
		=> (boolean && otherBoolean);

	public static bool butNot(this bool boolean, bool otherBoolean)
		=> boolean.and(!otherBoolean);

	public static bool or(this bool boolean, bool otherBoolean)
		=> (boolean || otherBoolean);

	public static bool xor(this bool boolean, bool otherBoolean)
		=> (boolean ^ otherBoolean);

	public static bool otherwiseWhether(this bool boolean, bool otherBoolean)
		=> (boolean ?
				true :
				otherBoolean
			);

	public static bool ifNot(this bool boolean, bool otherBoolean)
		=> (otherBoolean ?
				true :
				boolean
			);


	// methods for: acting //

	// method: return the given action on the specified class predicated with the given boolean //
	public static Action<TObject> predicating<TObject>(this bool boolean, Action<TObject> action)
		=> action.predicatedWith(boolean);


	// methods for: conversion //

	// method: return the sign integer for this given boolean //
	public static int asSign(this bool boolean)
		=> (boolean ? 1 : -1);
}