using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BooleanExtensions: provides extension methods for handling booleans //
public static class BooleanExtensions
{
	// methods for: logic //
	
	public static bool and(this bool boolean, bool otherBoolean)
		=> (boolean && otherBoolean);

	public static bool or(this bool boolean, bool otherBoolean)
		=> (boolean || otherBoolean);

	public static bool xor(this bool boolean, bool otherBoolean)
		=> (boolean ^ otherBoolean);

	public static bool otherwise(this bool boolean, bool otherBoolean)
		=> (boolean ?
				true :
				otherBoolean
			);


	// methods for: conversion //

	// method: return the sign integer for this given boolean //
	public static int asSign(this bool boolean)
		=> (boolean ? 1 : -1);
}