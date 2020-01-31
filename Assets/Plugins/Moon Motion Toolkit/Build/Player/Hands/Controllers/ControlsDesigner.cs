#if ODIN_INSPECTOR
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using Sirenix.Utilities.Editor;

// #unitology #window
public class ControlsDesigner : OdinEditorWindow
{
	#region window

	[MenuItem("Window/Controls Designer")]
    private static void show()
		=> GetWindow<ControlsDesigner>().Show();
	#endregion window


	#region content
	
	private void reloadCustomControllerOperations()
	{
		if (SirenixEditorGUI.ToolbarButton(EditorIcons.Refresh))
		{
			customControllerOperations_
				= Assets.notFromMoonMotionToolkitManifestedOfType_ViaReflection<ControllerOperation>();
			Play.listReloadedAudio();
		}
	}
	private List<ControllerOperation> reloadedCustomControllerOperations
	{
		get
		{
			reloadCustomControllerOperations();
			return customControllerOperations_;
		}
	}
	[SerializeField]
	[HideInInspector]
	private List<ControllerOperation> customControllerOperations_ = null;
	[PropertyOrder(-3)]
	[ListDrawerSettings(IsReadOnly = true, OnTitleBarGUI = "reloadCustomControllerOperations")]
	[HideReferenceObjectPicker]
    [ListItemSelector("customControllerOperations_ViaReflection_SetSelected")]
	[LabelText("Custom Controller Operations")]
	[ShowInInspector]
	public List<ControllerOperation> customControllerOperations_ViaReflection
	{
		get
		{
			return	customControllerOperations_.isYull() ?
						customControllerOperations_ :
						reloadedCustomControllerOperations;
		}
		private set {}
	}

	#region selected custom controller operation
	[PropertyOrder(-2)]
	[InlineEditor(InlineEditorModes.LargePreview, InlineEditorObjectFieldModes.CompletelyHidden, Expanded = true)]
	[HideLabel]
    [ShowInInspector]
	private ControllerOperation customControllerOperations_ListItemSelected_Preview => customControllerOperations_ListItemSelected;
	
	[PropertyOrder(-1)]
	[InlineEditor(InlineEditorModes.GUIAndHeader, InlineEditorObjectFieldModes.CompletelyHidden, Expanded = true)]
	[HideLabel]
    [ShowInInspector]
	#pragma warning disable 0414
    private ControllerOperation customControllerOperations_ListItemSelected;
	#pragma warning restore 0414
	public void customControllerOperations_ViaReflection_SetSelected(int index)
		=> customControllerOperations_ListItemSelected = customControllerOperations_ViaReflection.itemOtherwiseDefault(index);
	#endregion selected custom controller operation
	#endregion content
}
#endif
#endif