using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Instance Idee Extensions:
// • provides extension methods for handling instance idees
// #instancing #unityobject #gameobject
public static class InstanceIdeeExtensions
{
	// method: return the instance idee of this given Unity object //
	public static int instanceIdee(this Object object_)
		=> object_.GetInstanceID();

	// method: return whether this given instance idee is the instance idee for the given Unity object //
	public static bool isTheInstanceIdeeFor(this int instanceIdee, Object object_)
		=> object_.instanceIdee() == instanceIdee;

	#if UNITY_EDITOR
	// method: if there is a game object corresponding to this given integer as a game object idee, return that game object; otherwise, return null //
	public static GameObject asInstanceIdeeToGameObject(this int gameObjectInstanceIdee)
		=> EditorUtility.InstanceIDToObject(gameObjectInstanceIdee) as GameObject;
	#endif
}