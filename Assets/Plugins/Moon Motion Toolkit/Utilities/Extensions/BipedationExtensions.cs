#if NAV_MESH_COMPONENTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// BipedationExtensions: provides extension methods for handling BipedationExtensionss //
public static class BipedationExtensions
{
	#region bipeding
	// methods: have this bipedation begin to bipede to the given provided destination position, specified singleton behaviour, or the main camera (respectively), then return whether the destination was actually valid/set //
	
	/*public static bool bipedeTo(this Bipedation bipedation, object destinationPosition_PositionProvider)
	{
		NavMeshAgent navmeshAgent = bipedation.first<NavMeshAgent>();


		bool validSoSet = navmeshAgent.beginNavigatingTo(destinationPosition_PositionProvider);

		if (navmeshAgent.remainingDistance > navmeshAgent.stoppingDistance)
		{
			bipedation.Move(navmeshAgent.desiredVelocity, false, false);
		}
		else
		{
			bipedation.Move(FloatsVector.zeroes, false, false);
		}

		return validSoSet;
	}
	
	public static bool bipedeTo<SingletonBehaviourT>(this Bipedation bipedation) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> bipedation.bipedeTo(SingletonBehaviour<SingletonBehaviourT>.position);
	
	public static bool bipedeToCamera(this Bipedation bipedation)
		=> bipedation.bipedeTo(Camera.main);*/
	#endregion bipeding
}
#endif