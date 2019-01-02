using UnityEngine;
using System.Collections;

// Average Position: at each update, sets this transform's position to be the determined average position of the connected transforms //
public class AveragePosition : MonoBehaviour
{
	// variables //

	
	// connections: transforms to average positions of //
	public Transform[] transforms;




	// updating //

	
	// at each update: //
	protected virtual void Update()
	{
		// determine the average position of the connected transforms //
		Vector3 averagePosition = Vector3.zero;
		foreach (Transform transformToAverage in transforms)
		{
			averagePosition += transformToAverage.position;
		}
		averagePosition /= transforms.Length;

		// set this transform's position to be the determined average position of the connected transforms //
		transform.position = averagePosition;
	}
}
