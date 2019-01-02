using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// Hierarchy: provides methods for getting information about, getting connections through, and manipulating the transform hierarchy //
public class Hierarchy : MonoBehaviour
{
	public static void destroyAllChildrenObjectsOf(Transform parentTransform)
	{
		for (int i = parentTransform.childCount - 1; i >= 0; i--)
        {
            Destroy(parentTransform.GetChild(i).gameObject);
        }
	}
















	private static Transform anyLevelParentWithTagOrLayerOrName(Transform startingLevelTransform, string tagOrLayerOrName, bool tagOrLayerVersusName, bool tagVersusLayer)
	{
		Transform transformAtCurrentLevel = startingLevelTransform;
		while (transformAtCurrentLevel.parent)
		{
			Transform parentTransform = transformAtCurrentLevel.parent;
			bool particularParentFound = tagOrLayerVersusName ? (tagVersusLayer ? parentTransform.gameObject.CompareTag(tagOrLayerOrName) : LayerMask.LayerToName(parentTransform.gameObject.layer).Equals(tagOrLayerOrName)) : parentTransform.name.Equals(tagOrLayerOrName);
			if (particularParentFound)
			{
				return parentTransform;
			}
			transformAtCurrentLevel = parentTransform;
		}
		return null;
	}

	private static Transform anyLevelParentWithTagOrLayerOrNameContaining(Transform startingLevelTransform, string text, bool tagOrLayerVersusName, bool tagVersusLayer)
	{
		Transform transformAtCurrentLevel = startingLevelTransform;
		while (transformAtCurrentLevel.parent)
		{
			Transform parentTransform = transformAtCurrentLevel.parent;
			bool particularParentFound = tagOrLayerVersusName ? (tagVersusLayer ? parentTransform.gameObject.tag.Contains(text) : LayerMask.LayerToName(parentTransform.gameObject.layer).Contains(text)) : parentTransform.name.Contains(text);
			if (particularParentFound)
			{
				return parentTransform;
			}
			transformAtCurrentLevel = parentTransform;
		}
		return null;
	}




	public static Transform selfOrAnyLevelParentWithTag(Transform startingLevelTransform, string tag)
	{
		return (startingLevelTransform.gameObject.CompareTag(tag) ? startingLevelTransform : anyLevelParentWithTagOrLayerOrName(startingLevelTransform, tag, true, true));
	}
	public static Transform selfOrAnyLevelParentWithTag(GameObject startingLevelObject, string tag)
	{
		return (startingLevelObject.CompareTag(tag) ? startingLevelObject.transform : anyLevelParentWithTagOrLayerOrName(startingLevelObject.transform, tag, true, true));
	}
	public static Transform selfOrAnyLevelParentWithTag(Collider startingLevelCollider, string tag)
	{
		return (startingLevelCollider.gameObject.CompareTag(tag) ? startingLevelCollider.transform : anyLevelParentWithTagOrLayerOrName(startingLevelCollider.transform, tag, true, true));
	}
	public static Transform selfOrAnyLevelParentWithTag(Collision startingLevelCollision, string tag)
	{
		return (startingLevelCollision.gameObject.CompareTag(tag) ? startingLevelCollision.transform : anyLevelParentWithTagOrLayerOrName(startingLevelCollision.transform, tag, true, true));
	}
	public static Transform selfOrAnyLevelParentWithTag(Rigidbody startingLevelRigidbody, string tag)
	{
		return (startingLevelRigidbody.gameObject.CompareTag(tag) ? startingLevelRigidbody.transform : anyLevelParentWithTagOrLayerOrName(startingLevelRigidbody.transform, tag, true, true));
	}

