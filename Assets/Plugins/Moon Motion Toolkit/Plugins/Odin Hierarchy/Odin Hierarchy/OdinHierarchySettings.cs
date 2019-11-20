#if ODIN_INSPECTOR
#if UNITY_EDITOR
/// <summary>
/// Odin Hierarchy
/// Sirawat Pitaksarit / 5argon
/// Exceed7 Experiments 
/// Contact : http://5argon.info, http://exceed7.com, 5argon@exceed7.com
/// </summary>

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections.Generic;
using System.Text;
using System.Linq;

using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;
using System;


// #hierarchy
[CreateAssetMenu]
public class OdinHierarchySettings : ScriptableObject
{
    public enum Style 
    {
        Off,
        Button,
        MiniButton,
        MiniButtonMid,
        HelpBox,
        WhiteLabel,
        WhiteMiniLabel,
    }

    public enum Decoration 
    {
        Right,
        Left,
        Underline,
        Highlight
    }

    public class Error
    {
        [InfoBox("Please create an 'OdinHierarchySettings' file somewhere in the Project panel's Create menu!\nOdin Hierarchy uses the first one it found in the project.")]
        [Button("Yes I did that.", ButtonSizes.Medium)]
        public void Refresh()
        {
#if UNITY_EDITOR
            OdinHierarchyDrawer.LoadSettings();
#endif
        }
    }
	
    //[CustomContextMenu("Secret", "ToggleSecret")]
	[HideInInspector]
    public bool enabled = true;
	
	private Color enableOdinHierarchy_GUIColor => Colors.green;
	[PropertyOrder(-1)]
	[GUIColor("enableOdinHierarchy_GUIColor")]
	[HideIf("enabled")]
	[Button("Enable", ButtonSizes.Medium)]
	private void enableOdinHierarchy()
		=> enabled = true;
	private Color disableOdinHierarchy_GUIColor => Colors.red;
	[PropertyOrder(-1)]
	[GUIColor("disableOdinHierarchy_GUIColor")]
	[ShowIf("enabled")]
	[Button("Disable", ButtonSizes.Medium)]
	private void disableOdinHierarchy()
		=> enabled = false;
	
    private static bool iconAndSecret => /*icon && secret*/true;

	private void defaultIconSize()
		=> iconSize = Default.hierarchyIconSize;
	[BoxGroup("Icons In General")]
	[InlineButton("defaultIconSize", "Default")]
	[LabelText("Size")]
    [ShowIf("@iconAndSecret")]
    public float iconSize = Default.hierarchyIconSize;
	
	private void defaultPaddingRight()
		=> iconPaddingRight = Default.hierarchyIconPaddingRight;
	[BoxGroup("Icons In General")]
	[InlineButton("defaultPaddingRight", "Default")]
	[LabelText("Padding Right")]
    [ShowIf("@iconAndSecret")]
    public float iconPaddingRight = Default.hierarchyIconPaddingRight;

    private static bool secret;
    public void ToggleSecret() => secret = !secret;
	
	[LabelText("Styling Rules")]
    public List<Stylization> stylizations;

    [System.Serializable]
    public class Stylization
    {
		[PropertyOrder(-666)]
		[PropertyTooltip("(this name is just for organizational purposes)")]
		[HideLabel]
		public string name = "New Styling Rule";

        [TabGroup("Context")]
		[Title("Prefab Conditions")]
		[PropertyOrder(-8)]
		public bool prefabInstancesOnly = false;

        [TabGroup("Context")]
		[Title("String Containment Conditions", Subtitle = "(ignores empty strings)")]
		[PropertyOrder(-7)]
		public bool useStringContainmentConditions = true;
		
		private void clearNameStringContainmentCondition()
			=> nameContains = "";
        [TabGroup("Context")]
		[PropertyOrder(-6)]
		[InlineButton("clearNameStringContainmentCondition", "Clear")]
		[ShowIf("useStringContainmentConditions")]
		[LabelText("Object")]
        public string nameContains;
		
		private void clearLayerStringContainmentCondition()
			=> layerContains = "";
		private void setLayerStringContainmentConditionToDefaultLayer()
			=> layerContains = Layer.defaultName;
		private void setLayerStringContainmentConditionToMoonMotionPlayerLayerName()
			=> layerContains = MoonMotion.playerLayerName;
        [TabGroup("Context")]
		[PropertyOrder(-5)]
		[InlineButton("clearLayerStringContainmentCondition", "Clear")]
		[InlineButton("setLayerStringContainmentConditionToDefaultLayer", "Default")]
		[InlineButton("setLayerStringContainmentConditionToMoonMotionPlayerLayerName", "Player")]
		[ShowIf("useStringContainmentConditions")]
		[LabelText("Layer")]
        public string layerContains;
		
		private void clearSceneStringContainmentCondition()
			=> scene = "";
        [TabGroup("Context")]
		[PropertyOrder(-4)]
		[InlineButton("clearSceneStringContainmentCondition", "Clear")]
		[ShowIf("useStringContainmentConditions")]
		[LabelText("Scene")]
        public string scene;
		
		private void clearComponentStringContainmentCondition()
			=> component = "";
        [TabGroup("Context")]
		[PropertyOrder(-3)]
		[InlineButton("clearComponentStringContainmentCondition", "Clear")]
		[ShowIf("useStringContainmentConditions")]
		[LabelText("Any Component")]
        public string component;
		
		private void clearAttributeStringContainmentCondition()
			=> attribute = "";
        [TabGroup("Context")]
		[PropertyOrder(-2)]
		[InlineButton("clearAttributeStringContainmentCondition", "Clear")]
		[ShowIf("useStringContainmentConditions")]
		[LabelText("Any Attribute")]
        public string attribute;

