using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Face Player Camera: updates this object to always face the player camera //
public class FacePlayerCamera : MonoBehaviour
{
	// variables //

	
	// connection - automatic: the transform of the player's camera //
    protected Transform playerCameraTransform;




	// updating //

	
	// at the start: connect to the transform of the player's camera //
    protected virtual void Start()
    {
        playerCameraTransform = Player.instance.hmdTransform;
    }
	
	// at each update: //
    protected virtual void Update()
    {
		// update this object's rotation to face the player's camera //
        Vector3 vectorFromCamera = playerCameraTransform.position - transform.position;
		vectorFromCamera.x = vectorFromCamera.z = 0f;
		transform.LookAt(playerCameraTransform.position - vectorFromCamera); 
		transform.Rotate(0f, 180f, 0f);
    }
}