using Actor.ResponseDTO;

namespace Actor.Entity.Behavior{
	public interface IActorMoveCondition{
		void Condition(float horizontal, float vertical, bool isJump);
		ActorMoveData GetConditionData();
	}
}