using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Action Extensions: provides extension methods for handling actions //
public static class ActionExtensions
{
	#region acting

	// method: invoke each of these given actions on the given object, then return these given actions //
	public static IEnumerableT actOn<IEnumerableT, ObjectT>(this IEnumerableT actions, ObjectT object_) where IEnumerableT : IEnumerable<Action<ObjectT>>
		=> actions.forEach_EnumerableSpecializedViaCasting<IEnumerableT, Action<ObjectT>>(action => action(object_));
	#endregion acting


	#region logic

	// method: return this given action predicated with the given booleanic function //
	public static Action predicatedWith(this Action action, Func<bool> function)
		=> (() => {if (function()) {action();}});

	// method: return this given action predicated with the given boolean //
	public static Action predicatedWith(this Action action, bool boolean)
		=> action.predicatedWith(() => boolean);

	// method: return this given action on the specified class predicated with the given booleanic function upon the specified class //
	public static Action<ObjectT> predicatedWith<ObjectT>(this Action<ObjectT> action, Func<ObjectT, bool> function)
		=> (object_ => {if (function(object_)) {action(object_);}});

	// method: return this given action on the specified class predicated with the given boolean //
	public static Action<ObjectT> predicatedWith<ObjectT>(this Action<ObjectT> action, bool boolean)
		=> action.predicatedWith(object_ => boolean);
	#endregion logic


	#region conversion

	// method: return the (chainable) function corresponding to this given action //
	public static Func<ObjectT, ObjectT> asFunction<ObjectT>(this Action<ObjectT> action)
		=> (object_ => {action(object_); return object_;});
	#endregion conversion
}