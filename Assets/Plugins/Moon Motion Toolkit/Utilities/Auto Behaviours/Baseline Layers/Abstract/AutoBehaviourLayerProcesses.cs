using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Auto Behaviour Layer Processes:
// #auto
// • provides this behaviour with methods that start and end processes (such as coroutines)
public abstract class	AutoBehaviourLayerProcesses<AutoBehaviourT> :
					AutoBehaviourLayerCollisionAndForcing<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region movePositionToward

	private bool continueMovingPosition = true;

	public AutoBehaviourT beginMovingPositionTo(object targetPosition_PositionProvider, float honingDistance, LayerMask endingLayerMask)
	{
		continueMovingPosition = true;

		continueMovingPositionTo(targetPosition_PositionProvider.providePosition(), honingDistance, endingLayerMask);

		return self;
	}

	private void continueMovingPositionTo(Vector3 targetPosition, float honingDistance, LayerMask endingLayerMask)
	{
		if (!continueMovingPosition)
		{
			continueMovingPosition = true;
			return;
		}
		if (position.doesNotMatch(targetPosition) && isNotCollidedWith(endingLayerMask))
		{
			movePositionToward(targetPosition, honingDistance);

			nextFrameExecute(()=> continueMovingPositionTo(targetPosition, honingDistance, endingLayerMask));
		}
	}

	public AutoBehaviourT stopMovingPosition()
		=> selfAfter(()=> continueMovingPosition = false);
	#endregion movePositionToward
}