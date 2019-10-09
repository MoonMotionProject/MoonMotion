using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Provide:
// • provides methods for having dynamos provide certain types
//   · a 'dynamo' is a dynamic type, which can be specified as a parameter in a method using the keyword 'dynamic'
//   · in the current implementation's version of C#, dynamics cannot be the 'this' parameter in extension methods unless the extension method is called upon the static class; thus, this class is used as a cleaner alternative
//   · occasionally when using a Provide method within a Unity method the Unity method will not work as expected, so to be sure, always declare Provide results as variables before using them (for example, 'Vector3 position = Provide.positionVia(position_PositionProvider)')
// #auto #dynamics
public static class Provide
{
	#region Transform

	public static Transform transformVia(dynamic dynamo)
	{
		if (dynamo is Transform)
		{
			return dynamo;
		}
		else if (dynamo is GameObject)
		{
			GameObject gameObject = dynamo as GameObject;
			return gameObject.transform;
		}
		else if (dynamo is Component)
		{
			Component component = dynamo as Component;
			return component.transform;
		}
		else
		{
			Type dynamoType = dynamo.type();
			return default(Transform).returnWithError("Provide.transformVia given unrecognized dynamo of type "+dynamoType);
		}
	}
	#endregion Transform


	#region position

	public static Vector3 positionVia(dynamic dynamo)
	{
		if (dynamo is Vector3)
		{
			return dynamo;
		}
		else if (dynamo is GameObject)
		{
			GameObject gameObject = dynamo as GameObject;
			return gameObject.position();
		}
		else if (dynamo is Component)
		{
			Component component = dynamo as Component;
			return component.position();
		}
		else
		{
			Type dynamoType = dynamo.type();
			return default(Vector3).returnWithError("Provide.positionVia given unrecognized dynamo of type "+dynamoType);
		}
	}
	#endregion position


	#region Rigidbody
	
	public static Rigidbody rigidbodyVia(dynamic dynamo)
	{
		if (dynamo is Rigidbody)
		{
			return dynamo;
		}
		else if (dynamo is GameObject)
		{
			GameObject gameObject = dynamo as GameObject;
			return gameObject.rigidbody();
		}
		else if (dynamo is Component)
		{
			Component component = dynamo as Component;
			return component.rigidbody();
		}
		else
		{
			Type dynamoType = dynamo.type();
			return default(Rigidbody).returnWithError("Provide.rigidbodyVia given unrecognized dynamo of type "+dynamoType);
		}
	}
	#endregion Rigidbody


	#region List<Rigidbody>
	
	public static List<Rigidbody> rigidbodiesVia(dynamic dynamo)
	{
		if (dynamo is Rigidbody)
		{
			Rigidbody rigidbody = dynamo as Rigidbody;
			return rigidbody.startList();
		}
		else if (dynamo is GameObject)
		{
			GameObject gameObject = dynamo as GameObject;
			return rigidbodiesVia(gameObject.rigidbody());
		}
		else if (dynamo is Component)
		{
			Component component = dynamo as Component;
			return rigidbodiesVia(component.rigidbody());
		}
		else if (dynamo is IEnumerable<Rigidbody>)
		{
			IEnumerable<Rigidbody> rigidbodiesEnumerable = dynamo as IEnumerable<Rigidbody>;
			return rigidbodiesEnumerable.manifested();
		}
		else if (dynamo is IEnumerable<GameObject>)
		{
			IEnumerable<GameObject> gameObjectsEnumerable = dynamo as IEnumerable<GameObject>;
			return gameObjectsEnumerable.rigidbodies();
		}
		else if (dynamo is IEnumerable<Component>)
		{
			IEnumerable<Component> componentsEnumerable = dynamo as IEnumerable<Component>;
			return componentsEnumerable.rigidbodies();
		}
		else
		{
			Type dynamoType = dynamo.type();
			return default(List<Rigidbody>).returnWithError("Provide.rigidbodiesVia given unrecognized dynamo of type "+dynamoType);
		}
	}
	#endregion List<Rigidbody>


	#region mesh

	public static Mesh meshVia(dynamic dynamo)
	{
		if (dynamo is Mesh)
		{
			return dynamo;
		}
		else if (dynamo is GameObject)
		{
			GameObject gameObject = dynamo as GameObject;
			return gameObject.mesh();
		}
		else if (dynamo is Component)
		{
			Component component = dynamo as Component;
			return component.mesh();
		}
		else
		{
			Type dynamoType = dynamo.type();
			return default(Mesh).returnWithError("Provide.meshVia given unrecognized dynamo of type "+dynamoType);
		}
	}
	#endregion mesh


	#region shared mesh

	public static Mesh sharedMeshVia(dynamic dynamo)
	{
		if (dynamo is Mesh)
		{
			return dynamo;
		}
		else if (dynamo is GameObject)
		{
			GameObject gameObject = dynamo as GameObject;
			return gameObject.sharedMesh();
		}
		else if (dynamo is Component)
		{
			Component component = dynamo as Component;
			return component.sharedMesh();
		}
		else
		{
			Type dynamoType = dynamo.type();
			return default(Mesh).returnWithError("Provide.sharedMeshVia given unrecognized dynamo of type "+dynamoType);
		}
	}
	#endregion shared mesh
}