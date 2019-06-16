using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Label Type Extensions: provides extension methods for handling label types //
public static class LabelTypeExtensions
{
	public static bool isName(this LabelType labelType)
		=> (labelType == LabelType.name);

	public static bool isTag(this LabelType labelType)
		=> (labelType == LabelType.tag);

	public static bool isLayerName(this LabelType labelType)
		=> (labelType == LabelType.layerName);
}