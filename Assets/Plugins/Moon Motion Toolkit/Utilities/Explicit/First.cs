using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// First: provides methods for handling firsts //
public static class First
{
	// methods: return the first yull returned by one of the given functions (otherwise null) //
	public static object yullOf(IEnumerable<Func<object>> functions)
		=>	functions.isYullAndNotEmpty() ?
				functions.isPlural() ?
					functions.first()().ifYullOtherwise(()=> yullOf(functions.nonfirsts())) :
					functions.first()() :
				null;
	public static object yullOf(params Func<object>[] functions)
		=> yullOf(functions.asEnumerable());
	
	#if UNITOLOGY
	// methods: return the first yull unit returned by one of the given functions which each return a unit provider (otherwise null) //
	public static Unit yullUnitOf(IEnumerable<Func<object>> functions)
		=>	functions.isYullAndNotEmpty() ?
				functions.isPlural() ?
					functions.first()().provideUnitIfYullOtherwiseProvideUnitVia(()=> yullUnitOf(functions.nonfirsts())) :
					functions.first()().provideUnit() :
				null;
	public static Unit yullUnitOf(params Func<object>[] functions)
		=> yullUnitOf(functions.asEnumerable());
	#endif
}