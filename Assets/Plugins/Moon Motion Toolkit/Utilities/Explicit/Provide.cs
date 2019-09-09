using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Provide:
// • provides methods for having dynamos provide certain types
//   · a 'dynamo' is a dynamic type, which can be specified as a parameter in a method using the keyword 'dynamic'
//   · in the current implementation's version of C#, dynamics cannot be the 'this' parameter in extension methods unless the extension method is called upon the static class; thus, this class is used as a cleaner alternative
public static class Provide
{
	#region position

	// method: return a position via this given dynamo //
	public static Vector3 positionVia(dynamic dynamo)
		=> positionVia_(dynamo);

	private static Vector3 positionVia_(Vector3 vector)
		=> vector;
	private static Vector3 positionVia_(Component component)
		=> component.position();
	private static Vector3 positionVia_(GameObject gameObject)
		=> gameObject.position();
	#endregion position
}