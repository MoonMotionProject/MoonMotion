using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rectangle Extensions:
// • provides extension methods for handling rectangles
public static class RectangleExtensions
{
	public static Rect setPositionXTo(this Rect rectangle, float x)
	{
		rectangle.x = x;
		return rectangle;
	}
	public static Rect displacePositionXBy(this Rect rectangle, float xDisplacement)
		=> rectangle.setPositionXTo(rectangle.x + xDisplacement);

	public static Rect setPositionYTo(this Rect rectangle, float y)
	{
		rectangle.y = y;
		return rectangle;
	}
	public static Rect displacePositionYBy(this Rect rectangle, float yDisplacement)
		=> rectangle.setPositionYTo(rectangle.y + yDisplacement);


	public static Rect setWidthTo(this Rect rectangle, float width)
	{
		rectangle.width = width;
		return rectangle;
	}
	public static Rect reduceWidthBy(this Rect rectangle, float widthReduction)
		=> rectangle.setWidthTo(rectangle.width - widthReduction);

	public static Rect setHeightTo(this Rect rectangle, float height)
	{
		rectangle.height = height;
		return rectangle;
	}
	public static Rect reduceHeightBy(this Rect rectangle, float heightReduction)
		=> rectangle.setHeightTo(rectangle.height - heightReduction);
}