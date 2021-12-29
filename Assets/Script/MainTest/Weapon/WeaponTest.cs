using NUnit.Framework;

namespace Script.MainTest.Weapon{
	public class WeaponTest{
		[Test]
		public void Create_Weapon_With_Default_Setting(){
			const int defaultMaxAmmoCount = 30;
			var weapon = new Main.Weapon.Entity.Weapon(defaultMaxAmmoCount);
			Assert.NotNull(weapon);
			var currentAmmoCount = weapon.CurrentAmmoCount;
			Assert.AreEqual(defaultMaxAmmoCount, currentAmmoCount);
		}

		public void Weapon_Fired_Expend_Ammo(){
			var weapon = new Main.Weapon.Entity.Weapon(30);
			weapon.Fire();
			var currentAmmoCount = weapon.CurrentAmmoCount;
			weapon.GetEvent<WeaponFired>();
		}
	}
}