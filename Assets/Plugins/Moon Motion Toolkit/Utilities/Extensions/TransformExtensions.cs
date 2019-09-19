using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Transform Extensions: provides extension methods for handling transforms //
// #auto #transform
public static class TransformExtensions
{
	#region accessing

	// method: return a selection of the transforms for this given enumerable of game objects //
	public static IEnumerable<Transform> selectTransforms(this IEnumerable<GameObject> gameObjects)
		=> gameObjects.select(gameObject => gameObject.transform);
	#endregion accessing


	#region destruction

	// method: destroy the game object of this given transform //
	public static void destroyObject(this Transform transform)
		=> transform.gameObject.destroy();
	#endregion destruction


	#region activity

	// method: return whether this given transform is active locally //
	public static bool activeLocally(this Transform transform)
		=> transform.gameObject.activeLocally();

	// method: return whether this given transform is active globally //
	public static bool activeGlobally(this Transform transform)
		=> transform.gameObject.activeGlobally();

	// method: set the activity of this given transform to the given boolean, then return this given transform //
	public static Transform setActivityTo(this Transform transform, bool activity)
		=> transform.gameObject.setActivityTo(activity).transform;

	// method: activate this given transform, then return it //
	public static Transform activate(this Transform transform)
		=> transform.gameObject.activate().transform;

	// method: deactivate this given transform, then return it //
	public static Transform deactivate(this Transform transform)
		=> transform.gameObject.activate().transform;

	// method: toggle the activity of this given transform using the given toggling, then return this given transform //
	public static Transform toggleActivityBy(this Transform transform, Toggling toggling)
		=> transform.gameObject.toggleActivityBy(toggling).transform;

	// method: toggle the activity of these given transforms using the given toggling, then return them //
	public static Transform[] toggleActivityBy(this Transform[] transforms, Toggling toggling)
		=> transforms.forEach(transform => transform.toggleActivityBy(toggling));

	// method: set the activity of these given transforms to the given boolean, then return them //
	public static Transform[] setActivityTo(this Transform[] transforms, bool activity)
		=> transforms.forEach(transform => transform.setActivityTo(activity));

	// method: activate these given transforms, then return them //
	public static Transform[] activate(this Transform[] transforms)
		=> transforms.setActivityTo(true);

	// method: deactivate these given transforms, then return them //
	public static Transform[] deactivate(this Transform[] transforms)
		=> transforms.setActivityTo(false);
	#endregion activity


	#region calling local methods

	// method: call all of this transform's game object's mono behaviours' defined methods (ignoring inherited methods that haven't been overriden) with the given name, then return this given game object //
	public static Transform callAllLocal(this Transform transform, string methodName, SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver)
		=> transform.gameObject.callAllLocal(methodName, sendMessageOptions).transform;

	// method: (if in the editor:) have all mono behaviours on this transform's game object validate (if they have OnValidate defined), then return this given transform //
	public static Transform validate_IfInEditor(this Transform transform)
		=>	transform.gameObject.validate_IfInEditor().transform;
	#endregion calling local methods


	#region transformation averages

	// method: determine the average of these given transforms' local positions //
	public static Vector3 averageLocalPosition(this Transform[] transforms)
		=> transforms.selectLocalPositions().average();

	// method: determine the average of these given transforms' local scales //
	public static Vector3 averageLocalScale(this Transform[] transforms)
		=> transforms.selectLocalScales().average();

	// method: determine the average of these given transforms' (global) positions //
	public static Vector3 averagePosition(this Transform[] transforms)
		=> transforms.selectPositions().average();
	#endregion transformation averages


	#region casting

	// method: return the enumerable (of child transforms) for this given transform //
	public static IEnumerable<Transform> asEnumerable(this Transform transform)
		=> transform.Cast<Transform>();
	#endregion casting
}