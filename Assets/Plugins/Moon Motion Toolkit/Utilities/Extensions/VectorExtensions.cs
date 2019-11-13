using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Vector Extensions: provides extension methods for handling vectors
// #fundamentals #numbers
public static class VectorExtensions
{
	#region equality

	// method: return whether this given vector matches (is equal to) the other given vector //
	public static bool matches(this Vector3 vector, Vector3 otherVector)
		=> vector == otherVector;

	// method: return whether this given vector does not match the other given vector //
	public static bool doesNotMatch(this Vector3 vector, Vector3 otherVector)
		=> !vector.matches(otherVector);
	#endregion equality


	#region accessing

	// method: return the accessor for the x values of these given vectors //
	public static IEnumerable<float> accessXValues(this IEnumerable<Vector3> vectors)
		=> vectors.access(vector => vector.x);
	// method: return the list of x values of these given vectors //
	public static List<float> xValues(this IEnumerable<Vector3> vectors)
		=> vectors.accessXValues().manifested();

	// method: return the accessor for the y values of these given vectors //
	public static IEnumerable<float> accessYValues(this IEnumerable<Vector3> vectors)
		=> vectors.access(vector => vector.y);
	// method: return the list of y values of these given vectors //
	public static List<float> yValues(this IEnumerable<Vector3> vectors)
		=> vectors.accessYValues().manifested();

	// method: return the accessor for the z values of these given vectors //
	public static IEnumerable<float> accessZValues(this IEnumerable<Vector3> vectors)
		=> vectors.access(vector => vector.z);
	// method: return the list of z values of these given vectors //
	public static List<float> zValues(this IEnumerable<Vector3> vectors)
		=> vectors.accessZValues().manifested();
	#endregion accessing


	#region vectrals

	// method: return the vectral (normalized form) of this given vector //
	public static Vector3 vectral(this Vector3 vector)
		=> vector.normalized;
	#endregion vectrals


	#region magnitude manipulation

	// method: return this given vector with the given target magnitude //
	public static Vector3 withMagnitudeOf(this Vector3 vector, float targetMagnitude)
		=> vector.vectral() * targetMagnitude;
	#endregion magnitude manipulation


	#region vectral manipulation

	// method: return the result of the given function on this given vector, ensured to have the same magnitude this given vector started with, unless all axes became zeroed by the function //
	public static Vector3 withSameMagnitudeAfter(this Vector3 vector, Func<Vector3, Vector3> function)
		=> function(vector).withMagnitudeOf(vector.magnitude);

	// method: return this given vector with its x axis zeroed but its overall magnitude maintained (unless all axes became zeroed by zeroing its x axis) //
	public static Vector3 withVectralXZeroed(this Vector3 vector)
		=> vector.withSameMagnitudeAfter(vector_ => vector_.withXZero());

	// method: return this given vector with its y axis zeroed but its overall magnitude maintained (unless all axes became zeroed by zeroing its y axis) //
	public static Vector3 withVectralYZeroed(this Vector3 vector)
		=> vector.withSameMagnitudeAfter(vector_ => vector_.withYZero());

	// method: return this given vector with its z axis zeroed but its overall magnitude maintained (unless all axes became zeroed by zeroing its z axis) //
	public static Vector3 withVectralZZeroed(this Vector3 vector)
		=> vector.withSameMagnitudeAfter(vector_ => vector_.withZZero());
	#endregion vectral manipulation


	#region directionality

	// method: return the directionality of this given vector with the other given vector (such that 1 is for same directions, -1 is for opposite directions, and 0 is for perpendicular directions) //
	public static float directionalityWith(this Vector3 vector, Vector3 otherVector)
		=> Vector3.Dot(vector, otherVector);

	// method: return the sign of the directionality of this given vector with the other given vector //
	public static float directionalitySignWith(this Vector3 vector, Vector3 otherVector)
		=> vector.directionalityWith(otherVector).toInteger();

	// method: return the boolean for the directionality of this given vector with the other given vector (such that true is for a positive directionality sign) //
	public static bool directionalityBooleanWith(this Vector3 vector, Vector3 otherVector)
		=> vector.directionalityWith(otherVector).isPositive();
	#endregion directionality


	#region validity determination
	
	public static bool isFinite(this Vector3 vector)
		=> vector.x.isFinite() && vector.y.isFinite() && vector.z.isFinite();
	#endregion validity determination


	#region sign determination

	// method: return whether this given vector is all zeroes //
	public static bool isZeroes(this Vector3 vector)
		=> (vector.x.isZero() && vector.y.isZero() && vector.z.isZero());

	// method: return whether this given vector is nonnegative //
	public static bool isNonnegative(this Vector3 vector)
		=> (vector.x.isNonnegative() && vector.y.isNonnegative() && vector.z.isNonnegative());
	#endregion sign determination


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


	#region sign manipulation

	public static Vector3 magnitudes(this Vector3 vector)
		=> new Vector3(vector.x.magnitude(), vector.y.magnitude(), vector.z.magnitude());
	#endregion sign manipulation


	#region value replacement

	// method: (according to the given boolean:) return this given vector but with its x value set to the given x value //
	public static Vector3 withX(this Vector3 vector, float x, bool boolean = true)
		=> (boolean ? new Vector3(x, vector.y, vector.z) : vector);
	// method: (according to the given boolean:) return this given vector but with its x value set to the x position of the specified singleton behaviour //
	public static Vector3 withXOf<SingletonBehaviourT>(this Vector3 vector, float x, bool boolean = true) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=>	vector.withX(SingletonBehaviour<SingletonBehaviourT>.positionX,
				boolean);

