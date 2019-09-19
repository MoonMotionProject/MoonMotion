using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// Forcer
// • classifies this behaviour as a forcer
// #force
public abstract class	Forcer<ForcerT> :
					EnabledsBehaviour<ForcerT>
						where ForcerT : Forcer<ForcerT>
{
	// variables //


	// settings //
	
	[BoxGroup("Editor Visualization")]
	[Tooltip("the color to use for editor visualization")]
	public Color visualizationColor = Default.visualizationColor;
}