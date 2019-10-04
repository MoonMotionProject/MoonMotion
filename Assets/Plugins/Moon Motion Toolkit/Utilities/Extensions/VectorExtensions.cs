using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Vector Extensions: provides extension methods for handling vectors //
public static class VectorExtensions
{
	#region accessing

	// method: return the selection of x values of these given vectors //
	public static IEnumerable<float> selectXValues(this IEnumerable<Vector3> vectors)
		=> vectors.select(vector => vector.x);
	// method: return the list of x values of these given vectors //
	public static List<float> xValues(this IEnumerable<Vector3> vectors)
		=> vectors.selectXValues().manifested();

	// method: return the selection of y values of these given vectors //
	public static IEnumerable<float> selectYValues(this IEnumerable<Vector3> vectors)
		=> vectors.select(vector => vector.y);
	// method: return the list of y values of these given vectors //
	public static List<float> yValues(this IEnumerable<Vector3> vectors)
		=> vectors.selectYValues().manifested();

	// method: return the selection of z values of these given vectors //
	public static IEnumerable<float> selectZValues(this IEnumerable<Vector3> vectors)
		=> vectors.select(vector => vector.z);
	// method: return the list of z values of these given vectors //
	public static List<float> zValues(this IEnumerable<Vector3> vectors)
		=> vectors.selectZValues().manifested();
	#endregion accessing


	#region vectrals

	// method: return the vectral (normalized form) of this given vector //
	public static Vector3 vectral(this Vector3 vector)
		=> vector.normalized;
	#endregion vectrals


	#region clamping

	public static Vector3 atLeast(this Vector3 vector, Vector3 otherVector, bool boolean = true)
	{
		if (boolean)
		{
			return Vector3.Max(vector, otherVector);
		}
		return vector;
	}

	public static Vector3 atMost(this Vector3 vector, Vector3 otherVector, bool boolean = true)
	{
		if (boolean)
		{
			return Vector3.Min(vector, otherVector);
		}
		return vector;
	}

	public static Vector3 clampedFiniteAndNonnegative(this Vector3 vector)
		=> new Vector3(vector.x.clampedFiniteAndNonnegative(), vector.y.clampedFiniteAndNonnegative(), vector.z.clampedFiniteAndNonnegative());
	#endregion clamping


	#region validity determination
	
	public static bool isFinite(this Vector3 vector)
		=> vector.x.isFinite() && vector.y.isFinite() && vector.z.isFinite();
	#endregion validity determination


	#region sign determination

	// method: return whether this given vector is nonnegative //
	public static bool isNonnegative(this Vector3 vector)
		=> (vector.x.isNonnegative() && vector.y.isNonnegative() && vector.z.isNonnegative());
	#endregion sign determination


	#region directionality

	// method: return the directionality ratio of this given vector with the other given vector //
	public static float directionalityWith(this Vector3 vector, Vector3 otherVector)
		=> Vector3.Dot(vector, otherVector);

	// method: return the sign of the directionality ratio of this given vector with the other given vector //
	public static float directionalitySignWith(this Vector3 vector, Vector3 otherVector)
		=> vector.directionalityWith(otherVector).toInteger();
	#endregion directionality


	#region value replacement

	// method: (according to the given boolean:) return this given vector but with its x value set to the given x value //
	public static Vector3 withX(this Vector3 vector, float x, bool boolean = true)
		=> (boolean ? new Vector3(x, vector.y, vector.z) : vector);

	// method: (according to the given boolean:) return this given vector but with its y value set to the given y value //
	public static Vector3 withY(this Vector3 vector, float y, bool boolean = true)
		=> (boolean ? new Vector3(vector.x, y, vector.z) : vector);

	// method: (according to the given boolean:) return this given vector but with its z value set to the given z value //
	public static Vector3 withZ(this Vector3 vector, float z, bool boolean = true)
		=> (boolean ? new Vector3(vector.x, vector.y, z) : vector);

	// method: (according to the given boolean:) return this given vector but with its x value set to zero //
	public static Vector3 withXZero(this Vector3 vector, bool boolean = true)
		=> vector.withX(0f, boolean);

	// method: (according to the given boolean:) return this given vector but with its y value set to zero //
	public static Vector3 withYZero(this Vector3 vector, bool boolean = true)
		=> vector.withY(0f, boolean);

	// method: (according to the given boolean:) return this given vector but with its z value set to zero //
	public static Vector3 withZZero(this Vector3 vector, bool boolean = true)
		=> vector.withZ(0f, boolean);
	#endregion value replacement


	#region math operations

	// method: return the average (value) of this given vector //
	public static float average(this Vector3 vector)
		=> vector.toArray().average();

	// method: return the average x coordinate value of these given vectors //
	public static float averageX(this IEnumerable<Vector3> vectors)
		=> vectors.selectXValues().average();

	// method: return the average y coordinate value of these given vectors //
	public static float averageY(this IEnumerable<Vector3> vectors)
		=> vectors.selectYValues().average();

	// method: return the average z coordinate value of these given vectors //
	public static float averageZ(this IEnumerable<Vector3> vectors)
		=> vectors.selectZValues().average();

	// method: return a selection of averages (average values) corresponding to these given vectors //
	public static IEnumerable<float> selectAverages(this IEnumerable<Vector3> vectors)
		=> vectors.select(vector => vector.average());
	// method: return a list of averages (average values) corresponding to these given vectors //
	public static List<float> averages(this IEnumerable<Vector3> vectors)
		=> vectors.selectAverages().manifested();

	// method: determine the average value of these given vectors //
	public static float averageValue(this IEnumerable<Vector3> vectors)
		=> vectors.average().average();

	// method: determine the average (vector) of these given vectors //
	public static Vector3 average(this IEnumerable<Vector3> vectors)
		=> new Vector3
		(
			vectors.averageX(),
			vectors.averageY(),
			vectors.averageZ()
		);
	#endregion math operations


	#region conversion

	// method: return the float array corresponding to this given vector //
	public static float[] toArray(this Vector3 vector)
		=> new float[] {vector.x, vector.y, vector.z};

	// method: return a floats collection of the specified type created from this given vector's values //
	public static ICollectionT to<ICollectionT>(this Vector3 vector) where ICollectionT : ICollection<float>, new()
		=> new ICollectionT() {vector.x, vector.y, vector.z};

	// method: return the doubles vector corresponding to this given floats vector //
	public static Vector toDoublesVector(this Vector3 floatsVector)
		=> new Vector(floatsVector.x, floatsVector.y, floatsVector.z);

	// method: return the floats vector corresponding to this given doubles vector //
	public static Vector3 toFloatsVector(this Vector doublesVector)
		=> new Vector3(doublesVector.x.toFloat(), doublesVector.y.toFloat(), doublesVector.z.toFloat());
	#endregion conversion
}