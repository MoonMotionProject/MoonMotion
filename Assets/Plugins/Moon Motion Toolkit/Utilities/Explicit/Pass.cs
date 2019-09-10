using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pass:
// • provides methods to use what is provided by Provide directly in functions to return results
//   · due to restrictions in the current implementation's version of C#, the function passed to these methods must have its type declared when passed as a lambda; for instance, ~'new Func<Vector3, Vector3>()' with the lambda as usual now put inside those parentheses
public static class Pass
{
	#region position
	
	public static TResult positionVia<TResult>(dynamic dynamo, Func<Vector3, TResult> function)
		=> function(Provide.positionVia(dynamo));
	#endregion position


	#region Rigidbody

	public static TResult rigidbodyVia<TResult>(dynamic dynamo, Func<Rigidbody, TResult> function)
		=> function(Provide.rigidbodyVia(dynamo));

	public static TResult rigidbodiesVia<TResult>(dynamic dynamo, Func<IEnumerable<Rigidbody>, TResult> function)
		=> function(Provide.rigidbodiesVia(dynamo));
	#endregion Rigidbody
}