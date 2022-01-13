using System;
using Script.Main.Weapon.Repository;

namespace Script.Main.Weapon.UseCase{
	public class WeaponUseCase{
		private WeaponRepository Repository{ get; }

		public WeaponUseCase(WeaponRepository repository){
			Repository = repository;
		}

		public void CreateWeapon(string uid , int maxAmmoCount){
			var weapon = new Entity.Weapon(uid , maxAmmoCount);
			Repository.Save(weapon);
		}

		public Entity.Weapon GetWeapon(string uid){
			if(string.IsNullOrEmpty(uid)) throw new Exception("uid is Null or Empty");
			var weapon = Repository.Find(uid);
			return weapon;
		}
	}
}