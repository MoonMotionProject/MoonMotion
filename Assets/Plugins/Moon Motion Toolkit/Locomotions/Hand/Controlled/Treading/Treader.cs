using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Treader
// • classifies this hand locomotion as the "treading" locomotion
// • when the set locomotion dependencies are met: behaves the parent hand as a treader:
//   · allows the player to direct x and z movement: when this hand is currently being input: sets the player's x and z velocity based on the direction of this hand
//     – if both treaders are currently being input, the left treader is given priority
//   · allows the player to stop x and z movement: when input for either hands stops being input and the player is not currently skiing: sets the player's x and z velocity to 0
// • functions differently based on the input being used:
//   · when touchpad input (the most versatile input for this locomotion) is used:
//     - the speed applied is the max speed curved by the distance of the input position on the touchpad away from the center
//     - when the touchpad is merely touched instead of pressed, moves based on a different max speed for a slower gauge of treading
//     - the movement direction is relative to the orientation of the hand, where that relativity is defined by the input position on the touchpad away from the touchpad's center
//   · when input other than touchpad is used:
//     - the speed applied is simply the max speed setting
//     - there is only one possible gauge of motion (the slower max speed is not used, only the regular max speed is)
//     - the movement direction is simply defined as the orientation of the hand
// • responsiveness factors can be set for when not skiing and for when skiing, respectively
// • includes an option for whether the slower gauge speed (the functionality of merely touching touchpad input) is enabled
// • includes an option to have the regular gauge treading be either held or toggled
// • includes a customizable connection for the transform by which to determine the treading direction, as well as methods to change this to the player or the corresponding hand, or toggle between those two
// • provides a method for determining whether the player is treading currently
// • Treading Audio plays treading footsteps audio while the player is moving via treading; this class broadcasts an event for beginning either gauge of motion, via which Treading Audio has its footsteps audio play
// • note that treading unhindered up stairs (and similarly obstructive objects that aren't meant to be obstructive) would for example require such objects to include a script to teleport the player upward
public class Treader : HandLocomotionControlled
{
	// variables //

	
	// variables for: instancing //
	public static Treader left, right;		// connections - auto: left and right treader instances
	private Treader other;		// connection - auto: the other treader (for the other hand that this treader doesn't belong to)
	
