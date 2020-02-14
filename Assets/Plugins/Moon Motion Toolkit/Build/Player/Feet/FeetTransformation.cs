using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Feet Transformation
// • keeps the feet positioned under the headset to more precisely approximate the player's real feet
// • prevents local rotation of the feet
public class FeetTransformation : MonoBehaviour
{
	// connections to the transforms for the headset and the floor //
	
	public Transform headsetTransform;
	
	public Transform floorTransform;


    // local rotation locking //
    private Quaternion originalLocalRotation;
    private void Awake()
    {
        originalLocalRotation = transform.localRotation;
    }
    private void LateUpdate()
    {
        transform.localRotation = originalLocalRotation;
       
	// following x and z position of headset //
        transform.position = headsetTransform.position.withY(transform.position.y);
    }
}