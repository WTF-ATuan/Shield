using Script.Main.Actor.Entity;
using Script.Main.Utility;

namespace Script.Main.Actor.Event{
	public class WeaponSwiped : ViewEvent{
		public Weapon CurrentWeapon{ get; }
		public Weapon SwipeWeapon{ get; }

		public WeaponSwiped(Weapon currentWeapon, Weapon swipeWeapon){
			CurrentWeapon = currentWeapon;
			SwipeWeapon = swipeWeapon;
			throw new System.NotImplementedException();
		}
	}
}