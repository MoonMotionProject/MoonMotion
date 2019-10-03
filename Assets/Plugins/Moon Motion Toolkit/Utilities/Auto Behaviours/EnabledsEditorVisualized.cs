using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Enableds Editor Visualized
// • provides this behaviour with enableds behaviour features and a visualization color setting
public abstract class	EnabledsEditorVisualized<EnabledsEditorVisualizedT> :
					EnabledsBehaviour<EnabledsEditorVisualizedT>
						where EnabledsEditorVisualizedT : EnabledsEditorVisualized<EnabledsEditorVisualizedT>
{
	// variables //


	// settings //
	
	[BoxGroup("Editor Visualization")]
	[Tooltip("the color to use for editor visualization")]
	public Color visualizationColor = Default.visualizationColor;
}