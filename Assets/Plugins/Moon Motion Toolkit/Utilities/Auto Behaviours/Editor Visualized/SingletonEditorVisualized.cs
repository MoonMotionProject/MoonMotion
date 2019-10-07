using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Singleton Editor Visualized
// • provides this behaviour with singleton behaviour features and a visualization color setting
public abstract class	SingletonEditorVisualized<SingletonEditorVisualizedT> :
					SingletonBehaviour<SingletonEditorVisualizedT>
						where SingletonEditorVisualizedT : SingletonEditorVisualized<SingletonEditorVisualizedT>
{
	// variables //


	// settings //
	
	[BoxGroup("Editor Visualization")]
	[Tooltip("the color to use for editor visualization")]
	public Color visualizationColor = Default.visualizationColor;
}