using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collider Extensions:
// • provides extension methods for handling colliders
// #collider
public static class ColliderExtensions
{
	#region solidity determination

	// method: return whether this given collider is solid //
	public static bool isSolid(this Collider collider)
		=> !collider.isTrigger;
	#endregion solidity determination


	#region setting solidity

	// method: (according to the given boolean:) set this given collider's solidity to the given solidity boolean, then return this given collider //
	public static ColliderT setSolidityTo<ColliderT>(this ColliderT collider, bool solidity, bool boolean = true)
		where ColliderT : Collider
		=>	collider.after(()=>
				collider.isTrigger = !solidity,
				boolean);

	// method: (according to the given boolean:) solidify this given collider (set this given collider's solidity to true), then return this given collider //
	public static ColliderT solidify<ColliderT>(this ColliderT collider, bool boolean = true)
		where ColliderT : Collider
		=>	collider.setSolidityTo(true,
				boolean);

	// method: (according to the given boolean:) triggerize this given collider (set this given collider's solidity to false), then return this given collider //
	public static ColliderT triggerize<ColliderT>(this ColliderT collider, bool boolean = true)
		where ColliderT : Collider
		=>	collider.setSolidityTo(false,
				boolean);
	#endregion setting solidity


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