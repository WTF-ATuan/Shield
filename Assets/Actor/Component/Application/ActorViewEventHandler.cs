using Actor.ViewEvent;
using Project;
using UnityEngine;

namespace Actor.Component.Application{
	public class ActorViewEventHandler : MonoBehaviour{
		private ActorBehavior _actorBehavior;

		private void Awake(){
			_actorBehavior = GetComponent<ActorBehavior>();
			EventHandler();
		}

		private void EventHandler(){
			EventBus.Subscribe<ActorMoved>(OnActorMoved);
		}

		private void OnActorMoved(ActorMoved obj){
			var actorMoveData = obj.ActorMoveData;
			var horizontal = actorMoveData.Horizontal;
			var vertical = actorMoveData.Vertical;
			var isJump = actorMoveData.IsJump;
			var moveValue = new Vector3(horizontal, 0, vertical);
			_actorBehavior.MoveActor(moveValue, isJump);
		}
	}
}