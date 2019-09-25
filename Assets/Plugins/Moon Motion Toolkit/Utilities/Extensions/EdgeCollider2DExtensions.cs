using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Edge Collider 2D Extensions: provides extension methods for handling edge colliders
// #collision
public static class EdgeCollider2DExtensions
{
	#region setting points
	// methods: set this given edge collider's points to the given points, then return this given edge collider //

	public static EdgeCollider2D setPointsTo(this EdgeCollider2D edgeCollider, params Vector2[] points)
		=> edgeCollider.after(()=>
			edgeCollider.points = points);
	
	public static EdgeCollider2D setPointsTo(this EdgeCollider2D edgeCollider, IEnumerable<Vector2> points)
		=> edgeCollider.setPointsTo(points.toArray());
	#endregion setting points
}