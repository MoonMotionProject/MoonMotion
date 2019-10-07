using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Staticity Extensions: provides extension methods for handling staticity of game objects (game objects having constant positions, for the sake of Unity being able to combine their meshes and such for performance) //
public static class StaticityExtensions
{
	#region determining staticity
	
	// method: return whether this given game object is not static //
	public static bool isNotStatic(this GameObject gameObject)
		=> !gameObject.isStatic;

	// method: return whether this given raycast hit's game object is static //
	public static bool objectIsStatic(this RaycastHit raycastHit)
		=> raycastHit.gameObject().isStatic;
	// method: return whether this given raycast hit's game object is not static //
	public static bool objectIsNotStatic(this RaycastHit raycastHit)
		=> raycastHit.gameObject().isNotStatic();
	#endregion determining staticity
}