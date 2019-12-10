#if ODIN_INSPECTOR
#if UNITY_EDITOR
/// <summary>
/// Odin Hierarchy
/// Sirawat Pitaksarit / 5argon
/// Exceed7 Experiments 
/// Contact : http://5argon.info, http://exceed7.com, 5argon@exceed7.com
/// </summary>

using UnityEditor;
using UnityEngine;

using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using Sirenix.Utilities.Editor;
using Sirenix.Utilities;

// #hierarchy
[InitializeOnLoad]
public static class OdinHierarchyDrawer
{
    private static Dictionary<string, PropertyInfo> iconProperties = new Dictionary<string, PropertyInfo>();
    public static OdinHierarchySettings ohsStatic;

    static OdinHierarchyDrawer()
    {
        LoadSettings();
        iconProperties.Clear();
        foreach (var item in typeof(EditorIcons).GetProperties(Flags.StaticPublic).OrderBy(x => x.Name))
        {
            var returnType = item.GetReturnType();
            if (typeof(EditorIcon).IsAssignableFrom(returnType))
            {
                iconProperties.Add(item.Name, item);
            }
        }
        EditorApplication.hierarchyWindowItemOnGUI -= Draw;
        EditorApplication.hierarchyWindowItemOnGUI += Draw;
    }

    public static void LoadSettings()
    {
        string[] find = AssetDatabase.FindAssets("t:OdinHierarchySettings");
        if (find.Length > 0)
        {
            ohsStatic = AssetDatabase.LoadAssetAtPath<OdinHierarchySettings>(AssetDatabase.GUIDToAssetPath(find[0]));
        }
    }

	public static GUIStyle styleForUsingLayerNameWith(Color color)
	{
		GUIStyle guiStyle = new GUIStyle(GUI.skin.label);
		guiStyle.alignment = TextAnchor.MiddleRight;
		guiStyle.fontSize = 9;
		guiStyle.normal.textColor = color;
		return guiStyle;
	}
	public static GUIStyle styleForUsingLayerName
		=> styleForUsingLayerNameWith(Default.layerHierarchyLabelColor);

    private static void Draw(int id, Rect rect)
    {
        if (ohsStatic == null || ohsStatic.enabled == false)
        {
            return;
        }

        GameObject gameObject = EditorUtility.InstanceIDToObject(id) as GameObject;

        if (gameObject == null)
        {
            return;
        }

        Rect extended = new Rect(rect);
        extended.xMin = extended.xMin - 2;

        OdinHierarchySettings.Stylization item = ohsStatic.MatchSettingsWithGameObject(gameObject);

        if (item != null)
        {
            Rect rectToUse = extended;

            GUIStyle style;
			if (item.drawBackgroundColor)
			{
				switch (item.style)
				{
					case OdinHierarchySettings.Style.Off: style = SirenixGUIStyles.None; break;
					case OdinHierarchySettings.Style.Button: style = SirenixGUIStyles.Button; break;
					case OdinHierarchySettings.Style.MiniButton: style = EditorStyles.miniButton; break;
					case OdinHierarchySettings.Style.MiniButtonMid: style = EditorStyles.miniButtonMid; break;
					case OdinHierarchySettings.Style.HelpBox: style = EditorStyles.helpBox; break;
					case OdinHierarchySettings.Style.WhiteLabel: style = EditorStyles.whiteLabel; break;
					case OdinHierarchySettings.Style.WhiteMiniLabel: style = EditorStyles.whiteMiniLabel; break;
					default: style = SirenixGUIStyles.None; break;
				}
				style = new GUIStyle(style);
				style.alignment = item.textAnchor;
				GUIHelper.PushColor(item.color);
			}
			else
			{
				style = SirenixGUIStyles.None;
			}
            string textToDraw
				=	(item.useLayerName ?
						gameObject
							.layerName()
								.withReplaced
								(
									Layer.defaultName, "",
									item.treatDefaultLayerNameAsEmpty
								) :
						item.overrideText
					).withPotentialTrailingSpace();
            EditorGUI.LabelField
			(
				rectToUse,
				item.drawText ?
					textToDraw :
					"",
				(item.drawText && item.useLayerName) ?
					!item.treatDefaultLayerNameAsEmpty && item.useUniqueColorForDefaultLayerLabels && textToDraw.matches(Layer.defaultName.withPotentialTrailingSpace()) ?
						styleForUsingLayerNameWith(item.defaultLayerLabelColor) :
						styleForUsingLayerName :
					style
			);
			if (item.drawBackgroundColor)
			{
				 GUIHelper.PopColor();
			}

            if (item.decoration)
            {
                if (item.decorationType == OdinHierarchySettings.Decoration.Highlight)
                {
                    SirenixEditorGUI.DrawSolidRect(rectToUse, item.decorationColor);
                }
                if (item.decorationType == OdinHierarchySettings.Decoration.Underline)
                {
                    SirenixEditorGUI.DrawBorders(rectToUse, 0, 0, 0, 1, item.decorationColor);
                }
                if (item.decorationType == OdinHierarchySettings.Decoration.Left)
                {
					#pragma warning disable 0219
                    Rect extended2 = new Rect(extended);
					#pragma warning restore 0219
                    extended.xMin = extended.xMin - 2;
                    SirenixEditorGUI.DrawBorders(extended, 4, 0, 0, 0, item.decorationColor);
                }
                if (item.decorationType == OdinHierarchySettings.Decoration.Right)
                {
                    SirenixEditorGUI.DrawBorders(rectToUse, 0, 4, 0, 0, item.decorationColor);
                }
            }

            if (item.icon && string.IsNullOrEmpty(item.iconName) == false)
            {
                EditorIcon editorIcon = (EditorIcon)iconProperties[item.iconName].GetGetMethod().Invoke(null, null);

                float iconSize = ohsStatic.iconSize + item.sizeAdjustment;
                var rightPadding = ohsStatic.iconPaddingRight - item.paddingRightAdjustment;

                EditorGUIUtility.SetIconSize(new Vector2(iconSize, iconSize));
                var iconRect = new Rect(rect.xMax - (iconSize + rightPadding), rect.yMin + ((rect.height - iconSize) / 2.0f), iconSize + rightPadding, iconSize);
                //SirenixEditorGUI.DrawSolidRect(iconDrawRect, Color.yellow); //For debugging
                var iconContent = new GUIContent(editorIcon.Active);
                EditorGUI.LabelField(iconRect, iconContent, SirenixGUIStyles.None);
                EditorGUIUtility.SetIconSize(Vector2.zero);
            }
        }
    }
}
#endif
#endif