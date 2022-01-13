using System;
using Script.Main.Actor.Event;
using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Actor.Component{
	public class ActorViewEventHandler : MonoBehaviour{
		private Rigidbody _rigidbody;

		private void Start(){
			_rigidbody = GetComponent<Rigidbody>();
			EventBus.Subscribe<ViewEvent>(ViewEventHandler);
		}

		private void ViewEventHandler(ViewEvent obj){
			var type = obj.GetType();
			if(type == typeof(ActorMoved)){
				var actorMoved = (ActorMoved)obj;
				OnActorMoved(actorMoved);
			}
		}

		private void OnActorMoved(ActorMoved obj){
			var direction = obj.Direction;
			_rigidbody.velocity = direction;
		}
	}
}