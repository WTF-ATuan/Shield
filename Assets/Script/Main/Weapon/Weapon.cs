using Script.Main.Utility.Base;

namespace Script.Main.Weapon{
	public class Weapon : AggregateRoot{
		public int CurrentAmmoCount{ get; set; }
		public int MaxAmmoCount{ get; set; }

		public void Fire(){ }
		public void Reload(){ }
	}
}