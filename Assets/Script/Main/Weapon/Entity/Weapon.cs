using Script.Main.Utility.Base;

namespace Script.Main.Weapon.Entity{
	public class Weapon : AggregateRoot{
		public Weapon(int maxAmmoCount){
			MaxAmmoCount = maxAmmoCount;
			CurrentAmmoCount = MaxAmmoCount;
		}

		public int CurrentAmmoCount{ get; private set; }
		public int MaxAmmoCount{ get; }
		public void Fire(){ }
		public void Reload(){ }
	}
}