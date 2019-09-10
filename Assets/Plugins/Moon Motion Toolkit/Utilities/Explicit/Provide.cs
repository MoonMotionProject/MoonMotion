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
	
	public static Vector3 positionVia(dynamic dynamo)
		=> positionVia_(dynamo);

	private static Vector3 positionVia_(Vector3 vector)
		=> vector;
	private static Vector3 positionVia_(Component component)
		=> component.position();
	private static Vector3 positionVia_(GameObject gameObject)
		=> gameObject.position();
	#endregion position


	#region Rigidbody
	
	public static Rigidbody rigidbodyVia(dynamic dynamo)
		=> rigidbodyVia_(dynamo);

	private static Rigidbody rigidbodyVia_(Rigidbody rigidbody)
		=> rigidbody;
	private static Rigidbody rigidbodyVia_(Component component)
		=> component.rigidbody();
	private static Rigidbody rigidbodyVia_(GameObject gameObject)
		=> gameObject.rigidbody();

	public static IEnumerable<Rigidbody> rigidbodiesVia(dynamic dynamo)
		=> rigidbodiesVia_(dynamo);

	private static IEnumerable<Rigidbody> rigidbodiesVia_(Rigidbody rigidbody)
		=> rigidbody.startEnumerable();
	private static IEnumerable<Rigidbody> rigidbodiesVia_(Component component)
		=> component.rigidbody().startEnumerable();
	private static IEnumerable<Rigidbody> rigidbodiesVia_(GameObject gameObject)
		=> gameObject.rigidbody().startEnumerable();
	private static IEnumerable<Rigidbody> rigidbodiesVia_(IEnumerable<Rigidbody> rigidbodies)
		=> rigidbodies;
	private static IEnumerable<Rigidbody> rigidbodiesVia_(IEnumerable<Component> components)
		=> components.rigidbodies();
	private static IEnumerable<Rigidbody> rigidbodiesVia_(IEnumerable<GameObject> gameObjects)
		=> gameObjects.rigidbodies();
	#endregion Rigidbody
}