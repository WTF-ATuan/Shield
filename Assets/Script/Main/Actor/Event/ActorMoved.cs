using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Actor.Event{
	public class ActorMoved : ViewEvent{
		public Vector3 Direction{ get; }

		public ActorMoved(Vector3 direction){
			Direction = direction;
		}
	}
}