using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Body Transformation
// • keeps this body positioned under the headset (by matching x and z position to it) but above the floor (by adjusting y position from it)
// • prevents local rotation of this body
// • corrects (inverts) the body's y positioning according to the flipping locomotion (for the player being rotated 180° around the z axis, according to whether the flipping locomotion (via Flipper) has the player flipped currently)
[RequireComponent(typeof(TrackLocalRotationAtAwake))]
[RequireComponent(typeof(TrackCapsuleCollidersAtAwake))]
public class BodyTransformation : AutoBehaviour<BodyTransformation>
{
	// variables //
	
	
	// connections - manual: headset, floor //

    [BoxGroup("Transform Connections")]
    public Transform headsetTransform;

	[BoxGroup("Transform Connections")]
	public Transform floorTransform;
	

	// settings //

    [BoxGroup("Height of Head Above Eyes")]
	[Tooltip("adds additional height to this body collider to avoid the player colliding with ceilings and the like directly at their eye level")]
	public float headAboveEyesHeight = .06f;
	
	
	
	
	// updating //

	
	// at the end of each update: //
	private void LateUpdate()
    {
		// local rotation locking //
        setLocalRotationTo(localRotationAwake);
       
		// following x and z position of headset and setting y position to have the collider be just above the floor... but since the collider is a capsule it will be limited in height to a sphere formed from its two halfspheres once the nonspherical part of its height is entirely diminished (as a result of the entire height setting diminishing) //
		float distanceFromFloor = Vector3.Dot(headsetTransform.localPosition, Direction.up) + headAboveEyesHeight;		// determine the distance from the headset to the floor – but offset it by the head above eyes height to fudge for how the part of one's head above their eyes should collide with a ceiling or similar object before their eyes do
		// set any capsule colliders' heights to be whichever is greater: the distance from the headset to the floor, twice the length of the capsule collider's radius (since ∗) //
		foreach (CapsuleCollider capsuleCollider in capsuleCollidersAwake)
		{
			capsuleCollider.height = Mathf.Max(distanceFromFloor, (capsuleCollider.radius * 2));
		}
        transform.position = new Vector3(headsetTransform.position.x, floorTransform.position.y + (capsuleCollidersAwake[0].height.halved()), headsetTransform.position.z);		// the x and z position follow the headset; the y position is set to be half of the first (although all are likely the same height – by default, there is just one nontrigger one followed by one trigger one of the same height) capsule collider's height up from the floor position

		// if this body's y position should be inverted currently since the flipping locomotion has the player flipped via 180° rotation around the z axis: //
		if (Flipper.flipped)
		{
			negateLocalPositionY();
		}
    }
}
// ∗: a capsule collider is composed of two halfspheres serving as top and bottom to a cylinder, attached to that cylinder; a capsule collider has both a radius and a height setting... the height setting determines the height of the whole collider, whereas the radius setting determines the radius (which is thus also the width and height) for both of the halfspheres (they share the same value)... the height can be set to less than the value of both radii added together, although this will be ignored and twice the radius length will be used intead because the radii have priority //