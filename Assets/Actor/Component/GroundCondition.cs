using Actor.DomainEvent;
using Actor.Entity.Behavior;
using Actor.ResponseDTO;
using Project;
using UnityEngine;

namespace Actor.Component{
	public class GroundCondition : MonoBehaviour, IActorMoveCondition{
		[SerializeField] private float detectRange = 1.5f;
		[SerializeField] private bool isGround;

		private ActorMoveData _actorMoveData;

		private void Start(){
			var moveConditionAdded = new ActorMoveConditionAdded(this);
			EventBus.Post(moveConditionAdded);
		}

		public void Condition(float horizontal, float vertical, bool isJump){
			var actorTransform = transform;
			isGround = Physics.Raycast(actorTransform.position, Vector3.down, detectRange);
			_actorMoveData = isJump
					? new ActorMoveData(horizontal, vertical, isGround)
					: new ActorMoveData(horizontal, vertical, false);
		}

		public ActorMoveData GetConditionData(){
			return _actorMoveData;
		}
	}
}