	// variables for: treading //
	[Header("Stuck Failsafe")]
	[Tooltip("the exceptional dependencies by which to be allowed to tread even if the locomotion dependencies are not met, as an ensurance of getting out of stuck situations when the treading locomotion is the only one that would be helpful to escape that is allowed")]
	[ReorderableList]
	public Dependency[] dependenciesStuckFailsafe;		// setting: the exceptional dependencies by which to be allowed to tread even if the locomotion dependencies are not met, as an ensurance of getting out of stuck situations when the treading locomotion is the only one that would be helpful to escape that is allowed
	private Rigidbody playerRigidbody;		// connection - auto: the player rigidbody (to tread)
	[Header("Treading Speed Gauges")]
	[Tooltip("the max speed that this locomotion can set the player to")]
	public float speedMax = 5f;		// setting: the max speed that this locomotion can set the player to
	[Tooltip("whether the slower gauge speed (the touchpad touching functionality) is enabled currently")]
	public bool slowerSpeedEnabled = true;		// setting: whether the slower gauge speed (the touchpad touching functionality) is enabled currently
	[Tooltip("the max speed that this locomotion can set the player to (for the slower gauge of treading only when using touchpad input and the touchpad is merely being touched)")]
	public float slowerSpeedMax = 2.5f;		// setting: the max speed that this locomotion can set the player to (for the slower gauge of treading only when using touchpad input and the touchpad is merely being touched)
	[Header("Treading Speed Sensitivity")]
	[Tooltip("the sensitivity curve – for using touchpad input only – by which to interpolate the max speed from 0, from central touchpad input to edge touchpad input")]
	public InterpolationCurve touchpadSpeedDistanceCurve = InterpolationCurve.linear;		// setting: the sensitivity curve – for using touchpad input only – by which to interpolate the max speed from 0, from central touchpad input to edge touchpad input
	[Header("Treading Speed Responsiveness")]
	public Dependency dependencyDriftingWithinOneSecondAgo;		// setting: the dependency by which to determine whether the player was drifting within one second ago (in order to adjust treading speed responsiveness accordingly)
	[Tooltip("the responsiveness factor, sort of like a measure of agility, by which to hone the player's current velocity to the current target treading velocity - this responsiveness factor is for when not skiing nor drifting")]
	public float responsivenessFactorNonskiingNondrifting = 666666f;		// setting: the responsiveness factor, sort of like a measure of agility, by which to hone the player's current velocity to the current target treading velocity - this responsiveness factor is for when not skiing nor drifting
	[Tooltip("the responsiveness factor, sort of like a measure of agility, by which to hone the player's current velocity to the current target treading velocity - this responsiveness factor is the min for when not skiing but drifting, interpolated to the max based on the ratio of the time ago the player was last drifting out of one second")]
	public float responsivenessFactorNonskiingDriftingMin = 10f;		// setting: the responsiveness factor, sort of like a measure of agility, by which to hone the player's current velocity to the current target treading velocity - this responsiveness factor is the min for when not skiing but drifting, interpolated to the max based on the ratio of the time ago the player was last drifting out of one second
	[Tooltip("the responsiveness factor, sort of like a measure of agility, by which to hone the player's current velocity to the current target treading velocity - this responsiveness factor is the max for when not skiing but drifting, interpolated from the min based on the ratio of the time ago the player was last drifting out of one second")]
	public float responsivenessFactorNonskiingDriftingMax = 100f;		// setting: the responsiveness factor, sort of like a measure of agility, by which to hone the player's current velocity to the current target treading velocity - this responsiveness factor is the max for when not skiing but drifting, interpolated from the min based on the ratio of the time ago the player was last drifting out of one second
	[Tooltip("the curve by which to interpolate between the responsiveness factor min and max settings for when not skiing but drifting")]
	public InterpolationCurve responsivenessFactorNonskiingDriftingCurve = InterpolationCurve.smoother;		// setting: the curve by which to interpolate between the responsiveness factor min and max settings for when not skiing but drifting
	[Tooltip("the responsiveness factor, sort of like a measure of agility, by which to hone the player's current velocity to the current target treading velocity - this responsiveness factor is for when skiing (and regardless of whether the player is drifting)")]
	public float responsivenessFactorSkiing = 1f;		// setting: the responsiveness factor, sort of like a measure of agility, by which to hone the player's current velocity to the current target treading velocity - this responsiveness factor is for when skiing (and regardless of whether the player is drifting)
	[Header("Treading Control (regular gauge only)")]
	[Tooltip("whether to have the normal gauge be controlled via holding the input versus input toggling it")]
	public bool heldVersusToggled = true;		// setting: whether to have the normal gauge be controlled via holding the input versus input toggling it
	private bool regularTreadingToggle = false;		// tracking: whether regular gauge treading is currently toggled on
	[Header("Treading Direction")]
	private Transform handTransform;		// connection - auto: the transform of this treader's hand, which is the main (default, by default) transform to reference for determining the treading direction
	private Transform headTransform;		// connection - auto: the transform of the player's head, which is the alternate transform to reference for determining the treading direction
	[Tooltip("the transform to use for determining the treading direction")]
	public Transform directionReferenceTransform;		// connection - manual: the transform to use for determining the treading direction
	
	
	
	
	// methods //

	
	// methods for: handling input and treading state //
	
