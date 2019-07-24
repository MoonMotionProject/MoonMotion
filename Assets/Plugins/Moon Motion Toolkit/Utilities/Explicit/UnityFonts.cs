using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

// Unity Fonts: provides properties for Unity fonts //
public static class UnityFonts
{
	public static Font newTextComponent => Hierarchy.createTemporaryObject().addGet<Text>().font;
}