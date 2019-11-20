using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Default:
// • provides various default state:
//   · constants ("const" variables, and "readonly" variables where "const" variables are not possible)
//   · properties (which should be constant in result) serving as constants (where constants are not possible)
// #constants #navmesh #unitology
public static class Default
{
	#region miscellaneous
	public const float delay = 1f;
	public const float temporaryObjectDestructionDelay = 1f;
	public static readonly LayerMask layerMask = Layers.all;
	public const Affinity affinity = Affinity.attraction;
	public const bool leftnessVersusRightness = true;
	public const float thresholdDistance = .01f;
	public const bool nullsAsEmpty = true;
	public const bool errorSilencing = false;
	public const bool editorExecutionIfPlaymodeHasChanged = true;
	public const bool beginningNowVersusAtNextCycle = true;
	#endregion miscellaneous

	#region hierarchy
	#if UNITY_EDITOR
	public const float hierarchyIconSize = 14f;
	public const float hierarchyIconPaddingRight = 6f;
	#endif
	#endregion hierarchy

	#region transformations
	public static readonly Vector3 localScale = FloatsVector.ones;
	#endregion transformations

	#region game object creation
	public const string newGameObjectName = "New Game Object";
	public const bool matchingOfRotationToParentForFreshGameObjectCreation = true;
	public const bool matchingOfLabelsToParentForFreshGameObjectCreation = true;
	public const bool matchingOfRotationToParentForTemplatedGameObjectCreation = false;
	public const bool matchingOfLabelsToParentForTemplatedGameObjectCreation = false;
	#endregion game object creation

	#region printing
	public const string listingSeparator = ", ";
	public const string loggingSeparator = ": ";
	#endregion printing

	#region execution
	public const Coroute coroute = Coroute.nowAndAtEveryCheck;
	#region threading
	public const bool syncingOfThreadWithUpdate = true;
	#endregion threading
	#endregion execution

	#region editor visualization
	public static readonly Color visualizationColor = Colors.white.withAlpha(.3f);
	public const bool choiceToVisualizeInEditor = true;
	public const bool scalingOfVisualizedIcons = true;
	public static readonly Vector3 boxVisualizationDimensions = .3f.toFloatsVector();
	public const float positionVisualizationColorAlpha = .8f;
	public static readonly Color positionVisualizationColor = Colors.orange.withAlpha(positionVisualizationColorAlpha);
	public static readonly Color spawningVisualizationColor = Colors.magenta.withAlpha(positionVisualizationColorAlpha);
	#endregion editor visualization

	#region components
	public const bool inclusionOfInactiveComponents = true;
	#endregion components

	#region shaders
	public static Shader shader_IfInAwakeOrStart => Shaders.standard_IfInAwakeOrStart;
	public static Shader outlineShader_IfInAwakeOrStart => Shaders.penetratingStroke_IfInAwakeOrStart;
	#endregion shaders

	#region materials
	public static Material material_IfInAwakeOrStart => Materials.standard_IfInAwakeOrStart;
	public static Material outlineMaterial_IfInAwakeOrStart => Materials.penetratingStroke_IfInAwakeOrStart;
	#endregion materials

	#region time
	public const float interval = 1f;
	#endregion time

	#region displacement
	public static readonly Vector3 displacement = FloatsVector.zeroes;
	#endregion displacement

	#region direction
	public static readonly Vector3 direction = Direction.forward;
	public const BasicDirection basicDirection = BasicDirection.forward;
	#endregion direction

	#region distinctivity
	public const Distinctivity directionDistinctivity = Distinctivity.absolute;
	public const Distinctivity basicDirectionDistinctivity = Distinctivity.relative;
	#endregion distinctivity

	#region LineRenderer
	public const float lineRendererWidth = .01f;
	#endregion LineRenderer

	#region raycasting
	public const bool raycastQueryingForFirstHitOnly = false;
	public const bool raycastingPositionalCollidersQuerying = true;
	public static readonly Vector3 raycastingDirection = Direction.forward;
	public const BasicDirection raycastingBasicDirection = BasicDirection.forward;
	public const float raycastingDistance = 15f;
	public const float outlineRaycastingDistance = Infinity.asAFloat;
	public const RaycastQuery raycastQuery = RaycastQuery.unlimitedHitsAndAllPositionalColliders;
	public const QueryTriggerInteraction raycastingTriggerColliderQuery = QueryTriggerInteraction.Collide;
	public const Distinctivity raycastingDistinctivity = Distinctivity.relative;
	public const bool choiceToRenderRaycastLine = true;
	public const bool choiceToRenderRaycastLineOnlyToHit = true;
	#endregion raycasting

	#region force
	public const float forceMagnitude = 10f;
	public const float forceReach = Infinity.asAFloat;
	public const InterpolationCurve forceCurve = InterpolationCurve.quadratic;
	public const InterpolationCurve mistargetedForceCurve = InterpolationCurve.linear;
	public const bool targetedForceClamping = true;
	public const bool targetedForceZeroingOutsideReach = true;
	public const bool directedForceClamping = true;
	public const bool directedForceZeroingOutsideReach = true;
	#endregion force

	#region radial
	public const QueryTriggerInteraction radialTriggerColliderQuery = QueryTriggerInteraction.Collide;
	public const float forceRadius = 15f;
	#endregion radial

	#region waves
	public const float waveTrough = Wave.troughSine;
	public const float waveCrest = Wave.crestSine;
	public const float waveDuration = Wave.durationSine;
	public const float waveDurationalOffset = Wave.durationalOffsetSine;
	#endregion waves

