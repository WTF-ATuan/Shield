using Script.Main.Utility;

namespace Script.Main.Weapon.Event{
	public class WeaponUnFired : ViewEvent{
		public string Uid{ get; }

		public WeaponUnFired(string uid){
			Uid = uid;
		}
	}
}