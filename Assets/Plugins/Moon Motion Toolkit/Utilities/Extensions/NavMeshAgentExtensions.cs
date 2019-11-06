#if NAV_MESH_COMPONENTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Navmesh Agent Extensions:
// • provides extension methods for handling navmesh agents
// #navmesh
public static class NavmeshAgentExtensions
{
	#region determining whether an agent is on a navmesh

	// method: return whether this given navmesh agent is ("placed") on a navmesh //
	public static bool isOnANavmesh(this NavMeshAgent navmeshAgent)
		=> navmeshAgent.isOnNavMesh;
	public static bool isNotOnANavmesh(this NavMeshAgent navmeshAgent)
		=> !navmeshAgent.isOnANavmesh();
	#endregion determining whether an agent is on a navmesh


	#region accessing destination

	// method: return the destination of this given navmesh agent //
	public static Vector3 destination(this NavMeshAgent navmeshAgent)
		=> navmeshAgent.destination;
	#endregion accessing destination


	#region destinating
	// methods: set the destination of this given navmesh agent to the given position for the provided\specified\ main camera (respectively) collider – avoiding provided solidity according to the given 'avoidProvidedSolidity' boolean – or otherwise (if no collider is provided) the provided\specified\ main camera (respectively) position, then return whether the destination was actually valid/set //

	public static bool destinateTo(this NavMeshAgent navmeshAgent, object destination_ColliderOtherwisePositionProvider, bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity)
	{
		Vector3 destination
			=	avoidProvidedSolidity && destination_ColliderOtherwisePositionProvider.provideCollider().isYull() ?
					destination_ColliderOtherwisePositionProvider.provideCollider().nearestPointToPosition(navmeshAgent) :
					destination_ColliderOtherwisePositionProvider.providePosition();

		navmeshAgent.SetDestination(destination);

		return navmeshAgent;
	}

	public static bool destinateTo<SingletonBehaviourT>(this NavMeshAgent navmeshAgent, bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> navmeshAgent.destinateTo(SingletonBehaviour<SingletonBehaviourT>.singleton, avoidProvidedSolidity);

	public static bool destinateToCamera(this NavMeshAgent navmeshAgent, bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity)
		=> navmeshAgent.destinateTo(Camera.main, avoidProvidedSolidity);
	#endregion destinating


	#region determining haltedness

	// method: return whether this given navmesh agent is halted //
	public static bool isHalted(this NavMeshAgent navmeshAgent)
		=> navmeshAgent.isOnANavmesh() && navmeshAgent.isStopped;

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
	// methods:
	// have this given navmesh agent navigate to the given provided destination, avoiding solidity according to the given 'avoidProvidedSolidity' boolean
	// (have this given navmesh agent begin navigating to the given provided destination, avoiding solidity according to the given 'avoidProvidedSolidity' boolean
	// (have this given navmesh agent unhalt and destinate using the given parameters)) //
	
	public static bool navigateTo(this NavMeshAgent navmeshAgent, object destination_ColliderOtherwisePositionProvider, bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity)
		=> navmeshAgent.unhalt().destinateTo(destination_ColliderOtherwisePositionProvider, avoidProvidedSolidity);

	public static bool navigateTo<SingletonBehaviourT>(this NavMeshAgent navmeshAgent, bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> navmeshAgent.navigateTo(SingletonBehaviour<SingletonBehaviourT>.singleton, avoidProvidedSolidity);

	public static bool navigateToPlayer(this NavMeshAgent navmeshAgent, bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity)
		=> navmeshAgent.navigateTo<MoonMotionBody>(avoidProvidedSolidity);

	public static bool navigateToCamera(this NavMeshAgent navmeshAgent, bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity)
		=> navmeshAgent.navigateTo(Camera.main, avoidProvidedSolidity);
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