        private void clearComponentStringMatchingCondition()
			=> component_matching = "";
		[TabGroup("Context")]
		[Title("String Matching Conditions", Subtitle = "(ignores empty strings)")]
		[PropertyOrder(-2)]
		[InlineButton("clearComponentStringMatchingCondition", "Clear")]
		[LabelText("Any Component")]
        public string component_matching;
		
        [TabGroup("Background")]
		[PropertyOrder(6)]
		[HideLabel]
        public bool drawBackgroundColor = true;
		[TabGroup("Background")]
		[PropertyOrder(6)]
		[Indent]
		[ColorPalette]
		[ShowIf("drawBackgroundColor")]
		[HideLabel]
        public Color color = Colors.yellow;
		[HideInInspector]
        public Style style = Style.HelpBox;
		
		[TabGroup("Icon")]
		[PropertyOrder(-2)]
		[HideLabel]
        public bool icon = false;
		
		private bool particularIconAdjustments_ShowIf => icon && iconAndSecret;
		
		private void rightlessSizeAdjustment()
			=> sizeAdjustment = 4.5f;
		private void defaultSizeAdjustment()
			=> sizeAdjustment = 0f;
        [TabGroup("Icon")]
		[Indent]
		[InlineButton("rightlessSizeAdjustment", "Rightless")]
		[InlineButton("defaultSizeAdjustment", "Default")]
        [ShowIf("particularIconAdjustments_ShowIf")]
        public float sizeAdjustment = 0f;
		
		private void rightlessPaddingRightAdjustment()
			=> paddingRightAdjustment = 5f;
		private void defaultPaddingRightAdjustment()
			=> paddingRightAdjustment = 0f;
        [TabGroup("Icon")]
		[Indent]
		[InlineButton("rightlessPaddingRightAdjustment", "Rightless")]
		[InlineButton("defaultPaddingRightAdjustment", "Default")]
		[LabelText("Padding Right Ad.")]
        [ShowIf("particularIconAdjustments_ShowIf")]
        public float paddingRightAdjustment = 0f;
		
		[HideInInspector]
		[SerializeField]
		private string iconName_ = null;
        [TabGroup("Icon")]
		[PropertyOrder(-1)]
		[Indent]
        [InlineButton("ViewIcons", "View Catalogue")]
		[ValueDropdown("Icons")]
        [ShowIf("icon")]
		[HideLabel]
		[ShowInInspector]
        public string iconName
		{
			get {return iconName_.ifYullOtherwise(()=> Icons().first());}
			set {iconName_ = value;}
		}

        private static List<string> Icons()
        {
            List<string> icons = new List<string>();
            foreach (var item in typeof(EditorIcons).GetProperties(Flags.StaticPublic).OrderBy(x => x.Name))
            {
                var returnType = item.GetReturnType();
                if (typeof(EditorIcon).IsAssignableFrom(returnType))
                {
                    icons.Add(item.Name);
                }
            }
            return icons;
        }
        public void ViewIcons()
			=> EditorIconsOverview.OpenEditorIconsOverview();
		
        [TabGroup("Label")]
		[HideLabel]
        public bool drawText;
        [TabGroup("Label")]
		[Indent]
		[ShowIf("drawText")]
        public bool useLayerName = false;
        [TabGroup("Label")]
        [ShowIf("@drawText && !useLayerName"), Indent]
		[HideLabel]
        public string overrideText;
        [TabGroup("Label")]
		[Indent]
		[EnumToggleButtons]
        [ShowIf("@drawText && !useLayerName")]
		[HideLabel]
		[HideInInspector]
        public TextAnchor textAnchor = TextAnchor.MiddleRight;
		
        [TabGroup("Decoration")]
		[HideLabel]
        public bool decoration;
        [TabGroup("Decoration")]
        [ShowIf("decoration"),EnumToggleButtons, Indent(1)]
		[HideLabel]
        public Decoration decorationType = Decoration.Right;
        [TabGroup("Decoration")]
		[ColorPalette]
        [ShowIf("decoration"), Indent(1)]
		[HideLabel]
        public Color decorationColor = Colors.green;
    }

    public Stylization MatchSettingsWithGameObject(GameObject go)
    {
        return stylizations.reversed()?.FirstOrDefault(s =>
		{
            return
				(
					!s.prefabInstancesOnly ||
					go.isInstanceOfPrefabAsset()
				) &&
				(
					!s.useStringContainmentConditions ||
					(
						(
							s.nameContains.isEmptyOrNull() ||
							(go.name?.Contains(s.nameContains) ?? false)
						) &&
						(
							s.layerContains.isEmptyOrNull() ||
							(go.layerName()?.Contains(s.layerContains) ?? false)
						) &&
						(
							s.scene.isEmptyOrNull() ||
							go.scene.name.contains(s.scene)
						) &&
						(
							s.component.isEmptyOrNull() ||
							go.hasAny<Component>(component =>
								component.hasAnySelfOrInheritedSimpleClassName_ViaReflection(simpleClassName =>
									simpleClassName.contains(s.component)))
						) &&
						(
							s.attribute.isEmptyOrNull() ||
							go.hasAny<Component>(component =>
								component.hasAnyAttributesOfType_ViaAdditionalReflection<Attribute>(attribute =>
									attribute.simpleClassName_ViaReflection().contains(s.attribute)))
						)
					)
				) &&
				(
					s.component_matching.isEmptyOrNull() ||
					go.hasAny<Component>(component =>
						component.hasAnySelfOrInheritedSimpleClassName_ViaReflection(simpleClassName =>
							simpleClassName.matches(s.component_matching)))
				);
        });
    }

}
#endif
#endif