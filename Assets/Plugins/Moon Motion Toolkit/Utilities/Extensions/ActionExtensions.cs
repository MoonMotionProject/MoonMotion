using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Action Extensions: provides extension methods for handling actions //
public static class ActionExtensions
{
	// methods for: acting //
	
	// method: invoke each of these given actions on the given object, then return these given actions //
	public static IEnumerableT actOn<IEnumerableT, TObject>(this IEnumerableT actions, TObject object_) where IEnumerableT : IEnumerable<Action<TObject>>
		=> actions.forEach_EnumerableSpecializedViaCasting<IEnumerableT, Action<TObject>>(action => action(object_));


	// methods for: logic //

	// method: return this given action predicated with the given booleanic function //
	public static Action predicatedWith(this Action action, Func<bool> function)
		=> (() => {if (function()) {action();}});

	// method: return this given action predicated with the given boolean //
	public static Action predicatedWith(this Action action, bool boolean)
		=> action.predicatedWith(() => boolean);

	// method: return this given action on the specified class predicated with the given booleanic function upon the specified class //
	public static Action<TObject> predicatedWith<TObject>(this Action<TObject> action, Func<TObject, bool> function)
		=> (object_ => {if (function(object_)) {action(object_);}});

	// method: return this given action on the specified class predicated with the given boolean //
	public static Action<TObject> predicatedWith<TObject>(this Action<TObject> action, bool boolean)
		=> action.predicatedWith(object_ => boolean);


	// methods for: conversion //

	// method: return the (chainable) function corresponding to this given action //
	public static Func<TObject, TObject> asFunction<TObject>(this Action<TObject> action)
		=> (object_ => {action(object_); return object_;});
}