	public static Transform selfOrAnyLevelParentWithTagContaining(Transform startingLevelTransform, string tag)
	{
		return (startingLevelTransform.gameObject.tag.Contains(tag) ? startingLevelTransform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelTransform, tag, true, true));
	}
	public static Transform selfOrAnyLevelParentWithTagContaining(GameObject startingLevelObject, string tag)
	{
		return (startingLevelObject.tag.Contains(tag) ? startingLevelObject.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelObject.transform, tag, true, true));
	}
	public static Transform selfOrAnyLevelParentWithTagContaining(Collider startingLevelCollider, string tag)
	{
		return (startingLevelCollider.gameObject.tag.Contains(tag) ? startingLevelCollider.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelCollider.transform, tag, true, true));
	}
	public static Transform selfOrAnyLevelParentWithTagContaining(Collision startingLevelCollision, string tag)
	{
		return (startingLevelCollision.gameObject.tag.Contains(tag) ? startingLevelCollision.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelCollision.transform, tag, true, true));
	}
	public static Transform selfOrAnyLevelParentWithTagContaining(Rigidbody startingLevelRigidbody, string tag)
	{
		return (startingLevelRigidbody.gameObject.tag.Contains(tag) ? startingLevelRigidbody.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelRigidbody.transform, tag, true, true));
	}


	public static Transform selfOrAnyLevelParentWithLayer(Transform startingLevelTransform, string layer)
	{
		return (LayerMask.LayerToName(startingLevelTransform.gameObject.layer).Equals(layer) ? startingLevelTransform : anyLevelParentWithTagOrLayerOrName(startingLevelTransform, layer, true, false));
	}
	public static Transform selfOrAnyLevelParentWithLayer(GameObject startingLevelObject, string layer)
	{
		return (LayerMask.LayerToName(startingLevelObject.layer).Equals(layer) ? startingLevelObject.transform : anyLevelParentWithTagOrLayerOrName(startingLevelObject.transform, layer, true, false));
	}
	public static Transform selfOrAnyLevelParentWithLayer(Collider startingLevelCollider, string layer)
	{
		return (LayerMask.LayerToName(startingLevelCollider.gameObject.layer).Equals(layer) ? startingLevelCollider.transform : anyLevelParentWithTagOrLayerOrName(startingLevelCollider.transform, layer, true, false));
	}
	public static Transform selfOrAnyLevelParentWithLayer(Collision startingLevelCollision, string layer)
	{
		return (LayerMask.LayerToName(startingLevelCollision.gameObject.layer).Equals(layer) ? startingLevelCollision.transform : anyLevelParentWithTagOrLayerOrName(startingLevelCollision.transform, layer, true, false));
	}
	public static Transform selfOrAnyLevelParentWithLayer(Rigidbody startingLevelRigidbody, string layer)
	{
		return (LayerMask.LayerToName(startingLevelRigidbody.gameObject.layer).Equals(layer) ? startingLevelRigidbody.transform : anyLevelParentWithTagOrLayerOrName(startingLevelRigidbody.transform, layer, true, false));
	}

	public static Transform selfOrAnyLevelParentWithLayerContaining(Transform startingLevelTransform, string layer)
	{
		return (LayerMask.LayerToName(startingLevelTransform.gameObject.layer).Contains(layer) ? startingLevelTransform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelTransform, layer, true, false));
	}
	public static Transform selfOrAnyLevelParentWithLayerContaining(GameObject startingLevelObject, string layer)
	{
		return (LayerMask.LayerToName(startingLevelObject.layer).Contains(layer) ? startingLevelObject.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelObject.transform, layer, true, false));
	}
	public static Transform selfOrAnyLevelParentWithLayerContaining(Collider startingLevelCollider, string layer)
	{
		return (LayerMask.LayerToName(startingLevelCollider.gameObject.layer).Contains(layer) ? startingLevelCollider.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelCollider.transform, layer, true, false));
	}
	public static Transform selfOrAnyLevelParentWithLayerContaining(Collision startingLevelCollision, string layer)
	{
		return (LayerMask.LayerToName(startingLevelCollision.gameObject.layer).Contains(layer) ? startingLevelCollision.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelCollision.transform, layer, true, false));
	}
	public static Transform selfOrAnyLevelParentWithLayerContaining(Rigidbody startingLevelRigidbody, string layer)
	{
		return (LayerMask.LayerToName(startingLevelRigidbody.gameObject.layer).Contains(layer) ? startingLevelRigidbody.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelRigidbody.transform, layer, true, false));
	}


	public static Transform selfOrAnyLevelParentWithName(Transform startingLevelTransform, string name)
	{
		return (startingLevelTransform.name.Equals(name) ? startingLevelTransform : anyLevelParentWithTagOrLayerOrName(startingLevelTransform, name, false, false));
	}
	public static Transform selfOrAnyLevelParentWithName(GameObject startingLevelObject, string name)
	{
		return (startingLevelObject.name.Equals(name) ? startingLevelObject.transform : anyLevelParentWithTagOrLayerOrName(startingLevelObject.transform, name, false, false));
	}
	public static Transform selfOrAnyLevelParentWithName(Collider startingLevelCollider, string name)
	{
		return (startingLevelCollider.gameObject.name.Equals(name) ? startingLevelCollider.transform : anyLevelParentWithTagOrLayerOrName(startingLevelCollider.transform, name, false, false));
	}
	public static Transform selfOrAnyLevelParentWithName(Collision startingLevelCollision, string name)
	{
		return (startingLevelCollision.gameObject.name.Equals(name) ? startingLevelCollision.transform : anyLevelParentWithTagOrLayerOrName(startingLevelCollision.transform, name, false, false));
	}
	public static Transform selfOrAnyLevelParentWithName(Rigidbody startingLevelRigidbody, string name)
	{
		return (startingLevelRigidbody.gameObject.name.Equals(name) ? startingLevelRigidbody.transform : anyLevelParentWithTagOrLayerOrName(startingLevelRigidbody.transform, name, false, false));
	}

	public static Transform selfOrAnyLevelParentWithNameContaining(Transform startingLevelTransform, string text)
	{
		return (startingLevelTransform.name.Contains(text) ? startingLevelTransform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelTransform, text, false, false));
	}
	public static Transform selfOrAnyLevelParentWithNameContaining(GameObject startingLevelObject, string text)
	{
		return (startingLevelObject.name.Contains(text) ? startingLevelObject.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelObject.transform, text, false, false));
	}
	public static Transform selfOrAnyLevelParentWithNameContaining(Collider startingLevelCollider, string text)
	{
		return (startingLevelCollider.gameObject.name.Contains(text) ? startingLevelCollider.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelCollider.transform, text, false, false));
	}
	public static Transform selfOrAnyLevelParentWithNameContaining(Collision startingLevelCollision, string text)
	{
		return (startingLevelCollision.gameObject.name.Contains(text) ? startingLevelCollision.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelCollision.transform, text, false, false));
	}
	public static Transform selfOrAnyLevelParentWithNameContaining(Rigidbody startingLevelRigidbody, string text)
	{
		return (startingLevelRigidbody.gameObject.name.Contains(text) ? startingLevelRigidbody.transform : anyLevelParentWithTagOrLayerOrNameContaining(startingLevelRigidbody.transform, text, false, false));
	}








	public static Transform anyLevelParentWithRigidbody(Transform startingLevelTransform)
	{
		Transform transformAtCurrentLevel = startingLevelTransform;
		while (transformAtCurrentLevel.parent)
		{
			Transform parentTransform = transformAtCurrentLevel.parent;
			if (parentTransform.GetComponent<Rigidbody>())
			{
				return parentTransform;
			}
			transformAtCurrentLevel = parentTransform;
		}
		return null;
	}
	
	public static Transform selfOrAnyLevelParentWithRigidbody(Transform startingLevelTransform)
	{
		return (startingLevelTransform.GetComponent<Rigidbody>() ? startingLevelTransform : anyLevelParentWithRigidbody(startingLevelTransform));
	}

	public static Transform selfOrAnyLevelParentWithRigidbody(GameObject startingLevelObject)
	{
		return selfOrAnyLevelParentWithRigidbody(startingLevelObject.transform);
	}
	public static Transform selfOrAnyLevelParentWithRigidbody(Collider startingLevelCollider)
	{
		return selfOrAnyLevelParentWithRigidbody(startingLevelCollider.transform);
	}
	public static Transform selfOrAnyLevelParentWithRigidbody(Collision startingLevelCollision)
	{
		return selfOrAnyLevelParentWithRigidbody(startingLevelCollision.transform);
	}




	public static Transform anyLevelParentWithPlayer(Transform startingLevelTransform)
	{
		Transform transformAtCurrentLevel = startingLevelTransform;
		while (transformAtCurrentLevel.parent)
		{
			Transform parentTransform = transformAtCurrentLevel.parent;
			if (parentTransform.GetComponent<Player>())
			{
				return parentTransform;
			}
			transformAtCurrentLevel = parentTransform;
		}
		return null;
	}
	
	public static Transform selfOrAnyLevelParentWithPlayer(Transform startingLevelTransform)
	{
		return (startingLevelTransform.GetComponent<Player>() ? startingLevelTransform : anyLevelParentWithPlayer(startingLevelTransform));
	}

	public static Transform selfOrAnyLevelParentWithPlayer(GameObject startingLevelObject)
	{
		return selfOrAnyLevelParentWithPlayer(startingLevelObject.transform);
	}
	public static Transform selfOrAnyLevelParentWithPlayer(Collider startingLevelCollider)
	{
		return selfOrAnyLevelParentWithPlayer(startingLevelCollider.transform);
	}
	public static Transform selfOrAnyLevelParentWithPlayer(Collision startingLevelCollision)
	{
		return selfOrAnyLevelParentWithPlayer(startingLevelCollision.transform);
	}
	public static Transform selfOrAnyLevelParentWithPlayer(Rigidbody startingLevelRigidbody)
	{
		return selfOrAnyLevelParentWithPlayer(startingLevelRigidbody.transform);
	}








	public static Transform handHolding(Transform potentiallyHeldTransform)
	{
		Transform transformAtCurrentLevel = potentiallyHeldTransform;
		while (transformAtCurrentLevel.parent)
		{
			Transform parentTransform = transformAtCurrentLevel.parent;
			if (parentTransform.GetComponent<Hand>())
			{
				return parentTransform;
			}
			transformAtCurrentLevel = parentTransform;
		}
		return null;
	}
	public static Transform handHolding(GameObject potentiallyHeldObject)
	{
		return handHolding(potentiallyHeldObject.transform);
	}
	public static Transform handHolding(Collider colliderOfPotentiallyHeldObject)
	{
		return handHolding(colliderOfPotentiallyHeldObject.transform);
	}
	public static Transform handHolding(Collision collisionOfPotentiallyHeldObject)
	{
		return handHolding(collisionOfPotentiallyHeldObject.transform);
	}
	public static Transform handHolding(Rigidbody rigidbodyOfPotentiallyHeldObject)
	{
		return handHolding(rigidbodyOfPotentiallyHeldObject.transform);
	}
}