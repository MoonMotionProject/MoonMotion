using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Directionality Extensions: provides extension methods for handling directionality //
public static class DirectionalityExtensions
{
	#region directionality same toward both
	// methods: return whether this given provided position's direction toward the first given provided other position is in directionality with this given provided position's direction toward the second given provided other position //

	public static bool directionalitySameTowardBoth(this Vector3 position, object firstOtherPosition_PositionProvider, object secondOtherPosition_PositionProvider)
		=>	position.directionTo
			(
				Provide.positionVia(firstOtherPosition_PositionProvider)
			)
			.directionalityBooleanWith
			(
				position.directionTo
				(
					Provide.positionVia(secondOtherPosition_PositionProvider)
				)
			);
	public static bool directionalitySameTowardBoth<SingletonBehaviourT>(this Vector3 position, object secondOtherPosition_PositionProvider) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=>	position.directionalitySameTowardBoth
			(
				SingletonBehaviour<SingletonBehaviourT>.position,
				secondOtherPosition_PositionProvider
			);

	public static bool directionalitySameTowardBoth(this GameObject gameObject, object firstOtherPosition_PositionProvider, object secondOtherPosition_PositionProvider)
		=>	gameObject.position().directionalitySameTowardBoth
			(
				firstOtherPosition_PositionProvider,
				secondOtherPosition_PositionProvider
			);

	public static bool directionalitySameTowardBoth(this Component component, object firstOtherPosition_PositionProvider, object secondOtherPosition_PositionProvider)
		=>	component.position().directionalitySameTowardBoth
			(
				firstOtherPosition_PositionProvider,
				secondOtherPosition_PositionProvider
			);
	#endregion directionality same toward both
}