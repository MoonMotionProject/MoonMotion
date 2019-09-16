using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Line Renderer Extensions: provides extension methods for handling line renderers //
public static class LineRendererExtensions
{
	#region setting starting and ending widths

	// method: set this given line renderer's starting width to the given target starting width, then return this given line renderer //
	public static LineRenderer setStartingWidthTo(this LineRenderer lineRenderer, float targetStartingWidth)
		=> lineRenderer.after(()=>
			lineRenderer.startWidth = targetStartingWidth);

	// method: set this given line renderer's ending width to the given target ending width, then return this given line renderer //
	public static LineRenderer setEndingWidthTo(this LineRenderer lineRenderer, float targetEndingWidth)
		=> lineRenderer.after(()=>
			lineRenderer.endWidth = targetEndingWidth);

	// method: set this given line renderer's starting width and ending width to the given target starting width and ending width (respectively), then return this given line renderer //
	public static LineRenderer setStartingAndEndingWidthsTo(this LineRenderer lineRenderer, float targetStartingWidth, float targetEndingWidth)
		=> lineRenderer.setStartingWidthTo(targetStartingWidth).setEndingWidthTo(targetEndingWidth);

	// method: set this given line renderer's starting width and ending width both to the given target width, then return this given line renderer //
	public static LineRenderer setStartingAndEndingWidthsTo(this LineRenderer lineRenderer, float targetWidth)
		=> lineRenderer.setStartingAndEndingWidthsTo(targetWidth, targetWidth);
	#endregion setting starting and ending widths
}