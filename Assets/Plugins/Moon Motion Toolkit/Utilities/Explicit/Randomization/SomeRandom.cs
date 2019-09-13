using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Some Random: provides properties returning random state //
public static class SomeRandom
{
	public static Color color =>	new Color
									(
										RandomlyGenerate.within(0f, 1f),
										RandomlyGenerate.within(0f, 1f),
										RandomlyGenerate.within(0f, 1f)
									);
}