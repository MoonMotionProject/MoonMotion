#if NAV_MESH_COMPONENTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Navmesh Agent Extensions: provides extension methods for handling navmesh agents //
public static class NavmeshAgentExtensions
{
	#region destinating
	// methods: set the destination of this given navmesh agent to the given provided destination position, specified singleton behaviour, or the main camera (respectively), then return whether the destination was actually valid/set //
	
	public static bool destinateTo(this NavMeshAgent navmeshAgent, object destinationPosition_PositionProvider)
		=> navmeshAgent.SetDestination(destinationPosition_PositionProvider.providePosition());

	public static bool destinateTo<SingletonBehaviourT>(this NavMeshAgent navmeshAgent) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> navmeshAgent.destinateTo(SingletonBehaviour<SingletonBehaviourT>.position);

	public static bool destinateToCamera(this NavMeshAgent navmeshAgent)
		=> navmeshAgent.destinateTo(Camera.main);
	#endregion destinating


	#region determining haltedness

	// method: return whether this given navmesh agent is halted //
	public static bool isHalted(this NavMeshAgent navmeshAgent)
		=> navmeshAgent.isStopped;

	// method: return whether this given navmesh agent is not halted //
	public static bool isNotHalted(this NavMeshAgent navmeshAgent)
		=> !navmeshAgent.isHalted();
	#endregion determining haltedness


	#region setting haltedness

	// method: set this given navmesh agent's haltedness to the given boolean, then return this given navmesh agent //
	public static NavMeshAgent setHaltednessTo(this NavMeshAgent navmeshAgent, bool boolean)
		=> navmeshAgent.after(()=>
			navmeshAgent.isStopped = boolean);
	
	// method: halt this given navmesh (set this given navmesh agent's haltedness to true), then return this given navmesh agent //
	public static NavMeshAgent halt(this NavMeshAgent navmeshAgent)
		=> navmeshAgent.setHaltednessTo(true);
	
	// method: unhalt this given navmesh (set this given navmesh agent's haltedness to false), then return this given navmesh agent //
	public static NavMeshAgent unhalt(this NavMeshAgent navmeshAgent)
		=> navmeshAgent.setHaltednessTo(false);
	#endregion setting haltedness


	#region navigating
	// methods: have this given navmesh agent begin navigating to the given provided destination position, specified singleton behaviour, or the main camera (respectively) (unhalt this given navmesh agent and set the destination of this given navmesh agent to the respective destination position), then return whether the destination was actually valid/set //
	
	public static bool beginNavigatingTo(this NavMeshAgent navmeshAgent, object destinationPosition_PositionProvider)
		=> navmeshAgent.unhalt().destinateTo(destinationPosition_PositionProvider);

	public static bool beginNavigatingTo<SingletonBehaviourT>(this NavMeshAgent navmeshAgent) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> navmeshAgent.beginNavigatingTo(SingletonBehaviour<SingletonBehaviourT>.position);

	public static bool beginNavigatingToCamera(this NavMeshAgent navmeshAgent)
		=> navmeshAgent.beginNavigatingTo(Camera.main);
	#endregion navigating


	#region setting enablement of rotation via navigation
	
	// method: set whether this given navmesh agent rotates via navigation to the given boolean, then return this given navmesh agent //
	public static NavMeshAgent setEnablementOfRotationViaNavigationTo(this NavMeshAgent navmeshAgent, bool boolean)
		=> navmeshAgent.after(()=>
			navmeshAgent.updateRotation = boolean);
	
	// method: enable this given navmesh agent to rotate via navigation, then return this given navmesh agent //
	public static NavMeshAgent enableRotationViaNavigation(this NavMeshAgent navmeshAgent)
		=> navmeshAgent.setEnablementOfRotationViaNavigationTo(true);
	
	// method: disable this given navmesh agent to rotate via navigation, then return this given navmesh agent //
	public static NavMeshAgent disableRotationViaNavigation(this NavMeshAgent navmeshAgent)
		=> navmeshAgent.setEnablementOfRotationViaNavigationTo(false);
	#endregion setting rotation via navigation
}
#endif