using Script.Main.Utility.Base;

namespace Script.Main.Actor.Entity{
	public class Weapon : AggregateRoot{
		public int CurrentAmmoCount{ get; set; }
		public int MaxAmmoCount{ get; set; }

		public void Fire(){ }
		public void Reload(){ }
	}
}