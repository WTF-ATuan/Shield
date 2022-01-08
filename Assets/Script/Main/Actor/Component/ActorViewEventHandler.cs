using Script.Main.Actor.Event;
using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Actor.Component{
	public class ActorViewEventHandler : MonoBehaviour{
		[SerializeField] private float moveSpeed;
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
			var inputDirection = obj.Direction;
			var moveVelocity = new Vector3(inputDirection.x, 0, inputDirection.z) * moveSpeed;
			var isJump = inputDirection.y > 0;
			_rigidbody.velocity = moveVelocity;
			if(isJump){
				moveVelocity.y = inputDirection.y;
				_rigidbody.AddForce(moveVelocity);
			}
		}
	}
}