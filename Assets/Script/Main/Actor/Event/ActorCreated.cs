using Script.Main.Utility;

namespace Script.Main.Actor.Event{
	public class ActorCreated : DomainEvent{
		public string Uid{ get; }

		public ActorCreated(string uid){
			Uid = uid;
		}
	}
}