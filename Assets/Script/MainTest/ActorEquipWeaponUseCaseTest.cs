using NUnit.Framework;
using Script.Main.Weapon.Repository;
using Script.Main.Weapon.UseCase;

namespace Script.MainTest{
	public class ActorEquipWeaponUseCaseTest{
		[Test]
		public void Simple_EquipWeapon(){
			var weaponRepository = new WeaponRepository();
			var weaponUseCase = new WeaponUseCase(weaponRepository);
			var actor = new Main.Actor.Entity.Actor("456" , 100);
			weaponUseCase.CreateWeapon("123" , 10);
			var weapon = weaponUseCase.GetWeapon("123");
			actor.Equip(weapon);
		}
	}
}