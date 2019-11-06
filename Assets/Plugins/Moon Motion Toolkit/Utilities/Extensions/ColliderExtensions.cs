using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collider Extensions: provides extension methods for handling colliders //
public static class ColliderExtensions
{
	#region solidity determination

	// method: return whether this given collider is solid //
	public static bool isSolid(this Collider collider)
		=> !collider.isTrigger;
	#endregion solidity determination


	#region handling solidity

	// method: return this given collider if it is solid, otherwise returning null //
	public static Collider ifSolidOtherwiseNull(this Collider collider)
		=>	collider.isSolid() ?
				collider :
				null;

	// method: return this given collider if it is trigger, otherwise returning null //
	public static Collider ifTriggerOtherwiseNull(this Collider collider)
		=>	collider.isTrigger ?
				collider :
				null;
	#endregion handling solidity


	#region accessing local or descendant colliders based on solidity

	#region accessing local or descendant solid colliders
	// methods: return this given provided game object's first local or descendant solid collider of the specified collider type (null if none found), optionally including inactive colliders according to the given boolean //
	public static ColliderT firstLocalOrDescendantSolid<ColliderT>(this GameObject gameObject, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> gameObject.localAndDescendant<ColliderT>(includeInactiveColliders).firstWhere(collider => collider.isSolid());
	public static ColliderT firstLocalOrDescendantSolid<ColliderT>(this Component component, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> component.gameObject.firstLocalOrDescendantSolid<ColliderT>(includeInactiveColliders);
	#endregion accessing local or descendant solid colliders

	#region accessing local or descendant trigger colliders
	// methods: return this given provided game object's first local or descendant trigger collider of the specified collider type (null if none found), optionally including inactive colliders according to the given boolean //
	public static ColliderT firstLocalOrDescendantTrigger<ColliderT>(this GameObject gameObject, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> gameObject.localAndDescendant<ColliderT>(includeInactiveColliders).firstWhere(collider => collider.isTrigger);
	public static ColliderT firstLocalOrDescendantTrigger<ColliderT>(this Component component, bool includeInactiveColliders = Default.inclusionOfInactiveComponents) where ColliderT : Collider
		=> component.gameObject.firstLocalOrDescendantTrigger<ColliderT>(includeInactiveColliders);
	#endregion accessing local or descendant trigger colliders
	#endregion accessing local or descendant colliders based on solidity

	
	#region point determination

	// method: return whether this given provided position is a point on the given provided collider //
	public static bool isPointOn(this object position_PositionProvider, object collider_ColliderProvider)
	{
		Collider collider = collider_ColliderProvider.provideCollider();

		return	position_PositionProvider.providePosition()
					.positionalColliders
					(
						collider.toTriggerColliderQuery(),
						collider.asLayerMask()
					).contains(collider);
	}
	#endregion  point determination


	#region nearest point to

	// method: return the point on this given collider that is nearest to the given provided position //
	public static Vector3 nearestPointToPosition(this Collider collider, object position_PositionProvider)
		=> collider.ClosestPoint(position_PositionProvider.providePosition());
	#endregion nearest point to


	#region conversion

	// method: return the trigger collider query for this given collider //
	public static QueryTriggerInteraction toTriggerColliderQuery(this Collider collider)
		=>	collider.isTrigger ?
				QueryTriggerInteraction.Collide :
				QueryTriggerInteraction.Ignore;
	#endregion conversion
}