	// method: determine whether this hand locomotion's input is currently enabled and currently allowed //
	public override bool locomotionInputEnabledAndAllowed()
		=> (locomotionInputEnabled && (locomotionDependencies.areMet() || dependenciesStuckFailsafe.areMet()));
	// method: determine whether this treader's input experiencing valid input (whether its input is touched or pressed – versus neither touched nor pressed) //
	private bool experiencingValidInput()
		=> (((locomotionInputEnabledAndAllowed() && controller.inputPressed(inputsLocomotion)) || regularTreadingToggle) || (slowerSpeedEnabled && (locomotionInputEnabledAndAllowed() && controller.inputTouched(inputsLocomotion))));
	// method: determine whether the given treader is active //
	public static bool isActive(Treader treader)
		=> (treader && treader.gameObject && treader.gameObject.activeSelf);
	// method: determine whether the left treader is active //
	public static bool leftTreaderActive()
		=> isActive(left);
	// method: determine whether the right treader is active //
	public static bool rightTreaderActive()
		=> isActive(right);
	// method: determine whether the other treader is active //
	public bool otherTreaderActive()
		=> isActive(other);
	// method: determine whether this treader is experiencing significant input – assumes the treader is active //
	private bool experiencingSignificantInput()
	{
		// determine whether the other treader is experiencing prioritized input (because it is active, the left one, and experiencing nonautomated valid input) – thus overriding the input of this treader, making it insignificant //
		bool otherTreaderIsExperiencingPrioritizedInput = ((this == right) && otherTreaderActive() && (other.experiencingValidInput() && !other.regularTreadingToggle));

		// return whether both: experiencing valid input, the other treader is not experiencing prioritized input //
		return (experiencingValidInput() && !otherTreaderIsExperiencingPrioritizedInput);
	}
	// method: determine whether the player is currently treading (regardless of whether they are actually significantly moving as a result) //
	public static bool treading()
		=> ((isActive(left) && left.experiencingSignificantInput()) || (isActive(right) && right.experiencingSignificantInput()));
	// method: toggle the input style of this treader //
	public void toggleInputStyle()
		=> heldVersusToggled = !heldVersusToggled;
	// method: toggle the input style for both treaders //
	public static void toggleInputStyleForBoth()
	{
		left.toggleInputStyle();
		right.toggleInputStyle();
	}
	// method: toggle the input style for both treaders //
	public void toggleInputStyleForBoth_()
		=> toggleInputStyleForBoth();


	// methods for: changing the direction reference transform //
	
