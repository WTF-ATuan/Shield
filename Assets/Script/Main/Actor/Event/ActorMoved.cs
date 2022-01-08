using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Actor.Event{
	public class ActorMoved : ViewEvent{
		public Vector3 Direction{ get; }
		public bool IsJump{ get; }

		public ActorMoved(Vector3 direction , bool isJump){
			Direction = direction;
			IsJump = isJump;
		}
	}
}