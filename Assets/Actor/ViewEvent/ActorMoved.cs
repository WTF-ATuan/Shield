using Actor.ResponDTO;

namespace Actor.ViewEvent{
	public class ActorMoved{
		public string ActorID{ get; }
		public ActorMoveData ActorMoveData{ get; }

		public ActorMoved(string actorID, ActorMoveData actorMoveData){
			ActorID = actorID;
			ActorMoveData = actorMoveData;
		}
	}
}