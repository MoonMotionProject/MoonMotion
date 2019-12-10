#if ODIN_INSPECTOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

// #spawning
public class Spawner : EnabledsBehaviour<Spawner>
{
	#region variables


	#region spawning
	
	private string template_TitleSubtitle => template.isYull() ? template.name : "null";
	[TabGroup("Spawning")]
	[Title("What:", "$template_TitleSubtitle", horizontalLine: false)]
	[PropertyOrder(-3)]
	[Tooltip("the template object to spawn instances of")]
	[PreviewField(Alignment = ObjectFieldAlignment.Left, AlignmentHasValue = true, Height = 80)]
	[Required("Template is required")]
	[HideLabel]
	public GameObject template;
	
	[TabGroup("Spawning")]
	[Title("Where")]
	[PropertyOrder(-2)]
	[Tooltip("whether spawned objects are spawned positioned as children to a particular parent instead of this object")]
	public bool useParticularPositionParent = true;

	private GameObject automatedParticularPositionParent
		=>	hasAnyLodal<SpawnPoint>() ?
				lodespondingSpawnPoint.gameObject :
				gameObject;
	private GameObject automateParticularPositionParent()
		=> particularPositionParent_ = automatedParticularPositionParent;	
	private GameObject particularPositionParent_ = null;
	[TabGroup("Spawning")]
	[PropertyOrder(-1)]
	[Indent]
	[PropertyTooltip("the particular position parent object which spawned objects are spawned positioned as children of instead of this object")]
	[InfoBox("when automated:\nif a lodal Spawn Point is found, its object will be used; otherwise, this object will be used")]
	[InlineButton("automateParticularPositionParent", "Automate")]
	[ShowIf("useParticularPositionParent")]
	[HideLabel]
	[ShowInInspector]
	public GameObject particularPositionParent
	{
		get
		{
			return	particularPositionParent_.isYull() ?
						particularPositionParent_ :
						automateParticularPositionParent();
		}
		set {particularPositionParent_ = value;}
	}

	public GameObject spawningPositionParent
		=>	useParticularPositionParent ?
				particularPositionParent.ifYullOtherwise(()=> gameObject) :
				gameObject;

	public Vector3 spawningPosition => spawningPositionParent.position();

	#region spawning position editor visualization
	#if UNITY_EDITOR
	
	[TabGroup("Spawning")]
	[Tooltip("whether to visualize a cube for the spawning position")]
	public bool visualizeSpawningPosition = Default.choiceToVisualizeInEditor;
	
	private void defaultSpawningPositionVisualizationColor()
		=> spawningPositionVisualizationColor = Default.spawningVisualizationColor;
	[TabGroup("Spawning")]
	[Indent]
	[Tooltip("the color to use for editor visualization of the spawning position")]
	[InlineButton("defaultSpawningPositionVisualizationColor", "Default")]
	[ShowIf("visualizeSpawningPosition")]
	[HideLabel]
	public Color spawningPositionVisualizationColor = Default.spawningVisualizationColor;
	#endif
	#endregion spawning position editor visualization
	
	[TabGroup("Spawning")]
	[Title("Hierarchy")]
	[Tooltip("whether spawned objects are childed to a particular parent instead of this object")]
	public bool useParticularHierarchyParent = true;
	
	[TabGroup("Spawning")]
	[Indent]
	[Tooltip("whether the particular hierarchy parent is this object's parent, such that spawned objects are siblings")]
	[LabelText("Sibling Spawns")]
	[ShowIf("useParticularHierarchyParent")]
	public bool particularHierarchyParentIsParent = true;
	
	[TabGroup("Spawning")]
	[Indent]
	[Tooltip("the particular parent object to which to child spawned objects instead of this object (if null, uses this object)")]
	[ShowIf("@useParticularHierarchyParent && !particularHierarchyParentIsParent")]
	[HideLabel]
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
	[TabGroup("Spawning")]
	[Title("How Many")]
	[PropertyTooltip(countToSpawn_Tooltip)]
	[ShowInInspector]
	public int countToSpawn
	{
		get {return countToSpawn_;}
		set {countToSpawn_ = value.atLeastZero();}
	}

	[SerializeField]
	[HideInInspector]
	private float delayBetweenEach_ = Default.delay;
	private const string delayBetweenEach_Tooltip
		= "the delay to wait in between spawning each in the count (does not postpone the potential interval)";
	private bool delayBetweenEach_ShowIf => countToSpawn.isPlural();
	[TabGroup("Spawning")]
	[PropertyTooltip(delayBetweenEach_Tooltip)]
	[ShowIf("delayBetweenEach_ShowIf")]
	[ShowInInspector]
	public float delayBetweenEach
	{
		get {return delayBetweenEach_;}
		set {delayBetweenEach_ = value.atLeastZero();}
	}

