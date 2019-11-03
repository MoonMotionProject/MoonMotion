using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
#if NAV_MESH_COMPONENTS
using UnityEngine.AI;
#endif

// Auto Behaviour Layer Component Shortcuts Moon Motion:
// #auto #shortcuts #tracking #unitology
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

	#region destinating
	public bool destinateTo(object destinationPosition_PositionProvider)
		=> navmeshAgent.destinateTo(destinationPosition_PositionProvider);
	public bool destinateTo<SingletonBehaviourT>() where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> navmeshAgent.destinateTo<SingletonBehaviourT>();
	public bool destinateToCamera()
		=> navmeshAgent.destinateToCamera();
	#endregion destinating
	
	#region determining haltedness
	public bool isHalted => navmeshAgent.isHalted();
	public bool isNotHalted => navmeshAgent.isNotHalted();
	#endregion determining haltedness
	
	#region setting haltedness
	public AutoBehaviourT setHaltednessTo(bool boolean)
		=> selfAfter(()=> navmeshAgent.setHaltednessTo(boolean));
	public AutoBehaviourT halt()
		=> selfAfter(()=> navmeshAgent.halt());
	public AutoBehaviourT unhalt()
		=> selfAfter(()=> navmeshAgent.unhalt());
	#endregion setting haltedness
	
	#region navigating
	public bool navigateTo(object destinationPosition_PositionProvider)
		=> navmeshAgent.navigateTo(destinationPosition_PositionProvider);
	public bool navigateTo<SingletonBehaviourT>() where SingletonBehaviourT : SingletonBehaviour<SingletonBehaviourT>
		=> navmeshAgent.navigateTo<SingletonBehaviourT>();
	public bool navigateToPlayer()
		=> navmeshAgent.navigateToPlayer();
	public bool navigateToCamera()
		=> navmeshAgent.navigateToCamera();
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
	public bool isAwareOf(object targetPosition_PositionProvider)
		=> unit.isAwareOf(targetPosition_PositionProvider);
	public bool isNotAwareOf(object targetPosition_PositionProvider)
		=> unit.isNotAwareOf(targetPosition_PositionProvider);
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
	public HashSet<IntelligenceT> enemies<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> unit.enemies<IntelligenceT>();
	public HashSet<IntelligenceT> allies<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> unit.allies<IntelligenceT>();
	public HashSet<OtherIntelligenceT> awornEnemies<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
		=> unit.awornEnemies<OtherIntelligenceT>();
	public HashSet<OtherIntelligenceT> awornAllies<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
		=> unit.awornAllies<OtherIntelligenceT>();
	public OtherIntelligenceT nearestAwornEnemy<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
		=> unit.nearestAwornEnemy<OtherIntelligenceT>();
	public OtherIntelligenceT nearestAwornAlly<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
		=> unit.nearestAwornAlly<OtherIntelligenceT>();
	public IntelligenceT nearestEnemy<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> unit.nearestEnemy<IntelligenceT>();
	public IntelligenceT nearestAlly<IntelligenceT>() where IntelligenceT : Intelligence<IntelligenceT>
		=> unit.nearestAlly<IntelligenceT>();
	public bool isAwareOfAnyEnemy<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
		=> unit.isAwareOfAnyEnemy<OtherIntelligenceT>();
	public bool isAwareOfAnyAlly<OtherIntelligenceT>()
		where OtherIntelligenceT : Intelligence<OtherIntelligenceT>
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