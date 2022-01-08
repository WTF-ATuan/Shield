using Script.Main.Utility;

namespace Script.Main.Actor.Event{
	public class HealthModified : ViewEvent{
		public string Uid{ get; }
		public int CurrentHealth{ get; }

		public HealthModified(string uid, int currentHealth){
			Uid = uid;
			CurrentHealth = currentHealth;
		}
	}
}