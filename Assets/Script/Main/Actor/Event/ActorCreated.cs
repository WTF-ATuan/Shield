using Script.Main.Utility;

namespace Script.Main.Actor.Event{
	public class ActorCreated : ViewEvent{
		public string Uid{ get; }

		public ActorCreated(string uid){
			Uid = uid;
		}
	}
}