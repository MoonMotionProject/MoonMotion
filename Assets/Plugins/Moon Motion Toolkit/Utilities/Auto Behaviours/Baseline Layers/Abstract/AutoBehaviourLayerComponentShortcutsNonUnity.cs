using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
#if NAV_MESH_COMPONENTS
using UnityEngine.AI;
#endif

// Auto Behaviour Layer Component Shortcuts Moon Motion:
// #auto #shortcuts #tracking #navmesh #unitology
// • provides this behaviour with automatically-connected state and methods (recursively) of its game object's and its children game objects' nonUnity components
public abstract class AutoBehaviourLayerComponentShortcutsNonUnity<AutoBehaviourT> :
					AutoBehaviourLayerComponentShortcutsUnity<AutoBehaviourT>
						where AutoBehaviourT : AutoBehaviour<AutoBehaviourT>
{
	#region Utilities




	#region Auto Behaviours


	#region Trackings

	#region miscellaneous
	public float timeAwake => trackTimeOfAwake.timeAwake;
	public float lightIntensityAwake => trackLightIntensityAtAwake.lightIntensityAwake;
	public bool isAwake => trackAwake.isAwake;
	public bool isNotAwake => !isAwake;
	public Color colorAwake => trackColorAtAwake.colorAwake;
	public bool hasStarted => trackStart.hasStarted;
	public bool hasNotStarted => !hasStarted;
	#endregion miscellaneous

	#region Collideds
	public HashSet<Collider> collidedColliders => trackCollideds.collidedColliders;
	public HashSet<GameObject> collidedObjects => collidedColliders.uniqueObjects();
	public HashSet<Rigidbody> collidedRigidbodies => collidedColliders.uniqueCorrespondingRigidbodies();
	public bool isCollidedWith(Collider collider)
		=> collidedColliders.contains(collider);
	public bool isNotCollidedWith(Collider collider)
		=> !isCollidedWith(collider);
	public bool isCollidedWith(LayerMask layerMask)
		=> layerMask.includesAnyLayersOf(collidedObjects);
	public bool isNotCollidedWith(LayerMask layerMask)
		=> !isCollidedWith(layerMask);
	#endregion Collideds

	#region Components
	public List<CapsuleCollider> capsuleCollidersAwake => trackCapsuleCollidersAtAwake.capsuleCollidersAwake;
	#endregion Components

	#region Transformations
	public Vector3 localScaleAwake => trackLocalScaleAtAwake.localScaleAwake;
	public float localScaleXAwake => trackLocalScaleXAtAwake.localScaleXAwake;
	public float localScaleYAwake => trackLocalScaleYAtAwake.localScaleYAwake;
	public float localScaleZAwake => trackLocalScaleZAtAwake.localScaleZAwake;
	public Vector3 positionAwake => trackPositionAtAwake.positionAwake;
	public float positionXAwake => trackPositionXAtAwake.positionXAwake;
	public float positionYAwake => trackPositionYAtAwake.positionYAwake;
	public float positionZAwake => trackPositionZAtAwake.positionZAwake;
	public Quaternion rotationAwake => trackRotationAtAwake.rotationAwake;
	public float localPositionZAwake => trackLocalPositionZAtAwake.localPositionZAwake;
	public float localPositionYAwake => trackLocalPositionYAtAwake.localPositionYAwake;
	public float eulerAngleYAwake => trackEulerAngleYAtAwake.eulerAngleYAwake;
	public float localPositionXAwake => trackLocalPositionXAtAwake.localPositionXAwake;
	public Vector3 localPositionAwake => trackLocalPositionAtAwake.localPositionAwake;
	public float localEulerAngleZAwake => trackLocalEulerAngleZAtAwake.localEulerAngleZAwake;
	public float localEulerAngleYAwake => trackLocalEulerAngleYAtAwake.localEulerAngleYAwake;
	public float localEulerAngleXAwake => trackLocalEulerAngleXAtAwake.localEulerAngleXAwake;
	public Vector3 localEulerAnglesAwake => trackLocalEulerAnglesAtAwake.localEulerAnglesAwake;
	public float eulerAngleZAwake => trackEulerAngleZAtAwake.eulerAngleZAwake;
	public float eulerAngleXAwake => trackEulerAngleXAtAwake.eulerAngleXAwake;
	public Vector3 eulerAnglesAwake => trackEulerAnglesAtAwake.eulerAnglesAwake;
	public Quaternion localRotationAwake => trackLocalRotationAtAwake.localRotationAwake;
	#endregion Transformations
	#endregion Trackings
	#endregion Auto Behaviours
	#endregion Utilities









	#region Navmesh Components
	#if NAV_MESH_COMPONENTS
	#region NavMeshAgent

	#region determining whether an agent is on a navmesh
	public bool isOnANavmesh => UnityIs.playing && navmeshAgent.isYull() && navmeshAgent.isOnANavmesh();
	public bool isNotOnANavmesh => !isOnANavmesh;
	#endregion determining whether an agent is on a navmesh
	
	#region accessing destination
	public Vector3 destination
		=>	navmeshAgent.isYull() ?
				navmeshAgent.destination :
				Callstack.includesMethodNamed("DrawOdinInspector") || Callstack.includesEditorVisualization ?
					default(Vector3) :
					default(Vector3).returnWithError("navmesh agent is null, so cannot get destination");
	#endregion accessing destination
	
	#region destinating
	public bool destinateTo(object destination_ColliderOtherwisePositionProvider, bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> navmeshAgent.destinateTo(destination_ColliderOtherwisePositionProvider, avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	public bool destinateTo<SingletonBehaviourT>(bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> navmeshAgent.destinateTo<SingletonBehaviourT>(avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	public bool destinateToCamera(bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> navmeshAgent.destinateToCamera(avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	#endregion destinating
	
	#region determining haltedness
	public bool isHalted => UnityIs.playing && navmeshAgent.isYull() && navmeshAgent.isHalted();
	public bool isNotHalted => !isHalted;
	#endregion determining haltedness
	
	#region setting haltedness
	public AutoBehaviourT setHaltednessTo(bool boolean, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> selfAfter(()=> navmeshAgent.setHaltednessTo(boolean, silenceErrorForNotOnNavmesh));
	public AutoBehaviourT halt(bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> selfAfter(()=> navmeshAgent.halt(silenceErrorForNotOnNavmesh));
	public AutoBehaviourT unhalt(bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> selfAfter(()=> navmeshAgent.unhalt(silenceErrorForNotOnNavmesh));
	#endregion setting haltedness
	
	#region navigating
	public bool navigateTo(object destination_ColliderOtherwisePositionProvider, bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> navmeshAgent.navigateTo(destination_ColliderOtherwisePositionProvider, avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	public bool navigateTo<SingletonBehaviourT>(bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> navmeshAgent.navigateTo<SingletonBehaviourT>(avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	public bool navigateToPlayer(bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> navmeshAgent.navigateToPlayer(avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	public bool navigateToCamera(bool avoidProvidedSolidity = Default.destinatingAvoidanceOfProvidedSolidity, bool silenceErrorForNotOnNavmesh = Default.errorSilencing)
		=> navmeshAgent.navigateToCamera(avoidProvidedSolidity, silenceErrorForNotOnNavmesh);
	#endregion navigating
	
	#region setting enablement of rotation via navigation
	public NavMeshAgent setEnablementOfRotationViaNavigationTo(bool boolean)
		=> navmeshAgent.setEnablementOfRotationViaNavigationTo(boolean);
	public NavMeshAgent enableRotationViaNavigation()
		=> navmeshAgent.enableRotationViaNavigation();
	public NavMeshAgent disableRotationViaNavigation()
		=> navmeshAgent.disableRotationViaNavigation();
	#endregion setting enablement of rotation via navigation
	#endregion NavMeshAgent
	#endif
	#endregion Navmesh Components








	#region Unitology
	#if UNITOLOGY


	#region Unit

	#region targeting
	public Transform bestUnitTransform => unit.bestTransform;
	public Transform bestUnitTransformOtherwiseSelfTransform
		=>	(unit.isYull() && bestUnitTransform.isYull()) ?
				bestUnitTransform :
				transform;
	public Vector3 bestUnitPosition => unit.bestPosition;
	public float awaradius => unit.awaradius;
	public HashSet<Unit> enemies(bool includeSelf = Default.enemyInclusionOfSelf)
		=> unit.enemies(includeSelf);
	public HashSet<Unit> allies(bool includeSelf = Default.allyInclusionOfSelf)
		=> unit.allies(includeSelf);
	public HashSet<Unit> unitsWithinRangeFor
	(
		LayerMask layers,
		float range,
		bool includeSelf
	)
		=>	unit.unitsWithinRangeFor
			(
				layers,
				range,
				includeSelf
			);
	public HashSet<Unit> enemiesWithin
	(
		float range,
		bool includeSelf = Default.enemyInclusionOfSelf
	)
		=>	unit.enemiesWithin
			(
				range,
				includeSelf
			);
	public HashSet<Unit> awornEnemies(bool includeSelf = Default.enemyInclusionOfSelf)
		=> unit.awornEnemies(includeSelf);
	public HashSet<Unit> alliesWithin
	(
		float range,
		bool includeSelf = Default.allyInclusionOfSelf
	)
		=>	unit.alliesWithin
			(
				range,
				includeSelf
			);
	public HashSet<Unit> awornAllies(bool includeSelf = Default.allyInclusionOfSelf)
		=> unit.awornAllies(includeSelf);
	public Unit nearestEnemyWithin
	(
		float range,
		bool includeSelf = Default.enemyInclusionOfSelf
	)
		=>	unit.nearestEnemyWithin
			(
				range,
				includeSelf
			);
	public Unit nearestAwornEnemy(bool includeSelf = Default.enemyInclusionOfSelf)
		=> unit.nearestAwornEnemy(includeSelf);
	public Unit nearestEnemy(bool includeSelf = Default.enemyInclusionOfSelf)
		=> unit.nearestEnemy(includeSelf);
	public Unit nearestAllyWithin
	(
		float range,
		bool includeSelf = Default.allyInclusionOfSelf
	)
		=>	unit.nearestAllyWithin
			(
				range,
				includeSelf
			);
	public Unit nearestAwornAlly(bool includeSelf = Default.allyInclusionOfSelf)
		=> unit.nearestAwornAlly(includeSelf);
	public Unit nearestAlly(bool includeSelf = Default.allyInclusionOfSelf)
		=> unit.nearestAlly(includeSelf);
	public bool isAwareOf(object target)
		=> unit.isAwareOf(target);
	public bool isNotAwareOf(object target)
		=> unit.isNotAwareOf(target);
	public bool isAwareOfAnyEnemy(bool includeSelf = Default.enemyInclusionOfSelf)
		=> unit.isAwareOfAnyEnemy(includeSelf);
	public bool isAwareOfAnyAlly(bool includeSelf = Default.allyInclusionOfSelf)
		=> unit.isAwareOfAnyAlly(includeSelf);
	public bool considersAnEnemyOf(object layerIndex_LayerIndexProvider)
		=> unit.considersAnEnemyOf(layerIndex_LayerIndexProvider);
	public bool considersAnAllyOf(object layerIndex_LayerIndexProvider)
		=> unit.considersAnAllyOf(layerIndex_LayerIndexProvider);
	#endregion targeting

	#region trying to cast particular abilities
	public bool tryToCancel
	(
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	)
		=> unit.tryToCancel(requiresAwarenessOfTarget, logResult);
	public bool tryToMoveTo
	(
		object targetPosition_PositionProvider,
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	)
		=> unit.tryToMoveTo(targetPosition_PositionProvider, requiresAwarenessOfTarget, logResult);
	public bool tryToMoveTo<SingletonBehaviourT>
	(
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> unit.tryToMoveTo<SingletonBehaviourT>(requiresAwarenessOfTarget, logResult);
	public bool tryToMoveToPlayer
	(
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	)
		=> unit.tryToMoveToPlayer(requiresAwarenessOfTarget, logResult);
	public bool tryToAttack
	(
		object targetUnit_UnitProvider,
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	)
		=> unit.tryToAttack(targetUnit_UnitProvider, requiresAwarenessOfTarget, logResult);
	public bool tryToAttack<SingletonBehaviourT>
	(
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	) where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> unit.tryToAttack<SingletonBehaviourT>(requiresAwarenessOfTarget, logResult);
	public bool tryToAttackPlayer
	(
		bool requiresAwarenessOfTarget = Default.castingRequiringAwarenessOfTarget,
		bool? logResult = null
	)
		=> unit.tryToAttackPlayer(requiresAwarenessOfTarget, logResult);
	#endregion trying to cast particular abilities
	#endregion Unit


	#region Intelligence

	#region targeting
	public HashSet<IntelligenceT> enemies<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.enemies<IntelligenceT>();
	public HashSet<Unit> enemyUnits<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.enemyUnits<IntelligenceT>();
	public HashSet<IntelligenceT> allies<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.allies<IntelligenceT>();
	public HashSet<Unit> allyUnits<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.allyUnits<IntelligenceT>();
	public HashSet<OtherIntelligenceT> awornEnemies<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>, IIntelligence
		=> unit.awornEnemies<OtherIntelligenceT>();
	public HashSet<Unit> awornEnemyUnits<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.awornEnemyUnits<IntelligenceT>();
	public HashSet<OtherIntelligenceT> awornAllies<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>, IIntelligence
		=> unit.awornAllies<OtherIntelligenceT>();
	public HashSet<Unit> awornAllyUnits<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.awornAllyUnits<IntelligenceT>();
	public OtherIntelligenceT nearestAwornEnemy<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>, IIntelligence
		=> unit.nearestAwornEnemy<OtherIntelligenceT>();
	public HashSet<Unit> nearestAwornEnemyUnit<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.nearestAwornEnemyUnit<IntelligenceT>();
	public OtherIntelligenceT nearestAwornAlly<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>, IIntelligence
		=> unit.nearestAwornAlly<OtherIntelligenceT>();
	public HashSet<Unit> nearestAwornAllyUnit<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.nearestAwornAllyUnit<IntelligenceT>();
	public IntelligenceT nearestEnemy<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.nearestEnemy<IntelligenceT>();
	public HashSet<Unit> nearestEnemyUnit<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.nearestEnemyUnit<IntelligenceT>();
	public IntelligenceT nearestAlly<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.nearestAlly<IntelligenceT>();
	public HashSet<Unit> nearestAllyUnit<IntelligenceT>()
		where IntelligenceT : Intelligence<IntelligenceT>, IIntelligence
		=> unit.nearestAllyUnit<IntelligenceT>();
	public bool isAwareOfAnyEnemy<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>, IIntelligence
		=> unit.isAwareOfAnyEnemy<OtherIntelligenceT>();
	public bool isAwareOfAnyAlly<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>, IIntelligence
		=> unit.isAwareOfAnyAlly<OtherIntelligenceT>();
	public HashSet<Unit> enemyStructures(bool includeSelf = Default.enemyInclusionOfSelf)
		=> unit.enemyStructures(includeSelf);
	public HashSet<Unit> allyStructures(bool includeSelf = Default.allyInclusionOfSelf)
		=> unit.allyStructures(includeSelf);
	public HashSet<Unit> awornEnemyStructures(bool includeSelf = Default.enemyInclusionOfSelf)
		=> unit.awornEnemyStructures(includeSelf);
	public HashSet<Unit> awornAllyStructures(bool includeSelf = Default.allyInclusionOfSelf)
		=> unit.awornAllyStructures(includeSelf);
	public Unit nearestAwornEnemyStructure(bool includeSelf = Default.enemyInclusionOfSelf)
		=> unit.nearestAwornEnemyStructure(includeSelf);
	public Unit nearestAwornAllyStructure(bool includeSelf = Default.allyInclusionOfSelf)
		=> unit.nearestAwornAllyStructure(includeSelf);
	public bool isAwareOfAnyEnemyStructure(bool includeSelf = Default.enemyInclusionOfSelf)
		=> unit.isAwareOfAnyEnemyStructure(includeSelf);
	public bool isAwareOfAnyAllyStructure(bool includeSelf = Default.allyInclusionOfSelf)
		=> unit.isAwareOfAnyAllyStructure(includeSelf);
	#endregion targeting
	#endregion Intelligence
	#endif
	#endregion Unitology
}