	// method: change the direction reference transform to the corresponding hand's transform for this treader //
	public void changeDirectionReferenceTransformToHand()
		=> directionReferenceTransform = handTransform;
	// method: change the direction reference transform to the corresponding hand's transform for the given treader //
	public static void changeDirectionReferenceTransformToHandForTreader(Treader treader)
		=> treader.changeDirectionReferenceTransformToHand();
	// method: change the direction reference transform to the corresponding hand's transform for the given treader //
	public void changeDirectionReferenceTransformToHandForTreader_(Treader treader)
		=> changeDirectionReferenceTransformToHandForTreader(treader);
	// method: change the direction reference transform to the corresponding hand's transform for the left treader //
	public static void changeDirectionReferenceTransformToHandForLeft()
		=> left.changeDirectionReferenceTransformToHand();
	// method: change the direction reference transform to the corresponding hand's transform for the left treader //
	public void changeDirectionReferenceTransformToHandForLeft_()
		=> changeDirectionReferenceTransformToHandForLeft();
	// method: change the direction reference transform to the corresponding hand's transform for the right treader //
	public static void changeDirectionReferenceTransformToHandForRight()
		=> right.changeDirectionReferenceTransformToHand();
	// method: change the direction reference transform to the corresponding hand's transform for the right treader //
	public void changeDirectionReferenceTransformToHandForRight_()
		=> changeDirectionReferenceTransformToHandForRight();
	// method: change the direction reference transform to the corresponding hand's transform for both treaders //
	public static void changeDirectionReferenceTransformToHandForBoth()
	{
		changeDirectionReferenceTransformToHandForLeft();
		changeDirectionReferenceTransformToHandForRight();
	}
	// method: change the direction reference transform to the corresponding hand's transform for both treaders //
	public void changeDirectionReferenceTransformToHandForBoth_()
		=> changeDirectionReferenceTransformToHandForBoth();
	// method: change the direction reference transform to the player head transform for this treader //
	public void changeDirectionReferenceTransformToHead()
		=> directionReferenceTransform = headTransform;
	// method: change the direction reference transform to the player head transform for the given treader //
	public static void changeDirectionReferenceTransformToHeadForTreader(Treader treader)
		=> treader.changeDirectionReferenceTransformToHead();
	// method: change the direction reference transform to the player head transform for the given treader //
	public void changeDirectionReferenceTransformToHeadForTreader_(Treader treader)
		=> changeDirectionReferenceTransformToHeadForTreader(treader);
	// method: change the direction reference transform to the player head transform for the left treader //
	public static void changeDirectionReferenceTransformToHeadForLeft()
		=> left.changeDirectionReferenceTransformToHead();
	// method: change the direction reference transform to the player head transform for the left treader //
	public void changeDirectionReferenceTransformToHeadForLeft_()
		=> changeDirectionReferenceTransformToHeadForLeft();
	// method: change the direction reference transform to the player head transform for the right treader //
	public static void changeDirectionReferenceTransformToHeadForRight()
		=> right.changeDirectionReferenceTransformToHead();
	// method: change the direction reference transform to the player head transform for the right treader //
	public void changeDirectionReferenceTransformToHeadForRight_()
		=> changeDirectionReferenceTransformToHeadForRight();
	// method: change the direction reference transform to the player head transform for both treaders //
	public static void changeDirectionReferenceTransformToHeadForBoth()
	{
		changeDirectionReferenceTransformToHeadForLeft();
		changeDirectionReferenceTransformToHeadForRight();
	}
	// method: change the direction reference transform to the player head transform for both treaders //
	public void changeDirectionReferenceTransformToHeadForBoth_()
		=> changeDirectionReferenceTransformToHeadForBoth();
	// method: toggle the direction reference transform between the corresponding hand transform and the player head transform for this treader //
	public void toggleDirectionReferenceTransform()
	{
		if (directionReferenceTransform != handTransform)
		{
			directionReferenceTransform = handTransform;
		}
		else
		{
			directionReferenceTransform = headTransform;
		}
	}
	// method: toggle the direction reference transform between the corresponding hand transform and the player head transform for the given treader //
	public static void toggleDirectionReferenceTransformForTreader(Treader treader)
		=> treader.toggleDirectionReferenceTransform();
	// method: toggle the direction reference transform between the corresponding hand transform and the player head transform for the given treader //
	public void toggleDirectionReferenceTransformForTreader_(Treader treader)
		=> toggleDirectionReferenceTransformForTreader(treader);
	// method: toggle the direction reference transform between the corresponding hand transform and the player head transform for the left treader //
	public static void toggleDirectionReferenceTransformForLeft()
		=> left.toggleDirectionReferenceTransform();
	// method: toggle the direction reference transform between the corresponding hand transform and the player head transform for the left treader //
	public void toggleDirectionReferenceTransformForLeft_()
		=> toggleDirectionReferenceTransformForLeft();
	// method: toggle the direction reference transform between the corresponding hand transform and the player head transform for the right treader //
	public static void toggleDirectionReferenceTransformForRight()
		=> right.toggleDirectionReferenceTransform();
	// method: toggle the direction reference transform between the corresponding hand transform and the player head transform for the right treader //
	public void toggleDirectionReferenceTransformForRight_()
		=> toggleDirectionReferenceTransformForRight();
	// method: toggle the direction reference transform between the corresponding hand transform and the player head transform for both treaders //
	public static void toggleDirectionReferenceTransformForBoth()
	{
		toggleDirectionReferenceTransformForLeft();
		toggleDirectionReferenceTransformForRight();
	}
	// method: toggle the direction reference transform between the corresponding hand transform and the player head transform for both treaders //
	public void toggleDirectionReferenceTransformForBoth_()
		=> toggleDirectionReferenceTransformForBoth();
	
	
	
	
	// events //

	
	// event: treading beginning //
	public delegate void treadingGaugeBeginningDelegate();
	public static event treadingGaugeBeginningDelegate treadingGaugeBeginningEvent;
	
	
	
	
	// updating //
	

