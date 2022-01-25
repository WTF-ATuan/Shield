using Actor.Scripts.ViewEvent;
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
			EventBus.Subscribe<ActorDirectionChanged>(OnActorDirectionChanged);
		}

		private void OnActorDirectionChanged(ActorDirectionChanged obj){
			var directionData = obj.ActorDirectionData;
			var direction = directionData.Direction;
			var strength = directionData.Strength;
			_actorBehavior.SetFaceDirection(direction, strength);
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