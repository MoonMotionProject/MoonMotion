using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Function Extensions: provides extension methods for handling functions //
public static class FunctionExtensions
{
	// methods for: logic //
	
	// method: return the given action on the specified type predicated with this given booleanic function upon the specified type //
	public static Action<TObject> predicating<TObject>(this Func<TObject, bool> function, Action<TObject> action)
		=> action.predicatedWith(function);
	
	// method: return this given function negated //
	public static Func<TObject, bool> negated<TObject>(this Func<TObject, bool> function)
		=> (object_ => !function(object_));


	// methods for: conversion //
	
	// method: return the predicate corresponding to this given (predicate) function //
	public static Predicate<TObject> asPredicate<TObject>(this Func<TObject, bool> function)
		=> (object_ => function(object_));
}