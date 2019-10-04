using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Default:
// • provides various default state:
//   · constants ("const" variables, and "readonly" variables where "const" variables are not possible)
//   · properties (which should be constant in result) serving as constants (where constants are not possible)
// #default #auto
public static class Default
{
	#region miscellaneous
	public const float delay = 1f;
	public const float temporaryObjectDestructionDelay = 1f;
	public static readonly LayerMask layerMask = LayerMasks.everything;
	public const Affinity affinity = Affinity.attraction;
	#endregion miscellaneous

	#region printing
	public const string listingSeparator = ", ";
	public const string loggingSeparator = ": ";
	#endregion printing

	#region editor visualization
	public static readonly Color visualizationColor = Color.white.withAlpha(.3f);
	public const bool choiceToVisualizeInEditor = true;
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
	#endregion raycasting

	#region force
	public const float forceMagnitude = 10f;
	public const float forceReach = Infinity.asAFloat;
	public const InterpolationCurve forceCurve = InterpolationCurve.quadratic;
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

	#if MOON_MOTION_TOOLKIT
	#region Controller
	public const Controller.Handedness controllerHandedness = Controller.Handedness.infinite;
	public const ushort vibrationIntensity = 500;
	#endregion Controller
	#endif
}