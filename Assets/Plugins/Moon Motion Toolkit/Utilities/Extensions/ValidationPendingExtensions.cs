using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Validation Pending Extensions: provides extension methods and related functionality for pending validation of game objects //
public static class ValidationPendingExtensions
{
	#if UNITY_EDITOR
	// variables //


	// tracking //

	public static HashSet<GameObject> gameObjectsPendingValidation = new HashSet<GameObject>();




	// methods //

	
	// method: (if in the editor:) unpend validation for this given game object, then return this given game object //
	public static GameObject unpendValidation_IfInEditor(this GameObject gameObject)
		=> gameObjectsPendingValidation.removeGet(gameObject);
	
	// method: (if in the editor:) (if this given game object exists and the given boolean is true:) pend validation for this given game object, then return this given game object //
	public static GameObject pendValidation_IfInEditor(this GameObject gameObject, bool boolean = true)
		=>	gameObject.ifExists(()=>
			{
				if (gameObjectsPendingValidation.doesNotContain(gameObject))
				{
					gameObjectsPendingValidation.add(gameObject);
					EditorEvents.afterAllInspectorsHaveNextUpdatedExecute(()=>
					{
						gameObject.ifExists(()=> gameObject.validate_IfInEditor()).unpendValidation_IfInEditor();
					});
				}
			},
			boolean);
	#endif
}