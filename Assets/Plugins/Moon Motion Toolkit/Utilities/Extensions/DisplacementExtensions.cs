using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Displacement Extensions: provides extension methods for handling displacements (directional distances) //
public static class DisplacementExtensions
{
	#region from other
	// methods: return the displacement from the other given provided vector/position, specified singleton behaviour, or the main camera (respectively) to this given provided vector/position //
	
	public static Vector3 displacementFrom(this Vector3 position, Vector3 otherPosition)
		=> position - otherPosition;
	public static Vector3 displacementFrom(this Vector3 position, object otherPosition_PositionProvider)
		=> position.displacementFrom(otherPosition_PositionProvider.providePosition());
	public static Vector3 displacementFrom<SingletonBehaviourT>(this Vector3 position) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> position.displacementFrom(SingletonBehaviour<SingletonBehaviourT>.position);
	public static Vector3 displacementFromCamera(this Vector3 position)
		=> position.displacementFrom(Camera.main);
	
	public static Vector3 displacementFrom(this GameObject gameObject, object otherPosition_PositionProvider)
		=> gameObject.position().displacementFrom(otherPosition_PositionProvider);
	public static Vector3 displacementFrom<SingletonBehaviourT>(this GameObject gameObject) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> gameObject.displacementFrom(SingletonBehaviour<SingletonBehaviourT>.position);
	public static Vector3 displacementFromCamera(this GameObject gameObject)
		=> gameObject.position().displacementFromCamera();
	
	public static Vector3 displacementFrom(this Component component, object otherPosition_PositionProvider)
		=> component.position().displacementFrom(otherPosition_PositionProvider);
	public static Vector3 displacementFrom<SingletonBehaviourT>(this Component component) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> component.displacementFrom(SingletonBehaviour<SingletonBehaviourT>.position);
	public static Vector3 displacementFromCamera(this Component component)
		=> component.position().displacementFromCamera();
	#endregion from other


	#region to other
	// methods: return the displacement to the other given provided vector/position, specified singleton behaviour, or the main camera (respectively) from this given provided vector/position //
	
	public static Vector3 displacementTo(this Vector3 vector, Vector3 otherVector)
		=> otherVector - vector;
	public static Vector3 displacementTo(this Vector3 position, object otherPosition_PositionProvider)
		=> position.displacementTo(otherPosition_PositionProvider.providePosition());
	public static Vector3 displacementTo<SingletonBehaviourT>(this Vector3 position) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> position.displacementTo(SingletonBehaviour<SingletonBehaviourT>.position);
	public static Vector3 displacementToCamera(this Vector3 position)
		=> position.displacementTo(Camera.main);
	
	public static Vector3 displacementTo(this GameObject gameObject, object otherPosition_PositionProvider)
		=> gameObject.position().displacementTo(otherPosition_PositionProvider);
	public static Vector3 displacementTo<SingletonBehaviourT>(this GameObject gameObject) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> gameObject.displacementTo(SingletonBehaviour<SingletonBehaviourT>.position);
	public static Vector3 displacementToCamera(this GameObject gameObject)
		=> gameObject.position().displacementToCamera();
	
	public static Vector3 displacementTo(this Component component, object otherPosition_PositionProvider)
		=> component.position().displacementTo(otherPosition_PositionProvider);
	public static Vector3 displacementTo<SingletonBehaviourT>(this Component component) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> component.displacementTo(SingletonBehaviour<SingletonBehaviourT>.position);
	public static Vector3 displacementToCamera(this Component component)
		=> component.position().displacementToCamera();
	#endregion to other


	#region with displacement
	// methods: return this given provided position with the given displacement added //

	public static Vector3 withDisplacement(this object position_PositionProvider, Vector3 displacement)
		=> position_PositionProvider.providePosition() + displacement;
	#endregion with displacement
}