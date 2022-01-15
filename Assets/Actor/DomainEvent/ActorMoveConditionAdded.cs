using Actor.Entity.Behavior;

namespace Actor.DomainEvent{
	public class ActorMoveConditionAdded{
		public IActorMoveCondition ActorMoveCondition{ get; }

		public ActorMoveConditionAdded(IActorMoveCondition actorMoveCondition){
			ActorMoveCondition = actorMoveCondition;
		}
	}
}