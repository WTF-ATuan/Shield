using Script.Main.Utility;

namespace Script.Main.Actor.Event{
	public class WeaponSwiped : ViewEvent{
		public Weapon.Weapon CurrentWeapon{ get; }
		public Weapon.Weapon SwipeWeapon{ get; }

		public WeaponSwiped(Weapon.Weapon currentWeapon, Weapon.Weapon swipeWeapon){
			CurrentWeapon = currentWeapon;
			SwipeWeapon = swipeWeapon;
			throw new System.NotImplementedException();
		}
	}
}