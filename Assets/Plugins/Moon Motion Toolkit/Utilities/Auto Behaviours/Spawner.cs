using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

public class Spawner : EnabledsBehaviour<Spawner>
{
	#region variables


	#region spawning
	
	#if ODIN_INSPECTOR
	private string template_TitleSubtitle => template.name;
	[TabGroup("Spawning")]
	[Title("What:", "$template_TitleSubtitle", horizontalLine: false)]
	[PreviewField(Alignment = ObjectFieldAlignment.Left, AlignmentHasValue = true, Height = 80)]
	[Required("Template is required")]
	[HideLabel]
	#else
	[BoxGroup("Spawning")]
	[ShowAssetPreview]
	#endif
	[Tooltip("the template object to spawn instances of")]
	public GameObject template;

	#if ODIN_INSPECTOR
	[TabGroup("Spawning")]
	[Title("Where")]
	[ToggleLeft]
	#else
	[BoxGroup("Spawning")]
	#endif
	[Tooltip("whether spawned objects are spawned positioned as children to a particular parent instead of this object")]
	public bool useParticularPositionParent = false;

	#if ODIN_INSPECTOR
	[TabGroup("Spawning")]
	[Indent]
	[HideLabel]
	[ShowIf("useParticularPositionParent")]
	#else
	[BoxGroup("Spawning")]
	#endif
	[Tooltip("the particular position parent object which spawned objects are spawned positioned as children of instead of this object (if null, uses this object)")]
	public GameObject particularPositionParent = null;

	public GameObject spawningPositionParent
		=>	useParticularPositionParent ?
				particularPositionParent.ifYullOtherwise(()=> gameObject) :
				gameObject;

	public Vector3 spawningPosition => spawningPositionParent.position();

	#region spawning position editor visualization
	#if UNITY_EDITOR

	#if ODIN_INSPECTOR
	[TabGroup("Spawning")]
	[ToggleLeft]
	#else
	[BoxGroup("Spawning")]
	#endif
	[Tooltip("whether to visualize a cube for the spawning position")]
	public bool visualizeSpawningPosition = Default.choiceToVisualizeInEditor;
	#endif
	
	#if UNITY_EDITOR
	#if ODIN_INSPECTOR
	[TabGroup("Spawning")]
	[Indent]
	[ShowIf("visualizeSpawningPosition")]
	[HideLabel]
	#else
	[BoxGroup("Spawning")]
	#endif
	[Tooltip("the color to use for editor visualization of the spawning position")]
	public Color spawningPositionVisualizationColor = Default.spawningVisualizationColor;
	#endif
	#endregion spawning position editor visualization

	#if ODIN_INSPECTOR
	[TabGroup("Spawning")]
	[Title("Hierarchy")]
	[ToggleLeft]
	#else
	[BoxGroup("Spawning")]
	#endif
	[Tooltip("whether spawned objects are childed to a particular parent instead of this object")]
	public bool useParticularHierarchyParent = true;

	#if ODIN_INSPECTOR
	[TabGroup("Spawning")]
	[Indent]
	[ToggleLeft]
	[LabelText("Sibling Spawns")]
	[ShowIf("useParticularHierarchyParent")]
	#else
	[BoxGroup("Spawning")]
	#endif
	[Tooltip("whether the particular hierarchy parent is this object's parent, such that spawned objects are siblings")]
	public bool particularHierarchyParentIsParent = true;

	#if ODIN_INSPECTOR
	[TabGroup("Spawning")]
	[Indent]
	[HideLabel]
	[ShowIf("@useParticularHierarchyParent && !particularHierarchyParentIsParent")]
	#else
	[BoxGroup("Spawning")]
	#endif
	[Tooltip("the particular parent object to which to child spawned objects instead of this object (if null, uses this object)")]
	public GameObject specifiedParticularHierarchyParent = null;

	public GameObject spawningHierarchyParent
		=>	useParticularHierarchyParent ?
				particularHierarchyParentIsParent ?
					parentObject :
					specifiedParticularHierarchyParent.ifYullOtherwise(()=> gameObject) :
				gameObject;

	[SerializeField]
	[HideInInspector]
	private int countToSpawn_ = 1;
	private const string countToSpawn_Tooltip = "the number of instances to spawn";
	#if ODIN_INSPECTOR
	[TabGroup("Spawning")]
	[Title("How Many")]
	[PropertyTooltip(countToSpawn_Tooltip)]
	[ShowInInspector]
	#else
	[BoxGroup("Spawning")]
	[Tooltip(countToSpawn_Tooltip)]
	#endif
	public int countToSpawn
	{
		get {return countToSpawn_;}
		set
		{
			countToSpawn_ = value;
			countToSpawn_ = countToSpawn.atLeastZero();
		}
	}

	[SerializeField]
	[HideInInspector]
	private float delayBetweenEach_ = Default.delay;
	private const string delayBetweenEach_Tooltip
		= "the delay to wait in between spawning each in the count (does not postpone the potential interval)";
	#if ODIN_INSPECTOR
	private bool delayBetweenEach_ShowIf => countToSpawn.isPlural();
	[TabGroup("Spawning")]
	[PropertyTooltip(delayBetweenEach_Tooltip)]
	[ShowIf("delayBetweenEach_ShowIf")]
	[ShowInInspector]
	#else
	[BoxGroup("Spawning")]
	[Tooltip(delayBetweenEach_Tooltip)]
	#endif
	public float delayBetweenEach
	{
		get {return delayBetweenEach_;}
		set
		{
			delayBetweenEach_ = value;
			delayBetweenEach_ = delayBetweenEach.atLeastZero();
		}
	}
	#endregion spawning


