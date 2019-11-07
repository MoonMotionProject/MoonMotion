using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Default:
// • provides various default state:
//   · constants ("const" variables, and "readonly" variables where "const" variables are not possible)
//   · properties (which should be constant in result) serving as constants (where constants are not possible)
// #default #navmesh #unitology
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
	#endregion miscellaneous

	#region game object creation
	public const string newGameObjectName = "New Game Object";
	public const bool matchingOfRotationToParentForFreshGameObjectCreation = false;
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
	public const bool repeatingCoroutineStartingNowVersusAtNextCheck = true;
	#region threading
	public const bool syncingOfThreadWithUpdate = true;
	#endregion threading
	#endregion execution

	#region editor visualization
	public static readonly Color visualizationColor = Color.white.withAlpha(.3f);
	public const bool choiceToVisualizeInEditor = true;
	public const bool scalingOfVisualizedIcons = true;
	public static readonly Vector3 boxVisualizationDimensions = new Vector3(.3f, .3f, .3f);
	public static readonly Color spawningVisualizationColor = Color.green.withAlpha(.8f);
	#if NAV_MESH_COMPONENTS
	public static readonly Color destinationVisualizationColor = Color.green.withAlpha(.8f);
	#endif
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
	public const bool destinatingAvoidanceOfProvidedSolidity = false;
	#endif
	#endregion Navmesh Components

	#region Unitology
	#if UNITOLOGY
	public const Allegiance allegiance = Allegiance.playerNeutral;
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
	public static readonly Color awaradiusVisualizationColor = Colors.red.withAlpha(.35f);
	public const bool enemyInclusionOfSelf = false;
	public const bool allyInclusionOfSelf = true;
	#endregion targeting
	#region abilities
	public static readonly Color selectedAbilityRangeVisualizationColor = Colors.purple.withAlpha(.35f);
	#region casting
	public const bool castingRequiringAwarenessOfTarget = true;
	public const Fense fense = Fense.offense;
	public const bool castingRequiringAbleness = true;
	public const float targetedAbilityRange = Infinity.asAFloat;
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
	public const float effectDamage = 0f;
	public const float effectHealing = 0f;
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
	#endif
	#region traits
	public const bool pendanceNavigatingAvoidanceOfProvidedSolidity = true;
	#endregion traits
	#endregion Unitology

	#region Odin
	#if ODIN_INSPECTOR
	public const float titleSpaceBefore = 6;
	#endif
	#endregion Odin
}