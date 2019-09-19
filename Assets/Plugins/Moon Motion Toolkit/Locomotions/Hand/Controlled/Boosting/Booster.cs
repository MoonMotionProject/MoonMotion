using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Booster
// • classifies this hand locomotion as the "boosting" locomotion
// • behaves the parent hand as a "booster" (a locomotive tool which expels fuel to create force in the opposite direction, allowing the player to propel themself around)
//   · handles main functionality for this booster
//   · modular functionality is handled by the children module objects of this booster
//     - in the case that a module is missing, that module's class will provide fallback functionality
// • provides methods for determining whether either hand is boosting and in what manner
public class Booster : HandLocomotionControlled
{
	// variables //
	
	
	// variables for: instancing //
	public static Booster left, right;		// connections - auto: left and right Booster instances, respectively
	
	// variables for: handling the player's physics //
	[HideInInspector] public Rigidbody playerRigidbody;		// connection - auto: the player rigidbody (to be boosted)
	private Transform playerTransform;		// connection - auto: the player transform
	
	// tracking for: whether the booster is boosting, whether the booster is boosting deeply //
	[HideInInspector] public bool boosting = false, boostingDeeply = false;




	// methods //

	
	// method: determine whether this hand is boosting //
	public bool thisHandIsBoosting()
	{
		return boosting;
	}
	// method: determine whether the left hand is boosting //
	public static bool leftHandIsBoosting()
	{
		return left.thisHandIsBoosting();
	}
	// method: determine whether the right hand is boosting //
	public static bool rightHandIsBoosting()
	{
		return right.thisHandIsBoosting();
	}
	// method: determine whether either hand is boosting //
	public static bool eitherHandIsBoosting()
	{
		return (leftHandIsBoosting() || rightHandIsBoosting());
	}
	// method: determine whether both hands are boosting //
	public static bool bothHandsAreBoosting()
	{
		return (leftHandIsBoosting() && rightHandIsBoosting());
	}
	// method: determine whether this hand is boosting deeply //
	public bool thisHandIsBoostingDeeply()
	{
		return boostingDeeply;
	}
	// method: determine whether the left hand is boosting deeply //
	public static bool leftHandIsBoostingDeeply()
	{
		return left.thisHandIsBoostingDeeply();
	}
	// method: determine whether the right hand is boosting deeply //
	public static bool rightHandIsBoostingDeeply()
	{
		return right.thisHandIsBoostingDeeply();
	}
	// method: determine whether either hand is boosting deeply //
	public static bool eitherHandIsBoostingDeeply()
	{
		return (leftHandIsBoostingDeeply() || rightHandIsBoostingDeeply());
	}
	// method: determine whether both hands are boosting deeply //
	public static bool bothHandsAreBoostingDeeply()
	{
		return (leftHandIsBoostingDeeply() && rightHandIsBoostingDeeply());
	}
	// method: determine whether this hand is boosting shallowly //
	public bool thisHandIsBoostingShallowly()
	{
		return (thisHandIsBoosting() && !thisHandIsBoostingDeeply());
	}
	// method: determine whether the left hand is boosting shallowly //
	public static bool leftHandIsBoostingShallowly()
	{
		return left.thisHandIsBoostingShallowly();
	}
	// method: determine whether the right hand is boosting shallowly //
	public static bool rightHandIsBoostingShallowly()
	{
		return right.thisHandIsBoostingShallowly();
	}
	// method: determine whether either hand is boosting shallowly //
	public static bool eitherHandIsBoostingShallowly()
	{
		return (leftHandIsBoostingShallowly() || rightHandIsBoostingShallowly());
	}
	// method: determine whether both hands are boosting shallowly //
	public static bool bothHandsAreBoostingShallowly()
	{
		return (leftHandIsBoostingShallowly() && rightHandIsBoostingShallowly());
	}
	
	
	
	
	// updating //

	
	// before the start: connection of auto connections //
	protected override void Awake()
	{
		base.Awake();

		playerRigidbody = transform.parent.parent.parent.GetComponent<Rigidbody>();
		playerTransform = playerRigidbody.transform;
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


	// at each physics update: //
	private void FixedUpdate()
	{
		// fuel production
		// (updated alongside physics so that it stays in sync with the fuel usage drawn by boosting forces (such that if, for example, fuel force is produced at a rate of 100, and the force being applied is 100, the current fuel force amount will not change))
		BoosterFuelSupply.addFuelForce(this, BoosterRefueler.productionAmount(this));

		// determining whether this booster's automator is currently automating //
		bool automating = BoosterAutomator.automating(this);
		
		// boosting inputting, modules handling, and corresponding updating //
		if (!BoosterHalter.halted(this) && ((BoosterToggler.enabledBoosting(this) && locomotionInputEnabledAndAllowed() && controller.inputPressed(inputsLocomotion)) || automating))	  // if this booster's halter isn't currently halting boosting, and either boosting is enabled while the input is pressed at all or this booster's automator is automating
		{
			// initializing boosting values //
			float forceShallow = BoosterForceApplier.amountShallow(this);
			float forceDeep = BoosterForceApplier.amountDeep(this);
			float forceAmount = (forceShallow + forceDeep) / 2f;
			ushort vibrationIntensity = BoosterVibrator.intensityShallow(this);
			
			// determining the currently accessible fuel amount //
			float accessibleFuelAmount = BoosterFuelSupply.accessibleFuelForce(this);

			// determine whether the deep force fuel threshold is met by either being "swung open" (like a floodgate) by already deep boosting, or by being at or above the deep force fuel threshold (per Booster Force Applier) //
			bool deepForceFuelThresholdMet = (boostingDeeply || (accessibleFuelAmount >= BoosterForceApplier.fuelThresholdForBooster(this)));

			// determining whether the booster automator is using fuel //
			bool automatorUsingFuel = BoosterAutomator.usingFuel(this);

			// determining whether there is enough fuel for shallow force boosting andor deep force boosting //
			bool enoughFuelForShallowForce = ((accessibleFuelAmount >= forceShallow) || (automating && !automatorUsingFuel));
			bool enoughFuelForDeepForce = ((accessibleFuelAmount >= forceDeep) && deepForceFuelThresholdMet);

			// determining boosting values - shallow //
			if ((!controller.inputDeeped(inputsLocomotion) && enoughFuelForShallowForce) || (controller.inputDeeped(inputsLocomotion) && !enoughFuelForDeepForce && enoughFuelForShallowForce))		// whether either is true: the input is not deeped and there is enough fuel for shallow force, the input is deeped but there is not enough fuel for deep force yet there is enough fuel for shallow force
			{
				boosting = true;
				boostingDeeply = false;

				forceAmount = forceShallow;
				vibrationIntensity = BoosterVibrator.intensityShallow(this);
			}
			// determining boosting values - deep //
			else if (enoughFuelForDeepForce)		// otherwise (if the input is deeped), if there is enough fuel for deep force
			{
				boosting = true;
				boostingDeeply = true;

				forceAmount = forceDeep;
				vibrationIntensity = BoosterVibrator.intensityDeep(this);
			}
			// determining to not be boosting due to lack of fuel, and having the fuel sputtering play accordingly (if actually inputting) //
			else
			{
				boosting = false;
				boostingDeeply = false;

				if (controller.inputPressing(inputsLocomotion))		// only if this booster is receiving input, since the Booster Automator is smart enough to not try to boost when there is no fuel so it doesn't sputter
				{
					BoosterFuelSputterer.sputter(this);
				}
			}

			// boosting (if at least shallow force is boosting) //
			if (boosting)
			{
				// determine the player's current velocity //
				Vector3 currentPlayerVelocity = PlayerVelocityReader.velocity();
				// determining the rotation vector for the force direction relative to this booster //
				Vector3 forceDirectionRelative = BoosterForceApplier.direction(this).asDirectionRelativeTo(BoosterRelativizer.relativityTransform(this));
				// determining the speed of the player's rigidbody in the direction of the booster's force aiming //
				float bodySpeedInBoosterDirection = Vector3.Dot(currentPlayerVelocity, forceDirectionRelative);
				// fuel usage via Booster Defueler //
				if (!(automating && !automatorUsingFuel))		// only if not automatically boosting without using fuel
				{
					BoosterDefueler.defuel(this, forceAmount);
				}
				// application of boosting force //
				if (!BoosterSpeedLimiter.speedLimited(this) || (bodySpeedInBoosterDirection < BoosterSpeedLimiter.boosterSpeedLimit(this)))	  // if limiting the speed is currently unecessary
				{
					// boosting force to apply (in the specified direction (originally/ by default, opposite the expelling of the booster)) //
					Vector3 forceToApply = forceDirectionRelative * forceAmount * Time.fixedDeltaTime;
					forceToApply *= BoosterForceMultiplier.forceFactor(this);		// adjust the force to apply by the force factor provided by the corresponding Booster Force Multiplier
					if (BoosterPulser.pulsingForcePercentage(this) != 0f)     // add the pulsing force (based on the corresponding Booster Pulser) to the force to apply
					{
						if (BoosterPulser.pulsingPlayerUpDirectionOnly(this))
						{
							Vector3 playerUpDirection = BasicDirection.up.asDirectionRelativeTo(playerTransform);
							float forceToApplyForPlayerUpOnly = Vector3.Dot(forceToApply, playerUpDirection);
							forceToApply += (playerUpDirection * forceToApplyForPlayerUpOnly * BoosterPulser.pulsingForcePercentage(this) * Mathf.Sin(Time.time / BoosterPulser.pulsingForceFrequency(this)));
						}
						else
						{
							forceToApply += (forceToApply * BoosterPulser.pulsingForcePercentage(this) * Mathf.Sin(Time.time / BoosterPulser.pulsingForceFrequency(this)));
						}
					}
					if (BoosterAntidiminisher.antidiminishingBooster(this))		// if this booster's Booster Antidiminisher is currently antidiminishing this booster
					{
						forceToApply = Vector3.Scale(-forceToApply, BoosterAntidiminisher.antidiminishingFactors(this));		// reverse the force to apply and antidiminish it based on this booster's Booster Antidiminisher
					}
					else if (BoosterDiminisher.diminished(this))		// if this booster's Booster Diminisher is currently diminishing this booster
					{
						if ((bodySpeedInBoosterDirection + Vector3.Dot(forceToApply, forceDirectionRelative)) > 0f)		// if the speed the player's rigidbody will have in the booster direction after force application is greater than 0
						{
							forceToApply = Vector3.Scale(forceToApply, BoosterDiminisher.diminishingFactors(this));		// diminish the force to apply based on this booster's Booster Diminisher
						}
					}
					// inertia dampening //
					if (BoosterInertiaDampener.inertiaDampened(this) && (bodySpeedInBoosterDirection < forceToApply.magnitude))
					{
						Vector3 inertiaDampeningForceToApply = (forceDirectionRelative * Vector3.Dot(currentPlayerVelocity, -forceDirectionRelative) * BoosterInertiaDampener.dampeningFactor(this));
						playerRigidbody.AddForce(inertiaDampeningForceToApply);
					}
					// application of boosting force //
					BoosterForceApplier.applyForce(this, forceToApply);
				}
				// fall dampening //
				if (BoosterFallDampener.fallDampened(this) && (currentPlayerVelocity.y < 0) && ((forceDirectionRelative - playerTransform.up).y > -.25f))	  // if fall dampening is enabled and the rigidbody is going down and this controller is boosting against that direction by at least about 45°
				{
					Vector3 fallDampeningForceToApply = (playerTransform.up * BoosterFallDampener.dampeningForce(this) * Time.fixedDeltaTime);
					playerRigidbody.AddForce(fallDampeningForceToApply);
				}
				// vibrating of controller //
				controller.vibrate(vibrationIntensity);
			}
		}


		else		// otherwise (if no input nor module is having boosting happen currently): determining to not be boosting
		{
			boosting = false;
			boostingDeeply = false;
		}
	}
}