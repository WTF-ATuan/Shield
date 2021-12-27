using Script.Main.Actor.Event;
using Script.Main.Utility.Base;
using UnityEngine;

namespace Script.Main.Actor{
	public class Actor : AggregateRoot{
		public void Move(Vector3 direction){
			var actorMoved = new ActorMoved(direction);
			SaveEvent(actorMoved);
		}
	}
}