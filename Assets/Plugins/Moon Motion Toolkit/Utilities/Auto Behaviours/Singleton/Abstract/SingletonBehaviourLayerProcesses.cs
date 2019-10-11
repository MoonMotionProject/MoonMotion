using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Behaviour Layer Processes:
// #auto
// • provides this singleton behaviour with static access to its auto behaviour's processes layer
public abstract class	SingletonBehaviourLayerProcesses<SingletonBehaviourT> :
					SingletonBehaviourLayerCollisionAndForcing<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region movePositionToward

	public static new AutoBehaviour<SingletonBehaviourT> beginMovingPositionTo(object targetPosition_PositionProvider, float honingDistance, LayerMask endingLayerMask)
		=> autoBehaviour.beginMovingPositionTo(targetPosition_PositionProvider, honingDistance, endingLayerMask);

	public static new AutoBehaviour<SingletonBehaviourT> stopMovingPosition()
		=> autoBehaviour.stopMovingPosition();
	#endregion movePositionToward



}