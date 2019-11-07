using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
#if NAV_MESH_COMPONENTS
using UnityEngine.AI;
#endif

// Singleton Behaviour Layer Component Shortcuts Moon Motion:
// #auto #shortcuts #tracking #navmesh #unitology
// • provides this singleton behaviour with static access to its auto behaviour's nonUnity component shortcuts layer
public abstract class SingletonBehaviourLayerComponentShortcutsNonUnity<SingletonBehaviourT> :
					SingletonBehaviourLayerComponentShortcutsUnity<SingletonBehaviourT>
						where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
{
	#region Utilities




	#region Auto Behaviours


	#region Tracking

	#region miscellaneous
	public static new float timeAwake => autoBehaviour.timeAwake;
	public static new float lightIntensityAwake => autoBehaviour.lightIntensityAwake;
	public static new bool isAwake => autoBehaviour.isAwake;
	public static new bool isNotAwake => autoBehaviour.isNotAwake;
	public static new Color colorAwake => autoBehaviour.colorAwake;
	public static new bool hasStarted => autoBehaviour.hasStarted;
	public static new bool hasNotStarted => autoBehaviour.hasNotStarted;
	#endregion miscellaneous

	#region Collideds
	public static new HashSet<Collider> collidedColliders => autoBehaviour.collidedColliders;
	public static new HashSet<GameObject> collidedObjects => autoBehaviour.collidedObjects;
	public static new HashSet<Rigidbody> collidedRigidbodies => autoBehaviour.collidedRigidbodies;
	public static new bool isCollidedWith(Collider collider)
		=> autoBehaviour.isCollidedWith(collider);
	public static new bool isNotCollidedWith(Collider collider)
		=> autoBehaviour.isNotCollidedWith(collider);
	public static new bool isCollidedWith(LayerMask layerMask)
		=> autoBehaviour.isCollidedWith(layerMask);
	public static new bool isNotCollidedWith(LayerMask layerMask)
		=> autoBehaviour.isNotCollidedWith(layerMask);
	#endregion Collideds

	#region Components
	public static new List<CapsuleCollider> capsuleCollidersAwake => autoBehaviour.capsuleCollidersAwake;
	#endregion Components

	#region Transformations
	public static new Vector3 localScaleAwake => autoBehaviour.localScaleAwake;
	public static new float localScaleXAwake => autoBehaviour.localScaleXAwake;
	public static new float localScaleYAwake => autoBehaviour.localScaleYAwake;
	public static new float localScaleZAwake => autoBehaviour.localScaleZAwake;
	public static new Vector3 positionAwake => autoBehaviour.positionAwake;
	public static new float positionXAwake => autoBehaviour.positionXAwake;
	public static new float positionYAwake => autoBehaviour.positionYAwake;
	public static new float positionZAwake => autoBehaviour.positionZAwake;
	public static new Quaternion rotationAwake => autoBehaviour.rotationAwake;
	public static new float localPositionZAwake => autoBehaviour.localPositionZAwake;
	public static new float localPositionYAwake => autoBehaviour.localPositionYAwake;
	public static new float eulerAngleYAwake => autoBehaviour.eulerAngleYAwake;
	public static new float localPositionXAwake => autoBehaviour.localPositionXAwake;
	public static new Vector3 localPositionAwake => autoBehaviour.localPositionAwake;
	public static new float localEulerAngleZAwake => autoBehaviour.localEulerAngleZAwake;
	public static new float localEulerAngleYAwake => autoBehaviour.localEulerAngleYAwake;
	public static new float localEulerAngleXAwake => autoBehaviour.localEulerAngleXAwake;
	public static new Vector3 localEulerAnglesAwake => autoBehaviour.localEulerAnglesAwake;
	public static new float eulerAngleZAwake => autoBehaviour.eulerAngleZAwake;
	public static new float eulerAngleXAwake => autoBehaviour.eulerAngleXAwake;
	public static new Vector3 eulerAnglesAwake => autoBehaviour.eulerAnglesAwake;
	public static new Quaternion localRotationAwake => autoBehaviour.localRotationAwake;
	#endregion Transformations
	#endregion Tracking
	#endregion Auto Behaviours
	#endregion Utilities








	#region Navmesh Components
	#if NAV_MESH_COMPONENTS
	#region NavMeshAgent

	#region determining whether an agent is on a navmesh
	public static new bool isOnANavmesh => autoBehaviour.isOnANavmesh;
	public static new bool isNotOnANavmesh => autoBehaviour.isNotOnANavmesh;
	#endregion determining whether an agent is on a navmesh
	
	#region accessing destination
	public static new Vector3 destination => autoBehaviour.destination;
	#endregion accessing destination
	
	#region destinating
	public static new bool destinateTo(object destination_ColliderOtherwisePositionProvider, bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> autoBehaviour.destinateTo(destination_ColliderOtherwisePositionProvider, avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	public static new bool destinateTo<OtherSingletonBehaviourT>(bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.destinateTo<OtherSingletonBehaviourT>(avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	public static new bool destinateToCamera(bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> autoBehaviour.destinateToCamera(avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	#endregion destinating
	
	#region determining haltedness
	public static new bool isHalted => autoBehaviour.isHalted;
	public static new bool isNotHalted => autoBehaviour.isNotHalted;
	#endregion determining haltedness

	#region setting haltedness
	public static new AutoBehaviour<SingletonBehaviourT> setHaltednessTo(bool boolean, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> autoBehaviour.setHaltednessTo(boolean, silenceErrorForNotOnNavmesh);
	public static new AutoBehaviour<SingletonBehaviourT> halt(bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> autoBehaviour.halt(silenceErrorForNotOnNavmesh);
	public static new AutoBehaviour<SingletonBehaviourT> unhalt(bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> autoBehaviour.unhalt(silenceErrorForNotOnNavmesh);
	#endregion setting haltedness
	
	#region navigating
	public static new bool navigateTo(object destination_ColliderOtherwisePositionProvider, bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> autoBehaviour.navigateTo(destination_ColliderOtherwisePositionProvider, avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	public static new bool navigateTo<OtherSingletonBehaviourT>(bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.navigateTo<OtherSingletonBehaviourT>(avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	public static new bool navigateToPlayer(bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> autoBehaviour.navigateToPlayer(avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	public static new bool navigateToCamera(bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> autoBehaviour.navigateToCamera(avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	#endregion navigating
	
	#region setting enablement of rotation via navigation
	public static new NavMeshAgent setEnablementOfRotationViaNavigationTo(bool boolean)
		=> autoBehaviour.setEnablementOfRotationViaNavigationTo(boolean);
	public static new NavMeshAgent enableRotationViaNavigation()
		=> autoBehaviour.enableRotationViaNavigation();
	public static new NavMeshAgent disableRotationViaNavigation()
		=> autoBehaviour.disableRotationViaNavigation();
	#endregion setting enablement of rotation via navigation
	#endregion NavMeshAgent
#endif
	#endregion Navmesh Components








	#region Unitology
	#if UNITOLOGY


	#region Unit

	#region targeting
	public static new Transform bestUnitTransform => autoBehaviour.bestUnitTransform;
	public static new Transform bestUnitTransformOtherwiseSelfTransform => autoBehaviour.bestUnitTransformOtherwiseSelfTransform;
	public static new Vector3 bestUnitPosition => autoBehaviour.bestUnitPosition;
	public static new float awaradius => autoBehaviour.awaradius;
	public static new HashSet<Unit> enemies(bool includeSelf = Default.enemyInclusionOfSelf)
		=> autoBehaviour.enemies(includeSelf);
	public static new HashSet<Unit> allies(bool includeSelf = Default.allyInclusionOfSelf)
		=> autoBehaviour.allies(includeSelf);
	public static new HashSet<Unit> unitsWithinRangeFor
	(
		LayerMask layers,
		float range,
		bool includeSelf
	)
		=>	autoBehaviour.unitsWithinRangeFor
			(
				layers,
				range,
				includeSelf
			);
	public static new HashSet<Unit> enemiesWithin
	(
		float range,
		bool includeSelf = Default.enemyInclusionOfSelf
	)
		=>	autoBehaviour.enemiesWithin
			(
				range,
				includeSelf
			);
	public static new HashSet<Unit> alliesWithin
	(
		float range,
		bool includeSelf = Default.allyInclusionOfSelf
	)
		=>	autoBehaviour.alliesWithin
			(
				range,
				includeSelf
			);
	public static new Unit nearestEnemyWithin
	(
		float range,
		bool includeSelf = Default.enemyInclusionOfSelf
	)
		=>	autoBehaviour.nearestEnemyWithin
			(
				range,
				includeSelf
			);
	public static new Unit nearestEnemy
	(
		bool includeSelf = Default.enemyInclusionOfSelf
	)
		=> autoBehaviour.nearestEnemy(includeSelf);
	public static new Unit nearestAllyWithin
	(
		float range,
		bool includeSelf = Default.allyInclusionOfSelf
	)
		=>	autoBehaviour.nearestAllyWithin
			(
				range,
				includeSelf
			);
	public static new Unit nearestAlly
	(
		bool includeSelf = Default.allyInclusionOfSelf
	)
		=> autoBehaviour.nearestAlly(includeSelf);
	public static new bool isAwareOf(object target)
		=> autoBehaviour.isAwareOf(target);
	public static new bool isNotAwareOf(object target)
		=> autoBehaviour.isNotAwareOf(target);
	public static new bool isAwareOfAnyEnemy
	(
		bool includeSelf = Default.enemyInclusionOfSelf
	)
		=> autoBehaviour.isAwareOfAnyEnemy(includeSelf);
	public static new bool isAwareOfAnyAlly
	(
		bool includeSelf = Default.allyInclusionOfSelf
	)
		=> autoBehaviour.isAwareOfAnyAlly(includeSelf);
	public static new bool considersAnEnemyOf(object layerIndex_LayerIndexProvider)
		=> autoBehaviour.considersAnEnemyOf(layerIndex_LayerIndexProvider);
	public static new bool considersAnAllyOf(object layerIndex_LayerIndexProvider)
		=> autoBehaviour.considersAnAllyOf(layerIndex_LayerIndexProvider);
	#endregion targeting

	#region trying to cast particular abilities
	public static new bool tryToCancel
	(
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	)
		=> autoBehaviour.tryToCancel(requiresAwarenessOfTarget, logResult);
	public static new bool tryToMoveTo
	(
		object targetPosition_PositionProvider,
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	)
		=> autoBehaviour.tryToMoveTo(targetPosition_PositionProvider, requiresAwarenessOfTarget, logResult);
	public static new bool tryToMoveTo<OtherSingletonBehaviourT>
	(
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.tryToMoveTo<OtherSingletonBehaviourT>(requiresAwarenessOfTarget, logResult);
	public static new bool tryToMoveToPlayer
	(
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	)
		=> autoBehaviour.tryToMoveToPlayer(requiresAwarenessOfTarget, logResult);
	public static new bool tryToAttack
	(
		object targetUnit_UnitProvider,
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	)
		=> autoBehaviour.tryToAttack(targetUnit_UnitProvider, requiresAwarenessOfTarget, logResult);
	public static new bool tryToAttack<OtherSingletonBehaviourT>
	(
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	) where OtherSingletonBehaviourT : SingletonBehaviour<OtherSingletonBehaviourT>
		=> autoBehaviour.tryToAttack<OtherSingletonBehaviourT>(requiresAwarenessOfTarget, logResult);
	public static new bool tryToAttackPlayer
	(
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	)
		=> autoBehaviour.tryToAttackPlayer(requiresAwarenessOfTarget, logResult);
	#endregion trying to cast particular abilities
	#endregion Unit


	#region Intelligence

	#region targeting
	public static new HashSet<IntelligenceT> enemies<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.enemies<IntelligenceT>();
	public static new HashSet<Unit> enemyUnits<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.enemyUnits<IntelligenceT>();
	public static new HashSet<IntelligenceT> allies<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.allies<IntelligenceT>();
	public static new HashSet<Unit> allyUnits<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.allyUnits<IntelligenceT>();
	public static new HashSet<OtherIntelligenceT> awornEnemies<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
		=> autoBehaviour.awornEnemies<OtherIntelligenceT>();
	public static new HashSet<Unit> awornEnemyUnits<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.awornEnemyUnits<IntelligenceT>();
	public static new HashSet<OtherIntelligenceT> awornAllies<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
		=> autoBehaviour.awornAllies<OtherIntelligenceT>();
	public static new HashSet<Unit> awornAllyUnits<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.awornAllyUnits<IntelligenceT>();
	public static new OtherIntelligenceT nearestAwornEnemy<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
		=> autoBehaviour.nearestAwornEnemy<OtherIntelligenceT>();
	public static new HashSet<Unit> nearestAwornEnemyUnit<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.nearestAwornEnemyUnit<IntelligenceT>();
	public static new OtherIntelligenceT nearestAwornAlly<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
		=> autoBehaviour.nearestAwornAlly<OtherIntelligenceT>();
	public static new HashSet<Unit> nearestAwornAllyUnit<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.nearestAwornAllyUnit<IntelligenceT>();
	public static new IntelligenceT nearestEnemy<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.nearestEnemy<IntelligenceT>();
	public static new HashSet<Unit> nearestEnemyUnit<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.nearestEnemyUnit<IntelligenceT>();
	public static new IntelligenceT nearestAlly<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.nearestAlly<IntelligenceT>();
	public static new HashSet<Unit> nearestAllyUnit<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> autoBehaviour.nearestAllyUnit<IntelligenceT>();
	public static new bool isAwareOfAnyEnemy<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
		=> autoBehaviour.isAwareOfAnyEnemy<OtherIntelligenceT>();
	public static new bool isAwareOfAnyAlly<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
		=> autoBehaviour.isAwareOfAnyAlly<OtherIntelligenceT>();
	public static new HashSet<Unit> enemyStructures(bool includeSelf = Default.enemyInclusionOfSelf)
		=> autoBehaviour.enemyStructures(includeSelf);
	public static new HashSet<Unit> allyStructures(bool includeSelf = Default.allyInclusionOfSelf)
		=> autoBehaviour.allyStructures(includeSelf);
	public static new HashSet<Unit> awornEnemyStructures(bool includeSelf = Default.enemyInclusionOfSelf)
		=> autoBehaviour.awornEnemyStructures(includeSelf);
	public static new HashSet<Unit> awornAllyStructures(bool includeSelf = Default.allyInclusionOfSelf)
		=> autoBehaviour.awornAllyStructures(includeSelf);
	public static new Unit nearestAwornEnemyStructure(bool includeSelf = Default.enemyInclusionOfSelf)
		=> autoBehaviour.nearestAwornEnemyStructure(includeSelf);
	public static new Unit nearestAwornAllyStructure(bool includeSelf = Default.allyInclusionOfSelf)
		=> autoBehaviour.nearestAwornAllyStructure(includeSelf);
	public static new bool isAwareOfAnyEnemyStructure(bool includeSelf = Default.enemyInclusionOfSelf)
		=> autoBehaviour.isAwareOfAnyEnemyStructure(includeSelf);
	public static new bool isAwareOfAnyAllyStructure(bool includeSelf = Default.allyInclusionOfSelf)
		=> autoBehaviour.isAwareOfAnyAllyStructure(includeSelf);
	#endregion targeting
	#endregion Intelligence
	#endif
	#endregion Unitology
}