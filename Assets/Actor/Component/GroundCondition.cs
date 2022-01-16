using Actor.DomainEvent;
using Actor.Entity.Behavior;
using Actor.ResponseDTO;
using Project;
using UnityEngine;

namespace Actor.Component{
	public class GroundCondition : MonoBehaviour, IActorMoveCondition{
		private void Start(){
			var moveConditionAdded = new ActorMoveConditionAdded(this);
			EventBus.Post(moveConditionAdded);
		}

		public void Condition(float horizontal, float vertical, bool isJump){
			throw new System.NotImplementedException();
		}

		public ActorMoveData GetConditionData(){
			throw new System.NotImplementedException();
		}
	}
}