using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dimensionality: provides methods for handling dimensionality //
public static class Dimensionality
{
	#region encoding
	// (determining the dimensions of a particular dimensionality corresponding to another (original) particular dimensionality as an encoding (such that if dimensional measurements used to encode are remembered, the dimensions of the original dimensionality can be recovered))
	// (not the same kind of correspondence as seen when visualizing "flattening" and "unflattening" of dimensionality)


	// method: return the integer as 1D corresponding-encodedly to the given x any y integers as 2D //
	public static int encode2DTo1D(int x, int y, int width)
		=> (y * width) + x;
	#endregion encoding
}