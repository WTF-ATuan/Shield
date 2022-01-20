using Actor.ResponseDTO;

namespace Actor.Scripts.ViewEvent{
	public class ActorDirectionChanged{
		public string ActorID{ get; }
		public ActorDirectionData ActorDirectionData{ get; }

		public ActorDirectionChanged(string actorID, ActorDirectionData actorDirectionData){
			ActorID = actorID;
			ActorDirectionData = actorDirectionData;
		}
	}
}