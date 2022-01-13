using Script.Main.Utility;

namespace Script.MainTest.Weapon{
	public class WeaponFired : ViewEvent{
		public string Uid{ get; }

		public WeaponFired(string uid){
			Uid = uid;
		}
	}
}