	[SerializeField]
	[HideInInspector]
	private float startingSpawnDelay_ = Default.delay;
	[TabGroup("Spawning")]
	[Title("When")]
	[ShowInInspector]
	public float startingSpawnDelay
	{
		get {return startingSpawnDelay_;}
		set {startingSpawnDelay_ = value.atLeastZero();}
	}
	#endregion spawning


	#region interval
	
	private bool spawnOnInterval_EnableIf => UnityIs.inEditorEditMode;
	[TabGroup("Interval")]
	[Tooltip("whether to repeatedly spawn, on a consistent interval (only has an effect at the start)")]
	[InfoBox("will just spawn once at start", "justSpawnsOnceAtStart")]
	[EnableIf("spawnOnInterval_EnableIf")]
	public bool spawnOnInterval = true;

	public bool justSpawnsOnceAtStart => !spawnOnInterval;
	
	[TabGroup("Interval")]
	[Indent]
	[Tooltip("the delay to wait between spawnings")]
	[ShowIf("spawnOnInterval")]
	[HideLabel]
	public float spawnInterval = Default.interval;
	
	[TabGroup("Interval")]
	[Indent]
	[Tooltip("whether to wait the spawn interval before the first spawn (at the start)")]
	[ShowIf("spawnOnInterval")]
	public bool intervalBeforeFirstSpawn = false;
	#endregion interval
	
	
	#region facing
	
	[TabGroup("Facing")]
	[Tooltip("whether to, when creating a spawn, set its y euler angle to that of this spawner")]
	public bool matchEulerAngleYWithSpawner = true;
	#endregion facing
	
	
	#region force
	
	[TabGroup("Force")]
	[Tooltip("whether to apply force to spawned objects upon spawning them")]
	public bool applyForceToSpawns = false;
	
	[TabGroup("Force")]
	[Indent]
	[Tooltip("the magnitude with which to apply force to spawned objects")]
	[ShowIf("applyForceToSpawns")]
	[LabelText("Magnitude")]
	public float forceMagnitude = Default.forceMagnitude;
	
	private bool forceDirection_ShowIf => applyForceToSpawns && forceMagnitude.isNonzero();
	[TabGroup("Force")]
	[Indent]
	[Tooltip("the basic direction in which to apply force to spawned objects")]
	[EnumToggleButtons]
	[ShowIf("forceDirection_ShowIf")]
	[HideLabel]
	public BasicDirection forceDirection = Default.basicDirection;
	#endregion force
	#endregion variables




	#region methods


	// method: spawn one of the set template, then return the spawned object //
	[TabGroup("Spawning")]
	[Title("Testing")]
	[Button]
	public GameObject spawnOne()
	{
		GameObject spawn
			=	spawningPositionParent.createChildObject(template)
					.setParentTo(spawningHierarchyParent,
						useParticularPositionParent || useParticularHierarchyParent)
					.setEulerAngleYTo(this, matchEulerAngleYWithSpawner)
					.applyForceAlong(relativeDirectionFor(forceDirection), forceMagnitude,
						applyForceToSpawns);

		return spawn;
	}

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
				#if UNITY_EDITOR
				if (UnityIs.inEditorEditMode)
				{
					spawnCount_Recursion(timesRemaining);
				}
				else
				{
				#endif
					executeAfter
					(
						delayBetweenEach,
						()=> spawnCount_Recursion(timesRemaining)
					);
				#if UNITY_EDITOR
				}
				#endif
			}
		}
	}
	#endregion adjunct
	[TabGroup("Spawning")]
	[Button]
	public void spawnCount()
		=> spawnCount_Recursion(countToSpawn);

	// method: plan to call 'spawnCountAndPlanToRepeat' after the spawn interval //
	public void plan()
		=>	executeAfter
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
	
	public void startingSpawn()
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
	#endregion methods




	#region updating
	
	
	// upon editor visualization while selected: //
	#if UNITY_EDITOR
	private void OnDrawGizmosSelected()
		=>	Visualize.boxSittingAt(spawningPosition,
				spawningPositionVisualizationColor,
				visualizeSpawningPosition);
	#endif


	// at the start: //
	private void Start()
		=> executeAfter(startingSpawnDelay, startingSpawn);
	#endregion updating
}
#endif