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


	#region setting number of points

	// method: set this given line renderer's number of points to the given number of points, then return this given line renderer //
	public static LineRenderer setNumberOfPointsTo(this LineRenderer lineRenderer, int numberOfPoints)
		=> lineRenderer.after(()=>
			lineRenderer.positionCount = numberOfPoints);
	#endregion setting number of points


	#region setting points
	
	// method: set this given line renderer's point at the given index to the given point, then return this given line renderer //
	public static LineRenderer setPointAtIndex(this LineRenderer lineRenderer, int index, Vector2 point)
		=> lineRenderer.after(()=>
			lineRenderer.SetPosition(index, point));
	// method: set this given line renderer's point at the given index to the given position, then return this given line renderer //
	public static LineRenderer setPointAtIndex(this LineRenderer lineRenderer, int index, Vector3 position)
		=> lineRenderer.after(()=>
			lineRenderer.SetPosition(index, position));
	// method: set this given line renderer's first point to the given position, then return this given line renderer //
	public static LineRenderer setFirstPointTo(this LineRenderer lineRenderer, Vector3 position)
		=> lineRenderer.setPointAtIndex(0, position);
	// method: set this given line renderer's second point to the given position, then return this given line renderer //
	public static LineRenderer setSecondPointTo(this LineRenderer lineRenderer, Vector3 position)
		=> lineRenderer.setPointAtIndex(1, position);
	// method: set this given line renderer's first and second points to the given first and second positions (respectively), then return this given line renderer //
	public static LineRenderer setFirstTwoPointsTo(this LineRenderer lineRenderer, Vector3 firstPosition, Vector3 secondPosition)
		=>	lineRenderer
				.setFirstPointTo(firstPosition)
				.setSecondPointTo(secondPosition);
	// method: set this given line renderer's first and second points to the given provided first and second positions (respectively), then return this given line renderer //
	public static LineRenderer setFirstTwoPointsTo(this LineRenderer lineRenderer, object firstPosition_PositionProvider, object secondPosition_PositionProvider)
	{
		Vector3 firstPosition = Provide.positionVia(firstPosition_PositionProvider);
		Vector3 secondPosition = Provide.positionVia(secondPosition_PositionProvider);

		return lineRenderer.setFirstTwoPointsTo(firstPosition, secondPosition);
	}
	// method: set this given line renderer's first and second points according to the line from the given provided starting transform along the given local direction relative to the given provided starting transform, for the given distance, then return this given line renderer //
	public static LineRenderer setFirstTwoPointsForLineLocallyDirectedFrom(this LineRenderer lineRenderer, object startingTransform_TransformProvider, Vector3 localDirection, float distance)
	{
		Transform startingTransform = Provide.transformVia(startingTransform_TransformProvider);

		return lineRenderer.positionGlobally().setFirstTwoPointsTo
		(
			startingTransform,
			startingTransform.positionAlongLocal(localDirection, distance)
		);
	}
	#endregion setting points
	

	#region setting distinctivity

	// method: set this given line renderer's distinctivity to the given distinctivity, then return this given line renderer //
	public static LineRenderer setDistinctivityTo(this LineRenderer lineRenderer, Distinctivity distinctivity)
		=> lineRenderer.after(()=>
			lineRenderer.useWorldSpace = distinctivity.isAbsolute());

	// method: set this given line renderer's distinctivity to absolute, then return this given line renderer //
	public static LineRenderer positionGlobally(this LineRenderer lineRenderer)
		=> lineRenderer.setDistinctivityTo(Distinctivity.absolute);

	// method: set this given line renderer's distinctivity to relative, then return this given line renderer //
	public static LineRenderer positionLocally(this LineRenderer lineRenderer)
		=> lineRenderer.setDistinctivityTo(Distinctivity.relative);
	#endregion setting distinctivity


	#region setting starting and ending colors

	// method: set this given line renderer's starting color to the given color, then return this given line renderer //
	public static LineRenderer setStartingColorTo(this LineRenderer lineRenderer, Color color)
		=> lineRenderer.after(()=>
			lineRenderer.startColor = color);

	// method: set this given line renderer's ending color to the given color, then return this given line renderer //
	public static LineRenderer setEndingColorTo(this LineRenderer lineRenderer, Color color)
		=> lineRenderer.after(()=>
			lineRenderer.endColor = color);

	// method: set this given line renderer's starting and ending colors both to the given color, then return this given line renderer //
	public static LineRenderer setStartingAndEndingColorsTo(this LineRenderer lineRenderer, Color color)
		=> lineRenderer.setStartingColorTo(color).setEndingColorTo(color);

	// method: set this given line renderer's starting and ending colors both to its (first) material's color, then return this given line renderer //
	public static LineRenderer setStartingAndEndingColorsToColorOfMaterial(this LineRenderer lineRenderer)
		=> lineRenderer.setStartingAndEndingColorsTo(lineRenderer.material.color);
	#endregion setting starting and ending colors


	#region line of light setup
	
	public static LineRenderer setupAsLineOfLightLocallyDirectedFrom(this LineRenderer lineRenderer, object startingTransform_TransformProvider, Vector3 localDirection, float distance, Material material)
	{
		Transform startingTransform = Provide.transformVia(startingTransform_TransformProvider);

		return lineRenderer
			.nonshadowcast()
			.nonshadowable()
			.setMaterialTo(material)
			.setFirstTwoPointsForLineLocallyDirectedFrom(startingTransform, localDirection, distance)
			.setStartingAndEndingWidthsTo(Default.lineRendererWidth)
			.setStartingAndEndingColorsToColorOfMaterial();
	}
	#endregion line of light setup
}