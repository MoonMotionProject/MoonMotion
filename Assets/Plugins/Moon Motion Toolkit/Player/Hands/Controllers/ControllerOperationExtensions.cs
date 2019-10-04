using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller Operation Extensions: provides extension methods for handling controller operations //
public static class ControllerOperationExtensions
{
	// method: return whether these operations are currently operated //
	public static bool operated(this ControllerOperation[] controllerOperations)
		=> Controller.operated(controllerOperations);

	// method: return the set of controllers for which any of the given operations are currently operated //
	public static HashSet<Controller> operatedControllers(this ControllerOperation[] controllerOperations)
		=> Controller.operatedControllers(controllerOperations);

	// method: return the first controller operation of these given controller operations which is currently operated //
	public static ControllerOperation firstOperatedOperation(this IEnumerable<ControllerOperation> controllerOperations)
		=>	controllerOperations.firstWhere(controllerOperation =>
				controllerOperation.operated());

	// method: return the fallback controller of the first operated operation of these given operations //
	public static Controller fallbackControllerOfFirstOperatedOperation(this IEnumerable<ControllerOperation> controllerOperations)
		=> controllerOperations.firstOperatedOperation().fallbackController;

	// method: return the first controller for which any of the given operations are currently operated, otherwise returning the left controller //
	public static Controller firstOperatedControllerOtherwiseFallback(this ControllerOperation[] controllerOperations)
		=> controllerOperations.operatedControllers().firstOtherwise(controllerOperations.fallbackControllerOfFirstOperatedOperation());
}