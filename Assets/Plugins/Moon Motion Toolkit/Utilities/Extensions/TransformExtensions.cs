using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Transform Extensions: provides extension methods for handling transforms //
// #transform
public static class TransformExtensions
{
	#region accessing

	// method: return an accessor for the transforms for this given enumerable of game objects //
	public static IEnumerable<Transform> accessTransforms(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.access(gameObject => gameObject.transform);
	#endregion accessing


	#region destruction

	// method: destroy the game object of this given transform //
	public static void destroyObject(this Transform transform)
		=> transform.gameObject.destroy();
	#endregion destruction


	#region calling local methods

	// method: execute all of this transform's game object's mono behaviours' defined methods (ignoring inherited methods that haven't been overriden) with the given name, then return this given game object //
	public static Transform executeAllLocal(this Transform transform, string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver)
		=> transform.gameObject.executeAllLocal(methodName, sendMessageOptions).transform;

	// method: (if in the editor:) have all mono behaviours on this transform's game object validate (if they have OnValidate defined), then return this given transform //
	public static Transform validate_IfInEditor(this Transform transform)
		=>	transform.gameObject.validate_IfInEditor().transform;
	#endregion calling local methods


	#region transformation averages

	// method: determine the average of these given transforms' local positions //
	public static Vector3 averageLocalPosition(this Transform[] transforms)
		=> transforms.accessLocalPositions().average();

	// method: determine the average of these given transforms' local scales //
	public static Vector3 averageLocalScale(this Transform[] transforms)
		=> transforms.accessLocalScales().average();

	// method: determine the average of these given transforms' (global) positions //
	public static Vector3 averagePosition(this Transform[] transforms)
		=> transforms.accessPositions().average();
	#endregion transformation averages


	#region casting

	// method: return the enumerable (of child transforms) for this given transform //
	public static IEnumerable<Transform> asEnumerable(this Transform transform)
		=> transform.Cast<Transform>();
	#endregion casting
}