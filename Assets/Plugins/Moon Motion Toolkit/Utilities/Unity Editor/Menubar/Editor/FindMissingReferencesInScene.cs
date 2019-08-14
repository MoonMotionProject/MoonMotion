using UnityEditor;
using UnityEngine;

// Find Missing References In Scene:
// • provides a menubar command to log errors for each missing reference in the scene
// • based on code from: https://www.reddit.com/r/Unity3D/comments/2ogoaq/find_missing_references_in_the_unity_editor/cmnoge0?utm_source=share&utm_medium=web2x
public static class FindMissingReferencesInScene
{
	private static string fullObjectPath(GameObject gameObject)
	{
		return ((gameObject.parent() == null) ? gameObject.name : fullObjectPath(gameObject.parentObject())+"/"+gameObject.name);
	}

	private static void logPropertyMissingReferenceError(string objectName, string propertyName)
	{
		Debug.LogError("Missing reference found in: "+objectName+" - property: "+propertyName);
	}

	[MenuItem("Status/Find Missing References In Scene %#q")]
	public static void findMissingReferencesInScene()
	{
		bool issueFound = false;

		GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();

		foreach (GameObject gameObject in gameObjects)
		{
			Component[] components = gameObject.GetComponents<Component>();

			foreach (Component component in components)
			{
				if (component == null)
				{
					Debug.LogError("Missing script found on: "+fullObjectPath(gameObject));
					issueFound = true;
				}
				else
				{
					SerializedObject serializedObject = new SerializedObject(component);
					var serializedProperty = serializedObject.GetIterator();

					while (serializedProperty.NextVisible(true))
					{
						if (serializedProperty.propertyType != SerializedPropertyType.ObjectReference)
						{
							continue;
						}

						if ((serializedProperty.objectReferenceValue == null) && (serializedProperty.objectReferenceInstanceIDValue != 0))
						{
							logPropertyMissingReferenceError(fullObjectPath(gameObject), serializedProperty.name);
							issueFound = true;
						}
					}
				}
			}
		}

		if (!issueFound)
		{
			Debug.Log("This scene seems good; no missing references found!");
		}
	}
}