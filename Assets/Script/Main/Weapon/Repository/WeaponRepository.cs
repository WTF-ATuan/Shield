using System;
using System.Collections.Generic;

namespace Script.Main.Weapon.Repository{
	public class WeaponRepository{
		private readonly List<Entity.Weapon> _weaponList = new List<Entity.Weapon>();

		public void Save(Entity.Weapon weapon){
			if(weapon == null) throw new NullReferenceException($"Can,t Save Empty Weapon");
			_weaponList.Add(weapon);
		}

		public int WeaponCount => _weaponList.Count;

		public Entity.Weapon Find(string uid){
			var weapon = _weaponList.Find(actor => actor.Uid == uid);
			return weapon;
		}
	}
}