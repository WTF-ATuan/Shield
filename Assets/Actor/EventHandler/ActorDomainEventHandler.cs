using Actor.ResponseDTO;
using Actor.ViewEvent;
using Project;
using Project.Event;

namespace Actor.EventHandler{
	public class ActorDomainEventHandler{
		private readonly Entity.Actor _actor = new Entity.Actor("123");

		public ActorDomainEventHandler(){
			EventBus.Subscribe<MoveInputDetected>(OnMoveInputDetected);
		}

		private void OnMoveInputDetected(MoveInputDetected obj){
			var horizontalValue = obj.HorizontalValue;
			var verticalValue = obj.VerticalValue;
			var isJump = obj.IsJump;
			_actor.Move(horizontalValue, verticalValue, isJump);
			var actorMoveData = _actor.GetMoveData();
			var actorID = _actor.ActorID;
			var actorMoved = new ActorMoved(actorID, actorMoveData);
			EventBus.Post(actorMoved);
		}
	}
}