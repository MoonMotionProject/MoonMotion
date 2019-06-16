using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Functions: provides functionality for handling functions //
public static class Functions
{
	// properties //

	
	// return an identity function for the specified input/output type //
	public static Func<TInputAndOutput, TInputAndOutput> identity<TInputAndOutput>()
		=> (x => x);
}