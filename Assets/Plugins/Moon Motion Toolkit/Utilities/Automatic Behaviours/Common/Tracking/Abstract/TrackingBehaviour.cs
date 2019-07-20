using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class	TrackingBehaviour<TrackingBehaviourT> :
					CommonBehaviour<TrackingBehaviourT>
						where TrackingBehaviourT : TrackingBehaviour<TrackingBehaviourT>
{
	
}