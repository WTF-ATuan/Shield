using Script.Main.Utility.Base;
using Script.Main.Weapon.Event;
using Script.MainTest.Weapon;

namespace Script.Main.Weapon.Entity{
	public class Weapon : AggregateRoot{
		public Weapon(string uid , int maxAmmoCount){
			Uid = uid;
			MaxAmmoCount = maxAmmoCount;
			CurrentAmmoCount = MaxAmmoCount;
		}

		public string Uid{ get; }
		public int CurrentAmmoCount{ get; private set; }
		public int MaxAmmoCount{ get; }

		public void Fire(){
			if(CurrentAmmoCount > 1){
				CurrentAmmoCount--;
				var weaponFired = new WeaponFired();
				SaveEvent(weaponFired);
			}
			else{
				var weaponUnFired = new WeaponUnFired();
				SaveEvent(weaponUnFired);
			}
		}

		public void Reload(){ }
	}
}