	#region interval

	#if ODIN_INSPECTOR
	private bool spawnOnInterval_EnableIf => UnityIs.inEditorEditMode;
	[TabGroup("Interval")]
	[InfoBox("will just spawn once at start", "justSpawnsOnceAtStart")]
	[ToggleLeft]
	[EnableIf("spawnOnInterval_EnableIf")]
	#else
	[BoxGroup("Interval")]
	#endif
	[Tooltip("whether to repeatedly spawn, on a consistent interval (only has an effect at the start)")]
	public bool spawnOnInterval = true;

	public bool justSpawnsOnceAtStart => !spawnOnInterval;

	#if ODIN_INSPECTOR
	[TabGroup("Interval")]
	[Indent]
	[HideLabel]
	[ShowIf("spawnOnInterval")]
	#else
	[BoxGroup("Interval")]
	#endif
	[Tooltip("the delay to wait between spawnings")]
	public float spawnInterval = Default.interval;
	
	#if ODIN_INSPECTOR
	[TabGroup("Interval")]
	[Indent]
	[ToggleLeft]
	[ShowIf("spawnOnInterval")]
	#else
	[BoxGroup("Interval")]
	#endif
	[Tooltip("whether to wait the spawn interval before the first spawn (at the start)")]
	public bool intervalBeforeFirstSpawn = false;
	#endregion interval
	
	
	#region force

	#if ODIN_INSPECTOR
	[TabGroup("Force")]
	[ToggleLeft]
	#else
	[BoxGroup("Force")]
	#endif
	[Tooltip("whether to apply force to spawned objects upon spawning them")]
	public bool applyForceToSpawns = false;

	#if ODIN_INSPECTOR
	[TabGroup("Force")]
	[Indent]
	[LabelText("Magnitude")]
	[ShowIf("applyForceToSpawns")]
	#else
	[BoxGroup("Force")]
	#endif
	[Tooltip("the magnitude with which to apply force to spawned objects")]
	public float forceMagnitude = Default.forceMagnitude;

	#if ODIN_INSPECTOR
	private bool forceDirection_ShowIf => applyForceToSpawns && forceMagnitude.isNonzero();
	[TabGroup("Force")]
	[Indent]
	[EnumToggleButtons]
	[HideLabel]
	[ShowIf("forceDirection_ShowIf")]
	#else
	[BoxGroup("Force")]
	#endif
	[Tooltip("the basic direction in which to apply force to spawned objects")]
	public BasicDirection forceDirection = Default.basicDirection;
	#endregion force
	#endregion variables




	#region methods


	// method: spawn one of the set template, then return the spawned object //
	#if UNITY_EDITOR
	#if ODIN_INSPECTOR
	[TabGroup("Spawning")]
	[Title("Testing")]
	[Button]
	#else
	[ContextMenu("Spawn")]
	#endif
	#endif
	public GameObject spawnOne()
		=>	spawningPositionParent.createChildObject(template)
				.setParentTo
				(
					spawningHierarchyParent,
					useParticularPositionParent || useParticularHierarchyParent
				)
				.applyForceAlong(relativeDirectionFor(forceDirection), forceMagnitude,
					applyForceToSpawns);

	// method: spawn the set count of the template object //
	#region adjunct
	private void spawnCount_Recursion(int timesRemaining)
	{
		if (timesRemaining.isPositive())
		{
			spawnOne();
			timesRemaining -= 1;
			if (timesRemaining.isPositive())
			{
				planToExecuteAfter
				(
					delayBetweenEach,
					()=> spawnCount_Recursion(timesRemaining)
				);
			}
		}
	}
	#endregion adjunct
	#if UNITY_EDITOR
	#if ODIN_INSPECTOR
	[TabGroup("Spawning")]
	[Button]
	#else
	[ContextMenu("Spawn Count")]
	#endif
	#endif
	public void spawnCount()
		=> spawnCount_Recursion(countToSpawn);

	// method: plan to call 'spawnCountAndPlanToRepeat' after the spawn interval //
	public void plan()
		=>	planToExecuteAfter
			(
				spawnInterval,
				()=> spawnCountAndPlanToRepeat()
			);

	// method: spawn the set count of the template object and plan to repeat this method after the spawn interval //
	public void spawnCountAndPlanToRepeat()
	{
		spawnCount();
		plan();
	}
	#endregion methods




	#region updating
	

	// upon editor visualization while selected: //
	private void OnDrawGizmosSelected()
		=>	Visualize.boxSittingAt(spawningPositionParent,
				spawningPositionVisualizationColor,
				visualizeSpawningPosition);


	// at the start: //
	private void Start()
	{
		if (spawnOnInterval)
		{
			if (intervalBeforeFirstSpawn)
			{
				plan();
			}
			else
			{
				spawnCountAndPlanToRepeat();
			}
		}
		else
		{
			spawnCount();
		}
	}
	#endregion updating
}