	#region Moon Motion Toolkit
	#if MOON_MOTION_TOOLKIT
	#region Controller
	public const Controller.Handedness controllerHandedness = Controller.Handedness.infinite;
	public const ushort vibrationIntensity = 500;
	#endregion Controller
#endif
	#endregion Moon Motion Toolkit

	#region fense
	#endregion fense

	#region Navmesh Components
	#if NAV_MESH_COMPONENTS
	public const float navmeshAgentDelay = .01f;
	public const bool destinatingAvoidanceOfProvidedSolidity = false;
	public static readonly Color destinationVisualizationColor = positionVisualizationColor;
	#endif
	#endregion Navmesh Components

	#region Unitology
	#if UNITOLOGY
	public const float unitologySphereVisualizationColorAlpha = .35f;
	#region allegiance
	public const Allegiance allegiance = Allegiance.playerNeutral;
	public const AllegianceFilter allegianceFilter = AllegianceFilter.all;
	#endregion allegiance
	#region vitality
	public const InterpolationCurve healthbarInterpolationCurve = InterpolationCurve.quadratic;
	#region health
	public const float constitution = 1000f;
	#endregion health
	#region surplus
	public const float trop = 0f;
	public const float shielding = 0f;
	#endregion surplus
	#region expiration
	public const bool unitEventUponExpiring = false;
	public const bool unitDestructionUponExpiring = true;
	#endregion expiration
	#endregion vitality
	#region targeting
	public static readonly LayerMask enemyLayers = Layers.none;
	public static readonly LayerMask allyLayers = Layers.none;
	public const float awaradius = 20f;
	public static readonly Color allyAwarenessVisualizationColor = Colors.green.withAlpha(unitologySphereVisualizationColorAlpha);
	public static readonly Color enemyAwarenessVisualizationColor = Colors.red.withAlpha(unitologySphereVisualizationColorAlpha);
	public static readonly Color awaradiusVisualizationColor = enemyAwarenessVisualizationColor;
	public const bool allegianceIrrelevantInclusionOfSelf = false;
	public const bool allyInclusionOfSelf = true;
	public const bool enemyInclusionOfSelf = false;
	public const bool nearestUnitInclusionOfSelf = false;
	public const bool nearestAllegianceIrrelevantInclusionOfSelf = nearestUnitInclusionOfSelf;
	public const bool nearestAllyInclusionOfSelf = nearestUnitInclusionOfSelf;
	public const bool nearestEnemyInclusionOfSelf = nearestUnitInclusionOfSelf;
	public const float unitTargetTriggerColliderRadius = .01f;
	#endregion targeting
	#region kit
	public const float intelligentBehaviourDelay = navmeshAgentDelay;
	#region abilities
	#region casting
	public const bool castingRequiringAwarenessOfTarget = true;
	public const Fense fense = Fense.offense;
	public const bool castingRequiringAbleness = true;
	public static readonly Color selectedAbilityRangeVisualizationColor = Colors.abilityCasting.withAlpha(unitologySphereVisualizationColorAlpha);
	public const float targetedAbilityRange = Infinity.asAFloat;
	public static readonly Color pendingRangeVisualizationColor = Colors.abilityPending.withAlpha(unitologySphereVisualizationColorAlpha);
	public static readonly Color channelingRangeVisualizationColor = Colors.abilityChanneling.withAlpha(unitologySphereVisualizationColorAlpha);
	public static readonly Color coolingRangeVisualizationColor = Colors.abilityCooling.withAlpha(unitologySphereVisualizationColorAlpha);
	#endregion casting
	#region frequency
	public const float abilityChannelation = .1f;
	public const float abilityCooldown = 1f;
	#endregion frequency
	#region occupation
	public const bool abilityChannelingHaltingCaster = true;
	public const Abiliority abiliority = Abiliority.claimsAblenessAndCancels;
	#endregion occupation
	#region effects
	public const float effectDuration = 1f;
	public const float damage = 1f;
	public const float healage = 1f;
	#endregion effects
	#region nonabstract abilities
	#region Cancel
	public const bool cancelChannelingHaltingCaster = false;
	public const Abiliority cancelAbiliority = Abiliority.doesNotClaimAblenessAndDoesNotCancel;
	public const float cancelChannelation = 0f;
	public const float cancelCooldown = 0f;
	#endregion Cancel
	#region Move
	public const bool moveChannelingHaltingCaster = false;
	public const Abiliority moveAbiliority = Abiliority.doesNotClaimAblenessButCancels;
	public const float moveChannelation = 0f;
	public const float moveCooldown = 0f;
	#endregion Move
	#region attacks
	public const bool attackChannelingHaltingCaster = abilityChannelingHaltingCaster;
	public const Abiliority attackAbiliority = abiliority;
	public const float attackChannelation = abilityChannelation;
	public const float attackCooldown = abilityCooldown;
	#endregion attacks
	#endregion nonabstract abilities
	#endregion abilities
	#region effects
	public const float damageRadius = 5f;
	#endregion effects
	#region traits
	public const bool pendanceNavigatingAvoidanceOfProvidedSolidity = true;
	#endregion traits
	#endregion kit
	#region intelligence
	public const float behavingInterval = .3f;
	#endregion intelligence
	#endif
	#endregion Unitology

	#region Odin
#if ODIN_INSPECTOR
	public const float propertySpaceBefore = 8f;
	public const float propertySpaceAfter = 0f;
	public const float titleSpaceBefore = 6f;
	#endif
	#endregion Odin
}