	// method: (according to the given boolean:) return this given vector but with its y value set to the given y value //
	public static Vector3 withY(this Vector3 vector, float y, bool boolean = true)
		=> (boolean ? new Vector3(vector.x, y, vector.z) : vector);
	// method: (according to the given boolean:) return this given vector but with its y value set to the y position of the specified singleton behaviour //
	public static Vector3 withYOf<SingletonBehaviourT>(this Vector3 vector, bool boolean = true) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=>	vector.withY(SingletonBehaviour<SingletonBehaviourT>.positionY,
				boolean);

	// method: (according to the given boolean:) return this given vector but with its z value set to the given z value //
	public static Vector3 withZ(this Vector3 vector, float z, bool boolean = true)
		=> (boolean ? new Vector3(vector.x, vector.y, z) : vector);
	// method: (according to the given boolean:) return this given vector but with its z value set to the z position of the specified singleton behaviour //
	public static Vector3 withZOf<SingletonBehaviourT>(this Vector3 vector, bool boolean = true) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=>	vector.withZ(SingletonBehaviour<SingletonBehaviourT>.positionZ,
				boolean);
	
	// method: return this given vector but with its x value set to zero //
	public static Vector3 withXZero(this Vector3 vector)
		=> vector.withX(0f);
	// method: (according to the given boolean:) return this given vector but with its x value set to zero //
	public static Vector3 withXZeroIf(this Vector3 vector, bool boolean = true)
		=> vector.withX(0f, boolean);

	// method: return this given vector but with its y value set to zero //
	public static Vector3 withYZero(this Vector3 vector)
		=> vector.withY(0f);
	// method: (according to the given boolean:) return this given vector but with its y value set to zero //
	public static Vector3 withYZeroIf(this Vector3 vector, bool boolean = true)
		=> vector.withY(0f, boolean);
	
	// method: return this given vector but with its z value set to zero //
	public static Vector3 withZZero(this Vector3 vector)
		=> vector.withZ(0f);
	// method: (according to the given boolean:) return this given vector but with its z value set to zero //
	public static Vector3 withZZeroIf(this Vector3 vector, bool boolean = true)
		=> vector.withZ(0f, boolean);
	
	// method: return this given vector but with its x and z values both set to zero //
	public static Vector3 withXAndZZero(this Vector3 vector)
		=> vector.withXZero().withZZero();
	#endregion value replacement


	#region handling zeroness

	// method: if this given vector has only zeroes, return the other given vector; otherwise, return the result of the given function //
	public static Vector3 ifOnlyZeroesThen(this Vector3 vector, Func<Vector3> function)
		=>	vector.isZeroes() ?
				function() :
				vector;
	#endregion handling zeroness


	#region math operations

	public static Vector3 halved(this Vector3 vector)
		=> (vector / 2f);

	public static Vector3 doubled(this Vector3 vector)
		=> (vector * 2f);

	// method: return the average (value) of this given vector //
	public static float average(this Vector3 vector)
		=> vector.toArray().average();

	// method: return the average x coordinate value of these given vectors //
	public static float averageX(this IEnumerable<Vector3> vectors)
		=> vectors.accessXValues().average();

	// method: return the average y coordinate value of these given vectors //
	public static float averageY(this IEnumerable<Vector3> vectors)
		=> vectors.accessYValues().average();

	// method: return the average z coordinate value of these given vectors //
	public static float averageZ(this IEnumerable<Vector3> vectors)
		=> vectors.accessZValues().average();

	// method: return an accessor for the averages (average values) corresponding to these given vectors //
	public static IEnumerable<float> accessAverages(this IEnumerable<Vector3> vectors)
		=> vectors.access(vector => vector.average());
	// method: return a list of averages (average values) corresponding to these given vectors //
	public static List<float> averages(this IEnumerable<Vector3> vectors)
		=> vectors.accessAverages().manifested();

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

	// method: return this given vector multiplied by the other given vector (axis-respectively) //
	public static Vector3 multiplyBy(this Vector3 vector, Vector3 otherVector)
		=> new Vector3(vector.x * otherVector.x, vector.y * otherVector.y, vector.z * otherVector.z);
	#endregion math operations


	#region conversion

	// method: return the float array corresponding to this given vector //
	public static float[] toArray(this Vector3 vector)
		=> new float[] {vector.x, vector.y, vector.z};

	// method: return a floats collection of the specified type created from this given vector's values //
	public static ICollectionT to<ICollectionT>(this Vector3 vector) where ICollectionT : ICollection<float>, new()
		=> new ICollectionT() {vector.x, vector.y, vector.z};

	// method: return the doubles vector corresponding to this given floats vector //
	public static DoublesVector toDoublesVector(this Vector3 floatsVector)
		=> new DoublesVector(floatsVector.x, floatsVector.y, floatsVector.z);

	// method: return the floats vector corresponding to this given doubles vector //
	public static Vector3 toFloatsVector(this DoublesVector doublesVector)
		=> new Vector3(doublesVector.x.toFloat(), doublesVector.y.toFloat(), doublesVector.z.toFloat());
	#endregion conversion
}