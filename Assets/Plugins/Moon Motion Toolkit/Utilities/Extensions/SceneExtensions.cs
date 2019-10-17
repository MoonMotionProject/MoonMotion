using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scene Extensions: provides extension methods for handling scenes //
public static class SceneExtensions
{
	#region scene determination
	
	// method: return the scene that this given component is in //
	public static Scene scene(this Component component)
		=> component.gameObject.scene;
	#endregion scene determination
}