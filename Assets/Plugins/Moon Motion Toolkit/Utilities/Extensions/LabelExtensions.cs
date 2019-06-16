using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Label Extensions: provides extension methods for handling labels //
public static class LabelExtensions
{
	public static bool hasLabelThatMatches(this Transform transform, string label, LabelType labelType)
	{
		if (labelType.isName())
		{
			return transform.nameMatches(label);
		}
		else if (labelType.isTag())
		{
			return transform.tagMatches(label);
		}
		else if (labelType.isLayerName())
		{
			return transform.layerMatches(label);
		}
		else
		{
			return false.returnWithError(System.Reflection.MethodBase.GetCurrentMethod().Name+" did not receive valid 'labelType' argument");
		}
	}
	public static bool hasLabelThatContains(this Transform transform, string string_, LabelType labelType)
	{
		if (labelType.isName())
		{
			return transform.nameContains(string_);
		}
		else if (labelType.isTag())
		{
			return transform.tagContains(string_);
		}
		else if (labelType.isLayerName())
		{
			return transform.layerContains(string_);
		}
		else
		{
			return false.returnWithError(System.Reflection.MethodBase.GetCurrentMethod().Name+" did not receive valid 'labelType' argument");
		}
	}
	public static bool hasLabelThatMatchesOrContains(this Transform transform, string string_, LabelType labelType, bool matchesVersusContains)
	{
		if (labelType.isName())
		{
			return transform.nameMatchesOrContains(string_, matchesVersusContains);
		}
		else if (labelType.isTag())
		{
			return transform.tagMatchesOrContains(string_, matchesVersusContains);
		}
		else if (labelType.isLayerName())
		{
			return transform.layerMatchesOrContains(string_, matchesVersusContains);
		}
		else
		{
			return false.returnWithError(System.Reflection.MethodBase.GetCurrentMethod().Name+" did not receive valid 'labelType' argument");
		}
	}
	public static GameObject selfOrParentWithLabelThatMatchesOrContains(this GameObject gameObject, string string_, LabelType labelType, bool matchesVersusContains)
	{
		Transform transformAtCurrentLevel = gameObject.transform;
		if (transformAtCurrentLevel.hasLabelThatMatchesOrContains(string_, labelType, matchesVersusContains))
		{
			return gameObject;
		}

		while (transformAtCurrentLevel.parent)
		{
			Transform parentTransform = transformAtCurrentLevel.parent;
			if (parentTransform.hasLabelThatMatchesOrContains(string_, labelType, matchesVersusContains))
			{
				return parentTransform.gameObject;
			}

			transformAtCurrentLevel = parentTransform;
		}

		return null;
	}
}