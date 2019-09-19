using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Provide:
// • provides methods for having dynamos provide certain types
//   · a 'dynamo' is a dynamic type, which can be specified as a parameter in a method using the keyword 'dynamic'
//   · in the current implementation's version of C#, dynamics cannot be the 'this' parameter in extension methods unless the extension method is called upon the static class; thus, this class is used as a cleaner alternative
// #auto #dynamics
public static class Provide
{
	#region Transform

	public static Transform transformVia(dynamic dynamo)
		=> transformVia_(dynamo);

	private static Transform transformVia_(Transform transform)
		=> transform;
	private static Transform transformVia_(GameObject gameObject)
		=> gameObject.transform;
	private static Transform transformVia_(Component component)
		=> component.transform;
	#endregion Transform


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

	public static List<Rigidbody> rigidbodiesVia(dynamic dynamo)
		=> rigidbodiesVia_(dynamo);

	private static List<Rigidbody> rigidbodiesVia_(Rigidbody rigidbody)
		=> rigidbody.startList();
	private static List<Rigidbody> rigidbodiesVia_(Component component)
		=> rigidbodiesVia_(component.rigidbody());
	private static List<Rigidbody> rigidbodiesVia_(GameObject gameObject)
		=> rigidbodiesVia_(gameObject.rigidbody());
	private static List<Rigidbody> rigidbodiesVia_(IEnumerable<Rigidbody> rigidbodies)
		=> rigidbodies.manifest();
	private static List<Rigidbody> rigidbodiesVia_(IEnumerable<Component> components)
		=> components.rigidbodies();
	private static List<Rigidbody> rigidbodiesVia_(IEnumerable<GameObject> gameObjects)
		=> gameObjects.rigidbodies();
	#endregion Rigidbody
}