	// before the start: //
	protected override void Awake()
	{
		base.Awake();

		// connect to the player rigidbody (to tread) //
		playerRigidbody = transform.parent.parent.parent.GetComponent<Rigidbody>();

		// connect to the corresponding hand transform //
		handTransform = transform.parent;
	}
	
	// upon being enabled: //
	private void OnEnable()
	{
		// connect the corresponding instance of this class //
		if (leftInstance)
		{
			left = this;
		}
		else
		{
			right = this;
		}
	}

	// at the start: //
	protected override void Start()
	{
		base.Start();

		// connect to the other instance of this class //
		other = (leftInstance ? right : left);

		// connect to the player head transform //
		headTransform = AirRushingAudio.singleton.transform.parent;
	}

	// at each update: //
	private void Update()
	{
		// if either: the locomotion dependencies are met, the stuck failsafe dependencies are met: //
		if (locomotionDependencies.areMet() || dependenciesStuckFailsafe.areMet())
		{
			// if: regular gauge treading is controlled via toggling (instead of holding), regular gauge input just began: invert the tracking of whether the regular treading toggle is on //
			if (!heldVersusToggled && locomotionInputEnabledAndAllowed() && controller.inputPressing(inputsLocomotion))
			{
				regularTreadingToggle = !regularTreadingToggle;
			}
			// if regular gauge treading is not controlled via toggling or locomotion input is not enabled: ensure that the regular gauge treading toggle is off //
			if (heldVersusToggled || !locomotionInputEnabledAndAllowed())
			{
				regularTreadingToggle = false;
			}

			// if this treader is experiencing significant input: //
			if (experiencingSignificantInput())
			{
				// if a gauge of treading is beginning: broadcast the treading gauge beginning event //
				if (controller.inputPressing(inputsLocomotion) || controller.inputTouching(inputsLocomotion))
				{
					// broadcast treading gauge beginning event //
					if (treadingGaugeBeginningEvent != null)
					{
						treadingGaugeBeginningEvent();
					}
				}

				// based on whether any touchpad input is being used: determine the max treading speed //
				float maxSpeed = 0f;		// initialize the max treading speed to 0
				if (controller.inputTouched(inputsLocomotion))		// if any touchpad input is being used: set the max treading speed to the corresponding max treading speed gauge:
				{
					maxSpeed = ((controller.touchpadPressed() || !slowerSpeedEnabled || regularTreadingToggle) ? speedMax : slowerSpeedMax);		// if the touchpad is being pressed or the slower guage speed is disabled or regular treading is currently toggled on: use the normal gauge; otherwise (if the touchpad is merely significantly being touched): use the slower gauge
				}
				else		// otherwise (if no touchpad input is being used): simply set the max treading speed to the normal max treading speed setting
				{
					maxSpeed = speedMax;
				}

				// initialize the treading velocity (which is just for x and z) as a proportionality (that is, without scaling it to the appropriate magnitude/speed yet) //
				Vector3 treadingVelocityProportionalityForwardPart = FloatsVector.zeroes;		// define the forward part to be the forward direction of this treader
				Vector3 treadingVelocityProportionalityRightwardPart = FloatsVector.zeroes;		// initialize the rightward part as a zeroes vector
				if (controller.inputTouched(inputsLocomotion))       // if any touchpad input is being used: proportion the velocity parts based on the touchpad input position's coordinates' signage
				{
					// proportion the forward part of the velocity based on the touchpad's y (used for z) input position //
					treadingVelocityProportionalityForwardPart = directionReferenceTransform.forward * controller.touchpadY();

					// proportion the rightward part of the velocity based on the touchpad's x input position //
					treadingVelocityProportionalityRightwardPart = directionReferenceTransform.right * controller.touchpadX();
				}
				else		// otherwise (if no touchpad input is being used): only proportion the treading velocity forward part – using the forward direction of this treader
				{
					treadingVelocityProportionalityForwardPart = directionReferenceTransform.forward;
				}
				Vector3 treadingVelocity = treadingVelocityProportionalityForwardPart + treadingVelocityProportionalityRightwardPart;		// initialize the treading velocity as the sum of both the forward and rightward parts

				// trim out the y axis of the treading velocity //
				treadingVelocity = treadingVelocity.withYZero();

				// calculate the treading speed //
				float speed = 0f;		// initialize the treading speed to 0
				if (controller.inputTouched(inputsLocomotion))       // if any touchpad input is being used:
				{
					// set the speed to be the max treading speed, curved by the distance of the input position on the touchpad away from the center, using the curve setting //
					speed = touchpadSpeedDistanceCurve.clamped(0f, maxSpeed, controller.touchpadDistance());
				}
				else		// otherwise (if no touchpad input is being used): simply set the treading speed to the max treading speed
				{
					speed = speedMax;
				}

				// scale the treading velocity to the calculated treading speed //
				treadingVelocity = treadingVelocity.normalized * speed;
				
				// determine the player's velocity //
				Vector3 playerVelocity = PlayerVelocityReader.velocity();
				
				// if the player's speed in the direction of the treading velocity is not yet at or past the treading velocity's speed: //
				if (Vector3.Dot(playerVelocity, treadingVelocity.normalized) < speed)
				{
					// determine the appropriate responsiveness factor //
					float appropriateResponsivnessFactor = responsivenessFactorSkiing;
					if (!Skier.skiing)
					{
						bool driftingWithinOneSecondAgo = dependencyDriftingWithinOneSecondAgo.isMet();
						if (!driftingWithinOneSecondAgo)
						{
							appropriateResponsivnessFactor = responsivenessFactorNonskiingNondrifting;
						}
						else
						{
							float timeAgoDriftingBoosting = (Time.time - BoostingDriftingTracker.timePlayerWasLastBoostingDrifting);
							float timeAgoDriftingLaunching = (Time.time - LaunchingDriftingTracker.timePlayerWasLastLaunchingDrifting);
							float timeAgoDrifting = Mathf.Min(timeAgoDriftingBoosting, timeAgoDriftingLaunching);

							appropriateResponsivnessFactor = responsivenessFactorNonskiingDriftingCurve.clamped(responsivenessFactorNonskiingDriftingMin, responsivenessFactorNonskiingDriftingMax, (timeAgoDrifting / 1f));
						}
					}

					// hone the player's velocity x and z axes to the treading velocity x and z axes by the determined treading velocity x and z axes' magnitudes in proportion to the current frame's duration times the appropriate responsivness factor //
					Vector3 honingVector = ((new Vector3(Mathf.Abs(treadingVelocity.x), 0f, Mathf.Abs(treadingVelocity.z))) * (Time.deltaTime) * appropriateResponsivnessFactor);
					playerRigidbody.velocity = playerVelocity.honed(treadingVelocity, honingVector);
				}
			}
			// otherwise (if this treader is not currently experiencing significant input): if the player is not currently skiing: //
			else if (!Skier.skiing)
			{
				// determine whether significant input is currently ceasing //
				bool significantInputCeasing = (locomotionInputEnabledAndAllowed() && (controller.inputUnpressing(inputsLocomotion) || controller.inputUntouching(inputsLocomotion)));

				// determine whether the other treader is currently experiencing significant input //
				bool otherTreaderIsCurrentlyExperiencingSignificantInput = (otherTreaderActive() && other.experiencingSignificantInput());

				// if: this treader is currently ceasing to experience significant input, the other treader is not currently experiencing significant input //
				if (significantInputCeasing && !otherTreaderIsCurrentlyExperiencingSignificantInput)
				{
					// stop the player's x and z movement (zero the player velocity's x and z axes) //
					playerRigidbody.velocity = new Vector3(0f, PlayerVelocityReader.velocityY(), 0f);
				}
			}
		}
	}
}