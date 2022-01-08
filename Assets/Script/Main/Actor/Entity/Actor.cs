using Script.Main.Actor.Event;
using Script.Main.Utility.Base;
using UnityEngine;

namespace Script.Main.Actor.Entity{
	public class Actor : AggregateRoot{
		public string Uid{ get; }

		public Actor(string uid){
			Uid = uid;
			var actorCreated = new ActorCreated(uid);
			SaveEvent(actorCreated);
		}

		public void Move(Vector3 direction){
			var directionY = direction.y;
			var isJump = directionY > 0;
			var actorMoved = new ActorMoved(direction, isJump);
			SaveEvent(actorMoved);
		}

		public void Equip(Weapon.Entity.Weapon weapon){
			if(CurrentWeapon != weapon){
				var weaponSwiped = new WeaponSwiped(CurrentWeapon, weapon);
				SaveEvent(weaponSwiped);
			}

			CurrentWeapon = weapon;
		}

		public Weapon.Entity.Weapon CurrentWeapon{ get; private set; }
	}
}