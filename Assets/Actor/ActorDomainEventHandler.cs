using Project;
using Project.Event;

namespace Actor{
	public class ActorDomainEventHandler{
		private Entity.Actor _actor = new Entity.Actor("123");
		public ActorDomainEventHandler(){
			EventBus.Subscribe<MoveInputDetected>(OnMoveInputDetected);
		}

		private void OnMoveInputDetected(MoveInputDetected obj){
			var horizontalValue = obj.HorizontalValue;
			var verticalValue = obj.VerticalValue;
			var isJump = obj.IsJump;
		}
	}
}