using Script.Main.Actor.Entity;
using Script.Main.Utility;

namespace Script.Main.Actor.Event{
	public class WeaponSwiped : ViewEvent{
		public Weapon.Entity.Weapon CurrentWeapon{ get; }
		public Weapon.Entity.Weapon SwipeWeapon{ get; }

		public WeaponSwiped(Weapon.Entity.Weapon currentWeapon, Weapon.Entity.Weapon swipeWeapon){
			CurrentWeapon = currentWeapon;
			SwipeWeapon = swipeWeapon;
			throw new System.NotImplementedException();
		}
	}
}