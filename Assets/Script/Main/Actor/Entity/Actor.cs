using Script.Main.Actor.Event;
using Script.Main.Utility.Base;
using UnityEngine;

namespace Script.Main.Actor.Entity{
	public class Actor : AggregateRoot{
		public void Move(Vector3 direction){
			var actorMoved = new ActorMoved(direction);
			SaveEvent(actorMoved);
		}

		public void Equip(Weapon weapon){
			if(CurrentWeapon != weapon){
				var weaponSwiped = new WeaponSwiped(CurrentWeapon, weapon);
				SaveEvent(weaponSwiped);
			}

			CurrentWeapon = weapon;
		}

		public Weapon CurrentWeapon{ get; private set; }
	}
}