using UnityEngine;
using UnityEditor;

// Hierarchy Style:
// • stylizes the hierarchy
[InitializeOnLoad]      // ensures that this class's constructor is called every time the project recompiles
public static class HierarchyStyle
{
	static HierarchyStyle()
	{
		EditorApplication.hierarchyWindowItemOnGUI += stylizeHierarchy;
	}


	private static GUIStyle nameStyleActive
	{
		get
		{
			GUIStyle guiStyle = new GUIStyle(GUI.skin.label);
			guiStyle.alignment = TextAnchor.MiddleLeft;
			guiStyle.normal.textColor = Color.white.withAlpha(.6f);
			return guiStyle;
		}
	}
	private static GUIStyle nameStyleInactiveOnlyGlobally
	{
		get
		{
			GUIStyle guiStyle = new GUIStyle(nameStyleActive);
			guiStyle.normal.textColor = Color.white.withAlpha(.3f);
			return guiStyle;
		}
	}
	private static GUIStyle nameStyleInactiveLocally
	{
		get
		{
			GUIStyle guiStyle = new GUIStyle(nameStyleActive);
			guiStyle.normal.textColor = Color.white.withAlpha(.1f);
			return guiStyle;
		}
	}
	private static GUIStyle hierarchyNameStyle(this GameObject gameObject)
		=> gameObject.activeLocally() ?
			(gameObject.activeGlobally() ?
				nameStyleActive :
				nameStyleInactiveOnlyGlobally) :
			nameStyleInactiveLocally;
	private static GUIStyle layerStyle
	{
		get
		{
			GUIStyle guiStyle = new GUIStyle(GUI.skin.label);
			guiStyle.alignment = TextAnchor.MiddleRight;
			guiStyle.fontSize = 9;
			guiStyle.normal.textColor = Color.gray;
			return guiStyle;
		}
	}
	private static GUIStyle hierarchyLayerStyle(this GameObject gameObject)
		=>  layerStyle;

	private static void stylizeHierarchy(int gameObjectIdee, Rect selectionRectangle)
	{
		GameObject gameObject = gameObjectIdee.gameObject();
		if (gameObject.exists())
		{
			if (gameObject.isNotOnDefaultLayer())
			{
				EditorGUI.LabelField(selectionRectangle,
					gameObject.layerName().withPotentialTrailingSpace(),
					gameObject.hierarchyLayerStyle());
			}
		}
	}
}